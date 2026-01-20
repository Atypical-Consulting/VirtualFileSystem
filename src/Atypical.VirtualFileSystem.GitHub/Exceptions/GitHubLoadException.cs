// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.GitHub.Exceptions;

/// <summary>
/// Exception thrown when loading a GitHub repository fails.
/// </summary>
[Serializable]
public class GitHubLoadException : Exception
{
    /// <summary>
    /// Gets the owner of the repository that failed to load.
    /// </summary>
    public string? Owner { get; }

    /// <summary>
    /// Gets the name of the repository that failed to load.
    /// </summary>
    public string? Repository { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLoadException"/> class.
    /// </summary>
    public GitHubLoadException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLoadException"/> class with a message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public GitHubLoadException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLoadException"/> class with repository details.
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="message">The error message.</param>
    public GitHubLoadException(string owner, string repository, string message)
        : base($"Failed to load repository '{owner}/{repository}': {message}")
    {
        Owner = owner;
        Repository = repository;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLoadException"/> class with a message and inner exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of this exception.</param>
    public GitHubLoadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLoadException"/> class with repository details and inner exception.
    /// </summary>
    /// <param name="owner">The repository owner.</param>
    /// <param name="repository">The repository name.</param>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The exception that is the cause of this exception.</param>
    public GitHubLoadException(string owner, string repository, string message, Exception innerException)
        : base($"Failed to load repository '{owner}/{repository}': {message}", innerException)
    {
        Owner = owner;
        Repository = repository;
    }
}
