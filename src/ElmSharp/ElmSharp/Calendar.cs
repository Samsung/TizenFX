using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    public class Calendar : Layout
    {
        private Interop.SmartEvent _changed;
        private DateTime _cacheSelectedDate;
        private Interop.SmartEvent _displayedMonthChanged;
        private int _cacheDisplayedMonth;

        public Calendar(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (sender, e) =>
            {
                DateTime selectedDate = SelectedDate;
                DateChanged?.Invoke(this, new DateChangedEventArgs(_cacheSelectedDate, selectedDate));
                _cacheSelectedDate = selectedDate;
            };

            _displayedMonthChanged = new Interop.SmartEvent(this, Handle, "display,changed");
            _displayedMonthChanged.On += (sender, e) =>
            {
                int currentDisplayedMonth = SelectedDate.Month;
                DisplayedMonthChanged?.Invoke(this, new DisplayedMonthChangedEventArgs(_cacheDisplayedMonth, currentDisplayedMonth));
                _cacheDisplayedMonth = currentDisplayedMonth;
            };
        }

        public event EventHandler<DateChangedEventArgs> DateChanged;

        public event EventHandler<DisplayedMonthChangedEventArgs> DisplayedMonthChanged;

        public int MinimumYear
        {
            get
            {
                int minimumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(Handle, out minimumYear, out unused);
                return minimumYear;
            }
            set
            {
                int maximumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(Handle, out unused, out maximumYear);
                Interop.Elementary.elm_calendar_min_max_year_set(Handle, value, maximumYear);
            }
        }

        public int MaximumYear
        {
            get
            {
                int maximumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(Handle, out unused, out maximumYear);
                return maximumYear;
            }
            set
            {
                int minimumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(Handle, out minimumYear, out unused);
                Interop.Elementary.elm_calendar_min_max_year_set(Handle, minimumYear, value);
            }
        }

        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                return (DayOfWeek)Interop.Elementary.elm_calendar_first_day_of_week_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_calendar_first_day_of_week_set(Handle, (int)value);
            }
        }

        public IReadOnlyList<string> WeekDayNames
        {
            get
            {
                IntPtr stringArrayPtr = Interop.Elementary.elm_calendar_weekdays_names_get(Handle);
                string[] stringArray;
                IntPtrToStringArray(stringArrayPtr, 7, out stringArray);
                return stringArray;
            }
            set
            {
                if (value != null && value.Count == 7)
                {
                    Interop.Elementary.elm_calendar_weekdays_names_set(Handle, value.ToArray());
                }
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                var tm = new Interop.Elementary.tm();
                Interop.Elementary.elm_calendar_selected_time_get(Handle, out tm);
                return ConvertToDateTime(tm);
            }
            set
            {
                var tm = ConvertToTM(value);
                Interop.Elementary.elm_calendar_selected_time_set(Handle, ref tm);
                _cacheSelectedDate = value;
            }
        }

        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_calendar_interval_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_calendar_interval_set(Handle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_calendar_add(parent.Handle);
        }

        private static DateTime ConvertToDateTime(Interop.Elementary.tm tm)
        {
            DateTime date = new DateTime(tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday, tm.tm_hour, tm.tm_min, tm.tm_sec);
            return date;
        }

        private static Interop.Elementary.tm ConvertToTM(DateTime date)
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

        static private void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];

            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);

            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
            }
        }
    }
}
