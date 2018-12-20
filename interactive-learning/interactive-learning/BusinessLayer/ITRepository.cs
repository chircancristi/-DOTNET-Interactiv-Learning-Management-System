using System.Linq;
using DataLayer;
namespace BusinessLayer
{
    public interface ITRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        void Remove(T entity);

        void Add(T entity);
    }
}
