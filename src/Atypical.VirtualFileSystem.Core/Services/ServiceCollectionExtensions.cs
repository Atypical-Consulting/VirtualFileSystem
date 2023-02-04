// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Atypical.VirtualFileSystem.Core.Services;

/// <summary>
///     Extension methods for <see cref="IServiceCollection" />.
///     This class is used to register the virtual file system in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Registers the virtual file system in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddVirtualFileSystem(this IServiceCollection services)
    {
        services.TryAddScoped<IVirtualFileSystem, VFS>();
        return services;
    }
}