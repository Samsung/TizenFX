using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class ScrollBar
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DirectionProperty = null;
        internal static void SetInternalDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
                instance.SetInternalDirection((DirectionType)newValue);
            }
        }
        internal static object GetInternalDirectionProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.GetInternalDirection();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = null;
        internal static void SetInternalMaxValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
                instance.SetInternalMaxValue((int)newValue);
            }
        }
        internal static object GetInternalMaxValueProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.GetInternalMaxValue();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = null;
        internal static void SetInternalMinValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
                instance.SetInternalMinValue((int)newValue);
            }
        }
        internal static object GetInternalMinValueProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.GetInternalMinValue();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = null;
        internal static void SetInternalCurrentValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
                instance.SetInternalCurrentValue((int)newValue);
            }
        }
        internal static object GetInternalCurrentValueProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.GetInternalCurrentValue();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DurationProperty = null;
        internal static void SetInternalDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
                instance.SetInternalDuration((uint)newValue);
            }
        }
        internal static object GetInternalDurationProperty(BindableObject bindable)
        {
            var instance = (ScrollBar)bindable;
            return instance.GetInternalDuration();
        }

        /// <summary>
        /// ThumbSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = null;
        internal static void SetInternalThumbSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
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
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
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
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
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
            if (newValue != null)
            {
                var instance = (ScrollBar)bindable;
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
