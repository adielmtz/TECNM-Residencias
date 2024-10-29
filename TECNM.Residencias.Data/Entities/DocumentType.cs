namespace TECNM.Residencias.Data.Entities;

/// <summary>
/// Represents the type of a document entity in the database.
/// </summary>
public sealed class DocumentType
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the document type label.
    /// </summary>
    public string Label { get; set; } = "";

    /// <summary>
    /// Gets or sets the file tag.
    /// </summary>
    public string Tag { get; set; } = "";

    /// <summary>
    /// Returns the document type label as string representation.
    /// </summary>
    /// <returns>The label of the document type.</returns>
    public override string ToString() => Label;
}
