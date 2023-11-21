// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Compares two <see cref="VFSPath" /> objects for equivalence.
/// </summary>
internal sealed class VFSPathComparer : IComparer<VFSPath>
{
    /// <inheritdoc />
    public int Compare(VFSPath? x, VFSPath? y)
    {
        if (x is null)
            return y is null ? 0 : -1;

        if (y is null)
            return 1;

        return string.Compare(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
    }
}