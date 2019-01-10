using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CourseRepository<T> : ITRepository<T> where T : Course
    {
        private readonly CoursesContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public CourseRepository(CoursesContext context)
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

        public Course GetCourseById(Guid Id)
        {
            var course = Entities.First(a => a.Id == Id);
            return course;
        }
        
        public List<Course> GetAllCourses()
        {
            return _context.Courses
            .OrderBy(x => x.Name)
            .ToList();
        }
    }
}
