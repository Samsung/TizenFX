/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;

namespace Tizen.Network.Mtp
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Mtp";
    }

    internal partial class MtpManagerImpl : IDisposable
    {
        private static readonly MtpManagerImpl _instance = new MtpManagerImpl();
        private List<MtpDevice> _deviceList = new List<MtpDevice>();
        private bool disposed = false;

        internal static MtpManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private MtpManagerImpl()
        {
            Initialize();
        }

        ~MtpManagerImpl()
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
            }
            //Free unmanaged objects
            Deinitialize();
            disposed = true;
        }

        private void Initialize()
        {
            int ret = Interop.Mtp.Initialize();
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to Initialize Mtp, Error - " + (MtpError)ret);
                MtpErrorFactory.ThrowMtpException(ret);
            }
        }

        private void Deinitialize()
        {
            int ret = Interop.Mtp.Deinitialize();
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to Deinitialize Mtp, Error - " + (MtpError)ret);
            }
        }

        internal IEnumerable<MtpDevice> GetDevices()
        {
            IntPtr devicePtr;
            int count = 0;

            int ret = Interop.Mtp.GetDevices(out devicePtr, out count);
            if (ret != (int)MtpError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get device list, Error - " + (MtpError)ret);
                MtpErrorFactory.ThrowMtpException(ret);
            }

            for (int i = 0; i < count; i++)
            {
                int deviceID = Marshal.ReadInt32(devicePtr);

                MtpDevice deviceItem = new MtpDevice(deviceID);
                _deviceList.Add(deviceItem);
                devicePtr += sizeof(int);
            }

            return _deviceList;
        }
    }
}
