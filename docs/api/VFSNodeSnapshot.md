#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core')

## VFSNodeSnapshot Class

Captures the state of a node that was removed during a directory deletion,
so the deletion can be reversed by the change history\.

```csharp
public sealed record VFSNodeSnapshot : System.IEquatable<Atypical.VirtualFileSystem.Core.VFSNodeSnapshot>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → VFSNodeSnapshot

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[VFSNodeSnapshot](VFSNodeSnapshot.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [VFSNodeSnapshot\(VFSPath, bool, string\)](VFSNodeSnapshot.VFSNodeSnapshot(VFSPath,bool,string).md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\.VFSNodeSnapshot\(Atypical\.VirtualFileSystem\.Core\.VFSPath, bool, string\)') | Captures the state of a node that was removed during a directory deletion, so the deletion can be reversed by the change history\. |

| Properties | |
| :--- | :--- |
| [Content](VFSNodeSnapshot.Content.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\.Content') | The file content, or `null` for directories\. |
| [IsDirectory](VFSNodeSnapshot.IsDirectory.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\.IsDirectory') | `true` if the node was a directory; otherwise `false`\. |
| [Path](VFSNodeSnapshot.Path.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\.Path') | The path of the deleted node\. |
