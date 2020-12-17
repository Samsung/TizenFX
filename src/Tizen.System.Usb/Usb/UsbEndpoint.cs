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
    /// The USB Endpoint class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbEndpoint
    {
        internal readonly Interop.UsbEndpointHandle _handle;
        internal readonly UsbInterface _parent;

        internal UsbEndpoint(UsbInterface parent, Interop.UsbEndpointHandle handle)
        {
            _parent = parent;
            _handle = handle;
        }

        /// <summary>
        /// Gets the number of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Id
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetNumber);
            }
        }

        /// <summary>
        /// Gets the direction of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public EndpointDirection Direction
        {
            get
            {
                ThrowIfDisposed();
                return (EndpointDirection)Interop.NativeGet<Interop.EndpointDirection>(_handle.GetDirection);
            }
        }

        /// <summary>
        /// Gets the maximum packet size of a given endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int MaxPacketSize
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetMaxPacketSize);
            }
        }

        internal void ThrowIfDisposed()
        {
            if (_handle == null) throw new InvalidOperationException("Incompatible endpoint handle");
            _parent?.ThrowIfDisposed();
        }

        internal int TransferImpl(byte[] buffer, int length, uint timeout)
        {
            ThrowIfDisposed();
            int transferred;
            _handle.Transfer(buffer, length, out transferred, timeout).ThrowIfFailed("Transfer failed");
            return transferred;
        }

        internal static UsbEndpoint EndpointFactory(UsbInterface parent, Interop.UsbEndpointHandle handle)
        {
            Interop.TransferType transferType;
            handle.GetTransferType(out transferType).ThrowIfFailed("Failed to get transfer type from endpoint");
            switch(transferType)
            {
                case Interop.TransferType.Bulk: return new UsbBulkEndpoint(parent, handle);
                case Interop.TransferType.Interrupt: return new UsbInterruptEndpoint(parent, handle);
                case Interop.TransferType.Isochronous: return new UsbIsochronousEndpoint(parent, handle);
                default: return new UsbEndpoint(parent, handle);
            }
        }
    }
}