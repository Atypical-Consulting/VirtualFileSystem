using Spectre.Console.Cli;

namespace Atypical.VirtualFileSystem.DemoCli.Commands;

public class BugDeleteFolder : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        // Create a virtual file system
        var factory = new VirtualFileSystemFactory();
        var vfs = factory.CreateFileSystem();

        // Create folders
        vfs.CreateDirectory("/Assets");
        vfs.CreateDirectory("/Assets/New Folder");
        vfs.CreateDirectory("/Assets/New Folder 1");
        
        // Delete folder
        vfs.DeleteDirectory("/Assets/New Folder 1");
        
        var paths = vfs.Index.GetPathsStartingWith("/Assets/New Folder");
        
        foreach (var path in paths)
        {
            AnsiConsole.MarkupLine($"[red]{path}[/]");
        }
        
        return 0;
    }
}