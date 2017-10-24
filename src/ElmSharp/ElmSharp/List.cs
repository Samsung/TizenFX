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
    /// Enumeration for setting list's resizing behavior, transverse axis scrolling and items cropping.
    /// </summary>
    public enum ListMode
    {
        /// <summary>
        /// The list won't set any of its size hints to inform how a possible container should resize it.
        /// Then, if it's not created as a "resize object", it might end with zeroed dimensions.
        /// The list will respect the container's geometry and, if any of its items won't fit into its transverse axis, one won't be able to scroll it in that direction.
        /// </summary>
        Compress = 0,
        /// <summary>
        /// This is the same as Compress, with the exception that if any of its items won't fit into its transverse axis, one will be able to scroll it in that direction.
        /// </summary>
        Scroll,
        /// <summary>
        /// Sets a minimum size hint on the genlist object, so that containers may respect it (and resize itself to fit the child properly).
        /// More specifically, a minimum size hint will be set for its transverse axis, so that the largest item in that direction fits well.
        /// This is naturally bound by the list object's maximum size hints, set externally.
        /// </summary>
        Limit,
        /// <summary>
        /// Besides setting a minimum size on the transverse axis, just like on Limit, the list will set a minimum size on th longitudinal axis, trying to reserve space to all its children to be visible at a time.
        /// This is naturally bound by the list object's maximum size hints, set externally.
        /// </summary>
        Expand
    }

    /// <summary>
    /// It inherits System.EventArgs.
    /// It contains Item which is <see cref="ListItem"/> type.
    /// All events of List contain ListItemEventArgs as a parameter.
    /// </summary>
    public class ListItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets List item. The return type is <see cref="ListItem"/>.
        /// </summary>
        public ListItem Item { get; set; }

        internal static ListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ListItem item = ItemObject.GetItemByHandle(info) as ListItem;
            return new ListItemEventArgs() { Item = item };
        }
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The List is a widget that aims to display simple list item which has 2 icons and 1 text, and can be selected.
    /// For more robust lists, <see cref="GenList"/> should probably be used.
    /// </summary>
    /// <seealso cref="GenList"/>
    /// <seealso cref="GenGrid"/>
    public class List : Layout, IScrollable
    {
        ScrollableAdapter _scroller;
        HashSet<ListItem> _children = new HashSet<ListItem>();
        SmartEvent<ListItemEventArgs> _selected;
        SmartEvent<ListItemEventArgs> _unselected;
        SmartEvent<ListItemEventArgs> _doubleClicked;
        SmartEvent<ListItemEventArgs> _longpressed;
        SmartEvent<ListItemEventArgs> _activated;

        /// <summary>
        /// Creates and initializes a new instance of the List class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by List as a child. It's <see cref="EvasObject"/> type.</param>
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
        /// Gets or sets which mode to use for the list.
        /// </summary>
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
        public event EventHandler<ListItemEventArgs> ItemSelected;

        /// <summary>
        /// ItemUnselected is raised when the list item is Unselected.
        /// </summary>
        public event EventHandler<ListItemEventArgs> ItemUnselected;

        /// <summary>
        /// ItemDoubleClicked is raised when a new list item is double clicked.
        /// </summary>
        public event EventHandler<ListItemEventArgs> ItemDoubleClicked;

        /// <summary>
        /// ItemLongPressed is raised when a list item is pressed for a certain amount of time. By default it's 1 second.
        /// </summary>
        public event EventHandler<ListItemEventArgs> ItemLongPressed;

        /// <summary>
        /// ItemActivated is raised when a new list item is double clicked or pressed (enter|return|spacebar).
        /// </summary>
        public event EventHandler<ListItemEventArgs> ItemActivated;

        /// <summary>
        /// Starts the list.
        /// Call before running <see cref="EvasObject.Show"/> on the list object.
        /// If not called, it won't display the list properly.
        /// </summary>
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
        public ListItem Prepend(string label, EvasObject leftIcon, EvasObject rigthIcon)
        {
            ListItem item = new ListItem(label, leftIcon, rigthIcon);
            item.Handle = Interop.Elementary.elm_list_item_prepend(RealHandle, label, leftIcon, rigthIcon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Removes all items from a given list widget.
        /// To delete just one item, use <see cref="ItemObject.Delete"/>.
        /// </summary>
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
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_list_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            _scroller = new ScrollableAdapter(this);

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
