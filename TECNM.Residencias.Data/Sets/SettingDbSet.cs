namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

public sealed class SettingDbSet : DbSet<Setting>
{
    public SettingDbSet(DbContext contex) : base(contex)
    {
    }

    public override IEnumerable<Setting> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Name, Value, UpdatedOn, CreatedOn FROM Setting");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Setting entity) => throw new NotImplementedException();

    public override bool Add(Setting entity) => throw new NotImplementedException();

    public override int Update(Setting entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(Setting entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Setting (Name, Value, UpdatedOn, CreatedOn)
        VALUES ($p0, $p1, $p2, $p3)
        ON CONFLICT(Name) DO UPDATE
        SET Value     = excluded.Value,
            UpdatedOn = excluded.UpdatedOn
        """);

        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Value;
        command.Parameters.Add("$p2", SqliteType.Text).Value = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$p3", SqliteType.Text).Value = DateTimeOffset.Now.ToRfc3339();
        return command.ExecuteNonQuery() == 1;
    }

    public override int Remove(Setting entity) => throw new NotImplementedException();

    protected override Setting HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 4);
        int index = 0;
        return new Setting
        {
            Name      = reader.GetString(index++),
            Value     = reader.GetString(index++),
            UpdatedOn = reader.GetDateTimeOffset(index++),
            CreatedOn = reader.GetDateTimeOffset(index++),
        };
    }
}
