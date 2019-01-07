using System;
namespace DataLayer
{
    public class StudentCourseRelationship
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }

        public StudentCourseRelationship(Guid studentId, Guid courseId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
