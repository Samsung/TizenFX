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
using System.Collections.Specialized;

namespace Tizen.NUI.Components
{
    internal class ObservableGroupedSource : IGroupableItemSource, ICollectionChangedNotifier
    {
        readonly ICollectionChangedNotifier notifier;
        readonly IList groupSource;
        readonly List<IItemSource> groups = new List<IItemSource>();
        readonly bool hasGroupHeaders;
        readonly bool hasGroupFooters;
        bool disposed;

        public int Count
        {
            get
            {
                var groupContents = 0;

                for (int n = 0; n < groups.Count; n++)
                {
                    groupContents += groups[n].Count;
                }

                return (HasHeader ? 1 : 0)
                     + (HasFooter ? 1 : 0)
                     + groupContents;
            }
        }

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }

        public ObservableGroupedSource(CollectionView colView, ICollectionChangedNotifier changedNotifier)
        {
            var source = colView.ItemsSource;

            notifier = changedNotifier;
            groupSource = source as IList ?? new ListSource(source);

            hasGroupFooters = colView.GroupFooterTemplate != null;
            hasGroupHeaders = colView.GroupHeaderTemplate != null;
            HasHeader = colView.Header != null;
            HasFooter = colView.Footer != null;

            if (groupSource is INotifyCollectionChanged incc)
            {
                incc.CollectionChanged += CollectionChanged;
            }

            UpdateGroupTracking();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public bool IsFooter(int position)
        {
            if (!HasFooter)
            {
                return false;
            }

            return position == Count - 1;
        }

        public bool IsHeader(int position)
        {
            return HasHeader && position == 0;
        }

        public bool IsGroupHeader(int position)
        {
            if (IsFooter(position) || IsHeader(position))
            {
                return false;
            }

            var (group, inGroup) = GetGroupAndIndex(position);

            return groups[group].IsHeader(inGroup);
        }

        public bool IsGroupFooter(int position)
        {
            if (IsFooter(position) || IsHeader(position))
            {
                return false;
            }

            var (group, inGroup) = GetGroupAndIndex(position);

            return groups[group].IsFooter(inGroup);
        }

        public int GetPosition(object item)
        {
            int previousGroupsOffset = 0;

            for (int groupIndex = 0; groupIndex < groupSource.Count; groupIndex++)
            {
                if (groupSource[groupIndex].Equals(item))
                {
                    return AdjustPositionForHeader(groupIndex);
                }

                var group = groups[groupIndex];
                var inGroup = group.GetPosition(item);

                if (inGroup > -1)
                {
                    return AdjustPositionForHeader(previousGroupsOffset + inGroup);
                }

                previousGroupsOffset += group.Count;
            }

            return -1;
        }

        public object GetItem(int position)
        {
            var (group, inGroup) = GetGroupAndIndex(position);

            if (IsGroupFooter(position) || IsGroupHeader(position))
            {
                // This is looping to find the group/index twice, need to make it less inefficient
                return groupSource[group];
            }

            return groups[group].GetItem(inGroup);
        }

        public object GetGroupParent(int position)
        {
            var (group, inGroup) = GetGroupAndIndex(position);
            return groupSource[group];
        }

        // The ICollectionChangedNotifier methods are called by child observable items sources (i.e., the groups)
        // This class can then translate their local changes into global positions for upstream notification 
        // (e.g., to the actual RecyclerView.Adapter, so that it can notify the RecyclerView and handle animating
        // the changes)
        public void NotifyDataSetChanged()
        {
            Reload();
        }

        public void NotifyItemChanged(IItemSource group, int localIndex)
        {
            localIndex = GetAbsolutePosition(group, localIndex);
            notifier.NotifyItemChanged(this, localIndex);
        }

        public void NotifyItemInserted(IItemSource group, int localIndex)
        {
            localIndex = GetAbsolutePosition(group, localIndex);
            notifier.NotifyItemInserted(this, localIndex);
        }

        public void NotifyItemMoved(IItemSource group, int localFromIndex, int localToIndex)
        {
            localFromIndex = GetAbsolutePosition(group, localFromIndex);
            localToIndex = GetAbsolutePosition(group, localToIndex);
            notifier.NotifyItemMoved(this, localFromIndex, localToIndex);
        }

        public void NotifyItemRangeMoved(IItemSource group, int localFromIndex, int localToIndex, int count)
        {
            localFromIndex = GetAbsolutePosition(group, localFromIndex);
            localToIndex = GetAbsolutePosition(group, localToIndex);
            notifier.NotifyItemRangeMoved(this, localFromIndex, localToIndex, count);
        }

        public void NotifyItemRangeChanged(IItemSource group, int localStartIndex, int localEndIndex)
        {
            localStartIndex = GetAbsolutePosition(group, localStartIndex);
            localEndIndex = GetAbsolutePosition(group, localEndIndex);
            notifier.NotifyItemRangeChanged(this, localStartIndex, localEndIndex);
        }

        public void NotifyItemRangeInserted(IItemSource group, int localIndex, int count)
        {
            localIndex = GetAbsolutePosition(group, localIndex);
            notifier.NotifyItemRangeInserted(this, localIndex, count);
        }

        public void NotifyItemRangeRemoved(IItemSource group, int localIndex, int count)
        {
            localIndex = GetAbsolutePosition(group, localIndex);
            notifier.NotifyItemRangeRemoved(this, localIndex, count);
        }

        public void NotifyItemRemoved(IItemSource group, int localIndex)
        {
            localIndex = GetAbsolutePosition(group, localIndex);
            notifier.NotifyItemRemoved(this, localIndex);
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
                ClearGroupTracking();

                if (groupSource is INotifyCollectionChanged notifyCollectionChanged)
                {
                    notifyCollectionChanged.CollectionChanged -= CollectionChanged;
                }
                if (groupSource is IDisposable dispoableSource) dispoableSource.Dispose();
            }
        }

        void UpdateGroupTracking()
        {
            ClearGroupTracking();

            for (int n = 0; n < groupSource.Count; n++)
            {
                var source = ItemsSourceFactory.Create(groupSource[n] as IEnumerable, this);
                source.HasFooter = hasGroupFooters;
                source.HasHeader = hasGroupHeaders;
                groups.Add(source);
            }
        }

        void ClearGroupTracking()
        {
            for (int n = groups.Count - 1; n >= 0; n--)
            {
                groups[n].Dispose();
                groups.RemoveAt(n);
            }
        }

        void CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {/*
            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(() => CollectionChanged(args));
            }
            else
            {
                */
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
                    Reload();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(args));
            }
        }

        void Reload()
        {
            UpdateGroupTracking();
            notifier.NotifyDataSetChanged();
        }

        void Add(NotifyCollectionChangedEventArgs args)
        {
            var groupIndex = args.NewStartingIndex > -1 ? args.NewStartingIndex : groupSource.IndexOf(args.NewItems[0]);
            var groupCount = args.NewItems.Count;

            UpdateGroupTracking();

            // Determine the absolute starting position and the number of items in the groups being added
            var absolutePosition = GetAbsolutePosition(groups[groupIndex], 0);
            var itemCount = CountItemsInGroups(groupIndex, groupCount);

            if (itemCount == 1)
            {
                notifier.NotifyItemInserted(this, absolutePosition);
                return;
            }

            notifier.NotifyItemRangeInserted(this, absolutePosition, itemCount);
        }

        void Remove(NotifyCollectionChangedEventArgs args)
        {
            var groupIndex = args.OldStartingIndex;

            if (groupIndex < 0)
            {
                // INCC implementation isn't giving us enough information to know where the removed groups was in the
                // collection. So the best we can do is a full reload.
                Reload();
                return;
            }

            // If we have a start index, we can be more clever about removing the group(s) (and get the nifty animations)
            var groupCount = args.OldItems.Count;

            var absolutePosition = GetAbsolutePosition(groups[groupIndex], 0);

            // Figure out how many items are in the groups we're removing
            var itemCount = CountItemsInGroups(groupIndex, groupCount);

            if (itemCount == 1)
            {
                notifier.NotifyItemRemoved(this, absolutePosition);

                UpdateGroupTracking();

                return;
            }

            notifier.NotifyItemRangeRemoved(this, absolutePosition, itemCount);

            UpdateGroupTracking();
        }

        void Replace(NotifyCollectionChangedEventArgs args)
        {
            var groupCount = args.NewItems.Count;

            if (groupCount != args.OldItems.Count)
            {
                // The original and replacement sets are of unequal size; this means that most everything currently in 
                // view will have to be updated. So just reload the whole thing.
                Reload();
                return;
            }

            var newStartIndex = args.NewStartingIndex > -1 ? args.NewStartingIndex : groupSource.IndexOf(args.NewItems[0]);
            var oldStartIndex = args.OldStartingIndex > -1 ? args.OldStartingIndex : groupSource.IndexOf(args.OldItems[0]);

            var newItemCount = CountItemsInGroups(newStartIndex, groupCount);
            var oldItemCount = CountItemsInGroups(oldStartIndex, groupCount);

            if (newItemCount != oldItemCount)
            {
                // The original and replacement sets are of unequal size; this means that most everything currently in 
                // view will have to be updated. So just reload the whole thing.
                Reload();
                return;
            }

            // We are replacing one set of items with a set of equal size; we can do a simple item or range notification 
            var firstGroupIndex = Math.Min(newStartIndex, oldStartIndex);
            var absolutePosition = GetAbsolutePosition(groups[firstGroupIndex], 0);

            if (newItemCount == 1)
            {
                notifier.NotifyItemChanged(this, absolutePosition);
                UpdateGroupTracking();
            }
            else
            {
                notifier.NotifyItemRangeChanged(this, absolutePosition, newItemCount * 2);
                UpdateGroupTracking();
            }
        }

        void Move(NotifyCollectionChangedEventArgs args)
        {
            var itemCount = CountItemsInGroups(args.OldStartingIndex, args.OldItems.Count);
            var start = Math.Min(args.OldStartingIndex, args.NewStartingIndex);
            var end = Math.Max(args.OldStartingIndex, args.NewStartingIndex) + itemCount;

            var fromPosition = GetAbsolutePosition(groups[args.OldStartingIndex], 0);
            var toPosition = GetAbsolutePosition(groups[args.NewStartingIndex], 0);

            // RangeChanged give unspecified information about moves.
            // use RangeMoved instead of rangeChanged.
            //notifier.NotifyItemRangeChanged(this, absolutePosition, itemCount);
            notifier.NotifyItemRangeMoved(this, fromPosition, toPosition, itemCount);

            UpdateGroupTracking();
        }

        int GetAbsolutePosition(IItemSource group, int indexInGroup)
        {
            var groupIndex = groups.IndexOf(group);

            var runningIndex = 0;

            for (int n = 0; n < groupIndex; n++)
            {
                runningIndex += groups[n].Count;
            }

            return AdjustPositionForHeader(runningIndex + indexInGroup);
        }

        (int, int) GetGroupAndIndex(int absolutePosition)
        {
            absolutePosition = AdjustIndexForHeader(absolutePosition);

            var group = 0;
            var localIndex = 0;

            while (absolutePosition > 0)
            {
                localIndex += 1;

                if (localIndex == groups[group].Count)
                {
                    group += 1;
                    localIndex = 0;
                }

                absolutePosition -= 1;
            }

            return (group, localIndex);
        }

        int AdjustIndexForHeader(int index)
        {
            return index - (HasHeader ? 1 : 0);
        }

        int AdjustPositionForHeader(int position)
        {
            return position + (HasHeader ? 1 : 0);
        }

        int CountItemsInGroups(int groupStartIndex, int groupCount)
        {
            var itemCount = 0;
            for (int n = 0; n < groupCount; n++)
            {
                itemCount += groups[groupStartIndex + n].Count;
            }
            return itemCount;
        }
    }
}
