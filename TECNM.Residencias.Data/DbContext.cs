namespace TECNM.Residencias.Data;

using System;
using Microsoft.Data.Sqlite;

/// <summary>
/// Represents a base class for database contexts that manage the connection and transactions.
/// This class is intended exclusively for SQLite databases.
/// </summary>
public abstract class DbContext : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly SqliteTransaction _transaction;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbContext"/> class.
    /// </summary>
    /// <param name="connection">The SQLite connection to be managed by this context.</param>
    protected DbContext(SqliteConnection connection)
    {
        _connection = connection;
        _transaction = connection.BeginTransaction(deferred: true);
    }

    /// <summary>
    /// Gets the SQLite connection associated with this context.
    /// </summary>
    public SqliteConnection Connection
        => _connection;

    /// <summary>
    /// Diposes the connection and active transaction used by the
    /// current instance of the <see cref="DbContext"/> class.
    /// </summary>
    public void Dispose()
    {
        _connection.Dispose();
        _transaction.Dispose();
    }

    /// <summary>
    /// Commits the changes made in the current context.
    /// </summary>
    public void SaveChanges()
        => _transaction.Commit();

    /// <summary>
    /// Reverts the changes made in the current context.
    /// </summary>
    public void RejectChanges()
        => _transaction.Rollback();
}
