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
using System.Collections.Generic;

namespace ElmSharp
{
    public class FlipSelector : Layout
    {
        SmartEvent _selected;
        SmartEvent _overflowed;
        SmartEvent _underflowed;

        public FlipSelector(EvasObject parent) : base(parent)
        {
            _selected = new SmartEvent(this, Handle, "selected");
            _overflowed = new SmartEvent(this, Handle, "overflowed");
            _underflowed = new SmartEvent(this, Handle, "underflowed");

            _selected.On += SelectedChanged;
            _overflowed.On += OverflowedChanged;
            _underflowed.On += UnderflowedChanged;
        }

        public event EventHandler Selected;
        public event EventHandler Overflowed;
        public event EventHandler Underflowed;

        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_flipselector_first_interval_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_flipselector_first_interval_set(Handle, value);
            }
        }

        public FlipSelectorItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_selected_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        public FlipSelectorItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_first_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        public FlipSelectorItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_last_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        public FlipSelectorItem Append(string text)
        {
            FlipSelectorItem item = new FlipSelectorItem(text);
            item.Handle = Interop.Elementary.elm_flipselector_item_append(Handle, text, null, (IntPtr)item.Id);
            return item;
        }

        public FlipSelectorItem Prepend(string text)
        {
            FlipSelectorItem item = new FlipSelectorItem(text);
            item.Handle = Interop.Elementary.elm_flipselector_item_prepend(Handle, text, null, (IntPtr)item.Id);
            return item;
        }

        public void Remove(FlipSelectorItem item)
        {
            if (item as FlipSelectorItem != null)
                item.Delete();
        }

        public void Next()
        {
            Interop.Elementary.elm_flipselector_flip_next(Handle);
        }

        public void Prev()
        {
            Interop.Elementary.elm_flipselector_flip_prev(Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_flipselector_add(parent.Handle);
        }

        void SelectedChanged(object sender, EventArgs e)
        {
            SelectedItem?.SendSelected();
            Selected?.Invoke(this, EventArgs.Empty);
        }

        void OverflowedChanged(object sender, EventArgs e)
        {
            Overflowed?.Invoke(this, e);
        }

        void UnderflowedChanged(object sender, EventArgs e)
        {
            Underflowed?.Invoke(this, e);
        }
    }
}
