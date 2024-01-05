using CodeSense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Application.Abstractions
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        IEnumerable<User> GetUsers();
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
