using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;
using Shopy.Models;

namespace Shopy.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Product product)
        {
            var objFromDb =_dbContext.products.FirstOrDefault(p=>p.Id== product.Id);
            if(objFromDb != null)
            {
                objFromDb.Description = product.Description;
                objFromDb.Name = product.Name;
                objFromDb.Price = product.Price;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.CategoryId = product.CategoryId;
                if (objFromDb.ImageURL != null)
                {
                    objFromDb.ImageURL = objFromDb.ImageURL;
                }

            }

        }
    }
}
