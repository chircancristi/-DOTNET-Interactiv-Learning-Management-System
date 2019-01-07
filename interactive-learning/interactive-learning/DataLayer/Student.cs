using System;

namespace DataLayer
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Student(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            SetProperties(firstName, lastName);
        }

        public void Update(string firstName, string lastName)
        {
            SetProperties(firstName, lastName);
        }

        private void SetProperties(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
