using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace Server.Services;

public class GameDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }
    
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }

}