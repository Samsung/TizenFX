/* Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Diagnostics;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// [Draft] This class provides a View that can scroll a single View with a layout. This View can be a nest of Views.
    /// </summary>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollableBase : Control
    {
	    static bool LayoutDebugScrollableBase = false; // Debug flag
        private Direction mScrollingDirection = Direction.Vertical;
        private bool mScrollEnabled = true;
        private int mPageWidth = 0;

        private class ScrollableBaseCustomLayout : LayoutGroup
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                Extents padding = Padding;
                float totalHeight = padding.Top + padding.Bottom;
                float totalWidth = padding.Start + padding.End;

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                Direction scrollingDirection = Direction.Vertical;
                ScrollableBase scrollableBase = this.Owner as ScrollableBase;
                if (scrollableBase)
                {
                   scrollingDirection = scrollableBase.ScrollingDirection;
                }

                // measure child, should be a single scrolling child
                foreach( LayoutItem childLayout in LayoutChildren )
                {
                    if (childLayout != null)
                    {
                        // Get size of child
                        // Use an Unspecified MeasureSpecification mode so scrolling child is not restricted to it's parents size in Height (for vertical scrolling)
                        // or Width for horizontal scrolling
                        MeasureSpecification unrestrictedMeasureSpec = new MeasureSpecification( heightMeasureSpec.Size, MeasureSpecification.ModeType.Unspecified);

                        if (scrollingDirection == Direction.Vertical)
                        {
                            MeasureChild( childLayout, widthMeasureSpec, unrestrictedMeasureSpec );  // Height unrestricted by parent
                        }
                        else
                        {
                            MeasureChild( childLayout, unrestrictedMeasureSpec, heightMeasureSpec );  // Width unrestricted by parent
                        }

                        float childWidth = childLayout.MeasuredWidth.Size.AsDecimal();
                        float childHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                        // Determine the width and height needed by the children using their given position and size.
                        // Children could overlap so find the left most and right most child.
                        Position2D childPosition = childLayout.Owner.Position2D;
                        float childLeft = childPosition.X;
                        float childTop = childPosition.Y;

                        // Store current width and height needed to contain all children.
                        Extents childMargin = childLayout.Margin;
                        totalWidth = childWidth + childMargin.Start + childMargin.End;
                        totalHeight = childHeight + childMargin.Top + childMargin.Bottom;

                        if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                        {
                            childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                        }
                        if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                        {
                            childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                        }
                    }
                }


                MeasuredSize widthSizeAndState = ResolveSizeAndState(new LayoutLength(totalWidth + Padding.Start + Padding.End), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                MeasuredSize heightSizeAndState = ResolveSizeAndState(new LayoutLength(totalHeight + Padding.Top + Padding.Bottom), heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                totalWidth = widthSizeAndState.Size.AsDecimal();
                totalHeight = heightSizeAndState.Size.AsDecimal();

                // Ensure layout respects it's given minimum size
                totalWidth = Math.Max( totalWidth, SuggestedMinimumWidth.AsDecimal() );
                totalHeight = Math.Max( totalHeight, SuggestedMinimumHeight.AsDecimal() );

                widthSizeAndState.State = childWidthState;
                heightSizeAndState.State = childHeightState;

                SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(totalWidth + Padding.Start + Padding.End), widthMeasureSpec, childWidthState ),
                                       ResolveSizeAndState( new LayoutLength(totalHeight + Padding.Top + Padding.Bottom), heightMeasureSpec, childHeightState ) );

                // Size of ScrollableBase is changed. Change Page width too.
                scrollableBase.mPageWidth = (int)MeasuredWidth.Size.AsRoundedValue();
            }

            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                foreach( LayoutItem childLayout in LayoutChildren )
                {
                    if( childLayout != null )
                    {
                        LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                        LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                        Position2D childPosition = childLayout.Owner.Position2D;
                        Extents padding = Padding;
                        Extents childMargin = childLayout.Margin;

                        LayoutLength childLeft = new LayoutLength(childPosition.X + childMargin.Start + padding.Start);
                        LayoutLength childTop = new LayoutLength(childPosition.Y + childMargin.Top + padding.Top);

                        childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                    }
                }
            }
        } //  ScrollableBaseCustomLayout

        /// <summary>
        /// The direction axis to scroll.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum Direction
        {
            /// <summary>
            /// Horizontal axis.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Horizontal,

            /// <summary>
            /// Vertical axis.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Vertical
        }

        /// <summary>
        /// [Draft] Configurable speed threshold that register the gestures as a flick.
        /// If the flick speed less than the threshold then will not be considered a flick.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FlickThreshold { get; set; } = 0.2f;

        /// <summary>
        /// [Draft] Configurable duration modifer for the flick animation.
        /// Determines the speed of the scroll, large value results in a longer flick animation. Range (0.1 - 1.0)
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FlickAnimationSpeed { get; set; } = 0.4f;

        /// <summary>
        /// [Draft] Configurable modifer for the distance to be scrolled when flicked detected.
        /// It a ratio of the ScrollableBase's length. (not child's length).
        /// First value is the ratio of the distance to scroll with the weakest flick.
        /// Second value is the ratio of the distance to scroll with the strongest flick.
        /// Second > First.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 FlickDistanceMultiplierRange { get; set; } = new Vector2(0.6f, 1.8f);

        /// <summary>
        /// [Draft] Scrolling direction mode.
        /// Default is Vertical scrolling.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Direction ScrollingDirection
        {
            get
            {
                return mScrollingDirection;
            }
            set
            {
                if(value != mScrollingDirection)
                {
                    mScrollingDirection = value;
                    mPanGestureDetector.RemoveDirection(value == Direction.Horizontal ? PanGestureDetector.DirectionVertical : PanGestureDetector.DirectionHorizontal);
                    mPanGestureDetector.AddDirection(value == Direction.Horizontal ? PanGestureDetector.DirectionHorizontal : PanGestureDetector.DirectionVertical);
                }
            }
        }

        /// <summary>
        /// [Draft] Enable or disable scrolling.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollEnabled
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
                    if(mScrollEnabled)
                    {
                        mPanGestureDetector.Detected += OnPanGestureDetected;
                        mTapGestureDetector.Detected += OnTapGestureDetected;
                    }
                    else
                    {
                        mPanGestureDetector.Detected -= OnPanGestureDetected;
                        mTapGestureDetector.Detected -= OnTapGestureDetected;
                    }
                }
            }
        }

        /// <summary>
        /// [Draft] Pages mode, enables moving to the next or return to current page depending on pan displacement.
        /// Default is false.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SnapToPage { set; get; } = false;

        /// <summary>
        /// [Draft] Get current page.
        /// Working propery with SnapToPage property.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentPage { get; private set; } = 0;

        /// <summary>
        /// [Draft] Duration of scroll animation.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]

        public int ScrollDuration { set; get; } = 125;
        /// <summary>
        /// [Draft] Scroll Available area.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ScrollAvailableArea { set; get; }

        /// <summary>
        /// ScrollEventArgs is a class to record scroll event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ScrollEventArgs : EventArgs
        {
            Position position;

            /// <summary>
            /// Default constructor.
            /// </summary>
            /// <param name="position">Current scroll position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
            public ScrollEventArgs(Position position)
            {
                this.position = position;
            }

            /// <summary>
            /// [Draft] Current scroll position.
            /// </summary>
            /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position Position
            {
                get
                {
                    return position;
                }
            }
        }

        /// <summary>
        /// An event emitted when user starts dragging ScrollableBase, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollEventArgs> ScrollDragStartEvent;

        /// <summary>
        /// An event emitted when user stops dragging ScrollableBase, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollEventArgs> ScrollDragEndEvent;


        /// <summary>
        /// An event emitted when the scrolling slide animation starts, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollEventArgs> ScrollAnimationStartEvent;

        /// <summary>
        /// An event emitted when the scrolling slide animation ends, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollEventArgs> ScrollAnimationEndEvent;


        /// <summary>
        /// An event emitted when scrolling, user can subscribe or unsubscribe to this event handler.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollEventArgs> ScrollEvent;

        private Animation scrollAnimation;
        private float maxScrollDistance;
        private float childTargetPosition = 0.0f;
        private PanGestureDetector mPanGestureDetector;
        private TapGestureDetector mTapGestureDetector;
        private View mScrollingChild;
        private View mInterruptTouchingChild;
        private float multiplier =1.0f;
        private bool scrolling = false;
        private float ratioOfScreenWidthToCompleteScroll = 0.5f;
        private float totalDisplacementForPan = 0.0f;

        // If false then can only flick pages when the current animation/scroll as ended.
        private bool flickWhenAnimating = false;
        private PropertyNotification propertyNotification;

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollableBase() : base()
        {
            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            mTapGestureDetector = new TapGestureDetector();
            mTapGestureDetector.Attach(this);
            mTapGestureDetector.Detected += OnTapGestureDetected;


            ClippingMode = ClippingModeType.ClipToBoundingBox;

            mScrollingChild = new View();
            mScrollingChild.Name = "DefaultScrollingChild";

            //Interrupt touching when panning is started;
            mInterruptTouchingChild = new View()
            {
                Name = "InterruptTouchingChild",
                Size = new Size(Window.Instance.WindowSize),
                BackgroundColor = Color.Transparent,
            };

            mInterruptTouchingChild.TouchEvent += (object source, View.TouchEventArgs args) => {
                return true;
            };

            Layout = new ScrollableBaseCustomLayout();
        }

        private void OnPropertyChanged(object source, PropertyNotification.NotifyEventArgs args)
        {
            OnScroll();
        }

        /// <summary>
        /// Called after a child has been added to the owning view.
        /// </summary>
        /// <param name="view">The child which has been added.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnChildAdd(View view)
        {
            if(view.Name != "InterruptTouchingChild")
            {
                if(mScrollingChild.Name != "DefaultScrollingChild")
                {
                    propertyNotification.Notified -= OnPropertyChanged;
                    mScrollingChild.RemovePropertyNotification(propertyNotification);
                }

                mScrollingChild = view;
                propertyNotification = mScrollingChild?.AddPropertyNotification("position", PropertyCondition.Step(1.0f));
                propertyNotification.Notified += OnPropertyChanged;
            }
        }

        /// <summary>
        /// Called after a child has been removed from the owning view.
        /// </summary>
        /// <param name="view">The child which has been removed.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnChildRemove(View view)
        {
            if(view.Name != "InterruptTouchingChild")
            {
                propertyNotification.Notified -= OnPropertyChanged;
                mScrollingChild.RemovePropertyNotification(propertyNotification);

                mScrollingChild = new View();
            }
        }


        /// <summary>
        /// Scrolls to the item at the specified index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollToIndex(int index)
        {
            if(mScrollingChild.ChildCount-1 < index || index < 0)
            {
                return;
            }

            if(SnapToPage)
            {
                CurrentPage = index;
            }

            maxScrollDistance = CalculateMaximumScrollDistance();

            float targetPosition = Math.Min(ScrollingDirection == Direction.Vertical ? mScrollingChild.Children[index].Position.Y : mScrollingChild.Children[index].Position.X, maxScrollDistance);
            AnimateChildTo(ScrollDuration, -targetPosition);
        }

        private void OnScrollDragStart()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(mScrollingChild.CurrentPosition);
            ScrollDragStartEvent?.Invoke(this, eventArgs);
        }

        private void OnScrollDragEnd()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(mScrollingChild.CurrentPosition);
            ScrollDragEndEvent?.Invoke(this, eventArgs);
        }

        private void OnScrollAnimationStart()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(mScrollingChild.CurrentPosition);
            ScrollAnimationStartEvent?.Invoke(this, eventArgs);
        }

        private void OnScrollAnimationEnd()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(mScrollingChild.CurrentPosition);
            ScrollAnimationEndEvent?.Invoke(this, eventArgs);
        }

        private void OnScroll()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(mScrollingChild.CurrentPosition);
            ScrollEvent?.Invoke(this, eventArgs);
        }

        private void StopScroll()
        {
            if (scrollAnimation != null)
            {
                if (scrollAnimation.State == Animation.States.Playing)
                {
                    Debug.WriteLineIf(LayoutDebugScrollableBase, "StopScroll Animation Playing");
                    scrollAnimation.Stop(Animation.EndActions.Cancel);
                    OnScrollAnimationEnd();
                }
                scrollAnimation.Clear();
            }
        }

        // static constructor registers the control type
        static ScrollableBase()
        {
            // ViewRegistry registers control type with DALi type registry
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(ScrollableBase));
        }

        internal static CustomView CreateInstance()
        {
            return new ScrollableBase();
        }

        private void AnimateChildTo(int duration, float axisPosition)
        {
            Debug.WriteLineIf(LayoutDebugScrollableBase, "AnimationTo Animation Duration:" + duration + " Destination:" + axisPosition);

            StopScroll(); // Will replace previous animation so will stop existing one.

            if (scrollAnimation == null)
            {
                scrollAnimation = new Animation();
                scrollAnimation.Finished += ScrollAnimationFinished;
            }

            scrollAnimation.Duration = duration;
            scrollAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine);
            scrollAnimation.AnimateTo(mScrollingChild, (ScrollingDirection == Direction.Horizontal) ? "PositionX" : "PositionY", axisPosition);
            scrolling = true;
            OnScrollAnimationStart();
            scrollAnimation.Play();
        }

        private void ScrollBy(float displacement, bool animate)
        {
            if (GetChildCount() == 0 || maxScrollDistance < 0)
            {
                return;
            }

            float childCurrentPosition = (ScrollingDirection == Direction.Horizontal) ? mScrollingChild.PositionX: mScrollingChild.PositionY;

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollBy childCurrentPosition:" + childCurrentPosition +
                                                   " displacement:" + displacement,
                                                   " maxScrollDistance:" + maxScrollDistance );

            childTargetPosition = childCurrentPosition + displacement; // child current position + gesture displacement

            if(ScrollAvailableArea != null)
            {
                float minScrollPosition = ScrollingDirection == Direction.Horizontal? ScrollAvailableArea.X:ScrollAvailableArea.Y;
                float maxScrollPosition = ScrollingDirection == Direction.Horizontal? 
                                        ScrollAvailableArea.X + ScrollAvailableArea.Width:
                                        ScrollAvailableArea.Y + ScrollAvailableArea.Height;

                childTargetPosition = Math.Min( -minScrollPosition, childTargetPosition );
                childTargetPosition = Math.Max( -maxScrollPosition, childTargetPosition );
            }
            else
            {
                childTargetPosition = Math.Min(0, childTargetPosition);
                childTargetPosition = Math.Max(-maxScrollDistance, childTargetPosition);
            }

            Debug.WriteLineIf( LayoutDebugScrollableBase, "ScrollBy currentAxisPosition:" + childCurrentPosition + "childTargetPosition:" + childTargetPosition);

            if (animate)
            {
                // Calculate scroll animaton duration
                float scrollDistance = Math.Abs(displacement);
                int duration = (int)((320*FlickAnimationSpeed) + (scrollDistance * FlickAnimationSpeed));
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Scroll Animation Duration:" + duration + " Distance:" + scrollDistance);

                AnimateChildTo(duration, AdjustScrollToChild(childTargetPosition));
            }
            else
            {
                // Set position of scrolling child without an animation
                if (ScrollingDirection == Direction.Horizontal)
                {
                    mScrollingChild.PositionX = childTargetPosition;
                }
                else
                {
                    mScrollingChild.PositionY = childTargetPosition;
                }
            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                StopScroll();

                if (mPanGestureDetector != null)
                {
                    mPanGestureDetector.Detected -= OnPanGestureDetected;
                    mPanGestureDetector.Dispose();
                    mPanGestureDetector = null;
                }

                if (mTapGestureDetector != null)
                {
                    mTapGestureDetector.Detected -= OnTapGestureDetected;
                    mTapGestureDetector.Dispose();
                    mTapGestureDetector = null;
                }
            }
            base.Dispose(type);
        }

        private float CalculateDisplacementFromVelocity(float axisVelocity)
        {
            // Map: flick speed of range (2.0 - 6.0) to flick multiplier of range (0.7 - 1.6)
            float speedMinimum = FlickThreshold;
            float speedMaximum = FlickThreshold + 6.0f;
            float multiplierMinimum = FlickDistanceMultiplierRange.X;
            float multiplierMaximum = FlickDistanceMultiplierRange.Y;

            float flickDisplacement = 0.0f;

            float speed = Math.Min(4.0f,Math.Abs(axisVelocity));

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollableBase Candidate Flick speed:" + speed);

            if (speed > FlickThreshold)
            {
                // Flick length is the length of the ScrollableBase.
                float flickLength = (ScrollingDirection == Direction.Horizontal) ?CurrentSize.Width:CurrentSize.Height;

                // Calculate multiplier by mapping speed between the multiplier minimum and maximum.
                multiplier =( (speed - speedMinimum) / ( (speedMaximum - speedMinimum) * (multiplierMaximum - multiplierMinimum) ) )+ multiplierMinimum;

                // flick displacement is the product of the flick length and multiplier
                flickDisplacement = ((flickLength * multiplier) * speed) / axisVelocity;  // *speed and /velocity to perserve sign.

                Debug.WriteLineIf(LayoutDebugScrollableBase, "Calculated FlickDisplacement[" + flickDisplacement +"] from speed[" + speed + "] multiplier:"
                                                        + multiplier);
            }
            return flickDisplacement;
        }

        private float CalculateMaximumScrollDistance()
        {
            int scrollingChildLength = 0;
            int scrollerLength = 0;
            if (ScrollingDirection == Direction.Horizontal)
            {
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Horizontal");

                scrollingChildLength = (int)mScrollingChild.Layout.MeasuredWidth.Size.AsRoundedValue();
                scrollerLength = CurrentSize.Width;
            }
            else
            {
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Vertical");
                scrollingChildLength = (int)mScrollingChild.Layout.MeasuredHeight.Size.AsRoundedValue();
                scrollerLength = CurrentSize.Height;
            }

            Debug.WriteLineIf(LayoutDebugScrollableBase, "ScrollBy maxScrollDistance:" + (scrollingChildLength - scrollerLength) +
                                                   " parent length:" + scrollerLength +
                                                   " scrolling child length:" + scrollingChildLength);

            return Math.Max(scrollingChildLength,0);
        }

        private void PageSnap()
        {
            Debug.WriteLineIf(LayoutDebugScrollableBase, "PageSnap with pan candidate totalDisplacement:" + totalDisplacementForPan +
                                                                " currentPage[" + CurrentPage + "]" );

            //Increment current page if total displacement enough to warrant a page change.
            if (Math.Abs(totalDisplacementForPan) > (mPageWidth * ratioOfScreenWidthToCompleteScroll))
            {
                if (totalDisplacementForPan < 0)
                {
                    CurrentPage = Math.Min(Math.Max(mScrollingChild.Children.Count - 1,0), ++CurrentPage);
                }
                else
                {
                    CurrentPage = Math.Max(0, --CurrentPage);
                }
            }

            // Animate to new page or reposition to current page
            float destinationX = -(mScrollingChild.Children[CurrentPage].Position.X + mScrollingChild.Children[CurrentPage].CurrentSize.Width/2 - CurrentSize.Width/2); // set to middle of current page
            Debug.WriteLineIf(LayoutDebugScrollableBase, "Snapping to page[" + CurrentPage + "] to:" + destinationX + " from:" + mScrollingChild.PositionX);
            AnimateChildTo(ScrollDuration, destinationX);
        }

        private void Flick(float flickDisplacement)
        {
          if (SnapToPage)
          {
              if ( ( flickWhenAnimating && scrolling == true) || ( scrolling == false) )
              {
                  if(flickDisplacement < 0)
                  {
                      CurrentPage = Math.Min(Math.Max(mScrollingChild.Children.Count - 1,0), CurrentPage + 1);
                      Debug.WriteLineIf(LayoutDebugScrollableBase, "Snap - to page:" + CurrentPage);
                  }
                  else
                  {
                      CurrentPage = Math.Max(0, CurrentPage - 1);
                      Debug.WriteLineIf(LayoutDebugScrollableBase, "Snap + to page:" + CurrentPage);
                  }

                  float destinationX = -(mScrollingChild.Children[CurrentPage].Position.X + mScrollingChild.Children[CurrentPage].CurrentSize.Width/2.0f - CurrentSize.Width/2.0f); // set to middle of current page
                  Debug.WriteLineIf(LayoutDebugScrollableBase, "Snapping to :" + destinationX);
                  AnimateChildTo(ScrollDuration, destinationX);
              }
          }
          else
          {
              ScrollBy(flickDisplacement, true); // Animate flickDisplacement.
          }
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                Add(mInterruptTouchingChild);
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Gesture Start");
                if (scrolling && !SnapToPage)
                {
                    StopScroll();
                }
                maxScrollDistance = CalculateMaximumScrollDistance();
                totalDisplacementForPan = 0.0f;
                OnScrollDragStart();
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (ScrollingDirection == Direction.Horizontal)
                {
                    ScrollBy(e.PanGesture.Displacement.X, false);
                    totalDisplacementForPan += e.PanGesture.Displacement.X;
                }
                else
                {
                    ScrollBy(e.PanGesture.Displacement.Y, false);
                    totalDisplacementForPan += e.PanGesture.Displacement.Y;
                }
                Debug.WriteLineIf(LayoutDebugScrollableBase, "OnPanGestureDetected Continue totalDisplacementForPan:" + totalDisplacementForPan);
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                float axisVelocity = (ScrollingDirection == Direction.Horizontal) ? e.PanGesture.Velocity.X : e.PanGesture.Velocity.Y;
                float flickDisplacement = CalculateDisplacementFromVelocity(axisVelocity);

                Debug.WriteLineIf(LayoutDebugScrollableBase, "FlickDisplacement:" + flickDisplacement + "TotalDisplacementForPan:" + totalDisplacementForPan);
                OnScrollDragEnd();

                if (flickDisplacement > 0 | flickDisplacement < 0)// Flick detected
                {
                    Flick(flickDisplacement);
                }
                else
                {
                    // End of panning gesture but was not a flick
                    if (SnapToPage)
                    {
                        PageSnap();
                    }
                    else
                    {
                        ScrollBy(0, true);
                    }
                }
                totalDisplacementForPan = 0;

                Remove(mInterruptTouchingChild);
            }
        }

        private new void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (e.TapGesture.Type == Gesture.GestureType.Tap)
            {
                // Stop scrolling if tap detected (press then relase).
                // Unless in Pages mode, do not want a page change to stop part way.
                if(scrolling && !SnapToPage)
                {
                    StopScroll();
                }
            }
        }

        private void ScrollAnimationFinished(object sender, EventArgs e)
        {
            scrolling = false;
            OnScrollAnimationEnd();
        }


        protected virtual float AdjustScrollToChild(float position)
        {
            return position;
        }

    }

} // namespace
