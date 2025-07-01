using System.CommandLine;
using System.Text.Json;
using System.Text.Json.Serialization;

using CSM_Dev.Models;

using ShellProgressBar;

namespace CSM_Dev.Commands;

/// <summary>
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
                            10,
                            "Starting mirrors generation process...",
                            new ProgressBarOptions {
                                ForegroundColor = ConsoleColor.DarkCyan,
                                ProgressCharacter = '-',
                                DisplayTimeInRealTime = true,
                                EnableTaskBarProgress = true,
                            }
                        );

                    progressBar.Tick("Getting configuration file...");

                    DirectoryInfo workDir = new(Directory.GetCurrentDirectory());
                    FileInfo[] workDirFiles = workDir.GetFiles();

                    FileInfo? configFileInfo = workDirFiles.FirstOrDefault(workDirFile => workDirFile.Name == configFileName);
                    if(configFileInfo == null) {
                        progressBar.WriteErrorLine($"File ({configFileName}) not found at ({workDir.FullName}) working directory");
                        return;
                    }


                    progressBar.Tick($"Reading configuration file...");
                    using FileStream fileReader = configFileInfo.OpenRead();


                    JsonSerializerOptions convertionOptions = new JsonSerializerOptions { 
                        Converters = {
                            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true)
                        },
                    };

                    MirrorConfig? mirrorConfig = JsonSerializer.Deserialize<MirrorConfig>(fileReader, convertionOptions);
                    if(mirrorConfig == null) {
                        progressBar.WriteErrorLine($"Unable to read configuration file ({configFileName}) at ({workDir.FullName}) working directory");
                        return;
                    }

                   progressBar.Tick($"Mapping Sources ({mirrorConfig.Sources.Count}) to get mirror references...");
                   foreach (MirrorConfigActor<SourceMirrorsLanguage> source in mirrorConfig.Sources) {
                       string sourcePath = Path.GetFullPath(source.Path);
                       using ChildProgressBar mapProgressBar = progressBar.Spawn(2, $"Mapping Source({ sourcePath})...");
                       
                       DirectoryInfo sourceDirectory = new(sourcePath);


                   }
               },
               configFileNameOption
            );
    }
}
