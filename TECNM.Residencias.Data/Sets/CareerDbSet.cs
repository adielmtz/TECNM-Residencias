namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class CareerDbSet : DbSet<Career>
{
    public CareerDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a career entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the career entity.</param>
    /// <returns>A <see cref="Career"/> instance if a career with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Career? GetCareer(long id)
    {
        using var command = CreateCommand("SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    public override IEnumerable<Career> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career ORDER BY Name");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves an enumerable collection of <see cref="Career"/> objects.
    /// </summary>
    /// <param name="enabled">Indicates whether to filter the careers based on their enabled status. 
    /// If true, only enabled careers will be included in the result. 
    /// If false, only disabled careers will be returned.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the careers that match the specified filter.
    /// </returns>
    public IEnumerable<Career> EnumerateAll(bool enabled)
    {
        using var command = CreateCommand("SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career WHERE Enabled = $p0 ORDER BY Name");
        command.Parameters.Add("$p0", SqliteType.Integer).Value = enabled;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Career entity) => throw new NotImplementedException();

    public override bool Add(Career entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Career (Name, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p0, $p1, $p2, $p3)
        RETURNING Id
        """);

        command.Parameters.Add("$p0", SqliteType.Text).Value    = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p2", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = DateTimeOffset.Now;
        object? result = command.ExecuteScalar();

        if (result is long rowid)
        {
            entity.Id = rowid;
            return true;
        }

        return false;
    }

    public override int Update(Career entity)
    {
        using var command = CreateCommand("""
        UPDATE Career
        SET Name      = $p0,
            Enabled   = $p1,
            UpdatedOn = $p2
        WHERE Id = $id;
        """);

        command.Parameters.Add("$p0", SqliteType.Text).Value    = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p2", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Career entity)
    {
        return entity.Id > 0 ? Update(entity) > 0 : Add(entity);
    }

    public override int Remove(Career entity) => throw new NotImplementedException();

    protected override Career HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 5);
        int index = 0;
        return new Career
        {
            Id        = reader.GetInt64(index++),
            Name      = reader.GetString(index++),
            Enabled   = reader.GetBoolean(index++),
            UpdatedOn = reader.GetDateTimeOffset(index++),
            CreatedOn = reader.GetDateTimeOffset(index++),
        };
    }
}
