using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultGridItem
    {
        /// <summary>
        /// BadgeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BadgeProperty = null;
        internal static void SetInternalBadgeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultGridItem)bindable;
                instance.InternalBadge = newValue as View;
            }
        }
        internal static object GetInternalBadgeProperty(BindableObject bindable)
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalBadge;
        }

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultGridItem)bindable;
                instance.InternalText = newValue as string;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalText;
        }

        /// <summary>
        /// ResourceUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = null;
        internal static void SetInternalResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultGridItem)bindable;
                instance.InternalResourceUrl = newValue as string;
            }
        }
        internal static object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalResourceUrl;
        }

        /// <summary>
        /// LabelOrientationTypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelOrientationTypeProperty = null;
        internal static void SetInternalLabelOrientationTypeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultGridItem)bindable;
                instance.InternalLabelOrientationType = (LabelOrientation)newValue;
            }
        }
        internal static object GetInternalLabelOrientationTypeProperty(BindableObject bindable)
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalLabelOrientationType;
        }
    }
}
