using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Domain.Validators;
using CodeSense.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Application.Services;

//TODO: Move this to Application layer

public class AuthenticationService(CodeSenseDbContext context, IPasswordHasher<User> passwordHasher) : IAuthenticationService
{
    private readonly CodeSenseDbContext _context = context;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;


    public async Task<bool> LoginAsync(User loginUser)
    {

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.IsDeleted == false);

        if (user == null)
        {
            return false;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginUser.Password);

        return result == PasswordVerificationResult.Success;
    }

    public async Task<bool> RegisterAsync(User user)
    {

        var checkExistence = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.IsDeleted == false);
        if (checkExistence is not null)
        {
            return false;
        }

        user.Password = _passwordHasher.HashPassword(user, user.Password);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnregisterAsync(User user)
    {

        var checkExistence = await _context.Users.FirstOrDefaultAsync(u => !(u.Email != user.Email && u.IsDeleted == false));
        if (checkExistence is null)
        {
            return false;
        }

        user.IsDeleted = true;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return true;
    }

    
}