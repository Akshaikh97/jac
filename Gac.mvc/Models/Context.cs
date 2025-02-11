using Microsoft.EntityFrameworkCore;

namespace Gac.mvc.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
