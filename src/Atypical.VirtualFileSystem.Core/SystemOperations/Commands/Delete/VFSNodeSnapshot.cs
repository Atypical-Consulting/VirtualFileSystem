// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
//
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Captures the state of a node that was removed during a directory deletion,
/// so the deletion can be reversed by the change history.
/// </summary>
/// <param name="Path">The path of the deleted node.</param>
/// <param name="IsDirectory"><c>true</c> if the node was a directory; otherwise <c>false</c>.</param>
/// <param name="Content">The file content, or <c>null</c> for directories.</param>
public sealed record VFSNodeSnapshot(VFSPath Path, bool IsDirectory, string? Content);
