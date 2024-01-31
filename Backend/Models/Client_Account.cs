namespace Backend.Models
{
  public class Client_Account
  {
    public int client_account_Id { get; set; }
    public string client_account_Username { get; set; }
    public string client_account_Password { get; set; }

    public Client Client { get; set; } = null!;
  }
}
