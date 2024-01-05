using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Infrastructure.Services
{
    internal class UserService(CodeSenseDbContext dbContext, IPasswordHasher<User> passwordHasher) : IUserService
    {
        private readonly CodeSenseDbContext _dbContext = dbContext;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

        public async Task<User> CreateUserAsync(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            user = await GetUserByEmailAsync(user.Email);

            return user.Id != default ? user : new();

        }

        public async Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                return new();
            }

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
            if (user == null)
            {
                return new();
            }

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var user = _dbContext.Users.Where(u => !u.IsDeleted);
            if (!user.Any())
            {
                return new List<User>();
            }
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var currentUser = await GetUserAsync(user.Id);
            if (currentUser == null)
            {
               return new();
            }

            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Email = user.Email;
            currentUser.Password = _passwordHasher.HashPassword(user, user.Password);
            currentUser.ClientCompanyId = user.ClientCompanyId;
            currentUser.Phone = user.Phone;

            _dbContext.Users.Update(currentUser);
            await _dbContext.SaveChangesAsync();

            return currentUser;
        }
    }
}
