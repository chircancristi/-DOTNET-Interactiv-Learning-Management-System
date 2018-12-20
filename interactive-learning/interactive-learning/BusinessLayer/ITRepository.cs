using System.Linq;

namespace BusinessLayer
{
    public interface ITRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        void Remove(T entity);

        void Add(T entity);

    }
}
