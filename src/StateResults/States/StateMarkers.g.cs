/*
    NOTE: Auto-generated file.
    Don't make manual changes here.
*/
#nullable enable

using BMTLab.StateResults.Abstractions;

namespace BMTLab.StateResults.States;

/// <summary>
///     Contains a set of common states representing the result of an operation.
/// </summary>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public static partial class StateMarkers
{
    ///<inheritdoc cref="ISuccessStateMarker" />
    [PublicAPI]
    public readonly record struct Success : ISuccessStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Success(string message) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
        }

        /// <inheritdoc />
        public string? Message { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct Deprecated : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Deprecated(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct NotImplemented : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public NotImplemented(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct Canceled : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Canceled(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct InternalError : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public InternalError(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct ExternalError : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public ExternalError(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct NotFound : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public NotFound(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct NotExist : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public NotExist(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct CannotBeAdded : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public CannotBeAdded(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct CannotBeUpdated : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public CannotBeUpdated(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct CannotBeDeleted : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public CannotBeDeleted(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct Unauthorized : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Unauthorized(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


    ///<inheritdoc cref="IErrorStateMarker" />
    [PublicAPI]
    public readonly record struct Forbidden : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Forbidden(string message, Exception? exception = default) : this()
        {
            ThrowIfNullOrWhiteSpace(message);

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


}


