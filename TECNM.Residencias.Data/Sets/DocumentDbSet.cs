namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

public sealed class DocumentDbSet : DbSet<Document>
{
    public DocumentDbSet(DbContext context) : base(context)
    {
    }

    public override IEnumerable<Document> EnumerateAll() => throw new NotImplementedException();

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="Document"/> belonging to the specified <see cref="Student"/>.
    /// </summary>
    /// <param name="student">The owner of the documents to retrieve from the underlaying database.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating the entities retrieved.</returns>
    public IEnumerable<Document> EnumerateAll(Student student)
    {
        using var command = CreateCommand("""
        SELECT Id, StudentId, TypeId, FullPath, OriginalName, Size, Hash, CreatedOn
        FROM Document
        WHERE StudentId = $id
        ORDER BY TypeId
        """);

        command.Parameters.Add("$id", SqliteType.Integer).Value = student.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all entities of type <see cref="DocumentType"/> from the underlying database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<DocumentType> EnumerateDocumentTypes()
    {
        using var command = CreateCommand("SELECT Id, Label, Tag FROM DocumentType ORDER BY Id");
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new DocumentType
            {
                Id       = reader.GetInt64(0),
                Label    = reader.GetString(1),
                Tag      = reader.GetString(2),
            };
        }
    }

    public override bool Contains(Document entity) => throw new NotImplementedException();

    public override bool Add(Document entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Document (StudentId, TypeId, FullPath, OriginalName, Size, Hash, CreatedOn)
        VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6)
        RETURNING Id
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.StudentId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.TypeId;
        command.Parameters.Add("$p2", SqliteType.Text).Value    = entity.FullPath;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = entity.OriginalName;
        command.Parameters.Add("$p4", SqliteType.Integer).Value = entity.Size;
        command.Parameters.Add("$p5", SqliteType.Text).Value    = entity.Hash;
        command.Parameters.Add("$p6", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        object? result = command.ExecuteScalar();

        if (result is long rowid)
        {
            entity.Id = rowid;
            return true;
        }

        return false;
    }

    public override int Update(Document entity)
    {
        using var command = CreateCommand("""
        UPDATE Document
        SET StudentId    = $p0,
            TypeId       = $p1,
            FullPath     = $p2,
            OriginalName = $p3,
            Size         = $p4,
            Hash         = $p5
        WHERE Id = $id
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.StudentId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.TypeId;
        command.Parameters.Add("$p2", SqliteType.Text).Value    = entity.FullPath;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = entity.OriginalName;
        command.Parameters.Add("$p4", SqliteType.Integer).Value = entity.Size;
        command.Parameters.Add("$p5", SqliteType.Text).Value    = entity.Hash;
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Document entity) => throw new NotImplementedException();

    public override int Remove(Document entity)
    {
        using var command = CreateCommand("DELETE FROM Document WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    protected override Document HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 8);
        int index = 0;
        return new Document
        {
            Id           = reader.GetInt64(index++),
            StudentId    = reader.GetInt64(index++),
            TypeId       = reader.GetInt64(index++),
            FullPath     = reader.GetString(index++),
            OriginalName = reader.GetString(index++),
            Size         = reader.GetInt64(index++),
            Hash         = reader.GetString(index++),
            CreatedOn    = reader.GetDateTimeOffset(index++),
        };
    }
}
