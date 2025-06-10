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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI
{
    /// <summary>
    /// This class implements a linear box layout, automatically handling right to left or left to right direction change.
    /// </summary>
    public class LinearLayout : LayoutGroup
    {
        private Alignment linearAlignment = Alignment.Top;

        /// <summary>
        /// Enumeration for the direction in which the content is laid out
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum Orientation
        {
            /// <summary>
            /// Horizontal (row)
            /// </summary>
            Horizontal,
            /// <summary>
            /// Vertical (column)
            /// </summary>
            Vertical
        }

        /// <summary>
        /// Enumeration for the alignment of the linear layout items
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use HorizontalAlignment and VerticalAlignment instead.")]
        public enum Alignment
        {
            /// <summary>
            /// At the left/right edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            Begin = 0x1,
            /// <summary>
            /// At the right/left edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            End = 0x2,
            /// <summary>
            /// At the horizontal center of the container
            /// </summary>
            CenterHorizontal = 0x4,
            /// <summary>
            /// At the top edge of the container
            /// </summary>
            Top = 0x8,
            /// <summary>
            /// At the bottom edge of the container
            /// </summary>
            Bottom = 0x10,
            /// <summary>
            /// At the vertical center of the container
            /// </summary>
            CenterVertical = 0x20,
            /// <summary>
            /// At the vertical and horizontal center of the container
            /// </summary>
            Center = 0x40
        }

        struct HeightAndWidthState
        {
            public MeasuredSize.StateType widthState;
            public MeasuredSize.StateType heightState;

            public HeightAndWidthState(MeasuredSize.StateType width, MeasuredSize.StateType height)
            {
                widthState = width;
                heightState = height;
            }
        }

        /// <summary>
        /// Get/Set the orientation in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LinearLayout.Orientation LinearOrientation
        {
            get
            {
                return linearOrientation;
            }
            set
            {
                linearOrientation = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// Get/Set the padding between cells in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size2D CellPadding
        {
            get
            {
                if (cellPadding == null)
                {
                    cellPadding = new Size2D(0, 0);
                }

                return cellPadding;
            }
            set
            {
                cellPadding = value;
                RequestLayout();
            }
        }


        /// <summary>
        /// Get/Set the alignment in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use HorizontalAlignment and VerticalAlignment properties instead.")]
        public LinearLayout.Alignment LinearAlignment
        {
            get
            {
                return linearAlignment;
            }

            set
            {
                if (linearAlignment == value)
                {
                    return;
                }

                linearAlignment = value;

                switch (linearAlignment)
                {
                    case Alignment.Begin:
                        HorizontalAlignment = HorizontalAlignment.Begin;
                        break;
                    case Alignment.End:
                        HorizontalAlignment = HorizontalAlignment.End;
                        break;
                    case Alignment.CenterHorizontal:
                        HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case Alignment.Top:
                        VerticalAlignment = VerticalAlignment.Top;
                        break;
                    case Alignment.Bottom:
                        VerticalAlignment = VerticalAlignment.Bottom;
                        break;
                    case Alignment.CenterVertical:
                        VerticalAlignment = VerticalAlignment.Center;
                        break;
                    case Alignment.Center:
                        HorizontalAlignment = HorizontalAlignment.Center;
                        VerticalAlignment = VerticalAlignment.Center;
                        break;
                    default:
                        break;
                }
            }
         }

        /// <summary>
        /// Get/Set the horizontal alignment in the layout
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Begin;

        /// <summary>
        /// Get/Set the vertical alignment in the layout
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Top;

        private Size2D cellPadding = new Size2D(0, 0);
        private Orientation linearOrientation = Orientation.Horizontal;

        /// <summary>
        /// Default constructor of LinearLayout class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LinearLayout()
        {
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            if (linearOrientation == Orientation.Horizontal)
            {
                MeasureHorizontal(widthMeasureSpec, heightMeasureSpec);
            }
            else
            {
                MeasureVertical(widthMeasureSpec, heightMeasureSpec);
            }
        }

        /// <summary>
        /// Layout should assign a size and position to each of its children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            if (linearOrientation == Orientation.Horizontal)
            {
                LayoutHorizontal(left, top, right, bottom);
            }
            else
            {
                LayoutVertical(left, top, right, bottom);
            }
        }

        private void MeasureWeightedChild(LayoutItem childLayout, float totalWeightLength, float totalWeight, float childWeight,
                                          MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec,
                                          HeightAndWidthState childState, Orientation orientation)
        {
            bool horizontal = false;
            if (orientation == Orientation.Horizontal)
            {
                horizontal = true;
            }

            float childsShare = totalWeightLength * (childWeight / totalWeight);
            var desiredWidth = childLayout.Owner.LayoutWidth;
            var desiredHeight = childLayout.Owner.LayoutHeight;

            MeasureSpecification childWidthMeasureSpec;
            MeasureSpecification childHeightMeasureSpec;

            if (horizontal)
            {
                childWidthMeasureSpec = new MeasureSpecification(new LayoutLength(childsShare - (childLayout.Margin.Start + childLayout.Margin.End)), MeasureSpecification.ModeType.Exactly);

                childHeightMeasureSpec = GetChildMeasureSpecification(
                                            new MeasureSpecification(
                                                new LayoutLength(heightMeasureSpec.GetSize() - (childLayout.Margin.Top + childLayout.Margin.Bottom)),
                                                heightMeasureSpec.GetMode()),
                                            new LayoutLength(Padding.Top + Padding.Bottom),
                                            new LayoutLength(desiredHeight));
            }
            else // vertical
            {
                childWidthMeasureSpec = GetChildMeasureSpecification(
                                            new MeasureSpecification(
                                                new LayoutLength(widthMeasureSpec.GetSize() - (childLayout.Margin.Start + childLayout.Margin.End)),
                                                widthMeasureSpec.GetMode()),
                                            new LayoutLength(Padding.Start + Padding.End),
                                            new LayoutLength(desiredWidth));

                childHeightMeasureSpec = new MeasureSpecification(new LayoutLength(childsShare - (childLayout.Margin.Top + childLayout.Margin.Bottom)), MeasureSpecification.ModeType.Exactly);
            }

            childLayout.Measure(childWidthMeasureSpec, childHeightMeasureSpec);

            // Child may now not fit in horizontal dimension.
            if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
            {
                childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
            }

            // Child may now not fit in vertical dimension.
            if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
            {
                childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
            }
        }

        private void MeasureHorizontal(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
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

            var widthMode = widthMeasureSpec.GetMode();
            var heightMode = heightMeasureSpec.GetMode();
            bool isWidthExactly = (widthMode == MeasureSpecification.ModeType.Exactly);
            bool isHeightExactly = (heightMode == MeasureSpecification.ModeType.Exactly);
            float maxHeight = 0.0f;
            float totalWeight = 0.0f;
            int childrenCount = IterateLayoutChildren().Count();

            // Child layout, which wants to match its width to its parent's remaining width, is either following 1 or 2.
            // 1. Child layout whose Owner.LayoutWidth is LayoutDimension.MatchParent.
            // 2. Child layout whose Owner.LayoutWidth is 0 and Owner.Weight is greater than 0.
            // The number of child layout which wants to match its width to its parent's remaining width.
            int childrenMatchParentCount = 0;
            int childrenWrapContentCount = 0;

            var totalLength = 0.0f;

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            // 1ST PHASE:
            //
            // We measure all children whose width specification policy is WrapContent without weight.
            // After 1st phase, remaining width of parent is accumulated to calculate width of children
            // whose width specification policy is MatchParent.
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                {
                    continue;
                }
                var childDesiredWidth = childLayout.Owner.LayoutWidth;
                var childDesiredHeight = childLayout.Owner.LayoutHeight;
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                float childMarginWidth = childMargin.Start + childMargin.End;
                bool useRemainingWidth = (childDesiredWidth == 0) && (childWeight > 0);

                if ((childDesiredWidth == LayoutDimension.MatchParent) || (useRemainingWidth))
                {
                    totalWeight += childWeight;
                    childrenMatchParentCount++;
                }

                // MatchParent child layout's margin is not added to totalLength.
                // Consequently, MatchParent child layout's margin is added to remaining size,
                // so the margin is not shared with other MatchParent child layouts.
                // e.g.
                // LinearLayout has size 100.
                // Child layout1 is MatchParent and its margin is 20. (This margin is not ad
                // Child layout2 is MatchParent and its margin is 0.
                // Then, child layout1's size is 30 and child layout2's size is 50.
                if ((childDesiredWidth == LayoutDimension.WrapContent) || ((childDesiredWidth >= 0) && (!useRemainingWidth)))
                {
                    var measurableWidth = Math.Max(widthMeasureSpec.GetSize().AsDecimal() - (totalLength + CellPadding.Width * childrenWrapContentCount), 0);
                    var measurableWidthSpec = new MeasureSpecification(new LayoutLength(measurableWidth), widthMeasureSpec.GetMode());
                    MeasureChildWithMargins(childLayout, measurableWidthSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));

                    float childMeasuredWidth = childLayout.MeasuredWidth.Size.AsDecimal();

                    if (childMeasuredWidth < 0)
                    {
                        totalLength = Math.Max(totalLength, totalLength + childMarginWidth);
                    }
                    else
                    {
                        totalLength = Math.Max(totalLength, totalLength + childMeasuredWidth + childMarginWidth);
                    }

                    childrenWrapContentCount++;
                }

                if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
            } // 1ST PHASE foreach

            totalLength = Math.Max(totalLength, totalLength + CellPadding.Width * (childrenCount - 1) + Padding.Start + Padding.End);
            float widthSize = Math.Max(totalLength, SuggestedMinimumWidth.AsDecimal());
            MeasuredSize widthSizeAndState = ResolveSizeAndState(new LayoutLength(widthSize), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            widthSize = widthSizeAndState.Size.AsDecimal();

            float remainingWidth = widthSize - totalLength;
            float totalWeightLength = 0.0f;

            if (remainingWidth > 0)
            {
                // 2ND PHASE:
                //
                // We measure all children whose width specification policy is MatchParent without weight.
                // After 2nd phase, all children's widths are calculated without considering weight.
                // And the widths of all weighted children are accumulated to calculate weighted width.
                foreach (var childLayout in LayoutChildren)
                {
                    if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                    {
                        continue;
                    }
                    var childDesiredWidth = childLayout.Owner.LayoutWidth;
                    var childDesiredHeight = childLayout.Owner.LayoutHeight;
                    float childWeight = childLayout.Owner.Weight;
                    Extents childMargin = childLayout.Margin;
                    bool useRemainingWidth = (childDesiredWidth == 0) && (childWeight > 0);
                    bool needToMeasure = false;

                    if ((childDesiredWidth == LayoutDimension.MatchParent) || (useRemainingWidth))
                    {
                        if (isWidthExactly)
                        {
                            // In MeasureChildWithMargins(), it is assumed that widthMeasureSpec includes Padding.Start and Padding.End.
                            // Therefore, Padding.Start and Padding.End are added to widthMeasureSpec.GetSize() before it is passed to MeasureChildWithMargins().
                            widthMeasureSpec.SetSize(new LayoutLength((int)(remainingWidth / childrenMatchParentCount) + Padding.Start + Padding.End));
                            needToMeasure = true;
                        }
                        // RelativeLayout's MatchParent children should not fill to the RelativeLayout.
                        // Because the children's sizes and positions are calculated by RelativeLayout's APIs.
                        // Therefore, not to fill the RelativeLayout, the mode is changed from Exactly to AtMost.
                        //
                        // Not to print the recursive reference error message for this case, Specification is checked if it is WrapContent.
                        else if (Owner.LayoutWidth == LayoutDimension.WrapContent)
                        {
                            if (childDesiredWidth == LayoutDimension.MatchParent)
                            {
                                Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutWidth is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutWidth is MatchParent!");
                            }
                            else
                            {
                                Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutWidth is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutWidth is 0 with positive weight!");
                            }
                        }
                    }

                    if (needToMeasure == true)
                    {
                        MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
                    }

                    if ((childWeight > 0) && ((childDesiredWidth == LayoutDimension.MatchParent) || (childDesiredWidth == 0)))
                    {
                        float childMeasuredWidth = childLayout.MeasuredWidth.Size.AsDecimal();

                        if (childMeasuredWidth < 0)
                        {
                            totalWeightLength = Math.Max(totalWeightLength, totalWeightLength + childMargin.Start + childMargin.End);
                        }
                        else
                        {
                            totalWeightLength = Math.Max(totalWeightLength, totalWeightLength + childMeasuredWidth + childMargin.Start + childMargin.End);
                        }
                    }
                } // 2ND PHASE foreach

                // 3RD PHASE:
                //
                // We measure all weighted children whose owner has weight greater than 0.
                // After 3rd phase, all weighted children has width which is proportional to their weights
                // in remaining width of parent.
                if (totalWeight > 0.0f)
                {
                    foreach (LayoutItem childLayout in LayoutChildren)
                    {
                        if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                        {
                            continue;
                        }
                        var childDesiredWidth = childLayout.Owner.LayoutWidth;
                        float childWeight = childLayout.Owner.Weight;

                        if ((childWeight > 0) && ((childDesiredWidth == LayoutDimension.MatchParent) || (childDesiredWidth == 0)))
                        {
                            if (isWidthExactly)
                            {
                                MeasureWeightedChild(childLayout, totalWeightLength, totalWeight, childWeight,
                                                    widthMeasureSpec, heightMeasureSpec, childState,
                                                    Orientation.Horizontal);
                            }
                            // RelativeLayout's MatchParent children should not fill to the RelativeLayout.
                            // Because the children's sizes and positions are calculated by RelativeLayout's APIs.
                            // Therefore, not to fill the RelativeLayout, the mode is changed from Exactly to AtMost.
                            //
                            // Not to print the recursive reference error message for this case, Specification is checked if it is WrapContent.
                            else if (Owner.LayoutWidth == LayoutDimension.WrapContent)
                            {
                                if (childDesiredWidth == LayoutDimension.MatchParent)
                                {
                                    Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutWidth is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutWidth is MatchParent!");
                                }
                                else
                                {
                                    Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutWidth is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutWidth is 0 with positive weight!");
                                }
                            }
                        }
                    }
                } // 3RD PHASE foreach
            }

            // Decide the max height among children.
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                {
                    continue;
                }

                Extents childMargin = childLayout.Margin;
                float childMarginHeight = childMargin.Top + childMargin.Bottom;
                float childMeasuredHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                if (childMeasuredHeight < 0)
                {
                    maxHeight = Math.Max(maxHeight, childMarginHeight);
                }
                else
                {
                    maxHeight = Math.Max(maxHeight, childMeasuredHeight + childMarginHeight);
                }
            }

            // Decide the max height compared with paddings and its suggested height.
            maxHeight = Math.Max(maxHeight, maxHeight + (Padding.Top + Padding.Bottom));
            maxHeight = Math.Max(maxHeight, SuggestedMinimumHeight.AsRoundedValue());

            widthSizeAndState.State = childState.widthState;

            SetMeasuredDimensions(widthSizeAndState,
                                  ResolveSizeAndState(new LayoutLength(maxHeight), heightMeasureSpec, childState.heightState));
        } // MeasureHorizontal

        private void MeasureVertical(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
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

            var widthMode = widthMeasureSpec.GetMode();
            var heightMode = heightMeasureSpec.GetMode();
            bool isWidthExactly = (widthMode == MeasureSpecification.ModeType.Exactly);
            bool isHeightExactly = (heightMode == MeasureSpecification.ModeType.Exactly);
            float maxWidth = 0.0f;
            float totalWeight = 0.0f;
            int childrenCount = IterateLayoutChildren().Count();

            // Child layout, which wants to match its height to its parent's remaining height, is either following 1 or 2.
            // 1. Child layout whose Owner.LayoutHeight is LayoutDimension.MatchParent.
            // 2. Child layout whose Owner.LayoutHeight is 0 and Owner.Weight is greater than 0.
            // The number of child layout which wants to match its height to its parent's remaining height.
            int childrenMatchParentCount = 0;
            int childrenWrapContentCount = 0;

            var totalLength = 0.0f;

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            // 1ST PHASE:
            //
            // We measure all children whose height specification policy is WrapContent without weight.
            // After 1st phase, remaining height of parent is accumulated to calculate height of children
            // whose height specification policy is MatchParent.
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                {
                    continue;
                }
                var childDesiredWidth = childLayout.Owner.LayoutWidth;
                var childDesiredHeight = childLayout.Owner.LayoutHeight;
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                float childMarginHeight = childMargin.Top + childMargin.Bottom;
                bool useRemainingHeight = (childDesiredHeight == 0) && (childWeight > 0);

                if ((childDesiredHeight == LayoutDimension.MatchParent) || (useRemainingHeight))
                {
                    totalWeight += childWeight;
                    childrenMatchParentCount++;
                }

                // MatchParent child layout's margin is not added to totalLength.
                // Consequently, MatchParent child layout's margin is added to remaining size,
                // so the margin is not shared with other MatchParent child layouts.
                // e.g.
                // LinearLayout has size 100.
                // Child layout1 is MatchParent and its margin is 20. (This margin is not ad
                // Child layout2 is MatchParent and its margin is 0.
                // Then, child layout1's size is 30 and child layout2's size is 50.
                if ((childDesiredHeight == LayoutDimension.WrapContent) || ((childDesiredHeight >= 0) && (!useRemainingHeight)))
                {
                    var measurableHeight = Math.Max(heightMeasureSpec.GetSize().AsDecimal() - (totalLength + CellPadding.Height * childrenWrapContentCount), 0);
                    var measurableHeightSpec = new MeasureSpecification(new LayoutLength(measurableHeight), heightMeasureSpec.GetMode());
                    MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), measurableHeightSpec, new LayoutLength(0));

                    float childMeasuredHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                    if (childMeasuredHeight < 0)
                    {
                        totalLength = Math.Max(totalLength, totalLength + childMarginHeight);
                    }
                    else
                    {
                        totalLength = Math.Max(totalLength, totalLength + childMeasuredHeight + childMarginHeight);
                    }

                    childrenWrapContentCount++;
                }

                if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
            } // 1ST PHASE foreach

            totalLength = Math.Max(totalLength, totalLength + CellPadding.Height * (childrenCount - 1) + Padding.Top + Padding.Bottom);
            float heightSize = Math.Max(totalLength, SuggestedMinimumHeight.AsDecimal());
            MeasuredSize heightSizeAndState = ResolveSizeAndState(new LayoutLength(heightSize), heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            heightSize = heightSizeAndState.Size.AsDecimal();

            float remainingHeight = heightSize - totalLength;
            float totalWeightLength = 0.0f;

            if (remainingHeight > 0)
            {
                // 2ND PHASE:
                //
                // We measure all children whose height specification policy is MatchParent without weight.
                // After 2nd phase, all children's heights are calculated without considering weight.
                // And the heights of all weighted children are accumulated to calculate weighted height.
                foreach (var childLayout in LayoutChildren)
                {
                    if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                    {
                        continue;
                    }
                    var childDesiredWidth = childLayout.Owner.LayoutWidth;
                    var childDesiredHeight = childLayout.Owner.LayoutHeight;
                    float childWeight = childLayout.Owner.Weight;
                    Extents childMargin = childLayout.Margin;
                    bool useRemainingHeight = (childDesiredHeight == 0) && (childWeight > 0);
                    bool needToMeasure = false;

                    if ((childDesiredHeight == LayoutDimension.MatchParent) || (useRemainingHeight))
                    {
                        if (isHeightExactly)
                        {
                            // In MeasureChildWithMargins(), it is assumed that heightMeasureSpec includes Padding.Top and Padding.Bottom.
                            // Therefore, Padding.Top and Padding.Bottom are added to heightMeasureSpec.GetSize() before it is passed to MeasureChildWithMargins().
                            heightMeasureSpec.SetSize(new LayoutLength((int)(remainingHeight / childrenMatchParentCount) + Padding.Top + Padding.Bottom));
                            needToMeasure = true;
                        }
                        // RelativeLayout's MatchParent children should not fill to the RelativeLayout.
                        // Because the children's sizes and positions are calculated by RelativeLayout's APIs.
                        // Therefore, not to fill the RelativeLayout, the mode is changed from Exactly to AtMost.
                        //
                        // Not to print the recursive reference error message for this case, Specification is checked if it is WrapContent.
                        else if (Owner.LayoutHeight == LayoutDimension.WrapContent)
                        {
                            if (childDesiredHeight == LayoutDimension.MatchParent)
                            {
                                Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutHeight is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutHeight is MatchParent!");
                            }
                            else
                            {
                                Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutHeight is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutHeight is 0 with positive weight!");
                            }
                        }
                    }

                    if (needToMeasure == true)
                    {
                        MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
                    }

                    if ((childWeight > 0) && ((childDesiredHeight == LayoutDimension.MatchParent) || (childDesiredHeight == 0)))
                    {
                        float childMeasuredHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                        if (childMeasuredHeight < 0)
                        {
                            totalWeightLength = Math.Max(totalWeightLength, totalWeightLength + childMargin.Top + childMargin.Bottom);
                        }
                        else
                        {
                            totalWeightLength = Math.Max(totalWeightLength, totalWeightLength + childMeasuredHeight + childMargin.Top + childMargin.Bottom);
                        }
                    }
                } // 2ND PHASE foreach

                // 3RD PHASE:
                //
                // We measure all weighted children whose owner has weight greater than 0.
                // After 3rd phase, all weighted children has height which is proportional to their weights
                // in remaining height of parent.
                if (totalWeight > 0)
                {
                    foreach (var childLayout in LayoutChildren)
                    {
                        if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                        {
                            continue;
                        }
                        var childDesiredHeight = childLayout.Owner.LayoutHeight;
                        float childWeight = childLayout.Owner.Weight;

                        if ((childWeight > 0) && ((childDesiredHeight == LayoutDimension.MatchParent) || (childDesiredHeight == 0)))
                        {
                            if (isHeightExactly)
                            {
                                MeasureWeightedChild(childLayout, totalWeightLength, totalWeight, childWeight,
                                                    widthMeasureSpec, heightMeasureSpec, childState,
                                                    Orientation.Vertical);
                            }
                            // RelativeLayout's MatchParent children should not fill to the RelativeLayout.
                            // Because the children's sizes and positions are calculated by RelativeLayout's APIs.
                            // Therefore, not to fill the RelativeLayout, the mode is changed from Exactly to AtMost.
                            //
                            // Not to print the recursive reference error message for this case, Specification is checked if it is WrapContent.
                            else if (Owner.LayoutHeight == LayoutDimension.WrapContent)
                            {
                                if (childDesiredHeight == LayoutDimension.MatchParent)
                                {
                                    Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutHeight is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutHeight is MatchParent!");
                                }
                                else
                                {
                                    Tizen.Log.Error("NUI", "There is a recursive reference! Parent layout(Owner: " + Owner + ")'s LayoutHeight is WrapContent and child layout(Owner: " + childLayout.Owner + ")'s LayoutHeight is 0 with positive weight!");
                                }
                            }
                        }
                    }
                } // 3RD PHASE foreach
            }

            // Decide the max width among children.
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !(childLayout.Owner.Visibility))
                {
                    continue;
                }

                Extents childMargin = childLayout.Margin;
                float childMarginWidth = childMargin.Start + childMargin.End;
                float childMeasuredWidth = childLayout.MeasuredWidth.Size.AsDecimal();

                if (childMeasuredWidth < 0)
                {
                    maxWidth = Math.Max(maxWidth, childMarginWidth);
                }
                else
                {
                    maxWidth = Math.Max(maxWidth, childMeasuredWidth + childMarginWidth);
                }
            }

            // Decide the max width compared with paddings and its suggested width.
            maxWidth = Math.Max(maxWidth, maxWidth + (Padding.Start + Padding.End));
            maxWidth = Math.Max(maxWidth, SuggestedMinimumWidth.AsRoundedValue());

            heightSizeAndState.State = childState.heightState;

            SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(maxWidth), widthMeasureSpec, childState.widthState),
                                  heightSizeAndState);
        } // MeasureVertical

        private void LayoutHorizontal(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;

            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            float width = new LayoutLength(right - left).AsDecimal();
            float height = new LayoutLength(bottom - top).AsDecimal();

            // Space available for child
            float availableWidth = width - Padding.Start - Padding.End;
            float availableHeight = height - Padding.Top - Padding.Bottom;

            var LinearChildren = IterateLayoutChildren();
            int count = LinearChildren.Count();

            float totalLength = 0;
            int validChildCount = 0;
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !childLayout.Owner.Visibility)
                {
                    continue;
                }

                var childWidthSize = childLayout.MeasuredWidth.Size.AsDecimal();
                if (childWidthSize > 0)
                {
                    validChildCount++;
                    totalLength += childWidthSize + childLayout.Margin.Start + childLayout.Margin.End;
                }
            }
            totalLength += CellPadding.Width * (validChildCount - 1);

            var leftPadding = isLayoutRtl ? Padding.End : Padding.Start;

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.End:
                    if (isLayoutRtl)
                    {
                        childLeft = new LayoutLength(leftPadding);
                    }
                    else
                    {
                        childLeft = new LayoutLength(leftPadding + availableWidth - totalLength);
                    }
                    break;
                case HorizontalAlignment.Center:
                    childLeft = new LayoutLength(leftPadding + (availableWidth - totalLength) / 2.0f);
                    break;
                case HorizontalAlignment.Begin: // FALL THROUGH (default)
                default:
                    if (isLayoutRtl)
                    {
                        childLeft = new LayoutLength(leftPadding + availableWidth - totalLength);
                    }
                    else
                    {
                        childLeft = new LayoutLength(leftPadding);
                    }
                    break;
            }

            int start = 0;
            int dir = 1;

            // In case of RTL, start drawing from the last child.
            if (isLayoutRtl)
            {
                start = count - 1;
                dir = -1;
            }

            for (int i = 0; i < count; i++)
            {
                int childIndex = start + dir * i;
                // Get a reference to the childLayout at the given index
                LayoutItem childLayout = LinearChildren.ElementAt(childIndex);
                if (!childLayout.SetPositionByLayout || !childLayout.Owner.Visibility)
                {
                    continue;
                }

                var childWidthSize = childLayout.MeasuredWidth.Size.AsDecimal();
                var childHeightSize = childLayout.MeasuredHeight.Size.AsDecimal();

                LayoutLength childWidth = childWidthSize >= 0 ? childLayout.MeasuredWidth.Size : new LayoutLength(0);
                LayoutLength childHeight = childHeightSize >= 0 ? childLayout.MeasuredHeight.Size : new LayoutLength(0);

                Extents childMargin = childLayout.Margin;
                var leftMargin = isLayoutRtl ? childMargin.End : childMargin.Start;
                var rightMargin = isLayoutRtl ? childMargin.Start : childMargin.End;

                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        childTop = new LayoutLength(Padding.Top + availableHeight - childHeightSize - childMargin.Bottom);
                        break;
                    case VerticalAlignment.Center:
                        childTop = new LayoutLength(Padding.Top + (availableHeight - childHeightSize) / 2.0f + childMargin.Top - childMargin.Bottom);
                        break;
                    case VerticalAlignment.Top: // FALLTHROUGH default
                    default:
                        childTop = new LayoutLength(Padding.Top + childMargin.Top);
                        break;
                }
                childLeft += leftMargin;
                childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                childLeft += childWidth + new LayoutLength(rightMargin + ((i < count - 1) ? CellPadding.Width : 0));
            }
        } // LayoutHorizontally

        private void LayoutVertical(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;

            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            float width = new LayoutLength(right - left).AsDecimal();
            float height = new LayoutLength(bottom - top).AsDecimal();

            // Space available for child
            float availableWidth = width - Padding.Start - Padding.End;
            float availableHeight = height - Padding.Top - Padding.Bottom;

            var LinearChildren = IterateLayoutChildren();
            int count = LinearChildren.Count<LayoutItem>();

            float totalLength = 0;
            int validChildCount = 0;
            foreach (var childLayout in LayoutChildren)
            {
                if (!childLayout.SetPositionByLayout || !childLayout.Owner.Visibility)
                {
                    continue;
                }

                var childHeightSize = childLayout.MeasuredHeight.Size.AsDecimal();
                if (childHeightSize > 0)
                {
                    validChildCount++;
                    totalLength += childHeightSize + childLayout.Margin.Top + childLayout.Margin.Bottom;
                }
            }
            totalLength += CellPadding.Height * (validChildCount - 1);

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    childTop = new LayoutLength(Padding.Top + availableHeight - totalLength);
                    break;
                case VerticalAlignment.Center:
                    childTop = new LayoutLength(Padding.Top + (availableHeight - totalLength) / 2.0f);
                    break;
                case VerticalAlignment.Top:  // FALL THROUGH (default)
                default:
                    childTop = new LayoutLength(Padding.Top);
                    break;
            }

            var leftPadding = isLayoutRtl ? Padding.End : Padding.Start;

            for (int i = 0; i < count; i++)
            {
                LayoutItem childLayout = LinearChildren.ElementAt(i);
                if (!childLayout.SetPositionByLayout || !childLayout.Owner.Visibility)
                {
                    continue;
                }

                var childWidthSize = childLayout.MeasuredWidth.Size.AsDecimal();
                var childHeightSize = childLayout.MeasuredHeight.Size.AsDecimal();

                LayoutLength childWidth = childWidthSize >= 0 ? childLayout.MeasuredWidth.Size : new LayoutLength(0);
                LayoutLength childHeight = childHeightSize >= 0 ? childLayout.MeasuredHeight.Size : new LayoutLength(0);

                Extents childMargin = childLayout.Margin;
                var leftMargin = isLayoutRtl ? childMargin.End : childMargin.Start;
                var rightMargin = isLayoutRtl ? childMargin.Start : childMargin.End;

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.End:
                        if (isLayoutRtl)
                        {
                            childLeft = new LayoutLength(leftPadding + childMargin.End);
                        }
                        else
                        {
                            childLeft = new LayoutLength(leftPadding + availableWidth - childWidthSize - childMargin.End);
                        }
                        break;
                    case HorizontalAlignment.Center:
                        childLeft = new LayoutLength(leftPadding + (availableWidth - childWidthSize) / 2.0f + leftMargin - rightMargin);
                        break;
                    case HorizontalAlignment.Begin:
                    default:
                        if (isLayoutRtl)
                        {
                            childLeft = new LayoutLength(leftPadding + availableWidth - childWidthSize - childMargin.Start);
                        }
                        else
                        {
                            childLeft = new LayoutLength(leftPadding + childMargin.Start);
                        }
                        break;
                }
                childTop += childMargin.Top;
                childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                childTop += childHeight + new LayoutLength(childMargin.Bottom + ((i < count - 1) ? CellPadding.Height : 0));
            }
        } // LayoutVertical
    } //LinearLayout
} // namespace
