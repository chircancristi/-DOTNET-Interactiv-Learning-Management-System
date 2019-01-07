using System;
using DataLayer;
using BusinessLayer;
using System.Collections.Generic;

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

        public List<Answer> GetAnswersByQuestionId(Guid questionId)
        {
            return _unitOfWork.AnswerRepository.GetAnswersByQuestionId(questionId);
        }

        public List<Question> GetQuestionsByRoomId(Guid roomId)
        {
            return _unitOfWork.QuestionRepository.GetQuestionByRoomId(roomId);
        }

        public void MarkFavouriteAnswer(Guid answerId)
        {
            var answer = _unitOfWork.AnswerRepository.GetAnswerById(answerId);
            answer.MarkAsFavourite();
            _unitOfWork.AnswerRepository.Update(answer);
        }
    }
}
