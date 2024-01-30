using System.Linq.Expressions;

namespace Shopy.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);

    }
}
