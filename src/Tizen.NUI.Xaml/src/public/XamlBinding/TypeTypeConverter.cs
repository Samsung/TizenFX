using System;
using System.ComponentModel;
using System.Globalization;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Forms.XamlC.TypeTypeConverter")]
    [Xaml.TypeConversion(typeof(Type))]
    public sealed class TypeTypeConverter : TypeConverter, IExtendedTypeConverter
    {
        [Obsolete("IExtendedTypeConverter.ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string, IServiceProvider) instead.")]
        object IExtendedTypeConverter.ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
        {
            return ((IExtendedTypeConverter)this).ConvertFromInvariantString((string)value, serviceProvider);
        }

        object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            return typeResolver.Resolve(value, serviceProvider);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            throw new NotImplementedException();
        }
    }
}
