using BlazorStore.Client.Maui.Services;
using BlazorStore.Client.Shared.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;
using MudBlazor.Services;

namespace BlazorStore.Client.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddMudServices();
            builder.Services.AddSingleton<CartStateContainer>();
            builder.Services.AddSingleton<IStringService, StringService>();

#if ANDROID
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5278") });
#elif WINDOWS
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7278") });
#else
            throw new NotImplementedException("Please set up your HttpClient BaseAddress for iOS or MacOS");
#endif

            return builder.Build();
        }
    }
}