namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents a country entity in the database.
/// </summary>
public sealed class Country
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the country.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Returns the country name as string representation.
    /// </summary>
    /// <returns>The name of the country.</returns>
    public override string ToString() => Name;
}
