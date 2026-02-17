using Spectre.Console.Cli;

namespace Atypical.VirtualFileSystem.DemoCli.Commands;

public class DemonstrateVFS : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        // Create a virtual file system
        var factory = new VirtualFileSystemFactory();
        var vfs = factory.CreateFileSystem();

        // Subscribe to VFS events
        SubscribeToWriteVFSEvents(vfs, OnChange);

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
            () => vfs.RenameFile(new VFSFilePath("/heroes/ironman.txt"), "tony_stark.txt"));

        // UNDO
        // ProcessStep(vfs, "UNDO", () => vfs.ChangeHistory.Undo());

        // REDO
        // ProcessStep(vfs, "REDO", () => vfs.ChangeHistory.Redo());

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
        ProcessStep(vfs, "RENAME DIRECTORY",
            () => vfs.RenameDirectory(new VFSDirectoryPath("/avengers"), "heroes"));

        return 0;
    }

    private static void SubscribeToWriteVFSEvents(
        IVirtualFileSystem virtualFileSystem,
        Action<VFSEventArgs> action)
    {
        // ReSharper disable ConvertClosureToMethodGroup
        virtualFileSystem.DirectoryCreated += args => action(args);
        virtualFileSystem.FileCreated      += args => action(args);
        virtualFileSystem.DirectoryDeleted += args => action(args);
        virtualFileSystem.FileDeleted      += args => action(args);
        virtualFileSystem.DirectoryMoved   += args => action(args);
        virtualFileSystem.FileMoved        += args => action(args);
        virtualFileSystem.DirectoryRenamed += args => action(args);
        virtualFileSystem.FileRenamed      += args => action(args);
        // ReSharper restore ConvertClosureToMethodGroup
    }

    private static void OnChange(VFSEventArgs args)
    {
        AnsiConsole.Write(new Markup($"  - {args.MessageWithMarkup}"));
        AnsiConsole.WriteLine();
    }

    private static void ProcessStep(IVirtualFileSystem virtualFileSystem, string sectionHeader, Action action)
    {
        WriteSectionHeader(sectionHeader);
        action();
        WriteTree(virtualFileSystem);
    }

    private static void WriteSectionHeader(string header = "")
    {
        AnsiConsole.Write(new Markup($"[underline yellow]{header}[/]"));
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }

    private static void WriteTree(IVirtualFileSystem virtualFileSystem)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new Tree("Marvel Universe").FillTree(virtualFileSystem));
        AnsiConsole.WriteLine();
    }
}