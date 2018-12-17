using System;
namespace DataLayer
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid ProfessorId { get; private set; }
        public DateTime BeginAt { get; private set; }
        public DateTime EntAt { get; private set; }

        public Course(string name, Guid professorId)
        {
            Id = Guid.NewGuid();
            Name = name;
            ProfessorId = professorId;
            BeginAt = DateTime.Now.Date;
            EntAt = DateTime.Now.Date;
        }
    }
}
