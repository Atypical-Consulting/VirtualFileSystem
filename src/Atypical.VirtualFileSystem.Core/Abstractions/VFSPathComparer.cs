namespace Atypical.VirtualFileSystem.Core.Abstractions;

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