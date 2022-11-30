// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Abstractions;

public abstract record VFSNode
    : IVirtualFileSystemNode
{
    protected VFSNode(VFSPath path)
    {
        ArgumentNullException.ThrowIfNull(path);

        // set timestamps
        var now = DateTime.UtcNow;
        CreationTime = now;
        LastAccessTime = now;
        LastWriteTime = now;
    }

    public abstract VFSPath Path { get; }
    
    public DateTimeOffset CreationTime { get; }
    public DateTimeOffset LastAccessTime { get; }
    public DateTimeOffset LastWriteTime { get; }
    public abstract bool IsDirectory { get; }
    public abstract bool IsFile { get; }
}