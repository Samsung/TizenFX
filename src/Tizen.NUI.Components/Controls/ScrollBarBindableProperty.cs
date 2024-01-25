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
        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(ScrollBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalThumbSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalThumbSize;
        });

        /// <summary>
        /// TrackImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackImageURLProperty = BindableProperty.Create(nameof(TrackImageURL), typeof(string), typeof(ScrollBar), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalTrackImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalTrackImageURL;
        });

        /// <summary>
        /// TrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(ScrollBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalTrackColor;
        });

        /// <summary>
        /// ThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(ScrollBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.InternalThumbColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.InternalThumbColor;
        });
    }
}
