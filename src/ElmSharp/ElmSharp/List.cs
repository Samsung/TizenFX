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
    /// Enumeration for setting the list's resizing behavior, transverse axis scrolling, and items cropping.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ListMode
    {
        /// <summary>
        /// The list won't set any of its size hints to inform how a possible container should resize it.
        /// Then, if it's not created as a "resize object", it might end with zeroed dimensions.
        /// The list will respect the container's geometry, and if any of its items won't fit into its transverse axis, one won't be able to scroll it in that direction.
        /// </summary>
        Compress = 0,
        /// <summary>
        /// This is the same as Compress, with the exception that if any of its items won't fit into its transverse axis, one will be able to scroll it in that direction.
        /// </summary>
        Scroll,
        /// <summary>
        /// Sets a minimum size hint on the genlist object, so that the containers may respect it (and resize itself to fit the child properly).
        /// More specifically, a minimum size hint will be set for its transverse axis, so that the largest item in that direction fits well.
        /// This is naturally bound by the list object's maximum size hints, set externally.
        /// </summary>
        Limit,
        /// <summary>
        /// Besides setting a minimum size on the transverse axis, just like on limit, the list will set a minimum size on the longitudinal axis, trying to reserve space to all its children to be visible at a time.
        /// This is naturally bound by the list object's maximum size hints, set externally.
        /// </summary>
        Expand
    }

    /// <summary>
    /// It inherits System.EventArgs.
    /// It contains an item which is <see cref="ListItem"/> type.
    /// All the events of a list contain ListItemEventArgs as a parameter.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ListItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the list item. The return type is <see cref="ListItem"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ListItem Item { get; set; }

        internal static ListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ListItem item = ItemObject.GetItemByHandle(info) as ListItem;
            return new ListItemEventArgs() { Item = item };
        }
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The List is a widget that aims to display a simple list item which has 2 icons, 1 text, and can be selected.
    /// For more robust lists, <see cref="GenList"/> should probably be used.
    /// </summary>
    /// <seealso cref="GenList"/>
    /// <seealso cref="GenGrid"/>
    /// <since_tizen> preview </since_tizen>
    public class List : Layout
    {
        HashSet<ListItem> _children = new HashSet<ListItem>();
        SmartEvent<ListItemEventArgs> _selected;
        SmartEvent<ListItemEventArgs> _unselected;
        SmartEvent<ListItemEventArgs> _doubleClicked;
        SmartEvent<ListItemEventArgs> _longpressed;
        SmartEvent<ListItemEventArgs> _activated;

        /// <summary>
        /// Creates and initializes a new instance of the List class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the list as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public List(EvasObject parent) : base(parent)
        {
            _selected = new SmartEvent<ListItemEventArgs>(this, this.RealHandle, "selected", ListItemEventArgs.CreateFromSmartEvent);
            _unselected = new SmartEvent<ListItemEventArgs>(this, this.RealHandle, "unselected", ListItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new SmartEvent<ListItemEventArgs>(this, this.RealHandle, "clicked,double", ListItemEventArgs.CreateFromSmartEvent);
            _longpressed = new SmartEvent<ListItemEventArgs>(this, this.RealHandle, "longpressed", ListItemEventArgs.CreateFromSmartEvent);
            _activated = new SmartEvent<ListItemEventArgs>(this, this.RealHandle, "activated", ListItemEventArgs.CreateFromSmartEvent);
            _selected.On += (s, e) => { ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { ItemUnselected?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { ItemDoubleClicked?.Invoke(this, e); };
            _longpressed.On += (s, e) => { ItemLongPressed?.Invoke(this, e); };
            _activated.On += (s, e) => { ItemActivated?.Invoke(this, e); };
        }

        /// <summary>
        /// Gets or sets which mode to be used for the list.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ListMode Mode
        {
            get
            {
                return (ListMode)Interop.Elementary.elm_list_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_list_mode_set(RealHandle, (Interop.Elementary.Elm_List_Mode)value);
            }
        }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ListItem SelectedItem
        {
            get
            {
                IntPtr item = Interop.Elementary.elm_list_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(item) as ListItem;
            }
        }

        /// <summary>
        /// ItemSelected is raised when a new list item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ListItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemUnselected is raised when a list item is Unselected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ListItemEventArgs> ItemUnselected;

        /// <summary>
        /// ItemDoubleClicked is raised when a new list item is double-clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ListItemEventArgs> ItemDoubleClicked;

        /// <summary>
        /// ItemLongPressed is raised when a list item is pressed for a certain amount of time. By default, it's 1 second.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ListItemEventArgs> ItemLongPressed;

        /// <summary>
        /// ItemActivated is raised when a new list item is double-clicked or pressed (enter|return|spacebar).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ListItemEventArgs> ItemActivated;

        /// <summary>
        /// Starts the list.
        /// Called before running <see cref="EvasObject.Show"/> on the list object.
        /// If not called, it won't display the list properly.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Update()
        {
            Interop.Elementary.elm_list_go(RealHandle);
        }

        /// <summary>
        /// Appends a new item with a text to the end of a given list widget.
        /// </summary>
        /// <param name="label">The text for the item.</param>
        /// <returns>Return a new added list item that contains a text.</returns>
        /// <seealso cref="ListItem"/>
        /// <since_tizen> preview </since_tizen>
        public ListItem Append(string label)
        {
            return Append(label, null, null);
        }

        /// <summary>
        /// Appends a new item with a text and 2 icons to the end of a given list widget.
        /// </summary>
        /// <param name="label">The text for the item.</param>
        /// <param name="leftIcon">The left icon for the item.</param>
        /// <param name="rightIcon">The right icon for the item.</param>
        /// <returns>Return a new added list item that contains a text and 2 icons.</returns>
        /// <seealso cref="ListItem"/>
        /// <since_tizen> preview </since_tizen>
        public ListItem Append(string label, EvasObject leftIcon, EvasObject rightIcon)
        {
            ListItem item = new ListItem(label, leftIcon, rightIcon);
            item.Handle = Interop.Elementary.elm_list_item_append(RealHandle, label, leftIcon, rightIcon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Prepends a new item with a text to the beginning of a given list widget.
        /// </summary>
        /// <param name="label">The text for the item.</param>
        /// <returns>Return a new added list item that contains a text.</returns>
        /// <since_tizen> preview </since_tizen>
        public ListItem Prepend(string label)
        {
            return Prepend(label, null, null);
        }

        /// <summary>
        /// Prepends a new item with a text and 2 icons to the beginning of a given list widget.
        /// </summary>
        /// <param name="label">The text for the item.</param>
        /// <param name="leftIcon">The left icon for the item.</param>
        /// <param name="rigthIcon">The right icon for the item.</param>
        /// <returns>Return a new added list item that contains a text and 2 icons.</returns>
        /// <since_tizen> preview </since_tizen>
        public ListItem Prepend(string label, EvasObject leftIcon, EvasObject rigthIcon)
        {
            ListItem item = new ListItem(label, leftIcon, rigthIcon);
            item.Handle = Interop.Elementary.elm_list_item_prepend(RealHandle, label, leftIcon, rigthIcon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Removes all the items from a given list widget.
        /// To delete just one item, use <see cref="ItemObject.Delete"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_list_clear(RealHandle);
            foreach (var item in _children)
            {
                item.Deleted -= Item_Deleted;
            }
            _children.Clear();
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

            RealHandle = Interop.Elementary.elm_list_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        void AddInternal(ListItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((ListItem)sender);
        }
    }
}
