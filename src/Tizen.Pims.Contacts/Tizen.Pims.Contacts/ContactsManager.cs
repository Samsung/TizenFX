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
using static Interop.Contacts;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// Enumeration for name display order.
    /// </summary>
    public enum ContactDisplayOrder
    {
        /// <summary>
        /// First name comes at the first
        /// </summary>
        FirstLast,
        /// <summary>
        /// First name comes at the last
        /// </summary>
        LastFirst
    };

    /// <summary>
    /// Enumeration for name sorting order.
    /// </summary>
    public enum ContactSortingOrder
    {
        /// <summary>
        /// Contacts are first sorted based on the first name
        /// </summary>
        FirstLast,
        /// <summary>
        /// Contacts are first sorted based on the last name
        /// </summary>
        LastFirst
    };

    /// <summary>
    /// A class for managing contact information. It allows applications to use contacts service.
    /// </summary>
    public class ContactsManager : IDisposable
    {
        private ContactsDatabase _db = null;
        private Object thisLock = new Object();
        private Interop.Setting.DisplayOrderChangedCallback _displayOrderDelegate;
        private Interop.Setting.SortingOrderChangedCallback _sortingOrderDelegate;

        /// <summary>
        /// Creates a ContactsManager.
        /// </summary>        
        public ContactsManager()
        {
            int error = Interop.Contacts.Connect();
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Connect Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _db = new ContactsDatabase();
        }

        ~ContactsManager()
        {
            Dispose(false);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                int error = Interop.Contacts.Disconnect();
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Disconnect Failed with error " + error);
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

        private event EventHandler<NameDisplayOrderChangedEventArgs> _nameDisplayOrderChanged;
        private event EventHandler<NameSortingOrderChangedEventArgs> _nameSortingOrderChanged;

        /// <summary>
        /// (event) NameDisplayOrderChanged is raised when changing setting value of contacts name display order
        /// </summary>
        public event EventHandler<NameDisplayOrderChangedEventArgs> NameDisplayOrderChanged
        {
            add
            {
                lock (thisLock)
                {
                    _displayOrderDelegate = (ContactDisplayOrder nameDisplayOrder, IntPtr userData) =>
                    {
                        NameDisplayOrderChangedEventArgs args = new NameDisplayOrderChangedEventArgs(nameDisplayOrder);
                        _nameDisplayOrderChanged?.Invoke(this, args);
                    };
                    int error = Interop.Setting.AddNameDisplayOrderChangedCB(_displayOrderDelegate, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Add NameDisplayOrderChangedCB Failed with error " + error);
                    }
                    else
                    {
                        _nameDisplayOrderChanged += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    int error = Interop.Setting.RemoveNameDisplayOrderChangedCB(_displayOrderDelegate, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Remove StateChanged Failed with error " + error);
                    }

                    _nameDisplayOrderChanged -= value;
                }
            }

        }

        /// <summary>
        /// (event) NameSortingOrderChanged is raised when changing setting value of contacts name sorting order
        /// </summary>
        public event EventHandler<NameSortingOrderChangedEventArgs> NameSortingOrderChanged
        {
            add
            {
                lock (thisLock)
                {
                    _sortingOrderDelegate = (ContactSortingOrder nameSortingOrder, IntPtr userData) =>
                    {
                        NameSortingOrderChangedEventArgs args = new NameSortingOrderChangedEventArgs(nameSortingOrder);
                        _nameSortingOrderChanged?.Invoke(this, args);
                    };
                    int error = Interop.Setting.AddNameSortingOrderChangedCB(_sortingOrderDelegate, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Add NameSortingOrderChangedCB Failed with error " + error);
                    }
                    else
                    {
                        _nameSortingOrderChanged += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    int error = Interop.Setting.RemoveNameSortingOrderChangedCB(_sortingOrderDelegate, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Remove StateChanged Failed with error " + error);
                    }

                    _nameSortingOrderChanged -= value;
                }
            }

        }

        /// <summary>
        /// A ContactsDatabase
        /// </summary>
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
