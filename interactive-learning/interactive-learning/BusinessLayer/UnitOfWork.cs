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
        
        public UnitOfWork(PeopleContext peopleContext, InteractionContext interactionContext, CoursesContext coursesContext)
        {
            _peopleContext = peopleContext;
            _interactionContext = interactionContext;
            _coursesContext = coursesContext;
        }

        public PeopleContext GetPeopleContext()
        {
            return _peopleContext;
        }

        public InteractionContext GetInteractionContext()
        {
            return _interactionContext;
        }

        public CoursesContext GetCoursesContext()
        {
            return _coursesContext;
        }

        public ITRepository<Student> StudentRepository =>
            new GenericRepository<Student>(_peopleContext);

        public ITRepository<Profesor> ProfesorRepository =>
            new GenericRepository<Profesor>(_peopleContext);

        public ITRepository<Course> CourseRepository =>
            new GenericRepository<Course>(_coursesContext);

        public ITRepository<Room> RoomRepository =>
            new GenericRepository<Room>(_coursesContext);

        public ITRepository<Question> QuestionRepository =>
            new GenericRepository<Question>(_interactionContext);

        public ITRepository<Answer> AnswerRepository =>
            new GenericRepository<Answer>(_interactionContext);

        public void Commit()
        {
            _peopleContext.SaveChanges();
            _interactionContext.SaveChanges();
            _coursesContext.SaveChanges();
        }
    }
}
