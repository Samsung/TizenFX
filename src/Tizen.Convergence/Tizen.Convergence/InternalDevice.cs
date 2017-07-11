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
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.Convergence
{
    /// <summary>
    /// The class encapsulates a D2D convergence compliant device information
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InternalDevice : IDisposable
    {
        internal const string DeviceIdKey = "device_id";
        internal const string DeviceNameKey = "device_name";
        internal const string DeviceTypeKey = "device_type";
        internal Interop.Internal.ConvDeviceHandle _deviceHandle;
        internal List<InternalService> _services = new List<InternalService>();

        /// <summary>
        /// The Unique ID of the device
        /// </summary>
        public string Id { get;}

        /// <summary>
        /// Name of the device
        /// </summary>
        public string Name { get;}

        /// <summary>
        /// The profile of the device
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// List of services supported by the device
        /// </summary>
        public IEnumerable<InternalService> Services
        {
            get
            {
                return _services;
            }
        }

        internal InternalDevice(IntPtr deviceHandle)
        {
            int ret = Interop.Internal.ConvDevice.Clone(deviceHandle, out _deviceHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to clone device");
                throw ErrorFactory.GetException(ret);
            }

            IntPtr stringPtr = IntPtr.Zero;
            ret = Interop.Internal.ConvDevice.GetPropertyString(_deviceHandle, DeviceIdKey, out stringPtr);
            if (ret == (int)ConvErrorCode.None)
            {
                Id = Marshal.PtrToStringAnsi(stringPtr);
                Interop.Libc.Free(stringPtr);
            }

            ret = Interop.Internal.ConvDevice.GetPropertyString(_deviceHandle, DeviceNameKey, out stringPtr);
            if (ret == (int)ConvErrorCode.None)
            {
                Name = Marshal.PtrToStringAnsi(stringPtr);
                Interop.Libc.Free(stringPtr);
            }

            ret = Interop.Internal.ConvDevice.GetPropertyString(_deviceHandle, DeviceTypeKey, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Type = Marshal.PtrToStringAnsi(stringPtr);
                Interop.Libc.Free(stringPtr);
            }

            Log.Debug(ErrorFactory.LogTag, "Device ID ,Name, and Type:[" + Id +"," + Name +"," + Type +"]");

            Interop.Internal.ConvDevice.ConvServiceForeachCallback cb = (IntPtr serviceHandle, IntPtr userData) =>
            {
                    _services.Add(InternalService.GetService(serviceHandle));
            };

            ret = Interop.Internal.ConvDevice.ForeachService(_deviceHandle, cb, IntPtr.Zero);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to get device services");
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            _deviceHandle.Dispose();
        }
    }
}
