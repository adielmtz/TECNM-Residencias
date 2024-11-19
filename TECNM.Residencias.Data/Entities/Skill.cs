namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents an skill entity in the database.
/// </summary>
public sealed class Skill
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the skill type.
    /// </summary>
    public SkillType Type { get; set; }

    /// <summary>
    /// Gets or sets the value of the skill.
    /// </summary>
    public string Value { get; set; } = "";
}

/// <summary>
/// Represents the type of soft skill.
/// </summary>
public enum SkillType
{
    Database,
    Editor,
    Language,
    Methodology,
}
