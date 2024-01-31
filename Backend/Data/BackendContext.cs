using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Backend.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Backend.Data
{
  public class BackendContext :IdentityDbContext
  {
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Seller_Account> Seller_Accounts { get; set; }
    public DbSet<Client_Account> Client_Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
      modelBuilder.Entity<IdentityUserRole<string>>().HasKey((c => new { c.UserId, c.RoleId }));
      modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
      
      modelBuilder.Entity<Client>()
        .HasKey(c => c.client_Id);
      modelBuilder.Entity<Product>()
        .HasKey(p => p.product_Id);
      modelBuilder.Entity<Seller>()
        .HasKey(s => s.seller_Id);
      modelBuilder.Entity<Seller_Account>()
        .HasKey(a => a.seller_account_Id);
      modelBuilder.Entity<Client_Account>()
        .HasKey(a => a.client_account_Id);

      modelBuilder.Entity<Order>()
        .HasKey(c => new { c.ProductId, c.ClientId });

      modelBuilder.Entity<Client>()
          .HasOne(e => e.Account)
      .WithOne(e => e.Client)
          .HasForeignKey<Client_Account>(e => e.client_account_Id)
          .IsRequired();

       modelBuilder.Entity<Seller>()
          .HasOne(e => e.Account)
      .WithOne(e => e.Seller)
          .HasForeignKey<Seller_Account>(e => e.seller_account_Id)
      .IsRequired();

      modelBuilder.Entity<Product>()
            .HasOne(c => c.Seller)
            .WithMany(p => p.products)
            .HasForeignKey(c => c.sellerId);
    }




    public BackendContext(DbContextOptions options) : base(options) { }




    public DbSet<Order>? Orders { get; set; }
  }
}
