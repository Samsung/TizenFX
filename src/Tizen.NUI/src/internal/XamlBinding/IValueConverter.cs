using System;
using System.Globalization;

namespace Tizen.NUI.Binding
{
    internal interface IValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}