using System;
namespace DataLayer
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid ProfessorId { get; private set; }
        public Room GeneralRoom { get; private set; }

        public Course(string name, Guid professorId) {
            Id = Guid.NewGuid();
            Name = name;
            ProfessorId = professorId;
            GeneralRoom = new Room(Id, ProfessorId);
        }

        public Course()
        {
        }
    }
}
