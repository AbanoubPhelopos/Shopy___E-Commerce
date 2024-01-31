using Microsoft.EntityFrameworkCore;
using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace Shopy.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
            _dbContext.products.Include(u => u.CategoryId).Include(u => u.Category);
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProparties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProparties))
            {
                foreach (var includeProp in includeProparties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProparties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProparties))
            {
                foreach (var includeProp in includeProparties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query=query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }
    }
}
