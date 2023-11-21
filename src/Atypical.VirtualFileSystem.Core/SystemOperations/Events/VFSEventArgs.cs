// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents the base class for all VFS event arguments.
/// </summary>
public abstract class VFSEventArgs : EventArgs
{
    /// <summary>
    /// Gets the message template.
    /// </summary>
    public abstract string MessageTemplate { get; }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public abstract string Message { get; }

    /// <summary>
    /// Gets the message with markup.
    /// </summary>
    public abstract string MessageWithMarkup { get; }

    /// <summary>
    /// Transforms a message into a markup message with the specified color.
    /// </summary>
    /// <param name="color">The color to use in the markup.</param>
    /// <param name="args">The arguments to format the message.</param>
    /// <returns>The markup message.</returns>
    protected string ToMarkup(string color, params object[] args)
    {
        var message = MessageTemplate;
        
        for (var i = 0; i < args.Length; i++)
            message = message.Replace($"'{{{i}}}'", $"[red][[ [/][{color}]{{{i}}}[/][red] ]][/]");

        return string.Format(message, args);
    }
}