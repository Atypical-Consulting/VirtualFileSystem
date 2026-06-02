#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs')

## VFSDirectoryDeletedArgs Constructors

| Overloads | |
| :--- | :--- |
| [VFSDirectoryDeletedArgs\(VFSDirectoryPath\)](VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs.md#Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath) 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.VFSDirectoryDeletedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath\)') | Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class\. |
| [VFSDirectoryDeletedArgs\(VFSDirectoryPath, ImmutableArray&lt;VFSNodeSnapshot&gt;\)](VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs.md#Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,System.Collections.Immutable.ImmutableArray_Atypical.VirtualFileSystem.Core.VFSNodeSnapshot_) 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs\.VFSDirectoryDeletedArgs\(Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath, System\.Collections\.Immutable\.ImmutableArray\<Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot\>\)') | Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class with a snapshot of the deleted subtree so the deletion can be reversed\. |

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath)'></a>

## VFSDirectoryDeletedArgs\(VFSDirectoryPath\) Constructor

Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class\.

```csharp
public VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath path);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath).path'></a>

`path` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The path of the deleted directory\.

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,System.Collections.Immutable.ImmutableArray_Atypical.VirtualFileSystem.Core.VFSNodeSnapshot_)'></a>

## VFSDirectoryDeletedArgs\(VFSDirectoryPath, ImmutableArray\<VFSNodeSnapshot\>\) Constructor

Initializes a new instance of the [VFSDirectoryDeletedArgs](VFSDirectoryDeletedArgs.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryDeletedArgs') class
with a snapshot of the deleted subtree so the deletion can be reversed\.

```csharp
public VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath path, System.Collections.Immutable.ImmutableArray<Atypical.VirtualFileSystem.Core.VFSNodeSnapshot> deletedNodes);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,System.Collections.Immutable.ImmutableArray_Atypical.VirtualFileSystem.Core.VFSNodeSnapshot_).path'></a>

`path` [VFSDirectoryPath](VFSDirectoryPath.md 'Atypical\.VirtualFileSystem\.Core\.VFSDirectoryPath')

The path of the deleted directory\.

<a name='Atypical.VirtualFileSystem.Core.VFSDirectoryDeletedArgs.VFSDirectoryDeletedArgs(Atypical.VirtualFileSystem.Core.VFSDirectoryPath,System.Collections.Immutable.ImmutableArray_Atypical.VirtualFileSystem.Core.VFSNodeSnapshot_).deletedNodes'></a>

`deletedNodes` [System\.Collections\.Immutable\.ImmutableArray&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')[VFSNodeSnapshot](VFSNodeSnapshot.md 'Atypical\.VirtualFileSystem\.Core\.VFSNodeSnapshot')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')

The directory and its descendants that were removed\.