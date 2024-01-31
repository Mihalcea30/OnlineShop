using MessagePack;

namespace Backend.Models
{
  public class Product
  {
    public int product_Id { get; set; }
    public string product_Name { get; set; }
    public int price { get; set; }
    public int units { get; set; }

    public int sellerId { get; set; }
    public Seller? Seller  { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();


  }
}
