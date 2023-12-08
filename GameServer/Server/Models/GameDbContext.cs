using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace Server.Services;

public class GameDbContext : DbContext
{

    public readonly List<User> Users = new();
    
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }

}