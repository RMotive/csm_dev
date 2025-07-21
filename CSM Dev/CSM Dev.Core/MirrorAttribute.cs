namespace CSM_Dev.Core;

/// <summary>
///     Represents an entity attribute in the CSM Dev framework, used to get Entity references for the mirror process,
///     this entities are transpilated from soure languages to target languages.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class MirrorAttribute 
    : Attribute {

    /// <summary>
    ///     Category name where this entity belongs to, this is used to group entities in the mirror process.
    /// </summary>
    public string Category { get; init; }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="category">
    ///     Category name where this entity belongs to, this is used to group entities in the mirror process.
    /// </param>
    public MirrorAttribute(string category = "") {
        Category = category;
    }
}
