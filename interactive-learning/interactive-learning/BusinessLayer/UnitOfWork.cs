using DataLayer;
namespace BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleContext _peopleContext;
        private readonly InteractionContext _interactionContext;
        private readonly CoursesContext _coursesContext;

        public UnitOfWork(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }   

        public ITRepository<Student> StudentRepository =>
            new GenericRepository<Student>(_peopleContext);
        public ITRepository<Profesor> ProfesorRepository =>
            new GenericRepository<Profesor>(_peopleContext);

        public ITRepository<Profesor> CourseRepository =>
            new GenericRepository<Profesor>(_coursesContext);

        public ITRepository<Profesor> RoomRepository =>
            new GenericRepository<Profesor>(_coursesContext);

        public ITRepository<Profesor> QuestionRepository =>
            new GenericRepository<Profesor>(_interactionContext);

        public ITRepository<Profesor> AnswerRepository =>
            new GenericRepository<Profesor>(_interactionContext);

        public void Commit()
        {
            _peopleContext.SaveChanges();
        }
    }
}
