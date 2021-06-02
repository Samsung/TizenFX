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
    /// This CameraDeviceManager class provides methods to controls current camera devices and gets its information.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    /// <feature> http://tizen.org/feature/camera </feature>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CameraDeviceManager : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceManager"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Invalid operation.</exception>
        /// <exception cref="NotSupportedException">The camera feature is not supported.</exception>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CameraDeviceManager()
        {
            Native.Initialize(out _handle).ThrowIfFailed("Failed to initialize CameraDeviceManager");

            RegisterDeviceListCallback();
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
        /// Gets the current camera device information.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<CameraDeviceInfo> GetDeviceInfo()
        {
            var deviceList = new Native.CameraDeviceListStruct();

            Native.GetDeviceList(Handle, ref deviceList).
                ThrowIfFailed("Failed to get camera device list");

            return GetDeviceInfo(deviceList);
        }

        internal static ReadOnlyCollection<CameraDeviceInfo> GetDeviceInfo(Native.CameraDeviceListStruct deviceList)
        {
            var cameraDevice = deviceList.device;

            var cameraDeviceList = new List<CameraDeviceInfo>();

            for (int i = 0 ; i < deviceList.count ; i++)
            {
                var deviceInfo = new CameraDeviceInfo(cameraDevice[i].Type, cameraDevice[i].device,
                    GetString(cameraDevice[i].name), GetString(cameraDevice[i].id));

                cameraDeviceList.Add(deviceInfo);

                Log.Info(CameraLog.Tag, deviceInfo.ToString());
            }

            return new ReadOnlyCollection<CameraDeviceInfo>(cameraDeviceList);
        }

        private static string GetString(char[] word)
        {
            int length = 0;
            while(word[length] != '\0')
            {
                length++;
            }

            return new String(word, 0, length);
        }

        /// <summary>
        /// An event that occurs when there is a change in the camera device list.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<CameraDeviceListChangedEventArgs> CameraDeviceListChanged;

        private IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle;
            }
        }

        private int callbackId = 0;
        private void RegisterDeviceListCallback()
        {
            Native.DeviceListChangedCallback callback = (ref Native.CameraDeviceListStruct deviceList, IntPtr userData) =>
            {
                CameraDeviceListChanged?.Invoke(this, new CameraDeviceListChangedEventArgs(ref deviceList));
            };

            Native.SetDeviceListChangedCallback(Handle, callback, IntPtr.Zero, out callbackId).
                ThrowIfFailed("Failed to set device list changed callback");

            Log.Info(CameraLog.Tag, $"callback Id : {callbackId}");
        }

        private void UnregisterDeviceListCallback()
        {
            Log.Info(CameraLog.Tag, $"callback Id : {callbackId}");

            Native.UnsetDeviceListChangedCallback(Handle, callbackId).
                ThrowIfFailed("Failed to unset device list changed callback");
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
                    UnregisterDeviceListCallback();
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
    public class CameraDeviceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceInfo"/> class.
        /// </summary>
        /// <param name="type"><see cref="CameraDeviceType"/></param>
        /// <param name="device"><see cref="CameraDevice"/></param>
        /// <param name="name">The name of camera device</param>
        /// <param name="id">The ID of camera device</param>
        /// <exception cref="ArgumentException">Invalid enumeration of empty string.</exception>
        /// <exception cref="ArgumentNullException">name of id is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CameraDeviceInfo(CameraDeviceType type, CameraDevice device, string name, string id)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDeviceType), type, nameof(type));
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));
            ValidationUtil.ValidateIsNullOrEmpty(name, nameof(name));
            ValidationUtil.ValidateIsNullOrEmpty(id, nameof(id));

            Type = type;
            Device = device;
            Name = name;
            Id = id;
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
            $"Type:{Type.ToString()}, Device:{Device.ToString()}, Name:{Name}, ID:{Id}";
    }
}
