using System;
using System.Collections.Generic;
using System.Text;

using static Interop.Elementary;

namespace ElmSharp
{
    class ScrollableAdapter : IScrollable
    {
        EvasObject obj;
        SmartEvent _scroll;
        SmartEvent _dragStart;
        SmartEvent _dragStop;
        SmartEvent _scrollPage;

        public ScrollableAdapter(List list) : this(list as EvasObject)
        {
        }

        public ScrollableAdapter(Entry entry) : this(entry as EvasObject)
        {
        }

        public ScrollableAdapter(Panel panel) : this(panel as EvasObject)
        {
        }

        public ScrollableAdapter(GenGrid gengrid) : this(gengrid as EvasObject)
        {
        }

        public ScrollableAdapter(Scroller scroller) : this(scroller as EvasObject)
        {
        }

        public ScrollableAdapter(GenList genlist) : this(genlist as EvasObject)
        {
        }

        public ScrollableAdapter(Toolbar toolbar) : this(toolbar as EvasObject)
        {
        }

        ScrollableAdapter(EvasObject scrollable)
        {
            obj = scrollable;
            _scroll = new SmartEvent(obj, obj.RealHandle, "scroll");
            _dragStart = new SmartEvent(obj, obj.RealHandle, "scroll,drag,start");
            _dragStop = new SmartEvent(obj, obj.RealHandle, "scroll,drag,stop");
            _scrollPage = new SmartEvent(obj, obj.RealHandle, "scroll,page,changed");
        }

        public event EventHandler Scrolled
        {
            add => _scroll.On += value;
            remove => _scroll.On -= value;
        }
        public event EventHandler DragStart
        {
            add => _dragStart.On += value;
            remove => _dragStart.On -= value;
        }
        public event EventHandler DragStop
        {
            add => _dragStop.On += value;
            remove => _dragStop.On -= value;
        }
        public event EventHandler PageScrolled
        {
            add => _scrollPage.On += value;
            remove => _scrollPage.On -= value;
        }

        public double VerticalGravity
        {
            get => Get2<double>(elm_scroller_gravity_get);
            set => Set(elm_scroller_gravity_set, HorizontalGravity, value);
        }
        public double HorizontalGravity
        {
            get => Get1<double>(elm_scroller_gravity_get);
            set => Set(elm_scroller_gravity_set, value, VerticalGravity);
        }
        public bool VerticalBounce
        {
            get => Get2<bool>(elm_scroller_bounce_get);
            set => Set(elm_scroller_bounce_set, HorizontalBounce, value);
        }
        public bool HorizontalBounce
        {
            get => Get1<bool>(elm_scroller_bounce_get);
            set => Set(elm_scroller_bounce_set, value, VerticalBounce);
        }
        public bool WheelDisabled
        {
            get => Get(elm_scroller_wheel_disabled_get);
            set => Set(elm_scroller_wheel_disabled_set, value);
        }
        public ScrollBlock ScrollBlock
        {
            get => (ScrollBlock)Get(elm_scroller_movement_block_get);
            set => Set(elm_scroller_movement_block_set, (int)value);
        }
        public ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get => (ScrollBarVisiblePolicy)Get2<int>(elm_scroller_policy_get);
            set => Set(elm_scroller_policy_set, (int)HorizontalScrollBarVisiblePolicy, (int)value);
        }
        public ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get => (ScrollBarVisiblePolicy)Get1<int>(elm_scroller_policy_get);
            set => Set(elm_scroller_policy_set, (int)value, (int)VerticalScrollBarVisiblePolicy);
        }

        public Rect CurrentRegion
        {
            get
            {
                int x, y, w, h;
                elm_scroller_region_get(obj.RealHandle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        public int VerticalPageScrollLimit
        {
            get => Get2<int>(elm_scroller_page_scroll_limit_get);
            set => Set(elm_scroller_page_scroll_limit_set, HorizontalPageScrollLimit, value);
        }
        public int HorizontalPageScrollLimit
        {
            get => Get1<int>(elm_scroller_page_scroll_limit_get);
            set => Set(elm_scroller_page_scroll_limit_set, value, VerticalPageScrollLimit);
        }

        public int HorizontalPageSize
        {
            get => Get1<int>(elm_scroller_page_size_get);
            set => Set(elm_scroller_page_size_set, value, VerticalPageSize);
        }

        public int VerticalPageSize
        {
            get => Get2<int>(elm_scroller_page_size_get);
            set => Set(elm_scroller_page_size_set, HorizontalPageSize, value);
        }

        public bool VerticalSnap
        {
            get => Get2<bool>(elm_scroller_page_snap_get);
            set => Set(elm_scroller_page_snap_set, HorizontalSnap, value);
        }
        public bool HorizontalSnap
        {
            get => Get1<bool>(elm_scroller_page_snap_get);
            set => Set(elm_scroller_page_snap_set, value, VerticalSnap);
        }
        public int PageHeight
        {
            get => Get2<int>(elm_scroller_page_size_get);
            set => Set(elm_scroller_page_size_set, PageWidth, value);
        }
        public int PageWidth
        {
            get => Get1<int>(elm_scroller_page_size_get);
            set => Set(elm_scroller_page_size_set, value, PageHeight);
        }
        public ScrollSingleDirection SingleDirection
        {
            get => (ScrollSingleDirection)elm_scroller_single_direction_get(obj.RealHandle);
            set => Set(elm_scroller_single_direction_set, (int)value);
        }
        public int HorizontalStepSize
        {
            get => Get1<int>(elm_scroller_step_size_get);
            set => Set(elm_scroller_step_size_set, value, VerticalStepSize);
        }
        public int VerticalStepSize
        {
            get => Get2<int>(elm_scroller_step_size_get);
            set => Set(elm_scroller_step_size_set, HorizontalStepSize, value);
        }
        public bool VerticalLoop
        {
            get => Get2<bool>(elm_scroller_loop_get);
            set => Set(elm_scroller_loop_set, HorizontalLoop, value);
        }
        public bool HorizontalLoop
        {
            get => Get1<bool>(elm_scroller_loop_get);
            set => Set(elm_scroller_loop_set, value, VerticalLoop);
        }
        public double VerticalRelativePageSize
        {
            get => Get2<double>(elm_scroller_page_relative_get);
            set => Set(elm_scroller_page_relative_set, HorizontalRelativePageSize, value);
        }
        public double HorizontalRelativePageSize
        {
            get => Get1<double>(elm_scroller_page_relative_get);
            set => Set(elm_scroller_page_relative_set, value, VerticalRelativePageSize);
        }

        public int LastVerticalPageNumber => Get2<int>(elm_scroller_last_page_get);

        public int LastHorizontalPageNumber => Get1<int>(elm_scroller_last_page_get);

        public int VerticalPageIndex => Get2<int>(elm_scroller_current_page_get);

        public int HorizontalPageIndex => Get1<int>(elm_scroller_current_page_get);

        public int ChildWidth => Get1<int>(elm_scroller_child_size_get);

        public int ChildHeight => Get2<int>(elm_scroller_child_size_get);

        public void MinimumLimit(bool horizontal, bool vertical)
        {
            Set(elm_scroller_content_min_limit, horizontal, vertical);
        }

        public void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated)
        {
            if (animated)
            {
                Set(elm_scroller_page_bring_in, horizontalPageIndex, verticalPageIndex);
            }
            else
            {
                Set(elm_scroller_page_show, horizontalPageIndex, verticalPageIndex);
            }
        }

        public void ScrollTo(Rect region, bool animated)
        {
            if (animated)
            {
                elm_scroller_region_bring_in(obj.RealHandle, region.X, region.Y, region.Width, region.Height);
            }
            else
            {
                elm_scroller_region_show(obj.RealHandle, region.X, region.Y, region.Width, region.Height);
            }
        }

        delegate T Getter<T>(IntPtr handle);
        delegate void Setter<T>(IntPtr handle, T v);
        delegate void DoubleGetter<T>(IntPtr handle, out T v1, out T v2);
        delegate void DoubleSetter<T>(IntPtr handle, T v1, T v2);

        T Get<T>(Getter<T> func) => func(obj.RealHandle);
        void Set<T>(Setter<T> func,  T value) => func(obj.RealHandle, value);

        T Get1<T>(DoubleGetter<T> func)
        {
            T v1, v2;
            func(obj.RealHandle, out v1, out v2);
            return v1;
        }

        T Get2<T>(DoubleGetter<T> func)
        {
            T v1, v2;
            func(obj.RealHandle, out v1, out v2);
            return v2;
        }

        void Set<T>(DoubleSetter<T> func, T v1, T v2) => func(obj.RealHandle, v1, v2);
    }
}
