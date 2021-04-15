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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// A View that serves as a base class for views that contain a templated list of items.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class RecyclerView : ScrollableBase, ICollectionChangedNotifier
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public RecyclerView() : base()
        {
            Scrolling += OnScrolling;
        }

        /// <summary>
        /// Item's source data.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual IEnumerable ItemsSource { get; set; }

        /// <summary>
        /// DataTemplate for items.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual DataTemplate ItemTemplate { get; set; }

        /// <summary>
        /// Internal encapsulated items data source.
        /// </summary>
        internal IItemSource InternalItemSource { get; set; }

        /// <summary>
        /// RecycleCache of ViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected List<RecyclerViewItem> RecycleCache { get; } = new List<RecyclerViewItem>();

        /// <summary>
        /// Internal Items Layouter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ItemsLayouter InternalItemsLayouter { get; set; }

        /// <summary>
        /// Max size of RecycleCache. Default is 50.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int CacheMax { get; set; } = 50;

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            //Console.WriteLine("[NUI] On ReLayout [{0} {0}]", size.X, size.Y);
            base.OnRelayout(size, container);
            if (InternalItemsLayouter != null && ItemsSource != null && ItemTemplate != null)
            {
                InternalItemsLayouter.Initialize(this);
                InternalItemsLayouter.RequestLayout(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y, true);
            }
        }

        /// <summary>
        /// Notify Dataset is Changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyDataSetChanged()
        {
            //Need to update view.
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyDataSetChanged();
                if (ScrollingDirection == Direction.Horizontal)
                {
                    ContentContainer.SizeWidth =
                        InternalItemsLayouter.CalculateLayoutOrientationSize();
                }
                else
                {
                    ContentContainer.SizeHeight =
                        InternalItemsLayouter.CalculateLayoutOrientationSize();
                }
            }
        }

        /// <summary>
        /// Notify observable item is changed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Changed item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemChanged(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemChanged(source, startIndex);
            }
        }

        /// <summary>
        /// Notify range of observable items from start to end are changed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startRange">Start index of changed items range.</param>
        /// <param name="endRange">End index of changed items range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeChanged(IItemSource source, int startRange, int endRange)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeChanged(source, startRange, endRange);
            }
        }

        /// <summary>
        /// Notify observable item is inserted in dataset.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Inserted item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemInserted(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemInserted(source, startIndex);
            }
        }

        /// <summary>
        /// Notify count range of observable count items are inserted in startIndex.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Start index of inserted items range.</param>
        /// <param name="count">The number of inserted items.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeInserted(IItemSource source, int startIndex, int count)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeInserted(source, startIndex, count);
            }
        }

        /// <summary>
        /// Notify observable item is moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="fromPosition">Previous item position.</param>
        /// <param name="toPosition">Moved item position.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemMoved(IItemSource source, int fromPosition, int toPosition)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemMoved(source, fromPosition, toPosition);
            }
        }

        /// <summary>
        /// Notify the observable item is moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        /// <param name="count"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRangeMoved(IItemSource source, int fromPosition, int toPosition, int count)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeMoved(source, fromPosition, toPosition, count);
            }
        }

        /// <summary>
        /// Notify the observable item in startIndex is removed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Index of removed item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void NotifyItemRemoved(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRemoved(source, startIndex);
            }
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
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeRemoved(source, startIndex, count);
            }
        }

        /// <summary>
        /// Realize indexed item.
        /// </summary>
        /// <param name="index"> Index position of realizing item </param>
        internal virtual RecyclerViewItem RealizeItem(int index)
        {
            object context = InternalItemSource.GetItem(index);
            // Check DataTemplate is Same!
            if (ItemTemplate is DataTemplateSelector)
            {
                // Need to implements for caching of selector!
            }
            else
            {
                // pop item
                RecyclerViewItem item = PopRecycleCache(ItemTemplate);
                if (item != null)
                {
                    DecorateItem(item, index, context);
                    return item;
                }
            }

            object content = DataTemplateExtensions.CreateContent(ItemTemplate, context, (BindableObject)this) ?? throw new Exception("Template return null object.");
            if (content is RecyclerViewItem)
            {
                RecyclerViewItem item = (RecyclerViewItem)content;
                ContentContainer.Add(item);
                DecorateItem(item, index, context);
                return item;
            }
            else
            {
                throw new Exception("Template content must be type of ViewItem");
            }

        }

        /// <summary>
        /// Unrealize indexed item.
        /// </summary>
        /// <param name="item"> Target item for unrealizing </param>
        /// <param name="recycle"> Allow recycle. default is true </param>
        internal virtual void UnrealizeItem(RecyclerViewItem item, bool recycle = true)
        {
            if (item == null) return;
            item.Index = -1;
            item.ParentItemsView = null;
            item.BindingContext = null; 
            item.IsPressed = false;
            item.IsSelected = false;
            item.IsEnabled = true;
            item.UpdateState();
            item.Relayout -= OnItemRelayout;

            if (!recycle || !PushRecycleCache(item))
            {
                //ContentContainer.Remove(item);
                Utility.Dispose(item);
            }
        }

        /// <summary>
        /// Adjust scrolling position by own scrolling rules.
        /// Override this function when developer wants to change destination of flicking.(e.g. always snap to center of item)
        /// </summary>
        /// <param name="position">Scroll position which is calculated by ScrollableBase.</param>
        /// <returns>Adjusted scroll destination</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override float AdjustTargetPositionOfScrollAnimation(float position)
        {
            // Destination is depending on implementation of layout manager.
            // Get destination from layout manager.
            return InternalItemsLayouter.CalculateCandidateScrollPosition(position);
        }

        /// <summary>
        /// Push the item into the recycle cache. this item will be reused in view update.
        /// </summary>
        /// <param name="item"> Target item to push into recycle cache. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool PushRecycleCache(RecyclerViewItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (RecycleCache.Count >= CacheMax) return false;
            if (item.Template == null) return false;
            item.Hide();
            item.Index = -1;
            RecycleCache.Add(item);
            return true;
        }

        /// <summary>
        /// Pop the item from the recycle cache.
        /// </summary>
        /// <param name="Template"> Template of wanted item. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual RecyclerViewItem PopRecycleCache(DataTemplate Template)
        {
            for (int i = 0; i < RecycleCache.Count; i++)
            {
                RecyclerViewItem item = RecycleCache[i];
                if (item.Template == Template)
                {
                    RecycleCache.Remove(item);
                    item.Show();
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// On scroll event callback.
        /// </summary>        
        /// <since_tizen> 9 </since_tizen>
        protected virtual void OnScrolling(object source, ScrollEventArgs args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            if (!disposed && InternalItemsLayouter != null && ItemsSource != null && ItemTemplate != null)
            {
                //Console.WriteLine("[NUI] On Scrolling! {0} => {1}", ScrollPosition.Y, args.Position.Y);
                InternalItemsLayouter.RequestLayout(ScrollingDirection == Direction.Horizontal ? args.Position.X : args.Position.Y);
            }
        }

        /// <summary>
        /// Dispose ItemsView and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                // call the clear!
                if (RecycleCache != null)
                {
                    foreach (RecyclerViewItem item in RecycleCache)
                    {
                        UnrealizeItem(item, false);
                    }
                    RecycleCache.Clear();
                }
                InternalItemsLayouter.Clear();
                InternalItemsLayouter = null;
                ItemsSource = null;
                ItemTemplate = null;
                if (InternalItemSource != null)
                {
                    InternalItemSource.Dispose();
                    InternalItemSource = null;
                }
                //
            }

            base.Dispose(type);
        }

        private void OnItemRelayout(object sender, EventArgs e)
        {
            //FIXME: we need to skip the first relayout and only call size changed when real size change happen.
            //InternalItemsLayouter.NotifyItemSizeChanged((sender as ViewItem));
            //InternalItemsLayouter.RequestLayout(ScrollingDirection == Direction.Horizontal ? ContentContainer.CurrentPosition.X : ContentContainer.CurrentPosition.Y);
        }

        private void DecorateItem(RecyclerViewItem item, int index, object context)
        {
            item.Index = index;
            item.ParentItemsView = this;
            item.Template = (ItemTemplate as DataTemplateSelector)?.SelectDataTemplate(InternalItemSource.GetItem(index), this) ?? ItemTemplate;
            item.BindingContext = context;
            item.Relayout += OnItemRelayout;
        }
    }
}
