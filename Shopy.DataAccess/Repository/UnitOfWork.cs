﻿using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;


namespace Shopy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _dbContext;
        public ICategoryRepository Category {  get; private set; }
        public IProductRepository Product {  get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            Category=new CategoryRepository(_dbContext);
            Product=new ProductRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
