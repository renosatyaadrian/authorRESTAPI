using authorRESTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace authorRESTAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Course> Courses { get; set; }
    }
}