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
using static Interop.Calendar.Query;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// </summary>
    public class CalendarQuery : IDisposable
    {
        internal IntPtr _queryHandle;

        /// <summary>
        /// Creates a query.
        /// </summary>
        /// <param name="viewUri">The view URI of a query</param>
        public CalendarQuery(string viewUri)
        {
            int error = Interop.Calendar.Query.Create(viewUri, out _queryHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarQuery Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        internal CalendarQuery(IntPtr handle)
        {
            _queryHandle = handle;
        }

        ~CalendarQuery()
        {
            Dispose(false);
        }

#region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Calendar.Query.Destroy(_queryHandle);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "CalendarQueryDestroy Failed with error " + error);
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
        /// Adds property IDs for projection.
        /// </summary>
        /// <param name="propertyIdArray">The property ID array </param>
        public void SetProjection(uint[] propertyIdArray)
        {
            int error = Interop.Calendar.Query.SetProjection(_queryHandle, propertyIdArray, propertyIdArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetProjection Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the "distinct" option for projection.
        /// </summary>
        /// <param name="set">If true it is set, otherwise if false it is unset</param>
        public void SetDistinct(bool set)
        {
            int error = Interop.Calendar.Query.SetDistinct(_queryHandle, set);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetDistinct Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the filter for a query.
        /// </summary>
        /// <param name="filter">The filter</param>
        public void SetFilter(CalendarFilter filter)
        {
            int error = Interop.Calendar.Query.SetFilter(_queryHandle, filter._filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the sort mode for a query.
        /// </summary>
        /// <param name="propertyId">The property ID to sort</param>
        /// <param name="isAscending">If true it sorts in the ascending order, otherwise if false it sorts in the descending order</param>
        public void SetSort(uint propertyId, bool isAscending)
        {
            int error = Interop.Calendar.Query.SetSort(_queryHandle, propertyId, isAscending);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetSort Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
