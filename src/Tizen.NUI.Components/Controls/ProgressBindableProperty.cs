using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Progress
    {
        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = null;
        internal static void SetInternalMaxValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.SetInternalMaxValue((float)newValue);
            }
        }
        internal static object GetInternalMaxValueProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.GetInternalMaxValue();
        }

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = null;
        internal static void SetInternalMinValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.SetInternalMinValue((float)newValue);
            }
        }
        internal static object GetInternalMinValueProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.GetInternalMinValue();
        }

        /// <summary>
        /// CurrentValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = null;
        internal static void SetInternalCurrentValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.SetInternalCurrentValue((float)newValue);
            }
        }
        internal static object GetInternalCurrentValueProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.GetInternalCurrentValue();
        }

        /// <summary>
        /// BufferValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferValueProperty = null;
        internal static void SetInternalBufferValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.SetInternalBufferValue((float)newValue);
            }
        }
        internal static object GetInternalBufferValueProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.GetInternalBufferValue();
        }

        /// <summary>
        /// ProgressStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressStateProperty = null;
        internal static void SetInternalProgressStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.SetInternalProgressState((ProgressStatusType)newValue);
            }
        }
        internal static object GetInternalProgressStateProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.GetInternalProgressState();
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
                var instance = (Progress)bindable;
                instance.InternalTrackImageURL = newValue as string;
            }
        }
        internal static object GetInternalTrackImageURLProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalTrackImageURL;
        }

        /// <summary>
        /// ProgressImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressImageURLProperty = null;
        internal static void SetInternalProgressImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.InternalProgressImageURL = newValue as string;
            }
        }
        internal static object GetInternalProgressImageURLProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalProgressImageURL;
        }

        /// <summary>
        /// BufferImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferImageURLProperty = null;
        internal static void SetInternalBufferImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.InternalBufferImageURL = newValue as string;
            }
        }
        internal static object GetInternalBufferImageURLProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalBufferImageURL;
        }

        /// <summary>
        /// IndeterminateImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndeterminateImageUrlProperty = null;
        internal static void SetInternalIndeterminateImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.InternalIndeterminateImageUrl = newValue as string;
            }
        }
        internal static object GetInternalIndeterminateImageUrlProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalIndeterminateImageUrl;
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
                var instance = (Progress)bindable;
                instance.InternalTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalTrackColorProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalTrackColor;
        }

        /// <summary>
        /// ProgressColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressColorProperty = null;
        internal static void SetInternalProgressColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.InternalProgressColor = newValue as Color;
            }
        }
        internal static object GetInternalProgressColorProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalProgressColor;
        }

        /// <summary>
        /// BufferColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferColorProperty = null;
        internal static void SetInternalBufferColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Progress)bindable;
                instance.InternalBufferColor = newValue as Color;
            }
        }
        internal static object GetInternalBufferColorProperty(BindableObject bindable)
        {
            var instance = (Progress)bindable;
            return instance.InternalBufferColor;
        }
    }
}
