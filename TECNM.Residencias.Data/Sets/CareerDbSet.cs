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

    public Career? GetCareer(long id)
    {
        using var command = CreateCommand("SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
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

    public override bool Contains(Career entity) => throw new NotImplementedException();

    public override bool Add(Career entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Career (Name, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p0, $p1, $p2, $p3)
        RETURNING Id
        """);

        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.UpdatedOn;
        command.Parameters.Add("$p3", SqliteType.Text).Value = entity.CreatedOn;
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

        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.UpdatedOn;
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
