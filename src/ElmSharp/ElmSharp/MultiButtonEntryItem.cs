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
    public class MultiButtonEntryItem : ItemObject
    {
        public MultiButtonEntryItem(string text) : base(IntPtr.Zero)
        {
            Label = text;
        }

        internal MultiButtonEntryItem(IntPtr handle) : base(handle)
        {
            Label = Interop.Elementary.elm_object_item_part_text_get(handle, null);
        }

        public string Label { get; private set; }

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

        public MultiButtonEntryItem Next
        {
            get
            {
                var next = Interop.Elementary.elm_multibuttonentry_item_next_get(Handle);
                return ItemObject.GetItemByHandle(next) as MultiButtonEntryItem;
            }
        }

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