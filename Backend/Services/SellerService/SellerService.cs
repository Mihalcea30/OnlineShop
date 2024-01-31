using Backend.Data;
using Backend.Models;

namespace Backend.Services.SellerService
{
  public class SellerService : ISellerService
  {
    private readonly BackendContext _context;

    public SellerService(BackendContext context)
    {
      _context = context;
    }
    public IEnumerable<Seller> GetSellers()
    {
      return _context.Sellers.ToList();
    }
    public Seller GetSeller(int id)
    {
      Seller seller = _context.Sellers.Where(x => x.seller_Id == id).FirstOrDefault() ?? null;

      return seller;
    }
    public IEnumerable<Seller> PostSeller(Seller seller)
    {
      _context.Sellers.Add(seller);
      _context.SaveChanges();
      if (seller == null) { return null; }
      return _context.Sellers;
    }

    public Seller PutSeller(int id, Seller seller)
    {
      var y = _context.Sellers.Where(x => x.seller_Id == id).FirstOrDefault() ?? null;
      if (y != null)
      {
        y.seller_Name = seller.seller_Name;
        y.address = seller.address;
        y.Account = seller.Account;
        y.products = seller.products;
        _context.SaveChanges();
        return y;
      }

      return null;
    }
    public IEnumerable<Seller> DeleteSeller(int id)
    {
      Seller seller = _context.Sellers.Find(id);
      if (seller == null)
      {
        return null;
      }
      _context.Sellers.Remove(seller);
      _context.SaveChanges();
      return _context.Sellers;
    }
  }

}

