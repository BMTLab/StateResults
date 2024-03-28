# BMTLab.StateResults 
[![NuGet](https://img.shields.io/nuget/v/BMTLab.StateResults?logo=nuget)](https://www.nuget.org/packages/BMTLab.StateResults)
![Nuget Downloads](https://img.shields.io/nuget/dt/BMTLab.StateResults)
![.NET](https://github.com/BMTLab/StateResults/workflows/publish/badge.svg)

## OneOf.Reduced & StateResults - .NET 8 Discriminated Type Unions Library

This library introduces a powerful mechanism for discriminated type unions in .NET 8 through two main constructs: OneOf and Result/Results. 
Both these constructs can work with up to 6 type arguments (T0, T1, ... T5).

## How to Use
### OneOf.Reduced
The core concept of the library. Represents a choice between one of the given types.

1. Basic usage
```csharp
OneOf<string, int> union;

union = "Operation is successful";
Console.WriteLine(union); // >> Operation is successful

union = 42;
Console.WriteLine(union); // >> 42
```

2. Equality Check
```csharp
OneOf<bool, int, string> unionA = 42;
OneOf<bool, int, string> unionB = 42;

bool isMatch = unionA == unionB;
Console.WriteLine(isMatch); // >> True
```

3. Matching Values
```csharp
OneOf<int, string, Exception> union = "Some text";

string result = union.Match
(
    number => number.ToString(),
    text => text.ToUpperInvariant(),
    error => error.Message
);

Console.WriteLine(result); // >> SOME TEXT
```