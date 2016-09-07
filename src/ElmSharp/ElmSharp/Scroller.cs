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
        Interop.SmartEvent _scroll;
        Interop.SmartEvent _dragStart;
        Interop.SmartEvent _dragStop;
        Interop.SmartEvent _scrollpage;

        public Scroller(EvasObject parent) : base(parent)
        {
            _scroll = new Interop.SmartEvent(this, Handle, "scroll");
            _dragStart = new Interop.SmartEvent(this, Handle, "scroll,drag,start");
            _dragStop = new Interop.SmartEvent(this, Handle, "scroll,drag,stop");
            _scrollpage = new Interop.SmartEvent(this, Handle, "scroll,page,changed");
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
                Interop.Elementary.elm_scroller_region_get(Handle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        public ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Elementary.elm_scroller_policy_get(Handle, out policy, IntPtr.Zero);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy v = VerticalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(Handle, (int)value, (int)v);
            }
        }

        public ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get
            {
                int policy;
                Interop.Elementary.elm_scroller_policy_get(Handle, IntPtr.Zero, out policy);
                return (ScrollBarVisiblePolicy)policy;
            }
            set
            {
                ScrollBarVisiblePolicy h = HorizontalScrollBarVisiblePolicy;
                Interop.Elementary.elm_scroller_policy_set(Handle, (int)h, (int)value);
            }
        }

        public ScrollBlock ScrollBlock
        {
            get
            {
                return (ScrollBlock)Interop.Elementary.elm_scroller_movement_block_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_scroller_movement_block_set(Handle, (int)value);
            }
        }

        public int VerticalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(Handle, out h, out v);
                return v;
            }
        }

        public int HorizontalPageIndex
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_current_page_get(Handle, out h, out v);
                return h;
            }
        }

        public int VerticalPageScrollLimit
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_page_scroll_limit_get(Handle, out h, out v);
                return v;
            }
            set
            {
                int h = HorizontalPageScrollLimit;
                Interop.Elementary.elm_scroller_page_scroll_limit_set(Handle, h, value);
            }
        }

        public int HorizontalPageScrollLimit
        {
            get
            {
                int v, h;
                Interop.Elementary.elm_scroller_page_scroll_limit_get(Handle, out h, out v);
                return h;
            }
            set
            {
                int v = VerticalPageScrollLimit;
                Interop.Elementary.elm_scroller_page_scroll_limit_set(Handle, value, v);
            }
        }

        public void SetPageSize(int width, int height)
        {
            Interop.Elementary.elm_scroller_page_size_set(Handle, width, height);
        }

        public void SetPageSize(double width, double height)
        {
            Interop.Elementary.elm_scroller_page_relative_set(Handle, width, height);
        }

        public void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_scroller_page_bring_in(Handle, horizontalPageIndex, verticalPageIndex);
            }
            else
            {
                Interop.Elementary.elm_scroller_page_show(Handle, horizontalPageIndex, verticalPageIndex);
            }
        }

        public void ScrollTo(Rect region, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_scroller_region_bring_in(Handle, region.X, region.Y, region.Width, region.Height);
            }
            else
            {
                Interop.Elementary.elm_scroller_region_show(Handle, region.X, region.Y, region.Width, region.Height);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_scroller_add(parent);
        }
    }
}
