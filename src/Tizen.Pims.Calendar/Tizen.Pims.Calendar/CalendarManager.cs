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
    /// A class for managing calendar information. It allows applications to use calendar service.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CalendarManager : IDisposable
    {
        private CalendarDatabase _db = null;

        /// <summary>
        /// Create a manager.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public CalendarManager()
        {
            int error = Interop.Service.Connect();
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Connect Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _db = new CalendarDatabase();
        }

        /// <summary>
        /// Destroy CalendarManager resource.
        /// </summary>
        ~CalendarManager()
        {
            Dispose(false);
        }

#region IDisposable Support
        /// To detect redundant calls
        private bool disposedValue = false;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the CalendarManager.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Service.Disconnect();
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Disconnect Failed with error " + error);
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the CalendarManager.
        /// It should be called after having finished using of the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        /// <summary>
        /// Get database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The database instance</value>
        public CalendarDatabase Database
        {
            get
            {
                return _db;
            }
        }
    }
}
