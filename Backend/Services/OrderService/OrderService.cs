using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Azure;

namespace Backend.Services.OrderService
{
  public class OrderService : IOrderService
  {
    private readonly BackendContext _context;

    public OrderService(BackendContext context)
    {
      _context = context;
    }
    public IEnumerable<Order> GetOrders()
    {
      return _context.Orders.ToList();

    }
    public IEnumerable<Order> GetOrdersFromClient(int client_id)
    {
       var orders =  _context.Orders.Where(x => x.ClientId == client_id).ToList();
      return orders;
    }
    public IEnumerable<Order> GetOrdersOfProduct(int product_id)
    {
      var orders = _context.Orders.Where(x => x.ProductId == product_id).ToList();
      return orders;
    }
    public IEnumerable<Order> PostOrder(Order Order)
    {
      _context.Orders.Add(Order);
      Product prod = _context.Products.Where(x => x.product_Id == Order.ProductId).FirstOrDefault();
      Client client = _context.Clients.Where(x => x.client_Id == Order.ClientId).FirstOrDefault();
      prod.Orders.Append(Order);
      client.Orders.Append(Order);
      _context.Update(prod);
      _context.Update(client);
      _context.SaveChanges();
      return _context.Orders;
    }
    public Order GetOrderById(int client_id, int product_id)
    {
      return _context.Orders.Where(x => x.ProductId == product_id && x.ClientId == client_id).FirstOrDefault();
    }
    public IEnumerable<Order> DeleteOrder(int client_id, int product_id)
    {
      Order order = GetOrderById(client_id, product_id);
      Product prod = _context.Products.Where(x => x.product_Id == order.ProductId).FirstOrDefault();
      Client client = _context.Clients.Where(x => x.client_Id == order.ClientId).FirstOrDefault();
      prod.Orders.Remove(order);
      client.Orders.Remove(order);
      _context.Orders.Remove(order);
      _context.Update(prod);
      _context.Update(client);
      _context.SaveChanges();
      return _context.Orders;
    }

  }
}
