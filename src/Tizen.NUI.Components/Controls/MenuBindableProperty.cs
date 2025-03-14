using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Menu
    {
        /// <summary>
        /// AnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorProperty = null;
        internal static void SetInternalAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalAnchor = newValue as View;
            }
        }
        internal static object GetInternalAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalAnchor;
        }

        /// <summary>
        /// HorizontalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalPositionToAnchorProperty = null;
        internal static void SetInternalHorizontalPositionToAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalHorizontalPositionToAnchor = (RelativePosition)newValue;
            }
        }
        internal static object GetInternalHorizontalPositionToAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalHorizontalPositionToAnchor;
        }

        /// <summary>
        /// VerticalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalPositionToAnchorProperty = null;
        internal static void SetInternalVerticalPositionToAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalVerticalPositionToAnchor = (RelativePosition)newValue;
            }
        }
        internal static object GetInternalVerticalPositionToAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalVerticalPositionToAnchor;
        }
    }
}
