using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class StudentRepository<T> : ITRepository<T> where T : Student
    {
        private readonly PeopleContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public StudentRepository(PeopleContext context)
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

        public Student GetStudentById(Guid Id)
        {
            var student = Entities.First(a => a.Id == Id);
            return student;
        }
    }
}
