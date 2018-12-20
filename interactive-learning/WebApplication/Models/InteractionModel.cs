using System;
using DataLayer;
using BusinessLayer;

namespace Models
{
    public class InteractionModel
    {
        private readonly UnitOfWork _unitOfWork;

        public InteractionModel()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Question GetQuestion(Guid guid)
        {
            return _unitOfWork.QuestionRepository.GetQuestionById(guid);
        }

        public Answer GetAnswer(Guid guid)
        {
            return _unitOfWork.AnswerRepository.GetAnswerById(guid);
        }
    }
}
