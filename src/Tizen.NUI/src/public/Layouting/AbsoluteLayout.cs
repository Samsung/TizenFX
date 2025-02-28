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
using System.Collections.Generic;
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
        private static Dictionary<View, UIRect> boundsMap = null;
        private static Dictionary<View, AbsoluteLayoutFlags> flagsMap = null;
        private static Dictionary<View, (float, float)> positionCache = null;

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

        static AbsoluteLayout()
        {
            boundsMap = new Dictionary<View, UIRect>();
            flagsMap = new Dictionary<View, AbsoluteLayoutFlags>();
            positionCache = new Dictionary<View, (float, float)>();
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

            if (boundsMap.TryGetValue(view, out var bounds))
            {
                return bounds;
            }
            else
            {
                return new UIRect(0, 0, LayoutBoundsAutoSized, LayoutBoundsAutoSized);
            }
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
            boundsMap[view] = rect;
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

            if (flagsMap.TryGetValue(view, out var flags))
            {
                return flags;
            }
            else
            {
                return AbsoluteLayoutFlags.None;
            }
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
            flagsMap[view] = flags;
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
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

                Extents childMargin = childLayout.Margin;
                var isBoundsSet = boundsMap.ContainsKey(childLayout.Owner);
                var rect = GetLayoutBounds(childLayout.Owner);
                var flags = GetLayoutFlags(childLayout.Owner);

                // If child view positions with using pivot point, then padding and margin are not used.
                if (childLayout.Owner.PositionUsesPivotPoint)
                {
                    MeasureChildWithoutPadding(childLayout, widthMeasureSpec, heightMeasureSpec);
                }
                else
                {
                    var isWidthProportional = flags.HasFlag(AbsoluteLayoutFlags.WidthProportional);
                    var isHeightProportional = flags.HasFlag(AbsoluteLayoutFlags.HeightProportional);

                    var measuredWidth = MeasureBoundsSize(rect.Width, isWidthProportional,
                                            widthMeasureSpec.GetSize().AsDecimal() - (Padding.Start + Padding.End),
                                            childMargin.Start + childMargin.End);
                    var measuredHeight = MeasureBoundsSize(rect.Height, isHeightProportional,
                                            heightMeasureSpec.GetSize().AsDecimal() - (Padding.Top + Padding.Bottom),
                                            childMargin.Top + childMargin.Bottom);

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
                            new LayoutLength(childLayout.Owner.LayoutWidth));
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
                            new LayoutLength(childLayout.Owner.LayoutHeight));
                    }

                    childLayout.Measure(childWidthSpec, childHeightSpec);
                }

                // Determine the width and height needed by the children using their given position and size.
                // Children could overlap so find the right most child.
                float childRight;
                float childBottom;

                // Clear the cache calculated previously.
                positionCache.Remove(childLayout.Owner);

                 // If child view positions with using pivot point, then padding and margin are not used.
                if (childLayout.Owner.PositionUsesPivotPoint)
                {
                    childRight = childLayout.MeasuredWidth.Size.AsDecimal() + childLayout.Owner.PositionX;
                    childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + childLayout.Owner.PositionY;

                    positionCache[childLayout.Owner] = (childLayout.Owner.PositionX, childLayout.Owner.PositionY);
                }
                else
                {
                    var childWidth = childLayout.MeasuredWidth.Size.AsDecimal();
                    var childHeight = childLayout.MeasuredHeight.Size.AsDecimal();
                    var isXProportional = flags.HasFlag(AbsoluteLayoutFlags.XProportional);
                    var isYProportional = flags.HasFlag(AbsoluteLayoutFlags.YProportional);

                    // Determine the width and height needed by the children using their given position and size.
                    // Children could overlap so find the right most child.
                    var childX = MeasurePosition(isBoundsSet, childLayout.Owner.PositionX, rect.X, isXProportional,
                                Owner.SizeWidth - (Padding.Start + Padding.End),
                                childWidth + (childMargin.Start + childMargin.End),
                                Padding.Start, childMargin.Start);

                    var childY = MeasurePosition(isBoundsSet, childLayout.Owner.PositionY, rect.Y, isYProportional,
                                Owner.SizeHeight - (Padding.Top + Padding.Bottom),
                                childHeight + (childMargin.Top + childMargin.Bottom),
                                Padding.Top, childMargin.Bottom);

                    childRight = childWidth + childX;
                    childBottom = childHeight + childY;

                    positionCache[childLayout.Owner] = (childX, childY);
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

                Extents childMargin = childLayout.Margin;

                LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                LayoutLength childLeft;
                LayoutLength childTop;

                // Use the cached position calculated during measure phase.
                if (positionCache.TryGetValue(childLayout.Owner, out var cachedPosition))
                {
                    childLeft = new LayoutLength(cachedPosition.Item1);
                    childTop = new LayoutLength(cachedPosition.Item2);

                    // If child view positions with using pivot point, then padding and margin are not used.
                    if (childLayout.Owner.PositionUsesPivotPoint)
                    {
                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, true);
                    }
                    else
                    {
                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                    }
                }
                else
                {
                    // If child view positions with using pivot point, then padding and margin are not used.
                    if (childLayout.Owner.PositionUsesPivotPoint)
                    {
                        childLeft = new LayoutLength(childLayout.Owner.PositionX);
                        childTop = new LayoutLength(childLayout.Owner.PositionY);
                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, true);
                    }
                    else
                    {
                        var isBoundsSet = boundsMap.ContainsKey(childLayout.Owner);
                        var rect = GetLayoutBounds(childLayout.Owner);
                        var flags = GetLayoutFlags(childLayout.Owner);
                        var isXProportional = flags.HasFlag(AbsoluteLayoutFlags.XProportional);
                        var isYProportional = flags.HasFlag(AbsoluteLayoutFlags.YProportional);

                        var childX = MeasurePosition(isBoundsSet, childLayout.Owner.PositionX, rect.X, isXProportional,
                                    Owner.SizeWidth - (Padding.Start + Padding.End),
                                    childWidth.AsDecimal() + (childMargin.Start + childMargin.End),
                                    Padding.Start, childMargin.Start);

                        var childY = MeasurePosition(isBoundsSet, childLayout.Owner.PositionY, rect.Y, isYProportional,
                                    Owner.SizeHeight - (Padding.Top + Padding.Bottom),
                                    childHeight.AsDecimal() + (childMargin.Top + childMargin.Bottom),
                                    Padding.Top, childMargin.Bottom);

                        childLeft = new LayoutLength(childX);
                        childTop = new LayoutLength(childY);

                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                    }
                }
            }
        }

        private float MeasureBoundsSize(float boundsValue, bool proportional, float constraint, float marginSum)
        {
            if (boundsValue < 0)
            {
                return 0;
            }

            if (proportional)
            {
                return Math.Max(0, constraint * boundsValue - marginSum);
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

        private float MeasurePosition(bool isBoundsSet, float position, float boundsValue, bool proportional, float constraint, float sizeWithMargin, float paddingBegin, float marginBegin)
        {
            // If user sets LayoutBounds, use LayoutBounds. Otherwise, use Position property.
            if (isBoundsSet)
            {
                return MeasureBoundsPosition(boundsValue, proportional, constraint, sizeWithMargin, paddingBegin, marginBegin);
            }
            else
            {
                return paddingBegin + position + marginBegin;
            }
        }
    }
} // namespace
