using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace XamarinTemplate.Droid
{
  [Activity(
    Label = "XamarinTemplate",
    Icon = "@mipmap/ic_launcher",
    Theme = "@style/Theme.Splash",
    MainLauncher = true,
    NoHistory = true,
    /// LaunchMode = LaunchMode.SingleTask
    ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation)]
  public class SplashScreen : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // --------------------------------------------
      // Remove the items below when using OnResume()
      // --------------------------------------------

      InvokeMainActivity();
      Finish();

      // Disable activity slide-in animation
      OverridePendingTransition(0, 0);
    }

    ////// Launches the startup task
    ////protected override void OnResume()
    ////{
    ////  try
    ////  {
    ////    base.OnResume();
    ////
    ////    var mainIntent = new Intent(Application.Context, typeof(MainActivity));
    ////
    ////    if (Intent.Extras != null)
    ////      mainIntent.PutExtras(Intent.Extras);
    ////
    ////    StartActivity(mainIntent);
    ////  }
    ////  catch (Exception ex)
    ////  {
    ////  }
    ////}

    private void InvokeMainActivity()
    {
      //StartActivity(typeof(MainActivity));
      StartActivity(new Intent(this, typeof(MainActivity)));
    }
  }
}