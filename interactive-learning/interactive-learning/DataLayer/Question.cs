using System;
namespace DataLayer
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

        public Question(Guid ownerId, Guid roomId, string type, string content)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            RoomId = roomId;
            Type = type;
            Content = content;
            Start = DateTime.Now;
            Stop = Start.AddMinutes(5);
        }

        public void SetTimeToAnswer(int minutes)
        {
            Start = DateTime.Now.Date;
            Stop = Start.AddMinutes(minutes);
        }
    }
}
