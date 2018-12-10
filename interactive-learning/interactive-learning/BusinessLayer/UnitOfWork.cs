using DataLayer;
namespace BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleContext _peopleContext;

        public UnitOfWork(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }   

        public ITRepository<Student> StudentRepository =>
            new GenericRepository<Student>(_peopleContext);
        public ITRepository<Profesor> ProfesorRepository =>
            new GenericRepository<Profesor>(_peopleContext);

        public void Commit()
        {
            _peopleContext.SaveChanges();
        }
    }
}
