using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using Xamarin.Forms;
using XamarinTemplate.Client.Services;
using XamarinTemplate.Client.Views;

namespace XamarinTemplate.Client.ViewModels
{
  public class LoadingViewModel : ViewModelBase
  {
    private IDialogService _dialogService;
    private bool _hasFailure;
    private bool _isLoading;
    private ILogService _log;
    private string _statusLabel;

    public LoadingViewModel(INavigationService nav, ILogService logService, IDialogService dialogService)
      : base(nav)
    {
      _log = logService;
      _dialogService = dialogService;
      HasFailure = false;
    }

    public DelegateCommand CmdLoadAnyways => new DelegateCommand(OnLoadAnywaysAsync);

    public bool HasFailure
    {
      get => _hasFailure;
      private set => SetProperty(ref _hasFailure, value);
    }

    public bool IsLoading
    {
      get => _isLoading;
      private set => SetProperty(ref _isLoading, value);
    }

    public string StatusLabel
    {
      get => _statusLabel;
      private set => SetProperty(ref _statusLabel, value);
    }

    public override void Initialize(INavigationParameters parameters)
    {
      base.Initialize(parameters);
      Task.Run(LoadAppAsync);
    }

    private async Task LoadAppAsync()
    {
      string errMsg = string.Empty;
      try
      {
        IsLoading = true;

        StatusLabel = "Loading theme..";
        await Task.Delay(500);

        StatusLabel = "Loading language..";
        await Task.Delay(500);

        StatusLabel = "Syncing with cloud..";
        await Task.Delay(500);

        StatusLabel = "Wasting your time..";
        await Task.Delay(1000);

        var nextPage = $"{nameof(NavigationPage)}/{nameof(MainView)}";
        // var nextPage = $"{nameof(App):///{nameof(MasterDetailView)}/{nameof(NavigationPage)}/{nameof(DashboardView)}";

        await Device.InvokeOnMainThreadAsync(async () => await NavigationService.NavigateAsync(nextPage));
      }
      catch (Exception ex)
      {
        HasFailure = true;
        errMsg = ex.Message;
        _log.Error(errMsg);
      }
      finally
      {
        IsLoading = false;

        if (!string.IsNullOrEmpty(errMsg))
        {
          _dialogService.ShowDialog(errMsg, new DialogParameters
          {
            { "title", "Error" },
            { "message", errMsg }
          });
        }
      }
    }

    private async void OnLoadAnywaysAsync()
    {
      var nextPage = $"{nameof(NavigationPage)}/{nameof(MainView)}";
      // var nextPage = $"{nameof(App):///{nameof(MasterDetailView)}/{nameof(NavigationPage)}/{nameof(DashboardView)}";

      await NavigationService.NavigateAsync(nextPage);
    }
  }
}