using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class StudentRoomRelationshipRepository<T> : ITRepository<T> where T : StudentRoomRelationship
    {
        private readonly CoursesContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public StudentRoomRelationshipRepository(CoursesContext context)
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

        public StudentRoomRelationship GetRelationshipById(Guid Id)
        {
            var relationship = Entities.First(a => a.Id == Id);
            return relationship;
        }

        public List<StudentRoomRelationship> GetRelationshipsByRoomId(Guid roomId)
        {
            return _context.StudentRoomRelationships
               .Where(a => a.RoomId == roomId)
               .ToList();
        }
    }
}
