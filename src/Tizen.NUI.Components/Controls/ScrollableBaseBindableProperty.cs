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
        public static readonly BindableProperty ScrollingDirectionProperty = null;
        internal static void SetInternalScrollingDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollingDirection = (Direction)newValue;
            }
        }
        internal static object GetInternalScrollingDirectionProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollingDirection;
        }

        /// <summary>
        /// ScrollEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollEnabledProperty = null;
        internal static void SetInternalScrollEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollEnabled = (bool)newValue;
            }
        }
        internal static object GetInternalScrollEnabledProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollEnabled;
        }

        /// <summary>
        /// SnapToPageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SnapToPageProperty = null;
        internal static void SetInternalSnapToPageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalSnapToPage = (bool)newValue;
            }
        }
        internal static object GetInternalSnapToPageProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalSnapToPage;
        }

        /// <summary>
        /// ScrollDurationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDurationProperty = null;
        internal static void SetInternalScrollDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollDuration = (int)newValue;
            }
        }
        internal static object GetInternalScrollDurationProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollDuration;
        }

        /// <summary>
        /// ScrollAvailableAreaProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollAvailableAreaProperty = null;
        internal static void SetInternalScrollAvailableAreaProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollAvailableArea = newValue as Vector2;
            }
        }
        internal static object GetInternalScrollAvailableAreaProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollAvailableArea;
        }

        /// <summary>
        /// ScrollbarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollbarProperty = null;
        internal static void SetInternalScrollbarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollbar = newValue as ScrollbarBase;
            }
        }
        internal static object GetInternalScrollbarProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollbar;
        }

        /// <summary>
        /// HideScrollbarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HideScrollbarProperty = null;
        internal static void SetInternalHideScrollbarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalHideScrollbar = (bool)newValue;
            }
        }
        internal static object GetInternalHideScrollbarProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalHideScrollbar;
        }

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty LayoutProperty = null;
        internal static new void SetInternalLayoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalLayout = newValue as LayoutItem;
            }
        }
        internal static new object GetInternalLayoutProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalLayout;
        }

        /// <summary>
        /// DecelerationRateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecelerationRateProperty = null;
        internal static void SetInternalDecelerationRateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalDecelerationRate = (float)newValue;
            }
        }
        internal static object GetInternalDecelerationRateProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalDecelerationRate;
        }

        /// <summary>
        /// DecelerationThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecelerationThresholdProperty = null;
        internal static void SetInternalDecelerationThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalDecelerationThreshold = (float)newValue;
            }
        }
        internal static object GetInternalDecelerationThresholdProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalDecelerationThreshold;
        }

        /// <summary>
        /// ScrollingEventThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingEventThresholdProperty = null;
        internal static void SetInternalScrollingEventThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollingEventThreshold = (float)newValue;
            }
        }
        internal static object GetInternalScrollingEventThresholdProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollingEventThreshold;
        }

        /// <summary>
        /// PageFlickThresholdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PageFlickThresholdProperty = null;
        internal static void SetInternalPageFlickThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalPageFlickThreshold = (float)newValue;
            }
        }
        internal static object GetInternalPageFlickThresholdProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalPageFlickThreshold;
        }

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty PaddingProperty = null;
        internal static new void SetInternalPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalPadding = newValue as Extents;
            }
        }
        internal static new object GetInternalPaddingProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalPadding;
        }

        /// <summary>
        /// ScrollAlphaFunctionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollAlphaFunctionProperty = null;
        internal static void SetInternalScrollAlphaFunctionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalScrollAlphaFunction = newValue as AlphaFunction;
            }
        }
        internal static object GetInternalScrollAlphaFunctionProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalScrollAlphaFunction;
        }

        /// <summary>
        /// NoticeAnimationEndBeforePositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NoticeAnimationEndBeforePositionProperty = null;
        internal static void SetInternalNoticeAnimationEndBeforePositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalNoticeAnimationEndBeforePosition = (float)newValue;
            }
        }
        internal static object GetInternalNoticeAnimationEndBeforePositionProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalNoticeAnimationEndBeforePosition;
        }

        /// <summary>
        /// EnableOverShootingEffectProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableOverShootingEffectProperty = null;
        internal static void SetInternalEnableOverShootingEffectProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalEnableOverShootingEffect = (bool)newValue;
            }
        }
        internal static object GetInternalEnableOverShootingEffectProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalEnableOverShootingEffect;
        }

        /// <summary>
        /// StepScrollDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StepScrollDistanceProperty = null;
        internal static void SetInternalStepScrollDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.stepScrollDistance = (float)newValue;
            }
        }
        internal static object GetInternalStepScrollDistanceProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.stepScrollDistance;
        }

        /// <summary>
        /// WheelScrollDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WheelScrollDistanceProperty = null;
        internal static void SetInternalWheelScrollDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.wheelScrollDistance = (float)newValue;
            }
        }
        internal static object GetInternalWheelScrollDistanceProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.stepScrollDistance;
        }

        /// <summary>
        /// FadeScrollbarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FadeScrollbarProperty = null;
        internal static void SetInternalFadeScrollbarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ScrollableBase)bindable;
                instance.InternalFadeScrollbar = (bool)newValue;
            }
        }
        internal static object GetInternalFadeScrollbarProperty(BindableObject bindable)
        {
            var instance = (ScrollableBase)bindable;
            return instance.InternalFadeScrollbar;
        }
    }
}
