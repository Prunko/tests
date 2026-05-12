using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ht14
{
    public class OrderService : IOrderService
    {
        private static readonly List<Order> _orders = new List<Order>();
        private static int _nextId = 1;

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await Task.FromResult(_orders.AsEnumerable());
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(order);
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            var newOrder = new Order
            {
                Id = _nextId++,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price,
                CustomerEmail = dto.CustomerEmail,
            };

            _orders.Add(newOrder);

            return await Task.FromResult(newOrder);
        }

        public async Task<bool> UpdateOrderAsync(int id, UpdateOrderDto dto)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == id);

            if (existingOrder == null)
                return await Task.FromResult(false);

            existingOrder.Name = dto.Name;
            existingOrder.Quantity = dto.Quantity;
            existingOrder.Price = dto.Price;
            existingOrder.CustomerEmail = dto.CustomerEmail;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                return await Task.FromResult(false);

            _orders.Remove(order);
            return await Task.FromResult(true);
        }
    }
}