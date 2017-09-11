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

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// A list of records with the same type
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsList:IDisposable
    {
        private Int64 _memoryPressure = 20;
        internal IntPtr _listHandle;
        internal ContactsList(IntPtr handle)
        {
            int count;

            _listHandle = handle;
            int error = Interop.List.ContactsListGetCount(_listHandle, out count);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsList Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _memoryPressure += count * ContactsViews.Record.AverageSize;
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Creates a contacts record list.
        /// </summary>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsList()
        {
            int error = Interop.List.ContactsListCreate(out _listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsList Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~ContactsList()
        {
            Dispose(false);
        }

        /// <summary>
        /// The count of contact entity.
        /// </summary>
        /// <value>The count of contact entity.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Count
        {
            get
            {
                int count = -1;
                int error = Interop.List.ContactsListGetCount(_listHandle, out count);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "ContactsList Count Failed with error " + error);
                }
                return count;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases all resources used by the ContactsList.
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
                int error = Interop.List.ContactsListDestroy(_listHandle, true);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "ContactsListDestroy Failed with error " + error);
                }

                disposedValue = true;
                GC.RemoveMemoryPressure(_memoryPressure);
            }
        }

        /// <summary>
        /// Releases all resources used by the ContactsList.
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
        /// Adds a record to the contacts list.
        /// </summary>
        /// <param name="record">The record to add</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void AddRecord(ContactsRecord record)
        {
            int error = Interop.List.ContactsListAdd(_listHandle, record._recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            record._disposedValue = true;
            _memoryPressure += ContactsViews.Record.AverageSize;
        }

        /// <summary>
        /// Removes a record from the contacts list.
        /// </summary>
        /// <param name="record">The record to remove</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void RemoveRecord(ContactsRecord record)
        {
            int error = Interop.List.ContactsListRemove(_listHandle, record._recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "RemoveRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            record._disposedValue = false;
            _memoryPressure -= ContactsViews.Record.AverageSize;
        }

        /// <summary>
        /// Retrieves a record from the contacts list.
        /// </summary>
        /// <returns>
        /// contacts record
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsRecord GetCurrentRecord()
        {
            IntPtr handle;
            int error = Interop.List.ContactsListGetCurrentRecordP(_listHandle, out handle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetCurrentRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsRecord(handle, true);
        }

        /// <summary>
        /// Moves a contacts list to the previous position.
        /// </summary>
        /// <returns>
        /// When the cursor is already at the first position, it returns false.
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool MovePrevious()
        {
            int error = Interop.List.ContactsListPrev(_listHandle);

            if ((int)ContactsError.None == error)
            {
                return true;
            }
            else if (Count > 0 && (int)ContactsError.NoData == error)
            {
                Log.Debug(Globals.LogTag, "Nodata MovePrevious" + error);
                return false;
            }
            else
            {
                Log.Error(Globals.LogTag, "MovePrevious Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Moves a contacts list to the next position.
        /// </summary>
        /// <returns>
        /// When the cursor is already at the last position, it returns false.
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool MoveNext()
        {
            int error = Interop.List.ContactsListNext(_listHandle);

            if ((int)ContactsError.None == error)
            {
                return true;
            }
            else if (Count > 0 && (int)ContactsError.NoData == error)
            {
                Log.Debug(Globals.LogTag, "Nodata MoveNext" + error);
                return false;
            }
            else
            {
                Log.Error(Globals.LogTag, "MoveNext Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Moves a contacts list to the first position.
        /// </summary>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public void MoveFirst()
        {
            int error = Interop.List.ContactsListFirst(_listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "MoveFirst Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Moves a contacts list to the last position.
        /// </summary>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public void MoveLast()
        {
            int error = Interop.List.ContactsListLast(_listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "MoveFirst Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }
    }
}
