/*
    This file was generated automatically, do not make changes to it manually!
*/
#nullable enable

// Use GuardClauses for null or white space check
#if !NET8_0_OR_GREATER
using Ardalis.GuardClauses;
#endif

using BMTLab.StateResults.Abstractions;

namespace Application.Models.StateResults.States;

/// <summary>
///     Contains a set of common states representing the result of an operation2.
/// </summary>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public static class StateMarkers
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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
    public readonly record struct AlreadyExists : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public AlreadyExists(string message, Exception? exception = default) : this()
        {
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
    public readonly record struct NotAdded : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public NotAdded(string message, Exception? exception = default) : this()
        {
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
    public readonly record struct NotUpdated : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public NotUpdated(string message, Exception? exception = default) : this()
        {
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

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
    public readonly record struct Prohibited : IErrorStateMarker
    {
        /// <param name="message"><see cref="Message"/>.</param>
        /// <param name="exception"><see cref="Exception"/>.</param>
        /// <exception cref="ArgumentNullException">if the <paramref name="message"/> string is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">if the <paramref name="message"/> string is empty or contains empty characters.</exception>
        public Prohibited(string message, Exception? exception = default) : this()
        {
            #if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            #else
            Guard.Against.NullOrWhiteSpace(message, nameof(message));
            #endif

            Message = message;
            Exception = exception;
        }

        /// <inheritdoc />
        public string? Message { get; init; }

        /// <inheritdoc />
        public Exception? Exception { get; init; }
    }


}


