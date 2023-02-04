// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Constants used by the Virtual File System.
/// </summary>
public static class VFSConstants
{
    /// <summary>
    ///     The root path.
    ///     This is the path used to identify the root directory.
    /// </summary>
    public const string ROOT_PATH = "vfs://";

    /// <summary>
    ///     The directory separator.
    ///     This is the character used to separate directory names.
    /// </summary>
    public const string DIRECTORY_SEPARATOR = "/";

    /// <summary>
    ///     The string indent clear.
    ///     A 4 characters string used by a string builder to indent a line.
    /// </summary>
    public const string STR_INDENT_CLEAR = "    ";

    /// <summary>
    ///     The string indent entry middle.
    ///     A 4 characters string used by a string builder to indent a line which is not the last one.
    /// </summary>
    public const string STR_INDENT_ENTRY_MIDDLE = "├── ";

    /// <summary>
    ///     The string indent entry last.
    ///     A 4 characters string used by a string builder to indent a line which is the last one.
    /// </summary>
    public const string STR_INDENT_ENTRY_LAST = "└── ";

    /// <summary>
    ///     The string indent entry fill.
    ///     A 4 characters string used by a string builder to indent a line which is not the last one.
    /// </summary>
    public const string STR_INDENT_FILL = "│   ";
}