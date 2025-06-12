using CSM_Dev.Commands;

using System.CommandLine;

internal class Program
{




    private static async Task Main(string[] args)
    {
        RootCommand rootCommand = new("Command line tools for {CSM} developers to interact with development platforms easily")
        {
            new GenCommand(),
        };

        rootCommand.Name = "csm_dev";
        await rootCommand.InvokeAsync(args);
    }
}