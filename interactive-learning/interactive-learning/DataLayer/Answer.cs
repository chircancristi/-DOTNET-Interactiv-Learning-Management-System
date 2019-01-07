using System;
namespace DataLayer
{
    public class Answer
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid QuestionId { get; private set; }
        public String Content { get; private set; }
        public Boolean FavouriteAnswerFlag { get; private set; }

        public Answer(Guid ownerId, Guid questionId, string content)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            QuestionId = questionId;
            Content = content;
            FavouriteAnswerFlag = false;
        }

        public void MarkAsFavourite()
        {
            FavouriteAnswerFlag = true;
        }
    }
}
