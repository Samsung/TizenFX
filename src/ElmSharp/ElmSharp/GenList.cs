/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Enumeration for setting the genlist item types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum GenListItemType
    {
        /// <summary>
        /// If Normal is set, then this item is a normal item.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// If Tree is set, then this item is displayed as an item that is able to expand and have child items.
        /// </summary>
        Tree = (1 << 0),

        /// <summary>
        /// If Group is set, then this item is a group index item that is displayed at the top until the next group comes.
        /// </summary>
        Group = (1 << 1),
    }

    /// <summary>
    /// Enumeration for setting the genlist's resizing behavior, transverse axis scrolling, and items cropping.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum GenListMode
    {
        /// <summary>
        /// The genlist won't set any of its size hints to inform how a possible container should resize it.
        /// Then, if it's not created as a "resize object", it might end up with zeroed dimensions.
        /// The genlist will respect the container's geometry,and if any of its items won't fit into its transverse axis, one won't be able to scroll it in that direction.
        /// </summary>
        Compress = 0,

        /// <summary>
        /// This is the same as Compress, with the exception that if any of its items won't fit into its transverse axis, one will be able to scroll it in that direction.
        /// </summary>
        Scroll,

        /// <summary>
        /// Sets a minimum size hint on the genlist object, so that containers may respect it (and resize itself to fit the child properly).
        /// More specifically, a minimum size hint will be set for its transverse axis, so that the largest item in that direction fits well.
        /// This is naturally bound by the genlist object's maximum size hints, set externally.
        /// </summary>
        Limit,

        /// <summary>
        /// Besides setting a minimum size on the transverse axis, just like on Limit, the genlist will set a minimum size on the longitudinal axis, trying to reserve space to all its children to be visible at a time.
        /// This is naturally bound by the genlist object's maximum size hints, set externally.
        /// </summary>
        Expand
    }

    /// <summary>
    /// It inherits System.EventArgs.
    /// It contains an item which is <see cref="GenListItem"/> type.
    /// All events of the GenList contain GenListItemEventArgs as a parameter.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenListItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the genlist item. The return type is <see cref="GenListItem"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Item { get; set; }

        internal static GenListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenListItem item = ItemObject.GetItemByHandle(info) as GenListItem;
            return new GenListItemEventArgs { Item = item };
        }
    }

    /// <summary>
    /// Enumeration for defining where to position the item in the genlist.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ScrollToPosition
    {
        /// <summary>
        /// Scrolls to nowhere.
        /// </summary>
        None = 0,

        /// <summary>
        /// Scrolls to the nearest viewport.
        /// </summary>
        In = (1 << 0),

        /// <summary>
        /// Scrolls to the top of the viewport.
        /// </summary>
        Top = (1 << 1),

        /// <summary>
        /// Scrolls to the middle of the viewport.
        /// </summary>
        Middle = (1 << 2),

        /// <summary>
        /// Scrolls to the bottom of the viewport.
        /// </summary>
        Bottom = (1 << 3)
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The GenList is a widget that aims to have a more expansive list than the simple <see cref="List"/> in ElmSharp that could have more flexible items and allow many more entries while still being fast and low on memory usage.
    /// At the same time it was also made to be able to do tree structures.
    /// But the price to pay is more complex when it comes to usage.
    /// If all you want is a simple list with icons and a single text, use <see cref="List"/> widget.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Creates and initializes a new instance of the GenList class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by GenList as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public GenList(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the GenList class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected GenList()
        {
        }

        /// <summary>
        /// Gets or sets whether the homogeneous mode is enabled.
        /// </summary>
        /// <remarks>
        /// If true, the genlist items will have the same height and width.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the horizontal stretching mode. This mode used for sizing items horizontally.
        /// The default value is <see cref="GenListMode.Scroll"/>, which means that if the items are too wide to fit, the scroller scrolls horizontally.
        /// If set to <see cref="GenListMode.Compress"/>, means that the item width is fixed (restricted to a minimum) to the list width when calculating its size in order to allow the height to be calculated based on it.
        /// If set to <see cref="GenListMode.Limit"/>, means that items are expanded to the viewport width and limited to that size.
        /// If set to <see cref="GenListMode.Expand"/>, means that genlist try to reserve space to all its items to be visible at a time.
        /// </summary>
        /// <remarks>
        /// Compress makes the genlist resize slower, as it recalculates every item height again whenever the list width changes.
        /// The homogeneous mode is so that all items in the genlist are of the same width/height. With Compress, the genlist items are initialized fast.
        /// However, there are no subobjects in the genlist, which can be on the flying resizable (such as TEXTBLOCK).
        /// If so, then some dynamic resizable objects in the genlist would not be diplayed properly.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets the first item in the genlist.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenListItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_genlist_first_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenListItem;
            }
        }

        /// <summary>
        /// Gets the last item in the genlist.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenListItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_genlist_last_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenListItem;
            }
        }

        /// <summary>
        /// Gets or sets the reorder mode.
        /// After turning on the reorder mode, longpress on a normal item triggers reordering of the item.
        /// You can move the item up and down. However, reordering does not work with group items.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the maximum number of items within an item block.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int BlockCount
        {
            get
            {
                return Interop.Elementary.elm_genlist_block_count_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_block_count_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets whether the genlist items should be highlighted when an item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsHighlight
        {
            get
            {
                return Interop.Elementary.elm_genlist_highlight_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_highlight_mode_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the timeout in seconds for the longpress event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double LongPressTimeout
        {
            get
            {
                return Interop.Elementary.elm_genlist_longpress_timeout_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_longpress_timeout_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the focus upon the items selection mode.
        /// </summary>
        /// <remarks>
        /// When enabled, every selection of an item inside <see cref="GenList"/> will automatically set focus to its first focusable widget from the left.
        /// This is true of course, if the selection was made by clicking an unfocusable area in an item or selecting it with a key movement.
        /// Clicking on a focusable widget inside an item will couse this particular item to get focus as usual.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool FocusOnSelection
        {
            get
            {
                return Interop.Elementary.elm_genlist_focus_on_selection_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_focus_on_selection_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets whether to enable multi-selection in the genlist.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsMultiSelection
        {
            get
            {
                return Interop.Elementary.elm_genlist_multi_select_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_multi_select_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the selected item in a given GenList widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenListItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_genlist_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenListItem;
            }
        }

        /// <summary>
        /// Gets or sets the genlist select mode by <see cref="GenItemSelectionMode"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenItemSelectionMode SelectionMode
        {
            get
            {
                return (GenItemSelectionMode)Interop.Elementary.elm_genlist_select_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_genlist_select_mode_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Gets the count of items in a this genlist widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Count
        {
            get
            {
                return Interop.Elementary.elm_genlist_items_count(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy.
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get
            {
                Interop.Elementary.elm_scroller_policy_get(RealHandle, out int policy, IntPtr.Zero);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy v = VerticalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(RealHandle, (int)value, (int)v);
            }
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy.
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                Interop.Elementary.elm_scroller_policy_get(RealHandle, IntPtr.Zero, out int policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(RealHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// ItemSelected is raised when a new genlist item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemUnselected is raised when the genlist item is unselected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemUnselected;

        /// <summary>
        /// ItemPressed is raised when a new genlist item is pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemPressed;

        /// <summary>
        /// ItemReleased is raised when a new genlist item is released.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemReleased;

        /// <summary>
        /// ItemActivated is raised when a new genlist item is double-clicked or pressed (enter|return|spacebar).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemActivated;

        /// <summary>
        /// ItemDoubleClicked is raised when a new genlist item is double-clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemDoubleClicked;

        /// <summary>
        /// ItemExpanded is raised when a new genlist item is indicated to expand.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemExpanded;

        /// <summary>
        /// ItemRealized is raised when a new genlist item is created as a real object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemRealized;

        /// <summary>
        /// ItemUnrealized is raised when a new genlist item is unrealized.
        /// After calling unrealize, the item's content objects are deleted, and the item object itself is deleted or is put into a floating cache.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemUnrealized;

        /// <summary>
        /// ItemLongPressed is raised when a genlist item is pressed for a certain amount of time. By default, it's 1 second.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemLongPressed;

        /// <summary>
        /// ItemMoved is raised when a genlist item is moved in the reorder mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemMoved;

        /// <summary>
        /// ItemMovedAfter is raised when a genlist item is moved after another item in the reorder mode.
        /// To get the relative previous item, use <see cref="GenListItem.Previous"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemMovedAfter;

        /// <summary>
        /// ItemMovedBefore is raised when a genlist item is moved before another item in the reorder mode.
        /// To get the relative next item, use <see cref="GenListItem.Next"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenListItemEventArgs> ItemMovedBefore;

        /// <summary>
        /// Changed is raised when the genlist has changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Changed
        {
            add { _changed.On += value; }
            remove { _changed.On -= value; }
        }

        /// <summary>
        /// ScrollAnimationStarted is raised when the scrolling animation has started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ScrollAnimationStarted
        {
            add { _scrollAnimationStarted.On += value; }
            remove { _scrollAnimationStarted.On -= value; }
        }

        /// <summary>
        /// ScrollAnimationStopped is raised when the scrolling animation has stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ScrollAnimationStopped
        {
            add { _scrollAnimationStopped.On += value; }
            remove { _scrollAnimationStopped.On -= value; }
        }

        /// <summary>
        /// Appends a new item to the end of a given GenList widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a newly added genlist item that contains the data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenListItem"/>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Append(GenItemClass itemClass, object data)
        {
            return Append(itemClass, data, GenListItemType.Normal);
        }

        /// <summary>
        /// Appends a new item with <see cref="GenListItemType"/> to the end of a given GenList widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="type">The genlist item type.</param>
        /// <returns>Return a newly added genlist item that contains the data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Append(itemClass, data, type, null);
        }

        /// <summary>
        /// Appends a new item with <see cref="GenListItemType"/> to the end of a given GenList widget or the end of the children list, if the parent is given.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="type">The genlist item type.</param>
        /// <param name="parent">The parent item, otherwise null if there is no parent item.</param>
        /// <returns>Return a newly added genlist item that contains the data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(this, data, itemClass);
            item.Handle = Interop.Elementary.elm_genlist_item_append(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Prepends a new item to the beginning of a given GenList widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Prepend(GenItemClass itemClass, object data)
        {
            return Prepend(itemClass, data, GenListItemType.Normal);
        }

        /// <summary>
        /// Prepends a new item with <see cref="GenListItemType"/> to the beginning of a given genlist widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="type">The genlist item type.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Prepend(itemClass, data, type, null);
        }

        /// <summary>
        /// Prepends a new item with <see cref="GenListItemType"/> to the beginning of a given GenList widget or the beginning of the children list, if the parent is given.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="type">The genlist item type.</param>
        /// <param name="parent">The parent item, otherwise null if there is no parent item.</param>
        /// <returns>Return a newly added genlist item that contains the data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(this, data, itemClass);
            item.Handle = Interop.Elementary.elm_genlist_item_prepend(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item before another item in a genlist widget.
        /// It is the same tree level or group as the item before which it is inserted.????
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="before">The item before which to place this new one.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before)
        {
            return InsertBefore(itemClass, data, before, GenListItemType.Normal);
        }

        /// <summary>
        /// Inserts an item with <see cref="GenListItemType"/> before another item in a GenList widget.
        /// It is the same tree level or group as the item before which it is inserted.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="before">The item before which to place this new one.</param>
        /// <param name="type">The genlist item type.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type)
        {
            return InsertBefore(itemClass, data, before, type, null);
        }

        /// <summary>
        /// Inserts an item with <see cref="GenListItemType"/> before another item under a parent in a GenList widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="before">The item before which to place this new one.</param>
        /// <param name="type">The genlist item type.</param>
        /// <param name="parent">The parent item, otherwise null if there is no parent item.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(this, data, itemClass);
            // insert before the `before` list item
            item.Handle = Interop.Elementary.elm_genlist_item_insert_before(
                RealHandle, // genlist handle
                itemClass.UnmanagedPtr, // item class
                (IntPtr)item.Id, // data
                parent, // parent
                before, // before
                (int)type, // item type
                null, // select callback
                (IntPtr)item.Id); // callback data
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item with <see cref="GenListItemType"/> after another item under a parent in a GenList widget.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="after">The item after which to place this new one.</param>
        /// <param name="type">The genlist item type.</param>
        /// <param name="parent">The parent item, otherwise null if there is no parent item.</param>
        /// <returns>Return a newly added genlist item that contains data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem InsertAfter(GenItemClass itemClass, object data, GenListItem after, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(this, data, itemClass);
            // insert before the `before` list item
            item.Handle = Interop.Elementary.elm_genlist_item_insert_before(
                RealHandle, // genlist handle
                itemClass.UnmanagedPtr, // item class
                (IntPtr)item.Id, // data
                parent, // parent
                after, // after
                (int)type, // item type
                null, // select callback
                (IntPtr)item.Id); // callback data
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item in a GenList widget using a user-defined sort function.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="comparison">User-defined comparison function that defines the sort order based on the genlist item and its data.</param>
        /// <param name="type">The genlist item type.</param>
        /// <param name="parent">The parent item, otherwise null if there is no parent item.</param>
        /// <returns>Return a genlist item that contains the data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem InsertSorted(GenItemClass itemClass, object data, Comparison<object> comparison, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(this, data, itemClass);

            Interop.Elementary.Eina_Compare_Cb compareCallback = (handle1, handle2) =>
            {
                GenListItem first = (ItemObject.GetItemByHandle(handle1) as GenListItem) ?? item;
                GenListItem second = (ItemObject.GetItemByHandle(handle2) as GenListItem) ?? item;
                return comparison(first.Data, second.Data);
            };

            item.Handle = Interop.Elementary.elm_genlist_item_sorted_insert(
                RealHandle, // genlist handle
                itemClass.UnmanagedPtr, // item clas
                (IntPtr)item.Id, // data
                parent, // parent
                (int)type, // item type
                compareCallback, // compare callback
                null, //select callback
                (IntPtr)item.Id); // callback data
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Shows the given item with the position type in a genlist.
        /// When animated is true, the genlist will jump to the given item and display it (by animatedly scrolling), if it is not fully visible. This may use animation and take sometime.
        /// When animated is false, the genlist will jump to the given item and display it (by jumping to that position), if it is not fully visible.
        /// </summary>
        /// <param name="item">The item to display.</param>
        /// <param name="position">The position to show the given item to <see cref="ScrollToPosition"/>.</param>
        /// <param name="animated">The animated indicates how to display the item, by scrolling or by jumping.</param>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Updates the content of all the realized items.
        /// This updates all the realized items by calling all <see cref="GenItemClass"/> again to get the content, text, and states.
        /// Use this when the original item data has changed and the changes are desired to reflect.
        /// To update just one item, use <see cref="GenListItem.Update"/>.
        /// </summary>
        /// <seealso cref="GenListItem.Update"/>
        /// <since_tizen> preview </since_tizen>
        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_genlist_realized_items_update(RealHandle);
        }

        /// <summary>
        /// Removes all the items from a given genlist widget.
        /// This removes (and deletes) all items in the object, making it empty.
        /// To delete just one item, use <see cref="ItemObject.Delete"/>.
        /// </summary>
        /// <seealso cref="ItemObject.Delete"/>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_genlist_clear(RealHandle);
        }

        /// <summary>
        /// Gets the item that is at the X, Y canvas coordinates.
        /// </summary>
        /// <param name="x">The input X-coordinate.</param>
        /// <param name="y">The input Y-coordinate.</param>
        /// <param name="pos">The position relative to the item returned here.
        ///  -1, 0, or 1 depending on whether the coordinate is on the upper portion of that item (-1), in the middle section (0), or on the lower part (1).
        /// </param>
        /// <returns>The item at the given coordinates.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem GetItemByPosition(int x, int y, out int pos)
        {
            IntPtr handle = Interop.Elementary.elm_genlist_at_xy_item_get(RealHandle, x, y, out pos);
            return ItemObject.GetItemByHandle(handle) as GenListItem;
        }

        /// <summary>
        /// Gets the nth item in a given genlist widget, placed at position nth, in its internal items list.
        /// </summary>
        /// <param name="index">The number of the item to grab (0 being the first).</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public GenListItem GetItemByIndex(int index)
        {
            IntPtr handle = Interop.Elementary.elm_genlist_nth_item_get(RealHandle, index);
            return ItemObject.GetItemByHandle(handle) as GenListItem;
        }

        /// <summary>
        /// The callback of the Unrealized event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            ListMode = GenListMode.Compress;
            InitializeSmartEvent();
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
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