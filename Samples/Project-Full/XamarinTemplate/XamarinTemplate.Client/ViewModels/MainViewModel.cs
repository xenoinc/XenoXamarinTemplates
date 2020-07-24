using Prism.Navigation;

namespace TemplateApp.Client.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    public MainViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
    }
  }
}