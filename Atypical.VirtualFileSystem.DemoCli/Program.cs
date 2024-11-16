using Atypical.VirtualFileSystem.DemoCli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<BugDeleteFolder>("demo");
});

app.Run(args);