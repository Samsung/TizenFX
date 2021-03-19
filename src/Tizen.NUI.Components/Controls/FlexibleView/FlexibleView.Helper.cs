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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class FlexibleView
    {
        internal class RecycledViewPool
        {
            private FlexibleView flexibleView;

            private int maxTypeCount = 10;
            private List<FlexibleViewViewHolder>[] scrap;

            public RecycledViewPool(FlexibleView flexibleView)
            {
                this.flexibleView = flexibleView;
                scrap = new List<FlexibleViewViewHolder>[maxTypeCount];
            }

            public FlexibleViewViewHolder GetRecycledView(int viewType)
            {
                if (viewType >= maxTypeCount || scrap[viewType] == null)
                {
                    return null;
                }

                int index = scrap[viewType].Count - 1;
                if (index < 0)
                {
                    return null;
                }
                FlexibleViewViewHolder recycledView = scrap[viewType][index];
                scrap[viewType].RemoveAt(index);

                return recycledView;
            }

            public void PutRecycledView(FlexibleViewViewHolder view)
            {
                int viewType = view.ItemViewType;
                if (viewType >= maxTypeCount)
                {
                    return;
                }
                if (scrap[viewType] == null)
                {
                    scrap[viewType] = new List<FlexibleViewViewHolder>();
                }
                view.IsBound = false;
                scrap[viewType].Add(view);
            }

            public void Clear()
            {
                for (int i = 0; i < maxTypeCount; i++)
                {
                    if (scrap[i] == null)
                    {
                        continue;
                    }
                    for (int j = 0; j < scrap[i].Count; j++)
                    {
                        flexibleView.DispatchChildDestroyed(scrap[i][j]);
                    }
                    scrap[i].Clear();
                }
            }
        }

        internal class ChildHelper : Disposable
        {
            private FlexibleView flexibleView;
            private List<FlexibleViewViewHolder> viewList = new List<FlexibleViewViewHolder>();
            private Dictionary<uint, FlexibleViewViewHolder> itemViewTable = new Dictionary<uint, FlexibleViewViewHolder>();
            private TapGestureDetector tapGestureDetector;

            public ChildHelper(FlexibleView owner)
            {
                flexibleView = owner;

                tapGestureDetector = new TapGestureDetector();
                tapGestureDetector.Detected += OnTapGestureDetected;
            }

            public void Clear()
            {
                foreach (FlexibleViewViewHolder holder in viewList)
                {
                    flexibleView.Remove(holder.ItemView);
                    flexibleView.DispatchChildDestroyed(holder);
                }
                viewList.Clear();
            }

            public void ScrapViews(FlexibleViewRecycler recycler)
            {
                recycler.Clear();
                foreach (FlexibleViewViewHolder itemView in viewList)
                {
                    recycler.ScrapView(itemView);
                }

                viewList.Clear();
            }

            public void AttachView(FlexibleViewViewHolder holder, int index)
            {
                if (index == -1)
                {
                    index = viewList.Count;
                }

                viewList.Insert(index, holder);

                if (!itemViewTable.ContainsKey(holder.ItemView.ID))
                {
                    tapGestureDetector.Attach(holder.ItemView);
                    holder.ItemView.TouchEvent += OnTouchEvent;
                }

                itemViewTable[holder.ItemView.ID] = holder;
            }

            public void AddView(FlexibleViewViewHolder holder, int index)
            {
                flexibleView.Add(holder.ItemView);
                flexibleView.DispatchChildAttached(holder);
                AttachView(holder, index);
            }

            public bool RemoveView(FlexibleViewViewHolder holder)
            {
                flexibleView.Remove(holder.ItemView);
                flexibleView.DispatchChildDetached(holder);
                return viewList.Remove(holder);
            }

            public bool RemoveViewAt(int index)
            {
                FlexibleViewViewHolder itemView = viewList[index];
                return RemoveView(itemView);
            }

            public bool RemoveViewsRange(int index, int count)
            {
                for (int i = index; i < index + count; i++)
                {
                    FlexibleViewViewHolder holder = viewList[i];
                    flexibleView.Remove(holder.ItemView);
                }
                viewList.RemoveRange(index, count);
                return false;
            }

            public int GetChildCount()
            {
                return viewList.Count;
            }

            public FlexibleViewViewHolder GetChildAt(int index)
            {
                if (index < 0 || index >= viewList.Count)
                {
                    return null;
                }
                return viewList[index];
            }

            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    Clear();

                    if (tapGestureDetector != null)
                    {
                        tapGestureDetector.Detected -= OnTapGestureDetected;
                        tapGestureDetector.Dispose();
                        tapGestureDetector = null;
                    }
                }
                base.Dispose(type);
            }

            private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
            {
                View itemView = e.View as View;
                if (itemView == null)
                {
                    return;
                }
                if (itemViewTable.ContainsKey(itemView.ID))
                {
                    FlexibleViewViewHolder holder = itemViewTable[itemView.ID];
                    flexibleView.FocusedItemIndex = holder.AdapterPosition;

                    flexibleView.DispatchItemClicked(holder);
                }
            }

            private bool OnTouchEvent(object source, View.TouchEventArgs e)
            {
                View itemView = source as View;
                if (itemView != null && itemViewTable.ContainsKey(itemView.ID))
                {
                    FlexibleViewViewHolder holder = itemViewTable[itemView.ID];

                    flexibleView.DispatchItemTouched(holder, e.Touch);
                    return true;
                }
                return false;
            }
        }

        private class AdapterHelper
        {
            private FlexibleView flexibleView;
            private List<UpdateOp> pendingUpdates = new List<UpdateOp>();
            private int existingUpdateTypes = 0;

            public AdapterHelper(FlexibleView flexibleView)
            {
                this.flexibleView = flexibleView;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeInserted(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                pendingUpdates.Add(new UpdateOp(UpdateOp.ADD, positionStart, itemCount));
                existingUpdateTypes |= UpdateOp.ADD;
                return pendingUpdates.Count == 1;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeRemoved(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                pendingUpdates.Add(new UpdateOp(UpdateOp.REMOVE, positionStart, itemCount));
                existingUpdateTypes |= UpdateOp.REMOVE;
                return pendingUpdates.Count == 1;
            }

            public void PreProcess()
            {
                int count = pendingUpdates.Count;
                for (int i = 0; i < count; i++)
                {
                    UpdateOp op = pendingUpdates[i];
                    switch (op.cmd)
                    {
                        case UpdateOp.ADD:
                            flexibleView.OffsetPositionRecordsForInsert(op.positionStart, op.itemCount);
                            break;
                        case UpdateOp.REMOVE:
                            flexibleView.OffsetPositionRecordsForRemove(op.positionStart, op.itemCount, false);
                            break;
                        case UpdateOp.UPDATE:
                            break;
                        case UpdateOp.MOVE:
                            break;
                    }
                }
                pendingUpdates.Clear();
            }

        }

        /**
         * Queued operation to happen when child views are updated.
         */
        private class UpdateOp
        {

            public const int ADD = 1;
            public const int REMOVE = 1 << 1;
            public const int UPDATE = 1 << 2;
            public const int MOVE = 1 << 3;
            public const int POOL_SIZE = 30;

            public int cmd;
            public int positionStart;

            // holds the target position if this is a MOVE
            public int itemCount;

            public UpdateOp(int cmd, int positionStart, int itemCount)
            {
                this.cmd = cmd;
                this.positionStart = positionStart;
                this.itemCount = itemCount;
            }

            public bool Equals(UpdateOp op)
            {
                if (cmd != op.cmd)
                {
                    return false;
                }
                if (cmd == MOVE && Math.Abs(itemCount - positionStart) == 1)
                {
                    // reverse of this is also true
                    if (itemCount == op.positionStart && positionStart == op.itemCount)
                    {
                        return true;
                    }
                }
                if (itemCount != op.itemCount)
                {
                    return false;
                }
                if (positionStart != op.positionStart)
                {
                    return false;
                }

                return true;
            }

        }

        private class ItemViewInfo
        {
            public float Left
            {
                get;
                set;
            }
            public float Top
            {
                get;
                set;
            }
            public float Right
            {
                get;
                set;
            }
            public float Bottom
            {
                get;
                set;
            }
        }
    }
}
