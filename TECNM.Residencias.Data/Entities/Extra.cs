namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents an extra entity in the database.
/// </summary>
public sealed class Extra
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the extra type.
    /// </summary>
    public ExtraType Type { get; set; }

    /// <summary>
    /// Gets or sets the value of the extra.
    /// </summary>
    public string Value { get; set; } = "";
}

/// <summary>
/// Represents the type of soft skill.
/// </summary>
public enum ExtraType
{
    Database,
    Editor,
    Language,
    Methodology,
}
