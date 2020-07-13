/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ScrollEventArgs is a class to record scroll event arguments which will sent to user.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class ScrollEventArgs : EventArgs
    {
        private Position position;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="position">Current scroll position</param>
        /// <since_tizen> 8 </since_tizen>
        public ScrollEventArgs(Position position)
        {
            this.position = position;
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
    }

    /// <summary>
    /// This class provides a View that can scroll a single View with a layout. This View can be a nest of Views.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
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
                foreach (LayoutItem childLayout in LayoutChildren)
                {
                    if (childLayout != null)
                    {
                        // Get size of child
                        // Use an Unspecified MeasureSpecification mode so scrolling child is not restricted to it's parents size in Height (for vertical scrolling)
                        // or Width for horizontal scrolling
                        MeasureSpecification unrestrictedMeasureSpec = new MeasureSpecification(heightMeasureSpec.Size, MeasureSpecification.ModeType.Unspecified);

                        if (scrollingDirection == Direction.Vertical)
                        {
                            MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), unrestrictedMeasureSpec, new LayoutLength(0));  // Height unrestricted by parent
                        }
                        else
                        {
                            MeasureChildWithMargins(childLayout, unrestrictedMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));  // Width unrestricted by parent
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
                        if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
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
                totalWidth = Math.Max(totalWidth, SuggestedMinimumWidth.AsDecimal());
                totalHeight = Math.Max(totalHeight, SuggestedMinimumHeight.AsDecimal());

                widthSizeAndState.State = childWidthState;
                heightSizeAndState.State = childHeightState;

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(totalWidth + Padding.Start + Padding.End), widthMeasureSpec, childWidthState),
                                       ResolveSizeAndState(new LayoutLength(totalHeight + Padding.Top + Padding.Bottom), heightMeasureSpec, childHeightState));

                // Size of ScrollableBase is changed. Change Page width too.
                scrollableBase.mPageWidth = (int)MeasuredWidth.Size.AsRoundedValue();
            }

            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                foreach (LayoutItem childLayout in LayoutChildren)
                {
                    if (childLayout != null)
                    {
                        LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                        LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                        Position2D childPosition = childLayout.Owner.Position2D;
                        Extents padding = Padding;
                        Extents childMargin = childLayout.Margin;

                        LayoutLength childLeft = new LayoutLength(childPosition.X + childMargin.Start + padding.Start);
                        LayoutLength childTop = new LayoutLength(childPosition.Y + childMargin.Top + padding.Top);

                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                    }
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
                return mScrollingDirection;
            }
            set
            {
                if (value != mScrollingDirection)
                {
                    mScrollingDirection = value;
                    mPanGestureDetector.RemoveDirection(value == Direction.Horizontal ?
                        PanGestureDetector.DirectionVertical : PanGestureDetector.DirectionHorizontal);
                    mPanGestureDetector.AddDirection(value == Direction.Horizontal ?
                        PanGestureDetector.DirectionHorizontal : PanGestureDetector.DirectionVertical);

                    ContentContainer.WidthSpecification = mScrollingDirection == Direction.Vertical ?
                        LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent;
                    ContentContainer.HeightSpecification = mScrollingDirection == Direction.Vertical ?
                        LayoutParamPolicies.WrapContent : LayoutParamPolicies.MatchParent;
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
        /// Pages mode, enables moving to the next or return to current page depending on pan displacement.
        /// Default is false.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool SnapToPage { set; get; } = false;

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
        public int ScrollDuration { set; get; } = 125;

        /// <summary>
        /// Scroll Available area.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Vector2 ScrollAvailableArea { set; get; }

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
        /// Scrollbar for ScrollableBase.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ScrollbarBase Scrollbar
        {
            get
            {
                return scrollBar;
            }
            set
            {
                if (scrollBar)
                {
                    scrollBar.Unparent();
                }

                scrollBar = value;
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

        /// <summary>
        /// Always hide Scrollbar.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool HideScrollbar
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
                return ContentContainer.Layout;
            }
            set
            {
                ContentContainer.Layout = value;
                if (ContentContainer.Layout != null)
                {
                    ContentContainer.Layout.SetPositionByLayout = false;
                }
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
                return decelerationRate;
            }
            set
            {
                decelerationRate = value;
                logValueOfDeceleration = (float)Math.Log(value);
            }
        }

        /// <summary>
        /// Threashold not to go infinit at the end of scrolling animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DecelerationThreshold { get; set; } = 0.1f;

        /// <summary>
        /// Page will be changed when velocity of panning is over threshold.
        /// The unit of threshold is pixel per milisec.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float PageFlickThreshold { get; set; } = 0.4f;

        /// <summary>
        /// Alphafunction for scroll animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction ScrollAlphaFunction { get; set; } = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);

        private bool hideScrollbar = true;
        private float maxScrollDistance;
        private float childTargetPosition = 0.0f;
        private PanGestureDetector mPanGestureDetector;
        private View mInterruptTouchingChild;
        private ScrollbarBase scrollBar;
        private bool scrolling = false;
        private float ratioOfScreenWidthToCompleteScroll = 0.5f;
        private float totalDisplacementForPan = 0.0f;
        private Size previousContainerSize = new Size();
        private PropertyNotification propertyNotification;
        private float noticeAnimationEndBeforePosition = 0.0f;
        private bool readyToNotice = false;

        /// <summary>
        /// Notice before animation is finished.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Let's consider more whether this needs to be set as protected.
        public float NoticeAnimationEndBeforePosition { get => noticeAnimationEndBeforePosition; set => noticeAnimationEndBeforePosition = value; }

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

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ScrollableBase() : base()
        {
            DecelerationRate = 0.998f;

            base.Layout = new ScrollableBaseCustomLayout();
            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            ClippingMode = ClippingModeType.ClipChildren;

            //Default Scrolling child
            ContentContainer = new View()
            {
                WidthSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.MatchParent : LayoutParamPolicies.WrapContent,
                HeightSpecification = ScrollingDirection == Direction.Vertical ? LayoutParamPolicies.WrapContent : LayoutParamPolicies.MatchParent,
                Layout = new AbsoluteLayout() { SetPositionByLayout = false },
            };
            ContentContainer.Relayout += OnScrollingChildRelayout;
            propertyNotification = ContentContainer.AddPropertyNotification("position", PropertyCondition.Step(1.0f));
            propertyNotification.Notified += OnPropertyChanged;
            base.Add(ContentContainer);

            //Interrupt touching when panning is started
            mInterruptTouchingChild = new View()
            {
                Size = new Size(Window.Instance.WindowSize),
                BackgroundColor = Color.Transparent,
            };
            mInterruptTouchingChild.TouchEvent += OnIterruptTouchingChildTouched;
            Scrollbar = new Scrollbar();
        }

        private bool OnIterruptTouchingChildTouched(object source, View.TouchEventArgs args)
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
            if (SnapToPage && CurrentPage == Children.IndexOf(view) && CurrentPage == Children.Count - 1)
            {
                // Target View is current page and also last child.
                // CurrentPage should be changed to previous page.
                CurrentPage = Math.Max(0, CurrentPage - 1);
                ScrollToIndex(CurrentPage);
            }

            ContentContainer.Remove(view);
        }

        private void OnScrollingChildRelayout(object source, EventArgs args)
        {
            // Size is changed. Calculate maxScrollDistance.
            bool isSizeChanged = previousContainerSize.Width != ContentContainer.Size.Width || previousContainerSize.Height != ContentContainer.Size.Height;

            if (isSizeChanged)
            {
                maxScrollDistance = CalculateMaximumScrollDistance();
                SetScrollbar();
            }

            previousContainerSize = ContentContainer.Size;
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
                Scrollbar.Initialize(contentLength, viewportLength, currentPosition, isHorizontal);
            }
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

        private void OnScrollDragStarted()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollDragStarted?.Invoke(this, eventArgs);
        }

        private void OnScrollDragEnded()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollDragEnded?.Invoke(this, eventArgs);
        }

        private void OnScrollAnimationStarted()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollAnimationStarted?.Invoke(this, eventArgs);
        }

        private void OnScrollAnimationEnded()
        {
            scrolling = false;
            base.Remove(mInterruptTouchingChild);

            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            ScrollAnimationEnded?.Invoke(this, eventArgs);
        }

        private void OnScroll()
        {
            ScrollEventArgs eventArgs = new ScrollEventArgs(ContentContainer.CurrentPosition);
            Scrolling?.Invoke(this, eventArgs);

            bool isHorizontal = ScrollingDirection == Direction.Horizontal;
            float contentLength = isHorizontal ? ContentContainer.Size.Width : ContentContainer.Size.Height;
            float currentPosition = isHorizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y;

            scrollBar.Update(contentLength, Math.Abs(currentPosition));
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
                // Calculate scroll animaton duration
                float scrollDistance = Math.Abs(displacement);
                readyToNotice = true;

                AnimateChildTo(ScrollDuration, BoundScrollPosition(AdjustTargetPositionOfScrollAnimation(BoundScrollPosition(childTargetPosition))));
            }
            else
            {
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

            if (type == DisposeTypes.Explicit)
            {
                StopScroll();

                if (mPanGestureDetector != null)
                {
                    mPanGestureDetector.Detected -= OnPanGestureDetected;
                    mPanGestureDetector.Dispose();
                    mPanGestureDetector = null;
                }
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
            float destinationX = -(Children[CurrentPage].Position.X + Children[CurrentPage].CurrentSize.Width / 2 - CurrentSize.Width / 2); // set to middle of current page
            Debug.WriteLineIf(LayoutDebugScrollableBase, "Snapping to page[" + CurrentPage + "] to:" + destinationX + " from:" + ContentContainer.PositionX);
            AnimateChildTo(ScrollDuration, destinationX);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (SnapToPage && scrollAnimation != null && scrollAnimation.State == Animation.States.Playing)
            {
                return;
            }

            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                readyToNotice = false;
                base.Add(mInterruptTouchingChild);
                Debug.WriteLineIf(LayoutDebugScrollableBase, "Gesture Start");
                if (scrolling && !SnapToPage)
                {
                    StopScroll();
                }
                totalDisplacementForPan = 0.0f;
                OnScrollDragStarted();
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
                OnScrollDragEnded();
                StopScroll(); // Will replace previous animation so will stop existing one.

                if (scrollAnimation == null)
                {
                    scrollAnimation = new Animation();
                    scrollAnimation.Finished += ScrollAnimationFinished;
                }

                float panVelocity = (ScrollingDirection == Direction.Horizontal) ? e.PanGesture.Velocity.X : e.PanGesture.Velocity.Y;

                if(panVelocity != 0 || SnapToPage)
                {
                    if (SnapToPage)
                    {
                        PageSnap(panVelocity);
                    }
                    else
                    {
                        Decelerating(panVelocity, scrollAnimation);
                    }

                    totalDisplacementForPan = 0;
                    scrolling = true;
                    readyToNotice = true;
                    OnScrollAnimationStarted();
                }
            }
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
            // Decelerating using deceleration equation ===========
            //
            // V   : velocity (pixel per milisecond)
            // V0  : initial velocity
            // d   : deceleration rate,
            // t   : time
            // X   : final position after decelerating
            // log : natural logarithm
            //
            // V(t) = V0 * d pow t;
            // X(t) = V0 * (d pow t - 1) / log d;  <-- Integrate the velocity function
            // X(∞) = V0 * d / (1 - d); <-- Result using inifit T can be final position because T is tending to infinity.
            //
            // Because of final T is tending to inifity, we should use threshold value to finish.
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

    }

} // namespace
