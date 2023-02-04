// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Exceptions;

/// <summary>
///     Exception thrown by the VFS.
/// </summary>
public class VFSException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSException"/> class with a message that describes the error.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public VFSException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSException"/> class with a message and an inner exception that is the cause
    ///     of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference if no inner
    ///     exception is specified.
    /// </param>
    public VFSException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}