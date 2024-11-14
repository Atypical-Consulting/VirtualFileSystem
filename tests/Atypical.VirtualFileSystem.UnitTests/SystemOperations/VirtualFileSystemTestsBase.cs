// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.SystemOperations;

public abstract class VirtualFileSystemTestsBase
{
    protected static IVirtualFileSystem CreateVFS()
        => new VirtualFileSystemFactory().CreateFileSystem();
}