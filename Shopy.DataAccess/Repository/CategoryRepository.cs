﻿using Shopy.DataAccess.Data;
using Shopy.DataAccess.Repository.IRepository;
using Shopy.Models;

namespace Shopy.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category category)
        {
            _dbContext.categories.Update(category);
        }
    }
}
