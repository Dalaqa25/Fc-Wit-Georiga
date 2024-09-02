using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WitGeorgia.Dtos;
using WitGeorgia.Model;

namespace WitGeorgia.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext( DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<DeletedPlayers> DeletedPlayers { get; set; }
}