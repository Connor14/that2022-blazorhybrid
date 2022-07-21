# THAT Conf 2022 - Blazor Hybrid

This repository contains a few projects that aim to show how Blazor Hybrid can be set up and used.

The projects are not necessarily created utilizing best practices.

## web-app

This solution contains a sample Blazor WebAssembly app with an ASP.NET Core Web API backend. 

When starting the application, a database named `BlazorStoreDb` will be migrated to your `(localdb)\MSSQLLocalDB` instance. Populate the `Products` table with some entries to see data in the Blazor app.

This application does not implement any hybrid technologies.

## hybrid-app-part1

This solution contains the Blazor WebAssembly app from above with a Blazor Hybrid implementation.

A .NET MAUI Blazor App (utilizing the official template) was added to the solution. Then the common components of the Blazor WebAssembly app were migrated into a shared Razer Class Library.

More details on the process can be found in [Creating a Hybrid App](./CREATING_A_HYBRID_APP.md)

## hybrid-app-part2

This solution contains the Blazor Hybrid application from above with some example responsive UI, platform specific pages, and a platform specific service.

More details on the changes can be found in [Taking it Futher](./TAKING_IT_FURTHER.md)

## Libraries

* MudBlazor (https://mudblazor.com/)
