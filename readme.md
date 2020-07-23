Coming soon, **Visual Studio Xamarin Project Template Pack** by *Xeno Innovations' DevOps*


# vNext Template Features

## Blank Template Features

### New Cross Platform App - {ProjectName}
* Select a template
  * Master-Detail, Tabbed, Shell, Blank
* Platform
  * Android, iOS, Windows (UWP)
* Mobile Backend (out-of-scope)
  * Include ASP.Net Core Web API project
* .Net Analyzers

### NuGets
* Prism.Forms w/ DryIOC

### Project Items
* ``.gitignore``
* ``.editorconfig``
* ``Settings.cs`` - _Xamarin.Essentials_
* i18n
* Utf8Json - Service linkage to Json serialization/deserialization
* Secretes
  * ``secrets.json``
  * ``Secrets.cs``

## Full Template Features
Same as the blank app plus these additional items

### Project Items



## Sample usage
```cs
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
// ...

  // Register as Singleton
  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

    containerRegistry.RegisterForNavigation<NavigationPage>();
    containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
  }

  // Register as default
  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.Register<IAppInfo, AppInfoImplementation>();
    containerRegistry.Register<IGeolocatorService, GeolocatorService>();
    containerRegistry.Register<IApiService, ApiService>();
    containerRegistry.Register<IFilesHelper, FilesHelper>();
    containerRegistry.Register<IRegexHelper, RegexHelper>();

    containerRegistry.RegisterForNavigation<NavigationPage>();
    containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
  }
```
## References
* https://docs.microsoft.com/en-us/visualstudio/ide/how-to-create-project-templates?view=vs-2019
