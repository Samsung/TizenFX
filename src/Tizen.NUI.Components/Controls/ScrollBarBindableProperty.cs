using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class ScrollBar
    {
        /// <summary>
        /// ThumbSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = null;
        internal static void SetInternalThumbSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalThumbSize = newValue as Size;
            }
        }
        internal static object GetInternalThumbSizeProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalThumbSize;
        }

        /// <summary>
        /// TrackImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackImageURLProperty = null;
        internal static void SetInternalTrackImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalTrackImageURL = newValue as string;
            }
        }
        internal static object GetInternalTrackImageURLProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalTrackImageURL;
        }

        /// <summary>
        /// TrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = null;
        internal static void SetInternalTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalTrackColorProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalTrackColor;
        }

        /// <summary>
        /// ThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = null;
        internal static void SetInternalThumbColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalThumbColor = newValue as Color;
            }
        }
        internal static object GetInternalThumbColorProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalThumbColor;
        }
    }
}
