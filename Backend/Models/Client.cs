namespace Backend.Models
{
  public class Client
  {
    public int client_Id { get; set; }
    public string client_Name { get; set; }
    public string Address { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }

    public Client_Account? Account { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();


  }
}
