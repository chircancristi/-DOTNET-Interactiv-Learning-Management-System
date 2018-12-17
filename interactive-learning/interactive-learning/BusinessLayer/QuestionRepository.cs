using System;
using System.Linq;

namespace BusinessLayer
{
    class QuestionRepository
    {
        public UnitOfWork unitOfWork;

        public QuestionRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void CreateQuestion(DataLayer.Question question)
        {
            unitOfWork.QuestionRepository.Add(question);
        }

        void RemoveQuestionByItsId(Guid Id)
        {
            var question = unitOfWork.QuestionRepository.Entities.First(a => a.Id == Id);
            unitOfWork.QuestionRepository.Remove(question);
            unitOfWork.Commit();
        }
    }
}
