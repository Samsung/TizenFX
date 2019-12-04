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
    /// [Draft] This class provides a View that can scroll a single View with a layout.
    /// </summary>
    internal class LayoutScroller : CustomView
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

        private Animation scrollAnimation;
        private float maxScrollDistance;
        private float childTargetPosition = 0.0f;
        private PanGestureDetector mPanGestureDetector;
        private TapGestureDetector mTapGestureDetector;
        private View mScrollingChild;

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

        public void AddLayoutToScroll(View child)
        {
            mScrollingChild = child;
            Add(mScrollingChild);
        }


        /// <summary>
        /// Scroll vertically by displacement pixels in screen coordinates.
        /// </summary>
        /// <param name="displacement">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public float ScrollVerticallyBy(float displacement)
        {
            Debug.WriteLineIf( LayoutDebugScroller, "ScrollVerticallyBy displacement:" + displacement);
            return ScrollBy(displacement, false);
        }

        internal void StopScroll()
        {
            if (scrollAnimation != null && scrollAnimation.State == Animation.States.Playing)
            {
                scrollAnimation.Stop(Animation.EndActions.Cancel);
                scrollAnimation.Clear();
            }
        }

        // static constructor registers the control type (for user can add kinds of visuals to it)
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

        public void OffsetChildVertically(float displacement, bool animate)
        {
            float previousTargetPosition = childTargetPosition;

            childTargetPosition = childTargetPosition + displacement;
            childTargetPosition = Math.Min(0,childTargetPosition);
            childTargetPosition = Math.Max(-maxScrollDistance,childTargetPosition);

            Debug.WriteLineIf( LayoutDebugScroller, "OffsetChildVertically currentYPosition:" + mScrollingChild.PositionY + "childTargetPosition:" + childTargetPosition);

            if (animate)
            {
                if (scrollAnimation == null)
                {
                    scrollAnimation = new Animation();
                    scrollAnimation.Finished += ScrollAnimationFinished;

                }
                else
                {
                    scrollAnimation.Stop(Animation.EndActions.StopFinal);
                    scrollAnimation.Clear();
                }


                scrollAnimation.Duration = (int)(Math.Abs(displacement*1.9));
                scrollAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
                scrollAnimation.AnimateTo(mScrollingChild, "PositionY", childTargetPosition);
                scrollAnimation.Play();
            }
            else
            {
                // Set position of scrolling child without an animation
                mScrollingChild.PositionY = childTargetPosition;
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

        private void ScrollWithVelocity(Vector2 velocity)
        {
            float speed = Math.Min(4.0f,Math.Abs(velocity.Y));
            float FlickThreshold = 1.2f;
            if (speed > FlickThreshold)
            {
                Scrolling = true;
                Debug.WriteLineIf( LayoutDebugScroller, "ScrollWithVelocity speed " + speed);
                float flickLength = (mScrollingChild.Layout.MeasuredHeight.Size.AsRoundedValue())/CurrentSize.Height;
                float flickDisplacement = flickLength*velocity.Y*speed;

                if (flickDisplacement>800)
                {
                    Console.WriteLine("BIG FLICK");
                }
                OffsetChildVertically(flickDisplacement, true);
            }
        }

        private float ScrollBy(float displacement, bool animate)
        {
            if (GetChildCount() == 0 || displacement == 0)
            {
                return 0;
            }

            int scrollingChildHeight = (int)mScrollingChild.Layout.MeasuredHeight.Size.AsRoundedValue();
            maxScrollDistance = scrollingChildHeight - CurrentSize.Height;

            Debug.WriteLineIf( LayoutDebugScroller, "ScrollBy maxScrollDistance:" + maxScrollDistance +
                                                    " parent length:" + CurrentSize.Height +
                                                    " scrolling child length:" + mScrollingChild.CurrentSize.Height);

            float absDisplacement = Math.Abs(displacement);

            OffsetChildVertically(displacement, animate);

            return absDisplacement;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                if(Scrolling)
                {
                    StopScroll();
                }
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                ScrollVerticallyBy(e.PanGesture.Displacement.Y);
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                ScrollWithVelocity(e.PanGesture.Velocity); // Animate scroll.
            }
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (e.TapGesture.Type == Gesture.GestureType.Tap)
            {
                // Stop scrolling if touch detected
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
