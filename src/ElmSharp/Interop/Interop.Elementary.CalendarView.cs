/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        internal enum Elm_Calendar_Mark_Repeat_Type
        {
            ELM_CALENDAR_UNIQUE = 0, /* Default value. Marks will be displayed only on event day. */
            ELM_CALENDAR_DAILY, /* Marks will be displayed every day after event day (inclusive). */
            ELM_CALENDAR_WEEKLY, /* Marks will be displayed every week after event day (inclusive) */
            ELM_CALENDAR_MONTHLY, /* Marks will be displayed every month day that coincides to event day. */
            ELM_CALENDAR_ANNUALLY, /* Marks will be displayed every year that coincides to event day (and month). */
            LM_CALENDAR_LAST_DAY_OF_MONTH /* Marks will be displayed every last day of month after event day (inclusive). */
        };

        internal enum Elm_Calendar_Select_Mode
        {
            ELM_CALENDAR_SELECT_MODE_DEFAULT = 0, /* Default value. a day is always selected. */
            ELM_CALENDAR_SELECT_MODE_ALWAYS, /* a day is always selected. */
            ELM_CALENDAR_SELECT_MODE_NONE, /* None of the days can be selected. */
            ELM_CALENDAR_SELECT_MODE_ONDEMAND /* User may have selected a day or not. */
        }

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

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_select_mode_set(IntPtr obj, Elm_Calendar_Select_Mode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_calendar_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_calendar_mark_add(IntPtr obj, string type, ref Libc.SystemTime date, Elm_Calendar_Mark_Repeat_Type repeatType);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_mark_del(IntPtr markItem);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_marks_draw(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_marks_clear(IntPtr obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate string Elm_Calendar_Format_Cb(ref Libc.SystemTime date);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_calendar_format_function_set(IntPtr obj, Elm_Calendar_Format_Cb format_function);
    }
}