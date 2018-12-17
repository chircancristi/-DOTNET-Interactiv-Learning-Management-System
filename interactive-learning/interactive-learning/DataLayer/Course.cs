using System;
namespace interactive_learning.DataLayer
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid ProfessorId { get; private set; }
        public Guid RoomId { get; private set; }
        public DateTime BeginAt { get; private set; }
        public DateTime EntAt { get; private set; }

        public Course(Guid id, string name, Guid professorId, Guid roomId)
        {
            this.Id = id;
            this.Name = name;
            this.ProfessorId = professorId;
            this.RoomId = roomId;
            this.BeginAt = DateTime.Now.Date;
            this.EntAt = DateTime.Now.Date;
        }
    }
}
