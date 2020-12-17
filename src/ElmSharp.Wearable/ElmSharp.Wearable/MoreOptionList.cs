/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    class MoreOptionList : IList<MoreOptionItem>
    {
        MoreOption Owner { get; set; }

        List<MoreOptionItem> Items { get; set; }

        /// <summary>
        /// Sets or gets the count of items.
        /// </summary>
        public int Count => Items.Count;

        /// <summary>
        /// Sets or gets whether it is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Sets or gets the item with the index.
        /// </summary>
        /// <param name="index">The position of item in items.</param>
        /// <returns>MoreOptionItem object on the index.</returns>
        public MoreOptionItem this[int index]
        {
            get
            {
                return Items[index];
            }

            set
            {
                Items[index] = value;
            }
        }

        /// <summary>
        /// Creates and initializes a new instance of the MoreOptionList class.
        /// </summary>
        /// <param name="owner">The object of more option.</param>
        public MoreOptionList(MoreOption owner)
        {
            Owner = owner;
            Items = new List<MoreOptionItem>();
        }

        /// <summary>
        /// Appends a new item to the more option.
        /// </summary>
        /// <param name="item">The more option item.</param>
        public void Add(MoreOptionItem item)
        {
            item.Handle = Interop.Eext.eext_more_option_item_append(Owner);
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new item to the more option at the first.
        /// </summary>
        /// <param name="item">The more option item.</param>
        public void AddFirst(MoreOptionItem item)
        {
            item.Handle = Interop.Eext.eext_more_option_item_prepend(Owner);
            Items.Insert(0, item);
        }

        /// <summary>
        /// Adds a new item to the more option at the last.
        /// </summary>
        /// <param name="item">The more option item.</param>
        public void AddLast(MoreOptionItem item)
        {
            Add(item);
        }

        /// <summary>
        /// Get the index of an item.
        /// </summary>
        /// <param name="item">The more option item.</param>
        /// <returns>The index of an item.</returns>
        public int IndexOf(MoreOptionItem item)
        {
            return Items.IndexOf(item);
        }

        /// <summary>
        /// Inserts a new item into the more option, after the more option item with the index.
        /// </summary>
        /// <param name="index">The index of an item, which is inserted after.</param>
        /// <param name="item">The more option item.</param>
        public void Insert(int index, MoreOptionItem item)
        {
            if (Items.Count < index + 1 || index < 0)
                throw new ArgumentOutOfRangeException("index is not valid in the MoreOption");

            MoreOptionItem target = Items[index];
            item.Handle = Interop.Eext.eext_more_option_item_insert_after(Owner, target.Handle);
            Items.Insert(index, item);
        }

        /// <summary>
        /// Deletes an item, which is the given item index.
        /// </summary>
        /// <param name="index">the item index which will be deleted</param>
        public void RemoveAt(int index)
        {
            if (Items.Count < index + 1 || index < 0)
                throw new ArgumentOutOfRangeException("index is not valid in the MoreOptionList");

            MoreOptionItem item = Items[index];
            Interop.Eext.eext_more_option_item_del(item.Handle);
            item.Handle = IntPtr.Zero;
            Items.RemoveAt(index);
        }

        /// <summary>
        /// Removes all the items from a given more option list object.
        /// </summary>
        public void Clear()
        {
            Interop.Eext.eext_more_option_items_clear(Owner);
            foreach (MoreOptionItem item in Items)
            {
                item.Handle = IntPtr.Zero;
            }
            Items.Clear();
        }

        /// <summary>
        /// Checks the item whether it is contained.
        /// </summary>
        /// <param name="item">The more option item.</param>
        /// <returns>If contained return true, otherwise false.</returns>
        public bool Contains(MoreOptionItem item)
        {
            return Items.Contains(item);
        }

        /// <summary>
        /// Copies the items.
        /// </summary>
        /// <param name="array">The target array.</param>
        /// <param name="arrayIndex">The index to which the item will be copied.</param>
        public void CopyTo(MoreOptionItem[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The item will be removed.</param>
        /// <returns>If removed is successful return true, otherwise false.</returns>
        public bool Remove(MoreOptionItem item)
        {
            if (Items.Contains(item))
            {
                Interop.Eext.eext_more_option_item_del(item.Handle);
                Items.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through IEnumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MoreOptionItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
