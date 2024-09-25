namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class DocumentDbSet : DbSet<Document>
{
    public DocumentDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<Document> EnumerateDocumentsByStudent(long studentId)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, StudentId, Type, FullPath, OriginalName, Size, Hash, CreatedOn FROM Document WHERE StudentId = $p0 ORDER BY Type";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = studentId;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Document document = HydrateObject(reader);
            yield return document;
        }
    }

    public override bool Insert(Document entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        INSERT INTO Document (StudentId, Type, FullPath, OriginalName, Size, Hash)
        VALUES ($p0, $p1, $p2, $p3, $p4, $p5)
        RETURNING Id
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.StudentId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Type;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.FullPath;
        command.Parameters.Add("$p3", SqliteType.Text).Value = entity.OriginalName;
        command.Parameters.Add("$p4", SqliteType.Integer).Value = entity.Size;
        command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Hash;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    public override int Update(Document entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        UPDATE Document
        SET StudentId    = $p0,
            Type         = $p1,
            FullPath     = $p2,
            OriginalName = $p3,
            Size         = $p4,
            Hash         = $p5
        WHERE Id = $id
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.StudentId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Type;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.FullPath;
        command.Parameters.Add("$p3", SqliteType.Text).Value = entity.OriginalName;
        command.Parameters.Add("$p4", SqliteType.Integer).Value = entity.Size;
        command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Hash;
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override int Delete(Document entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM Document WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool InsertOrUpdate(Document entity)
    {
        if (entity.Id > 0)
        {
            return Update(entity) > 0;
        }
        else
        {
            return Insert(entity);
        }
    }

    protected override Document HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 8);
        return new Document
        {
            Id           = reader.GetInt64(0),
            StudentId    = reader.GetInt64(1),
            Type         = reader.GetInt32(2),
            FullPath     = reader.GetString(3),
            OriginalName = reader.GetString(4),
            Size         = reader.GetInt64(5),
            Hash         = reader.GetString(6),
            CreatedOn    = reader.GetLocalDateTime(7),
        };
    }
}
