namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class SettingDbSet : DbSet<Setting>
{
    public SettingDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<Setting> EnumerateSettings()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Name, Value, UpdatedOn, CreatedOn FROM Setting";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Setting setting = HydrateObject(reader);
            yield return setting;
        }
    }

    public override bool Insert(Setting entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "INSERT INTO Setting (Name, Value, UpdatedOn) VALUES ($p0, $p1, CURRENT_TIMESTAMP) RETURNING Id";
        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Value;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    public override int Update(Setting entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "UPDATE Setting SET Name = $p0, Value = $p1, UpdatedOn = CURRENT_TIMESTAMP WHERE Id = $id";
        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Value;
        return command.ExecuteNonQuery();
    }

    public override int Delete(Setting entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM Setting WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool InsertOrUpdate(Setting entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        INSERT INTO Setting (Name, Value, UpdatedOn)
        VALUES ($p0, $p1, CURRENT_TIMESTAMP)
        ON CONFLICT(Name) DO UPDATE
        SET Value     = excluded.Value,
            UpdatedOn = excluded.UpdatedOn
        RETURNING Id
        """;

        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Value;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    protected override Setting HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 5);
        return new Setting
        {
            Id        = reader.GetInt64(0),
            Name      = reader.GetString(1),
            Value     = reader.GetString(2),
            UpdatedOn = reader.GetLocalDateTime(3),
            CreatedOn = reader.GetLocalDateTime(4),
        };
    }
}
