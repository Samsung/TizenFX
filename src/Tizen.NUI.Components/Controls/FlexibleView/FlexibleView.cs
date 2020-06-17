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
    public partial class FlexibleView : Control
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

        private new Extents padding;
        /// <summary>
        /// overwrite the Padding.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Extents Padding
        {
            get
            {
                if (null == padding)
                {
                    padding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        padding.Start = start;
                        padding.End = end;
                        padding.Top = top;
                        padding.Bottom = bottom;
                    }, 0, 0, 0, 0);
                }

                return padding;
            }
            set
            {
                if (null == padding)
                {
                    padding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        padding.Start = start;
                        padding.End = end;
                        padding.Top = top;
                        padding.Bottom = bottom;
                    }, 0, 0, 0, 0);
                }

                padding.CopyFrom(value);
            }
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
            if (null == layoutManager) return;
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
                if (mLayout != null)
                {
                    mLayout.StopScroll(false);
                }

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
        /// you can override it to create your own default style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
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
            if (range == 0)
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
            if (offset < 0)
            {
                offset = 0;
            }
            if (mScrollBar.Direction == ScrollBar.DirectionType.Vertical)
            {
                mScrollBar.Style.Thumb.Size = new Size(thickness, length);
            }
            else
            {
                mScrollBar.Style.Thumb.Size = new Size(length, thickness);
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
                mLayout.StopScroll(true);
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
            public ViewHolder ClickedView { get; set; }
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
            public ViewHolder TouchedView { get; set; }
        }
    }
}
