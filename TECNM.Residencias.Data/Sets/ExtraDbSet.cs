namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

public sealed class ExtraDbSet : DbSet<Extra>
{
    public ExtraDbSet(DbContext context) : base(context)
    {
    }

    public int DeleteExtrasForStudent(Student student)
    {
        using var command = CreateCommand("DELETE FROM StudentExtras WHERE StudentId = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = student.Id;
        return command.ExecuteNonQuery();
    }

    public int InsertExtrasForStudent(Student student, IEnumerable<Extra> extras)
    {
        using var command = CreateCommand("INSERT INTO StudentExtras (StudentId, ExtraId) VALUES ($p0, $p1) ON CONFLICT DO NOTHING");
        command.Parameters.Add("$p0", SqliteType.Integer).Value = student.Id;

        SqliteParameter parameter = command.Parameters.Add("$p1", SqliteType.Integer);
        int count = 0;

        foreach (Extra extra in extras)
        {
            parameter.Value = extra.Id;
            count += command.ExecuteNonQuery();
        }

        return count;
    }

    public override IEnumerable<Extra> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, Type, Value FROM Extra ORDER BY Id");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all extra entities that belong to the specified student.
    /// </summary>
    /// <param name="student">The <see cref="Student"/> instance to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<Extra> EnumerateAll(Student student)
    {
        using var command = CreateCommand("""
        SELECT Id, Type, Value
        FROM Extra
        INNER JOIN StudentExtras
        ON Id = ExtraId
        WHERE StudentId = $p0
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = student.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Extra entity) => throw new NotImplementedException();

    public override bool Add(Extra entity) => throw new NotImplementedException();

    public override int Update(Extra entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(Extra entity) => throw new NotImplementedException();

    public override int Remove(Extra entity) => throw new NotImplementedException();

    protected override Extra HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        int index = 0;
        return new Extra
        {
            Id    = reader.GetInt64(index++),
            Type  = reader.GetEnum<ExtraType>(index++),
            Value = reader.GetString(index++),
        };
    }
}
