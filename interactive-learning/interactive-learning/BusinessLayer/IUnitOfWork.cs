namespace BusinessLayer
{
    public interface IUnitOfWork
    {
        ITRepository<DataLayer.Profesor> ProfesorRepository { get; }
        ITRepository<DataLayer.Student> StudentRepository { get; }

        /// <summary
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
