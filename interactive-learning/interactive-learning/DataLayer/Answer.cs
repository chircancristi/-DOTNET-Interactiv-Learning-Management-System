using System;
namespace interactive_learning.DataLayer
{
    public class Answer
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid QuestionId { get; private set; }
        public String Content { get; private set; }

        public Answer(Guid id, Guid ownerId, Guid questionId, string content)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.QuestionId = questionId;
            this.Content = content;
        }
    }
}
