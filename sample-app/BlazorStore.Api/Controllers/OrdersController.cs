using BlazorStore.Api.Contracts;
using BlazorStore.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IDbContextFactory<BlazorStoreDbContext> _dbContextFactory;

    public OrdersController(ILogger<OrdersController> logger, IDbContextFactory<BlazorStoreDbContext> dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    [HttpPost]
    public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        // Map from Contract -> Entity
        var orderEntity = MapToOrderEntity(order);

        foreach (var item in order.OrderItems)
        {
            orderEntity.OrderItems.Add(MapToOrderItemEntity(item));
        }

        await context.AddAsync(orderEntity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private Data.Models.Order MapToOrderEntity(Order order)
        => new Data.Models.Order()
        {
            Customer = MapToCustomerEntity(order.Customer),
            BillingAddress = MapToAddressEntity(order.BillingAddress),
            ShippingAddress = MapToAddressEntity(order.ShippingAddress),
            ShippingMethod = order.ShippingMethod,
            ShippingPrice = order.ShippingPrice,
            ShippingTax = order.ShippingTax
        };

    private Data.Models.OrderItem MapToOrderItemEntity(OrderItem orderItem)
        => new Data.Models.OrderItem()
        {
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            Tax = orderItem.Tax
        };

    private Data.Models.Customer MapToCustomerEntity(Customer customer)
        => new Data.Models.Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            EmailAddress = customer.EmailAddress
        };

    private Data.Models.Address MapToAddressEntity(Address address)
        => new Data.Models.Address()
        {
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode
        };
}