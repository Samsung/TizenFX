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
    /// <summary>
    /// Enumeration for the selection mode of Toolbar.
    /// </summary>
    public enum ToolbarSelectionMode
    {
        /// <summary>
        /// Default select mode.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Always select mode.
        /// </summary>
        Always,

        /// <summary>
        /// No select mode.
        /// </summary>
        None,

        /// <summary>
        /// No select mode with no finger size rule.
        /// </summary>
        DisplayOnly,
    }

    /// <summary>
    /// Enumeration that sets the toolbar items display behavior, it can be scrollable, can show a menu with exceeding items, or simply hide them.
    /// </summary>
    public enum ToolbarShrinkMode
    {
        /// <summary>
        /// Sets minimum toolbar size to fit all the items.
        /// </summary>
        None = 0,

        /// <summary>
        /// Hides exceeding items.
        /// </summary>
        Hide,

        /// <summary>
        /// Allows accessing exceeding items through a scroller.
        /// </summary>
        Scroll,

        /// <summary>
        /// Inserts a button to pop up a menu with exceeding items.
        /// </summary>
        Menu,

        /// <summary>
        /// Expands all items according to the size of the toolbar.
        /// </summary>
        Expand
    }

    /// <summary>
    /// Event arguments for events of <see cref="ToolbarItem"/>.
    /// </summary>
    /// <remarks>
    /// Inherits EventArgs.
    /// </remarks>
    public class ToolbarItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the ToolbarItem.
        /// </summary>
        public ToolbarItem Item { get; private set; }

        internal static ToolbarItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ToolbarItem item = ItemObject.GetItemByHandle(info) as ToolbarItem;
            return new ToolbarItemEventArgs() { Item = item };
        }
    }

    /// <summary>
    /// The Toolbar is a widget that displays a list of items inside a box.
    /// </summary>
    public class Toolbar : Widget
    {
        SmartEvent<ToolbarItemEventArgs> _clicked;
        SmartEvent<ToolbarItemEventArgs> _selected;
        SmartEvent<ToolbarItemEventArgs> _longpressed;

        /// <summary>
        /// Creates and initializes a new instance of the Toolbar class.
        /// </summary>
        /// <param name="parent">
        /// A EvasObject to which the new Table instance will be attached.
        /// </param>
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

        /// <summary>
        /// Selected will be triggered when toolbar have been selected.
        /// </summary>
        public event EventHandler<ToolbarItemEventArgs> Selected;

        /// <summary>
        /// Sets or gets whether the layout of this toolbar is homogeneous.
        /// </summary>
        /// <remarks>True for homogeneous, False for no homogeneous</remarks>
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

        /// <summary>
        /// Sets or gets the slection mode of a given Toolbar widget.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the shrink mode of a given Toolbar widget.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the alignment of the items.
        /// </summary>
        /// <remarks>The toolbar items alignment, a float between 0.0 and 1.0</remarks>
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

        /// <summary>
        /// Sets or gets the item's transverse expansion of a given toolbar widget.
        /// </summary>
        /// <remarks>
        /// The transverse expansion of the item, true for on and false for off.
        /// By default it's false.
        /// </remarks>
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

        /// <summary>
        /// Appends ToolbarItem which just contains label to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item</param>
        /// <returns>The new ToolbarItem which appended to the toolbar</returns>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string)"/>
        public ToolbarItem Append(string label)
        {
            return Append(label, null);
        }

        /// <summary>
        /// Appends ToolbarItem which contains label and icon to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file</param>
        /// <returns>The new ToolbarItem which appended to the toolbar</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Prepend(string)"/>
        /// <seealso cref="Prepend(string, string)"/>
        public ToolbarItem Append(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_append(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Prepends ToolbarItem which just contains label to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item</param>
        /// <returns>The new ToolbarItem which prepended to the toolbar</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string, string)"/>
        public ToolbarItem Prepend(string label)
        {
            return Prepend(label, null);
        }

        /// <summary>
        /// Prepends ToolbarItem which contains label and icon to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file</param>
        /// <returns>The new <see cref="ToolbarItem"/> which prepended to the toolbar</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string)"/>
        public ToolbarItem Prepend(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_prepend(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Inserts a new item which just contains label into the toolbar object before item <paramref name="before"/>.
        /// </summary>
        /// <param name="before">The toolbar item to insert before</param>
        /// <param name="label">The label of the item</param>
        /// <returns>The new <see cref="ToolbarItem"/> which insert into the toolbar</returns>
        /// <seealso cref="InsertBefore(ToolbarItem, string, string)"/>
        public ToolbarItem InsertBefore(ToolbarItem before, string label)
        {
            return InsertBefore(before, label);
        }

        /// <summary>
        /// Inserts a new item which contains label and icon into the toolbar object before item <paramref name="before"/>.
        /// </summary>
        /// <param name="before">The toolbar item to insert before</param>
        /// <param name="label">The label of the item</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file</param>
        /// <returns>The new <see cref="ToolbarItem"/> which insert into the toolbar</returns>
        /// <seealso cref="InsertBefore(ToolbarItem, string)"/>
        public ToolbarItem InsertBefore(ToolbarItem before, string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_insert_before(RealHandle, before, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Gets the selected ToolbarItemItem of the toolbar.
        /// </summary>
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
