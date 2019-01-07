using System;
namespace DataLayer
{
    public class StudentRoomRelationship
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid RoomId { get; private set; }

        public StudentRoomRelationship(Guid studentId, Guid roomId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            RoomId = roomId;
        }
    }
}
