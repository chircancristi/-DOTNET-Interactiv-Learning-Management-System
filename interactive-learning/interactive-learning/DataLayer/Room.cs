using System;
namespace DataLayer
{
    public class Room
    {

        public Guid Id { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid ProfesorId { get; private set; }
        public bool Open { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int Token { get; private set; }

        public Room (Guid courseId, Guid profesorId) {
            Id = Guid.NewGuid();
            CourseId = courseId;
            ProfesorId = profesorId;
            Open = true;
            CreatedDate = DateTime.Now;
            Token = GenerateToken();
        }

        public void CloseRoom() {
            Open = false;
        }

        private int GenerateToken()
        {
            Random numberGenerator = new Random();
            return numberGenerator.Next(1000, 10000);
        }

    }
}
