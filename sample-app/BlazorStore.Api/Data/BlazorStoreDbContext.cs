using BlazorStore.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorStore.Api.Data;

public class BlazorStoreDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public BlazorStoreDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Order>().HasOne(o => o.BillingAddress).WithMany().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Order>().HasOne(o => o.ShippingAddress).WithMany().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.OrderItems).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Product).WithMany().OnDelete(DeleteBehavior.Restrict);
    }
}
