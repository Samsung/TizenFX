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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// FlexibleView ItemClick Event Arguments.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleViewItemClickedEventArgs : EventArgs
    {
        /// <summary>
        /// The clicked FlexibleViewViewHolder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder ClickedView { get; set; }
    }

    /// <summary>
    /// FlexibleView ItemTouch Event Arguments.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleViewItemTouchEventArgs : View.TouchEventArgs
    {
        /// <summary>
        /// The touched FlexibleViewViewHolder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder TouchedView { get; set; }
    }

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
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
        public static readonly int NO_POSITION = -1;
        /// <summary>
        /// Constant value: -1.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
        public static readonly int INVALID_TYPE = -1;

        private FlexibleViewAdapter adapter;
        private FlexibleViewLayoutManager layout;
        private FlexibleViewRecycler recycler;
        private RecycledViewPool recyclerPool;
        private ChildHelper childHelper;

        private PanGestureDetector panGestureDetector;

        private int focusedItemIndex = NO_POSITION;

        private AdapterHelper adapteHelper;

        private ScrollBar scrollBar = null;
        private Timer scrollBarShowTimer = null;

        private EventHandler<FlexibleViewItemClickedEventArgs> clickEventHandlers;
        private EventHandler<FlexibleViewItemTouchEventArgs> touchEventHandlers;
        private EventHandler<NUI.StyleManager.StyleChangedEventArgs> styleChangedEventHandlers;

        /// <summary>
        /// Creates a FlexibleView instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleView()
        {
            recyclerPool = new RecycledViewPool(this);

            recycler = new FlexibleViewRecycler(this);
            recycler.SetRecycledViewPool(recyclerPool);

            childHelper = new ChildHelper(this);

            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(this);
            panGestureDetector.Detected += OnPanGestureDetected;

            adapteHelper = new AdapterHelper(this);

            ClippingMode = ClippingModeType.ClipToBoundingBox;
        }

        /// <summary>
        /// Item click event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FlexibleViewItemClickedEventArgs> ItemClicked
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FlexibleViewItemTouchEventArgs> ItemTouch
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

        private Extents padding;
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
                return focusedItemIndex;
            }
            set
            {
                if (value == focusedItemIndex)
                {
                    return;
                }

                if (adapter == null)
                {
                    return;
                }

                if (layout == null)
                {
                    return;
                }

                FlexibleViewViewHolder nextFocusView = FindViewHolderForAdapterPosition(value);
                if (nextFocusView == null)
                {
                    layout.ScrollToPosition(value);
                }
                else
                {
                    layout.GetRectOfVisibleChild(this, nextFocusView, recycler, true);
                    DispatchFocusChanged(value);
                }
            }
        }

        /// <summary>
        /// Set a new adapter to provide child views on demand.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAdapter(FlexibleViewAdapter adapter)
        {
            if (adapter == null)
            {
                return;
            }
            this.adapter = adapter;

            this.adapter.ItemEvent += OnItemEvent;
        }

        /// <summary>
        /// Retrieves the previously set adapter or null if no adapter is set.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewAdapter GetAdapter()
        {
            return adapter;
        }

        /// <summary>
        /// Set the FlexibleViewLayoutManager that this FlexibleView will use.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLayoutManager(FlexibleViewLayoutManager layoutManager)
        {
            if (null == layoutManager) return;
            layout = layoutManager;

            layout.SetRecyclerView(this);

            if (layout.CanScrollHorizontally())
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else if (layout.CanScrollVertically())
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        /// <summary>
        /// Return the FlexibleViewLayoutManager currently responsible for layout policy for this FlexibleView.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewLayoutManager GetLayoutManager()
        {
            return layout;
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
            layout.ScrollToPositionWithOffset(position, offset);
        }

        /// <summary>
        /// Move focus by direction.
        /// </summary>
        /// <param name="direction">Direction. Should be "Left", "Right", "Up" or "Down" </param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void MoveFocus(FlexibleViewLayoutManager.Direction direction)
        {
            layout.MoveFocus(direction, recycler);
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
            this.scrollBar = scrollBar;
            base.Add(this.scrollBar);
        }

        /// <summary>
        /// Detach the scrollbar from this FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachScrollBar()
        {
            if (scrollBar == null)
            {
                return;
            }
            Remove(scrollBar);
            scrollBar = null;
        }

        /// <summary>
        /// Return the FlexibleViewViewHolder for the item in the given position of the data set as of the latest layout pass.
        /// This method checks only the children of FlexibleViewRecyclerView. If the item at the given position is not laid out, it will not create a new one.
        /// </summary>
        /// <param name="position">The position of the item in the data set of the adapter</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder FindViewHolderForLayoutPosition(int position)
        {
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (childHelper.GetChildAt(i) is FlexibleViewViewHolder holder)
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
        /// Return the FlexibleViewViewHolder for the item in the given position of the data set.
        /// This method checks only the children of FlexibleViewRecyclerView. If the item at the given position is not laid out, it will not create a new one.
        /// </summary>
        /// <param name="position">The position of the item in the data set of the adapter</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder FindViewHolderForAdapterPosition(int position)
        {
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (childHelper.GetChildAt(i) is FlexibleViewViewHolder holder)
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewRecycler GetRecycler()
        {
            return recycler;
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
                if (layout != null)
                {
                    layout.StopScroll(false);
                    layout.ClearRecyclerView();
                    layout = null;
                }

                if (adapter != null)
                {
                    adapter.ItemEvent -= OnItemEvent;
                }

                if (panGestureDetector != null)
                {
                    panGestureDetector.Detected -= OnPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }

                if (scrollBarShowTimer != null)
                {
                    scrollBarShowTimer.Tick -= OnShowTimerTick;
                    scrollBarShowTimer.Stop();
                    scrollBarShowTimer.Dispose();
                    scrollBarShowTimer = null;
                }

                if (recyclerPool != null)
                {
                    recyclerPool.Clear();
                    recyclerPool = null;
                }

                if (childHelper != null)
                {
                    childHelper.Clear();
                    childHelper.Dispose();
                    childHelper = null;
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
        protected override ViewStyle CreateViewStyle()
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
            if (adapter == null)
            {
                return;
            }

            if (layout == null)
            {
                return;
            }

            DispatchLayoutStep1();

            layout.OnLayoutChildren(recycler);

            RemoveAndRecycleScrapInt();
        }

        private void DispatchLayoutStep1()
        {
            ProcessAdapterUpdates();
            SaveOldPositions();
            ClearOldPositions();
        }

        private void ProcessAdapterUpdates()
        {
            adapteHelper.PreProcess();
        }

        private void OffsetPositionRecordsForInsert(int positionStart, int itemCount)
        {
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                FlexibleViewViewHolder holder = childHelper.GetChildAt(i);
                if (holder != null && holder.AdapterPosition >= positionStart)
                {
                    holder.OffsetPosition(itemCount, false);
                }
            }

            if (positionStart <= focusedItemIndex)
            {
                focusedItemIndex += itemCount;
            }
        }

        private void OffsetPositionRecordsForRemove(int positionStart, int itemCount, bool applyToPreLayout)
        {
            int positionEnd = positionStart + itemCount;
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                FlexibleViewViewHolder holder = childHelper.GetChildAt(i);
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

            if (positionEnd <= focusedItemIndex)
            {
                focusedItemIndex -= itemCount;
            }
            else if (positionStart <= focusedItemIndex)
            {
                focusedItemIndex = positionStart;
                if (focusedItemIndex >= adapter.GetItemCount())
                {
                    focusedItemIndex = adapter.GetItemCount() - 1;
                }
            }
        }

        private void SaveOldPositions()
        {
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                FlexibleViewViewHolder holder = childHelper.GetChildAt(i);
                holder.SaveOldPosition();
            }
        }

        private void ClearOldPositions()
        {
            int childCount = childHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                FlexibleViewViewHolder holder = childHelper.GetChildAt(i);
                holder.ClearOldPosition();
            }
        }

        private void RemoveAndRecycleScrapInt()
        {
            int scrapCount = recycler.GetScrapCount();
            for (int i = 0; i < scrapCount; i++)
            {
                FlexibleViewViewHolder scrap = recycler.GetScrapViewAt(i);
                childHelper.RemoveView(scrap);
                recycler.RecycleView(scrap);
            }
            recycler.Clear();
        }

        private void ShowScrollBar(uint millisecond = 700, bool flagAni = false)
        {
            if (scrollBar == null || layout == null)
            {
                return;
            }

            float extent = layout.ComputeScrollExtent();
            float range = layout.ComputeScrollRange();
            if (range == 0)
            {
                return;
            }
            float offset = layout.ComputeScrollOffset();

            float size = scrollBar.Direction == ScrollBar.DirectionType.Vertical ? scrollBar.SizeHeight : scrollBar.SizeWidth;
            float thickness = scrollBar.Direction == ScrollBar.DirectionType.Vertical ? scrollBar.SizeWidth : scrollBar.SizeHeight;
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
            if (scrollBar.Direction == ScrollBar.DirectionType.Vertical)
            {
                scrollBar.ThumbSize = new Size(thickness, length);
            }
            else
            {
                scrollBar.ThumbSize = new Size(length, thickness);
            }
            scrollBar.MinValue = 0;
            scrollBar.MaxValue = (int)(range - extent);
            scrollBar.SetCurrentValue((int)offset, flagAni);
            scrollBar.Show();
            if (scrollBarShowTimer == null)
            {
                scrollBarShowTimer = new Timer(millisecond);
                scrollBarShowTimer.Tick += OnShowTimerTick;
            }
            else
            {
                scrollBarShowTimer.Interval = millisecond;
            }
            scrollBarShowTimer.Start();
        }

        private bool OnShowTimerTick(object source, EventArgs e)
        {
            if (scrollBar != null)
            {
                scrollBar.Hide();
            }

            return false;
        }

        internal void DispatchFocusChanged(int nextFocusPosition)
        {
            adapter.OnFocusChange(this, focusedItemIndex, nextFocusPosition);

            focusedItemIndex = nextFocusPosition;

            ShowScrollBar();
        }

        private void DispatchChildAttached(FlexibleViewViewHolder holder)
        {
            if (adapter != null && holder != null)
            {
                adapter.OnViewAttachedToWindow(holder);
            }
        }

        private void DispatchChildDetached(FlexibleViewViewHolder holder)
        {
            if (adapter != null && holder != null)
            {
                adapter.OnViewDetachedFromWindow(holder);
            }
        }

        private void DispatchChildDestroyed(FlexibleViewViewHolder holder)
        {
            if (adapter != null && holder != null)
            {
                adapter.OnDestroyViewHolder(holder);
            }
        }

        private void DispatchItemClicked(FlexibleViewViewHolder clickedHolder)
        {
            FlexibleViewItemClickedEventArgs args = new FlexibleViewItemClickedEventArgs();
            args.ClickedView = clickedHolder;
            OnClickEvent(this, args);
        }

        private void DispatchItemTouched(FlexibleViewViewHolder touchedHolder, Touch touchEvent)
        {
            FlexibleViewItemTouchEventArgs args = new FlexibleViewItemTouchEventArgs();
            args.TouchedView = touchedHolder;
            args.Touch = touchEvent;
            OnTouchEvent(this, args);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                layout.StopScroll(true);
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (layout.CanScrollVertically())
                {
                    layout.ScrollVerticallyBy(e.PanGesture.Displacement.Y, recycler, true);
                }
                else if (layout.CanScrollHorizontally())
                {
                    layout.ScrollHorizontallyBy(e.PanGesture.Displacement.X, recycler, true);
                }

                ShowScrollBar();
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                if (layout.CanScrollVertically())
                {
                    layout.ScrollVerticallyBy(e.PanGesture.Velocity.Y * 600, recycler, false);
                }
                else if (layout.CanScrollHorizontally())
                {
                    layout.ScrollHorizontallyBy(e.PanGesture.Velocity.X * 600, recycler, false);
                }
                ShowScrollBar(1200, true);
            }
        }

        private void OnItemEvent(object sender, FlexibleViewAdapter.ItemEventArgs e)
        {
            switch (e.EventType)
            {
                case FlexibleViewAdapter.ItemEventType.Insert:
                    adapteHelper.OnItemRangeInserted(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case FlexibleViewAdapter.ItemEventType.Remove:
                    adapteHelper.OnItemRangeRemoved(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case FlexibleViewAdapter.ItemEventType.Move:
                    break;
                case FlexibleViewAdapter.ItemEventType.Change:
                    break;
                default:
                    return;
            }
            RelayoutRequest();
        }


        private void OnClickEvent(object sender, FlexibleViewItemClickedEventArgs e)
        {
            clickEventHandlers?.Invoke(sender, e);
        }

        private void OnTouchEvent(object sender, FlexibleViewItemTouchEventArgs e)
        {
            touchEventHandlers?.Invoke(sender, e);
        }

        internal void LayoutManagerRelayoutRequest()
        {
            RelayoutRequest();
        }

        internal ChildHelper GetChildHelper()
        {
            return childHelper;
        }
    }
}
