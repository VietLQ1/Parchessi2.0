using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace Server.Services;

public class GameDBContext : DbContext
{

    public readonly List<User> Users = new();
    
    public GameDBContext(DbContextOptions<GameDBContext> options) : base(options)
    {
        
    }

}