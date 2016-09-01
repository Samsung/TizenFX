using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public class NaviframeEventArgs : EventArgs
    {
        public EvasObject Content { get; set; }
    }
    public class Naviframe : Widget
    {
        Interop.SmartEvent _transitionFinished;
        readonly List<NaviItem> _itemStack = new List<NaviItem>();
        public Naviframe(EvasObject parent) : base(parent)
        {
            _transitionFinished = new Interop.SmartEvent(this, Handle, "transition,finished");
            _transitionFinished.On += (s, e) => AnimationFinished?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<NaviframeEventArgs> Popped;
        public event EventHandler AnimationFinished;
        public IReadOnlyList<NaviItem> NavigationStack
        {
            get { return _itemStack; }
        }

        public bool PreserveContentOnPop
        {
            get
            {
                return Interop.Elementary.elm_naviframe_content_preserve_on_pop_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_content_preserve_on_pop_set(Handle, value);
            }
        }

        public bool DefaultBackButtonEnabled
        {
            get
            {
                return Interop.Elementary.elm_naviframe_prev_btn_auto_pushed_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_prev_btn_auto_pushed_set(Handle, value);
            }
        }

        public NaviItem Push(EvasObject content)
        {
            return Push(content, null);
        }
        public NaviItem Push(EvasObject content, string title)
        {
            IntPtr item = Interop.Elementary.elm_naviframe_item_push(Handle, title, IntPtr.Zero, IntPtr.Zero, content.Handle, null);
            NaviItem naviItem = NaviItem.FromNativeHandle(item, content);
            _itemStack.Add(naviItem);
            naviItem.Popped += (s, e) =>
            {
                _itemStack.Remove(naviItem);
                Popped?.Invoke(this, new NaviframeEventArgs() { Content = naviItem.Content });
            };
            return naviItem;
        }

        public NaviItem InsertBefore(NaviItem before, EvasObject content)
        {
            return InsertBefore(before, content);
        }
        public NaviItem InsertBefore(NaviItem before, EvasObject content, string title)
        {
            IntPtr item = Interop.Elementary.elm_naviframe_item_insert_before(Handle, before, title, IntPtr.Zero, IntPtr.Zero, content, null);
            NaviItem naviItem = NaviItem.FromNativeHandle(item, content);
            int idx = _itemStack.IndexOf(before);
            _itemStack.Insert(idx, naviItem);
            return naviItem;
        }

        public void Pop()
        {
            Interop.Elementary.elm_naviframe_item_pop(Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_naviframe_add(parent.Handle);
        }
    }
}
