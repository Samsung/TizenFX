using System;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class BindingExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    public sealed class BindingExtension : IMarkupExtension<BindingBase>
    {
        /// <summary>
        /// Attribute Path.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
		public string Path { get; set; } = Binding.Binding.SelfPath;

        /// <summary>
        /// Attribute Mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
		public BindingMode Mode { get; set; } = BindingMode.Default;

        /// <summary>
        /// Attribute Converter.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public IValueConverter Converter { get; set; }

        /// <summary>
        /// Attribute Converterparameter.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object ConverterParameter { get; set; }

        /// <summary>
        /// Attribute StringFormat.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string StringFormat { get; set; }

        /// <summary>
        /// Attribute Source.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object Source { get; set; }

        /// <summary>
        /// Attribute UpdateSourceEventName.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string UpdateSourceEventName { get; set; }

        /// <summary>
        /// Attribute TargetNullValue.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object TargetNullValue { get; set; }

        /// <summary>
        /// Attribute FallbackValue.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object FallbackValue { get; set; }

        /// <summary>
        /// Attribute TypedBinding.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
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