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
        // It needs to be static as its destroy function must be called after closing all devices and before application close.
        // It has to be called to clean the memory used by library.
        private static readonly Interop.UsbContextHandle _context = null;

        private readonly Interop.HostHotplugHandle _hotpluggedAttachHandle = null;
        private readonly Interop.HostHotplugHandle _hotpluggedDetachHandle = null;

        static UsbManager()
        {
            bool isSupported;
            Information.TryGetValue("http://tizen.org/feature/usb.host", out isSupported);
            if (isSupported)
            {
                _context = Interop.UsbContextHandle.GetContextHandle();
            }
        }

        /// <summary>
        /// The USB Manager constructor.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public UsbManager()
        {
            if (_context == null) Interop.ErrorCode.NotSupported.ThrowIfFailed("USB host operations are not supported in this device");

            IntPtr hotpluggedAttachHandle, hotpluggedDetachHandle;
            _context.SetHotplugCb(HostHotplugAttachCallback, Interop.HotplugEventType.Attach,
                IntPtr.Zero, out hotpluggedAttachHandle).ThrowIfFailed("Failed to set hot plugged callback");

            _context.SetHotplugCb(HostHotplugDetachCallback, Interop.HotplugEventType.Detach,
                IntPtr.Zero, out hotpluggedDetachHandle).ThrowIfFailed("Failed to set hot plugged callback");

            _hotpluggedAttachHandle = new Interop.HostHotplugHandle(hotpluggedAttachHandle);
            _hotpluggedDetachHandle = new Interop.HostHotplugHandle(hotpluggedDetachHandle);
        }

        /// <summary>
        /// This function returns a list of USB devices attached to the system.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Throws exception in case of insufficient memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// var specificDevice = manager.AvailableDevices.SingleOrDefault(dev => dev.DeviceInformation.ProductId == 0x123);
        /// foreach (var dev in manager.AvailableDevices.Where(...)) { ... }
        /// </code>
        /// </example>
        public IEnumerable<UsbDevice> AvailableDevices
        {
            get
            {
                ThrowIfDisposed();
                return _context.GetDeviceList().Select(devHandle => new UsbDevice(this, devHandle)).ToList();
            }
        }

        /// <summary>
        /// An event handler for events when the USB device is attached or detached.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        /// <example>
        /// <code>
        /// manager.DeviceHotPlugged += (object sender, HotPluggedEventArgs args) => {
        ///    Tizen.Log.Warn("EXAMPLE", $"product {args.Device.DeviceInformation.ProductId} was {0}", args.EventType == HotplugEventType.Attach ? "attached" : "detached");
        /// };
        /// </code>
        /// </example>
        public event EventHandler<HotPluggedEventArgs> DeviceHotPlugged;

        internal void HostHotplugAttachCallback(IntPtr devHandle, IntPtr userData)
        {
            Interop.HostDeviceHandle handle = new Interop.HostDeviceHandle(devHandle);
            UsbDevice device = new UsbDevice(this, handle);
            if (DeviceHotPlugged != null)
            {
                DeviceHotPlugged.Invoke(this, new HotPluggedEventArgs(device, HotplugEventType.Attach));
            }

            //AvailableDevices.Remove(device);
            // do we need to dispose device here ?
            }

        internal void HostHotplugDetachCallback(IntPtr devHandle, IntPtr userData)
            {
            Interop.HostDeviceHandle handle = new Interop.HostDeviceHandle(devHandle);
            UsbDevice device = new UsbDevice(this, handle);
            if (DeviceHotPlugged != null)
            {
                DeviceHotPlugged.Invoke(this, new HotPluggedEventArgs(device, HotplugEventType.Detach));
            }

            //AvailableDevices.Remove(device);
            // do we need to dispose device here ?
        }

        internal void ThrowIfDisposed()
        {
            if (disposedValue) throw new ObjectDisposedException("USB Context is already disposed");
        }

        #region IDisposable Support
        private bool disposedValue = false;

        internal virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (_hotpluggedAttachHandle != null) _hotpluggedAttachHandle.Dispose();
                if (_hotpluggedDetachHandle != null) _hotpluggedDetachHandle.Dispose();
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the USB Manager Class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
