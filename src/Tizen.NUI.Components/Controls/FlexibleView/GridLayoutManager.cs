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
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Layout collection of views in a grid.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GridLayoutManager : LinearLayoutManager
    {
        private const int DEFAULT_SPAN_COUNT = -1;

        private int spanCount = DEFAULT_SPAN_COUNT;

        /// <summary>
        /// Creates a GridLayoutManager with orientation. 
        /// </summary>
        /// <param name="spanCount">The number of columns or rows in the grid</param>
        /// <param name="orientation">Layout orientation.Should be HORIZONTAL or VERTICAL</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GridLayoutManager(int spanCount, int orientation) : base(orientation)
        {
            this.spanCount = spanCount;
        }

        internal override void EnsureAnchorReady(FlexibleViewRecycler recycler, AnchorInfo anchorInfo, int itemDirection)
        {
            bool layingOutInPrimaryDirection = (itemDirection == LayoutState.ITEM_DIRECTION_TAIL);
            int span = anchorInfo.Position % spanCount;
            if (layingOutInPrimaryDirection)
            {
                // choose span 0
                while (span > 0 && anchorInfo.Position > 0)
                {
                    anchorInfo.Position--;
                    span = anchorInfo.Position;
                }
            }
            else
            {
                // choose the max span we can get. hopefully last one
                int indexLimit = ChildCount - 1;
                int pos = anchorInfo.Position;
                int bestSpan = span;
                while (pos < indexLimit)
                {
                    int next = (pos + 1) % spanCount;
                    if (next > bestSpan)
                    {
                        pos += 1;
                        bestSpan = next;
                    }
                    else
                    {
                        break;
                    }
                }
                anchorInfo.Position = pos;
            }
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
                        if (position >= spanCount)
                        {
                            return position - spanCount;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Right:
                        if (position < ItemCount - spanCount)
                        {
                            return position + spanCount;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Up:
                        if (position % spanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Down:
                        if (position < ItemCount - 1 && (position % spanCount < spanCount - 1))
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
                    case FlexibleViewLayoutManager.Direction.Left:
                        if (position % spanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Right:
                        if (position < ItemCount - 1 && (position % spanCount < spanCount - 1))
                        {
                            return position + 1;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Up:
                        if (position >= spanCount)
                        {
                            return position - spanCount;
                        }
                        break;
                    case FlexibleViewLayoutManager.Direction.Down:
                        if (position < ItemCount - spanCount)
                        {
                            return position + spanCount;
                        }
                        break;
                }
            }

            return NO_POSITION;
        }

        internal override void LayoutChunk(FlexibleViewRecycler recycler,
            LayoutState layoutState, LayoutChunkResult result)
        {
            bool layingOutInPrimaryDirection =
                layoutState.ItemDirection == LayoutState.ITEM_DIRECTION_TAIL;

            int count = spanCount;
            for (int i = 0; i < count; i++)
            {
                FlexibleViewViewHolder holder = layoutState.Next(recycler);
                if (holder == null)
                {
                    result.Finished = true;
                    return;
                }

                if (layingOutInPrimaryDirection)
                    AddView(holder);
                else
                    AddView(holder, 0);

                result.Consumed = orientationHelper.GetViewHolderMeasurement(holder);

                float left, top, width, height;
                if (Orientation == VERTICAL)
                {
                    width = (Width - PaddingLeft - PaddingRight) / count;
                    height = result.Consumed;
                    if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                    {
                        left = PaddingLeft + width * i;
                        top = layoutState.Offset;
                    }
                    else
                    {
                        left = PaddingLeft + width * (count - 1 - i);
                        top = layoutState.Offset - height;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
                else
                {
                    width = result.Consumed;
                    height = (Height - PaddingTop - PaddingBottom) / count;
                    if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                    {
                        top = PaddingTop + height * i;
                        left = layoutState.Offset;
                    }
                    else
                    {
                        top = PaddingTop + height * (count - 1 - i);
                        left = layoutState.Offset - width;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
            }
        }
    }
}
