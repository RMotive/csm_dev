using System.CommandLine;

using ShellProgressBar;

namespace CSM_Dev.Commands;

enum SourceMirrorsLanguage {
    csharp,
}

enum TargetMirrorsLanguage {
    dart,
}

/// <summary>
///     {command} class.
///     
///     Implements the {gen} command at the command-line tools, wich generates target solution
///     language files based on the source solution entities, services and sources files to convert.
/// </summary>
public class GenCommand
    : Command {

    /// <summary>
    ///     Creates a new <see cref="GenCommand"/> instance.
    /// </summary>
    public GenCommand()
        : base(
        "gen",
    "Generates the mirror from a .Net Server solution entities, enumerators and services to the target development platform"
        ) {


        Option<string> configFileNameOption = new(
            "--config-file-name",
                description: "Specifies a mirror configuration file name for the generation (match case sensitive)",
                getDefaultValue: () => ".mirror_config.json"
            );

        AddOption(configFileNameOption);

        this.SetHandler(
               (string configFileName) => {

                   using ProgressBar progressBar = new(
                           2,
                           "Starting mirrors generation process...",
                           new ProgressBarOptions {
                               ForegroundColor = ConsoleColor.DarkCyan,
                               ProgressCharacter = '-',
                               EnableTaskBarProgress = true,
                           }
                       );

                   progressBar.Tick("Getting configuration file...");

                   DirectoryInfo workDir = new(Directory.GetCurrentDirectory());
                   FileInfo[] workDirFiles = workDir.GetFiles();

                   FileInfo configFileInfo = workDirFiles.FirstOrDefault(workDirFile => workDirFile.Name == configFileName) 
                        ?? throw new FileNotFoundException($"File ({configFileName}) not found at ({workDir.FullName}) working directory");


               },
               configFileNameOption
            );
    }
}
