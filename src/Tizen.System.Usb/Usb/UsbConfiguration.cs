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
    /// A class to manage the USB configuration.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbConfiguration : IDisposable
    {
        internal readonly Interop.UsbConfigHandle _handle;
        private readonly UsbDevice _parent;
        private Dictionary<int, UsbInterface> _interfaces;

        internal UsbConfiguration(UsbDevice parent, Interop.UsbConfigHandle handle)
        {
            _parent = parent;
            _handle = handle;
        }

        /// <summary>
        /// Checks if the device is self-powered in a given configuration.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool IsSelfPowered
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<bool>(_handle.IsSelfPowered);
            }
        }

        /// <summary>
        /// Checks if the device in a given configuration supports remote wakeup.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool SupportRemoteWakeup
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<bool>(_handle.SupportRemoteWakeup);
            }
        }

        /// <summary>
        /// Gets the maximum power required in a given configuration, in mA.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int MaximumPowerRequired
        {
            get
            {
                ThrowIfDisposed();
                return Interop.NativeGet<int>(_handle.GetMaxPower);
            }
        }

        /// <summary>
        /// A dictionary for mapping the interface IDs to interface instances for a given configuration.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// var specificIface = device.ActiveConfiguration.Interfaces[123];
        /// foreach (var iface in device.ActiveConfiguration.Interfaces.Where(...)) ...
        /// </code>
        /// </example>
        public IReadOnlyDictionary<int, UsbInterface> Interfaces
        {
            get
            {
                ThrowIfDisposed();
                if (_interfaces == null)
                {
                    _interfaces = new Dictionary<int, UsbInterface>();
                    int count = Interop.NativeGet<int>(_handle.GetNumInterfaces);
                    for (int i = 0; i < count; ++i)
                    {
                        IntPtr handle;
                        _handle.GetInterface(i, out handle);
                        UsbInterface usbInterface = new UsbInterface(this, new Interop.UsbInterfaceHandle(handle));
                        _interfaces.Add(usbInterface.Id, usbInterface);
                    }
                }
                return _interfaces;
            }
        }

        /// <summary>
        /// The configuration string.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// Throws exception if device is disconnected or not opened for operation or busy as its interfaces are currently claimed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string ConfigurationString
        {
            get
            {
                ThrowIfDisposed();
                _parent.ThrowIfDeviceNotOpened();
                return Interop.DescriptorString(_handle.GetConfigStr);
            }
        }

        /// <summary>
        /// Sets this configuration as an active configuration for the device.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// Throws an exception if the device is disconnected, or not opened for an operation, or busy as its interfaces are currently claimed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// device.Configurations[123].SetAsActive();
        /// DoSomeWorkNow(device.ActiveConfiguration);
        /// </code>
        /// </example>
        public void SetAsActive()
        {
            ThrowIfDisposed();
            _parent.ThrowIfDeviceNotOpened();
            _handle.SetAsActive().ThrowIfFailed("Failed to activate this configuration");
        }

        internal void ThrowIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException("Configuration is already disposed");
            _parent.ThrowIfDisposed();
        }

        internal void ThrowIfDeviceNotOpened()
        {
            _parent.ThrowIfDeviceNotOpened();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases all the resources used by the ConnectionProfile.
        /// It should be called after it has finished using the object.</summary>
        /// <since_tizen> 4 </since_tizen>
        internal virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _handle.Dispose();
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the UsbConfiguration class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~UsbConfiguration()
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
