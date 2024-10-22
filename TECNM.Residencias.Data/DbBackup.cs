namespace TECNM.Residencias.Data;

using Microsoft.Data.Sqlite;
using System;
using System.IO;

/// <summary>
/// Represents a database backup operation.
/// This class is intended exclusively for SQLite databases.
/// </summary>
public sealed class DbBackup : IDisposable
{
    private readonly SqliteConnection _source;
    private readonly DateTime _backupDateTime;
    private readonly string _directory;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbBackup"/> class with a specified SQLite
    /// connection, directory path, and backup date/time.
    /// </summary>
    /// <param name="source">The SQLite connection to the source database to back up.</param>
    /// <param name="directory">The directory path where the backup will be stored.</param>
    /// <param name="backupDateTime">The date and time of the backup.</param>
    public DbBackup(SqliteConnection source, string directory, DateTime backupDateTime)
    {
        _source = source;
        _directory = directory;
        _backupDateTime = backupDateTime;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DbBackup"/> class with a specified SQLite
    /// connection and directory path. The current date/time is used as the backup time.
    /// </summary>
    /// <param name="source">The SQLite connection to the source database to back up.</param>
    /// <param name="directory">The directory path where the backup will be stored.</param>
    public DbBackup(SqliteConnection source, string directory) : this(source, directory, DateTime.Now)
    {
    }

    /// <summary>
    /// Gets the date and time when the backup is created.
    /// </summary>
    public DateTime BackupDateTime => _backupDateTime;

    /// <summary>
    /// Gets the directory where the backup is saved.
    /// </summary>
    public string BackupDirectory => _directory;

    /// <summary>
    /// Disposes the source database.
    /// </summary>
    public void Dispose() => _source.Dispose();

    /// <summary>
    /// Executes the backup operation and returns the full path of the resulting backup file.
    /// </summary>
    /// <returns>The full path of the backup file.</returns>
    public string Execute()
    {
        SqliteConnection source = _source;
        string filename = $"database.db.{BackupDateTime:yyyyMMddHHmmss}.bak";
        string fullpath = Path.Combine(BackupDirectory, filename);

        using var destination = new SqliteConnection(
            new SqliteConnectionStringBuilder
            {
                DataSource = fullpath,
            }.ConnectionString
        );

        source.BackupDatabase(destination);
        SqliteConnection.ClearPool(destination);
        return fullpath;
    }
}
