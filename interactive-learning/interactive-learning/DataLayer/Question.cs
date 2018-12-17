using System;
namespace interactive_learning.DataLayer
{
    public class Question
    {

        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid RoomId { get; private set; }
        public String Type { get; private set; }
        public String Content { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }

        public Question(Guid id, Guid ownerId, Guid roomId, string type, string content)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.RoomId = roomId;
            this.Type = type;
            this.Content = content;
            this.Start = DateTime.Now.Date;
            this.Stop = DateTime.Now.Date;

        }
    }
}
