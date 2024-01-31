using System.Linq.Expressions;

namespace Shopy.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProparties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProparties = null);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);

    }
}
