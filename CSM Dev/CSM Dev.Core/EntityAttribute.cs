namespace CSM_Dev.Core;

/// <summary>
///     Represents an entity attribute in the CSM Dev framework, used to get Entity references for the mirror process,
///     this entities are transpilated from soure languages to target languages.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class EntityAttribute 
    : Attribute {
}
