using System.Linq.Expressions;
using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrderWithMaxSumAsync();

        public Task<List<Order>> GetOrdersListAsync(Expression<Func<Order, bool>> filter);
    }
}
