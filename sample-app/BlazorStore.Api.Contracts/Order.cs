namespace BlazorStore.Api.Contracts;

public class Order
{
    public Customer Customer { get; set; } = null!;
    public Address BillingAddress { get; set; } = null!;
    public Address ShippingAddress { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;
    public decimal ShippingPrice { get; set; }
    public decimal ShippingTax { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
