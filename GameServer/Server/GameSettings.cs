namespace Server;

public class GameSettings
{
    public string JwtKey { get; set; } = null!;
    
    public GameSettings(string jwtKey)
    {
        JwtKey = jwtKey;
        
    }
    
    
}