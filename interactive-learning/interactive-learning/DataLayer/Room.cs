using System;
namespace DataLayer
{
    public class Room
    {

        public Guid Id { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid ProfesorId { get; private set; }
        public bool Open { get; private set; }

        public Room (Guid courseId, Guid profesorId) {
            Id = Guid.NewGuid();
            CourseId = courseId;
            ProfesorId = profesorId;
            Open = true;
        }

        public void CloseRoom() {
            Open = false;
        }

    }
}
