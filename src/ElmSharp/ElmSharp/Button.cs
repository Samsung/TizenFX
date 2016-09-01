using System;

namespace ElmSharp
{
    public class Button : Layout
    {
        private Interop.SmartEvent _clicked;
        private Interop.SmartEvent _repeated;
        private Interop.SmartEvent _pressed;
        private Interop.SmartEvent _released;

        public Button(EvasObject parent) : base(parent)
        {
            _clicked = new Interop.SmartEvent(this, Handle, "clicked");
            _repeated = new Interop.SmartEvent(this, Handle, "repeated");
            _pressed = new Interop.SmartEvent(this, Handle, "pressed");
            _released = new Interop.SmartEvent(this, Handle, "unpressed");

            _clicked.On += (sender, e) =>
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            };

            _repeated.On += (sender, e) =>
            {
                Repeated?.Invoke(this, EventArgs.Empty);
            };

            _pressed.On += (sender, e) =>
            {
                Pressed?.Invoke(this, EventArgs.Empty);
            };

            _released.On += (sender, e) =>
            {
                Released?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler Clicked;

        public event EventHandler Repeated;

        public event EventHandler Pressed;

        public event EventHandler Released;

        public bool AutoRepeat
        {
            get
            {
                return !Interop.Elementary.elm_button_autorepeat_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_set(Handle, value);
            }
        }

        public double AutoRepeatInitialTime
        {
            get
            {
                return Interop.Elementary.elm_button_autorepeat_initial_timeout_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_initial_timeout_set(Handle, value);
            }
        }

        public double AutoRepeatGapTimeout
        {
            get
            {
                return Interop.Elementary.elm_button_autorepeat_gap_timeout_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_gap_timeout_set(Handle, value);
            }
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_button_add(parent.Handle);
        }
    }
}