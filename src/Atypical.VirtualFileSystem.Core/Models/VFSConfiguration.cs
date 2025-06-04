// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core.Models;

/// <summary>
/// Configuration options for the Virtual File System.
/// </summary>
public sealed record VFSConfiguration
{
    /// <summary>
    /// Gets the default VFS configuration.
    /// </summary>
    public static VFSConfiguration Default { get; } = new();

    /// <summary>
    /// Gets or sets whether file and directory operations are case sensitive.
    /// Default is false (case insensitive).
    /// </summary>
    public bool CaseSensitive { get; init; } = false;

    /// <summary>
    /// Gets or sets the maximum depth for recursive operations.
    /// Default is 100 to prevent infinite recursion.
    /// </summary>
    public int MaxRecursionDepth { get; init; } = 100;

    /// <summary>
    /// Gets or sets whether to enable change history tracking.
    /// Default is true.
    /// </summary>
    public bool EnableChangeHistory { get; init; } = true;

    /// <summary>
    /// Gets or sets the maximum number of operations to keep in change history.
    /// Default is 1000. Set to 0 for unlimited (not recommended).
    /// </summary>
    public int MaxChangeHistorySize { get; init; } = 1000;

    /// <summary>
    /// Gets or sets whether to validate paths on creation.
    /// Default is true.
    /// </summary>
    public bool ValidatePaths { get; init; } = true;

    /// <summary>
    /// Gets or sets whether to normalize paths automatically.
    /// Default is true.
    /// </summary>
    public bool NormalizePaths { get; init; } = true;

    /// <summary>
    /// Gets or sets the maximum file size in bytes for content operations.
    /// Default is 1MB. Set to 0 for unlimited.
    /// </summary>
    public long MaxFileSize { get; init; } = 1024 * 1024; // 1MB

    /// <summary>
    /// Gets or sets whether to enable index caching for performance.
    /// Default is true.
    /// </summary>
    public bool EnableIndexCaching { get; init; } = true;

    /// <summary>
    /// Gets or sets the string comparison type for path operations.
    /// </summary>
    public StringComparison PathComparison => CaseSensitive 
        ? StringComparison.Ordinal 
        : StringComparison.OrdinalIgnoreCase;

    /// <summary>
    /// Gets or sets custom path separators. Default uses forward slash.
    /// </summary>
    public PathSeparatorConfiguration PathSeparators { get; init; } = PathSeparatorConfiguration.Default;

    /// <summary>
    /// Gets or sets event handling configuration.
    /// </summary>
    public EventConfiguration Events { get; init; } = EventConfiguration.Default;

    /// <summary>
    /// Creates a new configuration with case sensitivity enabled.
    /// </summary>
    /// <returns>A new configuration with case sensitivity enabled.</returns>
    public VFSConfiguration WithCaseSensitivity()
        => this with { CaseSensitive = true };

    /// <summary>
    /// Creates a new configuration with case insensitivity.
    /// </summary>
    /// <returns>A new configuration with case insensitivity.</returns>
    public VFSConfiguration WithCaseInsensitivity()
        => this with { CaseSensitive = false };

    /// <summary>
    /// Creates a new configuration with change history disabled.
    /// </summary>
    /// <returns>A new configuration with change history disabled.</returns>
    public VFSConfiguration WithoutChangeHistory()
        => this with { EnableChangeHistory = false };

    /// <summary>
    /// Creates a new configuration with custom maximum file size.
    /// </summary>
    /// <param name="maxSize">Maximum file size in bytes.</param>
    /// <returns>A new configuration with the specified maximum file size.</returns>
    public VFSConfiguration WithMaxFileSize(long maxSize)
        => this with { MaxFileSize = maxSize };

    /// <summary>
    /// Creates a new configuration optimized for performance.
    /// </summary>
    /// <returns>A new performance-optimized configuration.</returns>
    public VFSConfiguration ForPerformance()
        => this with 
        { 
            EnableChangeHistory = false,
            ValidatePaths = false,
            MaxChangeHistorySize = 0,
            EnableIndexCaching = true
        };

    /// <summary>
    /// Creates a new configuration optimized for safety and validation.
    /// </summary>
    /// <returns>A new safety-optimized configuration.</returns>
    public VFSConfiguration ForSafety()
        => this with 
        { 
            ValidatePaths = true,
            NormalizePaths = true,
            MaxRecursionDepth = 50,
            MaxFileSize = 512 * 1024 // 512KB
        };
}

/// <summary>
/// Configuration for path separators.
/// </summary>
public sealed record PathSeparatorConfiguration
{
    /// <summary>
    /// Gets the default path separator configuration.
    /// </summary>
    public static PathSeparatorConfiguration Default { get; } = new();

    /// <summary>
    /// Gets or sets the primary path separator. Default is '/'.
    /// </summary>
    public char PrimarySeparator { get; init; } = '/';

    /// <summary>
    /// Gets or sets alternative path separators that are accepted.
    /// Default accepts both '/' and '\'.
    /// </summary>
    public char[] AlternativeSeparators { get; init; } = { '\\' };

    /// <summary>
    /// Gets all accepted path separators.
    /// </summary>
    public char[] AllSeparators => new[] { PrimarySeparator }.Concat(AlternativeSeparators).Distinct().ToArray();

    /// <summary>
    /// Creates a configuration that only accepts forward slashes.
    /// </summary>
    /// <returns>A configuration for Unix-style paths only.</returns>
    public static PathSeparatorConfiguration UnixOnly()
        => new() { PrimarySeparator = '/', AlternativeSeparators = Array.Empty<char>() };

    /// <summary>
    /// Creates a configuration that only accepts backslashes.
    /// </summary>
    /// <returns>A configuration for Windows-style paths only.</returns>
    public static PathSeparatorConfiguration WindowsOnly()
        => new() { PrimarySeparator = '\\', AlternativeSeparators = Array.Empty<char>() };
}

/// <summary>
/// Configuration for event handling.
/// </summary>
public sealed record EventConfiguration
{
    /// <summary>
    /// Gets the default event configuration.
    /// </summary>
    public static EventConfiguration Default { get; } = new();

    /// <summary>
    /// Gets or sets whether to enable all events. Default is true.
    /// </summary>
    public bool EnableEvents { get; init; } = true;

    /// <summary>
    /// Gets or sets whether to enable file operation events.
    /// </summary>
    public bool EnableFileEvents { get; init; } = true;

    /// <summary>
    /// Gets or sets whether to enable directory operation events.
    /// </summary>
    public bool EnableDirectoryEvents { get; init; } = true;

    /// <summary>
    /// Gets or sets whether events should be fired asynchronously.
    /// Default is false for synchronous events.
    /// </summary>
    public bool AsyncEvents { get; init; } = false;

    /// <summary>
    /// Gets or sets the maximum number of event handlers per event type.
    /// Default is 100. Set to 0 for unlimited.
    /// </summary>
    public int MaxEventHandlers { get; init; } = 100;

    /// <summary>
    /// Creates a configuration with all events disabled.
    /// </summary>
    /// <returns>A configuration with events disabled.</returns>
    public static EventConfiguration Disabled()
        => new() { EnableEvents = false, EnableFileEvents = false, EnableDirectoryEvents = false };

    /// <summary>
    /// Creates a configuration with only file events enabled.
    /// </summary>
    /// <returns>A configuration with only file events enabled.</returns>
    public static EventConfiguration FileEventsOnly()
        => new() { EnableDirectoryEvents = false };

    /// <summary>
    /// Creates a configuration with only directory events enabled.
    /// </summary>
    /// <returns>A configuration with only directory events enabled.</returns>
    public static EventConfiguration DirectoryEventsOnly()
        => new() { EnableFileEvents = false };

    /// <summary>
    /// Creates a configuration with asynchronous events.
    /// </summary>
    /// <returns>A configuration with asynchronous events enabled.</returns>
    public EventConfiguration WithAsyncEvents()
        => this with { AsyncEvents = true };
}