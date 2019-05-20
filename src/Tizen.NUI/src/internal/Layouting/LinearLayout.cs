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
    internal class LinearLayout : LayoutGroup
    {
        /// <summary>
        /// [Draft] Enumeration for the direction in which the content is laid out
        /// </summary>
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
            CenterVertical     = 0x20
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
        public LinearLayout.Alignment LinearAlignment{ get; set; } = Alignment.CenterVertical;

        private float _totalLength = 0.0f;
        private Size2D _cellPadding  = new Size2D(0,0);
        private Orientation _linearOrientation = Orientation.Horizontal;

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LinearLayout()
        {
        }

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

            // Reset total length
            _totalLength = 0.0f;
            LayoutLength usedExcessSpace = new LayoutLength(0);

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            // Measure children, and determine if further resolution is required

            // 1st phase:
            // We cycle through all children and measure children with weight 0 (non weighted children) according to their specs
            // to accumulate total used space in totalLength based on measured sizes and margins.
            // Weighted children are not measured at this phase.
            // Available space for weighted children will be calculated in the phase 2 based on totalLength value.

            foreach( LayoutItem childLayout in _children )
            {
                LayoutLength childDesiredWidth = new LayoutLength(childLayout.Owner.WidthSpecification);
                LayoutLength childDesiredHeight = new LayoutLength(childLayout.Owner.HeightSpecification);
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                totalWeight += childWeight;

                bool useExcessSpace = (childDesiredWidth.AsRoundedValue() == 0 ) && (childWeight > 0);
                if( isExactly && useExcessSpace )
                {
                    _totalLength += childMargin.Start + childMargin.End;
                }
                else
                {
                    if( useExcessSpace )
                    {
                        // The widthMode is either UNSPECIFIED or AT_MOST, and
                        // this child is only laid out using excess space. Measure
                        // using WRAP_CONTENT so that we can find out the view's
                        // optimal width.
                        MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification(widthMeasureSpec, new LayoutLength(childLayout.Padding.Start + childLayout.Padding.End),
                                                                    new LayoutLength(LayoutParamPolicies.WrapContent) );
                        MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification(heightMeasureSpec, new LayoutLength(childLayout.Padding.Top + childLayout.Padding.Bottom),
                                                                    childDesiredHeight);
                        childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec);
                        usedExcessSpace += childLayout.MeasuredWidth.Size;
                    }
                    else
                    {
                        MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    }
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;

                    LayoutLength length = childWidth + childMargin.Start + childMargin.End;
                    if( isExactly )
                    {
                        _totalLength += length.AsDecimal();
                    }
                    else
                    {
                        _totalLength = Math.Max(_totalLength, _totalLength + length.AsDecimal() + CellPadding.Width);
                    }
                }

                bool matchHeightLocally = false;
                if(heightMode != MeasureSpecification.ModeType.Exactly && (int)childDesiredHeight.AsRoundedValue() == LayoutParamPolicies.MatchParent)
                {
                    // Will have to re-measure at least this child when we know exact height.
                    matchHeight = true;
                    matchHeightLocally = true;
                }

                LayoutLength marginHeight = new LayoutLength(childMargin.Top + childMargin.Bottom);
                LayoutLength childHeight = childLayout.MeasuredHeight.Size + marginHeight;

                if( childLayout.MeasuredWidthAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall )
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if( childLayout.MeasuredHeightAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }

                maxHeight = Math.Max( maxHeight, childHeight.AsDecimal());
                allFillParent = ( allFillParent && childDesiredHeight.AsRoundedValue() == LayoutParamPolicies.MatchParent );

                if( childWeight > 0 )
                {
                  /*
                  * Heights of weighted Views are bogus if we end up
                  * remeasuring, so keep them separate.
                  */
                  weightedMaxHeight = Math.Max( weightedMaxHeight, matchHeightLocally ? marginHeight.AsDecimal() : childHeight.AsDecimal());
                }
                else
                {
                  alternativeMaxHeight = Math.Max( alternativeMaxHeight, matchHeightLocally ? marginHeight.AsDecimal() : childHeight.AsDecimal() );
                }
            } // foreach

            Extents padding = Padding;
            _totalLength += padding.Start + padding.End;
            LayoutLength widthSize = new LayoutLength(_totalLength);
            widthSize = new LayoutLength( Math.Max( widthSize.AsDecimal(), SuggestedMinimumWidth.AsDecimal()));
            MeasuredSize widthSizeAndState = ResolveSizeAndState( widthSize, widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            widthSize = widthSizeAndState.Size;

            if (!allFillParent && heightMode != MeasureSpecification.ModeType.Exactly)
            {
                maxHeight = alternativeMaxHeight;
            }
            maxHeight += padding.Top + padding.Bottom;
            maxHeight = Math.Max( maxHeight, SuggestedMinimumHeight.AsRoundedValue() );

            widthSizeAndState.State = childState.widthState;

            SetMeasuredDimensions(widthSizeAndState,
                                  ResolveSizeAndState( new LayoutLength(maxHeight), heightMeasureSpec, childState.heightState ));

            if (matchHeight)
            {
                ForceUniformHeight( _children.Count, widthMeasureSpec );
            }
        } // MeasureHorizontally

        void MeasureVertical( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
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
            LayoutLength usedExcessSpace = new LayoutLength(0);

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeTooSmall);


            // measure children, and determine if further resolution is required

            // 1st phase:
            // We cycle through all children and measure children with weight 0 (non weighted children) according to their specs
            // to accumulate total used space in mTotalLength based on measured sizes and margins.
            // Weighted children are not measured at this phase.
            // Available space for weighted children will be calculated in the phase 2 based on mTotalLength value.
            uint index = 0;
            foreach( LayoutItem childLayout in _children )
            {
                LayoutLength childDesiredWidth = new LayoutLength(childLayout.Owner.WidthSpecification);
                LayoutLength childDesiredHeight = new LayoutLength(childLayout.Owner.HeightSpecification);
                float childWeight = childLayout.Owner.Weight;
                Extents childMargin = childLayout.Margin;
                totalWeight += childWeight;

                bool useExcessSpace = (childDesiredHeight.AsRoundedValue() == 0) && (childWeight > 0);

                if( isExactly && useExcessSpace )
                {
                   LayoutLength totalLength = new LayoutLength(_totalLength);
                   _totalLength = Math.Max( totalLength.AsDecimal(), (totalLength + childMargin.Top + childMargin.Bottom).AsDecimal() );
                }
                else
                {
                    LayoutLength childHeight = new LayoutLength(0);
                    if( useExcessSpace )
                    {
                        // The heightMode is either Unspecified or AtMost, and
                        // this child is only laid out using excess space. Measure
                        // using WrapContent so that we can find out the view's
                        // optimal height. We'll restore the original height of 0
                        // after measurement.
                        MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( widthMeasureSpec,
                                                                    new LayoutLength(childLayout.Padding.Start + childLayout.Padding.End),
                                                                    childDesiredWidth);
                        MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( heightMeasureSpec,
                                                                      new LayoutLength(childLayout.Padding.Top + childLayout.Padding.Bottom),
                                                                      new LayoutLength(LayoutParamPolicies.WrapContent) );
                        childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
                        childHeight = childLayout.MeasuredHeight.Size;
                        usedExcessSpace += childHeight;
                    }
                    else
                    {
                        MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                        childHeight = childLayout.MeasuredHeight.Size;
                    }

                    float length = (childHeight + childMargin.Top + childMargin.Bottom).AsDecimal();
                    float cellPadding = CellPadding.Height;
                    // No need to add cell padding to the end of last item.
                    if (index>=_children.Count-1)
                    {
                        cellPadding = 0.0f;
                    }
                    _totalLength = Math.Max( _totalLength, _totalLength + length +  cellPadding );
                }

                bool matchWidthLocally = false;
                if( widthMode != MeasureSpecification.ModeType.Exactly && childDesiredWidth ==  new LayoutLength(LayoutParamPolicies.MatchParent) )
                {
                    // Will have to re-measure at least this child when we know exact height.
                    matchWidth = true;
                    matchWidthLocally = true;
                }

                float marginWidth = (childLayout.Margin.Start) + (childLayout.Margin.End);
                LayoutLength childWidth = new LayoutLength(childLayout.MeasuredWidth.Size.AsDecimal() + marginWidth);

                // was combineMeasuredStates()
                if (childLayout.MeasuredWidthAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }
                if (childLayout.MeasuredHeightAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                {
                    childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                }

                maxWidth = (Math.Max( maxWidth, childWidth.AsDecimal()));
                allFillParent = (allFillParent && (childDesiredWidth == new LayoutLength(LayoutParamPolicies.MatchParent)));

                float widthforWeight = childWidth.AsDecimal();
                if (matchWidthLocally)
                {
                    widthforWeight = marginWidth;
                }

                if (childWeight > 0)
                {
                    /*
                    * Widths of weighted Views are bogus if we end up remeasuring, so keep them separate.
                    */
                    weightedMaxWidth = Math.Max( weightedMaxWidth, widthforWeight);
                }
                else
                {
                    alternativeMaxWidth = Math.Max( alternativeMaxWidth, widthforWeight);
                }
            } // foreach


            Extents padding = Padding;
            _totalLength += padding.Top + padding.Bottom;
            LayoutLength heightSize = new LayoutLength(_totalLength);
            heightSize = new LayoutLength(Math.Max( heightSize.AsDecimal(), SuggestedMinimumHeight.AsDecimal() ));
            MeasuredSize heightSizeAndState = ResolveSizeAndState( heightSize, heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            heightSize = heightSizeAndState.Size;

            // Either expand children with weight to take up available space or
            // shrink them if they extend beyond our current bounds. If we skipped
            // measurement on any children, we need to measure them now.

            // 2nd phase:
            // We cycle through weighted children now (children with weight > 0).
            // The children are measured with exact size equal to their share of the available space based on their weights.
            // TotalLength is updated to include weighted children measured sizes.

            float remainingExcess = heightSize.AsDecimal() - _totalLength + usedExcessSpace.AsDecimal();

            if( remainingExcess != 0 && totalWeight > 0.0f )
            {
                float remainingWeightSum = totalWeight;

                _totalLength = 0;

                foreach( LayoutItem childLayout in _children )
                {
                    int desiredWidth = childLayout.Owner.WidthSpecification;
                    int desiredHeight = childLayout.Owner.HeightSpecification;
                    float childWeight = childLayout.Owner.Weight;
                    Extents childMargin = childLayout.Margin;

                    float childHeight = 0;
                    if( childWeight > 0 )
                    {
                        float share = ( childWeight * remainingExcess ) / remainingWeightSum;
                        remainingExcess -= share;
                        remainingWeightSum -= childWeight;

                        // Always lay out weighted elements with intrinsic size regardless of the parent spec
                        // for consistency between specs.
                        if( desiredHeight == 0 )
                        {
                          // This child needs to be laid out from scratch using
                          // only its share of excess space.
                          childHeight = share;
                        }
                        else
                        {
                          // This child had some intrinsic width to which we
                          // need to add its share of excess space.
                          childHeight = childLayout.MeasuredHeight.Size.AsDecimal() + share;
                        }

                        MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( widthMeasureSpec,
                                            new LayoutLength(Padding.Start + Padding.End),
                                            new LayoutLength(desiredWidth) );

                        MeasureSpecification childHeightMeasureSpec = new MeasureSpecification( new LayoutLength(childHeight), MeasureSpecification.ModeType.Exactly);
                        childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec );

                        // Child may now not fit in vertical dimension.
                        if( childLayout.MeasuredHeightAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                        {
                            childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                        }
                    }

                    bool matchWidthLocally = false;
                    if( widthMode != MeasureSpecification.ModeType.Exactly && desiredWidth == (int)LayoutParamPolicies.MatchParent )
                    {
                        // Will have to re-measure at least this child when we know exact height.
                        matchWidth = true;
                        matchWidthLocally = true;
                    }

                    float marginWidth = childMargin.Start + childMargin.End;
                    float childWidth = childLayout.MeasuredWidth.Size.AsDecimal() + marginWidth;
                    maxWidth = Math.Max( maxWidth, childWidth );
                    allFillParent = allFillParent && desiredWidth == (int)LayoutParamPolicies.MatchParent;


                    alternativeMaxWidth = Math.Max( alternativeMaxWidth, matchWidthLocally ? marginWidth : childWidth );

                    childHeight = childLayout.MeasuredHeight.Size.AsDecimal();
                    float length = childHeight + childMargin.Top + childMargin.Bottom;
                    float cellPadding = CellPadding.Height;
                    // No need to add cell padding to the end of last item.
                    if (index>=_children.Count-1)
                    {
                        cellPadding = 0.0f;
                    }
                    _totalLength = Math.Max( _totalLength, _totalLength + length + cellPadding );
                } // foreach

                // Add in our padding
                _totalLength += Padding.Top + Padding.Bottom;
            }
            else
            {
                alternativeMaxWidth = Math.Max( alternativeMaxWidth, weightedMaxWidth );
            }

            if (!allFillParent && widthMode != MeasureSpecification.ModeType.Exactly)
            {
                maxWidth = alternativeMaxWidth;
            }
            maxWidth += padding.Start + padding.End;
            maxWidth = Math.Max( maxWidth, SuggestedMinimumWidth.AsRoundedValue());

            heightSizeAndState.State = childState.heightState;

            SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(maxWidth), widthMeasureSpec, childState.widthState ),
                                  heightSizeAndState );

            if( matchWidth )
            {
                ForceUniformWidth( _children.Count, heightMeasureSpec );
            }
        } // MeasureVertically

        void LayoutHorizontal(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;

            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            // Where bottom of child should go
            LayoutLength height = new LayoutLength(bottom - top);

            // Space available for child
            LayoutLength childSpace = new LayoutLength( height - Padding.Top - Padding.Bottom);

            int count = _children.Count;

            switch (LinearAlignment)
            {
                case Alignment.Begin:
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
                case Alignment.CenterHorizontal:
                    // totalLength contains the padding already
                    childLeft = new LayoutLength(Padding.Start + (right.AsDecimal() - left.AsDecimal() - _totalLength) / 2.0f);
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
                LayoutItem childLayout = _children[childIndex];
                if( childLayout != null )
                {
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;
                    Extents childMargin = childLayout.Margin;

                    switch ( LinearAlignment )
                    {
                        case Alignment.Top:
                            childTop = new LayoutLength(Padding.Top + childMargin.Top);
                            break;
                        case Alignment.Bottom:
                            childTop = new LayoutLength(height - Padding.Bottom - childHeight - childMargin.Bottom);
                            break;
                        case Alignment.CenterVertical: // FALLTHROUGH
                        default:
                            childTop = new LayoutLength(Padding.Top + ( ( childSpace - childHeight ).AsDecimal() / 2.0f ) + childMargin.Top - childMargin.Bottom);
                            break;
                    }
                    childLeft += childMargin.Start;
                    childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                    childLeft += childWidth + childMargin.End + CellPadding.Width;
                }
            }
        } // LayoutHorizontally

        void LayoutVertical(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutLength childTop = new LayoutLength(Padding.Top);
            LayoutLength childLeft = new LayoutLength(Padding.Start);

            // Where end of child should go
            LayoutLength width = new LayoutLength(right - left);

            // Space available for child
            LayoutLength childSpace = new LayoutLength( width - Padding.Start - Padding.End);

            int count = _children.Count;

            switch (LinearAlignment)
            {
              case Alignment.Top:
                // totalLength contains the padding already
                childTop = new LayoutLength( Padding.Top );
                break;
              case Alignment.Bottom:
                // totalLength contains the padding already
                childTop = new LayoutLength( Padding.Top + bottom.AsDecimal() - top.AsDecimal() - _totalLength);
                break;
              case Alignment.CenterVertical:
              default:
                // totalLength contains the padding already
                childTop = new LayoutLength(Padding.Top + ( bottom.AsDecimal() - top.AsDecimal() - _totalLength ) / 2.0f);
                break;
            }

            for( int i = 0; i < count; i++)
            {
                LayoutItem childLayout = _children[i];
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

        void ForceUniformHeight( int count, MeasureSpecification widthMeasureSpec )
        {
          // Pretend that the linear layout has an exact size. This is the measured height of
          // ourselves. The measured height should be the max height of the children, changed
          // to accommodate the heightMeasureSpec from the parent
          MeasureSpecification uniformMeasureSpec = new MeasureSpecification( MeasuredHeight.Size, MeasureSpecification.ModeType.Exactly);
          for (int i = 0; i < count; ++i)
          {
            LayoutItem childLayout = _children[i];
            if (childLayout != null)
            {
                LayoutLength desiredWidth = new LayoutLength(childLayout.Owner.WidthSpecification);
                LayoutLength desiredHeight = new LayoutLength(Owner.WidthSpecification );

                if (desiredHeight.AsRoundedValue() == LayoutParamPolicies.MatchParent)
                {
                  // Temporarily force children to reuse their old measured width
                  LayoutLength oldWidth = desiredWidth;
                  childLayout.Owner.WidthSpecification = (int)childLayout.MeasuredWidth.Size.AsRoundedValue();
                  // Remeasure with new dimensions
                  MeasureChildWithMargins( childLayout, widthMeasureSpec, new LayoutLength(0),
                                           uniformMeasureSpec, new LayoutLength(0) );

                  childLayout.Owner.WidthSpecification =  (int)oldWidth.AsRoundedValue();
              }
            }
          }
        }

        void ForceUniformWidth( int count, MeasureSpecification heightMeasureSpec )
        {
            // Pretend that the linear layout has an exact size.
            MeasureSpecification uniformMeasureSpec = new MeasureSpecification( MeasuredWidth.Size, MeasureSpecification.ModeType.Exactly);
            for (int i = 0; i < count; ++i)
            {
                LayoutItem childLayout = _children[i];
                if (childLayout != null)
                {
                    LayoutLength desiredWidth = new LayoutLength(childLayout.Owner.WidthSpecification);
                    LayoutLength desiredHeight = new LayoutLength(Owner.WidthSpecification );

                    if( desiredWidth.AsRoundedValue()  == LayoutParamPolicies.MatchParent)
                    {
                        // Temporarily force children to reuse their old measured height
                        LayoutLength oldHeight = desiredHeight;
                        childLayout.Owner.HeightSpecification =  (int)childLayout.MeasuredHeight.Size.AsRoundedValue();

                        // Remeasure with new dimensions
                        MeasureChildWithMargins( childLayout, uniformMeasureSpec, new LayoutLength(0),
                                                heightMeasureSpec, new LayoutLength(0));

                        childLayout.Owner.HeightSpecification = (int)oldHeight.AsRoundedValue();
                    }
                }
            }
        }

    } //LinearLayout

} // namespace
