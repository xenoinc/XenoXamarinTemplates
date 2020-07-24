using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XamarinTemplate.Client.ViewModels
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
