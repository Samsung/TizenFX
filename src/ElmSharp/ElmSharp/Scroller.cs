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
    /// Enumeration for visible type of scrollbar.
    /// </summary>
    public enum ScrollBarVisiblePolicy
    {
        /// <summary>
        /// Show scrollbars as needed
        /// </summary>
        Auto = 0,
        /// <summary>
        /// Always show scrollbars
        /// </summary>
        Visible,
        /// <summary>
        /// Never show scrollbars
        /// </summary>
        Invisible
    }
    /// <summary>
    /// Enumeration for visible type of scrollbar.
    /// </summary>
    public enum ScrollBlock
    {
        /// <summary>
        /// Scrolling movement is allowed in both direction.(X axis and Y axis)
        /// </summary>
        None = 1,
        /// <summary>
        /// Scrolling movement is not allowed in Y axis direction.
        /// </summary>
        Vertical = 2,
        /// <summary>
        /// Scrolling movement is not allowed in X axis direction.
        /// </summary>
        Horizontal = 4
    }
    /// <summary>
    /// The Scroller is a container that holds and clips a single object and allows you to scroll across it.
    /// </summary>
    public class Scroller : Layout
    {
        SmartEvent _scroll;
        SmartEvent _dragStart;
        SmartEvent _dragStop;
        SmartEvent _scrollpage;

        /// <summary>
        /// Creates and initializes a new instance of the Scroller class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new Scroller will be attached as a child.</param>
        public Scroller(EvasObject parent) : base(parent)
        {
            _scroll = new SmartEvent(this, this.RealHandle, "scroll");
            _dragStart = new SmartEvent(this, this.RealHandle, "scroll,drag,start");
            _dragStop = new SmartEvent(this, this.RealHandle, "scroll,drag,stop");
            _scrollpage = new SmartEvent(this, this.RealHandle, "scroll,page,changed");
        }

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
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
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
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
        /// Gets the current region in the content object that is visible through the Scroller.
        /// </summary>
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
        /// Sets or gets the value of ScrollBlock.
        /// </summary>
        /// <remarks>
        /// This function will block scrolling movement  in a given direction.One can disable movements in the X axis, the Y axis or both.
        /// The default value is ScrollBlock.None, where movements are allowed in both directions.
        /// </remarks>
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
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
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
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
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
