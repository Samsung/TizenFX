/* Copyright (c) 2019-2025 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This class implements a absolute layout, allowing explicit positioning of children.
    /// Positions are from the top left of the layout and can be set using the View.Position and alike.
    /// </summary>
    public class AbsoluteLayout : LayoutGroup
    {
        /// <summary>
        /// A flag indicating that the width or height of the child view should be calculated based on the child view's WidthSpecification and HeightSpecification.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float LayoutBoundsAutoSized = -1f;

        /// <summary>
        /// The default constructor of AbsoluteLayout class
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AbsoluteLayout()
        {
        }

        /// <summary>
        /// Gets the layout bounds of the child view. The default layout bounds is 0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized.
        /// LayoutBoundsAutoSized for width and height calculates the child view's width and height based on the child view's WidthSpecification and HeightSpecification.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The layout bounds of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UIRect GetLayoutBounds(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            return view.GetAttached<LayoutParams>()?.LayoutBounds ?? new UIRect(0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized);
        }

        /// <summary>
        /// Sets the layout bounds of the child view. The default layout bounds is 0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized.
        /// LayoutBoundsAutoSized for width and height calculates the child view's width and height based on the child view's WidthSpecification and HeightSpecification.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="rect">The layout bounds.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetLayoutBounds(View view, UIRect rect)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var layoutParams = view.GetAttached<LayoutParams>();
            if (layoutParams != null)
            {
                layoutParams.LayoutBounds = rect;
            }
            else
            {
                view.SetAttached(new LayoutParams() { LayoutBounds = rect });
            }
        }

        /// <summary>
        /// Gets the absolute layout flags of the child view. The default absolute layout flags is <see cref="AbsoluteLayoutFlags.None"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The absolute layout flags of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AbsoluteLayoutFlags GetLayoutFlags(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            return view.GetAttached<LayoutParams>()?.LayoutFlags ?? AbsoluteLayoutFlags.None;
        }

        /// <summary>
        /// Sets the absolute layout flags of the child view. The default absolute layout flags is <see cref="AbsoluteLayoutFlags.None"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="flags">The absolute layout flags.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetLayoutFlags(View view, AbsoluteLayoutFlags flags)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var layoutParams = view.GetAttached<LayoutParams>();
            if (layoutParams != null)
            {
                layoutParams.LayoutFlags = flags;
            }
            else
            {
                view.SetAttached(new LayoutParams() { LayoutFlags = flags });
            }
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            var widthSpecSize = widthMeasureSpec.GetSize().AsDecimal();
            var newWidthSpecSize = Math.Max(Math.Min(widthSpecSize, Owner.GetMaximumWidth()), Owner.GetMinimumWidth());
            if (widthSpecSize != newWidthSpecSize)
            {
                widthMeasureSpec.SetSize(new LayoutLength(newWidthSpecSize));
            }

            var heightSpecSize = heightMeasureSpec.GetSize().AsDecimal();
            var newHeightSpecSize = Math.Max(Math.Min(heightSpecSize, Owner.GetMaximumHeight()), Owner.GetMinimumHeight());
            if (heightSpecSize != newHeightSpecSize)
            {
                heightMeasureSpec.SetSize(new LayoutLength(newHeightSpecSize));
            }

            // Ensure layout respects it's given minimum size
            float maxWidth = SuggestedMinimumWidth.AsDecimal();
            float maxHeight = SuggestedMinimumHeight.AsDecimal();

            MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
            MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout)
                {
                    continue;
                }

                var isBoundsSet = childLayout.Owner.GetAttached<LayoutParams>() != null;

                Extents childMargin = childLayout.Margin;
                var rect = GetLayoutBounds(childLayout.Owner);
                var flags = GetLayoutFlags(childLayout.Owner);

                // If child view does not use bounds, then padding and margin are not used.
                if (!isBoundsSet)
                {
                    MeasureChildWithoutPadding(childLayout, widthMeasureSpec, heightMeasureSpec);
                }
                else
                {
                    var isWidthProportional = flags.HasFlag(AbsoluteLayoutFlags.WidthProportional);
                    var isHeightProportional = flags.HasFlag(AbsoluteLayoutFlags.HeightProportional);

                    var measuredWidth = MeasureBoundsSize(rect.Width, isWidthProportional,
                                            widthMeasureSpec.GetSize().AsDecimal() - (Padding.Start + Padding.End),
                                            childMargin.Start + childMargin.End,
                                            childLayout.Owner.GetMinimumWidth(),
                                            childLayout.Owner.GetMaximumWidth());
                    var measuredHeight = MeasureBoundsSize(rect.Height, isHeightProportional,
                                            heightMeasureSpec.GetSize().AsDecimal() - (Padding.Top + Padding.Bottom),
                                            childMargin.Top + childMargin.Bottom,
                                            childLayout.Owner.GetMinimumHeight(),
                                            childLayout.Owner.GetMaximumHeight());

                    MeasureSpecification childWidthSpec;
                    if (rect.Width >= 0)
                    {
                        childWidthSpec = new MeasureSpecification(new LayoutLength(measuredWidth), MeasureSpecification.ModeType.Exactly);
                    }
                    else
                    {
                        childWidthSpec = GetChildMeasureSpecification(
                            new MeasureSpecification(
                                new LayoutLength(widthMeasureSpec.Size) - (childMargin.Start + childMargin.End),
                                widthMeasureSpec.Mode),
                            new LayoutLength(Padding.Start + Padding.End),
                            new LayoutLength(CalculateChildSpecSizeWidth(childLayout.Owner)));
                    }

                    MeasureSpecification childHeightSpec;
                    if (rect.Height >= 0)
                    {
                        childHeightSpec = new MeasureSpecification(new LayoutLength(measuredHeight), MeasureSpecification.ModeType.Exactly);
                    }
                    else
                    {
                        childHeightSpec = GetChildMeasureSpecification(
                            new MeasureSpecification(
                                new LayoutLength(heightMeasureSpec.Size) - (childMargin.Top + childMargin.Bottom),
                                heightMeasureSpec.Mode),
                            new LayoutLength(Padding.Top + Padding.End),
                            new LayoutLength(CalculateChildSpecSizeHeight(childLayout.Owner)));
                    }

                    childLayout.Measure(childWidthSpec, childHeightSpec);
                }

                // Determine the width and height needed by the children using their given position and size.
                // Children could overlap so find the right most child.
                float childRight;
                float childBottom;

                // If child view does not use bounds, then padding and margin are not used.
                if (!isBoundsSet)
                {
                    childRight = childLayout.MeasuredWidth.Size.AsDecimal() + childLayout.Owner.PositionX;
                    childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + childLayout.Owner.PositionY;
                }
                // Padding and margin are considered to decide parent size.
                // Proportional position does not affect the parent size.
                else
                {
                    if (flags.HasFlag(AbsoluteLayoutFlags.XProportional))
                        childRight = childLayout.MeasuredWidth.Size.AsDecimal() + Padding.Start + Padding.End + childMargin.Start + childMargin.End;
                    else
                        childRight = childLayout.MeasuredWidth.Size.AsDecimal() + Padding.Start + Padding.End + childMargin.Start + childMargin.End + rect.X;

                    if (flags.HasFlag(AbsoluteLayoutFlags.YProportional))
                        childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + Padding.Top + Padding.Bottom + childMargin.Top + childMargin.Bottom;
                    else
                        childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + Padding.Top + Padding.Bottom + childMargin.Top + childMargin.Bottom + rect.Y;
                }

                if (maxWidth < childRight)
                    maxWidth = childRight;

                if (maxHeight < childBottom)
                    maxHeight = childBottom;

                if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
            }

            // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
            maxWidth = Math.Max(Math.Min(maxWidth, Owner.GetMaximumWidth()), Owner.GetMinimumWidth());
            maxHeight = Math.Max(Math.Min(maxHeight, Owner.GetMaximumHeight()), Owner.GetMinimumHeight());

            SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(maxWidth), widthMeasureSpec, childWidthState),
                                  ResolveSizeAndState(new LayoutLength(maxHeight), heightMeasureSpec, childHeightState));
        }

        /// <summary>
        /// Assign a size and position to each of its children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            // Absolute layout positions it's children at their Actor positions.
            // Children could overlap or spill outside the parent, as is the nature of absolute positions.
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout)
                {
                    continue;
                }

                var isBoundsSet = childLayout.Owner.GetAttached<LayoutParams>() != null;

                Extents childMargin = childLayout.Margin;

                LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                LayoutLength childLeft;
                LayoutLength childTop;

                // If child view does not use bounds, then padding and margin are not used.
                if (!isBoundsSet)
                {
                    childLeft = new LayoutLength(childLayout.Owner.PositionX);
                    childTop = new LayoutLength(childLayout.Owner.PositionY);
                    childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, true);
                }
                else
                {
                    var rect = GetLayoutBounds(childLayout.Owner);
                    var flags = GetLayoutFlags(childLayout.Owner);
                    var isXProportional = flags.HasFlag(AbsoluteLayoutFlags.XProportional);
                    var isYProportional = flags.HasFlag(AbsoluteLayoutFlags.YProportional);

                    var childX = MeasureBoundsPosition(rect.X, isXProportional,
                                MeasuredWidth.Size.AsDecimal() - (Padding.Start + Padding.End),
                                childWidth.AsDecimal() + (childMargin.Start + childMargin.End),
                                Padding.Start, childMargin.Start);

                    var childY = MeasureBoundsPosition(rect.Y, isYProportional,
                                MeasuredHeight.Size.AsDecimal() - (Padding.Top + Padding.Bottom),
                                childHeight.AsDecimal() + (childMargin.Top + childMargin.Bottom),
                                Padding.Top, childMargin.Bottom);

                    childLeft = new LayoutLength(childX);
                    childTop = new LayoutLength(childY);

                    childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                }
            }
        }

        private float MeasureBoundsSize(float boundsValue, bool proportional, float constraint, float marginSum, float min, float max)
        {
            if (boundsValue < 0)
            {
                return 0;
            }

            if (proportional)
            {
                // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
                return Math.Max(Math.Min(Math.Max(0, constraint * boundsValue - marginSum), max), min);
            }

            // Margin does not affect to the fixed size set by user.
            // Only relative sizes such as MatchParent, WrapContent, proportional size are affected by margin.
            return boundsValue;
        }

        private float MeasureBoundsPosition(float boundsValue, bool proportional, float constraint, float sizeWithMargin, float paddingBegin, float marginBegin)
        {
            if (proportional)
            {
                return paddingBegin + ((constraint - sizeWithMargin) * boundsValue) + marginBegin;
            }
            else
            {
                return paddingBegin + boundsValue + marginBegin;
            }
        }

        private class LayoutParams
        {
            /// <summary>
            /// Constructs LayoutParams.
            /// </summary>
            public LayoutParams()
            {
            }

            /// <summary>
            /// Gets or sets the layout bounds of the view. The default layout bounds is 0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized.
            /// LayoutBoundsAutoSized for width and height calculates the view's width and height based on the view's WidthSpecification and HeightSpecification.
            /// </summary>
            public UIRect LayoutBounds
            {
                get;
                set;
            } = new UIRect(0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized);

            /// <summary>
            /// Gets or sets the absolute layout flags of the view. The default absolute layout flags is <see cref="AbsoluteLayoutFlags.None"/>.
            /// </summary>
            public AbsoluteLayoutFlags LayoutFlags
            {
                get;
                set;
            } = AbsoluteLayoutFlags.None;
        }
    }
} // namespace
