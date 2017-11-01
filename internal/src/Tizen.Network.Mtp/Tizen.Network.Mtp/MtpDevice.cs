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
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Network.Mtp
{
    /// <summary>
    /// A class for Mtp Device information. It allows applications to handle device information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MtpDevice : IDisposable
    {
        private int _deviceHandle = -1;
        private bool disposed = false;
        private List<MtpStorage> _storageList = new List<MtpStorage>();

        /// <summary>
        /// Gets the manufacturer name of the device information.
        /// </summary>
        /// <value>Manufacture name of device.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ManufacturerName
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.DeviceInfomation.GetManufacturerName(_deviceHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get manufacturer name, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// Gets the model name of the device information.
        /// </summary>
        /// <value>Model name of device.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ModelName
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.DeviceInfomation.GetModelName(_deviceHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get model name, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// Gets the serial number of the device information.
        /// </summary>
        /// <value>Serial number of device.</value>
        /// <since_tizen> 4 </since_tizen>
        public string SerialNumber
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.DeviceInfomation.GetSerialNumber(_deviceHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get serial number, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// Gets the device version of the device information.
        /// </summary>
        /// <value>Version number of device.</value>
        /// <since_tizen> 4 </since_tizen>
        public string DeviceVersion
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.DeviceInfomation.GetDeviceVersion(_deviceHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get device version, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        internal MtpDevice(int handle)
        {
            _deviceHandle = handle;
        }

        /// <summary>
        /// MtpDevice destructor.
        /// </summary>
        ~MtpDevice()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                foreach (MtpStorage storage in _storageList)
                {
                    storage.Dispose();
                    _storageList.Remove(storage);
                }
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal int GetHandle()
        {
            return _deviceHandle;
        }

        /// <summary>
        /// Gets the list of storages.
        /// </summary>
        /// <returns>List of storage objects.</returns>
        /// <feature>http://tizen.org/feature/network.mtp</feature>
        /// <exception cref="NotSupportedException">Thrown when Mtp is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<MtpStorage> GetStorages()
        {
            IntPtr storagePtr;
            int count = 0;

            int ret = Interop.Mtp.GetStorages(_deviceHandle, out storagePtr, out count);
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get storage list, Error - " + (MtpError)ret);
                MtpErrorFactory.ThrowMtpException(ret);
            }

            for (int i = 0; i < count; i++)
            {
                int storageID = Marshal.ReadInt32(storagePtr);

                MtpStorage storageItem = new MtpStorage(_deviceHandle, storageID);
                _storageList.Add(storageItem);
                storagePtr += sizeof(int);
            }

            return _storageList;
        }
    }
}
