using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Xaml.ProvideCompiled("Tizen.NUI.XamlC.UriTypeConverter")]
    [Xaml.TypeConversion(typeof(Uri))]
    public class UriTypeConverter : TypeConverter
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return new Uri(value, UriKind.RelativeOrAbsolute);
        }

        bool CanConvert(Type type)
        {
            if (type == typeof(string))
                return true;
            if (type == typeof(Uri))
                return true;

            return false;
        }
    }
}
