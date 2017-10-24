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
    /// The Scroller is a container that holds and clips a single object and allows you to scroll across it.
    /// </summary>
    public class Scroller : Layout, IScrollable
    {
        ScrollableAdapter _adapter;

        /// <summary>
        /// Creates and initializes a new instance of the Scroller class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new Scroller will be attached as a child.</param>
        public Scroller(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Scroller class.
        /// </summary>
        public Scroller() : base()
        {
        }

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
        public event EventHandler Scrolled
        {
            add => _adapter.Scrolled += value;
            remove => _adapter.Scrolled -= value;
        }

        /// <summary>
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
        public event EventHandler DragStart
        {
            add => _adapter.DragStart += value;
            remove => _adapter.DragStart -= value;
        }

        /// <summary>
        /// DragStop will be triggered when dragging the contents around has stopped.
        /// </summary>
        public event EventHandler DragStop
        {
            add => _adapter.DragStop += value;
            remove => _adapter.DragStop -= value;
        }

        /// <summary>
        /// PageScrolled will be triggered when the visible page has changed.
        /// </summary>
        public event EventHandler PageScrolled
        {
            add => _adapter.PageScrolled += value;
            remove => _adapter.PageScrolled -= value;
        }

        /// <summary>
        /// Gets the current region in the content object that is visible through the Scroller.
        /// </summary>
        public Rect CurrentRegion => _adapter.CurrentRegion;

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public virtual ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get => _adapter.HorizontalScrollBarVisiblePolicy;
            set => _adapter.HorizontalScrollBarVisiblePolicy = value;
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
            get => _adapter.VerticalScrollBarVisiblePolicy;
            set => _adapter.VerticalScrollBarVisiblePolicy = value;
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
            get => _adapter.ScrollBlock;
            set => _adapter.ScrollBlock = value;
        }

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int VerticalPageIndex => _adapter.VerticalPageIndex;

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int HorizontalPageIndex => _adapter.HorizontalPageIndex;

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at vertical direction.
        /// </summary>
        public int VerticalPageScrollLimit
        {
            get => _adapter.VerticalPageScrollLimit;
            set => _adapter.VerticalPageScrollLimit = value;
        }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at horizontal direction.
        /// </summary>
        public int HorizontalPageScrollLimit
        {
            get => _adapter.HorizontalPageScrollLimit;
            set => _adapter.HorizontalPageScrollLimit = value;
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
            get => _adapter.VerticalBounce;
            set => _adapter.VerticalBounce = value;
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
            get => _adapter.HorizontalBounce;
            set => _adapter.HorizontalBounce = value;
        }

        /// <summary>
        /// Gets the width of the content object of the scroller.
        /// </summary>
        public int ChildWidth
        {
            get => _adapter.ChildWidth;
        }

        /// <summary>
        /// Gets the height of the content object of the scroller.
        /// </summary>
        public int ChildHeight
        {
            get => _adapter.ChildHeight;
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
            get => _adapter.HorizontalGravity;
            set => _adapter.HorizontalGravity = value;
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
            get => _adapter.VerticalGravity;
            set => _adapter.VerticalGravity = value;
        }

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastVerticalPageNumber => _adapter.LastVerticalPageNumber;

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastHorizontalPageNumber => _adapter.LastHorizontalPageNumber;

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop vertically.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool VerticalLoop
        {
            get => _adapter.VerticalLoop;
            set => _adapter.VerticalLoop = value;
        }

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop horizontally.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool HorizontalLoop
        {
            get => _adapter.HorizontalLoop;
            set => _adapter.HorizontalLoop = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int HorizontalPageSize
        {
            get => _adapter.HorizontalPageSize;
            set => _adapter.HorizontalPageSize = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int VerticalPageSize
        {
            get => _adapter.VerticalPageSize;
            set => _adapter.VerticalPageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double VerticalRelativePageSize
        {
            get => _adapter.VerticalRelativePageSize;
            set => _adapter.VerticalRelativePageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double HorizontalRelativePageSize
        {
            get => _adapter.HorizontalRelativePageSize;
            set => _adapter.HorizontalRelativePageSize = value;
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
            get => _adapter.VerticalSnap;
            set => _adapter.VerticalSnap = value;
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
            get => _adapter.HorizontalSnap;
            set => _adapter.HorizontalSnap = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageHeight
        {
            get => _adapter.PageHeight;
            set => _adapter.PageHeight = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageWidth
        {
            get => _adapter.PageWidth;
            set => _adapter.PageWidth = value;
        }

        /// <summary>
        /// Gets or sets the event propagation for a scroller.
        /// This enables or disables event propagation from the scroller content to the scroller and its parent.
        /// By default event propagation is enabled.
        /// </summary>
        public bool ContentPropagateEvents
        {
            get
            {
                return Interop.Elementary.elm_scroller_propagate_events_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_scroller_propagate_events_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int HorizontalStepSize
        {
            get => _adapter.HorizontalStepSize;
            set => _adapter.HorizontalStepSize = value;
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int VerticalStepSize
        {
            get => _adapter.VerticalStepSize;
            set => _adapter.VerticalStepSize = value;
        }

        /// <summary>
        /// Gets or sets a value whether mouse wheel is enabled or not over the scroller.
        /// </summary>
        public bool WheelDisabled
        {
            get => _adapter.WheelDisabled;
            set => _adapter.WheelDisabled = value;
        }

        /// <summary>
        /// Gets or sets the type of single direction scroll.
        /// </summary>
        public ScrollSingleDirection SingleDirection
        {
            get => _adapter.SingleDirection;
            set => _adapter.SingleDirection = value;
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
            _adapter.MinimumLimit(horizontal, vertical);
        }

        /// <summary>
        /// Sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        /// <param name="width">The horizontal page size.</param>
        /// <param name="height">The vertical page size.</param>
        public void SetPageSize(int width, int height)
        {
            Interop.Elementary.elm_scroller_page_size_set(RealHandle, width, height);
        }

        /// <summary>
        /// Sets the scroll page size relative to the viewport size.
        /// </summary>
        /// <remarks>
        /// The scroller is capable of limiting scrolling by the user to "pages".
        /// That is to jump by and only show a "whole page" at a time as if the continuous area of the scroller
        /// content is split into page sized pieces. This sets the size of a page relative to the viewport of the scroller.
        /// 1.0 is "1 viewport" which is the size (horizontally or vertically). 0.0 turns it off in that axis.
        /// This is mutually exclusive with the page size (see elm_scroller_page_size_set() for more information).
        /// Likewise 0.5 is "half a viewport". Usable values are normally between 0.0 and 1.0 including 1.0.
        /// If you only want 1 axis to be page "limited", use 0.0 for the other axis.
        /// </remarks>
        /// <param name="width">The horizontal page relative size.</param>
        /// <param name="height">The vertical page relative size.</param>
        public void SetPageSize(double width, double height)
        {
            Interop.Elementary.elm_scroller_page_relative_set(RealHandle, width, height);
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
            _adapter.ScrollTo(horizontalPageIndex, verticalPageIndex, animated);
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
            _adapter.ScrollTo(region, animated);
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

            RealHandle = Interop.Elementary.elm_scroller_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            _adapter = new ScrollableAdapter(this);

            return handle;
        }
    }
}