using DataLayer;

namespace BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleContext _peopleContext;
        private readonly InteractionContext _interactionContext;
        private readonly CoursesContext _coursesContext;

        public UnitOfWork()
        {
            _peopleContext = new PeopleContext();
            _interactionContext = new InteractionContext();
            _coursesContext = new CoursesContext();
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

        public StudentRepository<Student> StudentRepository =>
            new StudentRepository<Student>(_peopleContext);

        public ProfesorRepository<Profesor> ProfesorRepository =>
            new ProfesorRepository<Profesor>(_peopleContext);

        public CourseRepository<Course> CourseRepository =>
            new CourseRepository<Course>(_coursesContext);

        public RoomRepository<Room> RoomRepository =>
            new RoomRepository<Room>(_coursesContext);

        public QuestionRepository<Question> QuestionRepository =>
            new QuestionRepository<Question>(_interactionContext);

        public AnswerRepository<Answer> AnswerRepository =>
            new AnswerRepository<Answer>(_interactionContext);

        public StudentCourseRelationshipRepository<StudentCourseRelationship> StudentCourseRelationshipRepository =>
            new StudentCourseRelationshipRepository<StudentCourseRelationship>(_coursesContext);

        public void Commit()
        {
            _peopleContext.SaveChanges();
            _interactionContext.SaveChanges();
            _coursesContext.SaveChanges();
        }
    }
}
