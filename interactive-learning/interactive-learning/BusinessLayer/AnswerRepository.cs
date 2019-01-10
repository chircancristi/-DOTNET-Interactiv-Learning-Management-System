using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class AnswerRepository<T> : ITRepository<T> where T : Answer
    {
        private readonly InteractionContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public AnswerRepository(InteractionContext context)
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

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void MarkAsFavourite(Guid Id)
        {
            var answer = Entities.First(a => a.Id == Id);
            answer.MarkAsFavourite();
            _dbSet.Update(answer);
        }
        public void UnMarkAsFavourite(Guid Id)
        {
            var answer = Entities.First(a => a.Id == Id);
            answer.UnMarkAsFavourite();
            _dbSet.Update(answer);
        }
        public Answer GetAnswerById(Guid Id)
        {
            var answer = Entities.First(a => a.Id == Id);
            return answer;
        }

        public List<Answer> GetAnswersByQuestionId(Guid questionId)
        {
            return _context.Answers
               .Where(a => a.QuestionId == questionId)
               .OrderBy(x => x.CreatedDate)
               .ToList();
        }

        public List<Answer> GetAllAnswers()
        {
            return _context.Answers
                .OrderBy(x => x.CreatedDate)
                .ToList();
        }
    }
}
