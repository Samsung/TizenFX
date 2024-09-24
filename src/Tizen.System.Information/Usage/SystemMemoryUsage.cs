/*
* Copyright (c) 2016 - 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.IO;

namespace Tizen.System
{
    /// <summary>
    /// The class for memory usage information of the system.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SystemMemoryUsage
    {
        private Interop.RuntimeInfo.MemoryInfo Info;

        /// <summary>
        /// The constructor of MemoryInformation class. It internally call Update() on constructing an instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system.</exception>
        public SystemMemoryUsage()
        {
            Update();
        }

        /// <summary>
        /// Total memory (KiB). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Total
        {
            get
            {
                return Info.Total;
            }
        }

        /// <summary>
        /// Used memory (KiB). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Used
        {
            get
            {
                return Info.Used;
            }
        }

        /// <summary>
        /// Free memory (KiB). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Free
        {
            get
            {
                return Info.Free;
            }
        }

        /// <summary>
        /// Cache memory (KiB). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Cache
        {
            get
            {
                return Info.Cache;
            }
        }

        /// <summary>
        /// Swap memory (KiB). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Swap
        {
            get
            {
                return Info.Swap;
            }
        }

        /// <summary>
        /// Update the system memory information to the latest.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="IOException">Thrown when I/O error occurs while reading from the system.</exception>
        public void Update()
        {
            InformationError ret = Interop.RuntimeInfo.GetSystemMemoryInfo(out Info);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get System memory information");
                InformationErrorFactory.ThrowException(ret);
            }
        }
    }
}
