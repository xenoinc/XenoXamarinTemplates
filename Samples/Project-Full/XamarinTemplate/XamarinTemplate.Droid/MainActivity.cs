using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamarinTemplate.Droid
{
  [Activity(
    Label = "XamarinTemplate",
    Icon = "@mipmap/ic_launcher",
    Theme = "@style/MainTheme",
    MainLauncher = false,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = XamarinTemplate.Droid.Resource.Layout.Tabbar;
      ToolbarResource = XamarinTemplate.Droid.Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      // Xamarin.Forms Flags
      Xamarin.Forms.Forms.SetFlags(new string[] { "CarouselView_Experimental", "IndicatorView_Experimental" });

      // Plugins Init
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

      LoadApplication(new Client.App(new MainInitializer()));
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}