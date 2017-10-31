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
    /// Enumeration for name display order.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ContactDisplayOrder
    {
        /// <summary>
        /// First name comes at the first
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        FirstLast,
        /// <summary>
        /// First name comes at the last
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        LastFirst
    };

    /// <summary>
    /// Enumeration for name sorting order.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ContactSortingOrder
    {
        /// <summary>
        /// Contacts are first sorted based on the first name
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        FirstLast,
        /// <summary>
        /// Contacts are first sorted based on the last name
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        LastFirst
    };

    /// <summary>
    /// A class for managing contact information. It allows applications to access contacts database.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsManager : IDisposable
    {
        private ContactsDatabase _db = null;
        private Object thisLock = new Object();
        private Interop.Setting.DisplayOrderChangedCallback _displayOrderChangedCallback;
        private Interop.Setting.SortingOrderChangedCallback _sortingOrderChangedCallback;

        /// <summary>
        /// Creates a ContactsManager.
        /// </summary>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <since_tizen> 4 </since_tizen>
        public ContactsManager()
        {
            int error = Interop.Service.Connect();
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Connect Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _db = new ContactsDatabase();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~ContactsManager()
        {
            Dispose(false);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases all resources used by the ContactsManager.
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
                int error = Interop.Service.Disconnect();
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Disconnect Failed with error " + error);
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ContactsManager.
        /// It should be called after finished using of the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private EventHandler<NameDisplayOrderChangedEventArgs> _nameDisplayOrderChanged;
        private EventHandler<NameSortingOrderChangedEventArgs> _nameSortingOrderChanged;

        /// <summary>
        /// (event) NameDisplayOrderChanged is raised when changing setting value of contacts name display order
        /// </summary>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<NameDisplayOrderChangedEventArgs> NameDisplayOrderChanged
        {
            add
            {
                lock (thisLock)
                {
                    if (_displayOrderChangedCallback == null)
                    {
                        _displayOrderChangedCallback = (ContactDisplayOrder nameDisplayOrder, IntPtr userData) =>
                        {
                            NameDisplayOrderChangedEventArgs args = new NameDisplayOrderChangedEventArgs(nameDisplayOrder);
                            _nameDisplayOrderChanged?.Invoke(this, args);
                        };
                    }

                    if (_nameDisplayOrderChanged == null)
                    {
                        int error = Interop.Setting.AddNameDisplayOrderChangedCB(_displayOrderChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Add NameDisplayOrderChangedCB Failed with error " + error);
                        }
                    }

                    _nameDisplayOrderChanged += value;
                }
            }

            remove
            {
                lock (thisLock)
                {
                    _nameDisplayOrderChanged -= value;

                    if (_nameDisplayOrderChanged == null)
                    {
                        int error = Interop.Setting.RemoveNameDisplayOrderChangedCB(_displayOrderChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Remove StateChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// (event) NameSortingOrderChanged is raised when changing setting value of contacts name sorting order
        /// </summary>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<NameSortingOrderChangedEventArgs> NameSortingOrderChanged
        {
            add
            {
                lock (thisLock)
                {
                    if (_sortingOrderChangedCallback == null)
                    {
                        _sortingOrderChangedCallback = (ContactSortingOrder nameSortingOrder, IntPtr userData) =>
                        {
                            NameSortingOrderChangedEventArgs args = new NameSortingOrderChangedEventArgs(nameSortingOrder);
                            _nameSortingOrderChanged?.Invoke(this, args);
                        };
                    }

                    if (_nameSortingOrderChanged == null)
                    {
                        int error = Interop.Setting.AddNameSortingOrderChangedCB(_sortingOrderChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Add NameSortingOrderChangedCB Failed with error " + error);
                        }
                    }

                    _nameSortingOrderChanged += value;
                }
            }

            remove
            {
                lock (thisLock)
                {
                    _nameSortingOrderChanged -= value;

                    if (_nameSortingOrderChanged == null)
                    {
                        int error = Interop.Setting.RemoveNameSortingOrderChangedCB(_sortingOrderChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Remove StateChanged Failed with error " + error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A ContactsDatabase
        /// </summary>
        /// <value>A ContactsDatabase</value>
        /// <since_tizen> 4 </since_tizen>
        public ContactsDatabase Database
        {
            get
            {
                return _db;
            }
        }

        /// <summary>
        /// A setting value of contacts name display order
        /// </summary>
        /// <value>A setting value of contacts name display order</value>
        /// <remarks>
        /// DisplayName of contacts returned from database are determined by this property
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ContactDisplayOrder NameDisplayOrder
        {
            get
            {
                ContactDisplayOrder contactDisplayOrder;
                int error = Interop.Setting.GetNameDisplayOrder(out contactDisplayOrder);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get NameDisplayOrder Failed with error " + error);
                }
                return contactDisplayOrder;
            }
            set
            {
                int error = Interop.Setting.SetNameDisplayOrder(value);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set NameDisplayOrder Failed with error " + error);
                }
            }
        }

        /// <summary>
        /// A setting value of contacts name sorting order
        /// </summary>
        /// <value>A setting value of contacts name sorting order</value>
        /// <remarks>
        /// Contacts returned from database are first sorted based on the first name or last name by this property
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ContactSortingOrder NameSortingOrder
        {
            get
            {
                ContactSortingOrder contactsSortingOrder;
                int error = Interop.Setting.GetNameSortingOrder(out contactsSortingOrder);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Get NameSortingOrder Failed with error " + error);
                }
                return contactsSortingOrder;
            }
            set
            {
                int error = Interop.Setting.SetNameSortingOrder(value);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Set NameSortingOrder Failed with error " + error);
                }
            }
        }
    }
}
