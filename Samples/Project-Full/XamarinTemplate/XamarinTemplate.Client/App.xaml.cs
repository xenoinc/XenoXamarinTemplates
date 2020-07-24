using System;
using Prism;
using Prism.Ioc;
using TemplateApp.Client.ViewModels;
using TemplateApp.Client.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TemplateApp.Client
{
  public partial class App
  {
    /*
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor.
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */

    public App() : this(null)
    {
    }

    public App(IPlatformInitializer initializer) : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      var nav = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
      if (!nav.Success)
      {
        // Log the message
        Console.WriteLine(nav.Exception.Message);
        throw new System.Exception(nav.Exception.Message);
      }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Services
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

      // Navigation
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
    }
  }
}