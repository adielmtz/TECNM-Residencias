namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

public sealed class SpecialtyDbSet : DbSet<Specialty>
{
    public SpecialtyDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a specialty entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the specialty entity.</param>
    /// <returns>A <see cref="Specialty"/> instance if a specialty with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Specialty? GetSpecialty(long id)
    {
        using var command = CreateCommand("SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    public override IEnumerable<Specialty> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty ORDER BY CareerId, Name");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all specialty entities that belong to the specified career.
    /// </summary>
    /// <param name="career">The <see cref="Career"/> instance to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<Specialty> EnumerateAll(Career career, bool? enabled = null)
    {
        using var command = CreateCommand();
        string query = "SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty WHERE CareerId = $p0 ";

        if (enabled is not null)
        {
            query += "AND Enabled = $p1 ";
            command.Parameters.Add("$p1", SqliteType.Integer).Value = enabled!;
        }

        command.CommandText = query + "ORDER BY Name";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = career.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public IEnumerable<Specialty> EnumerateAll(long careerId)
    {
        using var command = CreateCommand("SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty WHERE CareerId = $p0 ORDER BY Name");
        command.Parameters.Add("$p0", SqliteType.Integer).Value = careerId;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Specialty entity) => throw new NotImplementedException();

    public override bool Add(Specialty entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Specialty (CareerId, Name, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p0, $p1, $p2, $p3, $p4)
        RETURNING Id
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
        command.Parameters.Add("$p1", SqliteType.Text).Value    = entity.Name;
        command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$p4", SqliteType.Text).Value    = DateTimeOffset.Now;
        object? result = command.ExecuteScalar();

        if (result is long rowid)
        {
            entity.Id = rowid;
            return true;
        }

        return false;
    }

    public override int Update(Specialty entity)
    {
        using var command = CreateCommand("""
        UPDATE Specialty
        SET CareerId  = $p0,
            Name      = $p1,
            Enabled   = $p2,
            UpdatedOn = $p3
        WHERE Id = $id
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
        command.Parameters.Add("$p1", SqliteType.Text).Value    = entity.Name;
        command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Specialty entity)
    {
        return entity.Id > 0 ? Update(entity) > 0 : Add(entity);
    }

    public override int Remove(Specialty entity) => throw new NotImplementedException();

    protected override Specialty HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 6);
        int index = 0;
        return new Specialty
        {
            Id        = reader.GetInt64(index++),
            CareerId  = reader.GetInt64(index++),
            Name      = reader.GetString(index++),
            Enabled   = reader.GetBoolean(index++),
            UpdatedOn = reader.GetDateTimeOffset(index++),
            CreatedOn = reader.GetDateTimeOffset(index++),
        };
    }
}
