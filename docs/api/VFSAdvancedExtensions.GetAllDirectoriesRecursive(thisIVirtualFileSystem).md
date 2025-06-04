#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSAdvancedExtensions](VFSAdvancedExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSAdvancedExtensions')

## VFSAdvancedExtensions\.GetAllDirectoriesRecursive\(this IVirtualFileSystem\) Method

Gets all directories in the file system recursively\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.Contracts.IDirectoryNode> GetAllDirectoriesRecursive(this Atypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem vfs);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSAdvancedExtensions.GetAllDirectoriesRecursive(thisAtypical.VirtualFileSystem.Core.Contracts.IVirtualFileSystem).vfs'></a>

`vfs` [IVirtualFileSystem](IVirtualFileSystem.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IVirtualFileSystem')

The virtual file system\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IDirectoryNode](IDirectoryNode.md 'Atypical\.VirtualFileSystem\.Core\.Contracts\.IDirectoryNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
All directories in the file system\.