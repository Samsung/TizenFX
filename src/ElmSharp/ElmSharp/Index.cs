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
    public class Index : Layout
    {
        HashSet<IndexItem> _children = new HashSet<IndexItem>();
        SmartEvent _delayedChanged;

        public Index(EvasObject parent) : base(parent)
        {
            _delayedChanged = new SmartEvent(this, this.RealHandle, "delay,changed");
            _delayedChanged.On += _delayedChanged_On;
        }

        public event EventHandler Changed;

        public bool AutoHide
        {
            get
            {
                return !Interop.Elementary.elm_index_autohide_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_index_autohide_disabled_set(RealHandle, !value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_index_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_index_horizontal_set(RealHandle, value);
            }
        }

        public bool IndicatorVisible
        {
            get
            {
                return !Interop.Elementary.elm_index_indicator_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_index_indicator_disabled_set(RealHandle, !value);
            }
        }

        public bool OmitEnabled
        {
            get
            {
                return Interop.Elementary.elm_index_omit_enabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_index_omit_enabled_set(RealHandle, value);
            }
        }

        public IndexItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_index_selected_item_get(RealHandle, 0);
                return ItemObject.GetItemByHandle(handle) as IndexItem;
            }
        }

        public IndexItem Append(string label)
        {
            IndexItem item = new IndexItem(label);
            item.Handle = Interop.Elementary.elm_index_item_append(RealHandle, label, null, (IntPtr)item.Id);
            return item;
        }

        public IndexItem Prepend(string label)
        {
            IndexItem item = new IndexItem(label);
            item.Handle = Interop.Elementary.elm_index_item_prepend(RealHandle, label, null, (IntPtr)item.Id);
            return item;
        }

        public IndexItem InsertBefore(string label, IndexItem before)
        {
            IndexItem item = new IndexItem(label);
            item.Handle = Interop.Elementary.elm_index_item_insert_before(RealHandle, before, label, null, (IntPtr)item.Id);
            return item;
        }

        public void Update(int level)
        {
            Interop.Elementary.elm_index_level_go(RealHandle, level);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_index_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        void _delayedChanged_On(object sender, EventArgs e)
        {
            SelectedItem?.SendSelected();
            Changed?.Invoke(this, e);
        }

        void AddInternal(IndexItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((IndexItem)sender);
        }
    }
}
