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
    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The MultiButtonEntry is a widget, that lets a user enter text and each chunk of the text managed as a set of buttons.
    /// Each text button is inserted by pressing the "return" key. If there is no space in the current row, a new button is added to the next row.
    /// When a text button is pressed, it will become focused. Backspace removes the focus. When the multi-button entry loses focus, items longer than one line are shrunk to one line.
    /// The typical use case of multi-button entry is composing emails/messages to a group of addresses, each of which is an item that can be clicked for further actions.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class MultiButtonEntry : Layout
    {
        HashSet<MultiButtonEntryItem> _children = new HashSet<MultiButtonEntryItem>();
        List<Func<string, bool>> _filters = new List<Func<string, bool>>();
        Func<int, string> _formatFunc = null;
        Entry _entry = null;

        Interop.Elementary.MultiButtonEntryItemFilterCallback _filterCallback;
        Interop.Elementary.MultiButtonEntryFormatCallback _formatCallback;

        SmartEvent _clicked;
        SmartEvent _expanded;
        SmartEvent _contracted;
        SmartEvent _expandedStateChanged;
        SmartEvent<MultiButtonEntryItemEventArgs> _itemSelected;
        SmartEvent<MultiButtonEntryItemEventArgs> _itemClicked;
        SmartEvent<MultiButtonEntryItemEventArgs> _itemLongPressed;
        SmartEvent<MultiButtonEntryItemEventArgs> _itemAdded;

        /// <summary>
        /// Creates and initializes a new instance of the MultiButtonEntry class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the MultiButtonEntry as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntry(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, "clicked");
            _expanded = new SmartEvent(this, "expanded");
            _contracted = new SmartEvent(this, "contracted");
            _expandedStateChanged = new SmartEvent(this, "expand,state,changed");

            _itemSelected = new SmartEvent<MultiButtonEntryItemEventArgs>(this, "item,selected", MultiButtonEntryItemEventArgs.CreateFromSmartEvent);
            _itemClicked = new SmartEvent<MultiButtonEntryItemEventArgs>(this, "item,clicked", MultiButtonEntryItemEventArgs.CreateFromSmartEvent);
            _itemLongPressed = new SmartEvent<MultiButtonEntryItemEventArgs>(this, "item,longpressed", MultiButtonEntryItemEventArgs.CreateFromSmartEvent);
            _itemAdded = new SmartEvent<MultiButtonEntryItemEventArgs>(this, "item,added", MultiButtonEntryItemEventArgs.CreateAndAddFromSmartEvent);

            _filterCallback = new Interop.Elementary.MultiButtonEntryItemFilterCallback(FilterCallbackHandler);
            _formatCallback = new Interop.Elementary.MultiButtonEntryFormatCallback(FormatCallbackHandler);

            _clicked.On += (sender, e) => Clicked?.Invoke(this, EventArgs.Empty);
            _expanded.On += (sender, e) => Expanded?.Invoke(this, EventArgs.Empty);
            _contracted.On += (sender, e) => Contracted?.Invoke(this, EventArgs.Empty);
            _expandedStateChanged.On += (sender, e) => ExpandedStateChanged?.Invoke(this, EventArgs.Empty);

            _itemSelected.On += (sender, e) => { ItemSelected?.Invoke(this, e); };
            _itemClicked.On += (sender, e) => { ItemClicked?.Invoke(this, e); };
            _itemLongPressed.On += (sender, e) => { ItemLongPressed?.Invoke(this, e); };
            _itemAdded.On += OnItemAdded;
        }

        /// <summary>
        /// Clicked is raised when a MultiButtonEntry is clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Clicked;

        /// <summary>
        /// Expanded is raised when a MultiButtonEntry is expanded.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Expanded;

        /// <summary>
        /// Contracted is raised when a MultiButtonEntry is contracted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Contracted;

        /// <summary>
        /// ExpandedStateChanged is raised when shrink mode state of MultiButtonEntry is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ExpandedStateChanged;

        /// <summary>
        /// ItemSelected is raised when an item is selected by API, user interaction, and etc.
        /// This is also raised when a user presses backspace, while the cursor is on the first field of the entry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MultiButtonEntryItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemClicked is raised when an item is clicked by user interaction.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MultiButtonEntryItemEventArgs> ItemClicked;

        /// <summary>
        /// ItemLongPressed is raised when MultiButtonEntry item is pressed for a long time.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MultiButtonEntryItemEventArgs> ItemLongPressed;

        /// <summary>
        /// ItemAdded is raised when a new MultiButtonEntry item is added.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MultiButtonEntryItemEventArgs> ItemAdded;

        /// <summary>
        /// ItemDeleted is raised when a MultiButtonEntry item is deleted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MultiButtonEntryItemEventArgs> ItemDeleted;

        /// <summary>
        /// Gets the selected item in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        /// <summary>
        /// Gets or sets whether the MultiButtonEntry is editable or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_multibuttonentry_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_multibuttonentry_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the MultiButtonEntry to expanded state.
        /// If true, expanded state.
        /// If false, single line state.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsExpanded
        {
            get
            {
                return Interop.Elementary.elm_multibuttonentry_expanded_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_multibuttonentry_expanded_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the first item in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_first_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        /// <summary>
        /// Gets the last item in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_multibuttonentry_last_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            }
        }

        /// <summary>
        /// Gets the entry object int the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Entry Entry
        {
            get
            {
                if (_entry == null)
                {
                    _entry = new EntryInner(this);
                }

                return _entry;
            }
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_multibuttonentry_add(parent.Handle);
        }

        /// <summary>
        /// Appends a new item to the multibuttonentry.
        /// </summary>
        /// <param name="label">The label of the new item.</param>
        /// <returns>A MultiButtonEntryItem to the item added.</returns>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem Append(string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_append(RealHandle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        /// <summary>
        /// Prepends a new item to the MultiButtonEntry.
        /// </summary>
        /// <param name="label">The label of the new item.</param>
        /// <returns>A MultiButtonEntryItem to the item added.</returns>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem Prepend(string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_prepend(RealHandle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        /// <summary>
        /// Adds a new item to the MultiButtonEntry before the indicated object reference.
        /// </summary>
        /// <param name="before">The item before which to add it.</param>
        /// <param name="label">The label of new item.</param>
        /// <returns>A MultiButtonEntryItem to the item added.</returns>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem InsertBefore(MultiButtonEntryItem before, string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_insert_before(RealHandle, before.Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        /// <summary>
        /// Adds a new item to the MultiButtonEntry after the indicated object.
        /// </summary>
        /// <param name="after">The item after which to add it.</param>
        /// <param name="label">The label of new item.</param>
        /// <returns>A MultiButtonEntryItem to the item added.</returns>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem InsertAfter(MultiButtonEntryItem after, string label)
        {
            var handle = Interop.Elementary.elm_multibuttonentry_item_insert_after(RealHandle, after.Handle, label, null, IntPtr.Zero);
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(handle) as MultiButtonEntryItem;
            return item;
        }

        /// <summary>
        /// Removes all items in the MultiButtonEntry.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_multibuttonentry_clear(RealHandle);
            foreach (var item in _children)
            {
                item.Deleted -= Item_Deleted;
            }
            _children.Clear();
        }

        /// <summary>
        /// Appends an item filter function for the text inserted in the multibuttonentry.
        /// </summary>
        /// <param name="func">The function to use as item filter.</param>
        /// <since_tizen> preview </since_tizen>
        public void AppendFilter(Func<string, bool> func)
        {
            _filters.Add(func);
            if (_filters.Count == 1)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_append(RealHandle, _filterCallback, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Prepends a filter function for the text inserted in the MultiButtonEntry.
        /// </summary>
        /// <param name="func">The function to use as text filter.</param>
        /// <since_tizen> preview </since_tizen>
        public void PrependFilter(Func<string, bool> func)
        {
            _filters.Insert(0, func);
            if (_filters.Count == 1)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_prepend(RealHandle, _filterCallback, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Removes a filter from the list.
        /// </summary>
        /// <param name="func">The filter function to remove.</param>
        /// <since_tizen> preview </since_tizen>
        public void RemoveFilter(Func<string, bool> func)
        {
            _filters.Remove(func);
            if (_filters.Count == 0)
            {
                Interop.Elementary.elm_multibuttonentry_item_filter_remove(RealHandle, _filterCallback, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Sets a function to format the string that will be used to display the hidden items counter.
        /// If func is NULL, the default format will be used, which is "+ 'the hidden items counter'".
        /// </summary>
        /// <param name="func">The function to return string to show.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFormatCallback(Func<int, string> func)
        {
            if (func == null)
            {
                Interop.Elementary.elm_multibuttonentry_format_function_set(RealHandle, null, IntPtr.Zero);
            }
            else
            {
                _formatFunc = func;
                Interop.Elementary.elm_multibuttonentry_format_function_set(RealHandle, _formatCallback, IntPtr.Zero);
            }
        }

        string FormatCallbackHandler(int count, IntPtr data)
        {
            return _formatFunc(count);
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            var removed = sender as MultiButtonEntryItem;
            _children.Remove(removed);

            // "item,deleted" event will be called after removing the item from ItemObject has been done.
            // ItemObject will no longer have the item instance that is deleted after this.
            // So, ItemDelete event with the removed item should be triggered here.
            ItemDeleted?.Invoke(this, new MultiButtonEntryItemEventArgs { Item = removed });
        }

        void OnItemAdded(object sender, MultiButtonEntryItemEventArgs e)
        {
            e.Item.Parent = this;
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

        internal class EntryInner : Entry
        {
            /// <summary>
            /// Creates and initializes a new instance of the EntryInner class.
            /// </summary>
            /// <param name="parent">The parent is a given container, which will be attached by the MultiButtonEntry as a child. It's <see cref="EvasObject"/> type.</param>
            internal EntryInner(EvasObject parent) : base(parent)
            {
            }

            /// <summary>
            /// Creates a widget handle.
            /// </summary>
            /// <param name="parent">Parent EvasObject.</param>
            /// <returns>Handle IntPtr.</returns>
            protected override IntPtr CreateHandle(EvasObject parent)
            {
                return Interop.Elementary.elm_multibuttonentry_entry_get(parent.Handle);
            }
        }
    }

    /// <summary>
    /// It inherits System.EventArgs.
    /// The MultiButtonEntryItemEventArgs is a argument for all events of MultiButtonEntry.
    /// It contains the Item which is <see cref="MultiButtonEntryItem"/> type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class MultiButtonEntryItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the MultiButtonEntryItem item. The return type is <see cref="MultiButtonEntryItem"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MultiButtonEntryItem Item { get; set; }

        internal static MultiButtonEntryItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            MultiButtonEntryItem item = ItemObject.GetItemByHandle(info) as MultiButtonEntryItem;
            return new MultiButtonEntryItemEventArgs { Item = item };
        }

        internal static MultiButtonEntryItemEventArgs CreateAndAddFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            // Item can be added throught calling Append method and user input.
            // And since "item.added" event will be called before xx_append() method returns,
            // ItemObject does NOT have an item that contains handle matched to "info" at this time.
            // So, item should be created and added internally here.
            
            MultiButtonEntryItem item = new MultiButtonEntryItem(null, info);
            return new MultiButtonEntryItemEventArgs { Item = item };
        }
    }
}