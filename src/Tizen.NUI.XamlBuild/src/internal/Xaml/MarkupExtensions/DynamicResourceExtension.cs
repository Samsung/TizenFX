using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.EXaml;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Key")]
    internal sealed class DynamicResourceExtension : IMarkupExtension<DynamicResource>
    {
        public string Key { get; set; }

        public object ProvideValue()
        {
            if (null == Key)
            {
                return null;
            }
            else
            {
                return new DynamicResource(Key);
            }
        }

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