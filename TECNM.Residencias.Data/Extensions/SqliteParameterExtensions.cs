namespace TECNM.Residencias.Data.Extensions;

using System;
using Microsoft.Data.Sqlite;

/// <summary>
/// Provides extension methods for the <see cref="SqliteParameter"/> class.
/// </summary>
public static class SqliteParameterExtensions
{
    /// <summary>
    /// Sets the value of a <see cref="SqliteParameter"/> to the specified value,
    /// converting <see langword="null"/> values to <see cref="DBNull"/> for compatibility.
    /// </summary>
    /// <typeparam name="T">The type of the value being set.</typeparam>
    /// <param name="parameter">The <see cref="SqliteParameter"/> to set the value for.</param>
    /// <param name="value">The value to assign to the parameter. Can be <see langword="null"/>.</param>
    /// <remarks>
    /// If the <paramref name="value"/> is <see langword="null"/>, the parameter's value will be set to 
    /// <see cref="DBNull"/>, which is necessary for handling nullable database fields.
    /// </remarks>
    public static void SetValue<T>(this SqliteParameter parameter, T? value)
        => parameter.Value = value is null ? DBNull.Value : value!;
}
