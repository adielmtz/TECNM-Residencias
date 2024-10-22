namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents a configuration setting entity in the database.
/// </summary>
public sealed class Setting
{
    /// <summary>
    /// Gets or sets the name of the setting.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets the value associated with the setting.
    /// </summary>
    public string Value { get; set; } = "";

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTimeOffset UpdatedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }
}
