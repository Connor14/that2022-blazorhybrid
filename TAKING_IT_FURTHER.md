# Taking it Further

The `hybrid-app-part2` solution contains a few changes from the base `hybrid-app-part1` solution to illustrate some additional possibilities. The high-level changes are listed below.

## Responsive components

* The grids within `Product.razor` and `Products.razor` were updated to have more appropriate breakpoints

## Project specific pages

* Added an `Authentication.razor` page to MAUI and Web projects.
* Updated `Main.razor`, `App.razor`, and `SharedApp.razor` to utilize an additional assembly reference
    * This change gives our MAUI and Web projects the ability to define pages

## Platform specific service

* Added a `StringService` interface to our Shared project.
* Implemented the `StringService` in the Web project
* Implemented the `StringService` via partial classes in the MAUI project
    * Each of MAUI's platforms has a different implementation of the partial class
