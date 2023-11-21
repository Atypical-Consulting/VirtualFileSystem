using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoCli.Extensions;

// Create a virtual file system
var factory = new VirtualFileSystemFactory();
var vfs = factory.CreateFileSystem();

// Subscribe to VFS events
SubscribeToVFSEvents(vfs);

// Display a banner
AnsiConsole.Write(
    new FigletText("VFS Demo")
        .LeftJustified()
        .Color(Color.Gold1));

// Create a directory structure
WriteSectionHeader("INITIAL DIRECTORY STRUCTURE");

vfs.CreateDirectory(new VFSDirectoryPath("/heroes"));
vfs.CreateFile(new VFSFilePath("/heroes/ironman.txt"), "Tony Stark");
vfs.CreateFile(new VFSFilePath("/heroes/captain_america.txt"), "Steve Rogers");
vfs.CreateFile(new VFSFilePath("/heroes/hulk.txt"), "Bruce Banner");
vfs.CreateFile(new VFSFilePath("/heroes/thor.txt"), "Thor Odinson");
vfs.CreateFile(new VFSFilePath("/heroes/black_widow.txt"), "Natasha Romanoff");

vfs.CreateDirectory(new VFSDirectoryPath("/villains"));
vfs.CreateFile(new VFSFilePath("/villains/loki.txt"), "Loki Laufeyson");
vfs.CreateFile(new VFSFilePath("/villains/ultron.txt"), "Ultron");
vfs.CreateFile(new VFSFilePath("/villains/thanos.txt"), "Thanos");

WriteTree(vfs);

// Rename a file
WriteSectionHeader("RENAME FILE");
vfs.RenameFile(new VFSFilePath("/heroes/ironman.txt"), "tony_stark.txt");
WriteTree(vfs);

// Move a file
WriteSectionHeader("MOVE FILE");
vfs.MoveFile(new VFSFilePath("/heroes/tony_stark.txt"), new VFSFilePath("/villains/tony_stark.txt"));
WriteTree(vfs);

// Delete a file
WriteSectionHeader("DELETE FILE");
vfs.DeleteFile(new VFSFilePath("/villains/tony_stark.txt"));
WriteTree(vfs);

// Delete a directory
WriteSectionHeader("DELETE DIRECTORY");
vfs.DeleteDirectory(new VFSDirectoryPath("/villains"));
WriteTree(vfs);

// Move a directory
WriteSectionHeader("MOVE DIRECTORY");
vfs.MoveDirectory(new VFSDirectoryPath("/heroes"), new VFSDirectoryPath("/avengers"));
WriteTree(vfs);

// Rename a directory
// TODO: fix rename directory
// WriteSectionHeader("RENAME DIRECTORY");
// vfs.RenameDirectory(new VFSDirectoryPath("/avengers"), new VFSDirectoryPath("/heroes"));
// WriteTree(vfs);
return;

void SubscribeToVFSEvents(IVirtualFileSystem virtualFileSystem)
{
    virtualFileSystem.DirectoryCreated += createdArgs => OnChange(virtualFileSystem, createdArgs);
    virtualFileSystem.FileCreated      += createdArgs => OnChange(virtualFileSystem, createdArgs);
    virtualFileSystem.DirectoryDeleted += deletedArgs => OnChange(virtualFileSystem, deletedArgs);
    virtualFileSystem.FileDeleted      += deletedArgs => OnChange(virtualFileSystem, deletedArgs);
    virtualFileSystem.DirectoryMoved   += movedArgs   => OnChange(virtualFileSystem, movedArgs);
    virtualFileSystem.FileMoved        += movedArgs   => OnChange(virtualFileSystem, movedArgs);
    virtualFileSystem.DirectoryRenamed += renamedArgs => OnChange(virtualFileSystem, renamedArgs);
    virtualFileSystem.FileRenamed      += renamedArgs => OnChange(virtualFileSystem, renamedArgs);
    return;

    static void OnChange(object? sender, VFSEventArgs args)
    {
        AnsiConsole.Write(new Markup($"  - {args.MessageWithMarkup}"));
        AnsiConsole.WriteLine();
    }
}

void WriteSectionHeader(string header = "")
{
    AnsiConsole.Write(new Markup($"[underline yellow]{header}[/]"));
    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine();
}

void WriteTree(IVirtualFileSystem virtualFileSystem)
{
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Tree("Marvel Universe").FillTree(virtualFileSystem));
    AnsiConsole.WriteLine();
}