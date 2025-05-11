namespace TECNM.Residencias.Data.Extensions;

using System;

/// <summary>
/// Provides extension methods for the <see cref="DateTimeOffset"/> struct.
/// </summary>
public static class DateTimeOffsetExtensions
{
    private const string DATE_RFC3339 = @"yyyy\-MM\-dd\THH\:mm\:sszzz";

    /// <summary>
    /// Converts a <see cref="DateTimeOffset"/> to its string representation in RFC 3339 format.
    /// </summary>
    /// <param name="dto">The <see cref="DateTimeOffset"/> instance to convert.</param>
    /// <returns>A string representating the date and time in RFC 3339 format.</returns>
    public static string ToRfc3339(this DateTimeOffset dto)
        => dto.ToString(DATE_RFC3339);
}
