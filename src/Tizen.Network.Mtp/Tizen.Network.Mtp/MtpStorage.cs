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
    /// A class for Mtp Storage informations. It allows applications to handle storage informations.
    /// </summary>
    public class MtpStorage : IDisposable
    {
        private int _deviceHandle = -1;
        private int _storageHandle = -1;
        private bool disposed = false;
        private List<int> _objectHandleList = new List<int>();
        private List<MtpObject> _objectList = new List<MtpObject>();
        //private int _objectHandle = 0;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>Description of storage.</value>
        public string Description
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.StorageInformation.GetDescription(_deviceHandle, _storageHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get description, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// Gets the free space.
        /// </summary>
        /// <value>Free space of storage.</value>
        public UInt64 FreeSpace
        {
            get
            {
                UInt64 freeSpace;
                int ret = Interop.Mtp.StorageInformation.GetFreeSpace(_deviceHandle, _storageHandle, out freeSpace);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get free space, Error - " + (MtpError)ret);
                }
                return freeSpace;
            }
        }

        /// <summary>
        /// Gets the max capacity.
        /// </summary>
        /// <value>Max capacity of storage.</value>
        public UInt64 MaxCapacity
        {
            get
            {
                UInt64 maxCapacity;
                int ret = Interop.Mtp.StorageInformation.GetMaxCapacity(_deviceHandle, _storageHandle, out maxCapacity);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get free space, Error - " + (MtpError)ret);
                }
                return maxCapacity;
            }
        }

        /// <summary>
        /// Gets the storage type.
        /// </summary>
        /// <value>Type of storage.</value>
        public MtpStorageType StorageType
        {
            get
            {
                int storageType;
                int ret = Interop.Mtp.StorageInformation.GetStorageType(_deviceHandle, _storageHandle, out storageType);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get free space, Error - " + (MtpError)ret);
                }
                return (MtpStorageType)storageType;
            }
        }

        /// <summary>
        /// Gets the volume identifier.
        /// </summary>
        /// <value>Volume identifier of stroage.</value>
        public string VolumeIdentifier
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.StorageInformation.GetVolumeIdentifier(_deviceHandle, _storageHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get volume identifier, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        internal MtpStorage(int deviceHandle, int storageHandle)
        {
            _deviceHandle = deviceHandle;
            _storageHandle = storageHandle;
        }

        ~MtpStorage()
        {
            Dispose(false);
        }

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
/*                foreach (SmartcardChannel channel in _basicChannelList)
                {
                    channel.Dispose();
                    _basicChannelList.Remove(channel);
                }

                foreach (SmartcardChannel channel in _logicalChannelList)
                {
                    channel.Dispose();
                    _logicalChannelList.Remove(channel);
                }
*/            }
            //Free unmanaged objects
            disposed = true;
        }

        internal int GetHandle()
        {
            return _storageHandle;
        }

        /// <summary>
        /// Gets the list of storages.
        /// </summary>
        /// <returns>List of storage objects.</returns>
        /// <feature>http://tizen.org/feature/network.mtp</feature>
        /// <remarks>
        /// http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage.
        /// http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when Mtp is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when method is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        public IEnumerable<MtpObject> GetObjectHandles(int parentHandle, MtpFileType fileType)
        {
            IntPtr objectPtr;
            int count = 0;

            int ret = Interop.Mtp.GetObjectHandles(_deviceHandle, _storageHandle, parentHandle, (int)fileType, out objectPtr, out count);
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get object handle lists, Error - " + (MtpError)ret);
                MtpErrorFactory.ThrowMtpException(ret);
            }

            for (int i = 0; i < count; i++)
            {
                int objectID = Marshal.ReadInt32(objectPtr);

                MtpObject objectItem = new MtpObject(_deviceHandle, objectID);
                _objectList.Add(objectItem);
                objectPtr += sizeof(int);
            }

            return _objectList;
        }
    }
}
