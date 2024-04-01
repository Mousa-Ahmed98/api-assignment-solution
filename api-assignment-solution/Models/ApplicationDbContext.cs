using Microsoft.EntityFrameworkCore;

namespace api_assignment_solution.Models
{
    public class ApplicationDbContext : DbContext
    {
        //Application Context
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
