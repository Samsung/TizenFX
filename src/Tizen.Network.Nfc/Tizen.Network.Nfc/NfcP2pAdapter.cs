﻿/*
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

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// The NfcP2pAdapter class provides methods for managing NFC peer-to-peer (P2P) communication.
    /// It allows applications to initiate and receive P2P communication,
    /// and to handle P2P information such as messages and connections. 
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/nfc</privilege>
    public class NfcP2pAdapter : IDisposable
    {
        private NfcP2p _p2pTarget;
        private bool disposed = false;

        private event EventHandler<P2pTargetDiscoveredEventArgs> _p2pTargetDiscovered;

        private Interop.Nfc.P2pTargetDiscoveredCallback _p2pTargetDiscoveredCallback;

        /// <summary>
        /// The event for receiving the NFC peer-to-peer target discovered notification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<P2pTargetDiscoveredEventArgs> P2pTargetDiscovered
        {
            add
            {
                _p2pTargetDiscovered += value;
            }
            remove
            {
                _p2pTargetDiscovered -= value;
            }
        }

        internal NfcP2pAdapter()
        {
            RegisterP2pTargetDiscoveredEvent();
        }

        /// <summary>
        /// NfcP2pAdapter destructor
        /// </summary>
        ~NfcP2pAdapter()
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
                UnregisterP2pTargetDiscoveredEvent();
            }
            //Free unmanaged objects
            disposed = true;
        }

        /// <summary>
        /// The GetConnectedTarget method returns the currently connected P2P target. 
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The NfcP2p object.</returns>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcP2p GetConnectedTarget()
        {
            IntPtr targetHandle = IntPtr.Zero;
            int ret = Interop.Nfc.GetConnectedTarget(out targetHandle);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get connected p2p target, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
            _p2pTarget = new NfcP2p(targetHandle);

            return _p2pTarget;
        }

        private void RegisterP2pTargetDiscoveredEvent()
        {
            _p2pTargetDiscoveredCallback = (int type, IntPtr p2pTargetHandle, IntPtr userData) =>
            {
                NfcDiscoveredType tagType = (NfcDiscoveredType)type;
                P2pTargetDiscoveredEventArgs e = new P2pTargetDiscoveredEventArgs(tagType, p2pTargetHandle);
                _p2pTargetDiscovered.SafeInvoke(null, e);
            };

            int ret = Interop.Nfc.SetP2pTargetDiscoveredCallback(_p2pTargetDiscoveredCallback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set p2p target discovered callback, Error - " + (NfcError)ret);
            }
        }

        private void UnregisterP2pTargetDiscoveredEvent()
        {
            Interop.Nfc.UnsetP2pTargetDiscoveredCallback();
        }
    }
}
