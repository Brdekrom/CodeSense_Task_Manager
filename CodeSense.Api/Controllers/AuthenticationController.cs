using CodeSense.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers;

public class AuthenticationController
{
    public AuthenticationController()
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User request)
    {
        throw new NotImplementedException();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User request)
    {
        throw new NotImplementedException();
    }
}