using System;
using System.Globalization;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.TypeTypeConverter")]
    [Xaml.TypeConversion(typeof(Type))]
    internal sealed class TypeTypeConverter : TypeConverter, IExtendedTypeConverter
    {
        [Obsolete("IExtendedTypeConverter.ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string, IServiceProvider) instead.")]
        object IExtendedTypeConverter.ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
        {
            return ((IExtendedTypeConverter)this).ConvertFromInvariantString((string)value, serviceProvider);
        }

        object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            return typeResolver.Resolve(value, serviceProvider);
        }

        public override object ConvertFromInvariantString(string value)
        {
            throw new NotImplementedException();
        }
    }
}
