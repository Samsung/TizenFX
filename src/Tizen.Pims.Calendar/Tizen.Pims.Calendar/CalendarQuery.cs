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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A query is used to retrieve data which satisfies given criteria.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    /// <remarks>
    /// A query is used to retrieve calendar data which satisfies a given criteria,
    /// such as an integer property being greater than a given value,
    /// or a string property containing a given substring.
    /// A query needs a filter which can set the conditions for the search.
    /// </remarks>
    public class CalendarQuery:IDisposable
    {
        internal IntPtr _queryHandle;

        /// <summary>
        /// Creates a query.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a query</param>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarQuery(string viewUri)
        {
            int error = Interop.Query.Create(viewUri, out _queryHandle);
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

        /// <summary>
        /// Destructor
        /// </summary>
        ~CalendarQuery()
        {
            Dispose(false);
        }

#region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the CalendarQuery.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Query.Destroy(_queryHandle);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "CalendarQueryDestroy Failed with error " + error);
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the CalendarQuery.
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
        /// Adds property IDs for projection.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyIdArray">The property ID array </param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void SetProjection(uint[] propertyIdArray)
        {
            if (propertyIdArray == null)
            {
                throw new ArgumentException("Invalid Parameters Provided");
            }

            int error = Interop.Query.SetProjection(_queryHandle, propertyIdArray, propertyIdArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetProjection Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the "distinct" option for projection.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="set">If true it is set, otherwise if false it is unset</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        public void SetDistinct(bool set)
        {
            int error = Interop.Query.SetDistinct(_queryHandle, set);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetDistinct Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the filter for a query.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="filter">The filter</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void SetFilter(CalendarFilter filter)
        {
            int error = Interop.Query.SetFilter(_queryHandle, filter._filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Sets the sort mode for a query.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID to sort</param>
        /// <param name="isAscending">If true it sorts in the ascending order, otherwise if false it sorts in the descending order</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void SetSort(uint propertyId, bool isAscending)
        {
            int error = Interop.Query.SetSort(_queryHandle, propertyId, isAscending);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "SetSort Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
