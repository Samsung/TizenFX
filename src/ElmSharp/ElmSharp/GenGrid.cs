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
                Interop.Elementary.elm_gengrid_align_get(Handle, out align, IntPtr.Zero);
                return align;
            }
            set
            {
                double aligny = ItemAlignmentY;
                Interop.Elementary.elm_gengrid_align_set(Handle, value, aligny);
            }
        }

        public double ItemAlignmentY
        {
            get
            {
                double align;
                Interop.Elementary.elm_gengrid_align_get(Handle, IntPtr.Zero, out align);
                return align;
            }
            set
            {
                double alignx = ItemAlignmentX;
                Interop.Elementary.elm_gengrid_align_set(Handle, alignx, value);
            }
        }

        public bool FillItems
        {
            get
            {
                return Interop.Elementary.elm_gengrid_filled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_filled_set(Handle, value);
            }
        }

        public bool MultipleSelection
        {
            get
            {
                return Interop.Elementary.elm_gengrid_multi_select_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_multi_select_set(Handle, value);
            }
        }

        public int ItemWidth
        {
            get
            {
                int width;
                Interop.Elementary.elm_gengrid_item_size_get(Handle, out width, IntPtr.Zero);
                return width;
            }
            set
            {
                int height = ItemHeight;
                Interop.Elementary.elm_gengrid_item_size_set(Handle, value, height);

            }
        }

        public int ItemHeight
        {
            get
            {
                int height;
                Interop.Elementary.elm_gengrid_item_size_get(Handle, IntPtr.Zero, out height);
                return height;
            }
            set
            {
                int width = ItemWidth;
                Interop.Elementary.elm_gengrid_item_size_set(Handle, width, value);
            }
        }

        public GenGridSelectionMode SelectionMode
        {
            get
            {
                return (GenGridSelectionMode)Interop.Elementary.elm_gengrid_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_select_mode_set(Handle, (int)value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_gengrid_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_horizontal_set(Handle, value);
            }
        }

        public bool IsHighlight
        {
            get
            {
                return Interop.Elementary.elm_gengrid_highlight_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_highlight_mode_set(Handle, value);
            }
        }

        public GenGridItem Append(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_append(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem Prepend(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_prepend(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem InsertBefore(GenItemClass itemClass, object data, GenGridItem before)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_before(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, before, null, (IntPtr)item.Id);
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
            Interop.Elementary.elm_gengrid_realized_items_update(Handle);
        }

        public void Clear()
        {
            Interop.Elementary.elm_gengrid_clear(Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_gengrid_add(parent);
        }

        void InitializeSmartEvent()
        {
            _selected = new SmartEvent<GenGridItemEventArgs>(this, "selected", GenGridItemEventArgs.CreateFromSmartEvent);
            _unselected = new SmartEvent<GenGridItemEventArgs>(this, "unselected", GenGridItemEventArgs.CreateFromSmartEvent);
            _activated = new SmartEvent<GenGridItemEventArgs>(this,"activated", GenGridItemEventArgs.CreateFromSmartEvent);
            _pressed = new SmartEvent<GenGridItemEventArgs>(this, "pressed", GenGridItemEventArgs.CreateFromSmartEvent);
            _released = new SmartEvent<GenGridItemEventArgs>(this, "released", GenGridItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new SmartEvent<GenGridItemEventArgs>(this, "clicked,double", GenGridItemEventArgs.CreateFromSmartEvent);
            _realized = new SmartEvent<GenGridItemEventArgs>(this, "realized", GenGridItemEventArgs.CreateFromSmartEvent);
            _unrealized = new SmartEvent<GenGridItemEventArgs>(this, "unrealized", GenGridItemEventArgs.CreateFromSmartEvent);
            _longpressed = new SmartEvent<GenGridItemEventArgs>(this, "longpressed", GenGridItemEventArgs.CreateFromSmartEvent);

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
