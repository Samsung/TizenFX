/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Layout collection of views horizontally/vertically.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearLayoutManager : FlexibleView.LayoutManager
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
        public static readonly int NO_POSITION = FlexibleView.NO_POSITION;
        /// <summary>
        /// Constant value: -2^31.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int INVALID_OFFSET = -2147483648;

        private static readonly float MAX_SCROLL_FACTOR = 1 / 3f;

        /// <summary>
        /// Current orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int mOrientation;

        internal OrientationHelper mOrientationHelper;

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
            mOrientation = orientation;
            mOrientationHelper = OrientationHelper.CreateOrientationHelper(this, mOrientation);

            mLayoutState = new LayoutState();
            mLayoutState.Offset = mOrientationHelper.GetStartAfterPadding();
        }

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
                FlexibleView.ViewHolder child = FindFirstVisibleItemView();
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
                FlexibleView.ViewHolder child = FindFirstCompleteVisibleItemView();
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
                FlexibleView.ViewHolder child = FindLastVisibleItemView();
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
                FlexibleView.ViewHolder child = FindLastCompleteVisibleItemView();
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
            return mOrientation == HORIZONTAL;
        }

        /// <summary>
        /// Query if vertical scrolling is currently supported. The default implementation returns false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanScrollVertically()
        {
            return mOrientation == VERTICAL;
        }

        /// <summary>
        /// Lay out all relevant child views from the given adapter.
        /// </summary>
        /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnLayoutChildren(FlexibleView.Recycler recycler)
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollHorizontallyBy(float dx, FlexibleView.Recycler recycler, bool immediate)
        {
            if (mOrientation == VERTICAL)
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollVerticallyBy(float dy, FlexibleView.Recycler recycler, bool immediate)
        {
            if (mOrientation == HORIZONTAL)
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
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            int minPosition = Math.Min(startChild.LayoutPosition, endChild.LayoutPosition);
            int maxPosition = Math.Max(startChild.LayoutPosition, endChild.LayoutPosition);
            int itemsBefore = mShouldReverseLayout
                    ? Math.Max(0, ItemCount - maxPosition - 1)
                    : Math.Max(0, minPosition);

            float laidOutArea = Math.Abs(mOrientationHelper.GetViewHolderEnd(endChild)
                   - mOrientationHelper.GetViewHolderStart(startChild));
            int itemRange = Math.Abs(startChild.LayoutPosition - endChild.LayoutPosition) + 1;
            float avgSizePerRow = laidOutArea / itemRange;

            return (float)Math.Round(itemsBefore * avgSizePerRow + (mOrientationHelper.GetStartAfterPadding()
                    - mOrientationHelper.GetViewHolderStart(startChild)));
        }

        /// <summary>
        /// Compute the extent of the scrollbar's thumb within the range.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollExtent()
        {
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float extend = mOrientationHelper.GetViewHolderEnd(endChild)
                - mOrientationHelper.GetViewHolderStart(startChild);
            return Math.Min(mOrientationHelper.GetTotalSpace(), extend);
        }

        /// <summary>
        /// Compute the range that the scrollbar represents.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollRange()
        {
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (ChildCount == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float laidOutArea = mOrientationHelper.GetViewHolderEnd(endChild)
                    - mOrientationHelper.GetViewHolderStart(startChild);
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

        internal virtual void EnsureAnchorReady(FlexibleView.Recycler recycler, AnchorInfo anchorInfo, int itemDirection)
        {

        }


        /// <summary>
        /// Retrieves a position that neighbor to current position by direction.
        /// </summary>
        /// <param name="position">The anchor adapter position</param>
        /// <param name="direction">The direction.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override int GetNextPosition(int position, FlexibleView.LayoutManager.Direction direction)
        {
            if (mOrientation == HORIZONTAL)
            {
                switch (direction)
                {
                    case FlexibleView.LayoutManager.Direction.Left:
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleView.LayoutManager.Direction.Right:
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
                    case FlexibleView.LayoutManager.Direction.Up:
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleView.LayoutManager.Direction.Down:
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override FlexibleView.ViewHolder FindFirstVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int end = (int)mOrientationHelper.GetViewHolderEnd(child);
                    if (end >= 0 && end < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int end = (int)mOrientationHelper.GetViewHolderEnd(child);
                    if (end >= 0 && end < (int)mOrientationHelper.GetEnd())
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override FlexibleView.ViewHolder FindLastVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int start = (int)mOrientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int start = (int)mOrientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        internal virtual void LayoutChunk(FlexibleView.Recycler recycler,
            LayoutState layoutState, LayoutChunkResult result)
        {
            FlexibleView.ViewHolder holder = layoutState.Next(recycler);
            if (holder == null)
            {
                // if we are laying out views in scrap, this may return null which means there is
                // no more items to layout.
                result.Finished = true;
                return;
            }

            if (mShouldReverseLayout == (layoutState.LayoutDirection == LayoutState.LAYOUT_START))
                AddView(holder);
            else
                AddView(holder, 0);

            result.Consumed = mOrientationHelper.GetViewHolderMeasurement(holder);

            float left, top, width, height;
            if (mOrientation == VERTICAL)
            {
                width = Width - PaddingLeft - PaddingRight;
                height = result.Consumed;
                left = PaddingLeft;
                if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                {
                    top = layoutState.Offset;
                }
                else
                {
                    top = layoutState.Offset - height;
                }
                LayoutChild(holder, left, top, width, height);
            }
            else
            {
                width = result.Consumed;
                height = Height - PaddingTop - PaddingBottom;
                top = PaddingTop;
                if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                {
                    left = layoutState.Offset;
                }
                else
                {
                    left = layoutState.Offset - width;
                }
                LayoutChild(holder, left, top, width, height);
            }

            result.Focusable = true;
        }

        internal override FlexibleView.ViewHolder OnFocusSearchFailed(FlexibleView.ViewHolder focused, FlexibleView.LayoutManager.Direction direction, FlexibleView.Recycler recycler)
        {
            if (ChildCount == 0)
            {
                return null;
            }
            int layoutDir = ConvertFocusDirectionToLayoutDirection(direction);
            if (layoutDir == LayoutState.INVALID_LAYOUT)
            {
                return null;
            }
            int maxScroll = (int)(MAX_SCROLL_FACTOR * mOrientationHelper.GetTotalSpace());
            UpdateLayoutState(layoutDir, maxScroll, false);
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Recycle = false;
            Fill(recycler, mLayoutState, true, true);

            FlexibleView.ViewHolder nextFocus;
            if (layoutDir == LayoutState.LAYOUT_START)
            {
                nextFocus = GetChildAt(0);
            }
            else
            {
                nextFocus = GetChildAt(ChildCount - 1);
            }
            return nextFocus;
        }


        private void UpdateAnchorInfoForLayout(FlexibleView.Recycler recycler, AnchorInfo anchorInfo)
        {
            if (UpdateAnchorFromPendingData(anchorInfo))
            {
                return;
            }

            if (UpdateAnchorFromChildren(recycler, anchorInfo))
            {
                return;
            }

            anchorInfo.Position = FocusPosition != NO_POSITION ? FocusPosition : 0;
            anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? mOrientationHelper.GetEndAfterPadding() : mOrientationHelper.GetStartAfterPadding();
        }

        
        // If there is a pending scroll position or saved states, updates the anchor info from that
        // data and returns true
        private bool UpdateAnchorFromPendingData(AnchorInfo anchorInfo)
        {
            if (mPendingScrollPosition == NO_POSITION)
            {
                return false;
            }
            // validate scroll position
            if (mPendingScrollPosition < 0 || mPendingScrollPosition >= ItemCount)
            {
                mPendingScrollPosition = NO_POSITION;
                mPendingScrollPositionOffset = INVALID_OFFSET;
                return false;
            }

            anchorInfo.Position = mPendingScrollPosition;

            if (mPendingScrollPositionOffset == INVALID_OFFSET)
            {
                anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? mOrientationHelper.GetEndAfterPadding() : mOrientationHelper.GetStartAfterPadding();
            }
            else
            {
                if (mShouldReverseLayout)
                {
                    anchorInfo.Coordinate = mOrientationHelper.GetEndAfterPadding()
                            - mPendingScrollPositionOffset;
                }
                else
                {
                    anchorInfo.Coordinate = mOrientationHelper.GetStartAfterPadding()
                            + mPendingScrollPositionOffset;
                }
            }

            return true;
        }

        // Finds an anchor child from existing Views. Most of the time, this is the view closest to
        // start or end that has a valid position (e.g. not removed).
        // If a child has focus, it is given priority.
        private bool UpdateAnchorFromChildren(FlexibleView.Recycler recycler, AnchorInfo anchorInfo)
        {
            if (ChildCount == 0)
            {
                return false;
            }

            FlexibleView.ViewHolder anchorChild = FindFirstVisibleItemView();
            if (anchorChild == null)
            {
                Log.Error("flexibleview", $"exception occurs when updating anchor information!");
                anchorChild = GetChildAt(0);
            }
            anchorInfo.Position = anchorChild.LayoutPosition;
            anchorInfo.Coordinate = mOrientationHelper.GetViewHolderStart(anchorChild);

            return true;
        }

        // Converts a focusDirection to orientation.
        //
        // @param focusDirection One of {@link View#FOCUS_UP}, {@link View#FOCUS_DOWN},
        //                       {@link View#FOCUS_LEFT}, {@link View#FOCUS_RIGHT},
        //                       {@link View#FOCUS_BACKWARD}, {@link View#FOCUS_FORWARD}
        //                       or 0 for not applicable
        // @return {@link LayoutState#LAYOUT_START} or {@link LayoutState#LAYOUT_END} if focus direction
        // is applicable to current state, {@link LayoutState#INVALID_LAYOUT} otherwise.
        private int ConvertFocusDirectionToLayoutDirection(FlexibleView.LayoutManager.Direction focusDirection)
        {
            switch (focusDirection)
            {
                case FlexibleView.LayoutManager.Direction.Up:
                    return mOrientation == VERTICAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleView.LayoutManager.Direction.Down:
                    return mOrientation == VERTICAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleView.LayoutManager.Direction.Left:
                    return mOrientation == HORIZONTAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleView.LayoutManager.Direction.Right:
                    return mOrientation == HORIZONTAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                default:
                    return LayoutState.INVALID_LAYOUT;
            }

        }


        private float Fill(FlexibleView.Recycler recycler, LayoutState layoutState, bool stopOnFocusable, bool immediate)
        {
            float start = layoutState.Available;

            if (layoutState.ScrollingOffset != LayoutState.SCROLLING_OFFSET_NaN)
            {
                // TODO ugly bug fix. should not happen
                if (layoutState.Available < 0)
                {
                    layoutState.ScrollingOffset += layoutState.Available;
                }
                if (immediate == true)
                {
                    RecycleByLayoutState(recycler, layoutState, true);
                }
            }
            float remainingSpace = layoutState.Available + layoutState.Extra;
            LayoutChunkResult layoutChunkResult = mLayoutChunkResult;
            while ((remainingSpace > 0) && layoutState.HasMore(ItemCount))
            {
                layoutChunkResult.ResetInternal();
                LayoutChunk(recycler, layoutState, layoutChunkResult);
                if (layoutChunkResult.Finished)
                {
                    break;
                }
                layoutState.Offset += layoutChunkResult.Consumed * layoutState.LayoutDirection;
                
                // Consume the available space if:
                // layoutChunk did not request to be ignored
                // OR we are laying out scrap children
                // OR we are not doing pre-layout
                if (!layoutChunkResult.IgnoreConsumed)
                {
                    layoutState.Available -= layoutChunkResult.Consumed;
                    // we keep a separate remaining space because mAvailable is important for recycling
                    remainingSpace -= layoutChunkResult.Consumed;
                }

                if (layoutState.ScrollingOffset != LayoutState.SCROLLING_OFFSET_NaN)
                {
                    layoutState.ScrollingOffset += layoutChunkResult.Consumed;
                    if (layoutState.Available < 0)
                    {
                        layoutState.ScrollingOffset += layoutState.Available;
                    }
                    if (immediate == true)
                    {
                        RecycleByLayoutState(recycler, layoutState, true);
                    }
                }
                if (stopOnFocusable && layoutChunkResult.Focusable)
                {
                    break;
                }
            }
            if (immediate == false)
            {
                RecycleByLayoutState(recycler, layoutState, false);
            }

            return start - layoutState.Available;
        }

        private void Cache(FlexibleView.Recycler recycler, LayoutState layoutState, bool immediate, float scrolled = 0)
        {
            if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
            {
                // get the first child in the direction we are going
                FlexibleView.ViewHolder child = GetChildClosestToEnd();
                if (child != null)
                {
                    if (child.ItemView.Focusable == false || mOrientationHelper.GetViewHolderEnd(child) + scrolled < mOrientationHelper.GetEnd())
                    {
                        layoutState.Available = MAX_SCROLL_FACTOR * mOrientationHelper.GetTotalSpace();
                        layoutState.Extra = 0;
                        layoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
                        layoutState.Recycle = false;
                        Fill(recycler, layoutState, true, immediate);
                    }
                }
            }
            else
            {
                FlexibleView.ViewHolder child = GetChildClosestToStart();
                if (child != null)
                {
                    if (child.ItemView.Focusable == false || mOrientationHelper.GetViewHolderStart(child) + scrolled > 0)
                    {
                        layoutState.Available = MAX_SCROLL_FACTOR * mOrientationHelper.GetTotalSpace();
                        layoutState.Extra = 0;
                        layoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
                        layoutState.Recycle = false;
                        Fill(recycler, layoutState, true, immediate);
                    }
                }
            }
        }

        private void RecycleByLayoutState(FlexibleView.Recycler recycler, LayoutState layoutState, bool immediate)
        {
            if (!layoutState.Recycle)
            {
                return;
            }
            if (layoutState.LayoutDirection == LayoutState.LAYOUT_START)
            {
                RecycleViewsFromEnd(recycler, layoutState.ScrollingOffset, immediate);
            }
            else
            {
                RecycleViewsFromStart(recycler, layoutState.ScrollingOffset, immediate);
            }
        }

        private void RecycleViewsFromStart(FlexibleView.Recycler recycler, float dt, bool immediate)
        {
            if (dt < 0)
            {
                return;
            }
            // ignore padding, ViewGroup may not clip children.
            float limit = dt;
            int childCount = ChildCount;
            if (mShouldReverseLayout)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderEnd(child) > limit)
                    {
                        // stop here
                        RecycleChildren(recycler, childCount - 1, i, immediate);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderEnd(child) > limit)
                    {
                        // stop here
                        RecycleChildren(recycler, 0, i, immediate);
                        return;
                    }
                }
            }
        }

        private void RecycleViewsFromEnd(FlexibleView.Recycler recycler, float dt, bool immediate)
        {
            if (dt < 0)
            {
                return;
            }
            int childCount = ChildCount;
            float limit = mOrientationHelper.GetEnd() - dt;
            if (mShouldReverseLayout)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderStart(child) < limit)
                    {
                        // stop here
                        RecycleChildren(recycler, 0, i, immediate);
                        return;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderStart(child) < limit)
                    {
                        // stop here
                        RecycleChildren(recycler, childCount - 1, i, immediate);
                        return;
                    }
                }
            }
        }

        private float ScrollBy(float dy, FlexibleView.Recycler recycler, bool immediate)
        {
            if (ChildCount == 0 || dy == 0)
            {
                return 0;
            }
            mLayoutState.Recycle = true;
            int layoutDirection = dy < 0 ? LayoutState.LAYOUT_END : LayoutState.LAYOUT_START;
            float absDy = Math.Abs(dy);

            UpdateLayoutState(layoutDirection, absDy, true);

            float consumed = mLayoutState.ScrollingOffset
                + Fill(recycler, mLayoutState, false, immediate);

            if (consumed < 0)
            {
                return 0;
            }

            float scrolled = absDy > consumed ? -layoutDirection * consumed : dy;
            Cache(recycler, mLayoutState, immediate, scrolled);

            mOrientationHelper.OffsetChildren(scrolled, immediate);

            return scrolled;
        }

        private void UpdateLayoutState(int layoutDirection, float requiredSpace, bool canUseExistingSpace)
        {
            mLayoutState.Extra = 0;
            mLayoutState.LayoutDirection = layoutDirection;
            float scrollingOffset = 0.0f;
            if (layoutDirection == LayoutState.LAYOUT_END)
            {
                mLayoutState.Extra += mOrientationHelper.GetEndPadding();
                // get the first child in the direction we are going
                FlexibleView.ViewHolder child = GetChildClosestToEnd();
                if (child != null)
                {
                    // the direction in which we are traversing children
                    mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD
                            : LayoutState.ITEM_DIRECTION_TAIL;
                    mLayoutState.CurrentPosition = child.LayoutPosition + mLayoutState.ItemDirection;
                    mLayoutState.Offset = mOrientationHelper.GetViewHolderEnd(child);
                    // calculate how much we can scroll without adding new children (independent of layout)
                    scrollingOffset = mOrientationHelper.GetViewHolderEnd(child)
                            - mOrientationHelper.GetEndAfterPadding();
                }

            }
            else
            {
                mLayoutState.Extra += mOrientationHelper.GetStartAfterPadding();
                FlexibleView.ViewHolder child = GetChildClosestToStart();
                if (child != null)
                {
                   mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL
                           : LayoutState.ITEM_DIRECTION_HEAD;
                   mLayoutState.CurrentPosition = child.LayoutPosition + mLayoutState.ItemDirection;
                   mLayoutState.Offset = mOrientationHelper.GetViewHolderStart(child);
                   scrollingOffset = -mOrientationHelper.GetViewHolderStart(child)
                           + mOrientationHelper.GetStartAfterPadding();
                }
            }
            mLayoutState.Available = requiredSpace;
            if (canUseExistingSpace)
            {
                mLayoutState.Available -= scrollingOffset;
            }
            mLayoutState.ScrollingOffset = scrollingOffset;
        }

        // Convenience method to find the child closes to start. Caller should check it has enough
        // children.
        //
        // @return The child closes to start of the layout from user's perspective.
        private FlexibleView.ViewHolder GetChildClosestToStart()
        {
            return GetChildAt(mShouldReverseLayout ? ChildCount - 1 : 0);
        }

        // Convenience method to find the child closes to end. Caller should check it has enough
        // children.
        //
        // @return The child closes to end of the layout from user's perspective.
        private FlexibleView.ViewHolder GetChildClosestToEnd()
        {
            return GetChildAt(mShouldReverseLayout ? 0 : ChildCount - 1);
        }

        private void UpdateLayoutStateToFillEnd(int itemPosition, float offset)
        {
            mLayoutState.Available = mOrientationHelper.GetEndAfterPadding() - offset;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD :
                    LayoutState.ITEM_DIRECTION_TAIL;
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_END;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = mOrientationHelper.GetEndPadding();
        }

        private void UpdateLayoutStateToFillStart(int itemPosition, float offset)
        {
            mLayoutState.Available = offset - mOrientationHelper.GetStartAfterPadding();
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL :
                    LayoutState.ITEM_DIRECTION_HEAD;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_START;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = mOrientationHelper.GetStartAfterPadding();
        }

        private FlexibleView.ViewHolder FindFirstCompleteVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int start = (int)mOrientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    int start = (int)mOrientationHelper.GetViewHolderStart(child);
                    if (start > 0 && start < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        private FlexibleView.ViewHolder FindLastCompleteVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        // Helper class that keeps temporary state while {LayoutManager} is filling out the empty space.
        internal class LayoutState
        {
            public static readonly int LAYOUT_START = -1;

            public static readonly int LAYOUT_END = 1;

            public static readonly int INVALID_LAYOUT = -1000;

            public static readonly int ITEM_DIRECTION_HEAD = -1;

            public static readonly int ITEM_DIRECTION_TAIL = 1;

            public static readonly int SCROLLING_OFFSET_NaN = -10000;

            // We may not want to recycle children in some cases (e.g. layout)
            public bool Recycle = true;

            // Pixel offset where layout should start
            public float Offset;

            // Number of pixels that we should fill, in the layout direction.
            public float Available;

            // Current position on the adapter to get the next item.
            public int CurrentPosition;

            // Defines the direction in which the data adapter is traversed.
            // Should be {@link #ITEM_DIRECTION_HEAD} or {@link #ITEM_DIRECTION_TAIL}
            public int ItemDirection;

            // Defines the direction in which the layout is filled.
            // Should be {@link #LAYOUT_START} or {@link #LAYOUT_END}
            public int LayoutDirection;

            // Used when LayoutState is constructed in a scrolling state.
            // It should be set the amount of scrolling we can make without creating a new view.
            // Settings this is required for efficient view recycling.
            public float ScrollingOffset;

            // Used if you want to pre-layout items that are not yet visible.
            // The difference with {@link #mAvailable} is that, when recycling, distance laid out for
            // {@link #mExtra} is not considered to avoid recycling visible children.
            public float Extra = 0;


            // @return true if there are more items in the data adapter
            public bool HasMore(int itemCount)
            {
                return CurrentPosition >= 0 && CurrentPosition < itemCount;
            }

            // Gets the view for the next element that we should layout.
            // Also updates current item index to the next item, based on {@link #mItemDirection}
            //
            // @return The next element that we should layout.
            public FlexibleView.ViewHolder Next(FlexibleView.Recycler recycler)
            {
                FlexibleView.ViewHolder itemView = recycler.GetViewForPosition(CurrentPosition);
                CurrentPosition += ItemDirection;
                return itemView;
            }
        }

        internal class LayoutChunkResult
        {
            public float Consumed;
            public bool Finished;
            public bool IgnoreConsumed;
            public bool Focusable;

            public void ResetInternal()
            {
                Consumed = 0;
                Finished = false;
                IgnoreConsumed = false;
                Focusable = false;
            }
        }

        internal class AnchorInfo
        {
            public int Position;
            public float Coordinate;
            public bool LayoutFromEnd;
            public bool Valid;

            public void Reset()
            {
                Position = NO_POSITION;
                Coordinate = INVALID_OFFSET;
                LayoutFromEnd = false;
                Valid = false;
            }

        }
    }
}
