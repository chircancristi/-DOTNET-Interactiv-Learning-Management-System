using System;

namespace DataLayer
{
    public class Profesor
    {
        public Profesor()
        {

        }

        public Profesor(string firstName, string lastName, string course)
        {
            Id = Guid.NewGuid();
            SetProperties(firstName, lastName, course);
        }

        public void Update(string firstName, string lastName, string course)
        {
            SetProperties(firstName, lastName, course);
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Course { get; private set; }

        private void SetProperties(string firstName, string lastName, string course)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = course;
        }
    }
}
