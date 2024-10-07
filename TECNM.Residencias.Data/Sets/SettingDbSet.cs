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
        command.CommandText = "SELECT Name, Value, UpdatedOn, CreatedOn FROM Setting";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Setting setting = HydrateObject(reader);
            yield return setting;
        }
    }

    public override bool Insert(Setting entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(Setting entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(Setting entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM Setting WHERE Name = $p0";
        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
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
        """;

        command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Value;
        return command.ExecuteNonQuery() != 0;
    }

    protected override Setting HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 4);
        return new Setting
        {
            Name      = reader.GetString(0),
            Value     = reader.GetString(1),
            UpdatedOn = reader.GetLocalDateTime(2),
            CreatedOn = reader.GetLocalDateTime(3),
        };
    }
}
