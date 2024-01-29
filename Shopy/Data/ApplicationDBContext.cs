using Microsoft.EntityFrameworkCore;
using Shopy.Models;

namespace Shopy.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options){ }

        public DbSet<Category> categories { get; set; }
    }
}
