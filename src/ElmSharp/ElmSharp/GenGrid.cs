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
    /// Enumeration for setting selection mode for GenGird.
    /// </summary>
    public enum GenGridSelectionMode
    {
        /// <summary>
        /// The item will only call their selection func and callback when first becoming selected.
        /// Any further clicks will do nothing, unless you set Always select mode.
        /// </summary>
        Default = 0,

        /// <summary>
        /// This means that, even if selected, every click will make the selected callbacks be called.
        /// </summary>
        Always,

        /// <summary>
        /// This will turn off the ability to select the item entirely and they will neither appear selected nor call selected callback functions.
        /// </summary>
        None,

        /// <summary>
        /// This will apply no-finger-size rule with DisplayOnly.
        /// No-finger-size rule makes an item can be smaller than lower limit.
        /// Clickable objects should be bigger than human touch point device (your finger) for some touch or small screen devices.
        /// So it is enabled, the item can be shrink than predefined finger-size value. And the item will be updated.
        /// </summary>
        DisplayOnly,
    }

    /// <summary>
    /// It inherits System.EventArgs.
    /// It contains Item which is <see cref="GenGridItem"/> type.
    /// All events of GenGrid contain GenGridItemEventArgs as a parameter.
    /// </summary>
    public class GenGridItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets GenGrid item.The return type is <see cref="GenGridItem"/>.
        /// </summary>
        public GenGridItem Item { get; set; }

        internal static GenGridItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenGridItem item = ItemObject.GetItemByHandle(info) as GenGridItem;
            return new GenGridItemEventArgs() { Item = item };
        }
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The GenGrid is a widget that aims to position objects in a grid layout while actually creating and rendering only the visible ones.
    /// It has two direction in which a given GenGrid widget expands while placing its items, horizontal and vertical.
    /// The GenGrid items are represented through <see cref="GenItemClass"/> definition field details.
    /// </summary>
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
        SmartEvent _changed;

        /// <summary>
        /// Creates and initializes a new instance of the GenGrid class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by GenGrid as a child. It's <see cref="EvasObject"/> type.</param>
        public GenGrid(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        /// <summary>
        /// ItemSelected is raised when a new gengrid item is selected.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemUnselected is raised when the gengrid item is Unselected.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemUnselected;

        /// <summary>
        /// ItemPressed is raised when a new gengrid item is pressed.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemPressed;

        /// <summary>
        /// ItemReleased is raised when a new gengrid item is released.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemReleased;

        /// <summary>
        /// ItemActivated is raised when a new gengrid item is double clicked or pressed (enter|return|spacebar).
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemActivated;

        /// <summary>
        /// ItemDoubleClicked is raised when a new gengrid item is double clicked.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemDoubleClicked;

        /// <summary>
        /// ItemRealized is raised when a gengrid item is implementing through <see cref="GenItemClass"/>.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemRealized;

        /// <summary>
        /// ItemUnrealized is raised when the gengrid item is deleted.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemUnrealized;

        /// <summary>
        /// ItemLongPressed is raised when a gengrid item is pressed for a certain amount of time. By default it's 1 second.
        /// </summary>
        public event EventHandler<GenGridItemEventArgs> ItemLongPressed;

        /// <summary>
        ///  Changed is raised when an item is added, removed, resized or moved and when the gengrid is resized or gets "horizontal" property changes.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Gets or sets the item's grid alignment along x-axis within a given gengrid widget.
        /// The range is less than or equal to 1,and greater than or equal to 0.
        /// By default, value is 0.5, meaning that the gengrid has its items grid placed exactly in the middle along x-axis.
        /// </summary>
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
        /// Gets or sets the item's grid alignment on y-axis within a given gengrid widget.
        /// The range is less than or equal to 1, and greater than or equal to 0.
        /// By default, value is 0.5, meaning that the gengrid has its items grid placed exactly in the middle along y-axis.
        /// </summary>
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
        /// Gets or sets the manner in which the items grid is filled within a given gengrid widget.
        /// It is filled if true, otherwise false.
        /// </summary>
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
        /// Gets or sets whether multi-selection is enabled or disabled for a given gengrid widget.
        /// </summary>
        /// <remarks>
        /// Multi-selection is the ability to have more than one item selected, on a given gengrid, simultaneously.
        /// When it is enabled, a sequence of clicks on different items makes them all selected, progressively.
        /// A click on an already selected item unselects it. If interacting via the keyboard, multi-selection is enabled while holding the "Shift" key.
        /// By default, multi-selection is disabled.
        /// </remarks>
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
        /// Gets or sets the width for the items of a given gengrid widget.
        /// </summary>
        /// <remarks>
        /// A gengrid, after creation, still has no information on the size to give to each of its cells.
        /// The default width and height just have one finger wide.
        /// Use this property to force a custom width for your items, making them as big as you wish.
        /// </remarks>
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
        /// Gets or sets the height for the items of a given gengrid widget.
        /// </summary>
        /// <remarks>
        /// A gengrid, after creation, still has no information on the size to give to each of its cells.
        /// The default width and height just have one finger wide.
        /// Use this property to force a custom height for your items, making them as big as you wish.
        /// </remarks>
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
        /// Gets or sets the gengrid select mode by <see cref="GenGridSelectionMode"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the direction for which a given gengrid widget expands while placing its items.
        /// </summary>
        /// <remarks>
        /// If true, items are placed in columns from top to bottom and when the space for a column is filled, another one is started on the right, thus expanding the grid horizontally.
        /// If false, items are placed in rows from left to right, and when the space for a row is filled, another one is started below, thus expanding the grid vertically.
        /// </remarks>
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
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
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
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
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
        /// Appends a new item to a given gengrid widget. This adds an item to the end of the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a gengrid item that contains data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        public GenGridItem Append(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_append(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Prepends a new item to a given gengrid widget. This adds an item to the beginning of the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <returns>Return a gengrid item that contains data and itemClass.</returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        public GenGridItem Prepend(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_prepend(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Inserts an item before another in a gengrid widget. This inserts an item before another in the gengrid.
        /// </summary>
        /// <param name="itemClass">The itemClass defines how to display the data.</param>
        /// <param name="data">The item data.</param>
        /// <param name="before">The item before which to place this new one.</param>
        /// <returns>Return a gengrid item that contains data and itemClass./></returns>
        /// <seealso cref="GenItemClass"/>
        /// <seealso cref="GenGridItem"/>
        public GenGridItem InsertBefore(GenItemClass itemClass, object data, GenGridItem before)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_before(RealHandle, itemClass.UnmanagedPtr, (IntPtr)item.Id, before, null, (IntPtr)item.Id);
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
        /// If animated is true, the gengrid shows item by scrolling if it's not fully visible.
        /// If animated is false, the gengrid shows item by jumping if it's not fully visible.
        /// </remarks>
        /// <seealso cref="ScrollToPosition"/>
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
        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_gengrid_realized_items_update(RealHandle);
        }

        /// <summary>
        /// Removes all items from a given gengrid widget.
        /// This removes(and deletes) all items in obj, making it empty.
        /// </summary>
        /// <remarks>
        /// <see cref="ItemObject.Delete()"/> to delete just one item.
        /// </remarks>
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