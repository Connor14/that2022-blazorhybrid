using BlazorStore.Api.Contracts;
using System.Collections.ObjectModel;

namespace BlazorStore.Client.Web.Services;

public class CartStateContainer
{
    public event Action? OnChange;

    public ObservableCollection<CartEntry> Entries { get; }

    public CartStateContainer()
    {
        Entries = new ObservableCollection<CartEntry>();
        Entries.CollectionChanged += Products_CollectionChanged;
    }

    private void Products_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        OnChange?.Invoke();
    }
}

public class CartEntry
{
    public ProductContract Product { get; }
    public int Quantity { get; }
    public decimal TotalPrice => Product.UnitPrice * Quantity;

    public CartEntry(int quantity, ProductContract product)
    {
        Quantity = quantity;
        Product = product;
    }
}
