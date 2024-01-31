using Backend.Models;

namespace Backend.Services.SellerService
{
  public interface ISellerService
  {
    IEnumerable<Seller> GetSellers();
    Seller GetSeller(int id);
    IEnumerable<Seller> PostSeller(Seller seller);
    Seller PutSeller(int id, Seller seller);
    IEnumerable<Seller> DeleteSeller(int id);

  }
}
