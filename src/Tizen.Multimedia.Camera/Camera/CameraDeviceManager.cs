using System.Linq;
/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Native = Interop.CameraDeviceManager;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This CameraDeviceManager class provides methods to control current camera devices and get its information.
    /// </summary>
    /// <remarks>
    /// This supports the product infrastructure and is not intended to be used directly from 3rd party application code.
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    /// <feature> http://tizen.org/feature/camera </feature>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CameraDeviceManager : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;
        private Native.DeviceConnectionChangedCallback _deviceConnectionChangedCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceManager"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Invalid operation.</exception>
        /// <exception cref="NotSupportedException">The camera device manager is not supported.</exception>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CameraDeviceManager()
        {
            Native.Initialize(out _handle).ThrowIfFailed("Failed to initialize CameraDeviceManager");
        }

        /// <summary>
        /// Finalizes an instance of the Camera class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ~CameraDeviceManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the status whether camera device(usb, network) is connected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsExternalCameraConnected =>
            GetDeviceInformation().Where(d => d.Type == CameraDeviceType.Usb ||
                                              d.Type == CameraDeviceType.Network)
                                  .Any();

        /// <summary>
        /// Gets the current camera device information.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<CameraDeviceInformation> GetDeviceInformation()
        {
            var deviceList = new Native.CameraDeviceListStruct();

            Native.GetDeviceList(Handle, ref deviceList).
                ThrowIfFailed("Failed to get camera device list");

            return GetDeviceInformation(deviceList);
        }

        internal static ReadOnlyCollection<CameraDeviceInformation> GetDeviceInformation(Native.CameraDeviceListStruct list)
        {
            var devices = list.device;
            var deviceList = new List<CameraDeviceInformation>();

            for (int i = 0 ; i < list.count ; i++)
            {
                var deviceInfo = GetDeviceInformation(devices[i]);
                deviceList.Add(deviceInfo);

                Log.Info(CameraLog.Tag, deviceInfo.ToString());
            }

            return new ReadOnlyCollection<CameraDeviceInformation>(deviceList);
        }

        internal static CameraDeviceInformation GetDeviceInformation(Native.CameraDeviceStruct device) =>
            new CameraDeviceInformation(device.Type, device.device, GetString(device.name), GetString(device.id));

        private static string GetString(char[] word)
        {
            int length = 0;
            while(word[length] != '\0')
            {
                length++;
            }

            return new String(word, 0, length);
        }

        private event EventHandler<CameraDeviceConnectionChangedEventArgs> _deviceConnectionChanged;
        /// <summary>
        /// An event that occurs when camera device is connected or disconnected.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<CameraDeviceConnectionChangedEventArgs> DeviceConnectionChanged
        {
            add
            {
                if (_deviceConnectionChanged == null)
                {
                    RegisterDeviceConnectionChangedCallback();
                }

                _deviceConnectionChanged += value;
            }
            remove
            {
                _deviceConnectionChanged -= value;

                if (_deviceConnectionChanged == null)
                {
                    UnregisterDeviceConnectionChangedCallback();
                }
            }
        }

        private IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle;
            }
        }

        private int connectionCallbackId = 0;
        private void RegisterDeviceConnectionChangedCallback()
        {
            _deviceConnectionChangedCallback = (ref Native.CameraDeviceStruct device, bool status, IntPtr userData) =>
            {
                _deviceConnectionChanged?.Invoke(this, new CameraDeviceConnectionChangedEventArgs(ref device, status));
            };

            Native.SetDeviceConnectionChangedCallback(Handle, _deviceConnectionChangedCallback, IntPtr.Zero, out connectionCallbackId).
                ThrowIfFailed("Failed to set device connection changed callback");
        }

        private void UnregisterDeviceConnectionChangedCallback()
        {
            Native.UnsetDeviceConnectionChangedCallback(Handle, connectionCallbackId).
                ThrowIfFailed("Failed to unset device connection changed callback");
        }

        #region Dispose support
        /// <summary>
        /// Releases the unmanaged resources used by the camera.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }

                if (_handle != IntPtr.Zero)
                {
                    UnregisterDeviceConnectionChangedCallback();

                    Native.Deinitialize(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the camera.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(CameraLog.Tag, "Camera handle is disposed.");
                throw new ObjectDisposedException(nameof(Camera));
            }
        }
        #endregion Dispose support
    }

    /// <summary>
    /// Provides the ability to get camera device information.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CameraDeviceInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceInformation"/> class.
        /// </summary>
        /// <param name="type"><see cref="CameraDeviceType"/></param>
        /// <param name="device"><see cref="CameraDevice"/></param>
        /// <param name="name">The name of camera device</param>
        /// <param name="id">The ID of camera device</param>
        /// <exception cref="ArgumentException">Invalid enumeration.</exception>
        /// <exception cref="ArgumentNullException">name or id is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal CameraDeviceInformation(CameraDeviceType type, CameraDevice device, string name, string id)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDeviceType), type, nameof(type));
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Type = type;
            Device = device;
            Name = name ?? throw new ArgumentNullException(nameof(name), "name is null");
            Id = id ?? throw new ArgumentNullException(nameof(id), "id is null");
        }

        /// <summary>
        /// Gets the camera device type.
        /// </summary>
        /// <value><see cref="CameraDeviceType"/></value>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CameraDeviceType Type { get; }

        /// <summary>
        /// Gets the <see cref="CameraDevice"/>.
        /// </summary>
        /// <value><see cref="CameraDevice"/></value>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CameraDevice Device { get; }

        /// <summary>
        /// Gets the camera device name.
        /// </summary>
        /// <value>The camera device name</value>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }

        /// <summary>
        /// Gets the camera device Id.
        /// </summary>
        /// <value>The camera device id.</value>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() =>
            $"Type:{Type.ToString()}, Device:{Device.ToString()}, Name:{Name}, Id:{Id}";
    }
}
