namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents a city entity in the database.
/// </summary>
public sealed class City
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid for the state to which the city belongs.
    /// </summary>
    public long StateId { get; set; }

    /// <summary>
    /// Gets or sets the name of the city.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Returns the city name as string representation.
    /// </summary>
    /// <returns>The name of the city.</returns>
    public override string ToString()
    {
        return Name;
    }
}
