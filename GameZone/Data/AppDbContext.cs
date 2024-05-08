using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions) {
       
        }
       
    }
}
