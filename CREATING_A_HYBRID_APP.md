# Creating a Hybrid App

The `hybrid-app-part1` solution shows how I transformed the Blazor WebAssembly application from the `web-app` solution into a Blazor Hybrid application. Below are my high-level notes for that process.

## 1. Solution Setup

* Add a .NET MAUI Blazor App (BlazorStore.Client.Maui)
* Add a Razor CLass Library (BlazorStore.Client.Shared)
* BlazorStore.Client.Shared
    * Add a NuGet reference to MudBlazor
    * Add a project reference to BlazorStore.Api.Contracts
* BlazorStore.Client.Maui
    * Add a project reference to BlazorStore.Client.Shared
* BlazorStore.Client.Web
    * Add a project reference to BlazorStore.Client.Shared
    * Remove MudBlazor NuGet reference
    * Remove BlazorStore.Api.Contracts project reference

## 2. BlazorStore.Client.Shared

* Copy `Pages`, `Shared`, `Services`, `_Imports.razor`, and `App.razor` from BlazorStore.Client.Web
* Update `CartStateContainer` namespace to BlazorStore.Client.Shared.Services
* Update `_Imports`
    * Remove WebAssembly reference
    * Change BlazorStore.Client.Web references to BlazorStore.Client.Shared references

## 3. BlazorStore.Client.Web

* Remove `Pages`, `Shared`, `Services`
* Cleanup
    * `Program.cs`
    * `_Imports.razor`
* Add an import for BlazorStore.Client.Shared to `_Imports.razor`

## 4. BlazorStore.Client.Shared

* Rename `App.razor` to `SharedApp.razor`
* Update Router AppAssembly to `typeof(SharedApp)`

## 5. BlazorStore.Client.Web

* Replace `App.razor` contents with a `<SharedApp />` component

## 6. BlazorStore.Client.Maui

* Remove `Data`, `Pages`, `Shared`, `wwwroot/css`
* Copy `icon-192.png` from BlazorStore.Client.Web/wwwroot into BlazorStore.Client.Maui/wwwroot
* Update `index.html`
    * Remove css references
    * Add MudBlazor and loading image references (see BlazorStore.Client.Web/wwwroot/index.html)
* Update `MauiProgram.cs`
    * Remove invalid namespace
    * Add services (see BlazorStore.Client.Web/Program.cs)
* Update `_Imports.razor`
    * Remove invalid imports
    * Add import for BlazorStore.Client.Shared
* Replace `Main.razor` contents with a `<SharedApp />` component

## 7. Finishing up - BlazorStore.Client.Maui

* Update `MauiProgram.cs`
    * Add platform-specific HttpClient BaseAddress for Android
* Add Android network security config for cleartext HTTP to Platforms/Android/Resources/xml
* Add network security config to AndroidManifest.xml

## 8. Finishing up - BlazorStore.Api

* Update launch settings to bind to `0.0.0.0`
* Update `Program.cs` to remove HTTPS redirection
