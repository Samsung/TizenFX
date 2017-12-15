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

namespace Tizen.System.Usb
{
    /// <summary>
    /// USB Interrupt Endpoint class.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class UsbInterruptEndpoint : UsbEndpoint
    {
        internal UsbInterruptEndpoint(UsbInterface parent, Interop.UsbEndpointHandle handle) : base(parent, handle)
        {
        }

        /// <summary>
        /// Gets interval for polling endpoint for data transfers, in frame counts (refer to USB protocol specification).
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int PollingInterval
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetInterval);
            }
        }

        /// <summary>
        /// Performs a USB transfer on given endpoint. Direction of transfer is determined by the endpoint.
        /// </summary>
        /// <param name="buffer">Suitably-sized data buffer for either input or output (depending on endpoint).</param>
        /// <param name="length">
        /// For writes, the number of bytes from data to be sent, for reads the maximum number of bytes to receive
        /// into the data buffer.
        /// </param>
        /// <param name="timeout">
        /// Time (in milliseconds) that this function should wait for before giving up due to no response being
        /// received(for an unlimited timeout 0 value should be used).
        /// </param>
        /// <returns>Number of bytes actually transferred.</returns>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Throws exception if device is disconnected or not opened for operation.</exception>
        /// <exception cref="TimeoutException">Throws exception if transfer timed-out.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int Transfer(byte[] buffer, int length, uint timeout)
        {
            return TransferImpl(buffer, length, timeout);
        }
    }
}
