using System;
using System.Globalization;
using System.ComponentModel;

namespace Tizen.NUI.XamlBinding
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IValueConverter
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
