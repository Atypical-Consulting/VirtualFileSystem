// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents the result of an operation that can either succeed or fail without throwing exceptions.
/// </summary>
/// <typeparam name="T">The type of the success value.</typeparam>
public readonly record struct Result<T>
{
    private readonly T? _value;
    private readonly string? _error;
    private readonly bool _isSuccess;

    private Result(T value)
    {
        _value = value;
        _error = null;
        _isSuccess = true;
    }

    private Result(string error)
    {
        _value = default;
        _error = error;
        _isSuccess = false;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess => _isSuccess;

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsFailure => !_isSuccess;

    /// <summary>
    /// Gets the success value. Only available when IsSuccess is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessing Value on a failed result.</exception>
    public T Value => _isSuccess ? _value! : throw new InvalidOperationException($"Cannot access Value on failed result. Error: {_error}");

    /// <summary>
    /// Gets the error message. Only available when IsFailure is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessing Error on a successful result.</exception>
    public string Error => !_isSuccess ? _error! : throw new InvalidOperationException("Cannot access Error on successful result.");

    /// <summary>
    /// Creates a successful result with the specified value.
    /// </summary>
    /// <param name="value">The success value.</param>
    /// <returns>A successful result.</returns>
    public static Result<T> Success(T value) => new(value);

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed result.</returns>
    public static Result<T> Failure(string error) => new(error);

    /// <summary>
    /// Creates a failed result from an exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>A failed result with the exception message.</returns>
    public static Result<T> Failure(Exception exception) => new(exception.Message);

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <param name="action">The action to execute with the value.</param>
    /// <returns>The current result for chaining.</returns>
    public Result<T> OnSuccess(Action<T> action)
    {
        if (_isSuccess)
            action(_value!);
        return this;
    }

    /// <summary>
    /// Executes an action if the result is a failure.
    /// </summary>
    /// <param name="action">The action to execute with the error message.</param>
    /// <returns>The current result for chaining.</returns>
    public Result<T> OnFailure(Action<string> action)
    {
        if (!_isSuccess)
            action(_error!);
        return this;
    }

    /// <summary>
    /// Transforms the success value to another type.
    /// </summary>
    /// <typeparam name="TNew">The new value type.</typeparam>
    /// <param name="mapper">The transformation function.</param>
    /// <returns>A new result with the transformed value or the original error.</returns>
    public Result<TNew> Map<TNew>(Func<T, TNew> mapper)
    {
        return _isSuccess ? Result<TNew>.Success(mapper(_value!)) : Result<TNew>.Failure(_error!);
    }

    /// <summary>
    /// Transforms the success value to another result.
    /// </summary>
    /// <typeparam name="TNew">The new value type.</typeparam>
    /// <param name="mapper">The transformation function that returns a result.</param>
    /// <returns>The result of the transformation or the original error.</returns>
    public Result<TNew> Bind<TNew>(Func<T, Result<TNew>> mapper)
    {
        return _isSuccess ? mapper(_value!) : Result<TNew>.Failure(_error!);
    }

    /// <summary>
    /// Gets the value if successful, or returns the specified default value.
    /// </summary>
    /// <param name="defaultValue">The default value to return on failure.</param>
    /// <returns>The success value or the default value.</returns>
    public T GetValueOrDefault(T defaultValue = default!) => _isSuccess ? _value! : defaultValue;

    /// <summary>
    /// Gets the value if successful, or gets a value from the specified function.
    /// </summary>
    /// <param name="defaultValueFactory">Function to create default value from error message.</param>
    /// <returns>The success value or the result of the default value factory.</returns>
    public T GetValueOrDefault(Func<string, T> defaultValueFactory) => _isSuccess ? _value! : defaultValueFactory(_error!);

    /// <summary>
    /// Implicitly converts a value to a successful result.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Result<T>(T value) => Success(value);

    /// <summary>
    /// Deconstructs the result into success flag and value/error.
    /// </summary>
    /// <param name="isSuccess">Whether the operation was successful.</param>
    /// <param name="valueOrError">The value if successful, or the error message if failed.</param>
    public void Deconstruct(out bool isSuccess, out object? valueOrError)
    {
        isSuccess = _isSuccess;
        valueOrError = _isSuccess ? _value : _error;
    }

    /// <summary>
    /// Returns a string representation of the result.
    /// </summary>
    /// <returns>A string describing the result.</returns>
    public override string ToString()
    {
        return _isSuccess ? $"Success({_value})" : $"Failure({_error})";
    }
}

/// <summary>
/// Represents the result of an operation that can either succeed or fail without a return value.
/// </summary>
public readonly record struct Result
{
    private readonly string? _error;
    private readonly bool _isSuccess;

    private Result(bool isSuccess, string? error = null)
    {
        _isSuccess = isSuccess;
        _error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess => _isSuccess;

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsFailure => !_isSuccess;

    /// <summary>
    /// Gets the error message. Only available when IsFailure is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessing Error on a successful result.</exception>
    public string Error => !_isSuccess ? _error! : throw new InvalidOperationException("Cannot access Error on successful result.");

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A successful result.</returns>
    public static Result Success() => new(true);

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed result.</returns>
    public static Result Failure(string error) => new(false, error);

    /// <summary>
    /// Creates a failed result from an exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>A failed result with the exception message.</returns>
    public static Result Failure(Exception exception) => new(false, exception.Message);

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    /// <returns>The current result for chaining.</returns>
    public Result OnSuccess(Action action)
    {
        if (_isSuccess)
            action();
        return this;
    }

    /// <summary>
    /// Executes an action if the result is a failure.
    /// </summary>
    /// <param name="action">The action to execute with the error message.</param>
    /// <returns>The current result for chaining.</returns>
    public Result OnFailure(Action<string> action)
    {
        if (!_isSuccess)
            action(_error!);
        return this;
    }

    /// <summary>
    /// Transforms the result to a result with a value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="valueFactory">Function to create the value on success.</param>
    /// <returns>A result with value on success or the original error on failure.</returns>
    public Result<T> Map<T>(Func<T> valueFactory)
    {
        return _isSuccess ? Result<T>.Success(valueFactory()) : Result<T>.Failure(_error!);
    }

    /// <summary>
    /// Combines this result with another result.
    /// </summary>
    /// <param name="other">The other result to combine with.</param>
    /// <returns>Success if both results are successful, otherwise failure with the first error.</returns>
    public Result Combine(Result other)
    {
        if (!_isSuccess)
            return this;
        if (!other._isSuccess)
            return other;
        return Success();
    }

    /// <summary>
    /// Returns a string representation of the result.
    /// </summary>
    /// <returns>A string describing the result.</returns>
    public override string ToString()
    {
        return _isSuccess ? "Success" : $"Failure({_error})";
    }
}