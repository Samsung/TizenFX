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
    public enum ToolbarSelectionMode
    {
        Default = 0,
        Always,
        None,
        DisplayOnly,
    }

    public enum ToolbarShrinkMode
    {
        None = 0,
        Hide,
        Scroll,
        Menu,
        Expand
    }

    public class ToolbarItemEventArgs : EventArgs
    {
        public ToolbarItem Item { get; private set; }

        internal static ToolbarItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ToolbarItem item = ItemObject.GetItemByHandle(info) as ToolbarItem;
            return new ToolbarItemEventArgs() { Item = item };
        }
    }

    public class Toolbar : Widget
    {
        SmartEvent<ToolbarItemEventArgs> _clicked;
        SmartEvent<ToolbarItemEventArgs> _selected;
        SmartEvent<ToolbarItemEventArgs> _longpressed;
        public Toolbar(EvasObject parent) : base(parent)
        {
            _selected = new SmartEvent<ToolbarItemEventArgs>(this, this.RealHandle, "selected", ToolbarItemEventArgs.CreateFromSmartEvent);
            _selected.On += (s, e) =>
            {
                if (e.Item != null)
                {
                    Selected?.Invoke(this, e);
                    e.Item.SendSelected();
                }
            };
            _longpressed = new SmartEvent<ToolbarItemEventArgs>(this, this.RealHandle, "longpressed", ToolbarItemEventArgs.CreateFromSmartEvent);
            _longpressed.On += (s, e) =>
            {
                e.Item?.SendLongPressed();
            };
            _clicked = new SmartEvent<ToolbarItemEventArgs>(this, this.RealHandle, "clicked", ToolbarItemEventArgs.CreateFromSmartEvent);
            _clicked.On += (s, e) =>
            {
                e.Item?.SendClicked();
            };
        }

        public event EventHandler<ToolbarItemEventArgs> Selected;

        public bool Homogeneous
        {
            get
            {
                return Interop.Elementary.elm_toolbar_homogeneous_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_homogeneous_set(RealHandle, value);
            }
        }

        public ToolbarSelectionMode SelectionMode
        {
            get
            {
                return (ToolbarSelectionMode)Interop.Elementary.elm_toolbar_select_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_select_mode_set(RealHandle, (int)value);
            }
        }

        public ToolbarShrinkMode ShrinkMode
        {
            get
            {
                return (ToolbarShrinkMode)Interop.Elementary.elm_toolbar_shrink_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_shrink_mode_set(RealHandle, (int)value);
            }
        }

        public double ItemAlignment
        {
            get
            {
                return Interop.Elementary.elm_toolbar_align_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_align_set(RealHandle, value);
            }
        }

        public bool TransverseExpansion
        {
            get
            {
                return Interop.Elementary.elm_toolbar_transverse_expanded_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_transverse_expanded_set(RealHandle, value);
            }
        }

        public ToolbarItem Append(string label)
        {
            return Append(label, null);
        }
        public ToolbarItem Append(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_append(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        public ToolbarItem Prepend(string label)
        {
            return Prepend(label, null);
        }

        public ToolbarItem Prepend(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_prepend(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        public ToolbarItem InsertBefore(ToolbarItem before, string label)
        {
            return InsertBefore(before, label);
        }

        public ToolbarItem InsertBefore(ToolbarItem before, string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_insert_before(RealHandle, before, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        public ToolbarItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_toolbar_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as ToolbarItem;
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_toolbar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
