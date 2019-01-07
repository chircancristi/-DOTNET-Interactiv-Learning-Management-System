using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class QuestionRepository<T> : ITRepository<T> where T : Question
    {
        private readonly InteractionContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public QuestionRepository(InteractionContext context)
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

        public Question GetQuestionById(Guid Id)
        {
            var question = Entities.First(a => a.Id == Id);
            return question;
        }

        public List<Question> GetQuestionsByRoomId (Guid roomId)
        {
            var result = _context.Questions
                .Where(a => a.RoomId == roomId)
                .ToList();

            return result;
        }
    }
}
