using System;

namespace ElmSharp
{
    public class Panes : Layout
    {
        Interop.SmartEvent _press;
        Interop.SmartEvent _unpressed;
        public Panes(EvasObject parent) : base(parent)
        {
            _press = new Interop.SmartEvent(this, Handle, "press");
            _unpressed = new Interop.SmartEvent(this, Handle, "unpressed");

            _press.On += (s, e) => Pressed?.Invoke(this, e);
            _unpressed.On += (s, e) => Unpressed?.Invoke(this, e);
        }

        public event EventHandler Pressed;
        public event EventHandler Unpressed;
        public bool IsFixed
        {
            get
            {
                return Interop.Elementary.elm_panes_fixed_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_fixed_set(Handle, value);
            }
        }

        public double Proportion
        {
            get
            {
                return Interop.Elementary.elm_panes_content_left_size_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_left_size_set(Handle, value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_panes_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_horizontal_set(Handle, value);
            }
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_panes_add(parent);
        }
    }
}
