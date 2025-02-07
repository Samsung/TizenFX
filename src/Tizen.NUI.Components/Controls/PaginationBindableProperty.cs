using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Pagination
    {
        /// <summary>
        /// LastIndicatorImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LastIndicatorImageUrlProperty = null;
        internal static void SetInternalLastIndicatorImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalLastIndicatorImageUrl = newValue as Selector<string>;
            }
        }
        internal static object GetInternalLastIndicatorImageUrlProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalLastIndicatorImageUrl;
        }

        /// <summary>
        /// IndicatorCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorCountProperty = null;
        internal static void SetInternalIndicatorCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalIndicatorCount = (int)newValue;
            }
        }
        internal static object GetInternalIndicatorCountProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorCount;
        }

        /// <summary>
        /// IndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorColorProperty = null;
        internal static void SetInternalIndicatorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalIndicatorColor = newValue as Color;
            }
        }
        internal static object GetInternalIndicatorColorProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorColor;
        }

        /// <summary>
        /// SelectedIndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndicatorColorProperty = null;
        internal static void SetInternalSelectedIndicatorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalSelectedIndicatorColor = newValue as Color;
            }
        }
        internal static object GetInternalSelectedIndicatorColorProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndicatorColor;
        }

        /// <summary>
        /// SelectedIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndexProperty = null;
        internal static void SetInternalSelectedIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalSelectedIndex = (int)newValue;
            }
        }
        internal static object GetInternalSelectedIndexProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndex;
        }
    }
}
