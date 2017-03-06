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
    public enum ScrollBarVisiblePolicy
    {
        Auto = 0,
        Visible,
        Invisible
    }

    public enum ScrollBlock
    {
        None = 1,
        Vertical = 2,
        Horizontal = 4
    }

    public class Scroller : Layout
    {
        SmartEvent _scroll;
        SmartEvent _dragStart;
        SmartEvent _dragStop;
        SmartEvent _scrollpage;

        public Scroller(EvasObject parent) : base(parent)
        {
            _scroll = new SmartEvent(this, this.RealHandle, "scroll");
            _dragStart = new SmartEvent(this, this.RealHandle, "scroll,drag,start");
            _dragStop = new SmartEvent(this, this.RealHandle, "scroll,drag,stop");
            _scrollpage = new SmartEvent(this, this.RealHandle, "scroll,page,changed");
        }

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

        public Rect CurrentRegion
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_scroller_region_get(RealHandle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

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

        public int VerticalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(RealHandle, out h, out v);
                return v;
            }
        }

        public int HorizontalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(RealHandle, out h, out v);
                return h;
            }
        }

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

        public void SetPageSize(int width, int height)
        {
            Interop.Elementary.elm_scroller_page_size_set(RealHandle, width, height);
        }

        public void SetPageSize(double width, double height)
        {
            Interop.Elementary.elm_scroller_page_relative_set(RealHandle, width, height);
        }

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
