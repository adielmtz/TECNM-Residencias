namespace TECNM.Residencias.Data.Extensions;

using Microsoft.Data.Sqlite;
using System;
using System.Globalization;

/// <summary>
/// Provides extension methods for the <see cref="SqliteDataReader"/> class,
/// allowing for more convenient retrieval of data types from a SQLite database.
/// </summary>
public static class SqliteDataReaderExtensions
{
    /// <summary>
    /// Gets the value of the specified column as <see cref="long"/>?.
    /// </summary>
    /// <param name="reader">The <see cref="SqliteDataReader"/> instance.</param>
    /// <param name="ordinal">The zero-based column ordinal.</param>
    /// <returns>The value of the column as <see cref="long"/>, or <see langword="null"/> if the value is <see cref="DBNull"/>.</returns>
    public static long? GetOptionalInt64(this SqliteDataReader reader, int ordinal)
        => reader.IsDBNull(ordinal) ? null : reader.GetInt64(ordinal);

    /// <summary>
    /// Gets the value of the specified column as <see cref="string"/>?.
    /// </summary>
    /// <param name="reader">The <see cref="SqliteDataReader"/> instance.</param>
    /// <param name="ordinal">The zero-based column ordinal.</param>
    /// <returns>The value of the column as <see cref="string"/>, or <see langword="null"/> if the value is <see cref="DBNull"/>.</returns>
    public static string? GetOptionalString(this SqliteDataReader reader, int ordinal)
        => reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);

    /// <summary>
    /// Gets the value of the specified column as <see cref="DateOnly"/>.
    /// </summary>
    /// <param name="reader">The <see cref="SqliteDataReader"/> instance.</param>
    /// <param name="ordinal">The zero-based column ordinal.</param>
    /// <returns>The value of the column as <see cref="DateOnly"/>.</returns>
    public static DateOnly GetDateOnly(this SqliteDataReader reader, int ordinal)
        => DateOnly.Parse(reader.GetString(ordinal), CultureInfo.InvariantCulture);

    /// <summary>
    /// Gets the value of the specified column as an enum of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of enum to return.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/> instance.</param>
    /// <param name="ordinal">The zero-based column ordinal.</param>
    /// <returns>The value of the column as an <typeparamref name="TEnum"/> value.</returns>
    public static TEnum GetEnum<TEnum>(this SqliteDataReader reader, int ordinal) where TEnum : struct
        => Enum.Parse<TEnum>(reader.GetString(ordinal));
}
