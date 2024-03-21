using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderWithMaxSumAsync()
        {
            var orders = _context.Orders.AsNoTracking().AsQueryable();
            var maxSum = orders.Max(o => o.Quantity * o.Price);
            orders = orders.Where(o => o.Quantity * o.Price == maxSum);
            return await orders.FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrdersListAsync(Expression<Func<Order, bool>> filter)
        {
            return await _context.Orders.Where(filter).AsNoTracking().ToListAsync();
        }
    }
}
