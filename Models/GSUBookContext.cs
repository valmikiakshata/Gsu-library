using Microsoft.EntityFrameworkCore;

namespace GSULibrary.Models
{
    public class GSUBookContext : DbContext
    {
        public GSUBookContext(DbContextOptions<GSUBookContext> options)
            : base(options)
        {
        }

        public DbSet<GSUBook> Books { get; set; } = null!;
    }
}