using Shopy.Models;


namespace Shopy.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product> 
    {
        public void Update(Product product);
    }
}
