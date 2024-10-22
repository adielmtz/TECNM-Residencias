namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents a career entity in the database.
/// </summary>
public sealed class Career
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the career.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets a value indicating whether the entity is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTimeOffset UpdatedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Returns the career name as string representation.
    /// </summary>
    /// <returns>The name of the career.</returns>
    public override string ToString() => Name;
}
