using System;

namespace ElmSharp
{
    public class ProgressBar : Layout
    {
        Interop.SmartEvent _changed;

        public ProgressBar(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (s, e) =>
            {
                ValueChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler ValueChanged;

        public bool IsPulseMode
        {
            get
            {
                return Interop.Elementary.elm_progressbar_pulse_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_pulse_set(Handle, value);
            }
        }

        public double Value
        {
            get
            {
                return Interop.Elementary.elm_progressbar_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_value_set(Handle, value);
            }
        }

        public int SpanSize
        {
            get
            {
                return Interop.Elementary.elm_progressbar_span_size_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_span_size_set(Handle, value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_progressbar_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_horizontal_set(Handle, value);
            }
        }

        public bool IsInverted
        {
            get
            {
                return Interop.Elementary.elm_progressbar_inverted_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_inverted_set(Handle, value);
            }
        }

        public string UnitFormat
        {
            get
            {
                return Interop.Elementary.elm_progressbar_unit_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_unit_format_set(Handle, value);
            }
        }

        public void PlayPulse()
        {
            Interop.Elementary.elm_progressbar_pulse(Handle, true);
        }

        public void StopPluse()
        {
            Interop.Elementary.elm_progressbar_pulse(Handle, false);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_progressbar_add(parent);
        }
    }
}
