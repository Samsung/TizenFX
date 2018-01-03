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
using System.Linq;

namespace Tizen.System.Usb
{
    /// <summary>
    /// A class to manage the USB host devices. This class contains the operations for enumerating, opening, and closing devices.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbDevice : IDisposable
    {
        internal readonly Interop.HostDeviceHandle _handle;
        private readonly UsbManager _parent;
        private Dictionary<int, UsbConfiguration> _configurations = new Dictionary<int, UsbConfiguration>();

        internal UsbDevice(UsbManager parent, Interop.HostDeviceHandle handle)
        {
            _parent = parent;
            _handle = handle;

            int count = Interop.NativeGet<int>(_handle.GetNumConfigurations);
            for (int i = 0; i < count; ++i)
            {
                Interop.UsbConfigHandle configHandle;
                _handle.GetConfig(i, out configHandle);
                _configurations.Add(i, new UsbConfiguration(this, configHandle));
            }
        }

        /// <summary>
        /// Number of the bus, this device is connected to.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Throws an exception if the user has insufficient permission on the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int BusId {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetBusNumber);
            }
        }

        /// <summary>
        /// Address of the device on the bus.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Address
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetAddress);
            }
        }

        /// <summary>
        /// List of the available port numbers from the device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<int> Ports
        {
            get
            {
                ThrowIfDisposed();
                return _handle.Ports();
            }
        }

        /// <summary>
        /// Checks if the device is opened.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool IsOpened
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<bool>(_handle.IsOpened);
            }
        }

        /// <summary>
        /// Controls an endpoint (endpoint 0).
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public UsbControlEndpoint ControlEndpoint
        {
            get
            {
                ThrowIfDisposed();
                return new UsbControlEndpoint(this);
            }
        }

        /// <summary>
        /// Active configuration for the device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws an exception if the device is disconnected.</exception>
        /// <since_tizen> 4 </since_tizen>
        public UsbConfiguration ActiveConfiguration
        {
            get
            {
                ThrowIfDisposed();
                Interop.UsbConfigHandle configHandle = Interop.NativeGet<Interop.UsbConfigHandle>(_handle.GetActiveConfig);
                return _configurations.Values.Where(config => config._handle == configHandle).First();
            }
        }

        /// <summary>
        /// A dictionary for mapping the configuration IDs to configuration instances for this device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public IReadOnlyDictionary<int, UsbConfiguration> Configurations
        {
            get
            {
                ThrowIfDisposed();
                return _configurations;
            }
        }

        /// <summary>
        /// Device information such as version, class, subclass, etc.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public UsbDeviceInformation DeviceInformation
        {
            get
            {
                ThrowIfDisposed();
                return new UsbDeviceInformation(this);
            }
        }

        /// <summary>
        /// String associated with the device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public UsbDeviceStrings Strings
        {
            get
            {
                ThrowIfDisposed();
                return new UsbDeviceStrings(this, "us-ascii");
            }
        }

        /// <summary>
        /// Opens the device, which allows performing operations on it.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Throws an exception in case of insufficient memory.</exception>
        /// <exception cref="InvalidOperationException">Throws an exception if the device is disconnected.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws an exception if the user has insufficient permission on the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Open()
        {
            ThrowIfDisposed();
            _handle.Open().ThrowIfFailed("Failed to open device for use");
        }

        /// <summary>
        /// Closes the device for operations.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws an exception if the device is not opened for an operation.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Close()
        {
            ThrowIfDisposed();
            if (IsOpened == false) throw new InvalidOperationException("Device must be opened for operation first");

            _handle.CloseHandle().ThrowIfFailed("Failed to close device for use");
        }

        internal void ThrowIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException("USB Device is already disposed");
            _parent.ThrowIfDisposed();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases all the resources used by the ConnectionProfile.
        /// It should be called after it has finished using the object.</summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (IsOpened)
                {
                    Close();
                }
                foreach(var config in _configurations.Values) {
                    config.Dispose();
                }
                _configurations.Clear();
                _handle.Dispose();
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the UsbDevice class.
        /// </summary>
        ~UsbDevice()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all the resources used by the ConnectionProfile.
        /// It should be called after it has finished using the object.</summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
