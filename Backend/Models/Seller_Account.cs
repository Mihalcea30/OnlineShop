namespace Backend.Models
{
  public class Seller_Account
  {
    public int seller_account_Id { get; set; }
    public string seller_account_Username { get; set; }
    public string seller_account_Password { get; set; }

    public Seller Seller { get; set; } = null!;
  }
}
