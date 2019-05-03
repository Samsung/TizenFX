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
    internal class AbsoluteLayout : LayoutGroup
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

        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            Log.Info("NUI", "Measuring[" + _children.Count + "] child(ren)\n");
            float totalHeight = 0.0f;
            float totalWidth = 0.0f;

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSize.StateType.MeasuredSizeOK,
                                                                     MeasuredSize.StateType.MeasuredSizeOK);

            float minPositionX = 0.0f;
            float minPositionY = 0.0f;
            float maxPositionX = 0.0f;
            float maxPositionY = 0.0f;

            // measure children
            foreach( LayoutItem childLayout in _children )
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
                    Log.Info( "NUI" , "AbsoluteLayout::OnMeasure child width(" + childWidth + ") height(" + childHeight + ")\n" );

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

            Log.Info( "NUI" , "AbsoluteLayout::OnMeasure total width(" + totalWidth + ") total height(" + totalHeight + ")\n" );

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

        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            // Absolute layout positions it's children at their Actor positions.
            // Children could overlap or spill outside the parent, as is the nature of absolute positions.
            foreach( LayoutItem childLayout in _children )
            {
                if( childLayout != null )
                {
                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                    Position2D childPosition = childLayout.Owner.Position2D;

                    LayoutLength childLeft = new LayoutLength(childPosition.X);
                    LayoutLength childTop = new LayoutLength(childPosition.Y);

                    Log.Info("NUI", "Child View:" + childLayout.Owner.Name
                                    + " position(" + childLeft.AsRoundedValue() + ", "
                                    + childTop.AsRoundedValue() + ") width:"
                                    + childWidth.AsRoundedValue() + " height:"
                                    + childHeight.AsRoundedValue() + "\n");

                    childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                }
            }
        }
    }

} // namespace
