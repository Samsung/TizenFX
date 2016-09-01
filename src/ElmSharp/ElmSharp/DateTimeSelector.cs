using System;

namespace ElmSharp
{
    public enum DateTimeFieldType
    {
        Year,
        Month,
        Date,
        Hour,
        Minute,
        AmPm
    }

    public class DateTimeSelector : Layout
    {
        Interop.SmartEvent _changed;
        DateTime _cacheDateTime;

        public DateTimeSelector(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (s, e) =>
            {
                DateTime newDateTime = DateTime;
                DateTimeChanged?.Invoke(this, new DateChangedEventArgs(_cacheDateTime, newDateTime));
                DateTime = newDateTime;
            };
        }

        public event EventHandler<DateChangedEventArgs> DateTimeChanged;

        public string Format
        {
            get
            {
                return Interop.Elementary.elm_datetime_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_datetime_format_set(Handle, value);
            }
        }

        public DateTime MaximumDateTime
        {
            get
            {
                var tm = new Interop.Elementary.tm();
                Interop.Elementary.elm_datetime_value_max_get(Handle, ref tm);
                return ConvertToDateTime(tm);
            }
            set
            {
                var tm = ConvertToTM(value);
                Interop.Elementary.elm_datetime_value_max_set(Handle, ref tm);
            }
        }

        public DateTime MinimumDateTime
        {
            get
            {
                var tm = new Interop.Elementary.tm();
                Interop.Elementary.elm_datetime_value_min_get(Handle, ref tm);
                return ConvertToDateTime(tm);
            }
            set
            {
                var tm = ConvertToTM(value);
                Interop.Elementary.elm_datetime_value_min_set(Handle, ref tm);
            }
        }

        public DateTime DateTime
        {
            get
            {
                var tm = new Interop.Elementary.tm();
                Interop.Elementary.elm_datetime_value_get(Handle, ref tm);
                return ConvertToDateTime(tm);
            }
            set
            {
                var tm = ConvertToTM(value);
                Interop.Elementary.elm_datetime_value_set(Handle, ref tm);
                _cacheDateTime = value;
            }
        }

        public bool IsFieldVisible(DateTimeFieldType type)
        {
            return Interop.Elementary.elm_datetime_field_visible_get(Handle, (int) type);
        }

        public void SetFieldLimit(DateTimeFieldType type, int minimum, int maximum)
        {
            Interop.Elementary.elm_datetime_field_limit_set(Handle, (int)type, minimum, maximum);
        }

        public void SetFieldVisible(DateTimeFieldType type, bool visible)
        {
            Interop.Elementary.elm_datetime_field_visible_set(Handle, (int)type, visible);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_datetime_add(parent.Handle);
        }

        DateTime ConvertToDateTime(Interop.Elementary.tm tm)
        {
            DateTime date = new DateTime(tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday, tm.tm_hour, tm.tm_min, tm.tm_sec);
            return date;
        }

        Interop.Elementary.tm ConvertToTM(DateTime date)
        {
            Interop.Elementary.tm tm = new Interop.Elementary.tm();
            tm.tm_sec = date.Second;
            tm.tm_min = date.Minute;
            tm.tm_hour = date.Hour;
            tm.tm_mday = date.Day;
            tm.tm_mon = date.Month - 1;
            tm.tm_year = date.Year - 1900;
            tm.tm_wday = (int)date.DayOfWeek;
            tm.tm_yday = date.DayOfYear;
            tm.tm_isdst = date.IsDaylightSavingTime() ? 1 : 0;
            return tm;
        }
    }
}
