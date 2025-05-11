namespace TECNM.Residencias.Data.Sets;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class StateDbSet : DbSet<State>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StateDbSet"/> class with a given <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> that this DbSet is associated with.</param>
    public StateDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a state entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the state entity.</param>
    /// <returns>A <see cref="State"/> instance if a state with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public State? GetState(long id)
    {
        using SqliteCommand command = CreateCommand("SELECT Id, CountryId, Name FROM State WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using SqliteDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    public override IEnumerable<State> EnumerateAll()
    {
        using SqliteCommand command = CreateCommand("SELECT Id, CountryId, Name ORDER BY CountryId, Name");
        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="State"/> that belongs to the given <see cref="Country"/>.
    /// </summary>
    /// <param name="country">A <see cref="Country"/> instance to filter the states.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<State> EnumerateAll(Country country)
        => EnumerateAll(country.Id);

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="State"/> that belongs to the specified country.
    /// </summary>
    /// <param name="countryId">A rowid of the country entity to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<State> EnumerateAll(long countryId)
    {
        using SqliteCommand command = CreateCommand("SELECT Id, CountryId, Name FROM State WHERE CountryId = $cid ORDER BY Name");
        command.Parameters.Add("$cid", SqliteType.Integer).Value = countryId;
        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(State entity)
        => throw new NotImplementedException();

    public override bool Add(State entity)
        => throw new NotImplementedException();

    public override int Update(State entity)
        => throw new NotImplementedException();

    public override bool AddOrUpdate(State entity)
        => throw new NotImplementedException();

    public override int Remove(State entity)
        => throw new NotImplementedException();

    protected override State HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        int index = 0;
        return new State
        {
            Id = reader.GetInt64(index++),
            CountryId = reader.GetInt64(index++),
            Name = reader.GetString(index++),
        };
    }
}
