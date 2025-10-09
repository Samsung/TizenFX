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
    /// The USB Bulk Endpoint class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbBulkEndpoint : UsbEndpoint
    {
        internal UsbBulkEndpoint(UsbInterface parent, Interop.UsbEndpointHandle handle) : base(parent, handle)
        {
        }

        /// <summary>
        /// Performs a USB transfer on a given endpoint. The direction of transfer is determined by the endpoint.
        /// </summary>
        /// <param name="buffer">Suitably-sized data buffer for either an input or output (depending on the endpoint).</param>
        /// <param name="length">
        /// For writes, the number of bytes from the data to be sent. For reads, the maximum number of bytes to receive
        /// into the data buffer.
        /// </param>
        /// <param name="timeout">
        /// The time (in milliseconds) that this function should wait for, before giving up due to no response being
        /// received (for an unlimited timeout, 0 value should be used).
        /// </param>
        /// <returns>The number of bytes actually transferred.</returns>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Throws an exception if the device is disconnected or not opened for an operation.</exception>
        /// <exception cref="TimeoutException">Throws an exception if the transfer is timed out.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// byte[] buffer = new byte[123];
        /// int bytesTransferred = endpoint.Transfer(buffer, buffer.Length, 1000);
        /// </code>
        /// </example>
        public int Transfer(byte[] buffer, int length, uint timeout)
        {
            return TransferImpl(buffer, length, timeout);
        }
    }
}
