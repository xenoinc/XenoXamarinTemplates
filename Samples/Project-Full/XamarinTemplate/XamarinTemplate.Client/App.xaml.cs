using System;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTemplate.Client.Services;
using XamarinTemplate.Client.ViewModels;
using XamarinTemplate.Client.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamarinTemplate.Client
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

      var nav = await NavigationService.NavigateAsync($"{nameof(LoadingView)}");
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
      containerRegistry.RegisterSingleton<ILogService, LogService>();

      // Navigation
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
      containerRegistry.RegisterForNavigation<LoadingView, LoadingViewModel>();
    }
  }
}