using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class FlexibleView
    {
        internal class RecycledViewPool
        {
            private FlexibleView mFlexibleView;

            private int mMaxTypeCount = 10;
            private List<FlexibleViewViewHolder>[] mScrap;

            public RecycledViewPool(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
                mScrap = new List<FlexibleViewViewHolder>[mMaxTypeCount];
            }

            //public void SetViewTypeCount(int typeCount)
            //{
            //}

            public FlexibleViewViewHolder GetRecycledView(int viewType)
            {
                if (viewType >= mMaxTypeCount || mScrap[viewType] == null)
                {
                    return null;
                }

                int index = mScrap[viewType].Count - 1;
                if (index < 0)
                {
                    return null;
                }
                FlexibleViewViewHolder recycledView = mScrap[viewType][index];
                mScrap[viewType].RemoveAt(index);

                return recycledView;
            }

            public void PutRecycledView(FlexibleViewViewHolder view)
            {
                int viewType = view.ItemViewType;
                if (viewType >= mMaxTypeCount)
                {
                    return;
                }
                if (mScrap[viewType] == null)
                {
                    mScrap[viewType] = new List<FlexibleViewViewHolder>();
                }
                view.IsBound = false;
                mScrap[viewType].Add(view);
            }

            public void Clear()
            {
                for (int i = 0; i < mMaxTypeCount; i++)
                {
                    if (mScrap[i] == null)
                    {
                        continue;
                    }
                    for (int j = 0; j < mScrap[i].Count; j++)
                    {
                        mFlexibleView.DispatchChildDestroyed(mScrap[i][j]);
                    }
                    mScrap[i].Clear();
                }
            }
        }

        internal class ChildHelper : Disposable
        {
            private FlexibleView mFlexibleView;

            private List<FlexibleViewViewHolder> mViewList = new List<FlexibleViewViewHolder>();

            //private List<FlexibleViewViewHolder> mRemovePendingViews;

            private Dictionary<uint, FlexibleViewViewHolder> itemViewTable = new Dictionary<uint, FlexibleViewViewHolder>();
            private TapGestureDetector mTapGestureDetector;

            public ChildHelper(FlexibleView owner)
            {
                mFlexibleView = owner;

                mTapGestureDetector = new TapGestureDetector();
                mTapGestureDetector.Detected += OnTapGestureDetected;
            }

            public void Clear()
            {
                foreach (FlexibleViewViewHolder holder in mViewList)
                {
                    mFlexibleView.Remove(holder.ItemView);

                    mFlexibleView.DispatchChildDestroyed(holder);
                }
                mViewList.Clear();
            }

            public void ScrapViews(FlexibleViewRecycler recycler)
            {
                recycler.Clear();
                foreach (FlexibleViewViewHolder itemView in mViewList)
                {
                    recycler.ScrapView(itemView);
                }

                mViewList.Clear();
            }

            public void AttachView(FlexibleViewViewHolder holder, int index)
            {
                if (index == -1)
                {
                    index = mViewList.Count;
                }

                mViewList.Insert(index, holder);

                if (!itemViewTable.ContainsKey(holder.ItemView.ID))
                {
                    mTapGestureDetector.Attach(holder.ItemView);
                    holder.ItemView.TouchEvent += OnTouchEvent;
                }

                itemViewTable[holder.ItemView.ID] = holder;
            }

            public void AddView(FlexibleViewViewHolder holder, int index)
            {
                mFlexibleView.Add(holder.ItemView);

                mFlexibleView.DispatchChildAttached(holder);

                AttachView(holder, index);
            }

            public bool RemoveView(FlexibleViewViewHolder holder)
            {
                mFlexibleView.Remove(holder.ItemView);

                mFlexibleView.DispatchChildDetached(holder);

                return mViewList.Remove(holder);
            }

            public bool RemoveViewAt(int index)
            {
                FlexibleViewViewHolder itemView = mViewList[index];
                return RemoveView(itemView);
            }

            public bool RemoveViewsRange(int index, int count)
            {
                for (int i = index; i < index + count; i++)
                {
                    FlexibleViewViewHolder holder = mViewList[i];
                    mFlexibleView.Remove(holder.ItemView);
                }
                mViewList.RemoveRange(index, count);
                return false;
            }

            public int GetChildCount()
            {
                return mViewList.Count;
            }

            public FlexibleViewViewHolder GetChildAt(int index)
            {
                if (index < 0 || index >= mViewList.Count)
                {
                    return null;
                }
                return mViewList[index];
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

                    if (mTapGestureDetector != null)
                    {
                        mTapGestureDetector.Detected -= OnTapGestureDetected;
                        mTapGestureDetector.Dispose();
                        mTapGestureDetector = null;
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
                    mFlexibleView.FocusedItemIndex = holder.AdapterPosition;

                    mFlexibleView.DispatchItemClicked(holder);
                }
            }

            private bool OnTouchEvent(object source, View.TouchEventArgs e)
            {
                View itemView = source as View;
                if (itemView != null && itemViewTable.ContainsKey(itemView.ID))
                {
                    FlexibleViewViewHolder holder = itemViewTable[itemView.ID];

                    mFlexibleView.DispatchItemTouched(holder, e.Touch);
                    return true;
                }
                return false;
            }
        }

        private class AdapterHelper
        {
            private FlexibleView mFlexibleView;

            private List<UpdateOp> mPendingUpdates = new List<UpdateOp>();

            private int mExistingUpdateTypes = 0;

            public AdapterHelper(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
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
                mPendingUpdates.Add(new UpdateOp(UpdateOp.ADD, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.ADD;
                return mPendingUpdates.Count == 1;
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
                mPendingUpdates.Add(new UpdateOp(UpdateOp.REMOVE, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.REMOVE;
                return mPendingUpdates.Count == 1;
            }

            public void PreProcess()
            {
                int count = mPendingUpdates.Count;
                for (int i = 0; i < count; i++)
                {
                    UpdateOp op = mPendingUpdates[i];
                    switch (op.cmd)
                    {
                        case UpdateOp.ADD:
                            mFlexibleView.OffsetPositionRecordsForInsert(op.positionStart, op.itemCount);
                            break;
                        case UpdateOp.REMOVE:
                            mFlexibleView.OffsetPositionRecordsForRemove(op.positionStart, op.itemCount, false);
                            break;
                        case UpdateOp.UPDATE:
                            break;
                        case UpdateOp.MOVE:
                            break;
                    }
                }
                mPendingUpdates.Clear();
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
