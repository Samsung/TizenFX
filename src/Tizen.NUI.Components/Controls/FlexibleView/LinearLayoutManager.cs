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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Layout collection of views horizontally/vertically.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class LinearLayoutManager : FlexibleViewLayoutManager
    {
        /// <summary>
        /// Constant value: 0.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int HORIZONTAL = OrientationHelper.HORIZONTAL;
        /// <summary>
        /// Constant value: 1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int VERTICAL = OrientationHelper.VERTICAL;
        /// <summary>
        /// Constant value: -1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
        public static readonly int NO_POSITION = FlexibleView.NO_POSITION;
        /// <summary>
        /// Constant value: -2^31.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
        public static readonly int INVALID_OFFSET = -2147483648;

        private const float MAX_SCROLL_FACTOR = 1 / 3f;

        internal OrientationHelper orientationHelper;

        private LayoutState mLayoutState;
        private AnchorInfo mAnchorInfo = new AnchorInfo();

        // Stashed to avoid allocation, currently only used in #fill()
        private LayoutChunkResult mLayoutChunkResult = new LayoutChunkResult();

        private bool mShouldReverseLayout = false;

        // When LayoutManager needs to scroll to a position, it sets this variable and requests a
        // layout which will check this variable and re-layout accordingly.
        private int mPendingScrollPosition = NO_POSITION;

        // Used to keep the offset value when {@link #scrollToPositionWithOffset(int, int)} is
        // called.
        private int mPendingScrollPositionOffset = INVALID_OFFSET;

        /// <summary>
        /// Creates a LinearLayoutManager with orientation.
        /// </summary>
        /// <param name="orientation">Layout orientation.Should be HORIZONTAL or VERTICAL</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LinearLayoutManager(int orientation)
        {
            Orientation = orientation;
            orientationHelper = OrientationHelper.CreateOrientationHelper(this, Orientation);

            mLayoutState = new LayoutState();
            mLayoutState.Offset = orientationHelper.GetStartAfterPadding();
        }

        /// <summary>
        /// Current orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int Orientation { get; set; }

        /// <summary>
        /// Retrieves the first visible item position.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FirstVisibleItemPosition
        {
            get
            {
                FlexibleViewViewHolder child = FindFirstVisibleItemView();
                return child == null ? NO_POSITION : child.LayoutPosition;
            }
        }

        /// <summary>
        /// Retrieves the first complete visible item position.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FirstCompleteVisibleItemPosition
        {
            get
            {
                FlexibleViewViewHolder child = FindFirstCompleteVisibleItemView();
                return child == null ? NO_POSITION : child.LayoutPosition;
            }
        }

        /// <summary>
        /// Retrieves the last visible item position.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LastVisibleItemPosition
        {
            get
            {
                FlexibleViewViewHolder child = FindLastVisibleItemView();
                return child == null ? NO_POSITION : child.LayoutPosition;
            }
        }

        /// <summary>
        /// Retrieves the last complete visible item position.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LastCompleteVisibleItemPosition
        {
            get
            {
                FlexibleViewViewHolder child = FindLastCompleteVisibleItemView();
                return child == null ? NO_POSITION : child.LayoutPosition;
            }
        }

        /// <summary>
        /// Query if horizontal scrolling is currently supported. The default implementation returns false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanScrollHorizontally()
        {
            return Orientation == HORIZONTAL;
        }

        /// <summary>
        /// Query if vertical scrolling is currently supported. The default implementation returns false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanScrollVertically()
        {
            return Orientation == VERTICAL;
        }

        /// <summary>
        /// Lay out all relevant child views from the given adapter.
        /// </summary>
        /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnLayoutChildren(FlexibleViewRecycler recycler)
        {
            mLayoutState.Recycle = false;
            if (!mAnchorInfo.Valid || mPendingScrollPosition != NO_POSITION)
            {
                mAnchorInfo.Reset();
                mAnchorInfo.LayoutFromEnd = mShouldReverseLayout;
                // calculate anchor position and coordinate
                UpdateAnchorInfoForLayout(recycler, mAnchorInfo);
                mAnchorInfo.Valid = true;
            }

            int firstLayoutDirection;
            if (mAnchorInfo.LayoutFromEnd)
            {
                firstLayoutDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL
                        : LayoutState.ITEM_DIRECTION_HEAD;
            }
            else
            {
                firstLayoutDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD
                        : LayoutState.ITEM_DIRECTION_TAIL;
            }
            EnsureAnchorReady(recycler, mAnchorInfo, firstLayoutDirection);
            ScrapAttachedViews(recycler);

            if (mAnchorInfo.LayoutFromEnd == true)
            {
                UpdateLayoutStateToFillStart(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                Fill(recycler, mLayoutState, false, true);
                Cache(recycler, mLayoutState, true);

                UpdateLayoutStateToFillEnd(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                mLayoutState.CurrentPosition += mLayoutState.ItemDirection;
                Fill(recycler, mLayoutState, false, true);
                Cache(recycler, mLayoutState, true);
            }
            else
            {
                UpdateLayoutStateToFillEnd(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                Fill(recycler, mLayoutState, false, true);
                Cache(recycler, mLayoutState, true);

                UpdateLayoutStateToFillStart(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                mLayoutState.CurrentPosition += mLayoutState.ItemDirection;
                Fill(recycler, mLayoutState, false, true);
                Cache(recycler, mLayoutState, true);
            }

            OnLayoutCompleted();
        }

        /// <summary>
        /// Scroll horizontally by dy pixels in screen coordinates.
        /// </summary>
        /// <param name="dx">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
        /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
        /// <param name="immediate">Specify if the scroll need animation</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollHorizontallyBy(float dx, FlexibleViewRecycler recycler, bool immediate)
        {
            if (Orientation == VERTICAL)
            {
                return 0;
            }
            return ScrollBy(dx, recycler, immediate);
        }

        /// <summary>
        /// Scroll vertically by dy pixels in screen coordinates.
        /// </summary>
        /// <param name="dy">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
        /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
        /// <param name="immediate">Specify if the scroll need animation</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollVerticallyBy(float dy, FlexibleViewRecycler recycler, bool immediate)
        {
            if (Orientation == HORIZONTAL)
            {
                return 0;
            }
            return ScrollBy(dy, recycler, immediate);
        }

        /// <summary>
        /// Compute the offset of the scrollbar's thumb within the range.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollOffset()
        {
            FlexibleViewViewHolder startChild = FindFirstVisibleItemView();
            FlexibleViewViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            int minPosition = Math.Min(startChild.LayoutPosition, endChild.LayoutPosition);
            int maxPosition = Math.Max(startChild.LayoutPosition, endChild.LayoutPosition);
            int itemsBefore = mShouldReverseLayout
                    ? Math.Max(0, ItemCount - maxPosition - 1)
                    : Math.Max(0, minPosition);

            float laidOutArea = Math.Abs(orientationHelper.GetViewHolderEnd(endChild)
                   - orientationHelper.GetViewHolderStart(startChild));
            int itemRange = Math.Abs(startChild.LayoutPosition - endChild.LayoutPosition) + 1;
            float avgSizePerRow = laidOutArea / itemRange;

            return (float)Math.Round(itemsBefore * avgSizePerRow + (orientationHelper.GetStartAfterPadding()
                    - orientationHelper.GetViewHolderStart(startChild)));
        }

        /// <summary>
        /// Compute the extent of the scrollbar's thumb within the range.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollExtent()
        {
            FlexibleViewViewHolder startChild = FindFirstVisibleItemView();
            FlexibleViewViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float extend = orientationHelper.GetViewHolderEnd(endChild)
                - orientationHelper.GetViewHolderStart(startChild);
            return Math.Min(orientationHelper.GetTotalSpace(), extend);
        }

        /// <summary>
        /// Compute the range that the scrollbar represents.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollRange()
        {
            FlexibleViewViewHolder startChild = FindFirstVisibleItemView();
            FlexibleViewViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float laidOutArea = orientationHelper.GetViewHolderEnd(endChild)
                    - orientationHelper.GetViewHolderStart(startChild);
            int laidOutRange = Math.Abs(startChild.LayoutPosition - endChild.LayoutPosition) + 1;
            // estimate a size for full list.
            return laidOutArea / laidOutRange * ItemCount;
        }

        /// <summary>
        /// Scroll the FlexibleView to make the position visible.
        /// </summary>
        /// <param name="position">Scroll to this adapter position</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollToPosition(int position)
        {
            mPendingScrollPosition = position;
            mPendingScrollPositionOffset = INVALID_OFFSET;

            RelayoutRequest();
        }

        /// <summary>
        /// Scroll to the specified adapter position with the given offset from resolved layout start.
        /// </summary>
        /// <param name="position">Scroll to this adapter position</param>
        /// <param name="offset">The distance (in pixels) between the start edge of the item view and start edge of the FlexibleView.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollToPositionWithOffset(int position, int offset)
        {
            mPendingScrollPosition = position;
            mPendingScrollPositionOffset = offset;

            RelayoutRequest();
        }

        /// <summary>
        /// Called after a full layout calculation is finished.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnLayoutCompleted()
        {
            if (mPendingScrollPosition != NO_POSITION)
            {
                ChangeFocus(mPendingScrollPosition);
            }
            mPendingScrollPosition = NO_POSITION;
            mPendingScrollPositionOffset = INVALID_OFFSET;

            mAnchorInfo.Reset();
        }

        internal virtual void EnsureAnchorReady(FlexibleViewRecycler recycler, AnchorInfo anchorInfo, int itemDirection)
        {

        }


        /// <summary>
        /// Retrieves a position that neighbor to current position by direction.
        /// </summary>
        /// <param name="position">The anchor adapter position</param>
        /// <param name="direction">The direction.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override int GetNextPosition(int position, FlexibleViewLayoutManager.Direction direction)
        {
            if (Orientation == HORIZONTAL)
            {
                switch (direction)
                {
                    case FlexibleViewLayoutManager.Direction.Left:
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Right:
                        if (position < ItemCount - 1)
                        {
                            return position + 1;
                        }
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case FlexibleViewLayoutManager.Direction.Up:
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Down:
                        if (position < ItemCount - 1)
                        {
                            return position + 1;
                        }
                        break;
                }
            }

            return NO_POSITION;
        }

        /// <summary>
        /// Retrieves the first visible item view.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override FlexibleViewViewHolder FindFirstVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    int end = (int)orientationHelper.GetViewHolderEnd(child);
                    if (end >= 0 && end < (int)orientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    int end = (int)orientationHelper.GetViewHolderEnd(child);
                    if (end >= 0 && end < (int)orientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves the last visible item view.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override FlexibleViewViewHolder FindLastVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    int start = (int)orientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)orientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    int start = (int)orientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)orientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }
    }
}
