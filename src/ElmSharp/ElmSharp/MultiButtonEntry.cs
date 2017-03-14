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
    public class MultiButtonEntry : Layout
    {
        HashSet<MultiButtonEntryItem> _children = new HashSet<MultiButtonEntryItem>();
        List<Func<string, bool>> _filters = new List<Func<string, bool>>();

        Interop.Elementary.MultiButtonEntryItemFilterCallback _filtercallback;

        SmartEvent _clicked;
        SmartEvent _expanded;
        SmartEvent _contracted;
        SmartEvent _expandedStateChanged;
        SmartEvent<MultiButtonEntryArgs> _itemSelected;
        SmartEvent<MultiButtonEntryArgs> _itemClicked;
        SmartEvent<MultiButtonEntryArgs> _itemLongPressed;
        SmartEvent<MultiButtonEntryArgs> _itemAdded;

        public MultiButtonEntry(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, "clicked");
            _expanded = new SmartEvent(this, "expanded");
            _contracted = new SmartEvent(this, "contracted");
            _expandedStateChanged = new SmartEvent(this, "expand,state,changed");

            _itemSelected = new SmartEvent<MultiButtonEntryArgs>(this, "item,selected", MultiButtonEntryArgs.CreateFromSmartEvent);
            _itemClicked = new SmartEvent<MultiButtonEntryArgs>(this, "item,clicked", MultiButtonEntryArgs.CreateFromSmartEvent);
            _itemLongPressed = new SmartEvent<MultiButtonEntryArgs>(this, "item,longpressed", MultiButtonEntryArgs.CreateFromSmartEvent);
            _itemAdded = new SmartEvent<MultiButtonEntryArgs>(this, "item,added", MultiButtonEntryArgs.CreateAndAddFromSmartEvent);

            _filtercallback = new Interop.Elementary.MultiButtonEntryItemFilterCallback(FilterCallbackHandler);

            _clicked.On += (sender, e) => Clicked?.Invoke(this, EventArgs.Empty);
            _expanded.On += (sender, e) => Expanded?.Invoke(this, EventArgs.Empty);
            _contracted.On += (sender, e) => Contracted?.Invoke(this, EventArgs.Empty);
            _expandedStateChanged.On += (sender, e) => ExpandedStateChanged?.Invoke(this, EventArgs.Empty);

            _itemSelected.On += (sender, e) => { ItemSelected?.Invoke(this, e); };
            _itemClicked.On += (sender, e) => { ItemClicked?.Invoke(this, e); };
            _itemLongPressed.On += (sender, e) => { ItemLongPressed?.Invoke(this, e); };
            _itemAdded.On += OnItemAdded;
        }

        public event EventHandler Clicked;

        public event EventHandler Expanded;

        public event EventHandler Contracted;

        public event EventHandler ExpandedStateChanged;

        public event EventHandler<MultiButtonEntryArgs> ItemSelected;

        public event EventHandler<MultiButtonEntryArgs> ItemClicked;

        public event EventHandler<MultiButtonEntryArgs> ItemLongPressed;

        public event EventHandler<MultiButtonEntryArgs> ItemAdded;

        public event EventHandler<MultiButtonEntryArgs> ItemDeleted;

        public MultiButtonEntryItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_selected_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_multibuttonentry_editable_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_multibuttonentry_editable_set(Handle, value);
            }
        }

        public bool IsExpanded
        {
            get
            {
                return Interop.Elementary.elm_multibuttonentry_expanded_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_multibuttonentry_expanded_set(Handle, value);
            }
        }

        public MultiButtonEntryItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_first_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        public MultiButtonEntryItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_last_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_multibuttonentry_add(parent.Handle);
        }

        public MultiButtonEntryItem Append(string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_append(Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        public MultiButtonEntryItem Prepend(string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_prepend(Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        public MultiButtonEntryItem InsertBefore(MultiButtonEntryItem before, string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_insert_before(Handle, before.Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        public MultiButtonEntryItem InsertAfter(MultiButtonEntryItem after, string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_insert_after(Handle, after.Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        public void Clear()
        {
            Interop.Elementary.elm_multibuttonentry_clear(Handle);
            _children.Clear();
        }

        public void AppendFilter(Func<string, bool> func)
        {
            _filters.Add(func);
            if (_filters.Count == 1)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_append(Handle, _filtercallback, IntPtr.Zero);
            }
        }

        public void PrependFilter(Func<string, bool> func)
        {
            _filters.Insert(0, func);
            if (_filters.Count == 1)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_prepend(Handle, _filtercallback, IntPtr.Zero);
            }
        }

        public void RemoveFilter(Func<string, bool> func)
        {
            _filters.Remove(func);
            if (_filters.Count == 0)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_remove(Handle, _filtercallback, IntPtr.Zero);
            }
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            var removed = sender as MultiButtonEntryItem;
            _children.Remove(removed);

            // "item,deleted" event will be called after removing the item from ItemObject has been done.
            // ItemObject will no longer have the item instance that is deleted after this.
            // So, ItemDelete event with the removed item should be triggered here.
            ItemDeleted?.Invoke(this, new MultiButtonEntryArgs() { Item = removed });
        }

        void OnItemAdded(object sender, MultiButtonEntryArgs e)
        {
            _children.Add(e.Item);
            e.Item.Deleted += Item_Deleted;
            ItemAdded?.Invoke(this, e);
        }

        bool FilterCallbackHandler(IntPtr obj, string label, IntPtr itemData, IntPtr data)
        {
            foreach (var func in _filters)
            {
                if (!func(label))
                    return false;
            }
            return true;
        }
    }

    public class MultiButtonEntryArgs : EventArgs
    {
        public MultiButtonEntryItem Item { get; set; }

        internal static MultiButtonEntryArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(info) as MultiButtonEntryItem;
            return new MultiButtonEntryArgs() { Item = item };
        }

        internal static MultiButtonEntryArgs CreateAndAddFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            // Item can be added throught calling Append method and user input.
            // And since "item.added" event will be called before xx_append() method returns,
            // ItemObject does NOT have an item that contains handle matched to "info" at this time.
            // So, item should be created and added internally here.
            MultiButtonEntryItem item = new MultiButtonEntryItem(info);
            return new MultiButtonEntryArgs() { Item = item };
        }
    }
}