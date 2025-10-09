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
using System.Collections.Generic;

namespace Tizen.System.Usb
{
    /// <summary>
    /// A class to manage the USB interfaces.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbInterface
    {
        internal readonly Interop.UsbInterfaceHandle _handle;
        private readonly UsbConfiguration _parent;
        private Dictionary<int, UsbEndpoint> _endpoints;
        private bool _isClaimed;

        internal UsbInterface(UsbConfiguration parent, Interop.UsbInterfaceHandle handle)
        {
            _parent = parent;
            _handle = handle;
        }

        /// <summary>
        /// Gets the number of a given interface.
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
        /// Sets an alternative setting. Use the index of a new alternative setting for a given interface.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int AlternateSetting
        {
            set
            {
                ThrowIfDisposed();
                Interop.NativeSet(_handle.SetAltsetting, value);
            }
        }

        /// <summary>
        /// A dictionary for mapping the endpoint IDs to endpoint instances for a given interface.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// var endpoint = iface.Endpoints[123];
        /// </code>
        /// </example>
        public IReadOnlyDictionary<int, UsbEndpoint> Endpoints
        {
            get
            {
                ThrowIfDisposed();
                if (_endpoints == null)
                {
                    _endpoints = new Dictionary<int, UsbEndpoint>();
                    int count = Interop.NativeGet<int>(_handle.GetNumEndpoints);
                    for (int i = 0; i < count; ++i)
                    {
                        IntPtr handle;
                        _handle.GetEndpoint(i, out handle);
                        UsbEndpoint endpoint = UsbEndpoint.EndpointFactory(this, new Interop.UsbEndpointHandle(handle));
                        _endpoints.Add(endpoint.Id, endpoint);
                    }
                }
                return _endpoints;
            }
        }


        /// <summary>
        /// Gets the string describing an interface.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// Throws exception if the device is disconnected or not opened for operation.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public string InterfaceString
        {
            get
        {
            ThrowIfDisposed();
                _parent.ThrowIfDeviceNotOpened();
            return Interop.DescriptorString(_handle.GetStr);
        }
        }

        /// <summary>
        /// Claims the interface on a device. The interface must be claimed first to perform I/O operations.
        /// </summary>
        /// <param name="force">Set to <c> true </c> to auto detach the kernel driver, otherwise <c> false </c>.</param>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// Throws an exception if device is disconnected or not opened for operation or another program or driver has claimed the interface.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// var interface = device.Interfaces[123];
        /// interface.Claim();
        ///   ... do the needful ...
        /// interface.Release();
        /// </code>
        /// </example>
        public void Claim(bool force)
        {
            ThrowIfDisposed();
            _parent.ThrowIfDeviceNotOpened();

            if (_isClaimed == true) return;
            var err = _handle.ClaimInterface(force);
            if (err.IsFailed() && err != Interop.ErrorCode.ResourceBusy)
            {
                err.ThrowIfFailed("Failed to claim interface");
            }
            _isClaimed = true;
        }


        /// <summary>
        /// Releases the previously claimed interface.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Throws exception if the device is disconnected or not opened for operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// var interface = device.Interfaces[123];
        /// interface.Claim();
        ///   ... do the needful ...
        /// interface.Release();
        /// </code>
        /// </example>
        public void Release()
        {
            ThrowIfDisposed();
            _parent.ThrowIfDeviceNotOpened();

            if (_isClaimed == false) return;
            _handle.ReleaseInterface().ThrowIfFailed("Failed to release interface");
            _isClaimed = false;
        }

        internal void ThrowIfDisposed()
        {
            _parent.ThrowIfDisposed();
        }
    }
}
