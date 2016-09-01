using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class ToolbarItem : ItemObject
    {
        string _icon;
        string _text;
        internal ToolbarItem(string text, string icon) : base(IntPtr.Zero)
        {
            _text = text;
            _icon = icon;
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                Interop.Elementary.elm_toolbar_item_icon_set(Handle, value);
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                SetPartText(null, value);
            }
        }
        public bool Enabled
        {
            get
            {
                return !Interop.Elementary.elm_object_disabled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_object_disabled_set(Handle, !value);
            }
        }
        public bool IsSeparator
        {
            get
            {
                return Interop.Elementary.elm_toolbar_item_separator_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_item_separator_set(Handle, value);
            }
        }
        public bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_toolbar_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_item_selected_set(Handle, value);
            }
        }

        public event EventHandler Selected;
        public event EventHandler LongPressed;
        public event EventHandler Clicked;

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
        internal void SendLongPressed()
        {
            LongPressed?.Invoke(this, EventArgs.Empty);
        }
        internal void SendClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
