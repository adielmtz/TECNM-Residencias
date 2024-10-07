namespace TECNM.Residencias.Data.Entities;

using System;

public sealed class Setting
{
    public string Name { get; set; } = "";

    public string Value { get; set; } = "";

    public DateTime UpdatedOn { get; set; }

    public DateTime CreatedOn { get; set; }
}
