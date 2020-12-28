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
    /// Enumeration for the visible type of scrollbar.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ScrollBarVisiblePolicy
    {
        /// <summary>
        /// Show scrollbars as needed.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Always show scrollbars.
        /// </summary>
        Visible,

        /// <summary>
        /// Never show scrollbars.
        /// </summary>
        Invisible
    }

    /// <summary>
    /// Enumeration for the visible type of scrollbar.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ScrollBlock
    {
        /// <summary>
        /// Scrolling movement is allowed in both the directions (X-axis and Y-axis).
        /// </summary>
        None = 1,

        /// <summary>
        /// Scrolling movement is not allowed in the Y-axis direction.
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// Scrolling movement is not allowed in the X-axis direction.
        /// </summary>
        Horizontal = 4
    }

    /// <summary>
    /// Type that controls how the content is scrolled.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ScrollSingleDirection
    {
        /// <summary>
        /// Scroll in every direction.
        /// </summary>
        None,

        /// <summary>
        /// Scroll in single direction if the direction is certain.
        /// </summary>
        Soft,

        /// <summary>
        /// Scroll only in a single direction.
        /// </summary>
        Hard,
    }

    /// <summary>
    /// The Scroller is a container that holds and clips a single object and allows you to scroll across it.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Scroller : Layout
    {
        SmartEvent _scroll;
        SmartEvent _scrollAnimationStart;
        SmartEvent _scrollAnimationStop;
        SmartEvent _dragStart;
        SmartEvent _dragStop;
        SmartEvent _scrollpage;

        /// <summary>
        /// Creates and initializes a new instance of the Scroller class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new Scroller will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Scroller(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Scroller class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Scroller() : base()
        {
        }

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Scrolled
        {
            add
            {
                _scroll.On += value;
            }
            remove
            {
                _scroll.On -= value;
            }
        }

        /// <summary>
        /// ScrollAnimationStarted will be triggered when the content animation has been started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ScrollAnimationStarted
        {
            add
            {
                _scrollAnimationStart.On += value;
            }
            remove
            {
                _scrollAnimationStart.On -= value;
            }
        }

        /// <summary>
        /// ScrollAnimationStopped will be triggered when the content animation has been stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ScrollAnimationStopped
        {
            add
            {
                _scrollAnimationStop.On += value;
            }
            remove
            {
                _scrollAnimationStop.On -= value;
            }
        }

        /// <summary>
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DragStart
        {
            add
            {
                _dragStart.On += value;
            }
            remove
            {
                _dragStart.On -= value;
            }
        }

        /// <summary>
        /// DragStop will be triggered when dragging the contents around has stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DragStop
        {
            add
            {
                _dragStop.On += value;
            }
            remove
            {
                _dragStop.On -= value;
            }
        }

        /// <summary>
        /// PageScrolled will be triggered when the visible page has changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler PageScrolled
        {
            add
            {
                _scrollpage.On += value;
            }
            remove
            {
                _scrollpage.On -= value;
            }
        }

        /// <summary>
        /// Gets the current region in the content object that is visible through the scroller.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Rect CurrentRegion
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_scroller_region_get(RealHandle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
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
        public virtual ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
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
        public virtual ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
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
        /// Sets or gets the value of ScrollBlock.
        /// </summary>
        /// <remarks>
        /// This function will block scrolling movement in a given direction. One can disable movements in the X-axis, the Y-axis, or both.
        /// The default value is ScrollBlock.None, where movements are allowed in both directions.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ScrollBlock ScrollBlock
        {
            get
            {
                return (ScrollBlock)Interop.Elementary.elm_scroller_movement_block_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_scroller_movement_block_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public int VerticalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(RealHandle, out h, out v);
                return v;
            }
        }

        /// <summary>
        /// Sets or gets the scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public int HorizontalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(RealHandle, out h, out v);
                return h;
            }
        }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at vertical direction.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int VerticalPageScrollLimit
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_page_scroll_limit_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                int h = HorizontalPageScrollLimit;
                Interop.Elementary.elm_scroller_page_scroll_limit_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at horizontal direction.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int HorizontalPageScrollLimit
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_page_scroll_limit_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                int v = VerticalPageScrollLimit;
                Interop.Elementary.elm_scroller_page_scroll_limit_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Sets or gets the vertical bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool VerticalBounce
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_bounce_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                bool h = HorizontalBounce;
                Interop.Elementary.elm_scroller_bounce_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Sets or gets the horizontal bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool HorizontalBounce
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_bounce_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                bool v = VerticalBounce;
                Interop.Elementary.elm_scroller_bounce_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Gets the width of the content object of the scroller.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ChildWidth
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_scroller_child_size_get(RealHandle, out w, out h);
                return w;
            }
        }

        /// <summary>
        /// Gets the height of the content object of the scroller.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ChildHeight
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_scroller_child_size_get(RealHandle, out w, out h);
                return h;
            }
        }

        /// <summary>
        /// Sets the scrolling gravity values for a scroller.
        /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows:
        /// x=0.0, for staying where it is relative to the left edge of the content, x=1.0, for staying where it is relative to the rigth edge of the content, y=0.0, for staying where it is relative to the top edge of the content, y=1.0, for staying where it is relative to the bottom edge of the content.
        /// Default values for x and y are 0.0.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double HorizontalGravity
        {
            get
            {
                double v, h;
                Interop.Elementary.elm_scroller_gravity_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                double v = VerticalGravity;
                Interop.Elementary.elm_scroller_gravity_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Sets the scrolling gravity values for a scroller.
        /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows:
        /// x=0.0, for staying where it is relative to the left edge of the content, x=1.0, for staying where it is relative to the rigth edge of the content, y=0.0, for staying where it is relative to the top edge of the content, y=1.0, for staying where it is relative to the bottom edge of the content.
        /// Default values for x and y are 0.0.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double VerticalGravity
        {
            get
            {
                double v, h;
                Interop.Elementary.elm_scroller_gravity_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                double h = HorizontalGravity;
                Interop.Elementary.elm_scroller_gravity_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Gets the scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int LastVerticalPageNumber
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_last_page_get(RealHandle, out h, out v);
                return v;
            }
        }

        /// <summary>
        /// Gets the scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int LastHorizontalPageNumber
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_last_page_get(RealHandle, out h, out v);
                return h;
            }
        }

        /// <summary>
        /// Sets an infinite loop_ for a scroller.
        /// This function sets the infinite loop vertically.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool VerticalLoop
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_loop_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                bool h = HorizontalLoop;
                Interop.Elementary.elm_scroller_loop_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Sets an infinite loop_ for a scroller.
        /// This function sets the infinite loop horizontally.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool HorizontalLoop
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_loop_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                bool v = VerticalLoop;
                Interop.Elementary.elm_scroller_loop_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double VerticalRelativePageSize
        {
            get
            {
                double v, h;
                Interop.Elementary.elm_scroller_page_relative_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                double h = HorizontalRelativePageSize;
                Interop.Elementary.elm_scroller_page_relative_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double HorizontalRelativePageSize
        {
            get
            {
                double v, h;
                Interop.Elementary.elm_scroller_page_relative_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                double v = VerticalRelativePageSize;
                Interop.Elementary.elm_scroller_page_relative_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Gets or sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see VerticalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool VerticalSnap
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_page_snap_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                bool h = HorizontalSnap;
                Interop.Elementary.elm_scroller_page_snap_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Gets or sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see HorizontalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool HorizontalSnap
        {
            get
            {
                bool v, h;
                Interop.Elementary.elm_scroller_page_snap_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                bool v = VerticalSnap;
                Interop.Elementary.elm_scroller_page_snap_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int PageHeight
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_scroller_page_size_get(RealHandle, out w, out h);
                return h;
            }
            set
            {
                int w = PageWidth;
                Interop.Elementary.elm_scroller_page_size_set(RealHandle, w, value);
            }
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int PageWidth
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_scroller_page_size_get(RealHandle, out w, out h);
                return w;
            }
            set
            {
                int h = PageHeight;
                Interop.Elementary.elm_scroller_page_size_set(RealHandle, value, h);
            }
        }

        /// <summary>
        /// Gets or sets the event propagation for a scroller.
        /// This enables or disables event propagation from the scroller content to the scroller and its parent.
        /// By default, event propagation is enabled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
        public int HorizontalStepSize
        {
            get
            {
                int h, v;
                Interop.Elementary.elm_scroller_step_size_get(RealHandle, out h, out v);
                return h;
            }
            set
            {
                int v = VerticalStepSize;
                Interop.Elementary.elm_scroller_step_size_set(RealHandle, value, v);
            }
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int VerticalStepSize
        {
            get
            {
                int h, v;
                Interop.Elementary.elm_scroller_step_size_get(RealHandle, out h, out v);
                return v;
            }
            set
            {
                int h = HorizontalStepSize;
                Interop.Elementary.elm_scroller_step_size_set(RealHandle, h, value);
            }
        }

        /// <summary>
        /// Gets or sets a value whether mouse wheel is enabled or not over the scroller.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool WheelDisabled
        {
            get
            {
                return Interop.Elementary.elm_scroller_wheel_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_scroller_wheel_disabled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of single direction scroll.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ScrollSingleDirection SingleDirection
        {
            get
            {
                return (ScrollSingleDirection)Interop.Elementary.elm_scroller_single_direction_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_scroller_single_direction_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets the scroller minimum size limited to the minimum size of the content.
        /// By default, the scroller will be as small as its design allows, irrespective of its content.
        /// This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.
        /// </summary>
        /// <param name="horizontal">Enable limiting minimum size horizontally.</param>
        /// <param name="vertical">Enable limiting minimum size vertically.</param>
        /// <since_tizen> preview </since_tizen>
        public void MinimumLimit(bool horizontal, bool vertical)
        {
            Interop.Elementary.elm_scroller_content_min_limit(RealHandle, horizontal, vertical);
        }

        /// <summary>
        /// Sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        /// <param name="width">The horizontal page size.</param>
        /// <param name="height">The vertical page size.</param>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
        public void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_scroller_page_bring_in(RealHandle, horizontalPageIndex, verticalPageIndex);
            }
            else
            {
                Interop.Elementary.elm_scroller_page_show(RealHandle, horizontalPageIndex, verticalPageIndex);
            }
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
        /// <since_tizen> preview </since_tizen>
        public void ScrollTo(Rect region, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_scroller_region_bring_in(RealHandle, region.X, region.Y, region.Width, region.Height);
            }
            else
            {
                Interop.Elementary.elm_scroller_region_show(RealHandle, region.X, region.Y, region.Width, region.Height);
            }
        }

        /// <summary>
        /// The callback of the Realized event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            _scroll = new SmartEvent(this, this.RealHandle, "scroll");
            _scrollAnimationStart = new SmartEvent(this, this.RealHandle, "scroll,anim,start");
            _scrollAnimationStop = new SmartEvent(this, this.RealHandle, "scroll,anim,stop");
            _dragStart = new SmartEvent(this, this.RealHandle, "scroll,drag,start");
            _dragStop = new SmartEvent(this, this.RealHandle, "scroll,drag,stop");
            _scrollpage = new SmartEvent(this, this.RealHandle, "scroll,page,changed");
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

            RealHandle = Interop.Elementary.elm_scroller_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}