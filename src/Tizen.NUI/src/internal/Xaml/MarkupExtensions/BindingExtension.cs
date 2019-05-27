using System;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    internal sealed class BindingExtension : IMarkupExtension<BindingBase>
    {
		public string Path { get; set; } = Binding.Binding.SelfPath;
		public BindingMode Mode { get; set; } = BindingMode.Default;

        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public string StringFormat { get; set; }

        public object Source { get; set; }

        public string UpdateSourceEventName { get; set; }

        public object TargetNullValue { get; set; }
        
		public object FallbackValue { get; set; }

        public TypedBindingBase TypedBinding { get; set; }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            if (TypedBinding == null)
                return new Tizen.NUI.Binding.Binding(Path, Mode, Converter, ConverterParameter, StringFormat, Source)
				{
				    UpdateSourceEventName = UpdateSourceEventName,
                    FallbackValue = FallbackValue,
                    TargetNullValue = TargetNullValue,
				};

            TypedBinding.Mode = Mode;
            TypedBinding.Converter = Converter;
            TypedBinding.ConverterParameter = ConverterParameter;
            TypedBinding.StringFormat = StringFormat;
            TypedBinding.Source = Source;
            TypedBinding.UpdateSourceEventName = UpdateSourceEventName;
            TypedBinding.FallbackValue = FallbackValue;
            TypedBinding.TargetNullValue = TargetNullValue;
            return TypedBinding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }
    }
}