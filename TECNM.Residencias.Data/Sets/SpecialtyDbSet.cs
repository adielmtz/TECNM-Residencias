namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class SpecialtyDbSet : DbSet<Specialty>
{
    public SpecialtyDbSet(IDbContext context) : base(context)
    {
    }

    public Specialty? GetSpecialtyById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return HydrateObject(reader);
    }

    public IEnumerable<Specialty> EnumerateSpecialtiesByCareer(Career career, bool? enabled = null)
    {
        return EnumerateSpecialtiesByCareer(career.Id, enabled);
    }

    public IEnumerable<Specialty> EnumerateSpecialtiesByCareer(long careerId, bool? enabled = null)
    {
        using var command = Context.Database.CreateCommand();
        string query = "SELECT Id, CareerId, Name, Enabled, UpdatedOn, CreatedOn FROM Specialty WHERE CareerId = $p0 ";

        if (enabled != null)
        {
            query += "AND Enabled = $p1 ";
            command.Parameters.Add("$p1", SqliteType.Integer).Value = enabled!;
        }

        command.CommandText = query + "ORDER BY Name";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = careerId;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Specialty specialty = HydrateObject(reader);
            yield return specialty;
        }
    }

    public override bool Insert(Specialty entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "INSERT INTO Specialty (CareerId, Name, Enabled, UpdatedOn) VALUES ($p0, $p1, $p2, CURRENT_TIMESTAMP) RETURNING Id";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    public override int Update(Specialty entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "UPDATE Specialty SET CareerId = $p0, Name = $p1, Enabled = $p2, UpdatedOn = CURRENT_TIMESTAMP WHERE Id = $id";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override int Delete(Specialty entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM Specialty WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool InsertOrUpdate(Specialty entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        INSERT INTO Specialty (CareerId, Name, Enabled, UpdatedOn)
        VALUES ($p0, $p1, $p2, CURRENT_TIMESTAMP)
        ON CONFLICT(CareerId, Name) DO UPDATE
        SET Enabled   = excluded.Enabled,
            UpdatedOn = excluded.UpdatedOn
        RETURNING Id
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
        command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    protected override Specialty HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 6);
        return new Specialty
        {
            Id        = reader.GetInt64(0),
            CareerId  = reader.GetInt64(1),
            Name      = reader.GetString(2),
            Enabled   = reader.GetBoolean(3),
            UpdatedOn = reader.GetLocalDateTime(4),
            CreatedOn = reader.GetLocalDateTime(5),
        };
    }
}
