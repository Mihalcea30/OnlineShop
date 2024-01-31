using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ProductService
{
  public class ProductService : IProductService
  {
    private readonly BackendContext _context;

    public ProductService(BackendContext context)
    {
      _context = context;
    }
    public IEnumerable<Product> GetProducts()
    {
      return _context.Products.ToList();

    }
    public IEnumerable<Product> GetProductsFromSeller(int seller_id)
    {
      var products = _context.Products.Where(x => x.sellerId ==seller_id).ToList();
      if (products == null)
        return null;
      return products;
    }
    public  IEnumerable<Product> PostProduct(Product product)
    {
      Seller owner = GetProductOwner(product);
      if (owner == null)
        return null;
      _context.Products.Add(product);
      owner.products.Add(product);
      _context.Update(owner);
      _context.SaveChanges();
      return _context.Products;
    }

   public  Seller GetProductOwner(Product product)
    {
      return _context.Sellers.Where(x => x.seller_Id == product.sellerId).FirstOrDefault();
    }
   public Product GetProductById(int id)
    {
      return _context.Products.Where(x => x.product_Id == id).FirstOrDefault();
    }
    public IEnumerable<Product> DeleteProduct(int id)
    {
      Product product = GetProductById(id);
      Seller owner = GetProductOwner(product);
      owner.products.Remove(product);
      _context.Products.Remove(product);
      _context.SaveChanges();
      return _context.Products;
    }
   
  }
}
