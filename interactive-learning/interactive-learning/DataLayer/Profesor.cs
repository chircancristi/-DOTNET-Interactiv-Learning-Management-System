using System;

namespace DataLayer
{
    public class Profesor
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid CourseId { get; private set; }

        public Profesor()
        {

        }

        public void Update(string firstName, string lastName, Guid courseId)
        {
            SetProperties(firstName, lastName, courseId);
        }
        
        private void SetProperties(string firstName, string lastName, Guid courseId)
        {
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
        }
    }
}
