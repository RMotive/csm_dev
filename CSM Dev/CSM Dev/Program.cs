using System.CommandLine;

internal class Program
{


    enum SourceMirrorsLanguage
    {
        csharp,
    }

    enum TargetMirrorsLanguage
    {
        dart,
    }

    private static async Task Main(string[] args)
    {

        Option<SourceMirrorsLanguage> sourceMirrorOption = new(
                "--source-language",
                description: "Specifies the source server solution to mirror language",
                getDefaultValue: () => SourceMirrorsLanguage.csharp
            );
        
        Option<DirectoryInfo> sourcePathOption = new(
                "--source-path",
                description: "Specifies the source server solution path to get files to mirror",
                getDefaultValue: () => new DirectoryInfo(Directory.GetCurrentDirectory())
            );


        Option<TargetMirrorsLanguage> targetMirrorOption = new(
                "--target-language",
                description: "Specifies the target client solution to mirror language",
                getDefaultValue: () => TargetMirrorsLanguage.dart
            );

        Command genCommand = new(
            "gen",
            "Generates the mirror from a .Net Server solution entities, enumerators and services to the target development platform"
        ) {
            sourceMirrorOption,
            sourcePathOption,
            targetMirrorOption,
        };
        genCommand.SetHandler(
               (SourceMirrorsLanguage sourceMirror, DirectoryInfo sourcePath, TargetMirrorsLanguage targetMirror) =>
               {
                   Console.WriteLine($"sourceMirror {sourceMirror}");
                   Console.WriteLine($"sourcePath {sourcePath}");
                   Console.WriteLine($"targetMirror {targetMirror}");
               },
               sourceMirrorOption,
               sourcePathOption, 
               targetMirrorOption
            );




        RootCommand rootCommand = new("Command line tools for {CSM} developers to interact with development platforms easily")
        {
            genCommand,
        };
        rootCommand.Name = "csm_dev";
        await rootCommand.InvokeAsync(args);
    }
}