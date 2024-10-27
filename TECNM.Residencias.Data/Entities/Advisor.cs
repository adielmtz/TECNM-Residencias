namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents an advisor entity in the database.
/// </summary>
public sealed class Advisor
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid for the company to which the advisor belongs.
    /// </summary>
    public long CompanyId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the advisor is internal or not.
    /// </summary>
    public bool Internal { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = "";

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = "";

    /// <summary>
    /// Gets or sets the section or department within the company.
    /// </summary>
    public string Section { get; set; } = "";

    /// <summary>
    /// Gets or sets the role or position within the company.
    /// </summary>
    public string Role { get; set; } = "";

    /// <summary>
    /// Gets or sets the contact email address.
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// Gets or sets the contact phone number.
    /// </summary>
    public string Phone { get; set; } = "";

    /// <summary>
    /// Gets or sets the phone extension (if applicable).
    /// </summary>
    public string Extension { get; set; } = "";

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
    /// Returns the first name and last name as string representation.
    /// </summary>
    /// <returns>The full name of the advisor.</returns>
    public override string ToString() => $"{FirstName} {LastName}";
}
