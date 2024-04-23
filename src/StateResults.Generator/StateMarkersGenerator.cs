using System.Reflection;
using System.Text;

using BMTLab.StateResults.Abstractions;
using BMTLab.StateResults.Generator.Attributes;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using static System.String;
using static System.StringComparison;

namespace BMTLab.StateResults.Generator;

/// <inheritdoc />
[Generator]
public sealed class StateMarkersGenerator : IIncrementalGenerator
{
    private const string CsvHeader = "NAME,TYPE";
    private const string CsvExtension = ".csv";
    private const int DefaultStringBuilderCapacity = 8192;

    private static readonly Assembly CurrentAssembly = Assembly.GetAssembly(typeof(StateMarkersGenerator));
    private static readonly string AssemblyName = CurrentAssembly.GetName().Name;
    private static readonly string AssemblyVersion = CurrentAssembly.GetName().Version.ToString();


    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Combines class declarations marked with our attribute with all .csv files in the project
        var classDeclarationsWithAttributes =
            context.SyntaxProvider
                   .CreateSyntaxProvider(
                        static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 },
                        static (context, _) => GetClassAndAttributeInfo(context))
                   .Where(static info => info != default)
                   .Select(static (info, _) => info);

        // Combines the information from class declarations and csv files for processing
        var allCsvFiles = context.AdditionalTextsProvider.Where(static file => file.Path.EndsWith(CsvExtension, OrdinalIgnoreCase));
        var combined = classDeclarationsWithAttributes.Collect().Combine(allCsvFiles.Collect());

        context.RegisterSourceOutput(combined, static (spContext, source) =>
        {
            var (classDeclarations, csvFiles) = source;

            foreach (var classDeclaration in classDeclarations)
            {
                foreach (
                    var csvText in
                    from file in csvFiles
                    where file.Path.EndsWith(classDeclaration.FileName, OrdinalIgnoreCase)
                    select file.GetText(spContext.CancellationToken)
                )
                {
                    GenerateCode(spContext, classDeclaration.ClassDeclaration, csvText);
                }
            }
        });
    }


    /// <summary>
    ///     Extracts class and attribute information for generation.
    /// </summary>
    /// <param name="context">The generator syntax context.</param>
    /// <returns>A tuple of class declaration syntax and the filename from the attribute.</returns>
    private static (ClassDeclarationSyntax ClassDeclaration, string FileName) GetClassAndAttributeInfo(GeneratorSyntaxContext context)
    {
        var classDeclaration = (ClassDeclarationSyntax) context.Node;
        var attributeData = context.SemanticModel // Extracts the filename specified in the attribute
           .GetDeclaredSymbol(classDeclaration)?.GetAttributes()
           .FirstOrDefault(static ad => ad.AttributeClass!.ToDisplayString() == typeof(StateMarkersGeneratorAttribute).FullName);

        if (attributeData is null)
            return default;

        var fileNameArgument = attributeData.ConstructorArguments.FirstOrDefault().Value as string ?? StateMarkersGeneratorAttribute.DefaultFileName;

        if (!fileNameArgument.EndsWith(CsvExtension, OrdinalIgnoreCase))
            fileNameArgument += CsvExtension;

        return (classDeclaration, fileNameArgument);
    }


    /// <summary>
    ///     Generates the state markers based on the provided CSV content and class syntax.
    /// </summary>
    /// <param name="context">The source production context.</param>
    /// <param name="classSyntax">The class syntax where the generated code will be added.</param>
    /// <param name="csvText">The CSV content as SourceText.</param>
    private static void GenerateCode(SourceProductionContext context, BaseTypeDeclarationSyntax classSyntax, SourceText csvText)
    {
        // Prepare the source code builder
        var namespaceName = GetNamespace(classSyntax);
        var className = classSyntax.Identifier.ValueText;
        var sourceBuilder = new StringBuilder(DefaultStringBuilderCapacity);

        GenerateRootClass(sourceBuilder, namespaceName, className, csvText);

        var fileName = $"{classSyntax.Identifier.Text}.g.cs";
        context.AddSource(fileName, SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }


    /// <summary>
    ///     Prepares the source code builder with the root class structure.
    /// </summary>
    /// <param name="sourceBuilder">The StringBuilder instance for source code generation.</param>
    /// <param name="namespaceName">The namespace for the generated class.</param>
    /// <param name="rootClassName">The name of the root class.</param>
    /// <param name="text">The CSV content as SourceText.</param>
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
    private static void GenerateRootClass
    (
        StringBuilder sourceBuilder,
        string namespaceName,
        string rootClassName,
        SourceText text
    )
    {
        // Generate file header
        sourceBuilder.AppendLine(
            $$"""
              // <auto-generated/>
              #nullable enable

              namespace {{namespaceName}}
              {
                  /// <summary>
                  ///     Contains generated and other state types used as result markers in type unions.
                  /// </summary>
                  [System.CodeDom.Compiler.GeneratedCodeAttribute("{{AssemblyName}}", "{{AssemblyVersion}}")]
                  public static partial class {{rootClassName}}
                  {
              """);

        // To check if user has defined the None type in their .csv file, if not, it will be generated
        var isNoneExist = false;

        // Read and process each line from the CSV
        using (var reader = new StringReader(text.ToString()))
        {
            while (reader.ReadLine() is { } line)
            {
                if (IsHeaderOrEmpty(line.AsSpan()))
                    continue;

                var parts = line.Split(',');
                if (parts.Length != 2)
                    continue;

                var (name, type) = (NormalizeClassName(parts[0].AsSpan()), parts[1].Trim());
                GenerateStateStruct(sourceBuilder, name, type);

                if (name.Equals("NONE", OrdinalIgnoreCase))
                    isNoneExist = true;
            }
        }

        if (!isNoneExist)
        {
            sourceBuilder.AppendLine(
                """
                        /// <summary>
                        ///     Represents an empty result or a situation where there is no result. 
                        ///     At the user's discretion.
                        /// </summary>
                        /// <remarks>
                        ///     This is the default implementation when the user has not defined his None type in the .csv file.
                        /// </remarks>
                        public readonly record struct None;
                """);
        }
        else
        {
            // Remove the last line feed in the class
            sourceBuilder.Replace("\n", Empty, sourceBuilder.Length - 1, 1);
        }

        sourceBuilder.Append(
            """
                }
            }
            """);
    }


    /// <summary>
    ///     Generates state struct definitions within the root class.
    /// </summary>
    /// <param name="sourceBuilder">The StringBuilder instance for source code generation.</param>
    /// <param name="name">The name of the state struct.</param>
    /// <param name="type">The type of the state (success or error).</param>
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
    private static void GenerateStateStruct(StringBuilder sourceBuilder, string name, string type)
    {
        var isSuccessType = type.Equals("success", OrdinalIgnoreCase);
        var interfaceName = isSuccessType
            ? Intern($"global::{typeof(ISuccessStateMarker).FullName}")
            : Intern($"global::{typeof(IErrorStateMarker).FullName}");

        sourceBuilder.AppendLine(
            $$"""
                      ///<inheritdoc cref="{{interfaceName}}" />
                      public readonly record struct {{name}}() : {{interfaceName}}
                      {
              """);

        // Generating a constructor for the success type
        sourceBuilder.AppendLine(
            isSuccessType
                ? $"""
                               /// <summary>
                               ///     Initializes a new instance of the <see cref="{name}" /> struct.
                               /// </summary>
                               /// <param name="message">Optional descriptive message.</param>
                               public {name}(global::System.String? message) : this() =>
                                   Message = message;

                   """
                // Generating a constructor for an error type
                : $$"""
                                /// <summary>
                                ///     Initializes a new instance of the <see cref="{{name}}" /> struct with optional message and exception.
                                /// </summary>
                                /// <param name="message">Optional descriptive message.</param>
                                /// <param name="exception">Optional aggregated exception.</param>
                                public {{name}}(global::System.String? message = null, global::System.Exception? exception = null) : this()
                                {
                                    Message = message;
                                    Exception = exception;
                                }

                    """);


        sourceBuilder.AppendLine(
            """

                        /// <inheritdoc />
                        public global::System.String? Message { get; } = null;
            """);

        if (!isSuccessType)
            sourceBuilder.AppendLine(
                """

                            /// <inheritdoc />
                            public global::System.Exception? Exception { get; } = null;
                """);

        sourceBuilder.AppendLine(
            """
                    }

            """);
    }


    #region Helpers
    /// <summary>
    ///     Retrieves the namespace from the given syntax node.
    /// </summary>
    /// <param name="syntax">The syntax node to extract the namespace from.</param>
    /// <returns>The namespace as a string.</returns>
    [Pure]
    private static string GetNamespace(SyntaxNode syntax)
    {
        // If we don't have a namespace at all we'll return an empty string
        // This accounts for the "default namespace" case
        var @namespace = Empty;

        // Get the containing syntax node for the type declaration
        // (could be a nested type, for example)
        var potentialNamespaceParent = syntax.Parent;

        // Keep moving "out" of nested classes etc until we get to a namespace
        // or until we run out of parents
        while
        (
            potentialNamespaceParent is not null &&
            potentialNamespaceParent is not NamespaceDeclarationSyntax &&
            potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax
        )
            potentialNamespaceParent = potentialNamespaceParent.Parent;

        // Build up the final namespace by looping until we no longer have a namespace declaration
        if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
        {
            // We have a namespace. Use that as the type
            @namespace = namespaceParent.Name.ToString();

            // Keep moving "out" of the namespace declarations until we
            // run out of nested namespace declarations
            while (namespaceParent.Parent is NamespaceDeclarationSyntax parent)
            {
                // Add the outer namespace as a prefix to the final namespace
                @namespace = $"{namespaceParent.Name}.{@namespace}";
                namespaceParent = parent;
            }
        }

        return @namespace;
    }


    /// <summary>
    ///     Checks if a line from the CSV is a header or empty.
    /// </summary>
    /// <param name="line">The line to check.</param>
    /// <returns>True if the line is a header or empty; otherwise, false.</returns>
    [Pure]
    private static bool IsHeaderOrEmpty(ReadOnlySpan<char> line) =>
        line.IsWhiteSpace() || line.Contains(CsvHeader.AsSpan(), InvariantCultureIgnoreCase);


    /// <summary>
    ///     Normalizes class names by removing illegal characters and converting to PascalCase.
    /// </summary>
    /// <param name="name">The name to normalize.</param>
    /// <returns>The normalized class name.</returns>
    [Pure]
    private static string NormalizeClassName(ReadOnlySpan<char> name)
    {
        if (name.IsWhiteSpace())
            return "<NULL-PLEASE_REVIEW_YOUR_CSV-NULL>";

        Span<char> normalizedName = stackalloc char[name.Length];
        ReadOnlySpan<char> separators = stackalloc char[] { '_', '-', ' ' };

        var resultIndex = 0; // Index to write to the resulting Span<char>
        var toUpper = true; // Flag indicating whether the next character should be converted to upper case; first char will be converted.

        foreach (var currentChar in name)
        {
            if (separators.IndexOf(currentChar) != -1)
            {
                toUpper = true; // The next character will be in upper case
                continue; // Skip the separators
            }

            if (toUpper)
            {
                normalizedName[resultIndex++] = char.ToUpperInvariant(currentChar);
                toUpper = false;
            }
            else
            {
                normalizedName[resultIndex++] = currentChar;
            }
        }

        return normalizedName.Slice(0, resultIndex).ToString();
    }
    #endregion _Helpers
}