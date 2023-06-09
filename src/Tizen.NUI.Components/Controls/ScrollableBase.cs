﻿/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tizen.NUI.Accessibility;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ScrollEventArgs is a class to record scroll event arguments which will sent to user.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1001: Types that own disposable fields should be disposable.", Justification = "Scroll event is temporarily used for notifying scroll position update, so position will not be disposed during the event processing.")]
    public class ScrollEventArgs : EventArgs
    {
        // Position class is derived class of Disposable class and they will be implicitly disposed by DisposeQueue,
        // so that there will be no memory leak.
        private Position position;
        private Position scrollPosition;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="position">Current container position</param>
        /// <since_tizen> 8 </since_tizen>
        public ScrollEventArgs(Position position)
        {
            this.position = position;
            this.scrollPosition = new Position(-position);
        }

        /// <summary>
        /// Current position of ContentContainer.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Position Position
        {
            get
            {
                return position;
            }
        }
        /// <summary>
        /// Current scroll position of scrollableBase pan.
        /// This is the position in the opposite direction to the current position of ContentContainer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ScrollPosition
        {
            get
            {
                return scrollPosition;
            }
        }
    }

    /// <summary>
    /// ScrollOutofBoundEventArgs is to record scroll out-of-bound event arguments which will be sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollOutOfBoundEventArgs : EventArgs
    {
        /// <summary>
        /// The direction to be touched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum Direction
        {
            /// <summary>
            /// Upwards.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Up,

            /// <summary>
            /// Downwards.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Down,

            /// <summary>
            /// Left bound.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Left,

            /// <summary>
            /// Right bound.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Right,
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="direction">Current pan direction</param>
        /// <param name="displacement">Current total displacement</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollOutOfBoundEventArgs(Direction direction, float displacement)
        {
            PanDirection = direction;
            Displacement = displacement;
        }

        /// <summary>
        /// Current pan direction of ContentContainer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Direction PanDirection
        {
            get;
        }

        /// <summary>
        /// Current total displacement of ContentContainer.
        /// if its value is greater than 0, it is at the top/left;
        /// if less than 0, it is at the bottom/right.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Displacement
        {
            get;
        }
    }

    /// <summary>
    /// This class provides a View that can scroll a single View with a layout. This View can be a nest of Views.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public partial class ScrollableBase : Control
    {
        static bool LayoutDebugScrollableBase = false; // Debug flag
        static bool focusDebugScrollableBase = false; // Debug flag
        private Direction mScrollingDirection = Direction.Vertical;
        private bool mScrollEnabled = true;
        private int mScrollDuration = 125;
        private int mPageWidth = 0;
        private float mPageFlickThreshold = 0.4f;
        private float mScrollingEventThreshold = 0.001f;
        private bool fadeScrollbar = true;

        private class ScrollableBaseCustomLayout : AbsoluteLayout
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                Direction scrollingDirection = Direction.Vertical;
                ScrollableBase scrollableBase = this.Owner as ScrollableBase;
                if (scrollableBase != null)
                {
                    scrollingDirection = scrollableBase.ScrollingDirection;
                }

                float totalWidth = 0.0f;
                float totalHeight = 0.0f;

                // measure child, should be a single scrolling child
                foreach (LayoutItem childLayout in LayoutChildren)
                {
                    if (childLayout != null && childLayout.Owner.Name == "ContentContainer")
                    {
                        // Get size of child
                        // Use an Unspecified MeasureSpecification mode so scrolling child is not restricted to it's parents size in Height (for vertical scrolling)
                        // or Width for horizontal scrolling
                        if (scrollingDirection == Direction.Vertical)
                        {
                            MeasureSpecification unrestrictedMeasureSpec = new MeasureSpecification(heightMeasureSpec.Size, MeasureSpecification.ModeType.Unspecified);
                            MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), unrestrictedMeasureSpec, new LayoutLength(0)); // Height unrestricted by parent
                        }
                        else
                        {
                            MeasureSpecification unrestrictedMeasureSpec = new MeasureSpecification(widthMeasureSpec.Size, MeasureSpecification.ModeType.Unspecified);
                            MeasureChildWithMargins(childLayout, unrestrictedMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0)); // Width unrestricted by parent
                        }

                        totalWidth = (childLayout.MeasuredWidth.Size + (childLayout.Padding.Start + childLayout.Padding.End)).AsDecimal();
                        totalHeight = (childLayout.MeasuredHeight.Size + (childLayout.Padding.Top + childLayout.Padding.Bottom)).AsDecimal();

                        if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                        {
                            childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                        }
                        if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                        {
                            childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                        }
                    }
                }

                MeasuredSize widthSizeAndState = ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                MeasuredSize heightSizeAndState = ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                totalWidth = widthSizeAndState.Size.AsDecimal();
                totalHeight = heightSizeAndState.Size.AsDecimal();

                // Ensure layout respects it's given minimum size
                totalWidth = Math.Max(totalWidth, SuggestedMinimumWidth.AsDecimal());
                totalHeight = Math.Max(totalHeight, SuggestedMinimumHeight.AsDecimal());

                widthSizeAndState.State = childWidthState;
                heightSizeAndState.State = childHeightState;

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, childWidthState),
                    ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, childHeightState));

                // Size of ScrollableBase is changed. Change Page width too.
                if (scrollableBase != null)
                {
                    scrollableBase.mPageWidth = (int)MeasuredWidth.Size.AsRoundedValue();
                    scrollableBase.OnScrollingChildRelayout(null, null);
                }
            }
        } //  ScrollableBaseCustomLayout

        /// <summary>
        /// The direction axis to scroll.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum Direction
        {
            /// <summary>
            /// Horizontal axis.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Horizontal,

            /// <summary>
            /// Vertical axis.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Vertical
        }

        /// <summary>
        /// Scrolling direction mode.
        /// Default is Vertical scrolling.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Direction ScrollingDirection
        {
            get
            {
                return (Direction)GetValue(ScrollingDirectionProperty);
            }
            set
            {
                SetValue(ScrollingDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Direction InternalScrollingDirection
        {
            get
            {
                return mScrollingDirection;
            }
            set
            {
                if (value != mScrollingDirection)
                {
                    //Reset scroll position and stop scroll animation
                    ScrollTo(0, false);

                    mScrollingDirection = value;
                    mPanGestureDetector.ClearAngles();
                    mPanGestureDetector.AddDirection(value == Direction.Horizontal ?
                        PanGestureDetector.DirectionHorizontal : PanGestureDetector.DirectionVertical);

                    ContentContainer.WidthSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent;
                    ContentContainer.HeightSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.WrapContent : LayoutParamPolicies.MatchParent;
                    SetScrollbar();
                }
            }
        }

        /// <summary>
        /// Enable or disable scrolling.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool ScrollEnabled
        {
            get
            {
                return (bool)GetValue(ScrollEnabledProperty);
            }
            set
            {
                SetValue(ScrollEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool InternalScrollEnabled
        {
            get
            {
                return mScrollEnabled;
            }
            set
            {
                if (value != mScrollEnabled)
                {
                    mScrollEnabled = value;
                    if (mScrollEnabled)
                    {
                        mPanGestureDetector.Detected += OnPanGestureDetected;
                    }
                    else
                    {
                        mPanGestureDetector.Detected -= OnPanGestureDetected;
                    }
                }
            }
        }

        /// <summary>
        /// Gets scrollable status.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilityIsScrollable()
        {
            return true;
        }

        /// <summary>
        /// Pages mode, enables moving to the next or return to current page depending on pan displacement.
        /// Default is false.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool SnapToPage
        {
            get
            {
                return (bool)GetValue(SnapToPageProperty);
            }
            set
            {
                SetValue(SnapToPageProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool InternalSnapToPage { set; get; } = false;

        /// <summary>
        /// Get current page.
        /// Working property with SnapToPage property.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int CurrentPage { get; private set; } = 0;

        /// <summary>
        /// Duration of scroll animation.
        /// Default value is 125ms.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int ScrollDuration
        {
            get
            {
                return (int)GetValue(ScrollDurationProperty);
            }
            set
            {
                SetValue(ScrollDurationProperty, value);
                NotifyPropertyChanged();
            }
        }
        private int InternalScrollDuration
        {
            set
            {
                mScrollDuration = value >= 0 ? value : mScrollDuration;
            }
            get
            {
                return mScrollDuration;
            }
        }

        /// <summary>
        /// Scroll Available area.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Vector2 ScrollAvailableArea
        {
            get
            {
                return GetValue(ScrollAvailableAreaProperty) as Vector2;
            }
            set
            {
                SetValue(ScrollAvailableAreaProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Vector2 InternalScrollAvailableArea { set; get; }

        /// <summary>
        /// An event emitted when user starts dragging ScrollableBase, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ScrollEventArgs> ScrollDragStarted;

        /// <summary>
        /// An event emitted when user stops dragging ScrollableBase, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ScrollEventArgs> ScrollDragEnded;

        /// <summary>
        /// An event emitted when the scrolling slide animation starts, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ScrollEventArgs> ScrollAnimationStarted;

        /// <summary>
        /// An event emitted when the scrolling slide animation ends, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ScrollEventArgs> ScrollAnimationEnded;

        /// <summary>
        /// An event emitted when scrolling, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ScrollEventArgs> Scrolling;

        /// <summary>
        /// An event emitted when scrolling out of bound, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollOutOfBoundEventArgs> ScrollOutOfBound;

        /// <summary>
        /// Scrollbar for ScrollableBase.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ScrollbarBase Scrollbar
        {
            get
            {
                return GetValue(ScrollbarProperty) as ScrollbarBase;
            }
            set
            {
                SetValue(ScrollbarProperty, value);
                NotifyPropertyChanged();
            }
        }
        private ScrollbarBase InternalScrollbar
        {
            get
            {
                return scrollBar;
            }
            set
            {
                if (scrollBar)
                {
                    base.Remove(scrollBar);
                }
                scrollBar = value;

                if (scrollBar != null)
                {
                    scrollBar.Name = "ScrollBar";
                    base.Add(scrollBar);

                    if (hideScrollbar)
                    {
                        scrollBar.Hide();
                    }
                    else
                    {
                        scrollBar.Show();
                    }

                    SetScrollbar();
                }
            }
        }

        /// <summary>
        /// Always hide Scrollbar.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool HideScrollbar
        {
            get
            {
                return (bool)GetValue(HideScrollbarProperty);
            }
            set
            {
                SetValue(HideScrollbarProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool InternalHideScrollbar
        {
            get
            {
                return hideScrollbar;
            }
            set
            {
                hideScrollbar = value;

                if (scrollBar)
                {
                    if (value)
                    {
                        scrollBar.Hide();
                    }
                    else
                    {
                        scrollBar.Show();
                        if (fadeScrollbar)
                        {
                            scrollBar.Opacity = 1.0f;
                            scrollBar.FadeOut();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The boolean flag for automatic fading Scrollbar.
        /// Scrollbar will be faded out when scroll stay in certain position longer than the threshold.
        /// Scrollbar will be faded in scroll position changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FadeScrollbar
        {
            get => (bool)GetValue(FadeScrollbarProperty);
            set => SetValue(FadeScrollbarProperty, value);
        }

        private bool InternalFadeScrollbar
        {
            get
            {
                return fadeScrollbar;
            }
            set
            {
                fadeScrollbar = value;

                if (scrollBar != null && !hideScrollbar)
                {
                    if (value)
                    {
                        scrollBar.FadeOut();
                    }
                    else
                    {
                        scrollBar.Opacity = 1.0f;
                        // Removing fadeout timer and animation.
                        scrollBar.FadeIn();
                    }
                }
            }
        }

        /// <summary>
        /// Container which has content of ScrollableBase.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public View ContentContainer { get; private set; }

        /// <summary>
        /// Set the layout on this View. Replaces any existing Layout.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new LayoutItem Layout
        {
            get
            {
                return GetValue(LayoutProperty) as LayoutItem;
            }
            set
            {
                SetValue(LayoutProperty, value);
                NotifyPropertyChanged();
            }
        }
        private LayoutItem InternalLayout
        {
            get
            {
                return ContentContainer.Layout;
            }
            set
            {
                ContentContainer.Layout = value;
            }
        }

        /// <summary>
        /// List of children of Container.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new List<View> Children
        {
            get
            {
                return ContentContainer.Children;
            }
        }

        /// <summary>
        /// Deceleration rate of scrolling by finger.
        /// Rate should be bigger than 0 and smaller than 1.
        /// Default value is 0.998f;
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float DecelerationRate
        {
            get
            {
                return (float)GetValue(DecelerationRateProperty);
            }
            set
            {
                SetValue(DecelerationRateProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float InternalDecelerationRate
        {
            get
            {
                return decelerationRate;
            }
            set
            {
                decelerationRate = (value < 1 && value > 0) ? value : decelerationRate;
                logValueOfDeceleration = (float)Math.Log(value);
            }
        }

        /// <summary>
        /// Threshold not to go infinite at the end of scrolling animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DecelerationThreshold
        {
            get
            {
                return (float)GetValue(DecelerationThresholdProperty);
            }
            set
            {
                SetValue(DecelerationThresholdProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float InternalDecelerationThreshold { get; set; } = 0.1f;

        /// <summary>
        /// Scrolling event will be thrown when this amount of scroll position is changed.
        /// If this threshold becomes smaller, the tracking detail increases but the scrolling range that can be tracked becomes smaller.
        /// If large sized ContentContainer is required, please use larger threshold value.
        /// Default ScrollingEventThreshold value is 0.001f.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScrollingEventThreshold
        {
            get
            {
                return (float)GetValue(ScrollingEventThresholdProperty);
            }
            set
            {
                SetValue(ScrollingEventThresholdProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float InternalScrollingEventThreshold
        {
            get
            {
                return mScrollingEventThreshold;
            }
            set
            {
                if (mScrollingEventThreshold != value && value > 0)
                {
                    ContentContainer.RemovePropertyNotification(propertyNotification);
                    propertyNotification = ContentContainer.AddPropertyNotification("position", PropertyCondition.Step(value));
                    propertyNotification.Notified += OnPropertyChanged;
                    mScrollingEventThreshold = value;
                }
            }
        }

        /// <summary>
        /// Page will be changed when velocity of panning is over threshold.
        /// The unit of threshold is pixel per millisecond.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float PageFlickThreshold
        {
            get
            {
                return (float)GetValue(PageFlickThresholdProperty);
            }
            set
            {
                SetValue(PageFlickThresholdProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float InternalPageFlickThreshold
        {
            get
            {
                return mPageFlickThreshold;
            }
            set
            {
                mPageFlickThreshold = value >= 0f ? value : mPageFlickThreshold;
            }
        }

        /// <summary>
        /// Padding for the ScrollableBase
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Extents Padding
        {
            get
            {
                return GetValue(PaddingProperty) as Extents;
            }
            set
            {
                SetValue(PaddingProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Extents InternalPadding
        {
            get
            {
                return ContentContainer.Padding;
            }
            set
            {
                ContentContainer.Padding = value;
            }
        }

        /// <summary>
        /// Alphafunction for scroll animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction ScrollAlphaFunction
        {
            get
            {
                return GetValue(ScrollAlphaFunctionProperty) as AlphaFunction;
            }
            set
            {
                SetValue(ScrollAlphaFunctionProperty, value);
                NotifyPropertyChanged();
            }
        }
        private AlphaFunction InternalScrollAlphaFunction { get; set; } = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);

        private bool hideScrollbar = true;
        private float maxScrollDistance;
        private float childTargetPosition = 0.0f;
        private PanGestureDetector mPanGestureDetector;
        private ScrollbarBase scrollBar;
        private bool scrolling = false;
        private float ratioOfScreenWidthToCompleteScroll = 0.5f;
        private float totalDisplacementForPan = 0.0f;
        private Size previousContainerSize = new Size();
        private Size previousSize = new Size();
        private PropertyNotification propertyNotification;
        private float noticeAnimationEndBeforePosition = 0.0f;
        private bool readyToNotice = false;

        /// <summary>
        /// Notice before animation is finished.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Let's consider more whether this needs to be set as protected.
        public float NoticeAnimationEndBeforePosition
        {
            get
            {
                return (float)GetValue(NoticeAnimationEndBeforePositionProperty);
            }
            set
            {
                SetValue(NoticeAnimationEndBeforePositionProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float InternalNoticeAnimationEndBeforePosition
        {
            get => noticeAnimationEndBeforePosition;
            set => noticeAnimationEndBeforePosition = value;
        }

        /// <summary>
        /// Step scroll move distance.
        /// Key focus originally moves focusable objects, but in ScrollableBase,
        /// if focusable object is too far or un-exist and ScrollableBase is focusable,
        /// it can scroll move itself by key input.
        /// this value decide how long distance will it moves in one step.
        /// if any value is not set, step will be moved quater size of ScrollableBase length.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StepScrollDistance
        {
            get
            {
                return (float)GetValue(StepScrollDistanceProperty);
            }
            set
            {
                SetValue(StepScrollDistanceProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float stepScrollDistance = 0f;

        /// <summary>
        /// Wheel scroll move distance.
        /// This value decide how long distance will it moves in wheel event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelScrollDistance
        {
            get
            {
                return (float)GetValue(WheelScrollDistanceProperty);
            }
            set
            {
                SetValue(WheelScrollDistanceProperty, value);
                NotifyPropertyChanged();
            }
        }
        private float wheelScrollDistance = 50f;


        // Let's consider more whether this needs to be set as protected.
        private float finalTargetPosition;

        private Animation scrollAnimation;
        // Declare user alpha function delegate
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate float UserAlphaFunctionDelegate(float progress);
        private UserAlphaFunctionDelegate customScrollAlphaFunction;
        private float velocityOfLastPan = 0.0f;
        private float panAnimationDuration = 0.0f;
        private float panAnimationDelta = 0.0f;
        private float logValueOfDeceleration = 0.0f;
        private float decelerationRate = 0.0f;

        private View topOverShootingShadowView;
        private View bottomOverShootingShadowView;
        private View leftOverShootingShadowView;
        private View rightOverShootingShadowView;
        private const int overShootingShadowScaleHeightLimit = 64 * 3;
        private const int overShootingShadowAnimationDuration = 300;
        private Animation overShootingShadowAnimation;
        private bool isOverShootingShadowShown = false;
        private float startShowShadowDisplacement;

        private void Initialize()
        {
            DecelerationRate = 0.998f;

            base.Layout = new ScrollableBaseCustomLayout();
            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            if (mPanGestureDetector.GetMaximumTouchesRequired() < 2) mPanGestureDetector.SetMaximumTouchesRequired(2);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            ClippingMode = ClippingModeType.ClipToBoundingBox;

            //Default Scrolling child
            ContentContainer = new View()
            {
                Name = "ContentContainer",
                WidthSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent,
                HeightSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.WrapContent : LayoutParamPolicies.MatchParent,
            };
            // Check if children's sizes change to update Scrollbar
            ContentContainer.Relayout += OnScrollingChildRelayout;
            propertyNotification = ContentContainer.AddPropertyNotification("position", PropertyCondition.Step(mScrollingEventThreshold));
            propertyNotification.Notified += OnPropertyChanged;
            base.Add(ContentContainer);
            // Check if ScrollableBase's size changes to update Scrollbar
            base.Relayout += OnScrollingChildRelayout;

            Scrollbar = new Scrollbar();

            //Show vertical shadow on the top (or bottom) of the scrollable when panning down (or up).
            topOverShootingShadowView = new View
            {
                BackgroundImage = FrameworkInformation.ResourcePath + "nui_component_default_scroll_over_shooting_top.png",
                Opacity = 1.0f,
                SizeHeight = 0.0f,
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.TopCenter,
                PivotPoint = NUI.PivotPoint.TopCenter,
            };
            bottomOverShootingShadowView = new View
            {
                BackgroundImage = FrameworkInformation.ResourcePath + "nui_component_default_scroll_over_shooting_bottom.png",
                Opacity = 1.0f,
                SizeHeight = 0.0f,
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.BottomCenter,
                PivotPoint = NUI.PivotPoint.BottomCenter,
            };
            //Show horizontal shadow on the left (or right) of the scrollable when panning down (or up).
            leftOverShootingShadowView = new View
            {
                BackgroundImage = FrameworkInformation.ResourcePath + "nui_component_default_scroll_over_shooting_left.png",
                Opacity = 1.0f,
                SizeWidth = 0.0f,
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.CenterLeft,
                PivotPoint = NUI.PivotPoint.CenterLeft,
            };
            rightOverShootingShadowView = new View
            {
                BackgroundImage = FrameworkInformation.ResourcePath + "nui_component_default_scroll_over_shooting_right.png",
                Opacity = 1.0f,
                SizeWidth = 0.0f,
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.CenterRight,
                PivotPoint = NUI.PivotPoint.CenterRight,
            };

            WheelEvent += OnWheelEvent;

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "ScrollableBase");

            SetKeyboardNavigationSupport(true);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ScrollableBase() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a ScrollableBase with style.
        /// </summary>
        /// <param name="style">Creates ScrollableBase by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollableBase(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a ScrollableBase with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created ScrollableBase.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollableBase(ControlStyle style) : base(style)
        {
            Initialize();
        }

        private bool OnInterruptTouchingChildTouched(object source, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                if (scrolling && !SnapToPage)
                {
                    StopScroll();
                }
            }
            return true;
        }

        private void OnPropertyChanged(object source, PropertyNotification.NotifyEventArgs args)
        {
            OnScroll();
        }

        /// <summary>
        /// Called after a child has been added to the owning view.
        /// </summary>
        /// <param name="view">The child which has been added.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void Add(View view)
        {
            ContentContainer.Add(view);
        }

        /// <summary>
        /// Called after a child has been removed from the owning view.
        /// </summary>
        /// <param name="view">The child which has been removed.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void Remove(View view)
        {
            if (SnapToPage && CurrentPage == Children.IndexOf(view) && CurrentPage == Children.Count - 1 && Children.Count > 1)
            {
                // Target View is current page and also last child.
                // CurrentPage should be changed to previous page.
                ScrollToIndex(CurrentPage - 1);
            }

            ContentContainer.Remove(view);
        }

        private void OnScrollingChildRelayout(object source, EventArgs args)
        {
            // Size is changed. Calculate maxScrollDistance.
            bool isSizeChanged = previousContainerSize.Width != ContentContainer.Size.Width || previousContainerSize.Height != ContentContainer.Size.Height ||
                previousSize.Width != Size.Width || previousSize.Height != Size.Height;

            if (isSizeChanged)
            {
                maxScrollDistance = CalculateMaximumScrollDistance();
                if (!ReviseContainerPositionIfNeed())
                {
                    UpdateScrollbar();
                }
            }

            previousContainerSize = new Size(ContentContainer.Size);
            previousSize = new Size(Size);
        }

        private bool ReviseContainerPositionIfNeed()
        {
            bool isHorizontal = ScrollingDirection == Direction.Horizontal;
            float currentPosition = isHorizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y;

            if (Math.Abs(currentPosition) > maxScrollDistance)
            {
                StopScroll();
                var targetPosition = BoundScrollPosition(-maxScrollDistance);
                if (isHorizontal) ContentContainer.PositionX = targetPosition;
                else ContentContainer.PositionY = targetPosition;
                return true;
            }

            return false;
        }

        /// <summary>
        /// The composition of a Scrollbar can vary depending on how you use ScrollableBase.
        /// Set the composition that will go into the ScrollableBase according to your ScrollableBase.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SetScrollbar()
        {
            if (Scrollbar)
            {
                bool isHorizontal = ScrollingDirection == Direction.Horizontal;
                float contentLength = isHorizontal ? ContentContainer.Size.Width : ContentContainer.Size.Height;
                float viewportLength = isHorizontal ? Size.Width : Size.Height;
                float currentPosition = isHorizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y;
                Scrollbar.Initialize(contentLength, viewportLength, -currentPosition, isHorizontal);
            }
        }

        /// Update scrollbar position and size.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateScrollbar()
        {
            if (Scrollbar)
            {
                bool isHorizontal = ScrollingDirection == Direction.Horizontal;
                float contentLength = isHorizontal ? ContentContainer.Size.Width : ContentContainer.Size.Height;
                float viewportLength = isHorizontal ? Size.Width : Size.Height;
                float currentPosition = isHorizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y;
                Scrollbar.Update(contentLength, viewportLength, -currentPosition);

                if (!hideScrollbar && fadeScrollbar)
                {
                    Scrollbar.FadeOut();
                }
            }
        }

        /// <summary>
        /// return the children of ContentContainer when user try to get the children of ScrollableBase.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override List<View> GetChildren()
        {
            return ContentContainer.Children;
        }

        /// <summary>
        /// Scrolls to the item at the specified index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <since_tizen> 8 </since_tizen>
        public void ScrollToIndex(int index)
        {
            if (ContentContainer.ChildCount - 1 < index || index < 0)
            {
                return;
            }

            if (SnapToPage)
            {
                CurrentPage = index;
            }

            float targetPosition = Math.Min(ScrollingDirection == Direction.Vertical ? Children[index].Position.Y : Children[index].Position.X, maxScrollDistance);
            AnimateChildTo(ScrollDuration, -targetPosition);
        }

        internal void ScrollToChild(View child, bool anim = false)
        {
            if (null == FindDescendantByID(child.ID)) return;

            bool isHorizontal = (ScrollingDirection == Direction.Horizontal);

            float viewScreenPosition = (isHorizontal ? ScreenPosition.X : ScreenPosition.Y);
            float childScreenPosition = (isHorizontal ? child.ScreenPosition.X : child.ScreenPosition.Y);
            float scrollPosition = (isHorizontal ? ScrollPosition.X : ScrollPosition.Y);
            float viewSize = (isHorizontal ? SizeWidth : SizeHeight);
            float childSize = (isHorizontal ? child.SizeWidth : child.SizeHeight);

            if (viewScreenPosition > childScreenPosition ||
                viewScreenPosition + viewSize < childScreenPosition + childSize)
            {// if object is outside
                float targetPosition;
                float dist = viewScreenPosition - childScreenPosition;
                if (dist > 0)
                {// if object is upper side
                    targetPosition = scrollPosition - dist;
                }
                else
                {// if object is down side
                    targetPosition = scrollPosition - dist + childSize - viewSize;
                }
                ScrollTo(targetPosition, anim);
            }
        }

        private void OnScrollDragStarted()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollDragStarted?.Invoke(this, eventArgs);
            EmitScrollStartedEvent();

            if (!hideScrollbar && fadeScrollbar)
            {
                scrollBar?.FadeIn();
            }
        }

        private void OnScrollDragEnded()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollDragEnded?.Invoke(this, eventArgs);
            EmitScrollFinishedEvent();

            if (!hideScrollbar && fadeScrollbar)
            {
                scrollBar?.FadeOut();
            }
        }

        private void OnScrollAnimationStarted()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollAnimationStarted?.Invoke(this, eventArgs);
            EmitScrollStartedEvent();

            if (!hideScrollbar && fadeScrollbar)
            {
                scrollBar?.FadeIn();
            }
        }

        private void OnScrollAnimationEnded()
        {
            scrolling = false;
            this.InterceptTouchEvent -= OnInterruptTouchingChildTouched;

            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollAnimationEnded?.Invoke(this, eventArgs);
            EmitScrollFinishedEvent();

            if (!hideScrollbar && fadeScrollbar)
            {
                scrollBar?.FadeOut();
            }
        }

        private void OnScroll()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            Scrolling?.Invoke(this, eventArgs);

            bool isHorizontal = ScrollingDirection == Direction.Horizontal;
            float contentLength = isHorizontal ? ContentContainer.Size.Width : ContentContainer.Size.Height;
            float currentPosition = isHorizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y;

            scrollBar?.Update(contentLength, Math.Abs(currentPosition));
            CheckPreReachedTargetPosition();
        }

        private void CheckPreReachedTargetPosition()
        {
            // Check whether we reached pre-reached target position
            if (readyToNotice &&
                ContentContainer.CurrentPosition.Y <= finalTargetPosition + NoticeAnimationEndBeforePosition &&
                ContentContainer.CurrentPosition.Y >= finalTargetPosition - NoticeAnimationEndBeforePosition)
            {
                //Notice first
                readyToNotice = false;
                OnPreReachedTargetPosition(finalTargetPosition);
            }
        }

        /// <summary>
        /// This helps developer who wants to know before scroll is reaching target position.
        /// </summary>
        /// <param name="targetPosition">Index of item.</param>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPreReachedTargetPosition(float targetPosition)
        {

        }

        private void StopScroll()
        {
            if (scrollAnimation != null)
            {
                if (scrollAnimation.State == Animation.States.Playing)
                {
                    Debug.WriteLineIf(LayoutDebugScrollableBase, "StopScroll Animation Playing");
                    scrollAnimation.Stop(Animation.EndActions.Cancel);
                    OnScrollAnimationEnded();
                }
                scrollAnimation.Clear();
            }
        }

        private void AnimateChildTo(int duration, float axisPosition)
        {
            Debug.WriteLineIf(LayoutDebugScrollableBase, "AnimationTo Animation Duration:" + duration + " Destination:" + axisPosition);
            finalTargetPosition = axisPosition;

            StopScroll(); // Will replace previous animation so will stop existing one.

            if (scrollAnimation == null)
            {
                scrollAnimation = new Animation();
                scrollAnimation.Finished += ScrollAnimationFinished;
            }

            scrollAnimation.Duration = duration;
            scrollAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSquare);
            scrollAnimation.AnimateTo(ContentContainer, (ScrollingDirection == Direction.Horizontal) ? "PositionX" : "PositionY", axisPosition, ScrollAlphaFunction);
            scrolling = true;
            OnScrollAnimationStarted();
            scrollAnimation.Play();
        }

        /// <summary>
        /// Scroll to specific position with or without animation.
        /// </summary>
        /// <param name="position">Destination.</param>
        /// <param name="animate">Scroll with or without animation</param>
        /// <since_tizen> 8 </since_tizen>
        public void ScrollTo(float position, bool animate)
        {
            StopScroll();
            float currentPositionX = ContentContainer.CurrentPosition.X != 0 ? ContentContainer.CurrentPosition.X : ContentContainer.Position.X;
            float currentPositionY = ContentContainer.CurrentPosition.Y != 0 ? ContentContainer.CurrentPosition.Y : ContentContainer.Position.Y;
            float delta = ScrollingDirection == Direction.Horizontal ? currentPositionX : currentPositionY;
            // The argument position is the new pan position. So the new position of ScrollableBase becomes (-position).
            // To move ScrollableBase's position to (-position), it moves by (-position - currentPosition).
            delta = -position - delta;

            ScrollBy(delta, animate);
        }

        private float BoundScrollPosition(float targetPosition)
        {
            if (ScrollAvailableArea != null)
            {
                float minScrollPosition = ScrollAvailableArea.X;
                float maxScrollPosition = ScrollAvailableArea.Y;

                targetPosition = Math.Min(-minScrollPosition, targetPosition);
                targetPosition = Math.Max(-maxScrollPosition, targetPosition);
            }
            else
            {
                targetPosition = Math.Min(0, targetPosition);
                targetPosition = Math.Max(-maxScrollDistance, targetPosition);
            }

            return targetPosition;
        }

        private void ScrollBy(float displacement, bool animate)
        {
            if (GetChildCount() == 0 || maxScrollDistance < 0)
            {
                return;
            }

            float childCurrentPosition = (ScrollingDirection == Direction.Horizontal) ? ContentContainer.PositionX : ContentContainer.PositionY;

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollBy childCurrentPosition:" + childCurrentPosition +
                " displacement:" + displacement,
                " maxScrollDistance:" + maxScrollDistance);

            childTargetPosition = childCurrentPosition + displacement; // child current position + gesture displacement

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollBy currentAxisPosition:" + childCurrentPosition + "childTargetPosition:" + childTargetPosition);

            if (animate)
            {
                // Calculate scroll animation duration
                float scrollDistance = Math.Abs(displacement);
                readyToNotice = true;

                AnimateChildTo(ScrollDuration, BoundScrollPosition(AdjustTargetPositionOfScrollAnimation(BoundScrollPosition(childTargetPosition))));
            }
            else
            {
                StopScroll();
                finalTargetPosition = BoundScrollPosition(childTargetPosition);

                // Set position of scrolling child without an animation
                if (ScrollingDirection == Direction.Horizontal)
                {
                    ContentContainer.PositionX = finalTargetPosition;
                }
                else
                {
                    ContentContainer.PositionY = finalTargetPosition;
                }
            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            StopOverShootingShadowAnimation();
            StopScroll();

            if (type == DisposeTypes.Explicit)
            {
                mPanGestureDetector?.Dispose();
                mPanGestureDetector = null;

                ContentContainer?.RemovePropertyNotification(propertyNotification);
                propertyNotification?.Dispose();
                propertyNotification = null;
            }

            WheelEvent -= OnWheelEvent;

            if (type == DisposeTypes.Explicit)
            {

            }
            base.Dispose(type);
        }

        private float CalculateMaximumScrollDistance()
        {
            float scrollingChildLength = 0;
            float scrollerLength = 0;
            if (ScrollingDirection == Direction.Horizontal)
            {
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Horizontal");

                scrollingChildLength = ContentContainer.Size.Width;
                scrollerLength = Size.Width;
            }
            else
            {
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Vertical");
                scrollingChildLength = ContentContainer.Size.Height;
                scrollerLength = Size.Height;
            }

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollBy maxScrollDistance:" + (scrollingChildLength - scrollerLength) +
                " parent length:" + scrollerLength +
                " scrolling child length:" + scrollingChildLength);

            return Math.Max(scrollingChildLength - scrollerLength, 0);
        }

        private void PageSnap(float velocity)
        {
            float destination;

            Debug.WriteLineIf(LayoutDebugScrollableBase, "PageSnap with pan candidate totalDisplacement:" + totalDisplacementForPan +
                " currentPage[" + CurrentPage + "]");

            //Increment current page if total displacement enough to warrant a page change.
            if (Math.Abs(totalDisplacementForPan) > (mPageWidth * ratioOfScreenWidthToCompleteScroll))
            {
                if (totalDisplacementForPan < 0)
                {
                    CurrentPage = Math.Min(Math.Max(Children.Count - 1, 0), ++CurrentPage);
                }
                else
                {
                    CurrentPage = Math.Max(0, --CurrentPage);
                }
            }
            else if (Math.Abs(velocity) > PageFlickThreshold)
            {
                if (velocity < 0)
                {
                    CurrentPage = Math.Min(Math.Max(Children.Count - 1, 0), ++CurrentPage);
                }
                else
                {
                    CurrentPage = Math.Max(0, --CurrentPage);
                }
            }

            // Animate to new page or reposition to current page
            if (ScrollingDirection == Direction.Horizontal)
                destination = -(Children[CurrentPage].Position.X + Children[CurrentPage].CurrentSize.Width / 2 - CurrentSize.Width / 2); // set to middle of current page
            else
                destination = -(Children[CurrentPage].Position.Y + Children[CurrentPage].CurrentSize.Height / 2 - CurrentSize.Height / 2);

            AnimateChildTo(ScrollDuration, destination);
        }

        /// <summary>
        /// Enable/Disable overshooting effect. default is disabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableOverShootingEffect
        {
            get
            {
                return (bool)GetValue(EnableOverShootingEffectProperty);
            }
            set
            {
                SetValue(EnableOverShootingEffectProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool InternalEnableOverShootingEffect { get; set; } = false;

        private void AttachOverShootingShadowView()
        {
            if (!EnableOverShootingEffect)
                return;

            // stop animation if necessary.
            StopOverShootingShadowAnimation();

            if (ScrollingDirection == Direction.Horizontal)
            {
                base.Add(leftOverShootingShadowView);
                base.Add(rightOverShootingShadowView);

                leftOverShootingShadowView.Size = new Size(0.0f, SizeHeight);
                leftOverShootingShadowView.Opacity = 1.0f;
                leftOverShootingShadowView.RaiseToTop();

                rightOverShootingShadowView.Size = new Size(0.0f, SizeHeight);
                rightOverShootingShadowView.Opacity = 1.0f;
                rightOverShootingShadowView.RaiseToTop();
            }
            else
            {
                base.Add(topOverShootingShadowView);
                base.Add(bottomOverShootingShadowView);

                topOverShootingShadowView.Size = new Size(SizeWidth, 0.0f);
                topOverShootingShadowView.Opacity = 1.0f;
                topOverShootingShadowView.RaiseToTop();

                bottomOverShootingShadowView.Size = new Size(SizeWidth, 0.0f);
                bottomOverShootingShadowView.Opacity = 1.0f;
                bottomOverShootingShadowView.RaiseToTop();
            }

            // at the beginning, height or width of overshooting shadow is 0, so it is invisible.
            isOverShootingShadowShown = false;
        }

        private void DragOverShootingShadow(float totalPanDisplacement, float panDisplacement)
        {
            if (!EnableOverShootingEffect)
                return;

            if (totalPanDisplacement > 0) // downwards
            {
                // check if reaching at the top / left.
                if ((int)finalTargetPosition != 0)
                {
                    isOverShootingShadowShown = false;
                    return;
                }

                // save start displacement, and re-calculate displacement.
                if (!isOverShootingShadowShown)
                {
                    startShowShadowDisplacement = totalPanDisplacement;
                }
                isOverShootingShadowShown = true;

                float newDisplacement = (int)totalPanDisplacement < (int)startShowShadowDisplacement ? 0 : totalPanDisplacement - startShowShadowDisplacement;

                if (ScrollingDirection == Direction.Horizontal)
                {
                    // scale limit of height is 60%.
                    float heightScale = newDisplacement / overShootingShadowScaleHeightLimit;
                    leftOverShootingShadowView.SizeHeight = heightScale > 0.6f ? SizeHeight * 0.4f : SizeHeight * (1.0f - heightScale);

                    // scale limit of width is 300%.
                    leftOverShootingShadowView.SizeWidth = newDisplacement > overShootingShadowScaleHeightLimit ? overShootingShadowScaleHeightLimit : newDisplacement;

                    // trigger event
                    ScrollOutOfBoundEventArgs.Direction scrollDirection = panDisplacement > 0 ?
                       ScrollOutOfBoundEventArgs.Direction.Right : ScrollOutOfBoundEventArgs.Direction.Left;
                    OnScrollOutOfBound(scrollDirection, totalPanDisplacement);
                }
                else
                {
                    // scale limit of width is 60%.
                    float widthScale = newDisplacement / overShootingShadowScaleHeightLimit;
                    topOverShootingShadowView.SizeWidth = widthScale > 0.6f ? SizeWidth * 0.4f : SizeWidth * (1.0f - widthScale);

                    // scale limit of height is 300%.
                    topOverShootingShadowView.SizeHeight = newDisplacement > overShootingShadowScaleHeightLimit ? overShootingShadowScaleHeightLimit : newDisplacement;

                    // trigger event
                    ScrollOutOfBoundEventArgs.Direction scrollDirection = panDisplacement > 0 ?
                       ScrollOutOfBoundEventArgs.Direction.Down : ScrollOutOfBoundEventArgs.Direction.Up;
                    OnScrollOutOfBound(scrollDirection, totalPanDisplacement);
                }
            }
            else if (totalPanDisplacement < 0) // upwards
            {
                // check if reaching at the bottom.
                if (-(int)finalTargetPosition != (int)maxScrollDistance)
                {
                    isOverShootingShadowShown = false;
                    return;
                }

                // save start displacement, and re-calculate displacement.
                if (!isOverShootingShadowShown)
                {
                    startShowShadowDisplacement = totalPanDisplacement;
                }
                isOverShootingShadowShown = true;

                float newDisplacement = (int)startShowShadowDisplacement < (int)totalPanDisplacement ? 0 : startShowShadowDisplacement - totalPanDisplacement;

                if (ScrollingDirection == Direction.Horizontal)
                {
                    // scale limit of height is 60%.
                    float heightScale = newDisplacement / overShootingShadowScaleHeightLimit;
                    rightOverShootingShadowView.SizeHeight = heightScale > 0.6f ? SizeHeight * 0.4f : SizeHeight * (1.0f - heightScale);

                    // scale limit of width is 300%.
                    rightOverShootingShadowView.SizeWidth = newDisplacement > overShootingShadowScaleHeightLimit ? overShootingShadowScaleHeightLimit : newDisplacement;

                    // trigger event
                    ScrollOutOfBoundEventArgs.Direction scrollDirection = panDisplacement > 0 ?
                       ScrollOutOfBoundEventArgs.Direction.Right : ScrollOutOfBoundEventArgs.Direction.Left;
                    OnScrollOutOfBound(scrollDirection, totalPanDisplacement);
                }
                else
                {
                    // scale limit of width is 60%.
                    float widthScale = newDisplacement / overShootingShadowScaleHeightLimit;
                    bottomOverShootingShadowView.SizeWidth = widthScale > 0.6f ? SizeWidth * 0.4f : SizeWidth * (1.0f - widthScale);

                    // scale limit of height is 300%.
                    bottomOverShootingShadowView.SizeHeight = newDisplacement > overShootingShadowScaleHeightLimit ? overShootingShadowScaleHeightLimit : newDisplacement;

                    // trigger event
                    ScrollOutOfBoundEventArgs.Direction scrollDirection = panDisplacement > 0 ?
                       ScrollOutOfBoundEventArgs.Direction.Down : ScrollOutOfBoundEventArgs.Direction.Up;
                    OnScrollOutOfBound(scrollDirection, totalPanDisplacement);
                }
            }
            else
            {
                // if total displacement is 0, shadow would become invisible.
                isOverShootingShadowShown = false;
            }
        }

        private void PlayOverShootingShadowAnimation()
        {
            if (!EnableOverShootingEffect)
                return;

            // stop animation if necessary.
            StopOverShootingShadowAnimation();

            if (overShootingShadowAnimation == null)
            {
                overShootingShadowAnimation = new Animation(overShootingShadowAnimationDuration);
                overShootingShadowAnimation.Finished += OnOverShootingShadowAnimationFinished;
            }

            if (ScrollingDirection == Direction.Horizontal)
            {
                View targetView = totalDisplacementForPan < 0 ? rightOverShootingShadowView : leftOverShootingShadowView;
                overShootingShadowAnimation.AnimateTo(targetView, "SizeHeight", SizeHeight);
                overShootingShadowAnimation.AnimateTo(targetView, "SizeWidth", 0.0f);
                overShootingShadowAnimation.AnimateTo(targetView, "Opacity", 0.0f);
            }
            else
            {
                View targetView = totalDisplacementForPan < 0 ? bottomOverShootingShadowView : topOverShootingShadowView;
                overShootingShadowAnimation.AnimateTo(targetView, "SizeWidth", SizeWidth);
                overShootingShadowAnimation.AnimateTo(targetView, "SizeHeight", 0.0f);
                overShootingShadowAnimation.AnimateTo(targetView, "Opacity", 0.0f);
            }
            overShootingShadowAnimation.Play();
        }

        private void StopOverShootingShadowAnimation()
        {
            if (overShootingShadowAnimation == null || overShootingShadowAnimation.State != Animation.States.Playing)
                return;

            overShootingShadowAnimation.Stop(Animation.EndActions.Cancel);
            OnOverShootingShadowAnimationFinished(null, null);
            overShootingShadowAnimation.Clear();
        }

        private void OnOverShootingShadowAnimationFinished(object sender, EventArgs e)
        {
            if (ScrollingDirection == Direction.Horizontal)
            {
                base.Remove(leftOverShootingShadowView);
                base.Remove(rightOverShootingShadowView);

                leftOverShootingShadowView.Size = new Size(0.0f, SizeHeight);
                rightOverShootingShadowView.Size = new Size(0.0f, SizeHeight);
            }
            else
            {
                base.Remove(topOverShootingShadowView);
                base.Remove(bottomOverShootingShadowView);

                topOverShootingShadowView.Size = new Size(SizeWidth, 0.0f);
                bottomOverShootingShadowView.Size = new Size(SizeWidth, 0.0f);
            }

            // after animation finished, height/width & opacity of vertical shadow both are 0, so it is invisible.
            isOverShootingShadowShown = false;
        }

        private void OnScrollOutOfBound(ScrollOutOfBoundEventArgs.Direction direction, float displacement)
        {
            ScrollOutOfBoundEventArgs args = new ScrollOutOfBoundEventArgs(direction, displacement);
            ScrollOutOfBound?.Invoke(this, args);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            e.Handled = OnPanGesture(e.PanGesture);
        }

        private bool OnPanGesture(PanGesture panGesture)
        {
            bool handled = true;
            if (SnapToPage && scrollAnimation != null && scrollAnimation.State == Animation.States.Playing)
            {
                return handled;
            }
            if (panGesture.State == Gesture.StateType.Started)
            {
                readyToNotice = false;
                AttachOverShootingShadowView();
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Gesture Start");
                if (scrolling && !SnapToPage)
                {
                    StopScroll();
                }
                totalDisplacementForPan = 0.0f;

                // check if gesture need to propagation
                var checkDisplacement = (ScrollingDirection == Direction.Horizontal) ? panGesture.Displacement.X : panGesture.Displacement.Y;
                var checkChildCurrentPosition = (ScrollingDirection == Direction.Horizontal) ? ContentContainer.PositionX : ContentContainer.PositionY;
                var checkChildTargetPosition = checkChildCurrentPosition + checkDisplacement;
                var checkFinalTargetPosition = BoundScrollPosition(checkChildTargetPosition);
                handled = !((int)checkFinalTargetPosition == 0 || -(int)checkFinalTargetPosition == (int)maxScrollDistance);
                // If you propagate a gesture event, return;
                if (!handled)
                {
                    return handled;
                }

                //Interrupt touching when panning is started
                this.InterceptTouchEvent += OnInterruptTouchingChildTouched;
                OnScrollDragStarted();
            }
            else if (panGesture.State == Gesture.StateType.Continuing)
            {
                if (ScrollingDirection == Direction.Horizontal)
                {
                    // if vertical shadow is shown, does not scroll.
                    if (!isOverShootingShadowShown)
                    {
                        ScrollBy(panGesture.Displacement.X, false);
                    }
                    totalDisplacementForPan += panGesture.Displacement.X;
                    DragOverShootingShadow(totalDisplacementForPan, panGesture.Displacement.X);
                }
                else
                {
                    // if vertical shadow is shown, does not scroll.
                    if (!isOverShootingShadowShown)
                    {
                        ScrollBy(panGesture.Displacement.Y, false);
                    }
                    totalDisplacementForPan += panGesture.Displacement.Y;
                    DragOverShootingShadow(totalDisplacementForPan, panGesture.Displacement.Y);
                }
                Debug.WriteLineIf(LayoutDebugScrollableBase, "OnPanGestureDetected Continue totalDisplacementForPan:" + totalDisplacementForPan);

            }
            else if (panGesture.State == Gesture.StateType.Finished || panGesture.State == Gesture.StateType.Cancelled)
            {
                PlayOverShootingShadowAnimation();
                OnScrollDragEnded();
                StopScroll(); // Will replace previous animation so will stop existing one.

                if (scrollAnimation == null)
                {
                    scrollAnimation = new Animation();
                    scrollAnimation.Finished += ScrollAnimationFinished;
                }

                float panVelocity = (ScrollingDirection == Direction.Horizontal) ? panGesture.Velocity.X : panGesture.Velocity.Y;

                if (SnapToPage)
                {
                    PageSnap(panVelocity);
                }
                else
                {
                    if (panVelocity == 0)
                    {
                        float currentScrollPosition = (ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
                        scrollAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
                        scrollAnimation.Duration = 0;
                        scrollAnimation.AnimateTo(ContentContainer, (ScrollingDirection == Direction.Horizontal) ? "PositionX" : "PositionY", currentScrollPosition);
                        scrollAnimation.Play();
                    }
                    else
                    {
                        Decelerating(panVelocity, scrollAnimation);
                    }
                }

                totalDisplacementForPan = 0;
                scrolling = true;
                readyToNotice = true;
                OnScrollAnimationStarted();
            }
            return handled;
        }

        internal void BaseRemove(View view)
        {
            base.Remove(view);
        }

        internal override bool OnAccessibilityPan(PanGesture gestures)
        {
            if (SnapToPage && scrollAnimation != null && scrollAnimation.State == Animation.States.Playing)
            {
                return false;
            }

            OnPanGesture(gestures);
            return true;
        }

        private float CustomScrollAlphaFunction(float progress)
        {
            if (panAnimationDelta == 0)
            {
                return 1.0f;
            }
            else
            {
                // Parameter "progress" is normalized value. We need to multiply target duration to calculate distance.
                // Can get real distance using equation of deceleration (check Decelerating function)
                // After get real distance, normalize it
                float realDuration = progress * panAnimationDuration;
                float realDistance = velocityOfLastPan * ((float)Math.Pow(decelerationRate, realDuration) - 1) / logValueOfDeceleration;
                float result = Math.Min(realDistance / Math.Abs(panAnimationDelta), 1.0f);

                // This is hot-fix for if the velocity has very small value, result is not updated even progress done.
                if (progress > 0.99) result = 1.0f;

                return result;
            }
        }

        /// <summary>
        /// you can override it to custom your decelerating
        /// </summary>
        /// <param name="velocity">Velocity of current pan.</param>
        /// <param name="animation">Scroll animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Decelerating(float velocity, Animation animation)
        {
            if (animation == null) throw new ArgumentNullException(nameof(animation));
            // Decelerating using deceleration equation ===========
            //
            // V   : velocity (pixel per millisecond)
            // V0  : initial velocity
            // d   : deceleration rate,
            // t   : time
            // X   : final position after decelerating
            // log : natural logarithm
            //
            // V(t) = V0 * d pow t;
            // X(t) = V0 * (d pow t - 1) / log d;  <-- Integrate the velocity function
            // X(∞) = V0 * d / (1 - d); <-- Result using infinite T can be final position because T is tending to infinity.
            //
            // Because of final T is tending to infinity, we should use threshold value to finish.
            // Final T = log(-threshold * log d / |V0| ) / log d;

            velocityOfLastPan = Math.Abs(velocity);

            float currentScrollPosition = -(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
            panAnimationDelta = (velocityOfLastPan * decelerationRate) / (1 - decelerationRate);
            panAnimationDelta = velocity > 0 ? -panAnimationDelta : panAnimationDelta;

            float destination = -(panAnimationDelta + currentScrollPosition);
            float adjustDestination = AdjustTargetPositionOfScrollAnimation(destination);
            float maxPosition = ScrollAvailableArea != null ? ScrollAvailableArea.Y : maxScrollDistance;
            float minPosition = ScrollAvailableArea != null ? ScrollAvailableArea.X : 0;

            if (destination < -maxPosition || destination > minPosition)
            {
                panAnimationDelta = velocity > 0 ? (currentScrollPosition - minPosition) : (maxPosition - currentScrollPosition);
                destination = velocity > 0 ? minPosition : -maxPosition;

                if (panAnimationDelta == 0)
                {
                    panAnimationDuration = 0.0f;
                }
                else
                {
                    panAnimationDuration = (float)Math.Log((panAnimationDelta * logValueOfDeceleration / velocityOfLastPan + 1), decelerationRate);
                }

                Debug.WriteLineIf(LayoutDebugScrollableBase, "\n" +
                    "OverRange======================= \n" +
                    "[decelerationRate] " + decelerationRate + "\n" +
                    "[logValueOfDeceleration] " + logValueOfDeceleration + "\n" +
                    "[Velocity] " + velocityOfLastPan + "\n" +
                    "[CurrentPosition] " + currentScrollPosition + "\n" +
                    "[CandidateDelta] " + panAnimationDelta + "\n" +
                    "[Destination] " + destination + "\n" +
                    "[Duration] " + panAnimationDuration + "\n" +
                    "================================ \n"
                );
            }
            else
            {
                panAnimationDuration = (float)Math.Log(-DecelerationThreshold * logValueOfDeceleration / velocityOfLastPan) / logValueOfDeceleration;

                if (adjustDestination != destination)
                {
                    destination = adjustDestination;
                    panAnimationDelta = destination + currentScrollPosition;
                    velocityOfLastPan = Math.Abs(panAnimationDelta * logValueOfDeceleration / ((float)Math.Pow(decelerationRate, panAnimationDuration) - 1));
                    panAnimationDuration = (float)Math.Log(-DecelerationThreshold * logValueOfDeceleration / velocityOfLastPan) / logValueOfDeceleration;
                }

                Debug.WriteLineIf(LayoutDebugScrollableBase, "\n" +
                    "================================ \n" +
                    "[decelerationRate] " + decelerationRate + "\n" +
                    "[logValueOfDeceleration] " + logValueOfDeceleration + "\n" +
                    "[Velocity] " + velocityOfLastPan + "\n" +
                    "[CurrentPosition] " + currentScrollPosition + "\n" +
                    "[CandidateDelta] " + panAnimationDelta + "\n" +
                    "[Destination] " + destination + "\n" +
                    "[Duration] " + panAnimationDuration + "\n" +
                    "================================ \n"
                );
            }

            finalTargetPosition = destination;

            customScrollAlphaFunction = new UserAlphaFunctionDelegate(CustomScrollAlphaFunction);
            animation.DefaultAlphaFunction = new AlphaFunction(customScrollAlphaFunction);
            GC.KeepAlive(customScrollAlphaFunction);
            animation.Duration = (int)panAnimationDuration;
            animation.AnimateTo(ContentContainer, (ScrollingDirection == Direction.Horizontal) ? "PositionX" : "PositionY", destination);
            animation.Play();
        }

        private void ScrollAnimationFinished(object sender, EventArgs e)
        {
            OnScrollAnimationEnded();
        }

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// Override this function when developer wants to change destination of flicking.(e.g. always snap to center of item)
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual float AdjustTargetPositionOfScrollAnimation(float position)
        {
            return position;
        }

        /// <summary>
        /// Scroll position given to ScrollTo.
        /// This is the position in the opposite direction to the position of ContentContainer.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Position ScrollPosition
        {
            get
            {
                return new Position(-ContentContainer.Position);
            }
        }

        /// <summary>
        /// Current scroll position in the middle of ScrollTo animation.
        /// This is the position in the opposite direction to the current position of ContentContainer.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Position ScrollCurrentPosition
        {
            get
            {
                return new Position(-ContentContainer.CurrentPosition);
            }
        }

        /// <summary>
        /// Remove all children in ContentContainer.
        /// </summary>
        /// <param name="dispose">If true, removed child is disposed.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(ContentContainer, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }
            int maxChild = (int)parent.GetChildCount();
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }
                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }

        internal bool IsChildNearlyVisble(View child, float offset = 0)
        {
            if (ScreenPosition.X - offset < child.ScreenPosition.X + child.SizeWidth &&
                ScreenPosition.X + SizeWidth + offset > child.ScreenPosition.X &&
                ScreenPosition.Y - offset < child.ScreenPosition.Y + child.SizeHeight &&
                ScreenPosition.Y + SizeHeight + offset > child.ScreenPosition.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            bool isHorizontal = (ScrollingDirection == Direction.Horizontal);
            float targetPosition = -(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
            float stepDistance = (stepScrollDistance != 0 ? stepScrollDistance : (isHorizontal ? Size.Width * 0.25f : Size.Height * 0.25f));

            bool forward = ((isHorizontal && direction == View.FocusDirection.Right) ||
                            (!isHorizontal && direction == View.FocusDirection.Down) ||
                            (direction == View.FocusDirection.Clockwise));
            bool backward = ((isHorizontal && direction == View.FocusDirection.Left) ||
                             (!isHorizontal && direction == View.FocusDirection.Up) ||
                             (direction == View.FocusDirection.CounterClockwise));

            View nextFocusedView = FocusManager.Instance.GetNearestFocusableActor(this, currentFocusedView, direction);

            // Move out focus from ScrollableBase.
            // FIXME: Forward, Backward is unimplemented other components.
            if (direction == View.FocusDirection.Forward ||
                direction == View.FocusDirection.Backward ||
                (nextFocusedView == null &&
                ((forward && maxScrollDistance - targetPosition < 0.1f) ||
                 (backward && targetPosition < 0.1f))))
            {
                var next = FocusManager.Instance.GetNearestFocusableActor(this.Parent, this, direction);
                Debug.WriteLineIf(focusDebugScrollableBase, $"Focus move [{direction}] out from ScrollableBase! Next focus target {next}:{next?.ID}");
                return next;
            }

            if (focusDebugScrollableBase)
            {
                global::System.Text.StringBuilder debugMessage = new global::System.Text.StringBuilder("=========================================================\n");
                debugMessage.Append($"GetNextFocusableView On: {this}:{this.ID}\n");
                debugMessage.Append($"----------------Current: {currentFocusedView}:{currentFocusedView?.ID}\n");
                debugMessage.Append($"-------------------Next: {nextFocusedView}:{nextFocusedView?.ID}\n");
                debugMessage.Append($"--------------Direction: {direction}\n");
                debugMessage.Append("=========================================================");
                Debug.WriteLineIf(focusDebugScrollableBase, debugMessage);
            }

            if (nextFocusedView != null)
            {
                if (null != FindDescendantByID(nextFocusedView.ID))
                {
                    if (IsChildNearlyVisble(nextFocusedView, stepDistance) == true)
                    {
                        ScrollToChild(nextFocusedView, true);
                        return nextFocusedView;
                    }
                }
            }

            if (forward || backward)
            {
                // Fallback to current focus or scrollableBase till next focus visible in scrollable.
                if (null != currentFocusedView && null != FindDescendantByID(currentFocusedView.ID))
                {
                    nextFocusedView = currentFocusedView;
                }
                else
                {
                    Debug.WriteLineIf(focusDebugScrollableBase, "current focus view is not decendant. return ScrollableBase!");
                    return this;
                }

                if (forward)
                {
                    targetPosition += stepDistance;
                    targetPosition = targetPosition > maxScrollDistance ? maxScrollDistance : targetPosition;

                }
                else if (backward)
                {
                    targetPosition -= stepDistance;
                    targetPosition = targetPosition < 0 ? 0 : targetPosition;
                }

                ScrollTo(targetPosition, true);

                Debug.WriteLineIf(focusDebugScrollableBase, $"ScrollTo :({targetPosition})");
            }

            Debug.WriteLineIf(focusDebugScrollableBase, $"return end : {nextFocusedView}:{nextFocusedView?.ID}");
            return nextFocusedView;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilityScrollToChild(View child)
        {
            if (child == null)
            {
                return false;
            }

            if (ScrollingDirection == Direction.Horizontal)
            {
                if (child.ScreenPosition.X + child.Size.Width <= this.ScreenPosition.X)
                {
                    if (SnapToPage)
                    {
                        PageSnap(PageFlickThreshold + 1);
                    }
                    else
                    {
                        ScrollTo((float)(child.ScreenPosition.X - ContentContainer.ScreenPosition.X), false);
                    }
                }
                else if (child.ScreenPosition.X >= this.ScreenPosition.X + this.Size.Width)
                {
                    if (SnapToPage)
                    {
                        PageSnap(-(PageFlickThreshold + 1));
                    }
                    else
                    {
                        ScrollTo((float)(child.ScreenPosition.X + child.Size.Width - ContentContainer.ScreenPosition.X - this.Size.Width), false);
                    }
                }
            }
            else
            {
                if (child.ScreenPosition.Y + child.Size.Height <= this.ScreenPosition.Y)
                {
                    if (SnapToPage)
                    {
                        PageSnap(PageFlickThreshold + 1);
                    }
                    else
                    {
                        ScrollTo((float)(child.ScreenPosition.Y - ContentContainer.ScreenPosition.Y), false);
                    }
                }
                else if (child.ScreenPosition.Y >= this.ScreenPosition.Y + this.Size.Height)
                {
                    if (SnapToPage)
                    {
                        PageSnap(-(PageFlickThreshold + 1));
                    }
                    else
                    {
                        ScrollTo((float)(child.ScreenPosition.Y + child.Size.Height - ContentContainer.ScreenPosition.Y - this.Size.Height), false);
                    }
                }
            }

            return true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnWheel(Wheel wheel)
        {
            if (wheel == null)
            {
                return false;
            }

            float currentScrollPosition = -(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
            ScrollTo(currentScrollPosition + (wheelScrollDistance * wheel.Z), false);

            return true;
        }

        private bool OnWheelEvent(object o, WheelEventArgs e)
        {
            return OnWheel(e?.Wheel);
        }
    }

} // namespace
