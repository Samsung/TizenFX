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

namespace Tizen.NUI.Components
{
    sealed class ListSource : IItemSource, IList
    {
        IList _itemsSource;

        public ListSource()
        {
        }

        public ListSource(IEnumerable<object> enumerable)
        {
            _itemsSource = new List<object>(enumerable);
        }

        public ListSource(IEnumerable enumerable)
        {
            _itemsSource = new List<object>();

            if (enumerable == null)
                return;

            foreach (object item in enumerable)
            {
                _itemsSource.Add(item);
            }
        }

        public int Count => _itemsSource.Count + (HasHeader ? 1 : 0) + (HasFooter ? 1 : 0);

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }

        public bool IsReadOnly => _itemsSource.IsReadOnly;

        public bool IsFixedSize => _itemsSource.IsFixedSize;

        public object SyncRoot => _itemsSource.SyncRoot;

        public bool IsSynchronized => _itemsSource.IsSynchronized;

        object IList.this[int index] { get => _itemsSource[index]; set => _itemsSource[index] = value; }

        public void Dispose()
        {

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
            for (int n = 0; n < _itemsSource.Count; n++)
            {
                var elementByIndex = _itemsSource[n];
                var isEqual = elementByIndex == item || (elementByIndex != null && item != null && elementByIndex.Equals(item));

                if (isEqual)
                {
                    return AdjustPosition(n);
                }
            }

            return -1;
        }

        public object GetItem(int position)
        {
            return _itemsSource[AdjustIndexRequest(position)];
        }

        int AdjustIndexRequest(int index)
        {
            return index - (HasHeader ? 1 : 0);
        }

        int AdjustPosition(int index)
        {
            return index + (HasHeader ? 1 : 0);
        }
        public int Add(object value)
        {
            return _itemsSource.Add(value);
        }

        public bool Contains(object value)
        {
            return _itemsSource.Contains(value);
        }

        public void Clear()
        {
            _itemsSource.Clear();
        }

        public int IndexOf(object value)
        {
            return _itemsSource.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            _itemsSource.Insert(index, value);
        }

        public void Remove(object value)
        {
            _itemsSource.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _itemsSource.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            _itemsSource.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _itemsSource.GetEnumerator();
        }
    }
}
