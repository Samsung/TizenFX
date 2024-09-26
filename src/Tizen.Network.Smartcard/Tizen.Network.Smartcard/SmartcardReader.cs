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
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Network.Smartcard
{
    /// <summary>
    /// The SmartcardReader class provides information about the Smartcard readers connected to the device.
    /// Applications can use this class to obtain details about the available readers,
    /// such as their names and states, and to manage interactions with the readers.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    public class SmartcardReader : IDisposable
    {
        private int _readerHandle = -1;
        private int _session;
        private bool disposed = false;
        private List<SmartcardSession> _sessionList = new List<SmartcardSession>();

        /// <summary>
        /// The Name property represents the name of the Smartcard reader.
        /// This property allows applications to retrieve the human-readable name assigned to the reader,
        /// which can be useful for displaying information to the user or for logging purposes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Smartcard.Reader.ReaderGetName(_readerHandle, out strPtr);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get reader name, Error - " + (SmartcardError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// The IsSecureElementPresent property indicates whether a Secure Element is currently present in the Smartcard reader.
        /// This property allows applications to determine if there is a Smartcard inserted into the reader,
        /// which can be useful for deciding whether to proceed with further operations or display appropriate messages to the user.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsSecureElementPresent
        {
            get
            {
                bool isPresent;
                int ret = Interop.Smartcard.Reader.ReaderIsSecureElementPresent(_readerHandle, out isPresent);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get present, Error - " + (SmartcardError)ret);
                }
                return isPresent;
            }
        }

        internal SmartcardReader(int handle)
        {
            _readerHandle = handle;
        }

        /// <summary>
        /// SmartcardReader destructor.
        /// </summary>
        ~SmartcardReader()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                foreach (SmartcardSession session in _sessionList)
                {
                    session.Dispose();
                    _sessionList.Remove(session);
                }
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal int GetHandle()
        {
            return _readerHandle;
        }

        internal int GetSession()
        {
            return _session;
        }

        /// <summary>
        /// The OpenSession method establishes a connection to the Secure Element in the specified Smartcard reader.
        /// This method returns a SmartcardSession object, which represents the session with the Secure Element.
        /// By calling this method, applications can initiate communication with the Secure Element and perform various operations.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The SmartcardSession object.</returns>
        public SmartcardSession OpenSession()
        {
            int ret = Interop.Smartcard.Reader.ReaderOpenSession(_readerHandle, out _session);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get session handle, Error - " + (SmartcardError)ret);
            }

            SmartcardSession session = new SmartcardSession(this, _session);
            _sessionList.Add(session);
            return session;
        }

        /// <summary>
        /// The CloseSessions method closes all the open sessions associated with the specified Smartcard reader.
        /// This method ensures that any active sessions with the Secure Element are properly terminated.
        /// By calling this method, applications can release resources and prevent potential conflicts or errors when interacting with the Smartcard.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void CloseSessions()
        {
            int ret = Interop.Smartcard.Reader.ReaderCloseSessions(_readerHandle);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to close sessions, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }

            foreach (SmartcardSession session in _sessionList)
            {
                session.Close();
            }
        }
    }
}
