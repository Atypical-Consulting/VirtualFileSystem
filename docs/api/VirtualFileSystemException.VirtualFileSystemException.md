#### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md 'VirtualFileSystem')
### [Atypical\.VirtualFileSystem\.Core](VirtualFileSystem.md#Atypical.VirtualFileSystem.Core 'Atypical\.VirtualFileSystem\.Core').[VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException')

## VirtualFileSystemException Constructors

| Overloads | |
| :--- | :--- |
| [VirtualFileSystemException\(\)](VirtualFileSystemException.VirtualFileSystemException.md#Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException() 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException\.VirtualFileSystemException\(\)') | Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class\. |
| [VirtualFileSystemException\(string, Exception\)](VirtualFileSystemException.VirtualFileSystemException.md#Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string,System.Exception) 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException\.VirtualFileSystemException\(string, System\.Exception\)') | Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class with a message and an inner exception that is the cause of this exception\. |
| [VirtualFileSystemException\(string\)](VirtualFileSystemException.VirtualFileSystemException.md#Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string) 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException\.VirtualFileSystemException\(string\)') | Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class with a message that describes the error\. |

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException()'></a>

## VirtualFileSystemException\(\) Constructor

Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class\.

```csharp
public VirtualFileSystemException();
```

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string,System.Exception)'></a>

## VirtualFileSystemException\(string, Exception\) Constructor

Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class with a message and an inner exception that is the cause
of this exception\.

```csharp
public VirtualFileSystemException(string message, System.Exception innerException);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string,System.Exception).message'></a>

`message` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The error message that explains the reason for the exception\.

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string,System.Exception).innerException'></a>

`innerException` [System\.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System\.Exception')

The exception that is the cause of the current exception, or a null reference if no inner
exception is specified\.

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string)'></a>

## VirtualFileSystemException\(string\) Constructor

Initializes a new instance of the [VirtualFileSystemException](VirtualFileSystemException.md 'Atypical\.VirtualFileSystem\.Core\.VirtualFileSystemException') class with a message that describes the error\.

```csharp
public VirtualFileSystemException(string message);
```
#### Parameters

<a name='Atypical.VirtualFileSystem.Core.VirtualFileSystemException.VirtualFileSystemException(string).message'></a>

`message` [System\.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System\.String')

The error message that explains the reason for the exception\.