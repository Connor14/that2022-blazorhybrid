namespace BlazorStore.Api.Contracts;

public class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Tax { get; set; }
}
