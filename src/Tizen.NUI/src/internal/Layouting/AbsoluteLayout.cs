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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a absolute layout, allowing explicit positioning of children.
    ///  Positions are from the top left of the layout and can be set using the Actor::Property::POSITION and alike.
    /// </summary>
    public class AbsoluteLayout : LayoutGroup
    {
        /// <summary>
        /// Struct to store Measured states of height and width.
        /// </summary>
        private struct HeightAndWidthState
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
        /// [Draft] Constructor
        /// </summary>
        public AbsoluteLayout()
        {
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            float totalHeight = 0.0f;
            float totalWidth = 0.0f;

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            float minPositionX = 0.0f;
            float minPositionY = 0.0f;
            float maxPositionX = 0.0f;
            float maxPositionY = 0.0f;

            // measure children
            foreach( LayoutItem childLayout in LayoutChildren )
            {
                if (childLayout != null)
                {
                    // Get size of child
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    float childWidth = childLayout.MeasuredWidth.Size.AsDecimal();
                    float childHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                    // Determine the width and height needed by the children using their given position and size.
                    // Children could overlap so find the left most and right most child.
                    Position2D childPosition = childLayout.Owner.Position2D;
                    float childLeft = childPosition.X;
                    float childTop = childPosition.Y;

                    minPositionX = Math.Min( minPositionX, childLeft );
                    maxPositionX = Math.Max( maxPositionX, childLeft + childWidth );
                    // Children could overlap so find the highest and lowest child.
                    minPositionY = Math.Min( minPositionY, childTop );
                    maxPositionY = Math.Max( maxPositionY, childTop + childHeight );

                    // Store current width and height needed to contain all children.
                    totalWidth = maxPositionX - minPositionX;
                    totalHeight = maxPositionY - minPositionY;

                    if (childLayout.MeasuredWidthAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childState.widthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                    if (childLayout.MeasuredWidthAndState.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childState.heightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
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

            widthSizeAndState.State = childState.widthState;
            heightSizeAndState.State = childState.heightState;

            SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(totalWidth), widthMeasureSpec, childState.widthState ),
                                   ResolveSizeAndState( new LayoutLength(totalHeight), heightMeasureSpec, childState.heightState ) );
        }

        /// <summary>
        /// Assign a size and position to each of its children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            // Absolute layout positions it's children at their Actor positions.
            // Children could overlap or spill outside the parent, as is the nature of absolute positions.
            foreach( LayoutItem childLayout in LayoutChildren )
            {
                if( childLayout != null )
                {
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                    Position2D childPosition = childLayout.Owner.Position2D;

                    LayoutLength childLeft = new LayoutLength(childPosition.X);
                    LayoutLength childTop = new LayoutLength(childPosition.Y);

                    childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                }
            }
        }
    }

} // namespace
