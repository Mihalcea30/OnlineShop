namespace Backend.Models
{
  public class Order
  {
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public Client? Client { get; set; }
    public Product? Product { get; set; } 
  }
}
