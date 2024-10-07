namespace TECNM.Residencias.Data.Sets.Types;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

public sealed class GenderDbSet : DbSet<Gender>
{
    public GenderDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<Gender> EnumerateAll()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM Gender ORDER BY Name";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Gender gender = HydrateObject(reader);
            yield return gender;
        }
    }

    public override bool Insert(Gender entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(Gender entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(Gender entity)
    {
        throw new NotImplementedException();
    }

    public override bool InsertOrUpdate(Gender entity)
    {
        throw new NotImplementedException();
    }

    protected override Gender HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 2);
        return new Gender
        {
            Id    = reader.GetInt64(0),
            Label = reader.GetString(1),
        };
    }
}
