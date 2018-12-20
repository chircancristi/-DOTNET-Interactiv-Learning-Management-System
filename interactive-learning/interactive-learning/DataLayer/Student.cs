using System;

namespace DataLayer
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Course { get; private set; }
        public int Pluses { get; private set; }

        public Student(string firstName, string lastName, string course)
        {
            Id = Guid.NewGuid();
            SetProperties(firstName, lastName, course);
        }

        public void Update(string firstName, string lastName, string course)
        {
            SetProperties(firstName, lastName, course);
        }

        private void SetProperties(string firstName, string lastName, string course)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            Pluses = 0;
        }

        public void addPlus()
        {
            this.Pluses ++;
        }
    }
}
