using System;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Path")]
    [AcceptEmptyServiceProvider]
    public sealed class BindingExtension : IMarkupExtension<BindingBase>
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Path { get; set; } = Binding.Binding.SelfPath;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingMode Mode { get; set; } = BindingMode.Default;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IValueConverter Converter { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ConverterParameter { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StringFormat { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Source { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateSourceEventName { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object TargetNullValue { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object FallbackValue { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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