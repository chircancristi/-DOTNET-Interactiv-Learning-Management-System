using System.Linq;
using DataLayer; 

namespace BusinessLayer
{
    public interface ITRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        void Remove(T entity);

        void Add(T entity);

        void Update(T entity);

        PeopleContext GetPeopleContext();
        InteractionContext GetInteractionContext();
        CoursesContext GetCoursesContext();
    }
}
