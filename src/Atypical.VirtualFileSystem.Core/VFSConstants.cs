// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

public static class VFSConstants
{
    public const string ROOT_PATH = "vfs://";
    public const string DIRECTORY_SEPARATOR = "/";
    
    public const string STR_INDENT_CLEAR = "    ";
    public const string STR_INDENT_ENTRY_MIDDLE = "├── ";
    public const string STR_INDENT_ENTRY_LAST = "└── ";
    public const string STR_INDENT_FILL = "│   ";
}