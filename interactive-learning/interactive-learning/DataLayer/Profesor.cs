using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class Profesor
    {
        public Profesor()
        {

        }

        public Profesor(string firstName, string lastName, string course, List<Student> listOfStudents)
        {
            Id = Guid.NewGuid();
            SetProperties(firstName, lastName, course, listOfStudents);
        }

        public void Update(string firstName, string lastName, string course, List<Student> listOfStudents)
        {
            SetProperties(firstName, lastName, course, listOfStudents);
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Course { get; private set; }
        public List<Student> ListOfStudents { get; private set; }

        private void SetProperties(string firstName, string lastName, string course, List<Student> listOfStudents)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            ListOfStudents = listOfStudents;
        }
    }
}
