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
vfs.CreateDirectory("/heroes");
vfs.CreateFile("/heroes/ironman.txt", "Tony Stark");
vfs.CreateFile("/heroes/captain_america.txt", "Steve Rogers");
vfs.CreateFile("/heroes/hulk.txt", "Bruce Banner");
vfs.CreateFile("/heroes/thor.txt", "Thor Odinson");
vfs.CreateFile("/heroes/black_widow.txt", "Natasha Romanoff");
vfs.CreateDirectory("/villains");
vfs.CreateFile("/villains/loki.txt", "Loki Laufeyson");
vfs.CreateFile("/villains/ultron.txt", "Ultron");
vfs.CreateFile("/villains/killmonger.txt", "N'Jadaka");
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Rename a file
vfs.RenameFile("/heroes/ironman.txt", "tony_stark.txt");
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Move a file
vfs.MoveFile("/heroes/tony_stark.txt", "/villains/tony_stark.txt");
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

// Delete a file
vfs.DeleteFile("/villains/tony_stark.txt");
AnsiConsole.Write(new Tree("Marvel Universe").FillTree(vfs));

return;