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
    public enum GenGridSelectionMode
    {
        Default = 0,
        Always,
        None,
        DisplayOnly,
    }

    public class GenGridItemEventArgs : EventArgs
    {
        public GenGridItem Item { get; set; }

        internal static GenGridItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenGridItem item = ItemObject.GetItemByHandle(info) as GenGridItem;
            return new GenGridItemEventArgs() { Item = item };
        }
    }

    public class GenGrid : Layout
    {
        HashSet<GenGridItem> _children = new HashSet<GenGridItem>();

        SmartEvent<GenGridItemEventArgs> _selected;
        SmartEvent<GenGridItemEventArgs> _unselected;
        SmartEvent<GenGridItemEventArgs> _activated;
        SmartEvent<GenGridItemEventArgs> _pressed;
        SmartEvent<GenGridItemEventArgs> _released;
        SmartEvent<GenGridItemEventArgs> _doubleClicked;
        SmartEvent<GenGridItemEventArgs> _realized;
        SmartEvent<GenGridItemEventArgs> _unrealized;
        SmartEvent<GenGridItemEventArgs> _longpressed;

        public GenGrid(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        public event EventHandler<GenGridItemEventArgs> ItemSelected;
        public event EventHandler<GenGridItemEventArgs> ItemUnselected;
        public event EventHandler<GenGridItemEventArgs> ItemPressed;
        public event EventHandler<GenGridItemEventArgs> ItemReleased;
        public event EventHandler<GenGridItemEventArgs> ItemActivated;
        public event EventHandler<GenGridItemEventArgs> ItemDoubleClicked;
        public event EventHandler<GenGridItemEventArgs> ItemRealized;
        public event EventHandler<GenGridItemEventArgs> ItemUnrealized;
        public event EventHandler<GenGridItemEventArgs> ItemLongPressed;

        public double ItemAlignmentX
        {
            get
            {
                double align;
                Interop.Elementary.elm_gengrid_align_get(RealHandle, out align, IntPtr.Zero);
                return align;
            }
            set
            {
                double aligny = ItemAlignmentY;
                Interop.Elementary.elm_gengrid_align_set(RealHandle, value, aligny);
            }
        }

        public double ItemAlignmentY
        {
            get
            {
                double align;
                Interop.Elementary.elm_gengrid_align_get(RealHandle, IntPtr.Zero, out align);
                return align;
            }
            set
            {
                double alignx = ItemAlignmentX;
                Interop.Elementary.elm_gengrid_align_set(RealHandle, alignx, value);
            }
        }

        public bool FillItems
        {
            get
            {
                return Interop.Elementary.elm_gengrid_filled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_filled_set(RealHandle, value);
            }
        }

        public bool MultipleSelection
        {
            get
            {
                return Interop.Elementary.elm_gengrid_multi_select_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_multi_select_set(RealHandle, value);
            }
        }

        public int ItemWidth
        {
            get
            {
                int width;
                Interop.Elementary.elm_gengrid_item_size_get(RealHandle, out width, IntPtr.Zero);
                return width;
            }
            set
            {
                int height = ItemHeight;
                Interop.Elementary.elm_gengrid_item_size_set(RealHandle, value, height);

            }
        }

        public int ItemHeight
        {
            get
            {
                int height;
                Interop.Elementary.elm_gengrid_item_size_get(RealHandle, IntPtr.Zero, out height);
                return height;
            }
            set
            {
                int width = ItemWidth;
                Interop.Elementary.elm_gengrid_item_size_set(RealHandle, width, value);
            }
        }

        public GenGridSelectionMode SelectionMode
        {
            get
            {
                return (GenGridSelectionMode)Interop.Elementary.elm_gengrid_select_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_select_mode_set(RealHandle, (int)value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_gengrid_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_horizontal_set(RealHandle, value);
            }
        }

        public bool IsHighlight
        {
            get
            {
                return Interop.Elementary.elm_gengrid_highlight_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_highlight_mode_set(RealHandle, value);
            }
        }

        public GenGridItem Append(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_append(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem Prepend(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_prepend(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem InsertBefore(GenItemClass itemClass, object data, GenGridItem before)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_before(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, before, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public void ScrollTo(GenGridItem item, ScrollToPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_gengrid_item_bring_in(item.Handle, (int)position);
            }
            else
            {
                Interop.Elementary.elm_gengrid_item_show(item.Handle, (int)position);
            }
        }

        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_gengrid_realized_items_update(RealHandle);
        }

        public void Clear()
        {
            Interop.Elementary.elm_gengrid_clear(RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_gengrid_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        void InitializeSmartEvent()
        {
            _selected = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "selected", GenGridItemEventArgs.CreateFromSmartEvent);
            _unselected = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "unselected", GenGridItemEventArgs.CreateFromSmartEvent);
            _activated = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "activated", GenGridItemEventArgs.CreateFromSmartEvent);
            _pressed = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "pressed", GenGridItemEventArgs.CreateFromSmartEvent);
            _released = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "released", GenGridItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "clicked,double", GenGridItemEventArgs.CreateFromSmartEvent);
            _realized = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "realized", GenGridItemEventArgs.CreateFromSmartEvent);
            _unrealized = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "unrealized", GenGridItemEventArgs.CreateFromSmartEvent);
            _longpressed = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "longpressed", GenGridItemEventArgs.CreateFromSmartEvent);

            _selected.On += (s, e) => { if (e.Item != null) ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { if (e.Item != null) ItemUnselected?.Invoke(this, e); };
            _activated.On += (s, e) => { if (e.Item != null) ItemActivated?.Invoke(this, e); };
            _pressed.On += (s, e) => { if (e.Item != null) ItemPressed?.Invoke(this, e); };
            _released.On += (s, e) => { if (e.Item != null) ItemReleased?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { if (e.Item != null) ItemDoubleClicked?.Invoke(this, e); };
            _realized.On += (s, e) => { if (e.Item != null) ItemRealized?.Invoke(this, e); };
            _unrealized.On += (s, e) => { if (e.Item != null) ItemUnrealized?.Invoke(this, e); };
            _longpressed.On += (s, e) => { if (e.Item != null) ItemLongPressed?.Invoke(this, e); };
        }

        void AddInternal(GenGridItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((GenGridItem)sender);
        }
    }
}
