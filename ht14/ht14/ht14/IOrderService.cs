namespace ht14
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto dto);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<bool> UpdateOrderAsync(int id, UpdateOrderDto dto);
        Task<bool> DeleteOrderAsync(int id);
    }
}
