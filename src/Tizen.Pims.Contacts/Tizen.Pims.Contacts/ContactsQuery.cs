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
using static Interop.Contacts;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// </summary>
    public class ContactsQuery : IDisposable
    {
        internal IntPtr _queryHandle;

        /// <summary>
        /// Creates a query.
        /// </summary>
        /// <param name="viewUri">The view URI of a query</param>
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

        ~ContactsQuery()
        {
            Dispose(false);
        }
        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                int error = Interop.Query.ContactsQueryDestroy(_queryHandle);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "ContactsQueryDestroy Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
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
