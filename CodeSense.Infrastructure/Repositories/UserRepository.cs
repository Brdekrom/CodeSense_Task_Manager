using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Infrastructure.Repositories
{
    public sealed class UserRepository(CodeSenseDbContext dbContext, IPasswordHasher<User> passwordHasher) : IRepository<User>
    {
        private readonly CodeSenseDbContext _dbContext = dbContext;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

        public async Task<User> CreateAsync(User user)
        {
            user.UpdatePassword(_passwordHasher.HashPassword(user, user.GetHashedPassword()));

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            user = await GetByEmailAsync(user.GetEmail());

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _dbContext.Users.Where(u => !u.IsDeleted).ToListAsync();

            return users;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var currentUser = await GetByIdAsync(userId);

            if (currentUser == null)
            {
                return false;
            }

            currentUser.IsDeleted = true;
            _dbContext.Users.Update(currentUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GetEmail() == email && !u.IsDeleted);

            return user ?? throw new Exception("User not found");
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

        public async Task<User> UpdateAsync(User user)
        {
            var currentUser = await GetByIdAsync(user.Id);
            if (currentUser == null)
            {
                throw new Exception("User not found");
            }

            _dbContext.Users.Entry(currentUser).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();

            return currentUser;
        }

        public async Task SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}