using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementations
{
    public class UserRepository : IUserRepositoty
    {
        ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<User> GetUserWithMaxOrdersAsync()
        {
            var users =  await _context.Users.Include(u => u.Orders).ToListAsync();
            var maxUser = users.Max(u => u.Orders.Count);
            var user = users.FirstOrDefault(x => x.Orders.Count == maxUser);
            return user;
        }

        public async Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> filter)
        {
            return await _context.Users.Where(filter).ToListAsync();
        }
    }
}
