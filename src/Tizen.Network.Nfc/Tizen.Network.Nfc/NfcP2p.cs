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
using System.Threading.Tasks;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for managing the p2p target information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcP2p : IDisposable
    {
        private IntPtr _p2pTargetHandle = IntPtr.Zero;
        private bool disposed = false;

        private event EventHandler<P2pDataReceivedEventArgs> _p2pDataReceived;

        private Interop.Nfc.P2pDataReceivedCallback _p2pDataReceivedCallback;

        /// <summary>
        /// The event for receiving data from NFC peer-to-peer target.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<P2pDataReceivedEventArgs> P2pDataReceived
        {
            add
            {
                _p2pDataReceived += value;
            }
            remove
            {
                _p2pDataReceived -= value;
            }
        }

        internal NfcP2p(IntPtr handle)
        {
            _p2pTargetHandle = handle;
            RegisterP2pDataReceivedEvent();
        }

        ~NfcP2p()
        {
            Dispose(false);
        }

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
                UnregisterP2pDataReceivedEvent();
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _p2pTargetHandle;
        }

        /// <summary>
        /// Sends data to NFC peer-to-peer target.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="ndefMessage">NfcNdefMessage object.</param>
        /// <exception cref="NotSupportedException">Thrown when Nfc is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when method is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        public Task<NfcError> SendNdefMessageAsync(NfcNdefMessage ndefMessage)
        {
            var task = new TaskCompletionSource<NfcError>();

            Interop.Nfc.VoidCallback callback = (int result, IntPtr userData) =>
            {
                task.SetResult((NfcError)result);
                return;
            };

            int ret = Interop.Nfc.P2p.Send(_p2pTargetHandle, ndefMessage.GetHandle(), callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to write ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        private void RegisterP2pDataReceivedEvent()
        {
            _p2pDataReceivedCallback = (IntPtr p2pTargetHandle, IntPtr ndefMessageHandle, IntPtr userData) =>
            {
                P2pDataReceivedEventArgs e = new P2pDataReceivedEventArgs(p2pTargetHandle, ndefMessageHandle);
                _p2pDataReceived.SafeInvoke(null, e);
            };

            int ret = Interop.Nfc.P2p.SetDataReceivedCallback(_p2pTargetHandle, _p2pDataReceivedCallback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set p2p target discovered callback, Error - " + (NfcError)ret);
            }
        }

        private void UnregisterP2pDataReceivedEvent()
        {
            Interop.Nfc.P2p.UnsetDataReceivedCallback(_p2pTargetHandle);
        }
    }

    /// <summary>
    /// A class for managing the snep(Simple NDEF Exchange Protocol) information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcSnep : IDisposable
    {
        private IntPtr _snepHandle = IntPtr.Zero;
        private bool disposed = false;

        internal NfcSnep(IntPtr handle)
        {
            _snepHandle = handle;
        }

        ~NfcSnep()
        {
            Dispose(false);
        }

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
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _snepHandle;
        }
    }
}
