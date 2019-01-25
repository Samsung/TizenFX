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
using System.ComponentModel;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the selection mode of the toolbar.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
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
    /// Enumeration for setting the toolbar items display behavior, it can be scrollable, can show a menu with exceeding items, or simply hide them.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ToolbarShrinkMode
    {
        /// <summary>
        /// Sets the minimum toolbar size to fit all the items.
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
        /// Inserts a button to popup a menu with exceeding items.
        /// </summary>
        Menu,

        /// <summary>
        /// Expands all items according to the size of the toolbar.
        /// </summary>
        Expand
    }

    /// <summary>
    /// Enumeration for the icon lookup order of the toolbar.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ToolbarIconLookupOrder
    {
        /// <summary>
        /// Icon lookup order: freedesktop, theme.
        /// </summary>
        FreedesktopTheme,

        /// <summary>
        /// Icon lookup order: theme, freedesktop.
        /// </summary>
        ThemeFreedesktop,

        /// <summary>
        /// Icon lookup order: freedesktop.
        /// </summary>
        Freedesktop,

        /// <summary>
        /// Icon lookup order: theme.
        /// </summary>
        Theme,
    }

    /// <summary>
    /// Event arguments for events of <see cref="ToolbarItem"/>.
    /// </summary>
    /// <remarks>
    /// Inherits EventArgs.
    /// </remarks>
    /// <since_tizen> preview </since_tizen>
    public class ToolbarItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the ToolbarItem.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem Item { get; private set; }

        internal static ToolbarItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ToolbarItem item = ItemObject.GetItemByHandle(info) as ToolbarItem;
            return new ToolbarItemEventArgs { Item = item };
        }
    }

    /// <summary>
    /// The Toolbar is a widget that displays a list of items inside a box.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Selected will be triggered when toolbar has been selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ToolbarItemEventArgs> Selected;

        /// <summary>
        /// Sets or gets whether the layout of this toolbar is homogeneous.
        /// </summary>
        /// <remarks>True for homogeneous, False for no homogeneous.</remarks>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the toolbar's current orientation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_toolbar_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the icon lookup order, for toolbar items' icons.
        /// The default lookup order is ToolbarIocnLookupOrder.ThemeFreedesktop.
        /// Icons added before calling this function will not be affected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ToolbarIconLookupOrder IconLookupOrder
        {
            get
            {
                return (ToolbarIconLookupOrder)Interop.Elementary.elm_toolbar_icon_order_lookup_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_icon_order_lookup_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the icon size of a given toolbar widget.
        /// Default value is 32 pixels, to be used by toolbar items.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int IconSize
        {
            get
            {
                return Interop.Elementary.elm_toolbar_icon_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_icon_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the number of items in a Toolbar widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ItemsCount
        {
            get
            {
                return Interop.Elementary.elm_toolbar_items_count(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the alignment of the items.
        /// </summary>
        /// <remarks>The toolbar items alignment, a float between 0.0 and 1.0.</remarks>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the item's transverse expansion of a given Toolbar widget.
        /// </summary>
        /// <remarks>
        /// The transverse expansion of the item, true for on and false for off.
        /// By default it's false.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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
        /// Appends the ToolbarItem, which just contains label to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item.</param>
        /// <returns>The new ToolbarItem which is appended to the toolbar.</returns>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem Append(string label)
        {
            return Append(label, null);
        }

        /// <summary>
        /// Appends the ToolbarItem, which contains label and icon to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item.</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file.</param>
        /// <returns>The new ToolbarItem which is appended to the toolbar.</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Prepend(string)"/>
        /// <seealso cref="Prepend(string, string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem Append(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_append(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Prepends the ToolbarItem, which just contains label to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item.</param>
        /// <returns>The new ToolbarItem which is prepended to the toolbar.</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string, string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem Prepend(string label)
        {
            return Prepend(label, null);
        }

        /// <summary>
        /// Prepends the ToolbarItem, which contains label and icon to the toolbar.
        /// </summary>
        /// <param name="label">The label of the item.</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file.</param>
        /// <returns>The new <see cref="ToolbarItem"/> which is prepended to the toolbar.</returns>
        /// <seealso cref="Append(string)"/>
        /// <seealso cref="Append(string, string)"/>
        /// <seealso cref="Prepend(string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem Prepend(string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_prepend(RealHandle, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Inserts a new item which just contains label into the toolbar object before item <paramref name="before"/>.
        /// </summary>
        /// <param name="before">The toolbar item to insert before.</param>
        /// <param name="label">The label of the item.</param>
        /// <returns>The new <see cref="ToolbarItem"/> which is inserted into the toolbar.</returns>
        /// <seealso cref="InsertBefore(ToolbarItem, string, string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem InsertBefore(ToolbarItem before, string label)
        {
            return InsertBefore(before, label, string.Empty);
        }

        /// <summary>
        /// Inserts a new item which contains label and icon into the toolbar object before item <paramref name="before"/>.
        /// </summary>
        /// <param name="before">The toolbar item to insert before.</param>
        /// <param name="label">The label of the item.</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file.</param>
        /// <returns>The new <see cref="ToolbarItem"/> which is inserted into the toolbar.</returns>
        /// <seealso cref="InsertBefore(ToolbarItem, string)"/>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem InsertBefore(ToolbarItem before, string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_insert_before(RealHandle, before, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Inserts a new item which contains label and icon into the toolbar object after item <paramref name="after"/>.
        /// </summary>
        /// <param name="after">The toolbar item to insert after.</param>
        /// <param name="label">The label of the item.</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file.</param>
        /// <returns>The new <see cref="ToolbarItem"/> which is inserted into the toolbar.</returns>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem InsertAfter(ToolbarItem after, string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_insert_after(RealHandle, after, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Finds the item with that label in the toolbar.
        /// </summary>
        /// <param name="label">The label of the item.</param>
        /// <returns>The <see cref="ToolbarItem"/> into the toolbar.</returns>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem FindItemByLabel(string label)
        {
            IntPtr handle = Interop.Elementary.elm_toolbar_item_find_by_label(RealHandle, label);
            return ItemObject.GetItemByHandle(handle) as ToolbarItem;
        }

        /// <summary>
        /// Gets the selected ToolbarItemItem of the toolbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_toolbar_selected_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as ToolbarItem;
            }
        }

        /// <summary>
        /// Gets the first ToolbarItemItem of the toolbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_toolbar_first_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as ToolbarItem;
            }
        }

        /// <summary>
        /// Gets the last ToolbarItemItem of the toolbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ToolbarItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_toolbar_last_item_get(RealHandle);
                return ItemObject.GetItemByHandle(handle) as ToolbarItem;
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
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_toolbar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}