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
using System.Runtime.InteropServices;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// A record represents an actual record in the database
    /// </summary>
    /// <remarks>
    /// A record represents an actual record in the database, but you can also consider it a piece of information, such as an address, a phone number, or a group of contacts. 
    /// A record can be a complex set of data, containing other data. For example, a contact record contains the address property, which is a reference to an address record. 
    /// An address record belongs to a contact record, and its ContactId property is set to the identifier of the corresponding contact. In this case, the address is the child record of the contact and the contact is the parent record.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsRecord : IDisposable
    {
        private string _uri = null;
        private uint _id;
        private Int64 _memoryPressure = ContactsViews.Record.AverageSize;
        internal IntPtr _recordHandle;

        internal ContactsRecord(IntPtr handle)
        {
            _recordHandle = handle;
            IntPtr viewUri;
            int error = Interop.Record.GetUriP(handle, out viewUri);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            GC.AddMemoryPressure(_memoryPressure);
            _uri = Marshal.PtrToStringAnsi(viewUri);
        }

        internal ContactsRecord(IntPtr handle, bool disposedValue)
        {
            _recordHandle = handle;
            _disposedValue = disposedValue;
            IntPtr viewUri;
            int error = Interop.Record.GetUriP(handle, out viewUri);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            if (!_disposedValue)
                GC.AddMemoryPressure(_memoryPressure);
            _uri = Marshal.PtrToStringAnsi(viewUri);
        }

        internal ContactsRecord(IntPtr handle, int id)
        {
            _recordHandle = handle;
            _id = (uint)id;
            IntPtr viewUri;
            int error = Interop.Record.GetUriP(handle, out viewUri);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _uri = Marshal.PtrToStringAnsi(viewUri);
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <param name="viewUri">The view URI</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsRecord(string viewUri)
        {
            int error = Interop.Record.Create(viewUri, out _recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _uri = viewUri;
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~ContactsRecord()
        {
            Dispose(false);
        }

        /// <summary>
        /// The URI of the record
        /// </summary>
        /// <value>The URI of the record</value>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string Uri
        {
            get
            {
                return _uri;
            }
        }

        #region IDisposable Support
        internal bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases all resources used by the ContactsRecord.
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

            if (!_disposedValue)
            {
                int error = Interop.Record.Destroy(_recordHandle, true);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Dispose Failed with error " + error);
                }
                _disposedValue = true;
                GC.RemoveMemoryPressure(_memoryPressure);
            }
        }

        /// <summary>
        /// Releases all resources used by the ContactsRecord.
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
        /// Makes a clone of a record.
        /// </summary>
        /// <returns>A cloned record</returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsRecord Clone()
        {
            IntPtr _clonedRecordHandle;
            int error = Interop.Record.Clone(_recordHandle, out _clonedRecordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Clone Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsRecord(_clonedRecordHandle, (int)_id);
        }

        /// <summary>
        /// Gets a value of the property from a record.
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// The value of the property corresponding to property id.
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public T Get<T>(uint propertyId)
        {
            object parsedValue = null;
            if (typeof(T) == typeof(string))
            {
                string val;
                int error = Interop.Record.GetStr(_recordHandle, propertyId, out val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get String Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(int))
            {
                int val;
                int error = Interop.Record.GetInt(_recordHandle, propertyId, out val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get Int Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(bool))
            {
                bool val;
                int error = Interop.Record.GetBool(_recordHandle, propertyId, out val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get Bool Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(long))
            {
                long val;
                int error = Interop.Record.GetLli(_recordHandle, propertyId, out val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get Long Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(double))
            {
                double val;
                int error = Interop.Record.GetDouble(_recordHandle, propertyId, out val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get Long Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else
            {
                Log.Error(Globals.LogTag, "Not Supported Data Type");
                throw ContactsErrorFactory.CheckAndCreateException((int)ContactsError.NotSupported);
            }
            return (T)parsedValue;
        }

        /// <summary>
        /// Sets a value of the property to a record.
        /// </summary>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <param name="propertyId">The property ID</param>
        /// <param name="value">The value to set</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Set<T>(uint propertyId, T value)
        {
            if (typeof(T) == typeof(string))
            {
                string val = Convert.ToString(value);
                int error = Interop.Record.SetStr(_recordHandle, propertyId, val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set String Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                int val = Convert.ToInt32(value);
                int error = Interop.Record.SetInt(_recordHandle, propertyId, val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set Int Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }
            else if (typeof(T) == typeof(bool))
            {
                bool val = Convert.ToBoolean(value);
                int error = Interop.Record.SetBool(_recordHandle, propertyId, val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set Bool Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }
            else if (typeof(T) == typeof(long))
            {
                long val = Convert.ToInt64(value);
                int error = Interop.Record.SetLli(_recordHandle, propertyId, val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set Long Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }
            else if (typeof(T) == typeof(double))
            {
                double val = Convert.ToDouble(value);
                int error = Interop.Record.SetDouble(_recordHandle, propertyId, val);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get Long Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Not Supported Data Type");
                throw ContactsErrorFactory.CheckAndCreateException((int)ContactsError.NotSupported);
            }
        }

        /// <summary>
        /// Adds a child record to the parent record.
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <param name="childRecord">The child record to add to parent record</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void AddChildRecord(uint propertyId, ContactsRecord childRecord)
        {
            int error = Interop.Record.AddChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddChildRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            childRecord._disposedValue = true;
        }

        /// <summary>
        /// Removes a child record from the parent record.
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <param name="childRecord">The child record to remove from parent record</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public void RemoveChildRecord(uint propertyId, ContactsRecord childRecord)
        {
            int error = Interop.Record.RemoveChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "RemoveChildRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            childRecord._disposedValue = false;
        }

        /// <summary>
        /// Gets the number of child records of a parent record.
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>The number of child records corresponding to property ID</returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public int GetChildRecordCount(uint propertyId)
        {
            int count = 0;
            int error = Interop.Record.GetChildRecordCount(_recordHandle, propertyId, out count);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetChildRecordCount Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return count;
        }

        /// <summary>
        /// Gets a child record from the parent record
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <param name="index">The index of child record</param>
        /// <returns>The record </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsRecord GetChildRecord(uint propertyId, int index)
        {
            IntPtr handle;

            int error = Interop.Record.GetChildRecordAtP(_recordHandle, propertyId, index, out handle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetChildRecord Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsRecord(handle, true);
        }

        /// <summary>
        /// Clones a child record list corresponding to property ID
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsList CloneChildRecordList(uint propertyId)
        {
            IntPtr listHandle;

            int error = Interop.Record.CloneChildRecordList(_recordHandle, propertyId, out listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "CloneChildRecordList Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            ContactsList list = new ContactsList(listHandle);
            return list;
        }
    }
}
