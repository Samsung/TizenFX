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
        public static readonly BindableProperty SwitchBackgroundImageURLSelectorProperty = null;
        internal static void SetInternalSwitchBackgroundImageURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchBackgroundImageURLSelector = newValue as StringSelector;
            }
        }
        internal static object GetInternalSwitchBackgroundImageURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchBackgroundImageURLSelector;
        }

        /// <summary>
        /// SwitchHandlerImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLProperty = null;
        internal static void SetInternalSwitchHandlerImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageURL = newValue as string;
            }
        }
        internal static object GetInternalSwitchHandlerImageURLProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURL;
        }

        /// <summary>
        /// SwitchHandlerImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLSelectorProperty = null;
        internal static void SetInternalSwitchHandlerImageURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageURLSelector = newValue as StringSelector;
            }
        }
        internal static object GetInternalSwitchHandlerImageURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURLSelector;
        }

        /// <summary>
        /// SwitchHandlerImageSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageSizeProperty = null;
        internal static void SetInternalSwitchHandlerImageSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageSize = newValue as Size;
            }
        }
        internal static object GetInternalSwitchHandlerImageSizeProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageSize;
        }
    }
}
