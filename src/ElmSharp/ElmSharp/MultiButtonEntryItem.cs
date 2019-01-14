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

namespace ElmSharp
{
    /// <summary>
    /// It inherits <see cref="ItemObject"/>.
    /// MutltiButtonEntryItem is an item, which is added to MultiButtonEntry.
    /// It contains Next and Prev properties to get the next and previous item.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class MultiButtonEntryItem : ItemObject
    {
        /// <summary>
        /// Creates and initializes a new instance of the MultiButtonEntryItem class.
        /// </summary>
        /// <param name="text">The text of the MultiButtonEntryItem's label name.</param>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem(string text) : base(null, IntPtr.Zero)
        {
            Label = text;
        }

        internal MultiButtonEntryItem(EvasObject parent, IntPtr handle) : base(parent, handle)
        {
            Label = Interop.Elementary.elm_object_item_part_text_get(handle, null);
        }

        /// <summary>
        /// Gets the label of this item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Label { get; private set; }

        /// <summary>
        /// Gets or sets the selected state of an item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_multibuttonentry_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_multibuttonentry_item_selected_set(Handle, value);
            }
        }

        /// <summary>
        /// Get the next item in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem Next
        {
            get
            {
                var next = Interop.Elementary.elm_multibuttonentry_item_next_get(Handle);
                return ItemObject.GetItemByHandle(next) as MultiButtonEntryItem;
            }
        }

        /// <summary>
        /// Get the previous item in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem Prev
        {
            get
            {
                var prev = Interop.Elementary.elm_multibuttonentry_item_prev_get(Handle);
                return ItemObject.GetItemByHandle(prev) as MultiButtonEntryItem;
            }
        }
    }
}