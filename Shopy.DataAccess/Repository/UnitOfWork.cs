using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;


namespace Shopy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDBContext _dbContext;
        public ICategoryRepository Category {  get; private set; }

        public UnitOfWork(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
            Category=new CategoryRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
