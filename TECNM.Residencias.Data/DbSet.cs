namespace TECNM.Residencias.Data;

using System.Collections.Generic;
using Microsoft.Data.Sqlite;

/// <summary>
/// Represents a generic DbSet for managing a collection of entities of type <typeparamref name="T"/>
/// within a <see cref="DbContext"/>. Provides methods for basic CRUD operations.
/// </summary>
/// <typeparam name="T">The type of entity that the DbSet manages. Must be a class with a parameterless constructor.</typeparam>
public abstract class DbSet<T> where T : class, new()
{
    private readonly DbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbSet{T}"/> class with a given <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> that this DbSet is associated with.</param>
    protected DbSet(DbContext context)
        => _context = context;

    /// <summary>
    /// Gets the <see cref="DbContext"/> associated with this DbSet.
    /// </summary>
    public DbContext Context
        => _context;

    /// <summary>
    /// Retrieves and enumerates all entities of type <typeparamref name="T"/> from the underlying database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public abstract IEnumerable<T> EnumerateAll();

    /// <summary>
    /// Checks whether a specific entity of type <typeparamref name="T"/> exists in the database.
    /// </summary>
    /// <param name="entity">The entity to check for existance.</param>
    /// <returns><see langword="true"/> if the entity exists; otherwise, <see langword="false"/>.</returns>
    public abstract bool Contains(T entity);

    /// <summary>
    /// Adds a new entity of type <typeparamref name="T"/> to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns><see langword="true"/> if the entity was successfully added; otherwise, <see langword="false"/>.</returns>
    public abstract bool Add(T entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The number of rows affected by the update operation.</returns>
    public abstract int Update(T entity);

    /// <summary>
    /// Adds a new entity of type <typeparamref name="T"/> if it doesn't exists, or updates it if it does.
    /// </summary>
    /// <param name="entity">The entity to add or update.</param>
    /// <returns><see langword="true"/> if a new entity was added or updated; otherwise, <see langword="false"/>.</returns>
    public abstract bool AddOrUpdate(T entity);

    /// <summary>
    /// Removes an entity of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>The number of rows affected by the removal operation.</returns>
    public abstract int Remove(T entity);

    /// <summary>
    /// Maps a data row from a <see cref="SqliteDataReader"/> to an entity of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="reader">The <see cref="SqliteDataReader"/> containing the data.</param>
    /// <returns>An instance of <typeparamref name="T"/> representing the hydrated object.</returns>
    protected abstract T HydrateObject(SqliteDataReader reader);

    /// <summary>
    /// Creates a new <see cref="SqliteCommand"/> instance with the specified SQL query.
    /// </summary>
    /// <param name="query">The SQL query string to be executed by the command.
    /// This parameter can be null, in which case the command will be created without a specific query.</param>
    /// <returns>
    /// A <see cref="SqliteCommand"/> configured with the provided query, if any.</returns>
    protected SqliteCommand CreateCommand(string? query = null)
    {
        SqliteCommand command = Context.Connection.CreateCommand();

        if (query is not null)
        {
            command.CommandText = query;
        }

        return command;
    }
}
