using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Users;
using CodeSense.Application.Services;
using CodeSense.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers.Authentication;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService, TokenService tokenService, IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
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
    public async Task<IActionResult> Register([FromBody] CreateUserCommand registerUser)
    {
        try
        {
            var userId = await _mediator.Send(registerUser);

            return Ok(userId);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
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