namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents a company entity in the database.
/// </summary>
public sealed class Company
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets company type.
    /// </summary>
    public CompanyType Type { get; set; }

    /// <summary>
    /// Gets or sets the company RFC.
    /// Can be <see langword="null"/> to indicate an unknown value.
    /// </summary>
    public string? Rfc { get; set; }

    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets the company email address.
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// Gets or sets the company phone number.
    /// </summary>
    public string Phone { get; set; } = "";

    /// <summary>
    /// Gets or sets the phone number extension (if applicable).
    /// </summary>
    public string Extension { get; set; } = "";

    /// <summary>
    /// Gets or sets the address information.
    /// </summary>
    public string Address { get; set; } = "";

    /// <summary>
    /// Gets or sets the locality or neighbourhood information.
    /// </summary>
    public string Locality { get; set; } = "";

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    public string PostalCode { get; set; } = "";

    /// <summary>
    /// Gets or sets the unique rowid for the city the company is from.
    /// </summary>
    public long CityId { get; set; }

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
    /// Returns the company name as string representation.
    /// </summary>
    /// <returns>The name of the company.</returns>
    public override string ToString()
        => Name;
}

/// <summary>
/// Represents different types of companies.
/// </summary>
public enum CompanyType
{
    Public,
    Private,
    Industrial,
    Services,
    Other,
}
