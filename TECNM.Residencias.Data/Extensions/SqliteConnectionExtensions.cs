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
}
