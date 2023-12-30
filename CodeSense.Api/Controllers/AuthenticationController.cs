using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Application.Services;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService, TokenService tokenService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService;
    private readonly TokenService _tokenService = tokenService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User loginUser)
    {
        var isValid = await _authenticationService.LoginAsync(loginUser);
        if (isValid)
        {
            var token = _tokenService.GenerateToken(loginUser);
            return Ok(new { Token = token });
        }
        return Unauthorized("Invalid credentials");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User registerUser)
    {
        var result = await _authenticationService.RegisterAsync(registerUser);

        if (result)
        {
            return Ok("Registration successful");
        }
        return BadRequest("Registration failed");
    }

    [HttpPost("unregister")]
    public async Task<IActionResult> Unregister([FromBody] User unregisterUser)
    {
        var result = await _authenticationService.UnregisterAsync(unregisterUser);

        if (result)
        {
            return Ok("Unregistration successful");
        }
        return BadRequest("Unregistration failed");
    }
}