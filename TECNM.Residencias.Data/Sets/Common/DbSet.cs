using System.Data;

namespace TECNM.Residencias.Data.Sets.Common
{
    public abstract class DbSet<T> where T : class
    {
        private readonly IDbContext _context;

        public DbSet(IDbContext context)
        {
            _context = context;
        }

        public IDbContext Context => _context;

        public abstract bool Insert(T entity);

        public abstract int Update(T entity);

        public abstract int Delete(T entity);

        public abstract bool InsertOrUpdate(T entity);

        protected abstract T HydrateObject(IDataReader reader);
    }
}
