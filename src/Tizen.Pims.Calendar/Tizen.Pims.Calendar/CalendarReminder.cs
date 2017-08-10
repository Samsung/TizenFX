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
using static Interop.Calendar.Reminder;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A class for reminder for event.
    /// </summary>
    /// <remarks>
    /// The client who wants to be alerted at specific time should register MIME("application/x-tizen.calendar.reminder") type in manifest.xml file.
    /// </remarks>
    public class CalendarReminder : IDisposable
    {
#region IDisposable Support
        private bool disposedValue = false;

        internal CalendarReminder()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the CalendarReminder.
        /// It should be called after finished using of the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
#endregion

        private static readonly Interop.Calendar.Reminder.ReminderAlertedCallback _reminderAlertedCallback = (string param, IntPtr userData) =>
        {
            ReminderAlertedEventArgs args = new ReminderAlertedEventArgs(param);
            s_reminderAlerted?.Invoke(null, args);
        };

        private static event EventHandler<ReminderAlertedEventArgs> s_reminderAlerted;

        /// <summary>
        /// Reminder event is triggered when the alarm is alerted.
        /// </summary>
        public static event EventHandler<ReminderAlertedEventArgs> ReminderAlerted
        {
            add
            {
                Log.Debug(Globals.LogTag, "Add Reminder");

                if (s_reminderAlerted == null)
                {
                    int error = Interop.Calendar.Reminder.Add(_reminderAlertedCallback, IntPtr.Zero);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "Add reminder Failed with error " + error);
                        throw CalendarErrorFactory.GetException(error);
                    }
                }
                s_reminderAlerted += value;
            }

            remove
            {
                Log.Debug(Globals.LogTag, "Remove Reminder");

                s_reminderAlerted -= value;
                if (s_reminderAlerted == null)
                {
                    /// _reminderAlertedCallback is removed by .Net Core
                    int error = Interop.Calendar.Reminder.Remove(_reminderAlertedCallback, IntPtr.Zero);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "Remove reminder Failed with error " + error);
                        throw CalendarErrorFactory.GetException(error);
                    }
                }
            }
        }
    }
}
