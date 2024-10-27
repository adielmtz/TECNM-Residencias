namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents the type of an extra entity in the database.
/// </summary>
public sealed class ExtraType
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the extra type label.
    /// </summary>
    public string Label { get; set; } = "";

    /// <summary>
    /// Returns the extra type label as string representation.
    /// </summary>
    /// <returns>The label of the extra type.</returns>
    public override string ToString() => Label;
}
