// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using System.Runtime.Serialization;

namespace Atypical.VirtualFileSystem.Core.Exceptions;

/// <summary>
///     Exception thrown by the VFS.
/// </summary>
[Serializable]
public class VFSException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSException"/> class.
    /// </summary>
    public VFSException()
    {
    }

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

    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSException"/> class with a specified error message and a reference to the
    ///     inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
    protected VFSException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
    