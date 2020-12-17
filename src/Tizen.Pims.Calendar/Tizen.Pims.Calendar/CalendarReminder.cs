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
    /// A class for the reminder for an event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    /// <remarks>
    /// The client who wants to be alerted at a specific time should register MIME ("application/x-tizen.calendar.reminder") type in manifest.xml file.
    /// </remarks>
    public class CalendarReminder:IDisposable
    {
#region IDisposable Support
        private bool disposedValue = false;

        internal CalendarReminder()
        {
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the CalendarReminder.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources, false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by the CalendarReminder.
        /// It should be called after it has finished using the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        private static readonly Interop.Reminder.ReminderAlertedCallback _reminderAlertedCallback = (string param, IntPtr userData) =>
        {
            ReminderAlertedEventArgs args = new ReminderAlertedEventArgs(param);
            s_reminderAlerted?.Invoke(null, args);
        };

        private static event EventHandler<ReminderAlertedEventArgs> s_reminderAlerted;

        /// <summary>
        /// The Reminder event is triggered when the alarm is alerted.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<ReminderAlertedEventArgs> ReminderAlerted
        {
            add
            {
                Log.Debug(Globals.LogTag, "Add Reminder");

                if (s_reminderAlerted == null)
                {
                    int error = Interop.Reminder.Add(_reminderAlertedCallback, IntPtr.Zero);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "Add reminder Failed with error " + error);
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
                    int error = Interop.Reminder.Remove(_reminderAlertedCallback, IntPtr.Zero);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "Remove reminder Failed with error " + error);
                    }
                }
            }
        }
    }
}
