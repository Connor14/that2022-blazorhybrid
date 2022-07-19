using BlazorStore.Api.Contracts;
using BlazorStore.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IDbContextFactory<BlazorStoreDbContext> _dbContextFactory;

    public ProductsController(ILogger<ProductsController> logger, IDbContextFactory<BlazorStoreDbContext> dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        var products = await context.Products.ToListAsync();

        return products.Select(MapToProductContract).ToList();
    }

    [HttpGet("{id}")]
    public async Task<Product?> GetProductOrDefaultAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return null;

        return MapToProductContract(product);
    }

    private Product MapToProductContract(Data.Models.Product product)
        => new Product()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            UnitPrice = product.UnitPrice,
            ImageUrl = product.ImageUrl
        };
}