using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Switch
    {
        /// <summary>
        /// SwitchBackgroundImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchBackgroundImageURLSelectorProperty = BindableProperty.Create(nameof(SwitchBackgroundImageURLSelector), typeof(StringSelector), typeof(Switch), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Switch)bindable;
            if (newValue != null)
            {
                instance.InternalSwitchBackgroundImageURLSelector = newValue as StringSelector;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchBackgroundImageURLSelector;
        });

        /// <summary>
        /// SwitchHandlerImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLProperty = BindableProperty.Create(nameof(SwitchHandlerImageURL), typeof(string), typeof(Switch), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Switch)bindable;
            if (newValue != null)
            {
                instance.InternalSwitchHandlerImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURL;
        });

        /// <summary>
        /// SwitchHandlerImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLSelectorProperty = BindableProperty.Create(nameof(SwitchHandlerImageURLSelector), typeof(StringSelector), typeof(Switch), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Switch)bindable;
            if (newValue != null)
            {
                instance.InternalSwitchHandlerImageURLSelector = newValue as StringSelector;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURLSelector;
        });

        /// <summary>
        /// SwitchHandlerImageSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageSizeProperty = BindableProperty.Create(nameof(SwitchHandlerImageSize), typeof(Size), typeof(Switch), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Switch)bindable;
            if (newValue != null)
            {
                instance.InternalSwitchHandlerImageSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageSize;
        });

    }
}
