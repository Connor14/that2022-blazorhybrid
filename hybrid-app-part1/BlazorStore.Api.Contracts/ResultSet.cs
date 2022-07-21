namespace BlazorStore.Api.Contracts;

public class ResultSet<T>
{
    public List<T> Items { get; }
    public int TotalCount { get; }

    public ResultSet(List<T> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }
}
