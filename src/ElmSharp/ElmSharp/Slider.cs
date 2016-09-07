using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class Slider : Layout
    {
        double _minimum = 0.0;
        double _maximum = 1.0;

        Interop.SmartEvent _changed;
        Interop.SmartEvent _delayedChanged;
        Interop.SmartEvent _dragStarted;
        Interop.SmartEvent _dragStopped;

        public Slider(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);

            _delayedChanged = new Interop.SmartEvent(this, Handle, "delay,changed");
            _delayedChanged.On += (s, e) => DelayedValueChanged?.Invoke(this, EventArgs.Empty);

            _dragStarted = new Interop.SmartEvent(this, Handle, "slider,drag,start");
            _dragStarted.On += (s, e) => DragStarted?.Invoke(this, EventArgs.Empty);

            _dragStopped = new Interop.SmartEvent(this, Handle, "slider,drag,stop");
            _dragStopped.On += (s, e) => DragStopped?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public event EventHandler DelayedValueChanged;

        public event EventHandler DragStarted;

        public event EventHandler DragStopped;

        public int SpanSize
        {
            get
            {
                return Interop.Elementary.elm_slider_span_size_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_span_size_set(Handle, value);
            }
        }

        public string UnitFormat
        {
            get
            {
                return Interop.Elementary.elm_slider_unit_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_unit_format_set(Handle, value);
            }
        }

        public string IndicatorFormat
        {
            get
            {
                return Interop.Elementary.elm_slider_indicator_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_format_set(Handle, value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_slider_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_horizontal_set(Handle, value);
            }
        }

        public double Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
                Interop.Elementary.elm_slider_min_max_set(Handle, _minimum, _maximum);
            }
        }

        public double Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                Interop.Elementary.elm_slider_min_max_set(Handle, _minimum, _maximum);
            }
        }

        public double Value
        {
            get
            {
                return Interop.Elementary.elm_slider_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_value_set(Handle, value);
            }
        }

        public double Step
        {
            get
            {
                return Interop.Elementary.elm_slider_step_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_step_set(Handle, value);
            }
        }

        public bool IsInverted
        {
            get
            {
                return Interop.Elementary.elm_slider_inverted_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_inverted_set(Handle, value);
            }
        }

        public bool IsIndicatorVisible
        {
            get
            {
                return Interop.Elementary.elm_slider_indicator_show_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_show_set(Handle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_slider_add(parent);
        }
    }
}
