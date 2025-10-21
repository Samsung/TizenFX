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
    /// The USB Control Endpoint class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbControlEndpoint : UsbEndpoint
    {
        private readonly UsbDevice _device;

        internal UsbControlEndpoint(UsbDevice device) : base(null, null)
        {
            _device = device;
        }

        /// <summary>
        /// Gets the number of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public new int Id
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the direction of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public new EndpointDirection Direction
        {
            get
            {
                return EndpointDirection.InOut;
            }
        }

        /// <summary>
        /// Gets the maximum packet size of a given endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public new int MaxPacketSize
        {
            get
            {
                _device.ThrowIfDisposed();
                return Interop.NativeGet<int>(_device._handle.GetMaxPacketSize0);
            }
        }

        /// <summary>
        /// Performs a control transaction on the endpoint, zero for this device.
        /// </summary>
        /// <param name="requestType">bmRequestType type field for the setup packet.</param>
        /// <param name="request">bRequest field for the setup packet.</param>
        /// <param name="value">wValue field for the setup packet.</param>
        /// <param name="index">wIndex field for the setup packet.</param>
        /// <param name="data">Suitably-sized data buffer for either an input or output (depending on the direction bits within a bmRequestType).</param>
        /// <param name="length">wLength field for the setup packet. The data buffer should be at least this size.</param>
        /// <param name="timeout">
        /// The time (in milliseconds) that this function should wait for, before giving up due to no response being received
        /// (for an unlimited timeout, 0 value should be used).
        /// </param>
        /// <returns>Transferred number of the transferred bytes.</returns>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Throws an exception if the device is disconnected or not opened for an operation.</exception>
        /// <exception cref="TimeoutException">Throws an exception if the transfer is timed out.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// byte[] buffer = new byte[123];
        /// int bytesTransferred = endpoint.Transfer(0x12, 0x34, 0x56, 7, buffer, buffer.Length, 1000);
        /// </code>
        /// </example>
        public int Transfer(byte requestType, byte request, ushort value, ushort index, byte[] data, ushort length, uint timeout)
        {
            _device.ThrowIfDisposed();
            if (_device.IsOpened == false) throw new InvalidOperationException("Device must be opened for operation first");

            int transferred;
            var err = _device._handle.ControlTransfer(requestType, request, value, index, data, length, timeout, out transferred);
            err.ThrowIfFailed("Failed during control transfer");
            return transferred;
        }
    }
}
