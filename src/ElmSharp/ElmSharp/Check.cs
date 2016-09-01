using System;

namespace ElmSharp
{
    public class Check : Layout
    {
        private Interop.SmartEvent _changed;
        private bool _currentState;

        public Check(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (sender, e) =>
            {
                StateChanged?.Invoke(this, new CheckStateChangedEventArgs(_currentState, IsChecked));
            };
        }

        public event EventHandler<CheckStateChangedEventArgs> StateChanged;

        public bool IsChecked
        {
            get
            {
                _currentState = Interop.Elementary.elm_check_state_get(Handle);
                return _currentState;
            }
            set
            {
                Interop.Elementary.elm_check_state_set(Handle, value);
            }
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_check_add(parent.Handle);
        }
    }
}