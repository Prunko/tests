using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ht14
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) // Додай [FromRoute]
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null) return NotFound();

            // Тимчасово поверни анонімний об'єкт, щоб перевірити, чи не в Order проблема
            return Ok(new { order.Id, order.Name });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);
            //return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDto dto)
        {
            // Явне вказання [FromRoute] та [FromBody] знімає конфлікт метаданих
            var updated = await _orderService.UpdateOrderAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) // Додано [FromRoute]
        {
            var deleted = await _orderService.DeleteOrderAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
