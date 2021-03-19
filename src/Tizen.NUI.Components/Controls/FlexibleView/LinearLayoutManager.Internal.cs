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
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Components
{
    public partial class LinearLayoutManager
    {
        internal virtual void LayoutChunk(FlexibleViewRecycler recycler,
            LayoutState layoutState, LayoutChunkResult result)
        {
            FlexibleViewViewHolder holder = layoutState.Next(recycler);
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

            result.Consumed = orientationHelper.GetViewHolderMeasurement(holder);

            float left, top, width, height;
            if (Orientation == VERTICAL)
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

        internal override FlexibleViewViewHolder OnFocusSearchFailed(FlexibleViewViewHolder focused, FlexibleViewLayoutManager.Direction direction, FlexibleViewRecycler recycler)
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
            int maxScroll = (int)(MAX_SCROLL_FACTOR * orientationHelper.GetTotalSpace());
            UpdateLayout(layoutDir, maxScroll, false);
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Recycle = false;
            Fill(recycler, mLayoutState, true, true);

            FlexibleViewViewHolder nextFocus;
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

        private void UpdateAnchorInfoForLayout(FlexibleViewRecycler recycler, AnchorInfo anchorInfo)
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
            anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? orientationHelper.GetEndAfterPadding() : orientationHelper.GetStartAfterPadding();
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
                anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? orientationHelper.GetEndAfterPadding() : orientationHelper.GetStartAfterPadding();
            }
            else
            {
                if (mShouldReverseLayout)
                {
                    anchorInfo.Coordinate = orientationHelper.GetEndAfterPadding()
                            - mPendingScrollPositionOffset;
                }
                else
                {
                    anchorInfo.Coordinate = orientationHelper.GetStartAfterPadding()
                            + mPendingScrollPositionOffset;
                }
            }

            return true;
        }

        // Finds an anchor child from existing Views. Most of the time, this is the view closest to
        // start or end that has a valid position (e.g. not removed).
        // If a child has focus, it is given priority.
        private bool UpdateAnchorFromChildren(FlexibleViewRecycler recycler, AnchorInfo anchorInfo)
        {
            if (ChildCount == 0)
            {
                return false;
            }

            FlexibleViewViewHolder anchorChild = FindFirstVisibleItemView();
            if (anchorChild == null)
            {
                Log.Error("flexibleview", $"exception occurs when updating anchor information!");
                anchorChild = GetChildAt(0);
            }
            anchorInfo.Position = anchorChild.LayoutPosition;
            anchorInfo.Coordinate = orientationHelper.GetViewHolderStart(anchorChild);

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
        private int ConvertFocusDirectionToLayoutDirection(FlexibleViewLayoutManager.Direction focusDirection)
        {
            switch (focusDirection)
            {
                case FlexibleViewLayoutManager.Direction.Up:
                    return Orientation == VERTICAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleViewLayoutManager.Direction.Down:
                    return Orientation == VERTICAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleViewLayoutManager.Direction.Left:
                    return Orientation == HORIZONTAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case FlexibleViewLayoutManager.Direction.Right:
                    return Orientation == HORIZONTAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                default:
                    return LayoutState.INVALID_LAYOUT;
            }

        }


        private float Fill(FlexibleViewRecycler recycler, LayoutState layoutState, bool stopOnFocusable, bool immediate)
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

        private void Cache(FlexibleViewRecycler recycler, LayoutState layoutState, bool immediate, float scrolled = 0)
        {
            if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
            {
                // get the first child in the direction we are going
                FlexibleViewViewHolder child = GetChildClosestToEnd();
                if (child != null)
                {
                    if (child.ItemView.Focusable == false || orientationHelper.GetViewHolderEnd(child) + scrolled < orientationHelper.GetEnd())
                    {
                        layoutState.Available = MAX_SCROLL_FACTOR * orientationHelper.GetTotalSpace();
                        layoutState.Extra = 0;
                        layoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
                        layoutState.Recycle = false;
                        Fill(recycler, layoutState, true, immediate);
                    }
                }
            }
            else
            {
                FlexibleViewViewHolder child = GetChildClosestToStart();
                if (child != null)
                {
                    if (child.ItemView.Focusable == false || orientationHelper.GetViewHolderStart(child) + scrolled > 0)
                    {
                        layoutState.Available = MAX_SCROLL_FACTOR * orientationHelper.GetTotalSpace();
                        layoutState.Extra = 0;
                        layoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
                        layoutState.Recycle = false;
                        Fill(recycler, layoutState, true, immediate);
                    }
                }
            }
        }

        private void RecycleByLayoutState(FlexibleViewRecycler recycler, LayoutState layoutState, bool immediate)
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

        private void RecycleViewsFromStart(FlexibleViewRecycler recycler, float dt, bool immediate)
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
                    FlexibleViewViewHolder child = GetChildAt(i);
                    if (orientationHelper.GetViewHolderEnd(child) > limit)
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
                    FlexibleViewViewHolder child = GetChildAt(i);
                    if (orientationHelper.GetViewHolderEnd(child) > limit)
                    {
                        // stop here
                        RecycleChildren(recycler, 0, i, immediate);
                        return;
                    }
                }
            }
        }

        private void RecycleViewsFromEnd(FlexibleViewRecycler recycler, float dt, bool immediate)
        {
            if (dt < 0)
            {
                return;
            }
            int childCount = ChildCount;
            float limit = orientationHelper.GetEnd() - dt;
            if (mShouldReverseLayout)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    if (orientationHelper.GetViewHolderStart(child) < limit)
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
                    FlexibleViewViewHolder child = GetChildAt(i);
                    if (orientationHelper.GetViewHolderStart(child) < limit)
                    {
                        // stop here
                        RecycleChildren(recycler, childCount - 1, i, immediate);
                        return;
                    }
                }
            }
        }

        private float ScrollBy(float dy, FlexibleViewRecycler recycler, bool immediate)
        {
            if (ChildCount == 0 || dy == 0)
            {
                return 0;
            }
            mLayoutState.Recycle = true;
            int layoutDirection = dy < 0 ? LayoutState.LAYOUT_END : LayoutState.LAYOUT_START;
            float absDy = Math.Abs(dy);

            UpdateLayout(layoutDirection, absDy, true);

            float consumed = mLayoutState.ScrollingOffset
                + Fill(recycler, mLayoutState, false, immediate);

            if (consumed < 0)
            {
                return 0;
            }

            float scrolled = absDy > consumed ? -layoutDirection * consumed : dy;
            Cache(recycler, mLayoutState, immediate, scrolled);

            orientationHelper.OffsetChildren(scrolled, immediate);

            return scrolled;
        }

        private void UpdateLayout(int direction, float space, bool canUseExistingSpace)
        {
            mLayoutState.ResetLayout(direction, canUseExistingSpace, space, orientationHelper, this);
        }

        // Convenience method to find the child closes to start. Caller should check it has enough
        // children.
        //
        // @return The child closes to start of the layout from user's perspective.
        private FlexibleViewViewHolder GetChildClosestToStart()
        {
            return GetChildAt(mShouldReverseLayout ? ChildCount - 1 : 0);
        }

        // Convenience method to find the child closes to end. Caller should check it has enough
        // children.
        //
        // @return The child closes to end of the layout from user's perspective.
        private FlexibleViewViewHolder GetChildClosestToEnd()
        {
            return GetChildAt(mShouldReverseLayout ? 0 : ChildCount - 1);
        }

        private void UpdateLayoutStateToFillEnd(int itemPosition, float offset)
        {
            mLayoutState.Available = orientationHelper.GetEndAfterPadding() - offset;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD :
                    LayoutState.ITEM_DIRECTION_TAIL;
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_END;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = orientationHelper.GetEndPadding();

        }

        private void UpdateLayoutStateToFillStart(int itemPosition, float offset)
        {
            mLayoutState.Available = offset - orientationHelper.GetStartAfterPadding();
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL :
                    LayoutState.ITEM_DIRECTION_HEAD;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_START;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = orientationHelper.GetStartAfterPadding();
        }

        private FlexibleViewViewHolder FindFirstCompleteVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
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
            else
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
            return null;
        }

        private FlexibleViewViewHolder FindLastCompleteVisibleItemView()
        {
            int childCount = ChildCount;
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleViewViewHolder child = GetChildAt(i);
                    if ((int)orientationHelper.GetViewHolderEnd(child) < (int)orientationHelper.GetEnd())
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
                    if ((int)orientationHelper.GetViewHolderEnd(child) < (int)orientationHelper.GetEnd())
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
            public const int LAYOUT_START = -1;

            public const int LAYOUT_END = 1;

            public const int INVALID_LAYOUT = -1000;

            public const int ITEM_DIRECTION_HEAD = -1;

            public const int ITEM_DIRECTION_TAIL = 1;

            public const int SCROLLING_OFFSET_NaN = -10000;

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
            public FlexibleViewViewHolder Next(FlexibleViewRecycler recycler)
            {
                FlexibleViewViewHolder itemView = recycler.GetViewForPosition(CurrentPosition);
                CurrentPosition += ItemDirection;

                return itemView;
            }

            public void ResetLayout(int direction, bool canUseExistingSpace, float space, OrientationHelper orientationHelper, LinearLayoutManager linearLayoutManager)
            {
                this.Extra = 0;
                this.LayoutDirection = direction;

                float scrollingOffset = 0.0f;
                if (direction == LayoutState.LAYOUT_END)
                {
                    this.Extra += orientationHelper.GetEndPadding();
                    FlexibleViewViewHolder endChild = linearLayoutManager.GetChildClosestToEnd();
                    if (endChild != null)
                    {
                        // the direction in which we are traversing children
                        this.ItemDirection = linearLayoutManager.mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD
                                : LayoutState.ITEM_DIRECTION_TAIL;
                        this.CurrentPosition = endChild.LayoutPosition + linearLayoutManager.mLayoutState.ItemDirection;
                        this.Offset = orientationHelper.GetViewHolderEnd(endChild);
                        scrollingOffset = orientationHelper.GetViewHolderEnd(endChild) - orientationHelper.GetEndAfterPadding();
                    }

                }
                else
                {
                    this.Extra += orientationHelper.GetStartAfterPadding();
                    FlexibleViewViewHolder startChild = linearLayoutManager.GetChildClosestToStart();
                    if (startChild != null)
                    {
                        this.ItemDirection = linearLayoutManager.mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL
                                : LayoutState.ITEM_DIRECTION_HEAD;
                        this.CurrentPosition = startChild.LayoutPosition + linearLayoutManager.mLayoutState.ItemDirection;
                        this.Offset = orientationHelper.GetViewHolderStart(startChild);
                        scrollingOffset = -orientationHelper.GetViewHolderStart(startChild) + orientationHelper.GetStartAfterPadding();
                    }
                }

                this.Available = space;

                if (canUseExistingSpace)
                {
                    this.Available -= scrollingOffset;
                }
                this.ScrollingOffset = scrollingOffset;
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
