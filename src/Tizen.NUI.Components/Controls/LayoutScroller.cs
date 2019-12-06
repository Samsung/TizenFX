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
    public class LayoutScroller : CustomView
    {
	    static bool LayoutDebugScroller = true; // Debug flag

        private class ScrollerCustomLayout : LayoutGroup
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                float totalHeight = 0.0f;
                float totalWidth = 0.0f;

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                // measure children
                foreach( LayoutItem childLayout in LayoutChildren )
                {
                    if (childLayout != null)
                    {
                        // Get size of child
                        // Use an Unspecified MeasureSpecification mode so scrolling child is not restricted to it's parents size in Height (for vertical scrolling)
                        MeasureSpecification heightMeasureSpecUnrestricted = new MeasureSpecification( heightMeasureSpec.Size, MeasureSpecification.ModeType.Unspecified);
                        MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpecUnrestricted );
                        float childWidth = childLayout.MeasuredWidth.Size.AsDecimal();
                        float childHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                        // Determine the width and height needed by the children using their given position and size.
                        // Children could overlap so find the left most and right most child.
                        Position2D childPosition = childLayout.Owner.Position2D;
                        float childLeft = childPosition.X;
                        float childTop = childPosition.Y;

                        // Store current width and height needed to contain all children.
                        Extents padding = Padding;
                        Extents childMargin = childLayout.Margin;
                        totalWidth = childWidth + padding.Start + padding.End + childMargin.Start + childMargin.End;
                        totalHeight = childHeight + padding.Top + padding.Bottom + childMargin.Top + childMargin.Bottom;

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


                MeasuredSize widthSizeAndState = ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                MeasuredSize heightSizeAndState = ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
                totalWidth = widthSizeAndState.Size.AsDecimal();
                totalHeight = heightSizeAndState.Size.AsDecimal();

                // Ensure layout respects it's given minimum size
                totalWidth = Math.Max( totalWidth, SuggestedMinimumWidth.AsDecimal() );
                totalHeight = Math.Max( totalHeight, SuggestedMinimumHeight.AsDecimal() );

                widthSizeAndState.State = childWidthState;
                heightSizeAndState.State = childHeightState;

                SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(totalWidth), widthMeasureSpec, childWidthState ),
                                       ResolveSizeAndState( new LayoutLength(totalHeight), heightMeasureSpec, childHeightState ) );

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
        }

        /// <summary>
        /// [Draft] Configurable speed threshold that register the gestures as a flick.
        /// If the flick speed less than the threshold then will not be considered a flick.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public float FlickThreshold { get; set; } = 0.2f;

        /// <summary>
        /// [Draft] Configurable duration modifer for the flick animation. 
        /// Determines the speed of the scroll, large value results in a longer flick animation
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public float FlickAnimationDurationModifier { get; set; } = 0.4f;

        /// <summary>
        /// [Draft] Configurable modifer for the distance to be scrolled when flicked detected.
        /// It a ratio of the scroller's length. (not childs length).
        /// First value is the ratio of the distance to scroll with the weakest flick.
        /// Second value is the ratio of the distance to scroll with the strongest flick.
        /// Second > First.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public Vector2 FlickDistanceMultiplierRange { get; set; } = new Vector2(0.6f, 1.1f);

        /// <summary>
        /// [Draft] Horizontal scrolling mode.
        /// Sets the scrolling mode to horizontal.
        /// Default is Vertical.
        /// </summary>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        public bool HorizontalScrolling { set; get; } = false;

        private Animation scrollAnimation;
        private float maxScrollDistance;
        private float childTargetPosition = 0.0f;
        private PanGestureDetector mPanGestureDetector;
        private TapGestureDetector mTapGestureDetector;
        private View mScrollingChild;
        private float multiplier =1.0f;

        private bool Scrolling = false;

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LayoutScroller() : base(typeof(VisualView).FullName, CustomViewBehaviour.ViewBehaviourDefault | CustomViewBehaviour.RequiresTouchEventsSupport)
        {
            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            mTapGestureDetector = new TapGestureDetector();
            mTapGestureDetector.Attach(this);
            mTapGestureDetector.Detected += OnTapGestureDetected;

            ClippingMode = ClippingModeType.ClipToBoundingBox;

            mScrollingChild = new View();

            Layout = new ScrollerCustomLayout();
        }

        /// <summary>
        /// Add the child to scroll.
        /// </summary>
        /// <param name="child">View that should be scrolled.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public void AddLayoutToScroll(View child)
        {
            mScrollingChild = child;
            Add(mScrollingChild);
        }

        private void StopScroll()
        {
            if (scrollAnimation != null && scrollAnimation.State == Animation.States.Playing)
            {
                Debug.WriteLineIf(LayoutDebugScroller, "StopScroll Animation Playing");
                scrollAnimation.Stop(Animation.EndActions.Cancel);
            }
            scrollAnimation.Clear();
        }

        // static constructor registers the control type
        static LayoutScroller()
        {
            // ViewRegistry registers control type with DALi type registry
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(LayoutScroller));
        }

        internal static CustomView CreateInstance()
        {
            return new LayoutScroller();
        }

        private void OffsetChild(float displacement, bool animate)
        {
            float childCurrentPosition = HorizontalScrolling ? mScrollingChild.PositionX: mScrollingChild.PositionY;

            Debug.WriteLineIf(LayoutDebugScroller, "OffsetChild childCurrentPosition:" + childCurrentPosition +
                                                   " displacement:" + displacement,
                                                   " maxScrollDistance:" + maxScrollDistance );

            childTargetPosition = childCurrentPosition + displacement; // child current position + gesture displacement
            childTargetPosition = Math.Min(0,childTargetPosition);
            childTargetPosition = Math.Max(-maxScrollDistance,childTargetPosition);

            Debug.WriteLineIf( LayoutDebugScroller, "OffsetChild currentAxisPosition:" + childCurrentPosition + "childTargetPosition:" + childTargetPosition);

            if (animate)
            {
                if (scrollAnimation == null)
                {
                    scrollAnimation = new Animation();
                    scrollAnimation.Finished += ScrollAnimationFinished;
                }

                StopScroll(); // Will replace previous animation os stop existing one.

                float scrollDistance = 0.0f;
                if (childCurrentPosition < childTargetPosition)
                {
                    scrollDistance = Math.Abs(childCurrentPosition + childTargetPosition);
                }
                else
                {
                    scrollDistance = Math.Abs(childCurrentPosition - childTargetPosition);
                }

                int duration = 325 + (int)((scrollDistance * FlickAnimationDurationModifier));
                Debug.WriteLineIf(LayoutDebugScroller, "Scroll Animation Duration:" + duration + " Distance:" + scrollDistance);
                scrollAnimation.Duration = duration;
                scrollAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine);
                scrollAnimation.AnimateTo(mScrollingChild, (HorizontalScrolling) ? "PositionX" : "PositionY", childTargetPosition);
                scrollAnimation.Play();
            }
            else
            {
                // Set position of scrolling child without an animation
                if (HorizontalScrolling)
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

        private float CalculateDisplacementFromVelocity(Vector2 velocity)
        {
            // Map: flick speed of range (2.0 - 6.0) to flick multiplier of range (0.7 - 1.6) 
            float speedMinimum = FlickThreshold;
            float speedMaximum = FlickThreshold + 6.0f;
            float multiplierMinimum = FlickDistanceMultiplierRange.X;
            float multiplierMaximum = FlickDistanceMultiplierRange.Y;
            
            float flickDisplacement = 0.0f;
            float axisVelocity = (HorizontalScrolling) ? velocity.X : velocity.Y;

            float speed = Math.Min(4.0f,Math.Abs(axisVelocity));

            Debug.WriteLineIf(LayoutDebugScroller, "LayoutScroller Candidate Flick speed:" + speed);

            if (speed > FlickThreshold)
            {
                Scrolling = true;

                // Flick length is the length of the scroller.
                float flickLength = (HorizontalScrolling) ?CurrentSize.Width:CurrentSize.Height;

                // Calculate multiplier by mapping speed between the multiplier minimum and maximum.
                multiplier =( (speed - speedMinimum) / ( (speedMaximum - speedMinimum) * (multiplierMaximum - multiplierMinimum) ) )+ multiplierMinimum;

                // flick displacement is the product of the flick length and multiplier
                flickDisplacement = ((flickLength * multiplier) * speed) / axisVelocity;  // *speed and /velocity to perserve sign.

                Debug.WriteLineIf(LayoutDebugScroller, "Calculated FlickDisplacement[" + flickDisplacement +"] from speed[" + speed + "] multiplier:"
                                                        + multiplier);
            }
            return flickDisplacement;
        }

        private float CalculateMaximumScrollDistance()
        {
            int scrollingChildLength = 0;
            int scrollerLength = 0;
            if (HorizontalScrolling)
            {
                Debug.WriteLineIf(LayoutDebugScroller, "Horizontal");

                scrollingChildLength = (int)mScrollingChild.Layout.MeasuredWidth.Size.AsRoundedValue();
                scrollerLength = CurrentSize.Width; 
            }
            else
            {
                Debug.WriteLineIf(LayoutDebugScroller, "Vertical");
                scrollingChildLength = (int)mScrollingChild.Layout.MeasuredHeight.Size.AsRoundedValue();
                scrollerLength = CurrentSize.Height;
            }

            Debug.WriteLineIf(LayoutDebugScroller, "ScrollBy maxScrollDistance:" + (scrollingChildLength - scrollerLength) +
                                                   " parent length:" + scrollerLength +
                                                   " scrolling child length:" + scrollingChildLength);

            return scrollingChildLength - scrollerLength;
        }

        private void ScrollBy(float displacement, bool animate)
        {
            if (GetChildCount() == 0 || displacement == 0)
            {
                return;
            }

            OffsetChild(displacement, animate);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                if(Scrolling)
                {
                    StopScroll();
                }
                maxScrollDistance = CalculateMaximumScrollDistance();
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (HorizontalScrolling)
                {
                    ScrollBy(e.PanGesture.Displacement.X, false);
                }
                else
                {
                    ScrollBy(e.PanGesture.Displacement.Y, false);
                }
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                float flickDisplacement = CalculateDisplacementFromVelocity(e.PanGesture.Velocity);
                ScrollBy(flickDisplacement, true); // Animate flickDisplacement.
            }
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (e.TapGesture.Type == Gesture.GestureType.Tap)
            {
                // Stop scrolling if tap detected (press then relase).
                if(Scrolling)
                {
                    StopScroll();
                }
            }
        }

        private void ScrollAnimationFinished(object sender, EventArgs e)
        {
            Scrolling = false;
        }

    }

} // namespace
