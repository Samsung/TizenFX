using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Slider
    {
        /// <summary>
        /// DirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(DirectionType), typeof(Slider), default(DirectionType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalDirection = (DirectionType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalDirection;
        });

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(Slider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalMinValue = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalMinValue;
        });

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(Slider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalMaxValue = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalMaxValue;
        });

        /// <summary>
        /// ThumbSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalThumbSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbSize;
        });

        /// <summary>
        /// ThumbImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageURLProperty = BindableProperty.Create(nameof(ThumbImageURL), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalThumbImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageURL;
        });

        /// <summary>
        /// ThumbImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageURLSelectorProperty = BindableProperty.Create(nameof(ThumbImageURLSelector), typeof(StringSelector), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalThumbImageURLSelector = newValue as StringSelector;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageURLSelector;
        });

        /// <summary>
        /// ThumbImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageUrlProperty = BindableProperty.Create(nameof(ThumbImageUrl), typeof(Selector<string>), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalThumbImageUrl = newValue as Tizen.NUI.BaseComponents.Selector<string>;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageUrl;
        });

        /// <summary>
        /// ThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalThumbColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbColor;
        });

        /// <summary>
        /// BgTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BgTrackColorProperty = BindableProperty.Create(nameof(BgTrackColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalBgTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalBgTrackColor;
        });

        /// <summary>
        /// SlidedTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SlidedTrackColorProperty = BindableProperty.Create(nameof(SlidedTrackColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalSlidedTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalSlidedTrackColor;
        });

        /// <summary>
        /// WarningStartValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningStartValueProperty = BindableProperty.Create(nameof(WarningStartValue), typeof(float), typeof(Slider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalWarningStartValue = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningStartValue;
        });

        /// <summary>
        /// WarningTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningTrackColorProperty = BindableProperty.Create(nameof(WarningTrackColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalWarningTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningTrackColor;
        });

        /// <summary>
        /// WarningSlidedTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningSlidedTrackColorProperty = BindableProperty.Create(nameof(WarningSlidedTrackColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalWarningSlidedTrackColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningSlidedTrackColor;
        });

        /// <summary>
        /// WarningThumbImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningThumbImageUrlProperty = BindableProperty.Create(nameof(WarningThumbImageUrl), typeof(Tizen.NUI.BaseComponents.Selector<string>), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalWarningThumbImageUrl = newValue as Tizen.NUI.BaseComponents.Selector<string>;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningThumbImageUrl;
        });

        /// <summary>
        /// WarningThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningThumbColorProperty = BindableProperty.Create(nameof(WarningThumbColor), typeof(Color), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalWarningThumbColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningThumbColor;
        });

        /// <summary>
        /// LowIndicatorImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorImageURLProperty = BindableProperty.Create(nameof(LowIndicatorImageURL), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalLowIndicatorImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorImageURL;
        });

        /// <summary>
        /// HighIndicatorImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorImageURLProperty = BindableProperty.Create(nameof(HighIndicatorImageURL), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalHighIndicatorImageURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorImageURL;
        });

        /// <summary>
        /// LowIndicatorTextContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorTextContentProperty = BindableProperty.Create(nameof(LowIndicatorTextContent), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalLowIndicatorTextContent = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorTextContent;
        });

        /// <summary>
        /// HighIndicatorTextContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorTextContentProperty = BindableProperty.Create(nameof(HighIndicatorTextContent), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalHighIndicatorTextContent = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorTextContent;
        });

        /// <summary>
        /// LowIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorSizeProperty = BindableProperty.Create(nameof(LowIndicatorSize), typeof(Size), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalLowIndicatorSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorSize;
        });

        /// <summary>
        /// HighIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorSizeProperty = BindableProperty.Create(nameof(HighIndicatorSize), typeof(Size), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalHighIndicatorSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorSize;
        });

        /// <summary>
        /// ValueIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorSizeProperty = BindableProperty.Create(nameof(ValueIndicatorSize), typeof(Size), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalValueIndicatorSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalValueIndicatorSize;
        });

        /// <summary>
        /// ValueIndicatorUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorUrlProperty = BindableProperty.Create(nameof(ValueIndicatorUrl), typeof(string), typeof(Slider), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalValueIndicatorUrl = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalValueIndicatorUrl;
        });

        /// <summary>
        /// IsDiscreteProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsDiscreteProperty = BindableProperty.Create(nameof(IsDiscrete), typeof(bool), typeof(Slider), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalIsDiscrete = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalIsDiscrete;
        });

        /// <summary>
        /// DiscreteValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DiscreteValueProperty = BindableProperty.Create(nameof(DiscreteValue), typeof(float), typeof(Slider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.InternalDiscreteValue = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.InternalDiscreteValue;
        });

    }
}
