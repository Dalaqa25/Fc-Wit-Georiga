using Microsoft.EntityFrameworkCore;
using WitGeorgiaMVC.ViewsModel;

namespace WitGeorgiaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<DeletedPlayers> DeletedPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
