using System;
using System.ComponentModel;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Key")]
    public sealed class DynamicResourceExtension : IMarkupExtension<DynamicResource>
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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