using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_lyashuk.Models;

namespace wt_lab8_8razor_postgresql_lyashuk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players => Set<Player>();
    }
}