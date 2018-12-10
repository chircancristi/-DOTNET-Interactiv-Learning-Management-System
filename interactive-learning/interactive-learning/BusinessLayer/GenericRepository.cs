using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLayer
{
    public class GenericRepository<T> : ITRepository<T> where T : class
    {
        private readonly DbContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
