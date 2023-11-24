// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.DemoCli.WIP;

public interface IFileSystemWatcher
{
    event Action<VFSPath> OnChanged;

    void StartWatching();
    void StopWatching();
}