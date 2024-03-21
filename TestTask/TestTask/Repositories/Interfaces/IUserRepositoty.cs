using System.Linq.Expressions;
using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IUserRepositoty
    {
        public Task<User> GetUserWithMaxOrdersAsync();

        public Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> filter);
        
    }
}
