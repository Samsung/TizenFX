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
    /// The class for Smartcard reader information. It allows applications to handle the reader information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class SmartcardReader : IDisposable
    {
        private int _readerHandle = -1;
        private int _session;
        private bool disposed = false;
        private List<SmartcardSession> _sessionList = new List<SmartcardSession>();

        /// <summary>
        /// The name of the reader.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// The existence of a secure element.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Connects to a secure element in the given reader.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The SmartcardSession object.</returns>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Closes all the sessions opened on the given reader.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
