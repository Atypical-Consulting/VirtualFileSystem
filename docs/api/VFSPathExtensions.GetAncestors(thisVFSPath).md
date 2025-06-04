#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core\.Extensions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Extensions 'Atypical\.VirtualFileSystem\.Core\.Extensions').[VFSPathExtensions](VFSPathExtensions.md 'Atypical\.VirtualFileSystem\.Core\.Extensions\.VFSPathExtensions')

## VFSPathExtensions\.GetAncestors\(this VFSPath\) Method

Gets all ancestor paths from the current path up to the root\.

```csharp
public static System.Collections.Generic.IEnumerable<Atypical.VirtualFileSystem.Core.VFSDirectoryPath> GetAncestors(this Atypical.VirtualFileSystem.Core.VFSPath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Extensions.VFSPathExtensions.GetAncestors(thisAtypical.VirtualFileSystem.Core.VFSPath).path'></a>

`path` [VFSPath](VFSPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSPath')

The VFS path\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
Collection of ancestor paths from immediate parent to root\.