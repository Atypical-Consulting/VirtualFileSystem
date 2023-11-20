using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.DemoCli.Extensions;

// Create a virtual file system
var factory = new VirtualFileSystemFactory();
var vfs = factory.CreateFileSystem();

// Display a banner
AnsiConsole.Write(
    new FigletText("VFS Demo")
        .LeftJustified()
        .Color(Color.Gold1));

// Create a directory structure
vfs.CreateDirectory(new VFSDirectoryPath("/heroes"));
vfs.CreateFile(new VFSFilePath("/heroes/ironman.txt"), "Tony Stark");
vfs.CreateFile(new VFSFilePath("/heroes/captain_america.txt"), "Steve Rogers");
vfs.CreateFile(new VFSFilePath("/heroes/hulk.txt"), "Bruce Banner");
vfs.CreateFile(new VFSFilePath("/heroes/thor.txt"), "Thor Odinson");
vfs.CreateFile(new VFSFilePath("/heroes/black_widow.txt"), "Natasha Romanoff");

vfs.CreateDirectory(new VFSDirectoryPath("/villains"));
vfs.CreateFile(new VFSFilePath("/villains/loki.txt"), "Loki Laufeyson");
vfs.CreateFile(new VFSFilePath("/villains/ultron.txt"), "Ultron");
vfs.CreateFile(new VFSFilePath("/villains/killmonger.txt"), "N'Jadaka");

AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Rename a file
vfs.RenameFile(new VFSFilePath("/heroes/ironman.txt"), "tony_stark.txt");
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Move a file
vfs.MoveFile(new VFSFilePath("/heroes/tony_stark.txt"), new VFSFilePath("/villains/tony_stark.txt"));
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Delete a file
vfs.DeleteFile(new VFSFilePath("/villains/tony_stark.txt"));
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));
