using System;

namespace DataLayer
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Pluses { get; private set; }

        public Student(string firstName, string lastName, int pluses)
        {
            Id = Guid.NewGuid();
            SetProperties(firstName, lastName, pluses);
        }

        public void Update(string firstName, string lastName, int pluses)
        {
            SetProperties(firstName, lastName, pluses);
        }

        private void SetProperties(string firstName, string lastName, int pluses)
        {
            FirstName = firstName;
            LastName = lastName;
            Pluses = pluses;
        }

        public void addPlus()
        {
            this.Pluses ++;
        }
    }
}
