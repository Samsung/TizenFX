/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    // Helper class for LayoutManagers to abstract measurements depending on the View's orientation.
    // It is developed to easily support vertical and horizontal orientations in a LayoutManager but
    // can also be used to abstract calls around view bounds and child measurements with margins and
    // decorations.
    //
    // @see #createHorizontalHelper(FlexibleViewRecyclerView.LayoutManager)
    // @see #createVerticalHelper(FlexibleViewRecyclerView.LayoutManager)
    internal abstract class OrientationHelper
    {
        public const int HORIZONTAL = 0;
        public const int VERTICAL = 1;

        private const int INVALID_SIZE = -1;

        protected FlexibleViewLayoutManager layoutManager;

        private float lastTotalSpace = INVALID_SIZE;

        public OrientationHelper(FlexibleViewLayoutManager layoutManager)
        {
            this.layoutManager = layoutManager;
        }

        // Call this method after onLayout method is complete if state is NOT pre-layout.
        // This method records information like layout bounds that might be useful in the next layout
        // calculations.
        public void OnLayoutComplete()
        {
            lastTotalSpace = GetTotalSpace();
        }

        // Returns the layout space change between the previous layout pass and current layout pass.
        // Make sure you call {@link #onLayoutComplete()} at the end of your LayoutManager's
        // {@link FlexibleViewRecyclerView.LayoutManager#onLayoutChildren(FlexibleViewRecyclerView.Recycler,
        // FlexibleViewRecyclerView.State)} method.
        //
        // @return The difference between the current total space and previous layout's total space.
        // @see #onLayoutComplete()
        public float GetTotalSpaceChange()
        {
            return INVALID_SIZE == lastTotalSpace ? 0 : GetTotalSpace() - lastTotalSpace;
        }

        // Returns the start of the view including its decoration and margin.
        // For example, for the horizontal helper, if a View's left is at pixel 20, has 2px left
        // decoration and 3px left margin, returned value will be 15px.
        //
        // @param view The view element to check
        // @return The first pixel of the element
        // @see #getDecoratedEnd(android.view.View)
        public abstract float GetViewHolderStart(FlexibleViewViewHolder holder);

        // Returns the end of the view including its decoration and margin.
        // For example, for the horizontal helper, if a View's right is at pixel 200, has 2px right
        // decoration and 3px right margin, returned value will be 205.
        //
        // @param view The view element to check
        // @return The last pixel of the element
        // @see #getDecoratedStart(android.view.View)
        public abstract float GetViewHolderEnd(FlexibleViewViewHolder holder);

        // Returns the space occupied by this View in the current orientation including decorations and
        // margins.
        //
        // @param view The view element to check
        // @return Total space occupied by this view
        // @see #getDecoratedMeasurementInOther(View)

        public abstract float GetViewHolderMeasurement(FlexibleViewViewHolder holder);

        // Returns the space occupied by this View in the perpendicular orientation including
        // decorations and margins.
        //
        // @param view The view element to check
        // @return Total space occupied by this view in the perpendicular orientation to current one
        // @see #getDecoratedMeasurement(View)
        public abstract float GetViewHolderMeasurementInOther(FlexibleViewViewHolder holder);

        // Returns the start position of the layout after the start padding is added.
        //
        // @return The very first pixel we can draw.
        public abstract float GetStartAfterPadding();

        // Returns the end position of the layout after the end padding is removed.
        //
        // @return The end boundary for this layout.
        public abstract float GetEndAfterPadding();

        // Returns the end position of the layout without taking padding into account.
        //
        // @return The end boundary for this layout without considering padding.
        public abstract float GetEnd();

        // Offsets all children's positions by the given amount.
        //
        // @param amount Value to add to each child's layout parameters
        public abstract void OffsetChildren(float amount, bool immediate);

        // Returns the total space to layout. This number is the difference between
        // {@link #getEndAfterPadding()} and {@link #getStartAfterPadding()}.
        //
        // @return Total space to layout children
        public abstract float GetTotalSpace();

        // Offsets the child in this orientation.
        //
        // @param view   View to offset
        // @param offset offset amount
        internal abstract void OffsetChild(FlexibleViewViewHolder holder, int offset);

        // Returns the padding at the end of the layout. For horizontal helper, this is the right
        // padding and for vertical helper, this is the bottom padding. This method does not check
        // whether the layout is RTL or not.
        //
        // @return The padding at the end of the layout.
        public abstract float GetEndPadding();

        // Creates an OrientationHelper for the given LayoutManager and orientation.
        //
        // @param layoutManager LayoutManager to attach to
        // @param orientation   Desired orientation. Should be {@link #HORIZONTAL} or {@link #VERTICAL}
        // @return A new OrientationHelper
        public static OrientationHelper CreateOrientationHelper(
                FlexibleViewLayoutManager layoutManager, int orientation)
        {
            if (orientation == HORIZONTAL)
            {
                return CreateHorizontalHelper(layoutManager);
            }
            else if (orientation == VERTICAL)
            {
                return CreateVerticalHelper(layoutManager);
            }

            throw new ArgumentException("invalid orientation");
        }


        // Creates a horizontal OrientationHelper for the given LayoutManager.
        //
        // @param layoutManager The LayoutManager to attach to.
        // @return A new OrientationHelper
        public static OrientationHelper CreateHorizontalHelper(FlexibleViewLayoutManager layoutManager)
        {
            return new HorizontalHelper(layoutManager);

        }

        // Creates a vertical OrientationHelper for the given LayoutManager.
        //
        // @param layoutManager The LayoutManager to attach to.
        // @return A new OrientationHelper
        public static OrientationHelper CreateVerticalHelper(FlexibleViewLayoutManager layoutManager)
        {
            return new VerticalHelper(layoutManager);
        }
    }

    internal class HorizontalHelper : OrientationHelper
    {
        public HorizontalHelper(FlexibleViewLayoutManager layoutManager) : base(layoutManager)
        {

        }

        public override float GetEndAfterPadding()
        {
            return layoutManager.Width - layoutManager.PaddingRight;
        }

        public override float GetEnd()
        {
            return layoutManager.Width;
        }

        public override void OffsetChildren(float amount, bool immediate)
        {
            layoutManager.OffsetChildrenHorizontal(amount, immediate);
        }


        public override float GetStartAfterPadding()
        {
            return layoutManager.PaddingLeft;
        }

        public override float GetViewHolderMeasurement(FlexibleViewViewHolder holder)
        {
            return holder.Right - holder.Left;
        }

        public override float GetViewHolderMeasurementInOther(FlexibleViewViewHolder holder)
        {
            return holder.Bottom - holder.Top;
        }

        public override float GetViewHolderEnd(FlexibleViewViewHolder holder)
        {
            return holder.Right;
        }

        public override float GetViewHolderStart(FlexibleViewViewHolder holder)
        {
            return holder.Left;
        }

        public override float GetTotalSpace()
        {
            return layoutManager.Width - layoutManager.PaddingLeft - layoutManager.PaddingRight;
        }

        internal override void OffsetChild(FlexibleViewViewHolder holder, int offset)
        {
            //holder.offsetLeftAndRight(offset);
        }

        public override float GetEndPadding()
        {
            return layoutManager.PaddingRight;
        }

    }

    internal class VerticalHelper : OrientationHelper
    {
        public VerticalHelper(FlexibleViewLayoutManager layoutManager) : base(layoutManager)
        {

        }

        public override float GetEndAfterPadding()
        {
            return layoutManager.Height - layoutManager.PaddingBottom;
        }

        public override float GetEnd()
        {
            return layoutManager.Height;
        }

        public override void OffsetChildren(float amount, bool immediate)
        {
            layoutManager.OffsetChildrenVertical(amount, immediate);
        }

        public override float GetStartAfterPadding()
        {
            return layoutManager.PaddingTop;
        }

        public override float GetViewHolderMeasurement(FlexibleViewViewHolder holder)
        {
            return holder.Bottom - holder.Top;
        }

        public override float GetViewHolderMeasurementInOther(FlexibleViewViewHolder holder)
        {
            return holder.Right - holder.Left;
        }

        public override float GetViewHolderEnd(FlexibleViewViewHolder holder)
        {
            return holder.Bottom;
        }

        public override float GetViewHolderStart(FlexibleViewViewHolder holder)
        {
            return holder.Top;
        }

        public override float GetTotalSpace()
        {
            return layoutManager.Height - layoutManager.PaddingTop - layoutManager.PaddingBottom;
        }

        internal override void OffsetChild(FlexibleViewViewHolder holder, int offset)
        {
            //holder.offsetTopAndBottom(offset);
        }

        public override float GetEndPadding()
        {
            return layoutManager.PaddingBottom;
        }

    }

}
