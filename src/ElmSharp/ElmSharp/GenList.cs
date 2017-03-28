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
    public enum GenListItemType
    {
        Normal = 0,
        Tree = (1 << 0),
        Group = (1 << 1),
    }

    public enum GenListMode
    {
        Compress = 0,
        Scroll,
        Limit,
        Expand
    }

    public class GenListItemEventArgs : EventArgs
    {
        public GenListItem Item { get; set; }

        internal static GenListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenListItem item = ItemObject.GetItemByHandle(info) as GenListItem;
            return new GenListItemEventArgs() { Item = item };
        }
    }

    public enum ScrollToPosition
    {
        None = 0,   // Scrolls to nowhere
        In = (1 << 0),   // Scrolls to the nearest viewport
        Top = (1 << 1),   // Scrolls to the top of the viewport
        Middle = (1 << 2),   // Scrolls to the middle of the viewport
        Bottom = (1 << 3)   // Scrolls to the bottom of the viewport
    }

    public class GenList : Layout
    {
        HashSet<GenListItem> _children = new HashSet<GenListItem>();

        SmartEvent<GenListItemEventArgs> _selected;
        SmartEvent<GenListItemEventArgs> _unselected;
        SmartEvent<GenListItemEventArgs> _activated;
        SmartEvent<GenListItemEventArgs> _pressed;
        SmartEvent<GenListItemEventArgs> _released;
        SmartEvent<GenListItemEventArgs> _doubleClicked;
        SmartEvent<GenListItemEventArgs> _expanded;
        SmartEvent<GenListItemEventArgs> _realized;
        SmartEvent<GenListItemEventArgs> _unrealized;
        SmartEvent<GenListItemEventArgs> _longpressed;
        SmartEvent<GenListItemEventArgs> _moved;
        SmartEvent<GenListItemEventArgs> _movedAfter;
        SmartEvent<GenListItemEventArgs> _movedBefore;
        SmartEvent _scrollAnimationStarted;
        SmartEvent _scrollAnimationStopped;
        SmartEvent _changed;

        public GenList(EvasObject parent) : base(parent)
        {
            ListMode = GenListMode.Compress;
            InitializeSmartEvent();
        }

        public bool Homogeneous
        {
            get
            {
                return Interop.Elementary.elm_genlist_homogeneous_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_homogeneous_set(RealHandle, value);
            }
        }

        public GenListMode ListMode
        {
            get
            {
                return (GenListMode)Interop.Elementary.elm_genlist_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_mode_set(RealHandle, (int)value);
            }
        }

        public GenListItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_genlist_first_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenListItem;
            }
        }

        public GenListItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_genlist_last_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenListItem;
            }
        }

        public bool ReorderMode
        {
            get
            {
                return Interop.Elementary.elm_genlist_reorder_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_reorder_mode_set(RealHandle, value);
            }
        }

        public event EventHandler<GenListItemEventArgs> ItemSelected;
        public event EventHandler<GenListItemEventArgs> ItemUnselected;
        public event EventHandler<GenListItemEventArgs> ItemPressed;
        public event EventHandler<GenListItemEventArgs> ItemReleased;
        public event EventHandler<GenListItemEventArgs> ItemActivated;
        public event EventHandler<GenListItemEventArgs> ItemDoubleClicked;
        public event EventHandler<GenListItemEventArgs> ItemExpanded;
        public event EventHandler<GenListItemEventArgs> ItemRealized;
        public event EventHandler<GenListItemEventArgs> ItemUnrealized;
        public event EventHandler<GenListItemEventArgs> ItemLongPressed;
        public event EventHandler<GenListItemEventArgs> ItemMoved;
        public event EventHandler<GenListItemEventArgs> ItemMovedAfter;
        public event EventHandler<GenListItemEventArgs> ItemMovedBefore;

        public event EventHandler Changed
        {
            add { _changed.On += value; }
            remove { _changed.On -= value; }
        }

        public event EventHandler ScrollAnimationStarted
        {
            add { _scrollAnimationStarted.On += value; }
            remove { _scrollAnimationStarted.On -= value; }
        }

        public event EventHandler ScrollAnimationStopped
        {
            add { _scrollAnimationStopped.On += value; }
            remove { _scrollAnimationStopped.On -= value; }
        }

        public GenListItem Append(GenItemClass itemClass, object data)
        {
            return Append(itemClass, data, GenListItemType.Normal);
        }

        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Append(itemClass, data, type, null);
        }

        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_genlist_item_append(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenListItem Prepend(GenItemClass itemClass, object data)
        {
            return Prepend(itemClass, data, GenListItemType.Normal);
        }

        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Prepend(itemClass, data, type, null);
        }

        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_genlist_item_prepend(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before)
        {
            return InsertBefore(itemClass, data, before, GenListItemType.Normal);
        }
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type)
        {
            return InsertBefore(itemClass, data, before, type, null);
        }
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            // insert before the `before` list item
            IntPtr handle = Interop.Elementary.elm_genlist_item_insert_before(
                RealHandle, // genlist handle
                itemClass.UnmanagedPtr, // item class
                (IntPtr)item.Id, // data
                parent, // parent
                before, // before
                (int)type, // item type
                null, // select callback
                (IntPtr)item.Id); // callback data
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public void ScrollTo(GenListItem item, ScrollToPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_genlist_item_bring_in(item.Handle, (Interop.Elementary.Elm_Genlist_Item_Scrollto_Type)position);
            }
            else
            {
                Interop.Elementary.elm_genlist_item_show(item.Handle, (Interop.Elementary.Elm_Genlist_Item_Scrollto_Type)position);
            }
        }

        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_genlist_realized_items_update(RealHandle);
        }

        public void Clear()
        {
            Interop.Elementary.elm_genlist_clear(RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_genlist_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        void InitializeSmartEvent()
        {
            _selected = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "selected", GenListItemEventArgs.CreateFromSmartEvent);
            _unselected = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "unselected", GenListItemEventArgs.CreateFromSmartEvent);
            _activated = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "activated", GenListItemEventArgs.CreateFromSmartEvent);
            _pressed = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "pressed", GenListItemEventArgs.CreateFromSmartEvent);
            _released = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "released", GenListItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "clicked,double", GenListItemEventArgs.CreateFromSmartEvent);
            _expanded = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "expanded", GenListItemEventArgs.CreateFromSmartEvent);
            _realized = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "realized", GenListItemEventArgs.CreateFromSmartEvent);
            _unrealized = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "unrealized", GenListItemEventArgs.CreateFromSmartEvent);
            _longpressed = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "longpressed", GenListItemEventArgs.CreateFromSmartEvent);
            _moved = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "moved", GenListItemEventArgs.CreateFromSmartEvent);
            _movedAfter = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "moved,after", GenListItemEventArgs.CreateFromSmartEvent);
            _movedBefore = new SmartEvent<GenListItemEventArgs>(this, this.RealHandle, "moved,before", GenListItemEventArgs.CreateFromSmartEvent);
            _scrollAnimationStarted = new SmartEvent(this, this.RealHandle, "scroll,anim,start");
            _scrollAnimationStopped = new SmartEvent(this, this.RealHandle, "scroll,anim,stop");
            _changed = new SmartEvent(this, this.RealHandle, "changed");

            _selected.On += (s, e) => { if (e.Item != null) ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { if (e.Item != null) ItemUnselected?.Invoke(this, e); };
            _activated.On += (s, e) => { if (e.Item != null) ItemActivated?.Invoke(this, e); };
            _pressed.On += (s, e) => { if (e.Item != null) ItemPressed?.Invoke(this, e); };
            _released.On += (s, e) => { if (e.Item != null) ItemReleased?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { if (e.Item != null) ItemDoubleClicked?.Invoke(this, e); };
            _expanded.On += (s, e) => { if (e.Item != null) ItemExpanded?.Invoke(this, e); };
            _realized.On += (s, e) => { if (e.Item != null) ItemRealized?.Invoke(this, e); };
            _unrealized.On += (s, e) => { if (e.Item != null) ItemUnrealized?.Invoke(this, e); };
            _longpressed.On += (s, e) => { if (e.Item != null) ItemLongPressed?.Invoke(this, e); };
            _moved.On += (s, e) => { if (e.Item != null) ItemMoved?.Invoke(this, e); };
            _movedAfter.On += (s, e) => { if (e.Item != null) ItemMovedAfter?.Invoke(this, e); };
            _movedBefore.On += (s, e) => { if (e.Item != null) ItemMovedBefore?.Invoke(this, e); };
        }

        void AddInternal(GenListItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((GenListItem)sender);
        }
    }
}
