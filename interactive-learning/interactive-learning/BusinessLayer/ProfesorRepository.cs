using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace BusinessLayer
{
    public class ProfesorRepository<T> : ITRepository<T> where T : Profesor
    {
        private readonly PeopleContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public ProfesorRepository(PeopleContext context)
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

        public Profesor GetProfesorById(Guid Id)
        {
            var profesor = Entities.First(a => a.Id == Id);
            return profesor;
        }
    }
}
