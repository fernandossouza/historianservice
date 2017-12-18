using Microsoft.EntityFrameworkCore;
using historianservice.Model;

namespace historianservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Historian> Historians{get;set;}
        
    }
}