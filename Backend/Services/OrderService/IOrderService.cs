using Backend.Models;

namespace Backend.Services.OrderService
{
  public interface IOrderService
  {
    IEnumerable<Order> GetOrders();
    IEnumerable<Order> GetOrdersFromClient(int client_id);
    IEnumerable<Order> GetOrdersOfProduct(int product_id);


    Order GetOrderById(int client_id, int product_id);
    IEnumerable<Order> PostOrder(Order Order);

    IEnumerable<Order> DeleteOrder(int client_id, int product_id);
  }
}
