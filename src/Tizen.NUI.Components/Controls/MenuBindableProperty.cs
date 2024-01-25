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
        public static readonly BindableProperty AnchorProperty = BindableProperty.Create(nameof(Anchor), typeof(View), typeof(Menu), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Menu)bindable;
            if (newValue != null)
            {
                instance.InternalAnchor = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Menu)bindable;
            return instance.InternalAnchor;
        });

        /// <summary>
        /// HorizontalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalPositionToAnchorProperty = BindableProperty.Create(nameof(HorizontalPositionToAnchor), typeof(Tizen.NUI.Components.Menu.RelativePosition), typeof(Menu), default(RelativePosition), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Menu)bindable;
            if (newValue != null)
            {
                instance.InternalHorizontalPositionToAnchor = (RelativePosition)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Menu)bindable;
            return instance.InternalHorizontalPositionToAnchor;
        });

        /// <summary>
        /// VerticalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalPositionToAnchorProperty = BindableProperty.Create(nameof(VerticalPositionToAnchor), typeof(Tizen.NUI.Components.Menu.RelativePosition), typeof(Menu), default(RelativePosition), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Menu)bindable;
            if (newValue != null)
            {
                instance.InternalVerticalPositionToAnchor = (RelativePosition)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Menu)bindable;
            return instance.InternalVerticalPositionToAnchor;
        });
    }
}
