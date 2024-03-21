using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        IUserRepositoty _userRepositoty;
        public UserService(IUserRepositoty userRepositoty) { 
            _userRepositoty = userRepositoty;
        }
        public async Task<User> GetUser()
        {
            return await _userRepositoty.GetUserWithMaxOrdersAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepositoty.GetUsersAsync(u => u.Status == UserStatus.Active);
        }
    }
}
