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
    /// Enumeration for the icon lookup order of Toolbar.
    /// </summary>
    public enum ToolbarIconLookupOrder
    {
        /// <summary>
        /// Icon look up order: freedesktop, theme.
        /// </summary>
        FreedesktopTheme,

        /// <summary>
        /// Icon look up order: theme, freedesktop.
        /// </summary>
        ThemeFreedesktop,

        /// <summary>
        /// Icon look up order: freedesktop.
        /// </summary>
        Freedesktop,

        /// <summary>
        /// Icon look up order: theme.
        /// </summary>
        Theme,
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
    public class Toolbar : Widget, IScrollable
    {
        ScrollableAdapter _scroller;
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

            _scroller = new ScrollableAdapter(this);
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
        /// Sets or gets toolbar's current orientation.
        /// </summary>
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
        /// Gets the number of items in a toolbar widget.
        /// </summary>
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
            return InsertBefore(before, label, string.Empty);
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
        /// Inserts a new item which contains label and icon into the toolbar object after item <paramref name="after"/>.
        /// </summary>
        /// <param name="after">The toolbar item to insert after</param>
        /// <param name="label">The label of the item</param>
        /// <param name="icon">A string with the icon name or the absolute path of an image file</param>
        /// <returns>The new <see cref="ToolbarItem"/> which insert into the toolbar</returns>
        public ToolbarItem InsertAfter(ToolbarItem after, string label, string icon)
        {
            ToolbarItem item = new ToolbarItem(label, icon);
            item.Handle = Interop.Elementary.elm_toolbar_item_insert_after(RealHandle, after, icon, label, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Find the item with that label in the toolbar.
        /// </summary>
        /// <param name="label">The label of the item</param>
        /// <returns>The <see cref="ToolbarItem"/> into the toolbar</returns>
        public ToolbarItem FindItemByLabel(string label)
        {
            IntPtr handle = Interop.Elementary.elm_toolbar_item_find_by_label(RealHandle, label);
            return ItemObject.GetItemByHandle(handle) as ToolbarItem;
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

        /// <summary>
        /// Gets the first ToolbarItemItem of the toolbar.
        /// </summary>
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
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_toolbar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        #region IScroller Implementation

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
        public event EventHandler Scrolled
        {
            add => _scroller.Scrolled += value;
            remove => _scroller.Scrolled -= value;
        }

        /// <summary>
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
        public event EventHandler DragStart
        {
            add => _scroller.DragStart += value;
            remove => _scroller.DragStart -= value;
        }

        /// <summary>
        /// DragStop will be triggered when dragging the contents around has stopped.
        /// </summary>
        public event EventHandler DragStop
        {
            add => _scroller.DragStop += value;
            remove => _scroller.DragStop -= value;
        }

        /// <summary>
        /// PageScrolled will be triggered when the visible page has changed.
        /// </summary>
        public event EventHandler PageScrolled
        {
            add => _scroller.PageScrolled += value;
            remove => _scroller.PageScrolled -= value;
        }

        /// <summary>
        /// Gets the current region in the content object that is visible through the Scroller.
        /// </summary>
        public Rect CurrentRegion => _scroller.CurrentRegion;

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public virtual ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get => _scroller.HorizontalScrollBarVisiblePolicy;
            set => _scroller.HorizontalScrollBarVisiblePolicy = value;
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public virtual ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get => _scroller.VerticalScrollBarVisiblePolicy;
            set => _scroller.VerticalScrollBarVisiblePolicy = value;
        }

        /// <summary>
        /// Sets or gets the value of ScrollBlock.
        /// </summary>
        /// <remarks>
        /// This function will block scrolling movement  in a given direction.One can disable movements in the X axis, the Y axis or both.
        /// The default value is ScrollBlock.None, where movements are allowed in both directions.
        /// </remarks>
        public ScrollBlock ScrollBlock
        {
            get => _scroller.ScrollBlock;
            set => _scroller.ScrollBlock = value;
        }

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int VerticalPageIndex => _scroller.VerticalPageIndex;

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int HorizontalPageIndex => _scroller.HorizontalPageIndex;

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at vertical direction.
        /// </summary>
        public int VerticalPageScrollLimit
        {
            get => _scroller.VerticalPageScrollLimit;
            set => _scroller.VerticalPageScrollLimit = value;
        }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at horizontal direction.
        /// </summary>
        public int HorizontalPageScrollLimit
        {
            get => _scroller.HorizontalPageScrollLimit;
            set => _scroller.HorizontalPageScrollLimit = value;
        }

        /// <summary>
        /// Sets or gets the vertical bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        public bool VerticalBounce
        {
            get => _scroller.VerticalBounce;
            set => _scroller.VerticalBounce = value;
        }

        /// <summary>
        /// Sets or gets the horizontal bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        public bool HorizontalBounce
        {
            get => _scroller.HorizontalBounce;
            set => _scroller.HorizontalBounce = value;
        }

        /// <summary>
        /// Gets the width of the content object of the scroller.
        /// </summary>
        public int ChildWidth
        {
            get => _scroller.ChildWidth;
        }

        /// <summary>
        /// Gets the height of the content object of the scroller.
        /// </summary>
        public int ChildHeight
        {
            get => _scroller.ChildHeight;
        }

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        public double HorizontalGravity
        {
            get => _scroller.HorizontalGravity;
            set => _scroller.HorizontalGravity = value;
        }

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        public double VerticalGravity
        {
            get => _scroller.VerticalGravity;
            set => _scroller.VerticalGravity = value;
        }

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastVerticalPageNumber => _scroller.LastVerticalPageNumber;

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastHorizontalPageNumber => _scroller.LastHorizontalPageNumber;

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop vertically.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool VerticalLoop
        {
            get => _scroller.VerticalLoop;
            set => _scroller.VerticalLoop = value;
        }

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop horizontally.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool HorizontalLoop
        {
            get => _scroller.HorizontalLoop;
            set => _scroller.HorizontalLoop = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int HorizontalPageSize
        {
            get => _scroller.HorizontalPageSize;
            set => _scroller.HorizontalPageSize = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int VerticalPageSize
        {
            get => _scroller.VerticalPageSize;
            set => _scroller.VerticalPageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double VerticalRelativePageSize
        {
            get => _scroller.VerticalRelativePageSize;
            set => _scroller.VerticalRelativePageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double HorizontalRelativePageSize
        {
            get => _scroller.HorizontalRelativePageSize;
            set => _scroller.HorizontalRelativePageSize = value;
        }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see VerticalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        public bool VerticalSnap
        {
            get => _scroller.VerticalSnap;
            set => _scroller.VerticalSnap = value;
        }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see HorizontalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        public bool HorizontalSnap
        {
            get => _scroller.HorizontalSnap;
            set => _scroller.HorizontalSnap = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageHeight
        {
            get => _scroller.PageHeight;
            set => _scroller.PageHeight = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageWidth
        {
            get => _scroller.PageWidth;
            set => _scroller.PageWidth = value;
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int HorizontalStepSize
        {
            get => _scroller.HorizontalStepSize;
            set => _scroller.HorizontalStepSize = value;
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int VerticalStepSize
        {
            get => _scroller.VerticalStepSize;
            set => _scroller.VerticalStepSize = value;
        }

        /// <summary>
        /// Gets or sets a value whether mouse wheel is enabled or not over the scroller.
        /// </summary>
        public bool WheelDisabled
        {
            get => _scroller.WheelDisabled;
            set => _scroller.WheelDisabled = value;
        }

        /// <summary>
        /// Gets or sets the type of single direction scroll.
        /// </summary>
        public ScrollSingleDirection SingleDirection
        {
            get => _scroller.SingleDirection;
            set => _scroller.SingleDirection = value;
        }

        /// <summary>
        /// Sets the scroller minimum size limited to the minimum size of the content.
        /// By default the scroller will be as small as its design allows, irrespective of its content.
        /// This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.
        /// </summary>
        /// <param name="horizontal">Enable limiting minimum size horizontally</param>
        /// <param name="vertical">Enable limiting minimum size vertically</param>
        public void MinimumLimit(bool horizontal, bool vertical)
        {
            _scroller.MinimumLimit(horizontal, vertical);
        }

        /// <summary>
        /// Shows a specific virtual region within the scroller content object by the page number.
        /// (0, 0) of the indicated page is located at the top-left corner of the viewport.
        /// </summary>
        /// <param name="horizontalPageIndex">The horizontal page number.</param>
        /// <param name="verticalPageIndex">The vertical page number.</param>
        /// <param name="animated">True means slider with animation.</param>
        public void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated)
        {
            _scroller.ScrollTo(horizontalPageIndex, verticalPageIndex, animated);
        }

        /// <summary>
        /// Shows a specific virtual region within the scroller content object.
        /// </summary>
        /// <remarks>
        /// This ensures that all (or part, if it does not fit) of the designated region in the virtual content object ((0, 0)
        /// starting at the top-left of the virtual content object) is shown within the scroller.
        /// If set "animated" to true, it will allows the scroller to "smoothly slide" to this location
        /// (if configuration in general calls for transitions).
        /// It may not jump immediately to the new location and may take a while and show other content along the way.
        /// </remarks>
        /// <param name="region">Rect struct of region.</param>
        /// <param name="animated">True means allows the scroller to "smoothly slide" to this location.</param>
        public void ScrollTo(Rect region, bool animated)
        {
            _scroller.ScrollTo(region, animated);
        }

        #endregion
    }
}