using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class DynamicResourceExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [ContentProperty("Key")]
    public sealed class DynamicResourceExtension : IMarkupExtension<DynamicResource>
    {
        /// <summary>
        /// Attribute Key.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Key { get; set; }

        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return ((IMarkupExtension<DynamicResource>)this).ProvideValue(serviceProvider);
        }

        DynamicResource IMarkupExtension<DynamicResource>.ProvideValue(IServiceProvider serviceProvider)
        {
            if (Key == null)
            {
                var lineInfoProvider = serviceProvider.GetService(typeof (IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                var lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException("DynamicResource markup require a Key", lineInfo);
            }
            return new DynamicResource(Key);
        }
    }
}