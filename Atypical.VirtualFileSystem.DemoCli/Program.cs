using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoCli.Extensions;
using Atypical.VirtualFileSystem.DemoCli.WIP;

// Create a virtual file system
var factory = new VirtualFileSystemFactory();
var vfs = factory.CreateFileSystem();

// Add UNDO/REDO functionality
var changeHistory = new ChangeHistory(vfs);

// Subscribe to VFS events
SubscribeToWriteVFSEvents(vfs);

// Display a banner
AnsiConsole.Write(
    new FigletText("VFS Demo")
        .LeftJustified()
        .Color(Color.Gold1));

// Create a directory structure
ProcessStep(vfs, "CREATE A FILE STRUCTURE", () =>
{
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
});

// Rename a file
ProcessStep(vfs, "RENAME A FILE", 
    () => vfs.RenameFile(new VFSFilePath("/heroes/ironman.txt"), "tommy_stark.txt"));

// UNDO
ProcessStep(vfs, "UNDO", () => changeHistory.Undo());

// REDO
ProcessStep(vfs, "REDO", () => changeHistory.Redo());

// Move a file
ProcessStep(vfs, "MOVE A FILE",
    () => vfs.MoveFile(new VFSFilePath("/heroes/tony_stark.txt"), new VFSFilePath("/villains/tony_stark.txt")));

// Delete a file
ProcessStep(vfs, "DELETE A FILE",
    () => vfs.DeleteFile(new VFSFilePath("/villains/tony_stark.txt")));

// Delete a directory
ProcessStep(vfs, "DELETE DIRECTORY",
    () => vfs.DeleteDirectory(new VFSDirectoryPath("/villains")));

// Move a directory
ProcessStep(vfs, "MOVE DIRECTORY",
    () => vfs.MoveDirectory(new VFSDirectoryPath("/heroes"), new VFSDirectoryPath("/avengers")));

// Rename a directory
// TODO: fix rename directory
// ProcessStep(vfs, "RENAME DIRECTORY",
//     () => vfs.RenameDirectory(new VFSDirectoryPath("/avengers"), new VFSDirectoryPath("/heroes")));
return;

void SubscribeToWriteVFSEvents(IVirtualFileSystem virtualFileSystem)
{
    virtualFileSystem.DirectoryCreated += OnChange;
    virtualFileSystem.FileCreated      += OnChange;
    virtualFileSystem.DirectoryDeleted += OnChange;
    virtualFileSystem.FileDeleted      += OnChange;
    virtualFileSystem.DirectoryMoved   += OnChange;
    virtualFileSystem.FileMoved        += OnChange;
    virtualFileSystem.DirectoryRenamed += OnChange;
    virtualFileSystem.FileRenamed      += OnChange;
    return;

    static void OnChange(VFSEventArgs args)
    {
        AnsiConsole.Write(new Markup($"  - {args.MessageWithMarkup}"));
        AnsiConsole.WriteLine();
    }
}

void ProcessStep(IVirtualFileSystem virtualFileSystem, string sectionHeader, Action action)
{
    WriteSectionHeader(sectionHeader);
    action();
    WriteTree(virtualFileSystem);
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