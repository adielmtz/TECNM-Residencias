namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents a state entity in the database.
/// </summary>
public sealed class State
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid for the country to which the state belongs.
    /// </summary>
    public long CountryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the state.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Returns the state name as string representation.
    /// </summary>
    /// <returns>The name of the state.</returns>
    public override string ToString()
    {
        return Name;
    }
}
