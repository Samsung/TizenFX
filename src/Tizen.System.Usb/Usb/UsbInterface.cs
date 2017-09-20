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

using System.Collections.Generic;
using System;

namespace Tizen.System.Usb
{
    /// <summary>
    /// Class to manage USB Interfaces.
    /// </summary>
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
        /// Gets number of given interface.
        /// </summary>
        public int Id
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetNumber);
            }
        }

        /// <summary>
        /// Sets alternative setting. Use index of new alternative setting for given interface.
        /// </summary>
        public int AlternateSetting
        {
            set
            {
                ThrowIfDisposed();
                Interop.NativeSet(_handle.SetAltsetting, value);
            }
        }

        /// <summary>
        /// Dictionary mapping endpoint Ids to endpoint instances for given interface.
        /// </summary>
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
                        Interop.UsbEndpointHandle handle;
                        _handle.GetEndpoint(i, out handle);
                        UsbEndpoint endpoint = UsbEndpoint.EndpointFactory(this, handle);
                        _endpoints.Add(endpoint.Id, endpoint);
                    }
                }
                return _endpoints;
            }
        }


        /// <summary>
        /// Gets string describing an interface.
        /// </summary>
        /// <returns></returns>
        public string InterfaceString()
        {
            ThrowIfDisposed();
            return Interop.DescriptorString(_handle.GetStr);
        }

        /// <summary>
        /// Claims interface on a device. Interface must be claimed first to perform I/O operations.
        /// </summary>
        /// <param name="force">Set to true to auto detach kernel driver, false otherwise.</param>
        /// <exception cref="InvalidOperationException">
        /// Throws exception if device is disconnected or not opened for operation or another program or driver has claimed the interface.
        /// </exception>
        public void Claim(bool force)
        {
            ThrowIfDisposed();
            if (_isClaimed == true) return;
            _handle.ClaimInterface(force).ThrowIfFailed("Failed to claim interface");
            _isClaimed = true;
        }


        /// <summary>
        /// Releases previously claimed interface.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws exception if device is disconnected or not opened for operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        public void Release()
        {
            ThrowIfDisposed();
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
