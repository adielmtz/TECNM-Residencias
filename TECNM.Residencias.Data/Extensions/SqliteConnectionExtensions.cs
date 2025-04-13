namespace TECNM.Residencias.Data.Extensions;

using Microsoft.Data.Sqlite;

/// <summary>
/// Provides extension methods for <see cref="SqliteConnection"/> class to facilitate executing SQL queries.
/// </summary>
public static class SqliteConnectionExtensions
{
    /// <summary>
    /// Execute an SQL statement and return the number of affected rows.
    /// </summary>
    /// <param name="sqlite">The <see cref="SqliteConnection"/> on which the query will be executed.</param>
    /// <param name="query">The SQL query string to be executed.</param>
    /// <returns>The number of rows affected by the SQL query.</returns>
    public static int Execute(this SqliteConnection sqlite, string query)
    {
        using var command = sqlite.CreateCommand();
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to retrieve a database property.
    /// </summary>
    /// <typeparam name="T">The type of the value to be retrieved.</typeparam>
    /// <param name="sqlite">The <see cref="SqliteConnection"/> on which the query will be executed.</param>
    /// <param name="name">The name of the <c>PRAGMA</c> command to execute.</param>
    /// <returns>The value of the <c>PRAGMA</c>.</returns>
    public static T GetPragma<T>(this SqliteConnection sqlite, string name)
    {
        using var command = sqlite.CreateCommand();
        command.CommandText = $"PRAGMA {name}";
        return (T) command.ExecuteScalar()!;
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to set a database property.
    /// </summary>
    /// <typeparam name="T">The type of the value to be set.</typeparam>
    /// <param name="sqlite">The <see cref="SqliteConnection"/> on which the query will be executed.</param>
    /// <param name="name">The name of the <c>PRAGMA</c> command to execute.</param>
    /// <param name="value">The value to set.</param>
    public static void SetPragma<T>(this SqliteConnection sqlite, string name, T value)
    {
        using var command = sqlite.CreateCommand();
        command.CommandText = $"PRAGMA {name}={value}";
        command.ExecuteNonQuery();
    }
}
