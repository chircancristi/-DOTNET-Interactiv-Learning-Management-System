using System;
using System.Linq;

namespace BusinessLayer
{
    class AnswerRepository
    {
        public UnitOfWork unitOfWork;

        public AnswerRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void CreateAnswer(DataLayer.Answer answer)
        {
            unitOfWork.AnswerRepository.Add(answer);
        }

        void RemoveAnswerByItsId(Guid Id)
        {
            var answer = unitOfWork.AnswerRepository.Entities.First(a => a.Id == Id);
            unitOfWork.AnswerRepository.Remove(answer);
            unitOfWork.Commit();
        }
    }
}
