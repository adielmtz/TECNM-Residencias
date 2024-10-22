namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents a gender of an student entity in the database.
/// </summary>
public sealed class Gender
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the gender label.
    /// </summary>
    public string Label { get; set; } = "";

    /// <summary>
    /// Returns the gender label as string representation.
    /// </summary>
    /// <returns>The label of the gender.</returns>
    public override string ToString() => Label;
}
