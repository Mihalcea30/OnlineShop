using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ClientService
{
  public class ClientService : IClientService
  {
    private readonly BackendContext _context;

    public ClientService(BackendContext context)
    {
      _context = context;
    }
    public IEnumerable<Client> DeleteClient(int id)
    {
      Client client = _context.Clients.Find(id);
      if (client == null)
      {
        return null;
      }
      _context.Clients.Remove(client);
      _context.SaveChanges();
      return _context.Clients;
    }

    public Client GetClient(int id)
    {
      Client client = _context.Clients.Where(x => x.client_Id == id).FirstOrDefault() ?? null;

      return client;
    }

    public IEnumerable<Client> GetClients()
    {
      return _context.Clients.ToList();
    }

    public IEnumerable<Client> PostClient(Client client)
    {
      _context.Clients.Add(client);
      _context.SaveChanges();
      if (client == null) { return null; }
      return _context.Clients;
    }

    public Client PutClient(int id, Client client)
    {
      var y = _context.Clients.Where(x => x.client_Id == id).FirstOrDefault() ?? null;
      if (y != null)
      {
        y.client_Name = client.client_Name;
        y.Address = client.Address;
        y.Orders = client.Orders;
        y.Account = client.Account;
        _context.SaveChanges();
        return y;
      }

      

      return null;
    }
  }
}
