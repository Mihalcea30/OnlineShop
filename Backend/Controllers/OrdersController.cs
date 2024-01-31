using Backend.Models;
using Backend.Services.OrderService;
using Backend.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  
  [Route("api/[controller]")]
  [ApiController]
  
  public class OrdersController : ControllerBase
  {
    private IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
      _orderService = orderService;

    }
    [HttpGet, Authorize]
    public IEnumerable<Order> GetOrders()
    {
      return _orderService.GetOrders();
    }

    [HttpGet("fromClient/{client_id}")]
    public IEnumerable<Order> GetOrder_Client(int client_id)
    {
      return _orderService.GetOrdersFromClient(client_id);
    }
    [HttpGet("fromProduct/{product_id}")]
    public IEnumerable<Order> GetOrder_Product(int product_id)
    {
      return _orderService.GetOrdersOfProduct(product_id);
    }
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
      var orders = _orderService.PostOrder(order);
      if (orders == null)
        return null;
      return Ok(orders);
    }
    [HttpDelete("{client_id}, {product_id}")]
    public async Task<IActionResult> DeleteOrder(int client_id, int product_id)
    {
      var order = _orderService.DeleteOrder(client_id, product_id);
      if (order == null)
      {
        return NotFound();
      }

      return Ok(order);
    }

  }
}
