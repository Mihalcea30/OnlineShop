using Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Backend.Services.ProductService
{
  public interface IProductService
  {
    IEnumerable<Product> GetProducts();
    IEnumerable<Product> GetProductsFromSeller(int seller_id);

    Product GetProductById(int id);
    IEnumerable<Product> PostProduct(Product product);

    Seller GetProductOwner(Product product);
    IEnumerable<Product> DeleteProduct(int id);
  }
}
