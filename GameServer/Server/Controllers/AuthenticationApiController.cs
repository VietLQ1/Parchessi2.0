using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Services;
using SharedLibrary.Authentication;

namespace Server.Controllers;

[Route("api/AuthenticationApi")]
[ApiController]
public class AuthenticationApiController : Controller
{
    private readonly IGameAuthenticationService _authenticationService;
    
    public AuthenticationApiController(IGameAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [Route("api/AuthenticationApi/Login")]
    [HttpPost]
    public ActionResult<AuthenticationResponse> Login(AuthenticationRequest authenticationRequest)
    {
        var result = _authenticationService.Login(authenticationRequest.UserName, authenticationRequest.Password);
        if (result.IsSuccess)
        {
            return Ok(result.Token);
        }
        else
        {
            return BadRequest(result);
        }
    }
    
    
    [Route("api/AuthenticationApi/Register")]
    [HttpPost]
    public ActionResult<AuthenticationResponse> Register(AuthenticationRequest authenticationRequest)
    {
        var result = _authenticationService.Register(authenticationRequest.UserName, authenticationRequest.Password);
        if (result.IsSuccess)
        {
            return Login(authenticationRequest);
        }
        else
        {
            return BadRequest(result);
        }
    }
    
}