namespace BusinessLayer
{
    public interface IUnitOfWork
    {
        ITRepository<DataLayer.Profesor> ProfesorRepository { get; }
        ITRepository<DataLayer.Student> StudentRepository { get; }
        ITRepository<DataLayer.Question> QuestionRepository { get; }
        ITRepository<DataLayer.Answer> AnswerRepository { get; }
        ITRepository<DataLayer.Course> CourseRepository { get; }
        ITRepository<DataLayer.Room> RoomRepository { get; }

        /// <summary
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
