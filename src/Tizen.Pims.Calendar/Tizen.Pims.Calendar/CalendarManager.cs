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
using static Interop.Calendar.Service;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// </summary>
    public class CalendarManager : IDisposable
    {
        private CalendarDatabase _db = null;

        /// <summary>
        /// Create a manager.
        /// </summary>
        public CalendarManager()
        {
            int error = Interop.Calendar.Service.Connect();
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Connect Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _db = new CalendarDatabase();
        }

        ~CalendarManager()
        {
            Dispose(false);
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Calendar.Service.Disconnect();
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Disconnect Failed with error " + error);
                    throw CalendarErrorFactory.GetException(error);
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
#endregion

        /// <summary>
        /// Get database.
        /// </summary>
        public CalendarDatabase Database
        {
            get
            {
                return _db;
            }
        }
    }
}
