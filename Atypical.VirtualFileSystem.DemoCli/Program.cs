// See https://aka.ms/new-console-template for more information

using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using Atypical.VirtualFileSystem.DemoCli;
using Spectre.Console;

// Create a virtual file system
var factory = new VirtualFileSystemFactory();
IVirtualFileSystem vfs = factory.CreateFileSystem();

// Display a banner
AnsiConsole.Write(
    new FigletText("VFS Demo")
        .LeftJustified()
        .Color(Color.Gold1));

// Create a directory structure
vfs.CreateDirectory("/heroes");
vfs.CreateFile("/heroes/ironman.txt", "Tony Stark");
vfs.CreateFile("/heroes/captainamerica.txt", "Steve Rogers");
vfs.CreateFile("/heroes/hulk.txt", "Bruce Banner");
vfs.CreateFile("/heroes/thor.txt", "Thor Odinson");
vfs.CreateFile("/heroes/blackwidow.txt", "Natasha Romanoff");
vfs.CreateDirectory("/villains");
vfs.CreateFile("/villains/loki.txt", "Loki Laufeyson");
vfs.CreateFile("/villains/ultron.txt", "Ultron");
vfs.CreateFile("/villains/killmonger.txt", "N'Jadaka");

// use spectre console to display a tree view of the file system
var tree = new Tree("Marvel Universe");

// Start with the root node
tree.FillTree(vfs.Root);

// Display the tree
AnsiConsole.Write(tree);