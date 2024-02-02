namespace Backend.Models
{
  public class Seller
  {
    public int seller_Id { get; set; }
    public string seller_Name { get; set; }
    public string address { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<Product> products { get; set; } = new List <Product>();

    public Seller_Account? Account { get; set; }
  }
}
