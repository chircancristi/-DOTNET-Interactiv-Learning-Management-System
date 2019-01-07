using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class StudentCourseRelationshipRepository<T> : ITRepository<T> where T : StudentCourseRelationship
    {
        private readonly CoursesContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public StudentCourseRelationshipRepository(CoursesContext context)
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

        public StudentCourseRelationship GetRelationshipById(Guid Id)
        {
            var relationship = Entities.First(a => a.Id == Id);
            return relationship;
        }

        public List<StudentCourseRelationship> GetRelationshipsByCourse(Guid courseId)
        {
            return _context.StudentCourseRelationships
               .Where(a => a.CourseId == courseId)
               .ToList();           
        }
    }
}
