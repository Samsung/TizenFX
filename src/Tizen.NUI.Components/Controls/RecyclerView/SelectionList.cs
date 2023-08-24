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
    // Used by the CollectionView to keep track of (and respond to changes in) the SelectedItems property
    internal class SelectionList : IList<object>
    {
        static readonly IList<object> selectEmpty = new List<object>(0);
        readonly CollectionView ColView;
        readonly IList<object> internalList;
        IList<object> shadowList;
        bool externalChange;

        public SelectionList(CollectionView colView, IList<object> items = null)
        {
            ColView = colView ?? throw new ArgumentNullException(nameof(colView));
            internalList = items ?? new List<object>();
            shadowList = Copy();

            if (items is INotifyCollectionChanged incc)
            {
                incc.CollectionChanged += OnCollectionChanged;
            }
        }

        public object this[int index] { get => internalList[index]; set => internalList[index] = value; }

        public int Count => internalList.Count;

        public bool IsReadOnly => false;

        public void Add(object item)
        {
            externalChange = true;
            internalList.Add(item);
            externalChange = false;

            ColView.SelectedItemsPropertyChanged(shadowList, internalList);
            shadowList.Add(item);
        }

        public void Clear()
        {
            externalChange = true;
            internalList.Clear();
            externalChange = false;

            ColView.SelectedItemsPropertyChanged(shadowList, selectEmpty);
            shadowList.Clear();
        }

        public bool Contains(object item)
        {
            return internalList.Contains(item);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<object> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public int IndexOf(object item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, object item)
        {
            externalChange = true;
            internalList.Insert(index, item);
            externalChange = false;

            ColView.SelectedItemsPropertyChanged(shadowList, internalList);
            shadowList.Insert(index, item);
        }

        public bool Remove(object item)
        {
            externalChange = true;
            var removed = internalList.Remove(item);
            externalChange = false;

            if (removed)
            {
                ColView.SelectedItemsPropertyChanged(shadowList, internalList);
                shadowList.Remove(item);
            }

            return removed;
        }

        public void RemoveAt(int index)
        {
            externalChange = true;
            internalList.RemoveAt(index);
            externalChange = false;

            ColView.SelectedItemsPropertyChanged(shadowList, internalList);
            shadowList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        List<object> Copy()
        {
            var items = new List<object>();
            for (int n = 0; n < internalList.Count; n++)
            {
                items.Add(internalList[n]);
            }

            return items;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (externalChange)
            {
                // If this change was initiated by a renderer or direct manipulation of ColllectionView.SelectedItems,
                // we don't need to send a selection change notification
                return;
            }

            // This change is coming from a bound viewmodel property
            // Emit a selection change notification, then bring the shadow copy up-to-date
            ColView.SelectedItemsPropertyChanged(shadowList, internalList);
            shadowList = Copy();
        }
    }
}
