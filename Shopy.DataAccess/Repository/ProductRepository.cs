using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;
using Shopy.Models;

namespace Shopy.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Product product)
        {
            _dbContext.products.Update(product);
        }
    }
}
