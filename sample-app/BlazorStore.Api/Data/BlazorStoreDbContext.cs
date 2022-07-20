using Microsoft.EntityFrameworkCore;

namespace BlazorStore.Api.Data;

public class BlazorStoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;

    public BlazorStoreDbContext(DbContextOptions options) : base(options)
    {

    }
}
