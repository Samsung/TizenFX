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

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// Parsing the vCalendar file callback function.
    /// </summary>
    /// <param name="record">The record.</param>
    /// <returns>true to continue with the next iteration of the loop, otherwise false to break out of the loop.</returns>
    /// <since_tizen> 4 </since_tizen>
    public delegate bool ParseCallback(CalendarRecord record);

    /// <summary>
    /// A class for parsing and composing the vCalendar.
    /// </summary>
    /// <remarks>
    /// It's based on the vCalendar v2.0 specification.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public static class CalendarVcalendar
    {
        /// <summary>
        /// Retrieves a vCalendar stream from a calendar list.
        /// </summary>
        /// <param name="list">The calendar list.</param>
        /// <returns>
        /// The composed stream.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static string Compose(CalendarList list)
        {
            string stream;
            int error = Interop.Vcalendar.Compose(list._listHandle, out stream);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MakeVcalendar Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return stream;
        }

        /// <summary>
        /// Retrieves all the calendars from a vCalendar stream.
        /// </summary>
        /// <param name="stream">The vCalendar stream.</param>
        /// <returns>
        /// The record list.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static CalendarList Parse(string stream)
        {
            int error = 0;
            IntPtr _listHandle;
            error = Interop.Vcalendar.Parse(stream, out _listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Parse Vcalendar Failed [" + error + "]");
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarList(_listHandle);
        }

        /// <summary>
        /// Parses the vCalendar file with ForEach.
        /// </summary>
        /// <param name="path">The file path of the vCalendar stream file.</param>
        /// <param name="callback">The callback function to invoke.</param>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void ParseForEach(string path, ParseCallback callback)
        {
            int error = 0;

            Interop.Vcalendar.ParseCallback cb = (IntPtr handle, IntPtr data) =>
            {
                return callback(new CalendarRecord(handle, true));
            };

            error = Interop.Vcalendar.ParseForEach(path, cb, IntPtr.Zero);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Parse ForEach Vcalendar Failed [" + error + "]");
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
