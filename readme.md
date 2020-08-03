**Visual Studio Xamarin.Forms Project Template Pack** by *Xeno Innovations' DevOps*

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
* Xamarin.Essentials.Interfaces - _ViewModel friendly_

## How to - Update Template Changes
### Project
1. Open targeted solution (_basic or full_)
2. **Project** > **Export Template...**
3. Select, "_Project template_" and which project to export
4. Select Template options
  * Template Name: Keep the same
  * Description:
    * Solution: "Cross-platform solution template using Xamarin and Prism.Forms by Xeno Innovations (Xeno.Prism.Template)"
    * Client: "Xamarin.Forms client template using Prism"
    * Android: "Xamarin Android Template using Prism"
    * UWP: "Xamarin UWP Template using Prism"
  * Icon, Preview Image: *blank*
  * **Uncheck**: "_Automatically import the template..._"
  * Click, Finish
5. Copy **.ZIP** from "_My Exported Templates_" to our "Templates\XamarinTemplate.XXX" folder
6. Extract contents into the appropriate project folder

### Solution
1. Copy of a project ``.vstemplate`` modified for Solutions.
2. ``Type`` attribute, ``ProjectGroup``
3.
4. Additional tags and attributes:
```xml
<ProjectType>CSharp</ProjectType>
<ProjectSubType></ProjectSubType>
<LanguageTag>C#</LanguageTag>
<PlatformTag>Android</PlatformTag>
<PlatformTag>Windows</PlatformTag>
<ProjectTypeTag>Mobile</ProjectTypeTag>
<ProjectTypeTag>Desktop</ProjectTypeTag>
<ProjectTypeTag>Linux</ProjectTypeTag>
<ProjectTypeTag>Xamarin</ProjectTypeTag>
<ProjectTypeTag>Xeno DevOps</ProjectTypeTag>
```

## vNext Features
### Full Template
Same as the blank app plus these additional items

### Project Items
* ``.gitignore``
* ``.editorconfig``
* ``Settings.cs`` - _Xamarin.Essentials_
* i18n
* Utf8Json - Service linkage to Json serialization/deserialization
* Secretes
  * ``secrets.json``
  * ``Secrets.cs``


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
* https://docs.microsoft.com/en-us/visualstudio/ide/how-to-create-multi-project-templates?view=vs-2019
* https://docs.microsoft.com/en-us/visualstudio/ide/template-tags?view=vs-2019
