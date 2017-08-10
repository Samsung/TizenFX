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
    /// A class for managing the Secure Element information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcSecureElement : IDisposable
    {
        private IntPtr _secureElementHandle = IntPtr.Zero;
        private bool disposed = false;

        internal NfcSecureElement(IntPtr handle)
        {
            _secureElementHandle = handle;
        }

        ~NfcSecureElement()
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
        /// Send APDU(Application Protocol Data Unit) response to CLF(Contactless Front-end).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="response">The bytes array of response data.</param>
        /// <param name="responseLength">The size of response bytes array.</param>
        /// <privilege>http://tizen.org/privilege/nfc.cardemulation</privilege>
        /// <exception cref="NotSupportedException">Thrown when Nfc is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when method is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        public void HceSendApduResponse(byte[] response, uint responseLength)
        {
            int ret = Interop.Nfc.CardEmulation.HceSendApduRespondse(_secureElementHandle, response, responseLength);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to hcd send apdu response, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        internal IntPtr GetHandle()
        {
            return _secureElementHandle;
        }
    }
}
