namespace CSM_Dev.Models;

/// <summary>
///     Represents the current available source languages for mirror generation.
/// </summary>
public enum SourceMirrorsLanguage {
    csharp,
}

/// <summary>
///    Represents the current available target languages for mirror generation.
/// </summary>
public enum TargetMirrorsLanguage {
    dart,
}

/// <summary>
///     Represents an actor mirror configuration storing where at what type of files holds.
/// </summary>
public class MirrorConfigActor<TLanguage>
    where TLanguage : Enum {

    /// <summary>
    ///     Path for the actor reference.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    ///    Language to read / write transpilation files. 
    /// </summary>
    public TLanguage Language { get; set; } = default!;
}

/// <summary>
///     Represents a mirror configuration, storing sources (where reference files will be taken from) and targets (where transpilation files
///     will be placed on).
/// </summary>
public class MirrorConfig {

    /// <summary>
    ///     Current source files to generate mirror transpilations.
    /// </summary>
    public List<MirrorConfigActor<SourceMirrorsLanguage>> Sources { get; set; } = [];

    /// <summary>
    ///     Target solutions to generate mirror transpilations.
    /// </summary>
    public List<MirrorConfigActor<TargetMirrorsLanguage>> Targets { get; set; } = [];
}
