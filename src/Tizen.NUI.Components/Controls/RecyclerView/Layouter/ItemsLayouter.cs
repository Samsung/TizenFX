/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Default layout manager for RecyclerView.
    /// Layouting RecyclerViewItem on the scroll ContentContainer
    /// which need to be visible on the view by scroll position.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class ItemsLayouter : ICollectionChangedNotifier, IDisposable
    {
        private bool disposed = false;
        private Extents padding = new Extents(0, 0, 0, 0);

        /// <summary>
        /// Padding for ContentContainer of RecyclerView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Padding {
            get
            {
                return padding;
            }
            set
            {
                padding = value;
                if (ItemsView?.ContentContainer != null)
                {
                    ItemsView.Padding = padding;
                }
            }
        }

        /// <summary>
        /// Container which contains ViewItems.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View Container { get; set; }

        /// <summary>
        /// Parent ItemsView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected RecyclerView ItemsView { get; set; }

        /// <summary>
        /// The last scrolled position which is calculated by ScrollableBase. The value should be updated in the Recycle() method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected float PrevScrollPosition { get; set; }

        /// <summary>
        /// First index of visible items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int FirstVisible { get; set; } = -1;

        /// <summary>
        /// Last index of visible items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int LastVisible { get; set; } = -1;

        /// <summary>
        /// Visible ViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected List<RecyclerViewItem> VisibleItems { get; } = new List<RecyclerViewItem>();

        /// <summary>
        /// Flag of layouter initialization.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool IsInitialized { get; set; } = false;

        /// <summary>
        /// Candidate item step size for scroll size measure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected float StepCandidate { get; set; }

        /// <summary>
        /// Candidate item's Margin for scroll size measure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Extents CandidateMargin { get; set; }

        /// <summary>
        /// Content size of scrollable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected float ScrollContentSize { get; set; }

        /// <summary>
        /// boolean flag of scrollable horizontal direction.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool IsHorizontal { get; set; }

        /// <summary>
        /// Clean up ItemsLayouter.
        /// </summary>
        /// <param name="view"> ItemsView of layouter.</param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void Initialize(RecyclerView view)
        {
            ItemsView = view ?? throw new ArgumentNullException(nameof(view));
            Container = view.ContentContainer;
            PrevScrollPosition = 0.0f;

            IsHorizontal = (view.ScrollingDirection == ScrollableBase.Direction.Horizontal);

            IsInitialized = true;
        }

        /// <summary>
        /// This is called to find out where items are lain out according to current scroll position.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        /// <param name="force">boolean force flag to layouting forcely.</param>
        /// <since_tizen> 9 </since_tizen>
        public virtual void RequestLayout(float scrollPosition, bool force = false)
        {
            // Layouting Items in scrollPosition.
        }

        /// <summary>
        /// Clear the current screen and all properties.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void Clear()
        {
            foreach (RecyclerViewItem item in VisibleItems)
            {
                if (ItemsView != null) ItemsView.UnrealizeItem(item, false);
            }
            VisibleItems.Clear();
            if (CandidateMargin != null)
            {
                CandidateMargin.Dispose();
                CandidateMargin = null;
            }
            ItemsView = null;
            Container = null;
        }

        /// <summary>
        /// This is called to find out how much container size can be.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float CalculateLayoutOrientationSize()
        {
            return 0.0f;
        }

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// </summary>
        /// <param name="scrollPosition">Scroll position which is calculated by ScrollableBase</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float CalculateCandidateScrollPosition(float scrollPosition)
        {
            return scrollPosition;
        }

        /// <summary>
        /// Notify the relayout of ViewItem.
        /// </summary>
        /// <param name="item">updated ViewItem.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemSizeChanged(RecyclerViewItem item)
        {
        }

        /// <summary>
        /// Notify the dataset is Changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyDataSetChanged()
        {
            Initialize(ItemsView);
        }

        /// <summary>
        /// Notify the observable item in startIndex is changed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Changed item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemChanged(IItemSource source, int startIndex)
        {
        }

        /// <summary>
        /// Notify the observable item is inserted in dataset.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Inserted item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemInserted(IItemSource source, int startIndex)
        {
        }

        /// <summary>
        /// Notify the observable item is moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="fromPosition">Previous item position.</param>
        /// <param name="toPosition">Moved item position.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemMoved(IItemSource source, int fromPosition, int toPosition)
        {
        }

        /// <summary>
        /// Notify the range of the observable items are moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        /// <param name="count"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeMoved(IItemSource source, int fromPosition, int toPosition, int count)
        {
        }

        /// <summary>
        /// Notify the range of observable items from start to end are changed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startRange">Start index of changed items range.</param>
        /// <param name="endRange">End index of changed items range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeChanged(IItemSource source, int startRange, int endRange)
        {
        }

        /// <summary>
        /// Notify the count range of observable items are inserted in startIndex.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Start index of inserted items range.</param>
        /// <param name="count">The number of inserted items.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeInserted(IItemSource source, int startIndex, int count)
        {
        }

        /// <summary>
        /// Notify the count range of observable items from the startIndex are removed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Start index of removed items range.</param>
        /// <param name="count">The number of removed items</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeRemoved(IItemSource source, int startIndex, int count)
        {
        }

        /// <summary>
        /// Notify the observable item in startIndex is removed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Index of removed item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRemoved(IItemSource source, int startIndex)
        {
        }

        /// <summary>
        /// Gets the next keyboard focusable view in this control towards the given direction.<br />
        /// A control needs to override this function in order to support two dimensional keyboard navigation.<br />
        /// </summary>
        /// <param name="currentFocusedView">The current focused view.</param>
        /// <param name="direction">The direction to move the focus towards.</param>
        /// <param name="loopEnabled">Whether the focus movement should be looped within the control.</param>
        /// <returns>The next keyboard focusable view in this control or an empty handle if no view can be focused.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual View RequestNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            return null;
        }

        /// <summary>
        /// Dispose ItemsLayouter and all children on it.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Measure the size of child ViewItem manually.
        /// </summary>
        /// <param name="parent">Parent ItemsView.</param>
        /// <param name="child">Child ViewItem to Measure()</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureChild(RecyclerView parent, RecyclerViewItem child)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (child == null) throw new ArgumentNullException(nameof(child));

            if (child.Layout == null) return;

            //FIXME: This measure can be restricted size of child to be less than parent size.
            // but in some multiple-line TextLabel can be long enough to over the it's parent size.

            MeasureSpecification childWidthMeasureSpec = LayoutGroup.GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parent.Size.Width - parent.Padding.Start - parent.Padding.End - child.Margin.Start - child.Margin.End), MeasureSpecification.ModeType.Exactly),
                        new LayoutLength(0),
                        new LayoutLength(child.WidthSpecification));

            MeasureSpecification childHeightMeasureSpec = LayoutGroup.GetChildMeasureSpecification(
                        new MeasureSpecification(new LayoutLength(parent.Size.Height - parent.Padding.Top - parent.Padding.Bottom - child.Margin.Top - child.Margin.Bottom), MeasureSpecification.ModeType.Exactly),
                        new LayoutLength(0),
                        new LayoutLength(child.HeightSpecification));

            child.Layout.Measure(childWidthMeasureSpec, childHeightMeasureSpec);
        }

        /// <summary>
        /// Find consecutive visible items index.
        /// </summary>
        /// <param name="visibleArea">float turple of visible area start position to end position. </param>
        /// <return>int turple of start index to end index</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual (int start, int end) FindVisibleItems((float X, float Y) visibleArea)
        {
            return (0, 0);
        }

        /// <summary>
        /// Dispose ItemsLayouter and all children on it.
        /// </summary>
        /// <param name="disposing">true when it disposed by Dispose(). </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            if (disposing)
            {
                Clear();
                padding.Dispose();
            }
        }

        internal virtual (float X, float Y) GetItemPosition(int index)
        {
            return (0, 0);
        }

        internal virtual (float Width, float Height) GetItemSize(int index)
        {
            return (0, 0);
        }
    }
}
