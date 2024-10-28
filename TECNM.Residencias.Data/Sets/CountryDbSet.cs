namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class CountryDbSet : DbSet<Country>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CountryDbSet"/> class with a given <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> that this DbSet is associated with.</param>
    public CountryDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a country entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the country entity.</param>
    /// <returns>A <see cref="Country"/> instance if a country with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Country? GetCountry(long id)
    {
        using var command = CreateCommand("SELECT Id, Name FROM Country WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    public override IEnumerable<Country> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, Name FROM Country ORDER BY Name");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Country entity) => throw new NotImplementedException();

    public override bool Add(Country entity) => throw new NotImplementedException();

    public override int Update(Country entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(Country entity) => throw new NotImplementedException();

    public override int Remove(Country entity) => throw new NotImplementedException();

    protected override Country HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 2);
        int index = 0;
        return new Country
        {
            Id   = reader.GetInt64(index++),
            Name = reader.GetString(index++),
        };
    }
}
