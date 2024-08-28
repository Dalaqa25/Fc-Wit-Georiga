using Microsoft.EntityFrameworkCore;
using WitGeorgia.Model;

namespace WitGeorgia.Data;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Player> Players { get; set; }
}