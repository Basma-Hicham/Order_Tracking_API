using Microsoft.AspNetCore.Mvc;
using OrderTrackingApi.Models;
using OrderTrackingApi.Services;

namespace OrderTrackingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        // Simulating a logged-in user (replace with real auth later)
        private string CurrentUsername => "testuser";

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // POST /api/orders
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order.Items == null || !order.Items.Any())
                return BadRequest(new { message = "Order must have at least one item." });

            if (order.Items.Any(item => item.Quantity <= 0 || item.Price < 0))
                return BadRequest(new { message = "Each item must have valid quantity and price." });

            order.Username = CurrentUsername;
            var createdOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }

        // GET /api/orders
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetOrdersByUsername(CurrentUsername);
            return Ok(orders);
        }

        // GET /api/orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id, CurrentUsername);
            if (order == null)
                return NotFound(new { message = $"Order with ID {id} not found." });

            return Ok(order);
        }
    }
}

