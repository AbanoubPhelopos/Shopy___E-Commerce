using Microsoft.EntityFrameworkCore;

namespace Shopy.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
                
        }
    }
}
