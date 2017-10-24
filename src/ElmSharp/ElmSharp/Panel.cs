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
    /// Enumeration for paneldirection type.
    /// </summary>
    public enum PanelDirection
    {
        /// <summary>
        /// Top to bottom
        /// </summary>
        Top = 0,
        /// <summary>
        /// Bottom to top
        /// </summary>
        Bottom,
        /// <summary>
        /// Left to right
        /// </summary>
        Left,
        /// <summary>
        /// Right to left
        /// </summary>
        Right,
    }

    /// <summary>
    /// The Panel is a container that can contain subobjects.
    /// </summary>
    public class Panel : Layout, IScrollable
    {
        ScrollableAdapter _scroller;
        SmartEvent _toggled;

        /// <summary>
        /// Creates and initializes a new instance of Panel class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Panel will be attached as a child.</param>
        public Panel(EvasObject parent) : base(parent)
        {
            _toggled = new SmartEvent(this, this.RealHandle, "toggled");
            _toggled.On += (s, e) => Toggled?.Invoke(this, EventArgs.Empty);
            _scroller = new ScrollableAdapter(this);
        }

        /// <summary>
        /// Sets or gets the hidden status of a given Panel widget.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return !Interop.Elementary.elm_panel_hidden_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panel_hidden_set(RealHandle, !value);
            }
        }

        /// <summary>
        /// Sets or gets the direction of a given Panel widget.
        /// </summary>
        public PanelDirection Direction
        {
            get
            {
                return (PanelDirection)Interop.Elementary.elm_panel_orient_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_panel_orient_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Toggled will be triggered when toggles Panel.
        /// </summary>
        public event EventHandler Toggled;

        /// <summary>
        /// Enable or disable scrolling in the Panel.
        /// </summary>
        /// <param name="enable">
        /// Bool value can be false or true.
        /// </param>
        public void SetScrollable(bool enable)
        {
            Interop.Elementary.elm_panel_scrollable_set(RealHandle, enable);
        }

        /// <summary>
        /// Sets the scroll size of Panel.
        /// </summary>
        /// <param name="ratio">
        /// The size of scroll area.
        /// </param>
        public void SetScrollableArea(double ratio)
        {
            Interop.Elementary.elm_panel_scrollable_content_size_set(RealHandle, ratio);
        }

        /// <summary>
        /// Toggles the hidden state of the Panel.
        /// </summary>
        public void Toggle()
        {
            Interop.Elementary.elm_panel_toggle(RealHandle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_panel_add(handle);
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
