namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class ExtraDbSet : DbSet<Extra>
{
    public ExtraDbSet(DbContext context) : base(context)
    {
    }

    public override IEnumerable<Extra> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, TypeId, Value FROM Extra ORDER BY TypeId, Value");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="ExtraType"/> from the underlying database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<ExtraType> EnumerateExtraTypes()
    {
        using var command = CreateCommand("SELECT Id, Label FROM ExtraType ORDER BY Label");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new ExtraType
            {
                Id    = reader.GetInt64(0),
                Label = reader.GetString(1),
            };
        }
    }

    public override bool Contains(Extra entity) => throw new NotImplementedException();

    public override bool Add(Extra entity) => throw new NotImplementedException();

    public override int Update(Extra entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(Extra entity) => throw new NotImplementedException();

    public override int Remove(Extra entity) => throw new NotImplementedException();

    protected override Extra HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        int index = 0;
        return new Extra
        {
            Id     = reader.GetInt64(index++),
            TypeId = reader.GetInt64(index++),
            Value  = reader.GetString(index++),
        };
    }
}
