#### [Atypical.VirtualFileSystem.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical.VirtualFileSystem.Core.Exceptions](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core.Exceptions 'Atypical.VirtualFileSystem.Core.Exceptions').[VFSException](VFSException.md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException')

## VFSException(string, Exception) Constructor

Initializes a new instance of the [VFSException](VFSException.md 'Atypical.VirtualFileSystem.Core.Exceptions.VFSException') class with a message and an inner exception that is the cause  
of this exception.

```csharp
public VFSException(string message, System.Exception innerException);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.Exceptions.VFSException.VFSException(string,System.Exception).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The error message that explains the reason for the exception.

<a name='Atypical.VirtualFileSystem.Core.Exceptions.VFSException.VFSException(string,System.Exception).innerException'></a>

`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception that is the cause of the current exception, or a null reference if no inner  
exception is specified.