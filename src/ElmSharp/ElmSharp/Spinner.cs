using System;

namespace ElmSharp
{
    public class Spinner : Layout
    {
        double _minimum = 0.0;
        double _maximum = 100.0;

        Interop.SmartEvent _changed;
        Interop.SmartEvent _delayedChanged;

        public Spinner(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);

            _delayedChanged = new Interop.SmartEvent(this, Handle, "delay,changed");
            _delayedChanged.On += (s, e) => DelayedValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public event EventHandler DelayedValueChanged;

        public string LabelFormat
        {
            get
            {
                return Interop.Elementary.elm_spinner_label_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_label_format_set(Handle, value);
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
                Interop.Elementary.elm_spinner_min_max_set(Handle, _minimum, _maximum);
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
                Interop.Elementary.elm_spinner_min_max_set(Handle, _minimum, _maximum);
            }
        }

        public double Step
        {
            get
            {
                return Interop.Elementary.elm_spinner_step_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_step_set(Handle, value);
            }
        }

        public double Value
        {
            get
            {
                return Interop.Elementary.elm_spinner_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_value_set(Handle, value);
            }
        }

        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_spinner_interval_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_interval_set(Handle, value);
            }
        }

        public double RoundBase
        {
            get
            {
                return Interop.Elementary.elm_spinner_base_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_base_set(Handle, value);
            }
        }

        public int RoundValue
        {
            get
            {
                return Interop.Elementary.elm_spinner_round_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_round_set(Handle, value);
            }
        }

        public bool IsWrapEnabled
        {
            get
            {
                return Interop.Elementary.elm_spinner_wrap_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_wrap_set(Handle, value);
            }
        }

        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_spinner_editable_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_spinner_editable_set(Handle, value);
            }
        }


        public void AddSpecialValue(double value, string label)
        {
            Interop.Elementary.elm_spinner_special_value_add(Handle, value, label);
        }

        public void RemoveSpecialValue(double value)
        {
            Interop.Elementary.elm_spinner_special_value_del(Handle, value);
        }

        public string GetSpecialValue(double value)
        {
            return Interop.Elementary.elm_spinner_special_value_get(Handle, value);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_spinner_add(parent);
        }
    }
}
