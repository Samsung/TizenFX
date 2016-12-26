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

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for NFC Tag mode. It allows applications to handle Tag informations.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/nfc</privilege>
    public class NfcTagAdapter : IDisposable
    {
        private NfcTag _tag;
        private bool disposed = false;

        private event EventHandler<TagDiscoveredEventArgs> _tagDiscovered;

        private Interop.Nfc.TagDiscoveredCallback _tagDiscoveredCallback;

        /// <summary>
        /// The event for receiving tag discovered notification.
        /// </summary>
        public event EventHandler<TagDiscoveredEventArgs> TagDiscovered
        {
            add
            {
                if (_tagDiscovered == null)
                {
                    RegisterTagDiscoveredEvent();
                }
                _tagDiscovered += value;
            }
            remove
            {
                _tagDiscovered -= value;
                if (_tagDiscovered == null)
                {
                    UnregisterTagDiscoveredEvent();
                }
            }
        }

        internal NfcTagAdapter()
        {
        }

        ~NfcTagAdapter()
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

        /// <summary>
        /// Gets current connected tag.
        /// </summary>
        /// <returns>NfcTag object.</returns>
        public NfcTag GetConnectedTag()
        {
            IntPtr tagHandle = IntPtr.Zero;
            int ret = Interop.Nfc.GetConnectedTag(out tagHandle);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get connected tag, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
            _tag = new NfcTag(tagHandle);

            return _tag;
        }

        private void RegisterTagDiscoveredEvent()
        {
            _tagDiscoveredCallback = (int type, IntPtr tagHandle, IntPtr userData) =>
            {
                NfcDiscoveredType tagType = (NfcDiscoveredType)type;
                TagDiscoveredEventArgs e = new TagDiscoveredEventArgs(tagType, tagHandle);
                _tagDiscovered.SafeInvoke(null, e);
            };

            int ret = Interop.Nfc.SetTagDiscoveredCallback(_tagDiscoveredCallback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set tag discovered callback, Error - " + (NfcError)ret);
            }
        }

        private void UnregisterTagDiscoveredEvent()
        {
            Interop.Nfc.UnsetTagDiscoveredCallback();
        }
    }
}
