using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace BusinessLayer
{
    public class RoomRepository<T> : ITRepository<T> where T : Room
    {
        private readonly CoursesContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public RoomRepository(CoursesContext context)
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

        public Room GetRoomById(Guid Id)
        {
            var room = Entities.First(a => a.Id == Id);
            return room;
        }
    }
}
