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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// A flexible view for providing a limited window into a large data set.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleView : Control
    {
        /// <summary>
        /// Constant value: -1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int NO_POSITION = -1;
        /// <summary>
        /// Constant value: -1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int INVALID_TYPE = -1;

        private Adapter mAdapter;
        private LayoutManager mLayout;
        private Recycler mRecycler;
        private RecycledViewPool mRecyclerPool;
        private ChildHelper mChildHelper;

        private PanGestureDetector mPanGestureDetector;

        private int mFocusedItemIndex = NO_POSITION;

        private AdapterHelper mAdapteHelper;

        private ScrollBar mScrollBar = null;
        private Timer mScrollBarShowTimer = null;

        private EventHandler<ItemClickEventArgs> clickEventHandlers;
        private EventHandler<ItemTouchEventArgs> touchEventHandlers;
        private EventHandler<NUI.StyleManager.StyleChangedEventArgs> styleChangedEventHandlers;

        /// <summary>
        /// Creates a FlexibleView instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleView()
        {
            mRecyclerPool = new RecycledViewPool(this);

            mRecycler = new Recycler(this);
            mRecycler.SetRecycledViewPool(mRecyclerPool);

            mChildHelper = new ChildHelper(this);

            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            mAdapteHelper = new AdapterHelper(this);

            ClippingMode = ClippingModeType.ClipToBoundingBox;
        }

        /// <summary>
        /// Item click event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemClickEventArgs> ItemClickEvent
        {
            add
            {
                clickEventHandlers += value;
            }

            remove
            {
                clickEventHandlers -= value;
            }
        }


        /// <summary>
        /// Item touch event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemTouchEventArgs> ItemTouchEvent
        {
            add
            {
                touchEventHandlers += value;
            }

            remove
            {
                touchEventHandlers -= value;
            }
        }

        /// <summary>
        /// Style changed, for example default font size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NUI.StyleManager.StyleChangedEventArgs> StyleChanged
        {
            add
            {
                styleChangedEventHandlers += value;
            }

            remove
            {
                styleChangedEventHandlers -= value;
            }
        }

        /// <summary>
        /// overwrite the Padding.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Extents Padding
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the focused item index(adapter position).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FocusedItemIndex
        {
            get
            {
                return mFocusedItemIndex;
            }
            set
            {
                if (value == mFocusedItemIndex)
                {
                    return;
                }

                if (mAdapter == null)
                {
                    return;
                }

                if (mLayout == null)
                {
                    return;
                }

                ViewHolder nextFocusView = FindViewHolderForAdapterPosition(value);
                if (nextFocusView == null)
                {
                    mLayout.ScrollToPosition(value);
                }
                else
                {
                    mLayout.RequestChildRectangleOnScreen(this, nextFocusView, mRecycler, true);
                    DispatchFocusChanged(value);
                }
            }
        }

        /// <summary>
        /// Set a new adapter to provide child views on demand.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAdapter(Adapter adapter)
        {
            if (adapter == null)
            {
                return;
            }
            mAdapter = adapter;

            mAdapter.ItemEvent += OnItemEvent;
        }

        /// <summary>
        /// Retrieves the previously set adapter or null if no adapter is set.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Adapter GetAdapter()
        {
            return mAdapter;
        }

        /// <summary>
        /// Set the FlexibleView.LayoutManager that this FlexibleView will use.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLayoutManager(LayoutManager layoutManager)
        {
            mLayout = layoutManager;

            mLayout.SetRecyclerView(this);

            if (mLayout.CanScrollHorizontally())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else if (mLayout.CanScrollVertically())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        /// <summary>
        /// Return the FlexibleView.LayoutManager currently responsible for layout policy for this FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutManager GetLayoutManager()
        {
            return mLayout;
        }


        /// <summary>
        /// Convenience method to scroll to a certain position
        /// </summary>
        /// <param name="position">Adapter position</param>
        /// <param name="offset">The distance (in pixels) between the start edge of the item view and start edge of the FlexibleView.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollToPositionWithOffset(int position, int offset)
        {
            mLayout.ScrollToPositionWithOffset(position, offset);
        }

        /// <summary>
        /// Move focus by direction.
        /// </summary>
        /// <param name="direction">Direction. Should be "Left", "Right", "Up" or "Down" </param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void MoveFocus(FlexibleView.LayoutManager.Direction direction)
        {
            mLayout.MoveFocus(direction, mRecycler);
        }

        /// <summary>
        /// Attach a scrollbar to this FlexibleView.
        /// </summary>
        /// <param name="scrollBar">ScrollBar</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AttachScrollBar(ScrollBar scrollBar)
        {
            if (scrollBar == null)
            {
                return;
            }
            mScrollBar = scrollBar;
            Add(mScrollBar);
        }

        /// <summary>
        /// Detach the scrollbar from this FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachScrollBar()
        {
            if (mScrollBar == null)
            {
                return;
            }
            Remove(mScrollBar);
            mScrollBar = null;
        }

        /// <summary>
        /// Return the ViewHolder for the item in the given position of the data set as of the latest layout pass.
        /// This method checks only the children of RecyclerView. If the item at the given position is not laid out, it will not create a new one.
        /// </summary>
        /// <param name="position">The position of the item in the data set of the adapter</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewHolder FindViewHolderForLayoutPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.LayoutPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Return the ViewHolder for the item in the given position of the data set.
        /// This method checks only the children of RecyclerView. If the item at the given position is not laid out, it will not create a new one.
        /// </summary>
        /// <param name="position">The position of the item in the data set of the adapter</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewHolder FindViewHolderForAdapterPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.AdapterPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Return the recycler instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Recycler GetRecycler()
        {
            return mRecycler;
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                mLayout.StopScroll();

                if (mAdapter != null)
                {
                    mAdapter.ItemEvent -= OnItemEvent;
                }

                if (mPanGestureDetector != null)
                {
                    mPanGestureDetector.Detected -= OnPanGestureDetected;
                    mPanGestureDetector.Dispose();
                    mPanGestureDetector = null;
                }

                if (mScrollBarShowTimer != null)
                {
                    mScrollBarShowTimer.Tick -= OnShowTimerTick;
                    mScrollBarShowTimer.Stop();
                    mScrollBarShowTimer.Dispose();
                    mScrollBarShowTimer = null;
                }

                if (mRecyclerPool != null)
                {
                    mRecyclerPool.Clear();
                    mRecyclerPool = null;
                }

                if (mChildHelper != null)
                {
                    mChildHelper.Clear();
                    mChildHelper = null;
                }
            }
            base.Dispose(type);
        }

        /// <summary>
        /// you can override it to create your own default attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return null;
        }

        /// <summary>
        /// you can override it to relayout elements.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (mAdapter == null)
            {
                return;
            }

            if (mLayout == null)
            {
                return;
            }

            DispatchLayoutStep1();

            mLayout.OnLayoutChildren(mRecycler);

            RemoveAndRecycleScrapInt();
        }

        /// <summary>
        /// you can override it to do something for style change.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStyleChange(NUI.StyleManager styleManager, StyleChangeType change)
        {
            if (change == StyleChangeType.DefaultFontSizeChange)
            {
                NUI.StyleManager.StyleChangedEventArgs args = new NUI.StyleManager.StyleChangedEventArgs();
                args.StyleManager = styleManager;
                args.StyleChange = change;

                styleChangedEventHandlers?.Invoke(this, args);

                RelayoutRequest();
            }
        }

        private void DispatchLayoutStep1()
        {
            ProcessAdapterUpdates();
            SaveOldPositions();
            ClearOldPositions();
        }

        private void ProcessAdapterUpdates()
        {
            mAdapteHelper.PreProcess();
        }

        private void OffsetPositionRecordsForInsert(int positionStart, int itemCount)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null && holder.AdapterPosition >= positionStart)
                {
                    holder.OffsetPosition(itemCount, false);
                }
            }

            if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex += itemCount;
            }
        }

        private void OffsetPositionRecordsForRemove(int positionStart, int itemCount, bool applyToPreLayout)
        {
            int positionEnd = positionStart + itemCount;
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null)
                {
                    if (holder.AdapterPosition >= positionEnd)
                    {
                        holder.OffsetPosition(-itemCount, applyToPreLayout);
                    }
                    else if (holder.AdapterPosition >= positionStart)
                    {
                        holder.FlagRemovedAndOffsetPosition(positionStart - 1, -itemCount, applyToPreLayout);
                    }
                }
            }

            if (positionEnd <= mFocusedItemIndex)
            {
                mFocusedItemIndex -= itemCount;
            }
            else if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex = positionStart;
                if (mFocusedItemIndex >= mAdapter.GetItemCount())
                {
                    mFocusedItemIndex = mAdapter.GetItemCount() - 1;
                }
            }
        }

        private void SaveOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.SaveOldPosition();
            }
        }

        private void ClearOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.ClearOldPosition();
            }
        }

        private void RemoveAndRecycleScrapInt()
        {
            int scrapCount = mRecycler.GetScrapCount();
            for (int i = 0; i < scrapCount; i++)
            {
                ViewHolder scrap = mRecycler.GetScrapViewAt(i);
                mChildHelper.RemoveView(scrap);
                mRecycler.RecycleView(scrap);
            }
            mRecycler.Clear();
        }

        private void ShowScrollBar(uint millisecond = 700, bool flagAni = false)
        {
            if (mScrollBar == null || mLayout == null)
            {
                return;
            }

            float extent = mLayout.ComputeScrollExtent();
            float range = mLayout.ComputeScrollRange();
            if(range == 0)
            {
                return;
            }
            float offset = mLayout.ComputeScrollOffset();

            float size = mScrollBar.Direction == ScrollBar.DirectionType.Vertical ? mScrollBar.SizeHeight : mScrollBar.SizeWidth;
            float thickness = mScrollBar.Direction == ScrollBar.DirectionType.Vertical ? mScrollBar.SizeWidth : mScrollBar.SizeHeight;
            float length = (float)Math.Round(size * extent / range);

            // avoid the tiny thumb
            float minLength = thickness * 2;
            if (length < minLength)
            {
                length = minLength;
            }
            // avoid the too-big thumb
            if (offset > range - extent)
            {
                offset = range - extent;
            }
            if (mScrollBar.Direction == ScrollBar.DirectionType.Vertical)
            {
                mScrollBar.ThumbSize = new Size2D((int)thickness, (int)length);
            }
            else
            {
                mScrollBar.ThumbSize = new Size2D((int)length, (int)thickness);
            }
            mScrollBar.MinValue = 0;
            mScrollBar.MaxValue = (int)(range - extent);
            mScrollBar.SetCurrentValue((int)offset, flagAni);
            mScrollBar.Show();
            if (mScrollBarShowTimer == null)
            {
                mScrollBarShowTimer = new Timer(millisecond);
                mScrollBarShowTimer.Tick += OnShowTimerTick;
            }
            else
            {
                mScrollBarShowTimer.Interval = millisecond;
            }
            mScrollBarShowTimer.Start();
        }

        private bool OnShowTimerTick(object source, EventArgs e)
        {
            if (mScrollBar != null)
            {
                mScrollBar.Hide();
            }

            return false;
        }

        private void DispatchFocusChanged(int nextFocusPosition)
        {
            mAdapter.OnFocusChange(this, mFocusedItemIndex, nextFocusPosition);

            mFocusedItemIndex = nextFocusPosition;
 
           ShowScrollBar();
        }

        private void DispatchChildAttached(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnViewAttachedToWindow(holder);
            }
        }

        private void DispatchChildDetached(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnViewDetachedFromWindow(holder);
            }
        }

        private void DispatchChildDestroyed(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnDestroyViewHolder(holder);
            }
        }

        private void DispatchItemClicked(ViewHolder clickedHolder)
        {
            ItemClickEventArgs args = new ItemClickEventArgs();
            args.ClickedView = clickedHolder;
            OnClickEvent(this, args);
        }

        private void DispatchItemTouched(ViewHolder touchedHolder, Touch touchEvent)
        {
            ItemTouchEventArgs args = new ItemTouchEventArgs();
            args.TouchedView = touchedHolder;
            args.Touch = touchEvent;
            OnTouchEvent(this, args);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                mLayout.StopScroll();
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (mLayout.CanScrollVertically())
                {
                    mLayout.ScrollVerticallyBy(e.PanGesture.Displacement.Y, mRecycler, true);
                }
                else if (mLayout.CanScrollHorizontally())
                {
                    mLayout.ScrollHorizontallyBy(e.PanGesture.Displacement.X, mRecycler, true);
                }

                ShowScrollBar();
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                if (mLayout.CanScrollVertically())
                {
                    mLayout.ScrollVerticallyBy(e.PanGesture.Velocity.Y * 600, mRecycler, false);
                }
                else if (mLayout.CanScrollHorizontally())
                {
                    mLayout.ScrollHorizontallyBy(e.PanGesture.Velocity.X * 600, mRecycler, false);
                }
                ShowScrollBar(1200, true);
            }
        }


        private void OnItemEvent(object sender, Adapter.ItemEventArgs e)
        {
            switch (e.EventType)
            {
                case Adapter.ItemEventType.Insert:
                    mAdapteHelper.OnItemRangeInserted(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case Adapter.ItemEventType.Remove:
                    mAdapteHelper.OnItemRangeRemoved(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case Adapter.ItemEventType.Move:
                    break;
                case Adapter.ItemEventType.Change:
                    break;
                default:
                    return;
            }
            RelayoutRequest();
        }


        private void OnClickEvent(object sender, ItemClickEventArgs e)
        {
            clickEventHandlers?.Invoke(sender, e);
        }

        private void OnTouchEvent(object sender, ItemTouchEventArgs e)
        {
            touchEventHandlers?.Invoke(sender, e);
        }

        /// <summary>
        /// ItemClick Event Arguments.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// The clicked ViewHolder.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder ClickedView;
        }

        /// <summary>
        /// ItemTouch Event Arguments.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemTouchEventArgs : TouchEventArgs
        {
            /// <summary>
            /// The touched ViewHolder.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder TouchedView;
        }

        /// <summary>
        /// Adapters provide a binding from an app-specific data set to views that are displayed within a FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class Adapter
        {
            private EventHandler<ItemEventArgs> itemEventHandlers;

            internal event EventHandler<ItemEventArgs> ItemEvent
            {
                add
                {
                    itemEventHandlers += value;
                }

                remove
                {
                    itemEventHandlers -= value;
                }
            }

            internal enum ItemEventType
            {
                Insert = 0,
                Remove,
                Move,
                Change
            }

            /// <summary>
            /// Called when FlexibleView needs a new FlexibleView.ViewHolder of the given type to represent an item.
            /// </summary>
            /// <param name="viewType">The view type of the new View</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract ViewHolder OnCreateViewHolder(int viewType);

            /// <summary>
            /// Called by FlexibleView to display the data at the specified position.
            /// </summary>
            /// <param name="holder">The ViewHolder which should be updated to represent the contents of the item at the given position in the data set.</param>
            /// <param name="position">The position of the item within the adapter's data set.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnBindViewHolder(ViewHolder holder, int position);

            /// <summary>
            /// Called when a ViewHolder is never used.
            /// </summary>
            /// <param name="holder">The ViewHolder which need to be disposed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnDestroyViewHolder(ViewHolder holder);

            /// <summary>
            /// Returns the total number of items in the data set held by the adapter.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract int GetItemCount();

            /// <summary>
            /// Return the view type of the item at position for the purposes of view recycling.
            /// </summary>
            /// <param name="position">The position of the item within the adapter's data set.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual int GetItemViewType(int position)
            {
                return 0;
            }

            /// <summary>
            /// Called by FlexibleView when it starts observing this Adapter.
            /// Keep in mind that same adapter may be observed by multiple FlexibleView.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView instance which started observing this adapter.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnAttachedToRecyclerView(FlexibleView flexibleView)
            {
            }

            /// <summary>
            /// Called by FlexibleView when it stops observing this Adapter.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView instance which stopped observing this adapter.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnDetachedFromRecyclerView(FlexibleView flexibleView)
            {
            }

            /// <summary>
            /// Called when FlexibleView focus changed.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView into which the focus ViewHolder changed.</param>
            /// <param name="previousFocus">The position of previous focus</param>
            /// <param name="currentFocus">The position of current focus</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnFocusChange(FlexibleView flexibleView, int previousFocus, int currentFocus)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been recycled.
            /// If an item view has large or expensive data bound to it such as large bitmaps, this may be a good place to release those resources
            /// </summary>
            /// <param name="holder">The ViewHolder will be recycled.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewRecycled(ViewHolder holder)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been attached to a window.
            /// This can be used as a reasonable signal that the view is about to be seen by the user.
            /// </summary>
            /// <param name="holder">Holder of the view being attached.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewAttachedToWindow(ViewHolder holder)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been detached from its window.
            /// </summary>
            /// <param name="holder">Holder of the view being detached.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewDetachedFromWindow(ViewHolder holder)
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has changed.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyDataSetChanged()
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has changed.
            /// It indicates that any reflection of the data at position is out of date and should be updated.
            /// </summary>
            /// <param name="position">Position of the item that has changed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemChanged(int position)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Change,
                };
                args.param[0] = position;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items starting at position positionStart have changed.
            /// An optional payload can be passed to each changed item.
            /// </summary>
            /// <param name="positionStart">Position of the first item that has changed</param>
            /// <param name="itemCount">Number of items that have changed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeChanged(int positionStart, int itemCount)
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has been newly inserted.
            /// It indicates that any reflection of the data at position is out of date and should be updated.
            /// </summary>
            /// <param name="position">Position of the item that has been newly inserted</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemInserted(int position)
            {
                NotifyItemRangeInserted(position, 1);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items starting at position positionStart have been newly inserted.
            /// </summary>
            /// <param name="positionStart">Position of the first item that was inserted</param>
            /// <param name="itemCount">Number of items inserted</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeInserted(int positionStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Insert,
                };
                args.param[0] = positionStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the item previously located at position has been removed from the data set. 
            /// </summary>
            /// <param name="position">Previous position of the first item that was removed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRemoved(int position)
            {
                NotifyItemRangeRemoved(position, 1);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items previously located at positionStart have been removed from the data set.
            /// </summary>
            /// <param name="positionStart">Previous position of the first item that was removed</param>
            /// <param name="itemCount">Number of items removed from the data set </param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeRemoved(int positionStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Remove,
                };
                args.param[0] = positionStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the item reflected at fromPosition has been moved to toPosition.
            /// </summary>
            /// <param name="fromPosition">Previous position of the item</param>
            /// <param name="toPosition">New position of the item. </param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemMoved(int fromPosition, int toPosition)
            {
               
            }

            private void OnItemEvent(object sender, ItemEventArgs e)
            {
                itemEventHandlers?.Invoke(sender, e);
            }

            internal class ItemEventArgs : EventArgs
            {

                /// <summary>
                /// Data change event parameters.
                /// </summary>
                public int[] param = new int[4];

                /// <summary>
                /// Data changed event type.
                /// </summary>
                public ItemEventType EventType
                {
                    get;
                    set;
                }
            }
        }

        /// <summary>
        /// A LayoutManager is responsible for measuring and positioning item views within a FlexibleView
        /// as well as determining the policy for when to recycle item views that are no longer visible to the user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class LayoutManager
        {
            /// <summary>
            /// Direction
            /// </summary>
            public enum Direction
            {
                /// <summary>
                /// Left
                /// </summary>
                Left,

                /// <summary>
                /// Right
                /// </summary>
                Right,

                /// <summary>
                /// Up
                /// </summary>
                Up,

                /// <summary>
                /// Down
                /// </summary>
                Down
            }

            private FlexibleView mFlexibleView;
            private ChildHelper mChildHelper;

            private List<ViewHolder> mPendingRecycleViews = new List<ViewHolder>();

            private Animation mScrollAni;

            /// <summary>
            /// Layout all relevant child views from the given adapter.
            /// </summary>
            /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnLayoutChildren(Recycler recycler);

            /// <summary>
            /// Called after a full layout calculation is finished.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnLayoutCompleted()
            {
            }


            /// <summary>
            /// Gets the current focus position in adapter.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int FocusPosition
            {
                get
                {
                    return mFlexibleView.mFocusedItemIndex;
                }
            }

            /// <summary>
            /// Gets the datas count in data sets.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ItemCount
            {
                get
                {
                    Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;

                    return b != null ? b.GetItemCount() : 0;
                }
            }

            /// <summary>
            /// Query if horizontal scrolling is currently supported. The default implementation returns false.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollHorizontally()
            {
                return false;
            }

            /// <summary>
            /// Query if vertical scrolling is currently supported. The default implementation returns false.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollVertically()
            {
                return false;
            }

            /// <summary>
            /// Scroll horizontally by dy pixels in screen coordinates.
            /// </summary>
            /// <param name="dy">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
            /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
            /// <param name="immediate">Specify if the scroll need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ScrollHorizontallyBy(float dy, Recycler recycler, bool immediate)
            {
                return 0;
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
            public virtual float ScrollVerticallyBy(float dy, Recycler recycler, bool immediate)
            {
                return 0;
            }

            /// <summary>
            /// Compute the extent of the scrollbar's thumb within the range.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollExtent()
            {
                return 0;
            }

            /// <summary>
            /// Compute the offset of the scrollbar's thumb within the range.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollOffset()
            {
                return 0;
            }

            /// <summary>
            /// Compute the range that the scrollbar represents.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollRange()
            {
                return 0;
            }

            /// <summary>
            /// Scroll the FlexibleView to make the position visible.
            /// </summary>
            /// <param name="position">Scroll to this adapter position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPosition(int position)
            {

            }

            /// <summary>
            /// Scroll to the specified adapter position with the given offset from resolved layout start.
            /// </summary>
            /// <param name="position">Scroll to this adapter position</param>
            /// <param name="offset">The distance (in pixels) between the start edge of the item view and start edge of the FlexibleView.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPositionWithOffset(int position, int offset)
            {

            }

            internal void MoveFocus(FlexibleView.LayoutManager.Direction direction, Recycler recycler)
            {
                int prevFocusPosition = FocusPosition;
                int nextFocusPosition = GetNextPosition(FocusPosition, direction);
                if (nextFocusPosition == NO_POSITION)
                {
                    return;
                }

                FlexibleView.ViewHolder nextFocusChild = FindItemViewByPosition(nextFocusPosition);
                if (nextFocusChild == null)
                {
                    nextFocusChild = OnFocusSearchFailed(null, direction, recycler);
                }

                if (nextFocusChild != null)
                {
                    RequestChildRectangleOnScreen(mFlexibleView, nextFocusChild, recycler, false);

                    ChangeFocus(nextFocusPosition);
                }
            }

            /**
             * Requests that the given child of the RecyclerView be positioned onto the screen. This
             * method can be called for both unfocusable and focusable child views. For unfocusable
             * child views, focusedChildVisible is typically true in which case, layout manager
             * makes the child view visible only if the currently focused child stays in-bounds of RV.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *              wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @param focusedChildVisible Whether the currently focused view must stay visible.
             * @return Whether the group scrolled to handle the operation
             */
            internal bool RequestChildRectangleOnScreen(FlexibleView parent, FlexibleView.ViewHolder child, Recycler recycler, bool immediate)
            {
                Vector2 scrollAmount = GetChildRectangleOnScreenScrollAmount(parent, child);
                float dx = scrollAmount[0];
                float dy = scrollAmount[1];
                if (dx != 0 || dy != 0)
                {
                    if (dx != 0 && CanScrollHorizontally())
                    {
                        ScrollHorizontallyBy(dx, recycler, immediate);
                    }
                    else if (dy != 0 && CanScrollVertically())
                    {
                        ScrollVerticallyBy(dy, recycler, immediate);
                    }
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Calls {@code FlexibleView#RelayoutRequest} on the underlying FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RelayoutRequest()
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.RelayoutRequest();
                }
            }

            /// <summary>
            /// Lay out the given child view within the FlexibleView using coordinates that include view margins.
            /// </summary>
            /// <param name="child">Child to lay out</param>
            /// <param name="left">Left edge, with item view left margin included</param>
            /// <param name="top">Top edge, with item view top margin included</param>
            /// <param name="width">Width, with item view left and right margin included</param>
            /// <param name="height">Height, with item view top and bottom margin included</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void LayoutChild(ViewHolder child, float left, float top, float width, float height)
            {
                View itemView = child.ItemView;
                itemView.SizeWidth = width - itemView.Margin.Start - itemView.Margin.End;
                itemView.SizeHeight = height - itemView.Margin.Top - itemView.Margin.Bottom;
                itemView.PositionX = left + itemView.Margin.Start;
                itemView.PositionY = top + itemView.Margin.Top;
            }

            /// <summary>
            /// Change the ViewHolder with focusPosition to focus.
            /// </summary>
            /// <param name="focusPosition">the newly focus position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ChangeFocus(int focusPosition)
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.DispatchFocusChanged(focusPosition);
                }
            }

            /// <summary>
            /// Return the current number of child views attached to the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetChildCount()
            {
                return mChildHelper != null ? mChildHelper.GetChildCount() : 0;
            }

            /// <summary>
            /// Return the child view at the given index.
            /// </summary>
            /// <param name="index">child index</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetChildAt(int index)
            {
                return mChildHelper != null ? mChildHelper.GetChildAt(index) : null;
            }

            /// <summary>
            /// Finds the view which represents the given adapter position.
            /// </summary>
            /// <param name="position">adapter position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder FindItemViewByPosition(int position)
            {
                return mFlexibleView.FindViewHolderForLayoutPosition(position);
            }

            /// <summary>
            /// Offset all child views attached to the parent FlexibleView by dx pixels along the horizontal axis.
            /// </summary>
            /// <param name="dx">Pixels to offset by </param>
            /// <param name="immediate">specify if the offset need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenHorizontal(float dx, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (mScrollAni == null)
                {
                    mScrollAni = new Animation();
                    mScrollAni.Finished += OnScrollAnimationFinished;
                }
                else if (mScrollAni.State == Animation.States.Playing)
                {
                    //StopScroll();
                    mScrollAni.Stop(Animation.EndActions.StopFinal);
                }
                mScrollAni.Duration = 500;
                mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSquare);

                mScrollAni.Clear();

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionX += dx;
                    }
                }
                else
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mScrollAni.AnimateTo(v.ItemView, "PositionX", v.ItemView.PositionX + dx);
                    }
                    mScrollAni.Play();
                }
            }

            /// <summary>
            /// Offset all child views attached to the parent FlexibleView by dy pixels along the vertical axis.
            /// </summary>
            /// <param name="dy">Pixels to offset by </param>
            /// <param name="immediate">specify if the offset need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenVertical(float dy, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (mScrollAni == null)
                {
                    mScrollAni = new Animation();
                    mScrollAni.Finished += OnScrollAnimationFinished;
                }
                else if (mScrollAni.State == Animation.States.Playing)
                {
                    //StopScroll();
                    mScrollAni.Stop(Animation.EndActions.StopFinal);
                }
                mScrollAni.Duration = 500;
                mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSquare);

                mScrollAni.Clear();

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionY += dy;
                    }
                }
                else
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mScrollAni.AnimateTo(v.ItemView, "PositionY", v.ItemView.PositionY + dy);
                    }
                    mScrollAni.Play();
                }
            }

            /// <summary>
            /// Return the width of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetWidth()
            {
                return mFlexibleView != null ? mFlexibleView.SizeWidth : 0;
            }

            /// <summary>
            /// Return the height of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetHeight()
            {
                return mFlexibleView != null ? mFlexibleView.SizeHeight : 0;
            }

            /// <summary>
            /// Return the left padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingLeft()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Start : 0;
            }

            /// <summary>
            /// Return the top padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingTop()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Top : 0;
            }

            /// <summary>
            /// Return the right padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingRight()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.End : 0;
            }

            /// <summary>
            /// Return the bottom padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingBottom()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Bottom : 0;
            }

            /// <summary>
            /// Add a view to the currently attached FlexibleView if needed.<br />
            /// LayoutManagers should use this method to add views obtained from a FlexibleView.Recycler using getViewForPosition(int).<br />
            /// </summary>
            /// <param name="holder">view to add</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder)
            {
                AddView(holder, -1);
            }

            /// <summary>
            /// Add a view to the currently attached FlexibleView if needed.<br />
            /// LayoutManagers should use this method to add views obtained from a FlexibleView.Recycler using getViewForPosition(int).<br />
            /// </summary>
            /// <param name="holder">view to add</param>
            /// <param name="index">index to add child at</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder, int index)
            {
                AddViewInternal(holder, index, false);
            }

            /// <summary>
            /// Temporarily detach and scrap all currently attached child views.
            /// Views will be scrapped into the given Recycler.
            /// The Recycler may prefer to reuse scrap views before other views that were previously recycled.
            /// </summary>
            /// <param name="recycler">Recycler to scrap views into</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ScrapAttachedViews(Recycler recycler)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                recycler.Clear();

                mChildHelper.ScrapViews(recycler);
            }

            /**
             * Remove a child view and recycle it using the given Recycler.
             *
             * @param index Index of child to remove and recycle
             * @param recycler Recycler to use to recycle child
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveAndRecycleViewAt(int index, Recycler recycler)
            {
                ViewHolder v = mChildHelper.GetChildAt(index);
                mChildHelper.RemoveViewAt(index);
                recycler.RecycleView(v);
            }

            /// <summary>
            /// ecycles children between given indices..
            /// </summary>
            /// <param name="recycler">Recycler to recycle views into</param>
            /// <param name="startIndex">inclusive</param>
            /// <param name="endIndex">exclusive</param>
            /// <param name="immediate">recycle immediately or add to pending list and recycle later.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleChildren(FlexibleView.Recycler recycler, int startIndex, int endIndex, bool immediate)
            {
                if (startIndex == endIndex)
                {
                    return;
                }
                if (endIndex > startIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        if (v.PendingRecycle == false)
                        {
                            v.PendingRecycle = true;
                            mPendingRecycleViews.Add(v);
                        }
                    }
                }
                else
                {
                    for (int i = startIndex; i > endIndex; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        if (v.PendingRecycle == false)
                        {
                            v.PendingRecycle = true;
                            mPendingRecycleViews.Add(v);
                        }
                    }
                }
                if (immediate == true)
                {
                    RecycleChildrenInt(recycler);
                }
            }

            /// <summary>
            /// Retrieves a position that neighbor to current position by direction.
            /// </summary>
            /// <param name="position">The anchor adapter position</param>
            /// <param name="direction">The direction.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected abstract int GetNextPosition(int position, FlexibleView.LayoutManager.Direction direction);

            internal virtual ViewHolder OnFocusSearchFailed(FlexibleView.ViewHolder focused, LayoutManager.Direction direction, Recycler recycler)
            {
                return null;
            }

            internal void SetRecyclerView(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
                mChildHelper = recyclerView.mChildHelper;
            }

            internal void StopScroll()
            {
                if (mScrollAni != null && mScrollAni.State == Animation.States.Playing)
                {
                    mScrollAni.Stop(Animation.EndActions.StopFinal);
                    mScrollAni.Clear();
                    OnScrollAnimationFinished(mScrollAni, null);
                }
            }

            /**
             * Returns the scroll amount that brings the given rect in child's coordinate system within
             * the padded area of RecyclerView.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *             wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @return The array containing the scroll amount in x and y directions that brings the
             * given rect into RV's padded area.
             */
            private Vector2 GetChildRectangleOnScreenScrollAmount(FlexibleView parent, FlexibleView.ViewHolder child)
            {
                Vector2 ret = new Vector2(0, 0);
                int parentLeft = GetPaddingLeft();
                int parentTop = GetPaddingTop();
                int parentRight = (int)GetWidth() - GetPaddingRight();
                int parentBottom = (int)GetHeight() - GetPaddingBottom();
                int childLeft = (int)child.Left;
                int childTop = (int)child.Top;
                int childRight = (int)child.Right;
                int childBottom = (int)child.Bottom;

                int offScreenLeft = Math.Min(0, childLeft - parentLeft);
                int offScreenTop = Math.Min(0, childTop - parentTop);
                int offScreenRight = Math.Max(0, childRight - parentRight);
                int offScreenBottom = Math.Max(0, childBottom - parentBottom);

                // Favor the "start" layout direction over the end when bringing one side or the other
                // of a large rect into view. If we decide to bring in end because start is already
                // visible, limit the scroll such that start won't go out of bounds.
                int dx= offScreenLeft != 0 ? offScreenLeft
                            : Math.Min(childLeft - parentLeft, offScreenRight);

                // Favor bringing the top into view over the bottom. If top is already visible and
                // we should scroll to make bottom visible, make sure top does not go out of bounds.
                int dy = offScreenTop != 0 ? offScreenTop
                        : Math.Min(childTop - parentTop, offScreenBottom);

                ret.X = -dx;
                ret.Y = -dy;

                return ret;
            }

            private void OnScrollAnimationFinished(object sender, EventArgs e)
            {
                RecycleChildrenInt(mFlexibleView.mRecycler);
            }

            private void AddViewInternal(ViewHolder holder, int index, bool disappearing)
            {
                if (holder.IsScrap())
                {
                    holder.Unscrap();
                    mChildHelper.AttachView(holder, index);
                }
                else
                {
                    mChildHelper.AddView(holder, index);
                }
            }

            private void RecycleChildrenInt(FlexibleView.Recycler recycler)
            {
                foreach(ViewHolder holder in mPendingRecycleViews)
                {
                    holder.PendingRecycle = false;
                    recycler.RecycleView(holder);
                    mChildHelper.RemoveView(holder);
                }
                mPendingRecycleViews.Clear();
            }

            private void ScrapOrRecycleView(Recycler recycler, ViewHolder itemView)
            {
                recycler.ScrapView(itemView);
            }

        }

        /// <summary>
        /// A ViewHolder describes an item view and metadata about its place within the FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ViewHolder
        {
            /**
             * This ViewHolder has been bound to a position; AdapterPosition, mItemId and mItemViewType
             * are all valid.
             */
            //static readonly int FLAG_BOUND = 1 << 0;

            /**
             * The data this ViewHolder's view reflects is stale and needs to be rebound
             * by the adapter. AdapterPosition and mItemId are consistent.
             */
            //static readonly int FLAG_UPDATE = 1 << 1;

            /**
             * This ViewHolder's data is invalid. The identity implied by AdapterPosition and mItemId
             * are not to be trusted and may no longer match the item view type.
             * This ViewHolder must be fully rebound to different data.
             */
            //static readonly int FLAG_INVALID = 1 << 2;

            /**
             * This ViewHolder points at data that represents an item previously removed from the
             * data set. Its view may still be used for things like outgoing animations.
             */
            //static readonly int FLAG_REMOVED = 1 << 3;

            /**
             * This ViewHolder should not be recycled. This flag is set via setIsRecyclable()
             * and is intended to keep views around during animations.
             */
            //static readonly int FLAG_NOT_RECYCLABLE = 1 << 4;

            /**
             * This ViewHolder is returned from scrap which means we are expecting an addView call
             * for this itemView. When returned from scrap, ViewHolder stays in the scrap list until
             * the end of the layout pass and then recycled by RecyclerView if it is not added back to
             * the RecyclerView.
             */
            //static readonly int FLAG_RETURNED_FROM_SCRAP = 1 << 5;

            /**
             * This ViewHolder is fully managed by the LayoutManager. We do not scrap, recycle or remove
             * it unless LayoutManager is replaced.
             * It is still fully visible to the LayoutManager.
             */
            //static readonly int FLAG_IGNORE = 1 << 7;

            private int mFlags;
            private int mPreLayoutPosition = NO_POSITION;

            /// <summary>
            /// ViewHolder constructor.
            /// </summary>
            /// <param name="itemView">View</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder(View itemView)
            {
                if (itemView == null)
                {
                    throw new ArgumentNullException("itemView may not be null");
                }
                this.ItemView = itemView;
            }

            /// <summary>
            /// Returns the view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public View ItemView { get; }

            /// <summary>
            /// Returns the left edge includes the view left margin.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Left
            {
                get
                {
                    return ItemView.PositionX - ItemView.Margin.Start;
                }
            }

            /// <summary>
            /// Returns the right edge includes the view right margin.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Right
            {
                get
                {
                    return ItemView.PositionX + ItemView.SizeWidth + ItemView.Margin.End;
                }
            }

            /// <summary>
            /// Returns the top edge includes the view top margin.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Top
            {
                get
                {
                    return ItemView.PositionY - ItemView.Margin.Top;
                }
            }

            /// <summary>
            /// Returns the bottom edge includes the view bottom margin.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Bottom
            {
                get
                {
                    return ItemView.PositionY + ItemView.SizeHeight + ItemView.Margin.Bottom;
                }
            }

            /// <summary>
            /// Returns the position of the ViewHolder in terms of the latest layout pass.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int LayoutPosition
            {
                get
                {
                    return mPreLayoutPosition == NO_POSITION ? AdapterPosition : mPreLayoutPosition;
                }
            }

            /// <summary>
            /// Returns the Adapter position of the item represented by this ViewHolder.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int AdapterPosition { get; internal set; } = NO_POSITION;

            /// <summary>
            /// Get old position of item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int OldPosition { get; private set; } = NO_POSITION;

            /// <summary>
            /// Gets or sets item view type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ItemViewType { get; set; } = INVALID_TYPE;

            internal bool IsBound
            {
                get;
                set;
            }

            internal Recycler ScrapContainer { get; set; }

            internal bool PendingRecycle
            {
                get;
                set;
            } = false;


            internal bool IsScrap()
            {
                return ScrapContainer != null;
            }

            internal void Unscrap()
            {
                ScrapContainer.UnscrapView(this);
            }


            internal void FlagRemovedAndOffsetPosition(int mNewPosition, int offset, bool applyToPreLayout)
            {
                //AddFlags(ViewHolder.FLAG_REMOVED);
                OffsetPosition(offset, applyToPreLayout);
                AdapterPosition = mNewPosition;
            }

            internal void OffsetPosition(int offset, bool applyToPreLayout)
            {
                if (OldPosition == NO_POSITION)
                {
                    OldPosition = AdapterPosition;
                }
                if (mPreLayoutPosition == NO_POSITION)
                {
                    mPreLayoutPosition = AdapterPosition;
                }
                if (applyToPreLayout)
                {
                    mPreLayoutPosition += offset;
                }
                AdapterPosition += offset;
            }

            internal void ClearOldPosition()
            {
                OldPosition = NO_POSITION;
                mPreLayoutPosition = NO_POSITION;
            }

            internal void SaveOldPosition()
            {
                if (OldPosition == NO_POSITION)
                {
                    OldPosition = AdapterPosition;
                }
            }

            private void SetFlags(int flags, int mask)
            {
                mFlags = (mFlags & ~mask) | (flags & mask);
            }

            private void AddFlags(int flags)
            {
                mFlags |= flags;
            }

        }

        /// <summary>
        /// A Recycler is responsible for managing scrapped or detached item views for reuse.
        /// A "scrapped" view is a view that is still attached to its parent FlexibleView but that has been marked for removal or reuse.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class Recycler
        {
            private FlexibleView mFlexibleView;
            private RecycledViewPool mRecyclerPool;

            private List<ViewHolder> mAttachedScrap = new List<ViewHolder>();
            private List<ViewHolder> mChangedScrap = null;
            //private List<ItemView> mCachedViews = new List<ItemView>();

            //private List<ViewHolder> mUnmodifiableAttachedScrap;

            private int mCacheSizeMax = 2;

            /// <summary>
            /// Recycler constructor.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Recycler(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetViewCacheSize(int viewCount)
            {
                mCacheSizeMax = viewCount;
            }

            /// <summary>
            /// Obtain a view initialized for the given position.
            /// </summary>
            /// <param name="position">Position to obtain a view for</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetViewForPosition(int position)
            {
                Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;
                if (b == null)
                {
                    return null;
                }
                if (position < 0 || position >= b.GetItemCount())
                {
                    return null;
                }

                int type = b.GetItemViewType(position);
                ViewHolder itemView = null;
                for (int i = 0; i < mAttachedScrap.Count; i++)
                {
                    if (mAttachedScrap[i].LayoutPosition == position && mAttachedScrap[i].ItemViewType == type)
                    {
                        itemView = mAttachedScrap[i];
                        break;
                    }
                }
                if (itemView == null)
                {
                    itemView = mRecyclerPool.GetRecycledView(type);
                    if (itemView == null)
                    {
                        itemView = b.OnCreateViewHolder(type);
                    }

                    if (!itemView.IsBound)
                    {
                        b.OnBindViewHolder(itemView, position);
                        itemView.IsBound = true;
                    }

                    itemView.AdapterPosition = position;
                    itemView.ItemViewType = type;
                }

                return itemView;
            }

            /// <summary>
            /// Recycle a detached view.
            /// </summary>
            /// <param name="itemView">Removed holder for recycling</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleView(ViewHolder itemView)
            {
                itemView.ScrapContainer = null;
                mRecyclerPool.PutRecycledView(itemView);
            }

            /// <summary>
            /// Returns the count in scrap list.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetScrapCount()
            {
                return mAttachedScrap.Count;
            }

            /// <summary>
            /// Gets the scrap view at index.
            /// </summary>
            /// <param name="index">index</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetScrapViewAt(int index)
            {
                return mAttachedScrap[index];
            }

            /// <summary>
            /// Clear scrap views out of this recycler. Detached views contained within a recycled view pool will remain.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Clear()
            {
                mAttachedScrap.Clear();
                if (mChangedScrap != null)
                {
                    mChangedScrap.Clear();
                }
            }

            internal void ScrapView(ViewHolder itemView)
            {
                mAttachedScrap.Add(itemView);
                itemView.ScrapContainer = this;
            }

            internal void UnscrapView(ViewHolder itemView)
            {
                mAttachedScrap.Remove(itemView);
                itemView.ScrapContainer = null;
            }

            internal void SetRecycledViewPool(RecycledViewPool pool)
            {
                mRecyclerPool = pool;
            }
        }

        internal class RecycledViewPool
        {
            private FlexibleView mFlexibleView;

            private int mMaxTypeCount = 10;
            private List<ViewHolder>[] mScrap;

            public RecycledViewPool(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
                mScrap = new List<ViewHolder>[mMaxTypeCount];
            }

            //public void SetViewTypeCount(int typeCount)
            //{
            //}

            public ViewHolder GetRecycledView(int viewType)
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
                ViewHolder recycledView = mScrap[viewType][index];
                mScrap[viewType].RemoveAt(index);

                return recycledView;
            }

            public void PutRecycledView(ViewHolder view)
            {
                int viewType = view.ItemViewType;
                if (mScrap[viewType] == null)
                {
                    mScrap[viewType] = new List<ViewHolder>();
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

        private class ChildHelper
        {
            private FlexibleView mFlexibleView;
            
            private List<ViewHolder> mViewList = new List<ViewHolder>();

            //private List<ViewHolder> mRemovePendingViews;

            private Dictionary<uint, ViewHolder> itemViewTable = new Dictionary<uint, ViewHolder>();
            private TapGestureDetector mTapGestureDetector;

            public ChildHelper(FlexibleView owner)
            {
                mFlexibleView = owner;

                mTapGestureDetector = new TapGestureDetector();
                mTapGestureDetector.Detected += OnTapGestureDetected;
            }

            public void Clear()
            {
                foreach(ViewHolder holder in mViewList)
                {
                    mFlexibleView.Remove(holder.ItemView);

                    mFlexibleView.DispatchChildDestroyed(holder);
                }
                mViewList.Clear();
            }

            public void ScrapViews(Recycler recycler)
            {
                recycler.Clear();
                foreach (ViewHolder itemView in mViewList)
                {
                    recycler.ScrapView(itemView);
                }

                mViewList.Clear();
            }

            public void AttachView(ViewHolder holder, int index)
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

            public void AddView(ViewHolder holder, int index)
            {
                mFlexibleView.Add(holder.ItemView);

                mFlexibleView.DispatchChildAttached(holder);

                AttachView(holder, index);
            }

            public bool RemoveView(ViewHolder holder)
            {
                mFlexibleView.Remove(holder.ItemView);

                mFlexibleView.DispatchChildDetached(holder);

                return mViewList.Remove(holder);
            }

            public bool RemoveViewAt(int index)
            {
                ViewHolder itemView = mViewList[index];
                return RemoveView(itemView);
            }

            public bool RemoveViewsRange(int index, int count)
            {
                for (int i = index; i < index + count; i++)
                {
                    ViewHolder holder = mViewList[i];
                    mFlexibleView.Remove(holder.ItemView);
                }
                mViewList.RemoveRange(index, count);
                return false;
            }

            public int GetChildCount()
            {
                return mViewList.Count;
            }

            public ViewHolder GetChildAt(int index)
            {
                if (index < 0 || index >= mViewList.Count)
                {
                    return null;
                }
                return mViewList[index];
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
                    ViewHolder holder = itemViewTable[itemView.ID];
                    mFlexibleView.FocusedItemIndex = holder.AdapterPosition;

                    mFlexibleView.DispatchItemClicked(holder);
                }
            }

            private bool OnTouchEvent(object source, TouchEventArgs e)
            {
                View itemView = source as View;
                if (itemView != null && itemViewTable.ContainsKey(itemView.ID))
                {
                    ViewHolder holder = itemViewTable[itemView.ID];

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
