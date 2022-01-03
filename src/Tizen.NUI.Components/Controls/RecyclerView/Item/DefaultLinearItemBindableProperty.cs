using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultLinearItem
    {
        /// <summary>
        /// IconProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(View), typeof(DefaultLinearItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalIcon = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalIcon;
        });

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DefaultLinearItem), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalText;
        });

        /// <summary>
        /// SubTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubTextProperty = BindableProperty.Create(nameof(SubText), typeof(string), typeof(DefaultLinearItem), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalSubText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalSubText;
        });

        /// <summary>
        /// ExtraProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExtraProperty = BindableProperty.Create(nameof(Extra), typeof(View), typeof(DefaultLinearItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalExtra = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalExtra;
        });
    }
}
