// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using Microsoft.Extensions.DependencyInjection;

namespace VirtualFileSystem.UnitTests.Services;

public static class ServiceCollectionExtensionsTests
{
    public class MethodAddVirtualFileSystem
    {
        [Fact]
        public void AddVirtualFileSystem_registers_VirtualFileSystem_in_DI()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddVirtualFileSystem();

            // Assert
            services.ShouldContain(service => service.ServiceType == typeof(IVirtualFileSystem)
                                    && service.ImplementationType == typeof(VFS)
                                    && service.Lifetime == ServiceLifetime.Scoped);
        }
    }
}