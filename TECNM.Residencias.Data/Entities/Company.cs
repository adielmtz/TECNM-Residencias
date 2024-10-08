namespace TECNM.Residencias.Data.Entities;

using System;

public sealed class Company
{
    public long Id { get; set; }

    public long TypeId { get; set; }

    public string? Rfc { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Extension { get; set; } = "";

    public string Address { get; set; } = "";

    public string Locality { get; set; } = "";

    public string PostalCode { get; set; } = "";

    public long CityId { get; set; }

    public bool Enabled { get; set; }

    public DateTime UpdatedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
