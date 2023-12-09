using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedLibrary;

namespace Server.Controllers;

[Route("api/UserApi")]
[ApiController]
public class UserApiController : Controller
{
    private readonly GameDbContext _context;
    
    public UserApiController(GameDbContext context)
    {
        _context = context;
        
        Console.WriteLine("User Api");

    }
    
    [HttpGet]
    public IActionResult GetUser()
    {
        // Your action method logic here
        return Ok("User data");
    }

    [HttpPost]
    public IActionResult PostUser()
    {
        
        
        // Your action method logic here
        return Ok("User data");
    }
    
    
}