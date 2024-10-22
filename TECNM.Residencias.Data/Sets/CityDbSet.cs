namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class CityDbSet : DbSet<City>
{
    public CityDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a city entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the city entity.</param>
    /// <returns>A <see cref="City"/> instance if a city with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public City? GetCity(long id)
    {
        using var command = CreateCommand("SELECT Id, StateId, Name FROM City WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    public override IEnumerable<City> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, StateId, Name FROM City ORDER BY StateId, Name");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="City"/> that belongs to the given <see cref="State"/>.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<City> EnumerateAll(State state)
    {
        using var command = CreateCommand("SELECT Id, StateId, Name FROM City WHERE StateId = $sid ORDER BY Name");
        command.Parameters.Add("$sid", SqliteType.Integer).Value = state.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(City entity) => throw new NotImplementedException();

    public override bool Add(City entity) => throw new NotImplementedException();

    public override int Update(City entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(City entity) => throw new NotImplementedException();

    public override int Remove(City entity) => throw new NotImplementedException();

    protected override City HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        int index = 0;
        return new City
        {
            Id      = reader.GetInt64(index++),
            StateId = reader.GetInt64(index++),
            Name    = reader.GetString(index++),
        };
    }
}
