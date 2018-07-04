using System;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    internal sealed class TemplateBindingExtension : IMarkupExtension<BindingBase>
    {
        internal TemplateBindingExtension()
        {
            Mode = BindingMode.Default;
            Path = Tizen.NUI.Binding.Binding.SelfPath;
        }

        public string Path { get; set; }

        public BindingMode Mode { get; set; }

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public string StringFormat { get; set; }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return new TemplateBinding(Path, Mode, Converter, ConverterParameter, StringFormat);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }
    }
}