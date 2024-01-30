using Microsoft.EntityFrameworkCore;
using Shopy.Models;

namespace Shopy.DataAccess.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options){ }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
