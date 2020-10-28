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
    /// It inherits System.EventArgs.
    /// It contains the item which is the <see cref="GenGridItem"/> type.
    /// All events of the GenGrid contain GenGridItemEventArgs as a parameter.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenGridItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the gengrid item. The return type is <see cref="GenGridItem"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem Item { get; set; }

        internal static GenGridItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenGridItem item = ItemObject.GetItemByHandle(info) as GenGridItem;
            return new GenGridItemEventArgs { Item = item };
        }
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The GenGrid is a widget that aims to position objects in a grid layout, while actually creating and rendering only the visible ones.
    /// It has two directions in which a given GenGrid widget expands while placing its items, horizontal and vertical.
    /// The gengrid items are represented through the <see cref="GenItemClass"/> definition field details.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
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
        SmartEvent<GenGridItemEventArgs> _focused;
        SmartEvent<GenGridItemEventArgs> _unfocused;
        SmartEvent _changed;

        /// <summary>
        /// Creates and initializes a new instance of the GenGrid class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by GenGrid as a child. It's the <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public GenGrid(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        /// <summary>
        /// ItemSelected is raised when a new GenGrid item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemUnselected is raised when the gengrid item is unselected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemUnselected;

        /// <summary>
        /// ItemPressed is raised when a new gengrid item is pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemPressed;

        /// <summary>
        /// ItemReleased is raised when a new gengrid item is released.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemReleased;

        /// <summary>
        /// ItemActivated is raised when a new gengrid item is double-clicked or pressed (enter|return|spacebar).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemActivated;

        /// <summary>
        /// ItemDoubleClicked is raised when a new gengrid item is double-clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemDoubleClicked;

        /// <summary>
        /// ItemRealized is raised when a gengrid item is implemented through <see cref="GenItemClass"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemRealized;

        /// <summary>
        /// ItemUnrealized is raised when the gengrid item is deleted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemUnrealized;

        /// <summary>
        /// ItemLongPressed is raised when a gengrid item is pressed for a certain amount of time. By default it's 1 second.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemLongPressed;

        /// <summary>
        /// ItemFocussed is raised when a gengrid item has received focus.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemFocused;

        /// <summary>
        /// ItemUnfocussed is raised when a gengrid item has lost focus.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<GenGridItemEventArgs> ItemUnfocused;

        /// <summary>
        ///  Changed is raised when an item is added, removed, resized or moved and when the gengrid is resized or gets "horizontal" property changes.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Changed;

        /// <summary>
        /// Gets or sets the item's grid alignment along X-axis within a given GenGrid widget.
        /// Accepted values are in the 0.0 to 1.0 range, with the special value -1.0 used to specify "justify" or "fill" by some users.
        /// By default, value is 0.0, meaning that the gengrid has its items grid placed exactly in the left along X-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the item's grid alignment on Y-axis within a given GenGrid widget.
        /// Accepted values are in the 0.0 to 1.0 range, with the special value -1.0 used to specify "justify" or "fill" by some users.
        /// By default, value is 0.0, meaning that the gengrid has its items grid placed exactly in the top along Y-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the manner in which the items grid is filled within a given GenGrid widget.
        /// It is filled if true, otherwise not filled if false.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets whether multi-selection is enabled or disabled for a given GenGrid widget.
        /// </summary>
        /// <remarks>
        /// Multi-selection is the ability to have more than one item selected, on a given gengrid, simultaneously.
        /// When it is enabled, a sequence of clicks on different items makes them all selected, progressively.
        /// A click on an already selected item unselects it. If interacting via the keyboard, multi-selection is enabled while holding the "Shift" key.
        /// By default, multi-selection is disabled.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the width for the items of a given GenGrid widget.
        /// </summary>
        /// <remarks>
        /// A gengrid, after creation, still has no information on the size to give to each of its cells.
        /// The default width and height just are one finger wide.
        /// Use this property to force a custom width for your items, making them as big as you wish.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the height for the items of a given GenGrid widget.
        /// </summary>
        /// <remarks>
        /// A gengrid, after creation, still has no information on the size to give to each of its cells.
        /// The default width and height just are one finger wide.
        /// Use this property to force a custom height for your items, making them as big as you wish.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the gengrid select mode by <see cref="GenItemSelectionMode"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenItemSelectionMode SelectionMode
        {
            get
            {
                return (GenItemSelectionMode)Interop.Elementary.elm_gengrid_select_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_select_mode_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the direction for which a given GenGrid widget expands while placing its items.
        /// </summary>
        /// <remarks>
        /// If true, items are placed in columns from top to bottom and when the space for a column is filled, another one is started on the right, thus expanding the grid horizontally.
        /// If false, items are placed in rows from left to right, and when the space for a row is filled, another one is started below, thus expanding the grid vertically.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets whether the gengrid items should be highlighted when an item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
                int policy;
                Interop.Elementary.elm_scroller_policy_get(RealHandle, out policy, IntPtr.Zero);
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
                int policy;
                Interop.Elementary.elm_scroller_policy_get(RealHandle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(RealHandle, (int)h, (int)value);
            }
        }

        /// <summary>
        /// Gets the first item in a given GenGrid widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_gengrid_first_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenGridItem;
            }
        }

        /// <summary>
        /// Gets the last item in a given GenGrid widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_gengrid_last_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenGridItem;
            }
        }

        /// <summary>
        /// Gets the items count in a given GenGrid widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public uint ItemCount
        {
            get
            {
                return Interop.Elementary.elm_gengrid_items_count(RealHandle);
            }
        }

        /// <summary>
        /// Gets the selected item in a given GenGrid widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_gengrid_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as GenGridItem;
            }
        }

        /// <summary>
        /// Gets or sets whether a given GenGrid widget is able to or not able to have items reordered.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool ReorderMode
        {
            get
            {
                return Interop.Elementary.elm_gengrid_reorder_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_reorder_mode_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Appends a new item to a given GenGrid widget. This adds an item to the end of the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a gengrid item that contains the data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem Append(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_append(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Prepends a new item to a given GenGrid widget. This adds an item to the beginning of the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a gengrid item that contains the data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem Prepend(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_prepend(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item before another in a GenGrid widget. This inserts an item before another in the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="before">The item before which to place this new one.</param>
        /// <returns>Return a gengrid item that contains the data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem InsertBefore(GenItemClass itemClass, object data, GenGridItem before)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_before(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, before, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item after another in a GenGrid widget. This inserts an item after another in the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="after">The item after which to place this new one.</param>
        /// <returns>Return a gengrid item that contains the data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem InsertAfter(GenItemClass itemClass, object data, GenGridItem after)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_after(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, after, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item in a GenGrid widget using a user-defined sort function.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="comparison">User defined comparison function that defines the sort order based on the gengrid item and its data.</param>
        /// <returns>Return a gengrid item that contains the data and itemClass.</returns>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem InsertSorted(GenItemClass itemClass, object data, Comparison<object> comparison)
        {
            GenGridItem item = new GenGridItem(data, itemClass);

            Interop.Elementary.Eina_Compare_Cb compareCallback = (handle1, handle2) =>
            {
                GenGridItem first = (ItemObject.GetItemByHandle(handle1) as GenGridItem) ?? item;
                GenGridItem second = (ItemObject.GetItemByHandle(handle2) as GenGridItem) ?? item;
                return comparison(first.Data, second.Data);
            };

            IntPtr handle = Interop.Elementary.elm_gengrid_item_sorted_insert(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, compareCallback, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Shows a given item to the visible area of a gengrid.
        /// </summary>
        /// <param name="item">The gengrid item to display.</param>
        /// <param name="position">The position of the item in the viewport.</param>
        /// <param name="animated">The type of how to show the item.</param>
        /// <remarks>
        /// If animated is true, the gengrid shows the item by scrolling if it's not fully visible.
        /// If animated is false, the gengrid shows the item by jumping if it's not fully visible.
        /// </remarks>
        /// <seealso cref="ScrollToPosition"/>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Updates the contents of all the realized items.
        /// This updates all realized items by calling all the <see cref="GenItemClass"/> again to get the content, text, and states.
        /// Use this when the original item data has changed and the changes are desired to reflect.
        /// </summary>
        /// <remarks>
        /// <see cref="GenItem.Update()"/> to update just one item.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_gengrid_realized_items_update(RealHandle);
        }

        /// <summary>
        /// Removes all the items from a given GenGrid widget.
        /// This removes (and deletes) all the items in the object, making it empty.
        /// </summary>
        /// <remarks>
        /// <see cref="ItemObject.Delete()"/> to delete just one item.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_gengrid_clear(RealHandle);
        }

        /// <summary>
        /// Gets the item that is at the X, Y canvas coordinates.
        /// </summary>
        /// <param name="x">The input X coordinate.</param>
        /// <param name="y">The input Y coordinate.</param>
        /// <param name="portionX">The position relative to the item returned here.
        /// -1, 0, or 1, depending if the coordinate is on the left portion of that item(-1), on the middle section(0), or on the right part(1).
        /// </param>
        /// <param name="portionY">The position relative to the item returned here.
        /// -1, 0, or 1, depending if the coordinate is on the upper portion of that item (-1), on the middle section (0), or on the lower part (1).
        /// </param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public GenGridItem GetItemByPosition(int x, int y, out int portionX, out int portionY)
        {
            IntPtr handle = Interop.Elementary.elm_gengrid_at_xy_item_get(RealHandle, x, y, out portionX, out portionY);
            return ItemObject.GetItemByHandle(handle) as GenGridItem;
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
            _focused = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "item,focused", GenGridItemEventArgs.CreateFromSmartEvent);
            _unfocused = new SmartEvent<GenGridItemEventArgs>(this, this.RealHandle, "item,unfocused", GenGridItemEventArgs.CreateFromSmartEvent);
            _changed = new SmartEvent(this, this.RealHandle, "changed");

            _selected.On += (s, e) => { if (e.Item != null) ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { if (e.Item != null) ItemUnselected?.Invoke(this, e); };
            _activated.On += (s, e) => { if (e.Item != null) ItemActivated?.Invoke(this, e); };
            _pressed.On += (s, e) => { if (e.Item != null) ItemPressed?.Invoke(this, e); };
            _released.On += (s, e) => { if (e.Item != null) ItemReleased?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { if (e.Item != null) ItemDoubleClicked?.Invoke(this, e); };
            _realized.On += (s, e) => { if (e.Item != null) ItemRealized?.Invoke(this, e); };
            _unrealized.On += (s, e) => { if (e.Item != null) ItemUnrealized?.Invoke(this, e); };
            _longpressed.On += (s, e) => { if (e.Item != null) ItemLongPressed?.Invoke(this, e); };
            _focused.On += (s, e) => { if (e.Item != null) ItemFocused?.Invoke(this, e); };
            _unfocused.On += (s, e) => { if (e.Item != null) ItemUnfocused?.Invoke(this, e); };
            _changed.On += (s, e) => { Changed?.Invoke(this, e); };
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