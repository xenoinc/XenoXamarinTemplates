# XenoDevOps - Xamarin.Forms Template

**Visual Studio Xamarin.Forms Project Template Pack** by *Xeno Innovations' DevOps team*

This template pack creates a new [Xamarin.Forms]() project using [Prism.Forms](https://github.com/PrismLibrary/Prism) with DryIoc and basic services right out of the box for you.

This project is freely available for the community to help maintain and suggest alterations. When [System.Maui]() becomes more stable, we'll have a template warmed up for it.


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
* [Prism.Forms](https://github.com/PrismLibrary/Prism) w/ DryIOC
* Xamarin.Essentials.Interfaces - _ViewModel friendly_

## Roadmap
| Name | Stage |
|------|-------|
| Xeno Template Pack in VS Gallery | ***Backlog*** |
| New Project Wizard | ***TBD*** |
| MSBuild command | ***Backlog*** |
| System.Maui Support | ***TBD*** |

## How to - Update Template Changes
Please note, at this time you cannot include custom files in the Solution template such as ``.gitignore`` or ``.editorconfig``. At least, have not found a way yet.

### Creating a Project Template
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

### Creating a Solution Template
When creating a solution template from scratch, perform the following actions

1. Copy of a project ``.vstemplate`` modified for Solutions.
2. ``Type`` attribute, ``ProjectGroup``
3. Additional tags and attributes:
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

### Bundling and Installing
1. Create a .ZIP containing the following items. The solution ``.vstemplate`` should be in the root of the ZIP, not a subfolder.
  * XamarinTemplate.Client
  * XamarinTemplate.Droid
  * XamarinTemplate.UWP
  * XenoMobileBasicSolution.vstemplate
2. Copy .ZIP to ``%USERPROFILE%\Documents\Visual Studio 2019\Templates\ProjectTemplates\Visual C#\``

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


## vNext - Installation
**Status:** *PROPOSAL*
**Purpose:** Installs template
```
dotnet new -i "XenoXamarinTemplate"
```

## Creating a Project
**Status:** *PROPOSAL*
```
dotnet new XenoMobile -n "My.Project"
```

## Syncing up
**Status:** *PROPOSAL*
**Purpose:** Sync up ``EditorConfig`` and other coding standards files found in the project with the latest standard from XenoDevOps.
```
DevOps -sync
```

## References
* https://docs.microsoft.com/en-us/visualstudio/ide/how-to-create-project-templates?view=vs-2019
* https://docs.microsoft.com/en-us/visualstudio/ide/how-to-create-multi-project-templates?view=vs-2019
* https://docs.microsoft.com/en-us/visualstudio/ide/template-tags?view=vs-2019
* Templates
  * [Prism.Templates](https://github.com/PrismLibrary/Prism.Templates)
  * [Prism.Forms.QuickstartTemplates](https://dotnetnew.azurewebsites.net/template/Prism.Forms.QuickstartTemplates/PrismLibrary.Xamarin.Forms.QuickStart.CSharp)
  * [CLI Templates](https://docs.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template#:~:text=In%20your%20terminal%2C%20navigate%20to,to%20create%20a%20new%20template.)
  * [Available Templates](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
  * [Sample - Multi-Project](https://github.com/dotnet/dotnet-template-samples/tree/master/05-multi-project/.template.config)


