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
using System.ComponentModel;
using System.Linq;
using Native = Interop.CameraDeviceManager;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This CameraDeviceManager class provides methods to control current camera devices and get its information.
    /// </summary>
    /// <remarks>
    /// This supports the product infrastructure and is not intended to be used directly from 3rd party application code.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
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
        /// <since_tizen> 10 </since_tizen>
        public CameraDeviceManager()
        {
            Native.Initialize(out _handle).ThrowIfFailed("Failed to initialize CameraDeviceManager");
        }

        /// <summary>
        /// Finalizes an instance of the Camera class.
        /// </summary>
        ~CameraDeviceManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the status whether camera device(usb, network) is connected or not.
        /// </summary>
        /// <returns>true if usb or network camera is connected.</returns>
        /// <exception cref="ObjectDisposedException">The CameraDeviceManager already has been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public bool IsExternalCameraConnected =>
            SupportedDevices.Where(d => d.Type == CameraDeviceType.Usb ||
                                        d.Type == CameraDeviceType.Network)
                            .Any();

        /// <summary>
        /// Retrieves all the supported camera devices and returns its information.
        /// </summary>
        /// <returns>
        /// if camera device exist, returns list of <see cref="CameraDeviceInformation"/>; otherwise returns Enumerable.Empty.
        /// </returns>
        /// <exception cref="ArgumentException">Invalid enumeration.</exception>
        /// <exception cref="ArgumentNullException">name or id is null.</exception>
        /// <exception cref="ObjectDisposedException">The CameraDeviceManager already has been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public IEnumerable<CameraDeviceInformation> SupportedDevices
        {
            get
            {
                var deviceList = new List<CameraDeviceInformation>();

                Exception caught = null;

                Native.SupportedDeviceCallback callback = (ref Native.CameraDeviceStruct supportedDevice, IntPtr userData) =>
                {
                    try
                    {
                        var deviceInfo = new CameraDeviceInformation(supportedDevice.type, supportedDevice.device, supportedDevice.name,
                            supportedDevice.id, supportedDevice.extraStreamNum);
                        Log.Debug(CameraLog.Tag, deviceInfo.ToString());

                        deviceList.Add(deviceInfo);
                        return true;
                    }
                    catch (Exception e)
                    {
                        caught = e;
                        return false;
                    }
                };

                Native.SupportedDevices(Handle, callback, IntPtr.Zero).
                    ThrowIfFailed("failed to get supported devices");

                if (caught != null)
                {
                    throw caught;
                }

                return deviceList.Any() ? deviceList.AsReadOnly() : Enumerable.Empty<CameraDeviceInformation>();
            }
        }

        /// <summary>
        /// Gets the product ID for given <param name="device"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Invalid enumeration.</exception>
        /// <exception cref="ObjectDisposedException">The CameraDeviceManager already has been disposed.</exception>
        /// <since_tizen> 11 </since_tizen>
        public ushort GetProductId(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Native.GetProductId(Handle, out ushort productId).ThrowIfFailed("failed to get product ID");

            return productId;
        }

        /// <summary>
        /// Gets the vendor ID for given <param name="device"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Invalid enumeration.</exception>
        /// <exception cref="ObjectDisposedException">The CameraDeviceManager already has been disposed.</exception>
        /// <since_tizen> 11 </since_tizen>
        public ushort GetVendorId(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Native.GetVendorId(Handle, out ushort vendorId).ThrowIfFailed("failed to get vendor ID");

            return vendorId;
        }

        /// <summary>
        /// Gets the current camera device information.
        /// Retrieves all the supported camera devices and returns its information.
        /// </summary>
        /// <remarks>This method is only for backward compatibility. Please use SupportedDevices instead.</remarks>
        /// <returns>
        /// if camera device exist, returns list of <see cref="CameraDeviceInformation"/>; otherwise returns Enumerable.Empty.
        /// </returns>
        /// <see also="WebRTCState"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<CameraDeviceInformation> GetDeviceInformation() => SupportedDevices;

        private event EventHandler<CameraDeviceConnectionChangedEventArgs> _deviceConnectionChanged;
        /// <summary>
        /// An event that occurs when camera device is connected or disconnected.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The CameraDeviceManager already has been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
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

        private int _connectionCallbackId = -1;
        private void RegisterDeviceConnectionChangedCallback()
        {
            _deviceConnectionChangedCallback = (ref Native.CameraDeviceStruct supportedDevice, bool isConnected, IntPtr userData) =>
            {
                var deviceInfo = new CameraDeviceInformation(supportedDevice.type, supportedDevice.device, supportedDevice.name,
                    supportedDevice.id, supportedDevice.extraStreamNum);
                Log.Debug(CameraLog.Tag, deviceInfo.ToString());

                _deviceConnectionChanged?.Invoke(this, new CameraDeviceConnectionChangedEventArgs(deviceInfo, isConnected));
            };

            Native.SetDeviceConnectionChangedCallback(Handle, _deviceConnectionChangedCallback, IntPtr.Zero, out _connectionCallbackId).
                ThrowIfFailed("Failed to set device connection changed callback");

            Log.Debug(CameraLog.Tag, $"callbackId[{_connectionCallbackId}]");
        }

        private void UnregisterDeviceConnectionChangedCallback()
        {
            Log.Debug(CameraLog.Tag, $"callbackId[{_connectionCallbackId}]");

            if (_connectionCallbackId >= 0)
            {
                Native.UnsetDeviceConnectionChangedCallback(Handle, _connectionCallbackId).
                    ThrowIfFailed("Failed to unset device connection changed callback");
            }
        }

        #region Dispose support
        /// <summary>
        /// Releases the unmanaged resources used by the camera.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Log.Debug(CameraLog.Tag, $"Enter. disposing:{disposing.ToString()}");

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
        /// <since_tizen> 10 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(CameraLog.Tag, "CameraDeviceManager handle is disposed.");
                throw new ObjectDisposedException(nameof(Camera));
            }
        }
        #endregion Dispose support
    }

    /// <summary>
    /// Provides the ability to get camera device information.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public struct CameraDeviceInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceInformation"/> class.
        /// </summary>
        /// <param name="type">The camera type</param>
        /// <param name="device">The camera device</param>
        /// <param name="name">The name of camera device</param>
        /// <param name="id">The ID of camera device</param>
        /// <param name="numberOfExtraStream">The number of extra streams</param>
        /// <exception cref="ArgumentException">Invalid enumeration.</exception>
        /// <exception cref="ArgumentNullException">name or id is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        internal CameraDeviceInformation(CameraDeviceType type, CameraDevice device, string name, string id, int numberOfExtraStream)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDeviceType), type, nameof(type));
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Type = type;
            Device = device;
            Name = name ?? throw new ArgumentNullException(nameof(name), "name is null");
            Id = id ?? throw new ArgumentNullException(nameof(id), "id is null");
            NumberOfExtraStream = numberOfExtraStream;

            Log.Debug(CameraLog.Tag, this.ToString());
        }

        /// <summary>
        /// Gets the camera device type.
        /// </summary>
        /// <value><see cref="CameraDeviceType"/></value>
        /// <since_tizen> 10 </since_tizen>
        public CameraDeviceType Type { get; }

        /// <summary>
        /// Gets the <see cref="CameraDevice"/>.
        /// </summary>
        /// <value><see cref="CameraDevice"/></value>
        /// <since_tizen> 10 </since_tizen>
        public CameraDevice Device { get; }

        /// <summary>
        /// Gets the camera device name.
        /// </summary>
        /// <value>The camera device name</value>
        /// <since_tizen> 10 </since_tizen>
        public string Name { get; }

        /// <summary>
        /// Gets the camera device ID.
        /// </summary>
        /// <value>The camera device ID.</value>
        /// <since_tizen> 10 </since_tizen>
        public string Id { get; }

        /// <summary>
        /// Gets the number of extra streams.
        /// </summary>
        /// <value>The number of extra streams.</value>
        /// <since_tizen> 10 </since_tizen>
        public int NumberOfExtraStream { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 10 </since_tizen>
        public override string ToString() =>
            $"Type:{Type.ToString()}, Device:{Device.ToString()}, Name:{Name}, Id:{Id}, NumberOfExtraStream:{NumberOfExtraStream}";
    }
}
