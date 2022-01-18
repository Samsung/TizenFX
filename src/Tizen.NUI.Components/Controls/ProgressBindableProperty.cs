using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Progress
    {
        /// <summary>
        /// TrackImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackImageURLProperty = BindableProperty.Create(nameof(TrackImageURL), typeof(string), typeof(Progress), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalTrackImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalTrackImageURL;
        });

        /// <summary>
        /// ProgressImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressImageURLProperty = BindableProperty.Create(nameof(ProgressImageURL), typeof(string), typeof(Progress), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalProgressImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalProgressImageURL;
        });

        /// <summary>
        /// BufferImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferImageURLProperty = BindableProperty.Create(nameof(BufferImageURL), typeof(string), typeof(Progress), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalBufferImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalBufferImageURL;
        });

        /// <summary>
        /// IndeterminateImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndeterminateImageUrlProperty = BindableProperty.Create(nameof(IndeterminateImageUrl), typeof(string), typeof(Progress), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalIndeterminateImageUrl = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalIndeterminateImageUrl;
        });

        /// <summary>
        /// TrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(Progress), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalTrackColor;
        });

        /// <summary>
        /// ProgressColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(Progress), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalProgressColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalProgressColor;
        });

        /// <summary>
        /// BufferColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferColorProperty = BindableProperty.Create(nameof(BufferColor), typeof(Color), typeof(Progress), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.InternalBufferColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.InternalBufferColor;
        });
    }
}
