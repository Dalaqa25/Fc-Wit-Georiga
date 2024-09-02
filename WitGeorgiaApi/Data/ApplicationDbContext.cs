using Microsoft.EntityFrameworkCore;
using WitGeorgia.Model;

namespace WitGeorgia.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext( DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<DeletedPlayers> DeletedPlayers { get; set; }
}