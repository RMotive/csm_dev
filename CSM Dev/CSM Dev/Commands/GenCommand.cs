using System.CommandLine;

namespace CSM_Dev.Commands;

/// <summary>
///     {command} class.
///     
///     Implements the {gen} command at the command-line tools, wich generates target solution
///     language files based on the source solution entities, services and sources files to convert.
/// </summary>
public class GenCommand
    : Command
{
    public GenCommand() 
        : base(
        "gen",
    "Generates the mirror from a .Net Server solution entities, enumerators and services to the target development platform"
        ) {


    }
}
