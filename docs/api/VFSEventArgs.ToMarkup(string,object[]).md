#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical.VirtualFileSystem.Core').[VFSEventArgs](VFSEventArgs.md 'Atypical.VirtualFileSystem.Core.VFSEventArgs')

## VFSEventArgs.ToMarkup(string, object[]) Method

Transforms a message into a markup message with the specified color.

```csharp
protected string ToMarkup(string color, params object[] args);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VFSEventArgs.ToMarkup(string,object[]).color'></a>

`color` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The color to use in the markup.

<a name='Atypical.VirtualFileSystem.Core.VFSEventArgs.ToMarkup(string,object[]).args'></a>

`args` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The arguments to format the message.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The markup message.