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
    /// Gets or sets the unique rowid of the extra type.
    /// </summary>
    public long TypeId { get; set; }

    /// <summary>
    /// Gets or sets the value of the extra.
    /// </summary>
    public string Value { get; set; } = "";
}
