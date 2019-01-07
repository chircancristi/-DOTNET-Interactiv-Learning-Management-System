using DataLayer;

namespace BusinessLayer
{
    public interface IUnitOfWork
    {
        ProfesorRepository<Profesor> ProfesorRepository { get; }
        StudentRepository<Student> StudentRepository { get; }
        QuestionRepository<Question> QuestionRepository { get; }
        AnswerRepository<Answer> AnswerRepository { get; }
        CourseRepository<Course> CourseRepository { get; }
        RoomRepository<Room> RoomRepository { get; }
        StudentCourseRelationshipRepository<StudentCourseRelationship> StudentCourseRelationshipRepository { get; }
        StudentRoomRelationshipRepository<StudentRoomRelationship> StudentRoomRelationshipRepository { get; }

        /// <summary
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
