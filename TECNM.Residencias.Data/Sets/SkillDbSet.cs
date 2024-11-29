namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

public sealed class SkillDbSet : DbSet<Skill>
{
    public SkillDbSet(DbContext context) : base(context)
    {
    }

    public int DeleteSkillsOfStudent(Student student)
    {
        using var command = CreateCommand("DELETE FROM StudentSkills WHERE StudentId = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = student.Id;
        return command.ExecuteNonQuery();
    }

    public int AddSkillsOfStudent(Student student, IEnumerable<long> skills)
    {
        using var command = CreateCommand("INSERT INTO StudentSkills (StudentId, SkillId) VALUES ($p0, $p1) ON CONFLICT DO NOTHING");
        command.Parameters.Add("$p0", SqliteType.Integer).Value = student.Id;

        SqliteParameter parameter = command.Parameters.Add("$p1", SqliteType.Integer);
        int count = 0;

        foreach (long skillid in skills)
        {
            parameter.Value = skillid;
            count += command.ExecuteNonQuery();
        }

        return count;
    }

    public override IEnumerable<Skill> EnumerateAll()
    {
        using var command = CreateCommand("SELECT Id, Type, Value FROM Skill ORDER BY Id");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all skill entities that belong to the specified student.
    /// </summary>
    /// <param name="student">The <see cref="Student"/> instance to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<Skill> EnumerateAll(Student student)
    {
        return EnumerateAll(student.Id);
    }

    /// <summary>
    /// Retrieves and enumerates all skill entities that belong to the specified student.
    /// </summary>
    /// <param name="studentId">The unique rowid of the student to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<Skill> EnumerateAll(long studentId)
    {
        using var command = CreateCommand("""
        SELECT Id, Type, Value
        FROM Skill
        INNER JOIN StudentSkills
        ON Id = SkillId
        WHERE StudentId = $p0
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = studentId;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Skill entity) => throw new NotImplementedException();

    public override bool Add(Skill entity) => throw new NotImplementedException();

    public override int Update(Skill entity) => throw new NotImplementedException();

    public override bool AddOrUpdate(Skill entity) => throw new NotImplementedException();

    public override int Remove(Skill entity) => throw new NotImplementedException();

    protected override Skill HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        int index = 0;
        return new Skill
        {
            Id    = reader.GetInt64(index++),
            Type  = reader.GetEnum<SkillType>(index++),
            Value = reader.GetString(index++),
        };
    }
}
