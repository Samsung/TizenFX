using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class ScrollableBase
    {
        /// <summary>
        /// ScrollingDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingDirectionProperty = BindableProperty.Create(nameof(ScrollingDirection), typeof(Direction), typeof(ScrollableBase), default(Direction), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollingDirection = (Direction)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollingDirection;
        });

        /// <summary>
        /// ScrollEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollEnabledProperty = BindableProperty.Create(nameof(ScrollEnabled), typeof(bool), typeof(ScrollableBase), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollEnabled;
        });

        /// <summary>
        /// SnapToPageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SnapToPageProperty = BindableProperty.Create(nameof(SnapToPage), typeof(bool), typeof(ScrollableBase), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalSnapToPage = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalSnapToPage;
        });

        /// <summary>
        /// ScrollDurationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDurationProperty = BindableProperty.Create(nameof(ScrollDuration), typeof(int), typeof(ScrollableBase), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollDuration = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollDuration;
        });

        /// <summary>
        /// ScrollAvailableAreaProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollAvailableAreaProperty = BindableProperty.Create(nameof(ScrollAvailableArea), typeof(Vector2), typeof(ScrollableBase), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollAvailableArea = newValue as Vector2;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollAvailableArea;
        });

        /// <summary>
        /// ScrollbarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollbarProperty = BindableProperty.Create(nameof(Scrollbar), typeof(ScrollbarBase), typeof(ScrollableBase), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollbar = newValue as ScrollbarBase;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollbar;
        });

        /// <summary>
        /// HideScrollbarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HideScrollbarProperty = BindableProperty.Create(nameof(HideScrollbar), typeof(bool), typeof(ScrollableBase), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalHideScrollbar = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalHideScrollbar;
        });

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(LayoutItem), typeof(ScrollableBase), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = newValue as LayoutItem;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalLayout;
        });

        /// <summary>
        /// DecelerationRateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecelerationRateProperty = BindableProperty.Create(nameof(DecelerationRate), typeof(float), typeof(ScrollableBase), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalDecelerationRate = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalDecelerationRate;
        });

        /// <summary>
        /// DecelerationThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecelerationThresholdProperty = BindableProperty.Create(nameof(DecelerationThreshold), typeof(float), typeof(ScrollableBase), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalDecelerationThreshold = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalDecelerationThreshold;
        });

        /// <summary>
        /// ScrollingEventThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingEventThresholdProperty = BindableProperty.Create(nameof(ScrollingEventThreshold), typeof(float), typeof(ScrollableBase), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollingEventThreshold = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollingEventThreshold;
        });

        /// <summary>
        /// PageFlickThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PageFlickThresholdProperty = BindableProperty.Create(nameof(PageFlickThreshold), typeof(float), typeof(ScrollableBase), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalPageFlickThreshold = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalPageFlickThreshold;
        });

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(ScrollableBase), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalPadding = newValue as Extents;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalPadding;
        });

        /// <summary>
        /// ScrollAlphaFunctionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollAlphaFunctionProperty = BindableProperty.Create(nameof(ScrollAlphaFunction), typeof(AlphaFunction), typeof(ScrollableBase), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalScrollAlphaFunction = newValue as AlphaFunction;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollAlphaFunction;
        });

        /// <summary>
        /// NoticeAnimationEndBeforePositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NoticeAnimationEndBeforePositionProperty = BindableProperty.Create(nameof(NoticeAnimationEndBeforePosition), typeof(float), typeof(ScrollableBase), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalNoticeAnimationEndBeforePosition = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalNoticeAnimationEndBeforePosition;
        });

        /// <summary>
        /// EnableOverShootingEffectProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableOverShootingEffectProperty = BindableProperty.Create(nameof(EnableOverShootingEffect), typeof(bool), typeof(ScrollableBase), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollableBase)bindable;
            if (newValue != null)
            {
                instance.InternalEnableOverShootingEffect = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalEnableOverShootingEffect;
        });
    }
}
