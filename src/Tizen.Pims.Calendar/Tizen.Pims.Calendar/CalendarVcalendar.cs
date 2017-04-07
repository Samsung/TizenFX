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
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// </summary>
    public class CalendarVcalendar
    {
        internal CalendarVcalendar()
        {
        }

        public delegate bool ParseDelegate(CalendarRecord record);

        /// <summary>
        /// Retrieves a vcalendar stream from a calendar list.
        /// </summary>
        /// <param name="list">The calendar list</param>
        /// <returns>
        /// The composed stream.
        /// </returns>
        public static string Compose(CalendarList list)
        {
            string stream;
            int error = Interop.Calendar.Vcalendar.Compose(list._listHandle, out stream);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MakeVcalendar Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return stream;
        }

        /// <summary>
        /// Retrieves all calendars from a vcalendar stream.
        /// </summary>
        /// <param name="stream">The vcalendar stream</param>
        /// <returns>
        /// List of records
        /// </returns>
        public static CalendarList Parse(string stream)
        {
            int error = 0;
            IntPtr _listHandle;
            error = Interop.Calendar.Vcalendar.Parse(stream, out _listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Parse Vcalendar Failed [" + error + "]");
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarList(_listHandle);
        }

        /// <summary>
        /// Parse vcalendar file with foreach
        /// </summary>
        /// <param name="path">The file path of the vCalendar stream file</param>
        /// <param name="callback"></param>
        public static void ParseForEach(string path, ParseDelegate callback)
        {
            int error = 0;

            Interop.Calendar.Vcalendar.ParseCallback cb = (IntPtr handle, IntPtr data) =>
            {
                return callback(new CalendarRecord(handle, true));
            };

            error = Interop.Calendar.Vcalendar.ParseForEach(path, cb, IntPtr.Zero);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Parse foreach Vcalendar Failed [" + error + "]");
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
