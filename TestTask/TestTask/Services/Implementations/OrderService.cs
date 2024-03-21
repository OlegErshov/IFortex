using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrder()
        {
            return await  _orderRepository.GetOrderWithMaxSumAsync();
            
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetOrdersListAsync(x => x.Quantity > 10);
        }
    }
}
