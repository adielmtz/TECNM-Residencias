namespace TECNM.Residencias.Data.Sets.Types;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

public sealed class ExtraTypeDbSet : DbSet<ExtraType>
{
    public ExtraTypeDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<ExtraType> EnumerateAll()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM ExtraType ORDER BY Label";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            ExtraType type = HydrateObject(reader);
            yield return type;
        }
    }

    public override bool Insert(ExtraType entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(ExtraType entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(ExtraType entity)
    {
        throw new NotImplementedException();
    }

    public override bool InsertOrUpdate(ExtraType entity)
    {
        throw new NotImplementedException();
    }

    protected override ExtraType HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 2);
        return new ExtraType
        {
            Id    = reader.GetInt64(0),
            Label = reader.GetString(1),
        };
    }
}
