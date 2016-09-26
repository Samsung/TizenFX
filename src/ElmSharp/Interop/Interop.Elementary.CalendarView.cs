using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_calendar_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_calendar_weekdays_names_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_weekdays_names_set(IntPtr obj, string[] weekdays);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_min_max_year_set(IntPtr obj, int min, int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_min_max_year_get(IntPtr obj, out int min, out int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_selected_time_set(IntPtr obj, ref Libc.SystemTime selectedtime);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_selected_time_get(IntPtr obj, ref Libc.SystemTime selectedtime);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_first_day_of_week_set(IntPtr obj, int day);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_calendar_first_day_of_week_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_selectable_set(IntPtr obj, int SelectedField);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_calendar_selectable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_calendar_displayed_time_get(IntPtr obj, out Libc.SystemTime displayedtime);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_interval_set(IntPtr obj, double interval);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_calendar_interval_get(IntPtr obj);
    }
}
