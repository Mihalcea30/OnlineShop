using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.ClientService
{
  public interface IClientService
  {
    IEnumerable<Client> GetClients();
    Client GetClient(int id);
    Client PutClient(int id, Client client);

    IEnumerable<Client> PostClient(Client client);
    IEnumerable<Client> DeleteClient(int id);

    //bool ClientExists(int id);



  }
}
