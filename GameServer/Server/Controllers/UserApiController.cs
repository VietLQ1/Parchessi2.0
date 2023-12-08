﻿using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedLibrary;

namespace Server.Controllers;

[Route("api/UserApi")]
[ApiController]
public class UserApiController : Controller
{
    private readonly GameDBContext _context;
    
    public UserApiController(GameDBContext context)
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
        _context.Users.Add(new User
        {
            UserName = "test",
            PasswordHash = "test",
            PasswordSalt = "test"
        });
        
        // Your action method logic here
        return Ok("User data");
    }
    
    
}