using BlazorStore.Client.Shared.Services;

namespace BlazorStore.Client.Web.Services;

public class StringService : IStringService
{
    public string GetString() => "Web";
}
