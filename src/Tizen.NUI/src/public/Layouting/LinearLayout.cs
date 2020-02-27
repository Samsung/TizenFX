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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a linear box layout, automatically handling right to left or left to right direction change.
    /// </summary>
    public class LinearLayout : LayoutGroup
    {
        /// <summary>
        /// [Draft] Enumeration for the direction in which the content is laid out
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
        /// [Draft] Enumeration for the alignment of the linear layout items
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum Alignment
        {
            /// <summary>
            /// At the left/right edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            Begin              = 0x1,
            /// <summary>
            /// At the right/left edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            End                = 0x2,
            /// <summary>
            /// At the horizontal center of the container
            /// </summary>
            CenterHorizontal   = 0x4,
            /// <summary>
            /// At the top edge of the container
            /// </summary>
            Top                = 0x8,
            /// <summary>
            /// At the bottom edge of the container
            /// </summary>
            Bottom             = 0x10,
            /// <summary>
            /// At the vertical center of the container
            /// </summary>
            CenterVertical     = 0x20,
            /// <summary>
            /// At the vertical and horizontal center of the container
            /// </summary>
            Center             = 0x40
        }

        struct HeightAndWidthState
        {
            public MeasuredSize.StateType widthState;
            public MeasuredSize.StateType heightState;

            public HeightAndWidthState( MeasuredSize.StateType width, MeasuredSize.StateType height)
            {
                widthState = width;
                heightState = height;
            }
        }

        /// <summary>
        /// [Draft] Get/Set the orientation in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LinearLayout.Orientation LinearOrientation
        {
            get
            {
                return _linearOrientation;
            }
            set
            {
                _linearOrientation = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// [Draft] Get/Set the padding between cells in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size2D CellPadding
        {
            get
            {
                return _cellPadding;
            }
            set
            {
                _cellPadding = value;
                RequestLayout();
            }
        }


        /// <summary>
        /// [Draft] Get/Set the alignment in the layout
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LinearLayout.Alignment LinearAlignment{ get; set; } = Alignment.Top;

        private float _totalLength = 0.0f;
        private Size2D _cellPadding  = new Size2D(0,0);
        private Orientation _linearOrientation = Orientation.Horizontal;

        /// <summary>
        /// [Draft] Constructor
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
            if (_linearOrientation == Orientation.Horizontal)
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
            if (_linearOrientation == Orientation.Horizontal)
            {
                LayoutHorizontal(left, top, right, bottom);
            }
            else
            {
                LayoutVertical(left, top, right, bottom);
            }
        }


        private void MeasureWeightedChild( LayoutItem childLayout, float remainingExcess, float remainingWeight, float childWeight,
                                           MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec,
                                           HeightAndWidthState childState, Orientation orientation )
        {
            bool horizontal = false;
            if (orientation == Orientation.Horizontal)
            {
                horizontal = true;
            }

            float childsShare = ( childWeight * remainingExcess ) / remainingWeight;
            remainingExcess -= childsShare;
            remainingWeight -= childWeight;

            float desiredWidth = childLayout.Owner.WidthSpecification;
            float desiredHeight = childLayout.Owner.HeightSpecification;
            float childLength = 0;

            // Always lay out weighted elements with intrinsic size regardless of the parent spec.
            // for consistency between specs.
            if( ( horizontal && ( desiredWidth == 0 )) || ( !horizontal && ( desiredHeight == 0 )) )
            {
                // This child needs to be laid out from scratch using
                // only its share of excess space.
                childLength = childsShare;
            }
            else
            {
                // This child had some intrinsic width to which we
                // need to add its share of excess space.
                if (horizontal)
                {
                    childLength = childLayout.MeasuredWidth.Size.AsDecimal() + childsShare;
                }
                else
                {
                    childLength = childLayout.MeasuredHeight.Size.AsDecimal() + childsShare;
                }
            }

            MeasureSpecification childWidthMeasureSpec;
            MeasureSpecification childHeightMeasureSpec;

            if (horizontal)
            {
                childWidthMeasureSpec = new MeasureSpecification( new LayoutLength(childLength), MeasureSpecification.ModeType.Exactly );
                childHeightMeasureSpec = GetChildMeasureSpecification( heightMeasureSpec,
                                            new LayoutLength(Padding.Top + Padding.Bottom),
                                            new LayoutLength(desiredHeight),
                                            new LayoutLength(childLayout.Owner.Margin.Top + childLayout.Owner.Margin.Bottom) );
            }
            else // vertical
            {
                childWidthMeasureSpec = GetChildMeasureSpecification( widthMeasureSpec,
                                            new LayoutLength(Padding.Start + Padding.End),
                                            new LayoutLength(desiredWidth),
                                            new LayoutLength(childLayout.Owner.Margin.Start + childLayout.Owner.Margin.End) );

                childHeightMeasureSpec = new MeasureSpecification( new LayoutLength(childLength), MeasureSpecification.ModeType.Exactly);
            }

            childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec );

            // Child may now not fit in horizontal dimension.
            if( childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
            {
                childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
            }

            // Child may now not fit in vertical dimension.
            if( childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
            {
                childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
            }
        }

        private void MeasureHorizontal(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            var widthMode = widthMeasureSpec.Mode;
            var heightMode = heightMeasureSpec.Mode;
            bool isExactly = ( widthMode == MeasureSpecification.ModeType.Exactly );
            bool matchHeight = false;
            bool allFillParent = true;
            float maxHeight = 0.0f;
            float alternativeMaxHeight = 0.0f;
            float weightedMaxHeight = 0.0f;
            float totalWeight = 0.0f;

            // Reset measure variables
            _totalLength = 0.0f;
            float usedExcessSpace = 0.0f;
            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            // 1st phase:
            // We cycle through all children and measure children with weight 0 (non weighted children) according to their specs
            // to accumulate total used space in totalLength based on measured sizes and margins.
            // Weighted children are not measured at this phase.
            // Available space for weighted children will be calculated in the phase 2 based on totalLength value.
            // Max height of children is stored.
            foreach( LayoutItem childLayout in LayoutChildren )
            {
                int childDesiredHeight = childLayout.Owner.HeightSpecification;
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                totalWeight += childWeight;

                bool useExcessSpace = (childLayout.Owner.WidthSpecification == 0 ) && (childWeight > 0);
                if( isExactly && useExcessSpace )
                {
                    // Children to be laid out with excess space can be measured later
                    _totalLength = Math.Max( _totalLength, (_totalLength + childMargin.Start + childMargin.End) );
                }
                else
                {
                    if (useExcessSpace)
                    {
                        // Parent is not defiend!!!
                        // The widthMode is either Unspecified or AtMost, and
                        // this child is only laid out using excess space. Measure
                        // using WrapContent so that we can find out the view's
                        // optimal width.
                        MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(widthMeasureSpec,
                                                new LayoutLength(Padding.Start + Padding.End),
                                                new LayoutLength(LayoutParamPolicies.WrapContent),
                                                new LayoutLength(childLayout.Margin.Start + childLayout.Margin.End));

                        MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(heightMeasureSpec,
                                                new LayoutLength(Padding.Top + Padding.Bottom),
                                                new LayoutLength(childDesiredHeight),
                                                new LayoutLength(childLayout.Margin.Top + childLayout.Margin.Bottom));

                        childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec);
                        usedExcessSpace += childLayout.MeasuredWidth.Size.AsDecimal();
                    }
                    else
                    {
                        MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    }

                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength length = childWidth + childMargin.Start + childMargin.End;

                    if (isExactly)
                    {
                        _totalLength += length.AsDecimal();
                    }
                    else
                    {
                        _totalLength = Math.Max(_totalLength, _totalLength + length.AsDecimal() + CellPadding.Width);
                    }
                }

                bool matchHeightLocally = false;
                if (heightMode != MeasureSpecification.ModeType.Exactly && childDesiredHeight == LayoutParamPolicies.MatchParent)
                {
                    // A child has set to MatchParent on it's height.
                    // Will have to re-measure at least this child when we know exact height.
                    matchHeight = true;
                    matchHeightLocally = true;
                }

                float marginHeight = childMargin.Top + childMargin.Bottom;
                float childHeight = childLayout.MeasuredHeight.Size.AsDecimal() + marginHeight;

                if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }

                maxHeight = Math.Max( maxHeight, childHeight);
                allFillParent = ( allFillParent && childDesiredHeight == LayoutParamPolicies.MatchParent);

                if (childWeight > 0)
                {
                  // Heights of weighted Views are invalid if we end up remeasuring, so store them separately.
                  weightedMaxHeight = Math.Max( weightedMaxHeight, matchHeightLocally ? marginHeight : childHeight);
                }
                else
                {
                  alternativeMaxHeight = Math.Max( alternativeMaxHeight, matchHeightLocally ? marginHeight : childHeight );
                }
            } // foreach

            float widthSize = _totalLength;
            widthSize = Math.Max( widthSize, SuggestedMinimumWidth.AsDecimal());
            MeasuredSize widthSizeAndState = ResolveSizeAndState( new LayoutLength(widthSize), new LayoutLength(Padding.Start + Padding.End), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            widthSize = widthSizeAndState.Size.AsDecimal();

            // 2nd phase:
            // Expand children with weight to take up available space
            // We cycle through weighted children now (children with weight > 0).
            // The children are measured with exact size equal to their share of the available space based on their weights.
            // _totalLength is updated to include weighted children measured sizes.
            float remainingExcess = widthSize - _totalLength + usedExcessSpace - (Padding.Start + Padding.End);
            if( remainingExcess != 0 && totalWeight > 0 )
            {
                float remainingWeight = totalWeight;
                maxHeight = 0;
                _totalLength = 0;

                int numberOfChildren = LayoutChildren.Count;
                for( int i = 0; i < numberOfChildren; ++i )
                {
                    LayoutItem childLayout = LayoutChildren[i];

                    float desiredChildHeight = childLayout.Owner.HeightSpecification;

                    float childWeight = childLayout.Owner.Weight;
                    Extents childMargin = childLayout.Margin;

                    if( childWeight > 0 )
                    {
                        MeasureWeightedChild(childLayout, remainingExcess, remainingWeight, childWeight,
                                             widthMeasureSpec, heightMeasureSpec, childState,
                                             Orientation.Horizontal );
                    }

                    float length = childLayout.MeasuredWidth.Size.AsDecimal() + childMargin.Start + childMargin.End;
                    float cellPadding = i < numberOfChildren - 1 ? CellPadding.Width : 0;
                    if( isExactly )
                    {
                        _totalLength += length;
                    }
                    else
                    {
                        float totalLength = _totalLength;
                        _totalLength = Math.Max( _totalLength, _totalLength + length + cellPadding );
                    }

                    bool matchHeightLocally = (heightMode != MeasureSpecification.ModeType.Exactly) && (desiredChildHeight == LayoutParamPolicies.MatchParent);
                    float marginHeight = childMargin.Top + childMargin.Bottom;
                    float childHeight = childLayout.MeasuredHeight.Size.AsDecimal() + marginHeight;

                    maxHeight = Math.Max( maxHeight, childHeight );
                    alternativeMaxHeight = Math.Max( alternativeMaxHeight, matchHeightLocally ? marginHeight : childHeight );
                    allFillParent = (allFillParent && desiredChildHeight == LayoutParamPolicies.MatchParent);
                } // for loop
            }
            else
            {
                // No excess space or no weighted children
                alternativeMaxHeight = Math.Max( alternativeMaxHeight, weightedMaxHeight );
            }

            if (!allFillParent && heightMode != MeasureSpecification.ModeType.Exactly)
            {
                maxHeight = alternativeMaxHeight;
            }



            // Padding should be concerned when specification is Wrapcontent.
            maxHeight += (Owner.HeightSpecification == LayoutParamPolicies.WrapContent)?(Padding.Top + Padding.Bottom):0;
            maxHeight = Math.Max( maxHeight, SuggestedMinimumHeight.AsRoundedValue() );

            widthSizeAndState.State = childState.widthState;

            SetMeasuredDimensions(widthSizeAndState,
                                  ResolveSizeAndState( new LayoutLength(maxHeight), new LayoutLength(Padding.Top + Padding.Bottom), heightMeasureSpec, childState.heightState ));

            if (matchHeight)
            {
                ForceUniformHeight(widthMeasureSpec);
            }
        } // MeasureHorizontal

        private void MeasureVertical( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            var widthMode = widthMeasureSpec.Mode;
            var heightMode = heightMeasureSpec.Mode;
            bool isExactly = ( heightMode == MeasureSpecification.ModeType.Exactly);
            bool matchWidth = false;
            bool allFillParent = true;
            float maxWidth = 0.0f;
            float alternativeMaxWidth = 0.0f;
            float weightedMaxWidth = 0.0f;
            float totalWeight = 0.0f;

            // Reset total length
            _totalLength = 0.0f;
            float usedExcessSpace =0.0f;
            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);


            // measure children, and determine if further resolution is required

            // 1st phase:
            // We cycle through all children and measure children with weight 0 (non weighted children) according to their specs
            // to accumulate total used space in _totalLength.
            // Weighted children are not measured in this phase.
            // Available space for weighted children will be calculated in the phase 2 based on _totalLength value.
            foreach( LayoutItem childLayout in LayoutChildren )
            {
                int childDesiredWidth = childLayout.Owner.WidthSpecification;
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                totalWeight += childWeight;

                bool useExcessSpace = (childLayout.Owner.HeightSpecification == 0) && (childWeight > 0);
                if( isExactly && useExcessSpace )
                {
                   _totalLength = Math.Max( _totalLength, (_totalLength + childMargin.Top + childMargin.Bottom) );
                }
                else
                {
                    if( useExcessSpace )
                    {
                        // The heightMode is either Unspecified or AtMost, and
                        // this child is only laid out using excess space. Measure
                        // using WrapContent so that we can find out the view's
                        // optimal height.
                        // We'll restore the original height of 0 after measurement.
                        MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(widthMeasureSpec,
                                                                    new LayoutLength(Padding.Start + Padding.End),
                                                                    new LayoutLength(childDesiredWidth),
                                                                    new LayoutLength(childLayout.Margin.Start + childLayout.Margin.End) );

                        MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( heightMeasureSpec,
                                                                    new LayoutLength(Padding.Top + Padding.Bottom),
                                                                    new LayoutLength(LayoutParamPolicies.WrapContent),
                                                                    new LayoutLength(childLayout.Margin.Top + childLayout.Margin.Bottom) );

                        childLayout.Measure(childWidthMeasureSpec, childHeightMeasureSpec);
                        usedExcessSpace += childLayout.MeasuredHeight.Size.AsDecimal();
                    }
                    else
                    {
                        MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    }

                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;
                    LayoutLength length = childHeight + childMargin.Top + childMargin.Bottom;


                    if (isExactly)
                    {
                        _totalLength += length.AsDecimal();
                    }
                    else
                    {
                        _totalLength = Math.Max(_totalLength, _totalLength + length.AsDecimal() + CellPadding.Height);
                    }
                }

                bool matchWidthLocally = false;
                if( widthMode != MeasureSpecification.ModeType.Exactly && childDesiredWidth ==  LayoutParamPolicies.MatchParent)
                {
                    // Will have to re-measure at least this child when we know exact height.
                    matchWidth = true;
                    matchWidthLocally = true;
                }

                float marginWidth = childLayout.Margin.Start + childLayout.Margin.End;
                float childWidth = childLayout.MeasuredWidth.Size.AsDecimal() + marginWidth;

                if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }

                maxWidth = Math.Max( maxWidth, childWidth);
                allFillParent = ( allFillParent && childDesiredWidth == LayoutParamPolicies.MatchParent);

                if (childWeight > 0)
                {
                    // Widths of weighted Views are bogus if we end up remeasuring, so keep them separate.
                    weightedMaxWidth = Math.Max( weightedMaxWidth,  matchWidthLocally ? marginWidth : childWidth);
                }
                else
                {
                    alternativeMaxWidth = Math.Max( alternativeMaxWidth, matchWidthLocally ? marginWidth : childWidth);
                }
            } // foreach


            float heightSize = _totalLength;
            heightSize = Math.Max( heightSize, SuggestedMinimumHeight.AsDecimal());
            MeasuredSize heightSizeAndState = ResolveSizeAndState( new LayoutLength(heightSize), new LayoutLength(Padding.Top + Padding.Bottom), heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK );
            heightSize = heightSizeAndState.Size.AsDecimal();

            // 2nd phase:
            // We cycle through weighted children now (children with weight > 0).
            // The children are measured with exact size equal to their share of the available space based on their weights.
            // _totalLength is updated to include weighted children measured sizes.
            float remainingExcess = heightSize - _totalLength + usedExcessSpace - (Padding.Top + Padding.Bottom);
            if( remainingExcess != 0 && totalWeight > 0.0f )
            {
                float remainingWeight = totalWeight;
                maxWidth = 0;
                _totalLength = 0;

                int numberOfChildren = LayoutChildren.Count;
                for( int i = 0; i < numberOfChildren; ++i )
                {
                    LayoutItem childLayout = LayoutChildren[i];

                    float desiredChildWidth = childLayout.Owner.WidthSpecification;

                    float childWeight = childLayout.Owner.Weight;
                    Extents childMargin = childLayout.Margin;

                    if( childWeight > 0 )
                    {
                        MeasureWeightedChild(childLayout, remainingExcess, remainingWeight, childWeight,
                                                widthMeasureSpec, heightMeasureSpec, childState,
                                                Orientation.Vertical);
                    }

                    float length = childLayout.MeasuredHeight.Size.AsDecimal() + childMargin.Top + childMargin.Bottom;
                    float cellPadding = i < numberOfChildren - 1 ? CellPadding.Height : 0;

                    if( isExactly )
                    {
                        _totalLength += length;
                    }
                    else
                    {
                        float totalLength = _totalLength;
                        _totalLength = Math.Max( _totalLength, _totalLength + length + cellPadding );
                    }

                    bool matchWidthLocally = (widthMode != MeasureSpecification.ModeType.Exactly) && (desiredChildWidth == LayoutParamPolicies.MatchParent);
                    float marginWidth = childMargin.Start + childMargin.End;
                    float childWidth = childLayout.MeasuredWidth.Size.AsDecimal() + marginWidth;

                    maxWidth = Math.Max( maxWidth, childWidth );
                    alternativeMaxWidth = Math.Max( alternativeMaxWidth, matchWidthLocally ? marginWidth : childWidth );
                    allFillParent = (allFillParent && desiredChildWidth == LayoutParamPolicies.MatchParent);
                } // for loop
            }
            else
            {
                alternativeMaxWidth = Math.Max( alternativeMaxWidth, weightedMaxWidth );
            }

            if (!allFillParent && widthMode != MeasureSpecification.ModeType.Exactly)
            {
                maxWidth = alternativeMaxWidth;
            }

            maxWidth += (Owner.WidthSpecification == LayoutParamPolicies.WrapContent)?(Padding.Start + Padding.End):0;
            maxWidth = Math.Max( maxWidth, SuggestedMinimumWidth.AsRoundedValue());

            heightSizeAndState.State = childState.heightState;

            SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(maxWidth), new LayoutLength(Padding.Top + Padding.Bottom), widthMeasureSpec, childState.widthState ),
                                  heightSizeAndState );

            if (matchWidth)
            {
                ForceUniformWidth(heightMeasureSpec );
            }
        } // MeasureVertical

        private void LayoutHorizontal(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;

            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            // Where bottom of child should go
            LayoutLength height = new LayoutLength(bottom - top);

            // Space available for child
            LayoutLength childSpace = new LayoutLength( height - Padding.Top - Padding.Bottom);

            int count = LayoutChildren.Count;

            switch (LinearAlignment)
            {
                case Alignment.End:
                    // totalLength contains the padding already
                    // In case of RTL map END alignment to the left edge
                    if (isLayoutRtl)
                    {
                        childLeft = new LayoutLength(Padding.Start);
                    }
                    else
                    {
                        childLeft = new LayoutLength(Padding.Start + right.AsDecimal() - left.AsDecimal() - _totalLength);
                    }
                    break;
                case Alignment.CenterHorizontal: // FALL THROUGH
                case Alignment.Center:
                    // totalLength contains the padding already
                    childLeft = new LayoutLength(Padding.Start + (right.AsDecimal() - left.AsDecimal() - _totalLength) / 2.0f);
                    break;
                case Alignment.Begin: // FALL THROUGH (default)
                default:
                    // totalLength contains the padding already
                    // In case of RTL map BEGIN alignment to the right edge
                    if (isLayoutRtl)
                    {
                        childLeft = new LayoutLength(Padding.Start  + right.AsDecimal() - left.AsDecimal() - _totalLength);
                    }
                    else
                    {
                        childLeft = new LayoutLength(Padding.Start);
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

            for( int i = 0; i < count; i++)
            {
                int childIndex = start + dir * i;
                // Get a reference to the childLayout at the given index
                LayoutItem childLayout = LayoutChildren[childIndex];
                if( childLayout != null )
                {
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;
                    Extents childMargin = childLayout.Margin;

                    switch ( LinearAlignment )
                    {
                        case Alignment.Bottom:
                            childTop = new LayoutLength(height - Padding.Bottom - childHeight - childMargin.Bottom);
                            break;
                        case Alignment.CenterVertical:
                        case Alignment.Center: // FALLTHROUGH
                            childTop = new LayoutLength(Padding.Top + ( ( childSpace - childHeight ).AsDecimal() / 2.0f ) + childMargin.Top - childMargin.Bottom);
                            break;
                        case Alignment.Top: // FALLTHROUGH default
                        default:
                            childTop = new LayoutLength(Padding.Top + childMargin.Top);
                            break;
                    }
                    childLeft += childMargin.Start;
                    childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                    childLeft += childWidth + childMargin.End + CellPadding.Width;
                }
            }
        } // LayoutHorizontally

        private void LayoutVertical(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            // Where end of child should go
            LayoutLength width = new LayoutLength(right - left);

            // Space available for child
            LayoutLength childSpace = new LayoutLength( width - Padding.Start - Padding.End);

            int count = LayoutChildren.Count;

            switch (LinearAlignment)
            {
              case Alignment.Bottom:
                // totalLength contains the padding already
                childTop = new LayoutLength( Padding.Top + bottom.AsDecimal() - top.AsDecimal() - _totalLength);
                break;
              case Alignment.CenterVertical: // FALL THROUGH
              case Alignment.Center:
                // totalLength contains the padding already
                childTop = new LayoutLength(Padding.Top + ( bottom.AsDecimal() - top.AsDecimal() - _totalLength ) / 2.0f);
                break;
              case Alignment.Top:  // FALL THROUGH (default)
              default:
                // totalLength contains the padding already
                childTop = new LayoutLength( Padding.Top );
                break;
            }

            for( int i = 0; i < count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if( childLayout != null )
                {
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;
                    Extents childMargin = childLayout.Margin;

                    childTop += childMargin.Top;
                    switch ( LinearAlignment )
                    {
                      case Alignment.Begin:
                      default:
                      {
                        childLeft = new LayoutLength(Padding.Start + childMargin.Start);
                        break;
                      }
                      case Alignment.End:
                      {
                        childLeft = new LayoutLength(width - Padding.End - childWidth - childMargin.End);
                        break;
                      }
                      case Alignment.CenterHorizontal:
                      case Alignment.Center: // FALL THROUGH
                      {
                        childLeft = new LayoutLength(Padding.Start + (( childSpace - childWidth ).AsDecimal() / 2.0f) + childMargin.Start - childMargin.End);
                        break;
                      }
                    }
                    childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                    childTop += childHeight + childMargin.Bottom + CellPadding.Height;
                }
            }
        } // LayoutVertical

        private void ForceUniformHeight(MeasureSpecification widthMeasureSpec)
        {
          // Pretend that the linear layout has an exact size. This is the measured height of
          // ourselves. The measured height should be the max height of the children, changed
          // to accommodate the heightMeasureSpec from the parent
          MeasureSpecification uniformMeasureSpec = new MeasureSpecification( MeasuredHeight.Size, MeasureSpecification.ModeType.Exactly);
          foreach (LayoutItem childLayout in LayoutChildren)
          {
              int desiredChildHeight = childLayout.Owner.HeightSpecification;
              int desiredChildWidth = childLayout.Owner.WidthSpecification;

              if (desiredChildHeight == LayoutParamPolicies.MatchParent)
              {
                  // Temporarily force children to reuse their original measured width
                  int originalWidth = desiredChildWidth;
                  childLayout.Owner.WidthSpecification = (int)childLayout.MeasuredWidth.Size.AsRoundedValue();
                  // Remeasure with new dimensions
                  MeasureChildWithMargins( childLayout, widthMeasureSpec, new LayoutLength(0),
                                           uniformMeasureSpec, new LayoutLength(0) );
                  // Restore width specification
                  childLayout.Owner.WidthSpecification =  originalWidth;
              }
          }
        }

        private void ForceUniformWidth(MeasureSpecification heightMeasureSpec)
        {
            // Pretend that the linear layout has an exact size.
            MeasureSpecification uniformMeasureSpec = new MeasureSpecification( MeasuredWidth.Size, MeasureSpecification.ModeType.Exactly);
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                int desiredChildWidth = childLayout.Owner.WidthSpecification;
                int desiredChildHeight = childLayout.Owner.WidthSpecification;

                if (desiredChildWidth  == LayoutParamPolicies.MatchParent)
                {
                    // Temporarily force children to reuse their original measured height
                    int originalHeight = desiredChildHeight;
                    childLayout.Owner.HeightSpecification =  (int)childLayout.MeasuredHeight.Size.AsRoundedValue();

                    // Remeasure with new dimensions
                    MeasureChildWithMargins( childLayout, uniformMeasureSpec, new LayoutLength(0),
                                             heightMeasureSpec, new LayoutLength(0));
                    // Restore height specification
                    childLayout.Owner.HeightSpecification = originalHeight;
                }
            }
        }
    } //LinearLayout
} // namespace
