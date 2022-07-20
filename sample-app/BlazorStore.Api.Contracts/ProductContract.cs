namespace BlazorStore.Api.Contracts;

public class ProductContract
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public string ImageUrl { get; set; } = null!;
}
