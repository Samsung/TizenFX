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

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// A query is used to retrieve data which satisfies given criteria
    /// </summary>
    /// <remarks>
    /// A query is used to retrieve person, group, speed dial, and log data which satisfies a given criteria, such as an integer property being greater than a given value, or a string property containing a given substring. 
    /// A query needs a filter which can set the conditions for the search.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsQuery : IDisposable
    {
        internal IntPtr _queryHandle;

        /// <summary>
        /// Creates a query.
        /// </summary>
        /// <param name="viewUri">The view URI of a query</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")] 
        public ContactsQuery(string viewUri)
        {
            int error = Interop.Query.ContactsQueryCreate(viewUri, out _queryHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsQuery Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        internal ContactsQuery(IntPtr handle)
        {
            _queryHandle = handle;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~ContactsQuery()
        {
            Dispose(false);
        }
        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases all resources used by the ContactsQuery.
        /// </summary>
        /// <param name="disposing">Disposing by User</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here
            }

            if (!disposedValue)
            {
                int error = Interop.Query.ContactsQueryDestroy(_queryHandle);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "ContactsQueryDestroy Failed with error " + error);
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ContactsQuery.
        /// It should be called after finished using of the object.
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
        /// <param name="propertyIdArray">The property ID array </param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetProjection(uint[] propertyIdArray)
        {
            if (propertyIdArray == null)
            {
                throw new ArgumentException("Invalid Parameters Provided");
            }

            int error = Interop.Query.ContactsQuerySetProjection(_queryHandle, propertyIdArray, propertyIdArray.Length);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "SetProjection Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Sets the "distinct" option for projection.
        /// </summary>
        /// <param name="set">If true it is set, otherwise if false it is unset</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetDistinct(bool set)
        {
            int error = Interop.Query.ContactsQuerySetDistinct(_queryHandle, set);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "SetDistinct Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Sets the filter for a query.
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetFilter(ContactsFilter filter)
        {
            int error = Interop.Query.ContactsQuerySetFilter(_queryHandle, filter._filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "SetFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Sets the sort mode for a query.
        /// </summary>
        /// <param name="propertyId">The property ID to sort</param>
        /// <param name="isAscending">If true it sorts in the ascending order, otherwise if false it sorts in the descending order</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetSort(uint propertyId, bool isAscending)
        {
            int error = Interop.Query.ContactsQuerySetSort(_queryHandle, propertyId, isAscending);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "SetSort Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }
    }
}
