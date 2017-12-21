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
    /// Class to manage USB host devices. This class contains operations for enumerating, opening and closing devices.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class UsbDevice : IDisposable
    {
        internal readonly Interop.HostDeviceHandle _handle;
        private readonly UsbManager _parent;

        internal UsbDevice(UsbManager parent, Interop.HostDeviceHandle handle)
        {
            _parent = parent;
            _handle = handle;
        }

        /// <summary>
        /// Number of the bus, this device is connected to.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int BusId {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetBusNumber);
            }
        }

        /// <summary>
        /// Address of device on the bus.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int Address
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetAddress);
            }
        }

        /// <summary>
        /// List of available port numbers from a device.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<int> Ports
        {
            get
            {
                ThrowIfDisposed();
                return _handle.Ports();
            }
        }

        /// <summary>
        /// Checks if device is opened.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool IsOpened
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<bool>(_handle.IsOpened);
            }
        }

        /// <summary>
        /// Control endpoint (endpoint 0).
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
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
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Throws exception if device is disconnected or not opened for operation. </exception>
        /// <since_tizen> 5 </since_tizen>
        public UsbConfiguration ActiveConfiguration
        {
            get
            {
                ThrowIfDisposed();
                ThrowIfDeviceNotOpened();
                IntPtr handle = Interop.NativeGet<IntPtr>(_handle.GetActiveConfig);
                Interop.UsbConfigHandle configHandle = new Interop.UsbConfigHandle(handle);
                return new UsbConfiguration(this, configHandle);
            }
        }

        /// <summary>
        /// Dictionary mapping configuration Ids to configuration instances for this device.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IReadOnlyDictionary<int, UsbConfiguration> Configurations
        {
            get
            {
                ThrowIfDisposed();
                var configurations = new Dictionary<int, UsbConfiguration>();
                int count = Interop.NativeGet<int>(_handle.GetNumConfigurations);
                for (int i = 0; i < count; ++i)
                {
                    IntPtr configHandle;
                    _handle.GetConfig(i, out configHandle);
                    configurations.Add(i, new UsbConfiguration(this, new Interop.UsbConfigHandle(configHandle)));
                }
                return configurations;
            }
        }

        /// <summary>
        /// Device information such as version, class, subclass etc.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public UsbDeviceInformation DeviceInformation
        {
            get
            {
                ThrowIfDisposed();
                return new UsbDeviceInformation(this);
            }
        }

        /// <summary>
        /// String associated with device.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException"> Throws exception if device is disconnected or not opened for operation. </exception>
        /// <since_tizen> 5 </since_tizen>
        public UsbDeviceStrings Strings
        {
            get
            {
                ThrowIfDisposed();
                ThrowIfDeviceNotOpened();
                return new UsbDeviceStrings(this, "us-ascii");
            }
        }

        /// <summary>
        /// Opens device, which allows performing operations on it.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Throws exception in case of insufficient memory.</exception>
        /// <exception cref="InvalidOperationException">Throws exception if device is disconnected.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void Open()
        {
            ThrowIfDisposed();
            _handle.Open().ThrowIfFailed("Failed to open device for use");
        }

        /// <summary>
        /// Closes device for operations.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void Close()
        {
            ThrowIfDisposed();
            if (IsOpened == false) return;

            _handle.CloseHandle().ThrowIfFailed("Failed to close device for use");
        }

        internal void ThrowIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException("USB Device is already disposed");
            _parent.ThrowIfDisposed();
        }

        internal void ThrowIfDeviceNotOpened()
        {
            if (IsOpened == false) throw new InvalidOperationException("USB Device is should be in open state for this operation");
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases all resources used by the ConnectionProfile.
        /// It should be called after finished using of the object.</summary>
        /// <since_tizen> 5 </since_tizen>
        internal virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
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
        /// Releases all resources used by the ConnectionProfile.
        /// It should be called after finished using of the object.</summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
