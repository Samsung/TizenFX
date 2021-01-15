/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// [Draft] This class provides a View that can layouting items in list and grid with high performance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ItemsView : ScrollableBase, ICollectionChangedNotifier
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
       [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemsView() : base()
        {
            Scrolling += OnScrolling;
        }

        /// <summary>
        /// Item's source data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IEnumerable ItemsSource { get; set; }

        /// <summary>
        /// DataTemplate for items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataTemplate ItemTemplate { get; set; }

        /// <summary>
        /// Internal encapsulated items data source.
        /// </summary>
        internal IItemSource InternalItemSource { get; set;}

        /// <summary>
        /// RecycleCache of ViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected List<ViewItem> RecycleCache { get; } = new List<ViewItem>();

        /// <summary>
        /// Internal Items Layouter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ItemsLayouter InternalItemsLayouter {get; set; }

        /// <summary>
        /// Max size of RecycleCache. Default is 50.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int CacheMax { get; set; } = 50;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        public void NotifyDataSetChanged()
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
        public void NotifyItemChanged(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemChanged(source, startIndex);
            }
        }

        /// <summary>
        /// Notify observable item is inserted in dataset.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Inserted item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemInserted(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemInserted(source, startIndex);
            }
        }

        /// <summary>
        /// Notify observable item is moved from fromPosition to ToPosition.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="fromPosition">Previous item position.</param>
        /// <param name="toPosition">Moved item position.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemMoved(IItemSource source, int fromPosition, int toPosition)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemMoved(source, fromPosition, toPosition);
            }
        }

        /// <summary>
        /// Notify range of observable items from start to end are changed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="start">Start index of changed items range.</param>
        /// <param name="end">End index of changed items range.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemRangeChanged(IItemSource source, int start, int end)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeChanged(source, start, end);
            }
        }

        /// <summary>
        /// Notify count range of observable count items are inserted in startIndex.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Start index of inserted items range.</param>
        /// <param name="count">The number of inserted items.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemRangeInserted(IItemSource source, int startIndex, int count)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeInserted(source, startIndex, count);
            }
        }

        /// <summary>
        /// Notify the count range of observable items from the startIndex are removed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Start index of removed items range.</param>
        /// <param name="count">The number of removed items</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemRangeRemoved(IItemSource source, int startIndex, int count)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRangeRemoved(source, startIndex, count);
            }
        }

        /// <summary>
        /// Notify the observable item in startIndex is removed.
        /// </summary>
        /// <param name="source">Dataset source.</param>
        /// <param name="startIndex">Index of removed item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemRemoved(IItemSource source, int startIndex)
        {
            if (InternalItemsLayouter != null)
            {
                InternalItemsLayouter.NotifyItemRemoved(source, startIndex);
            }
        }

        /// <summary>
        /// Realize indexed item.
        /// </summary>
        /// <param name="index"> Index position of realizing item </param>
        internal virtual ViewItem RealizeItem(int index)
        {
            // Check DataTemplate is Same!
            if (ItemTemplate is DataTemplateSelector)
            {
                // Need to implements
            }
            else
            {
               // pop item
               ViewItem item = PopRecycleCache(ItemTemplate);
               if (item != null)
               {
                    DecorateItem(item, index);
                    return item;
               }
            }

            object content = ItemTemplate.CreateContent() ?? throw new Exception("Template return null object.");
            if (content is ViewItem)
            {
                ViewItem item = (ViewItem)content;
                ContentContainer.Add(item);
                DecorateItem(item, index);
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
        internal virtual void UnrealizeItem(ViewItem item, bool recycle = true)
        {
            item.Index = -1;
            item.ParentItemsView = null;
            // Remove BindingContext null set for performance improving.
            //item.BindingContext = null; 
            item.isPressed = false;
            item.IsSelected = false;
            item.IsEnabled = true;
            // Remove Update Style on default for performance improving.
            //item.UpdateState();
            item.Relayout -= OnItemRelayout;

            if (!recycle || !PushRecycleCache(item))
            {
                ContentContainer.Remove(item);
                item.Dispose();
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
        protected virtual bool PushRecycleCache(ViewItem item)
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
        protected virtual ViewItem PopRecycleCache(DataTemplate Template)
        {
           for (int i = 0; i < RecycleCache.Count; i++)
           {
               ViewItem item = RecycleCache[i];
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                disposed = true;
                // call the clear!
                if (RecycleCache != null)
                {
                    foreach (ViewItem item in RecycleCache)
                    {
                        ContentContainer.Remove(item);
                        item.Dispose();
                    }
                    RecycleCache.Clear();
                }
                InternalItemsLayouter.Clear();
                InternalItemsLayouter = null;
                ItemsSource = null;
                ItemTemplate = null;
                if (InternalItemSource != null) InternalItemSource.Dispose();
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

        private void DecorateItem(ViewItem item, int index)
        {
            item.Index = index;
            item.ParentItemsView = this;
            item.Template = (ItemTemplate as DataTemplateSelector)?.SelectDataTemplate(InternalItemSource.GetItem(index), this) ?? ItemTemplate;
            item.BindingContext = InternalItemSource.GetItem(index);
            item.Relayout += OnItemRelayout;
        }
    }
}
