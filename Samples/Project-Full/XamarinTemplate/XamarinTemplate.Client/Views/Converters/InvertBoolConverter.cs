using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinTemplate.Views.Converters
{
  public class InvertBoolConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (targetType == typeof(Boolean))
      {
        return !System.Convert.ToBoolean(value);
      }

      return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (targetType == typeof(Boolean))
      {
        return !System.Convert.ToBoolean(value);
      }

      return false;
    }
  }
}