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
    /// The USB Manager class.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbManager : IDisposable
    {
        private readonly Interop.UsbContextHandle _context = null;
        private readonly Interop.HostHotplugHandle _hotpluggedHandle = null;
        private List<UsbDevice> _devices = new List<UsbDevice>();

        /// <summary>
        /// The USB Manager constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public UsbManager()
        {
            _context = new Interop.UsbContextHandle();
            _devices = _context.GetDeviceList().Select(devHandle => new UsbDevice(this, devHandle)).ToList();
            _context.SetHotplugCb(HostHotplugCallback, Interop.HotplugEventType.Any,
                IntPtr.Zero, out _hotpluggedHandle).ThrowIfFailed("Failed to set hot plugged callback");
        }

        /// <summary>
        /// This function returns a list of USB devices attached to the system.
        /// </summary>
        /// <exception cref="NotSupportedException">Throws an exception if the USB host feature is not enabled.</exception>
        /// <exception cref="OutOfMemoryException">Throws an exception in case of insufficient memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws an exception if the user has insufficient permission on the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<UsbDevice> AvailableDevices
        {
            get
            {
                ThrowIfDisposed();
                return _devices;
            }
        }

        /// <summary>
        /// An event handler for events when the USB device is attached or detached.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<HotPluggedEventArgs> DeviceHotPlugged;

        internal void HostHotplugCallback(IntPtr devHandle, IntPtr userData)
        {
            Interop.HostDeviceHandle handle = new Interop.HostDeviceHandle(devHandle);
            UsbDevice device = _devices.Where(dev => dev._handle == handle).FirstOrDefault();
            if (device == null)
            {
                device = new UsbDevice(this, handle);
                _devices.Add(device);

                if (DeviceHotPlugged != null)
                {
                    DeviceHotPlugged.Invoke(this, new HotPluggedEventArgs(device, HotplugEventType.Attach));
                }
            }
            else
            {
                if (DeviceHotPlugged != null)
                {
                    DeviceHotPlugged.Invoke(this, new HotPluggedEventArgs(device, HotplugEventType.Detach));
                }

                _devices.Remove(device);
                // do we need to dispose device here ?
            }
        }

        internal void ThrowIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException("USB Context is already disposed");
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_hotpluggedHandle != null) _hotpluggedHandle.Dispose();
                if (_context != null) _context.Dispose();
                disposedValue = true;
            }
        }

        ~UsbManager()
        {
            Dispose(false);
        }

        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
