using System;

namespace ElmSharp
{
    public class NaviItem : ItemObject
    {
        EvasObject _content;
        bool _isPopped;
        Interop.Elementary.Elm_Naviframe_Item_Pop_Cb _popped;
        NaviItem(IntPtr handle, EvasObject content) : base(handle)
        {
            _isPopped = false;
            _content = content;
            _popped = (d, i) =>
            {
                _isPopped = true;
                Popped?.Invoke(this, EventArgs.Empty);
                return true;
            };
        }

        public event EventHandler Popped;

        public EvasObject Content
        {
            get { return _content; }
        }

        public bool TitleBarVisible
        {
            get
            {
                return Interop.Elementary.elm_naviframe_item_title_enabled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_item_title_enabled_set(Handle, value, false);
            }
        }

        protected override void OnInvalidate()
        {
            if (!_isPopped)
                Popped?.Invoke(this, EventArgs.Empty);
        }

        internal static NaviItem FromNativeHandle(IntPtr handle, EvasObject content)
        {
            return new NaviItem(handle, content);
        }
    }
}
