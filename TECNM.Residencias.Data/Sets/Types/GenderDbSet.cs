namespace TECNM.Residencias.Data.Sets.Types;

using Microsoft.Data.Sqlite;
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

    public Gender? GetGenderById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM Gender WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return HydrateObject(reader);
    }

    public IEnumerable<Gender> EnumerateAll()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM Gender ORDER BY Label";
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
