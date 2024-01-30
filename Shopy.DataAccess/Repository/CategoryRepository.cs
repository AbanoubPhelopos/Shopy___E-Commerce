using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;
using Shopy.Models;

namespace Shopy.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category category)
        {
            _dbContext.categories.Update(category);
        }
    }
}
