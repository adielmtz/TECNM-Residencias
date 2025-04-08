namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents a document entity in the database.
/// </summary>
public sealed class Document
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid of the student to which the document belongs.
    /// </summary>
    public long StudentId { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid of the document type.
    /// </summary>
    public long TypeId { get; set; }

    /// <summary>
    /// Gets or sets the location of the document on the file system.
    /// </summary>
    public string Location { get; set; } = "";

    /// <summary>
    /// Gets or sets the original name of the document.
    /// </summary>
    public string OriginalName { get; set; } = "";

    /// <summary>
    /// Gets or sets the size of the document in bytes.
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// Gets or sets the SHA-256 hash of the document.
    /// </summary>
    public string Hash { get; set; } = "";

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }
}
