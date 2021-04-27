/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a absolute layout, allowing explicit positioning of children.
    ///  Positions are from the top left of the layout and can be set using the View.Position and alike.
    /// </summary>
    public class AbsoluteLayout : LayoutGroup
    {
        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AbsoluteLayout()
        {
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

            foreach (LayoutItem childLayout in IterateLayoutChildren())
            {
                // Get size of child with no padding, no margin. we won't support margin, padding for AbsolutLayout.
                MeasureChildWithoutPadding(childLayout, widthMeasureSpec, heightMeasureSpec);

                // Determine the width and height needed by the children using their given position and size.
                // Children could overlap so find the right most child.
                float childRight = childLayout.MeasuredWidth.Size.AsDecimal() + childLayout.Owner.PositionX;
                float childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + childLayout.Owner.PositionY;

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
            foreach (LayoutItem childLayout in IterateLayoutChildren())
            {
                LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                LayoutLength childLeft = new LayoutLength(childLayout.Owner.PositionX);
                LayoutLength childTop = new LayoutLength(childLayout.Owner.PositionY);

                childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, true);
            }
        }
    }
} // namespace
