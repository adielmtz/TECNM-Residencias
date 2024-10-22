namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents the type of a company entity in the database.
/// </summary>
public sealed class CompanyType
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the company type label.
    /// </summary>
    public string Label { get; set; } = "";

    /// <summary>
    /// Returns the company type label as string representation.
    /// </summary>
    /// <returns>The label of the company type.</returns>
    public override string ToString() => Label;
}
