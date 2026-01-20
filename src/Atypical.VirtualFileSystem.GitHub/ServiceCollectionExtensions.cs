// Copyright (c) 2022-2025, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Atypical.VirtualFileSystem.GitHub;

/// <summary>
/// Extension methods for registering GitHub VFS services in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the GitHub repository loader services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddVirtualFileSystem();
    /// services.AddVirtualFileSystemGitHub();
    /// </code>
    /// </example>
    public static IServiceCollection AddVirtualFileSystemGitHub(this IServiceCollection services)
    {
        services.TryAddSingleton<IGitHubRepositoryLoader, GitHubRepositoryLoader>();
        services.TryAddSingleton(GitHubLoaderOptions.Default);
        return services;
    }

    /// <summary>
    /// Registers the GitHub repository loader services with custom options.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">An action to configure the default options.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddVirtualFileSystem();
    /// services.AddVirtualFileSystemGitHub(options =>
    /// {
    ///     options = options with { AccessToken = configuration["GitHub:Token"] };
    ///     return options;
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddVirtualFileSystemGitHub(
        this IServiceCollection services,
        Func<GitHubLoaderOptions, GitHubLoaderOptions> configureOptions)
    {
        var options = configureOptions(GitHubLoaderOptions.Default);
        services.TryAddSingleton(options);
        services.TryAddSingleton<IGitHubRepositoryLoader>(sp =>
            new GitHubRepositoryLoader(sp.GetRequiredService<GitHubLoaderOptions>()));
        return services;
    }

    /// <summary>
    /// Registers the GitHub repository loader services with a specific access token.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="accessToken">The GitHub Personal Access Token.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <example>
    /// <code>
    /// services.AddVirtualFileSystem();
    /// services.AddVirtualFileSystemGitHub(configuration["GitHub:Token"]);
    /// </code>
    /// </example>
    public static IServiceCollection AddVirtualFileSystemGitHub(
        this IServiceCollection services,
        string? accessToken)
    {
        var options = GitHubLoaderOptions.Default with { AccessToken = accessToken };
        services.TryAddSingleton(options);
        services.TryAddSingleton<IGitHubRepositoryLoader>(sp =>
            new GitHubRepositoryLoader(sp.GetRequiredService<GitHubLoaderOptions>()));
        return services;
    }

    /// <summary>
    /// Registers the GitHub repository loader services with the specified options.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="options">The loader options to use.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <example>
    /// <code>
    /// var options = new GitHubLoaderOptions(
    ///     AccessToken: configuration["GitHub:Token"],
    ///     MaxFileSize: 5_000_000,
    ///     ExcludePatterns: ["**/node_modules/**"]
    /// );
    /// services.AddVirtualFileSystem();
    /// services.AddVirtualFileSystemGitHub(options);
    /// </code>
    /// </example>
    public static IServiceCollection AddVirtualFileSystemGitHub(
        this IServiceCollection services,
        GitHubLoaderOptions options)
    {
        services.TryAddSingleton(options);
        services.TryAddSingleton<IGitHubRepositoryLoader>(sp =>
            new GitHubRepositoryLoader(sp.GetRequiredService<GitHubLoaderOptions>()));
        return services;
    }
}
