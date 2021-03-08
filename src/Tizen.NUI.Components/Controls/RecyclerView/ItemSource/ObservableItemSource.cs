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
using System.Collections.Specialized;

namespace Tizen.NUI.Components
{
    internal class ObservableItemSource : IItemSource
    {
        readonly IEnumerable itemsSource;
        readonly ICollectionChangedNotifier notifier;
        bool disposed;

        public ObservableItemSource(IEnumerable itemSource, ICollectionChangedNotifier changedNotifier)
        {
            itemsSource = itemSource as IList ?? itemSource as IEnumerable;
            notifier = changedNotifier;

            ((INotifyCollectionChanged)itemSource).CollectionChanged += CollectionChanged;
        }


        internal event NotifyCollectionChangedEventHandler CollectionItemsSourceChanged;

        public int Count => ItemsCount() + (HasHeader ? 1 : 0) + (HasFooter ? 1 : 0);

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }

        public void Dispose()
        {
            Dispose(true);
        }

        public bool IsFooter(int index)
        {
            return HasFooter && index == Count - 1;
        }

        public bool IsHeader(int index)
        {
            return HasHeader && index == 0;
        }

        public int GetPosition(object item)
        {
            for (int n = 0; n < ItemsCount(); n++)
            {
                var elementByIndex = ElementAt(n);
                var isEqual = elementByIndex == item || (elementByIndex != null && item != null && elementByIndex.Equals(item));

                if (isEqual)
                {
                    return AdjustPositionForHeader(n);
                }
            }

            return -1;
        }

        public object GetItem(int position)
        {
            return ElementAt(AdjustIndexForHeader(position));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;

            if (disposing)
            {
                ((INotifyCollectionChanged)itemsSource).CollectionChanged -= CollectionChanged;
            }
        }

        int AdjustIndexForHeader(int index)
        {
            return index - (HasHeader ? 1 : 0);
        }

        int AdjustPositionForHeader(int position)
        {
            return position + (HasHeader ? 1 : 0);
        }

        void CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {/*
            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(() => CollectionChanged(args));
            }
            else
            {*/
            CollectionChanged(args);
            //}

        }

        void CollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Add(args);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Remove(args);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Replace(args);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Move(args);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    notifier.NotifyDataSetChanged();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(args));
            }
            CollectionItemsSourceChanged?.Invoke(this, args);
        }

        void Move(NotifyCollectionChangedEventArgs args)
        {
            var count = args.NewItems.Count;

            if (count == 1)
            {
                // For a single item, we can use NotifyItemMoved and get the animation
                notifier.NotifyItemMoved(this, AdjustPositionForHeader(args.OldStartingIndex), AdjustPositionForHeader(args.NewStartingIndex));
                return;
            }

            var start = AdjustPositionForHeader(Math.Min(args.OldStartingIndex, args.NewStartingIndex));
            var end = AdjustPositionForHeader(Math.Max(args.OldStartingIndex, args.NewStartingIndex) + count);
            notifier.NotifyItemRangeChanged(this, start, end);
        }

        void Add(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.NewStartingIndex > -1 ? args.NewStartingIndex : IndexOf(args.NewItems[0]);
            startIndex = AdjustPositionForHeader(startIndex);
            var count = args.NewItems.Count;

            if (count == 1)
            {
                notifier.NotifyItemInserted(this, startIndex);
                return;
            }

            notifier.NotifyItemRangeInserted(this, startIndex, count);
        }

        void Remove(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.OldStartingIndex;

            if (startIndex < 0)
            {
                // INCC implementation isn't giving us enough information to know where the removed items were in the
                // collection. So the best we can do is a NotifyDataSetChanged()
                notifier.NotifyDataSetChanged();
                return;
            }

            startIndex = AdjustPositionForHeader(startIndex);

            // If we have a start index, we can be more clever about removing the item(s) (and get the nifty animations)
            var count = args.OldItems.Count;

            if (count == 1)
            {
                notifier.NotifyItemRemoved(this, startIndex);
                return;
            }

            notifier.NotifyItemRangeRemoved(this, startIndex, count);
        }

        void Replace(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.NewStartingIndex > -1 ? args.NewStartingIndex : IndexOf(args.NewItems[0]);
            startIndex = AdjustPositionForHeader(startIndex);
            var newCount = args.NewItems.Count;

            if (newCount == args.OldItems.Count)
            {
                // We are replacing one set of items with a set of equal size; we can do a simple item or range 
                // notification to the adapter
                if (newCount == 1)
                {
                    notifier.NotifyItemChanged(this, startIndex);
                }
                else
                {
                    notifier.NotifyItemRangeChanged(this, startIndex, newCount);
                }

                return;
            }

            // The original and replacement sets are of unequal size; this means that everything currently in view will 
            // have to be updated. So we just have to use NotifyDataSetChanged and let the RecyclerView update everything
            notifier.NotifyDataSetChanged();
        }

        internal int ItemsCount()
        {
            if (itemsSource is IList list)
                return list.Count;

            int count = 0;
            foreach (var item in itemsSource)
                count++;
            return count;
        }

        internal object ElementAt(int index)
        {
            if (itemsSource is IList list)
                return list[index];

            int count = 0;
            foreach (var item in itemsSource)
            {
                if (count == index)
                    return item;
                count++;
            }

            return -1;
        }

        internal int IndexOf(object item)
        {
            if (itemsSource is IList list)
                return list.IndexOf(item);

            int count = 0;
            foreach (var i in itemsSource)
            {
                if (i == item)
                    return count;
                count++;
            }

            return -1;
        }
    }
}
