// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Exception thrown by the VFS.
/// </summary>
[Serializable]
public class VirtualFileSystemException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualFileSystemException"/> class.
    /// </summary>
    public VirtualFileSystemException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualFileSystemException"/> class with a message that describes the error.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public VirtualFileSystemException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VirtualFileSystemException"/> class with a message and an inner exception that is the cause
    ///     of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference if no inner
    ///     exception is specified.
    /// </param>
    public VirtualFileSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
    