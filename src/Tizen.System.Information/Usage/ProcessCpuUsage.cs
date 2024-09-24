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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.System
{
    /// <summary>
    /// The class for CPU usage per given list of process.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ProcessCpuUsage
    {
        private int[] Pids;
        private Interop.RuntimeInfo.ProcessCpuUsage[] Usages;

        /// <summary>
        /// The constructor of ProcessCpuUsage class of the given list of process. It internally call Update() on constructing an instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">List of unique process ids.</param>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is empty.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system or requesting to the resource management daemon.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have privilege to use this method.</exception>
        public ProcessCpuUsage(IEnumerable<int> pid)
        {
            Update(pid);
        }

        /// <summary>
        /// The number of processes being tracked by the instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Count { get; internal set; }

        /// <summary>
        /// Gets the amount of time this process has been scheduled in user mode. To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The amount of time <paramref name="pid"/> has been scheduled in user mode (clock ticks).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public uint GetUTime(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].UTime;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the amount of time this process has been scheduled in kernel mode. To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The amount of time <paramref name="pid"/> has been scheduled in kernel mode (clock ticks).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public uint GetSTime(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].STime;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Update CPU usage of the given processes to the latest.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">List of unique process ids.</param>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is empty.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system or requesting to the resource management daemon.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have privilege to use this method.</exception>
        public void Update(IEnumerable<int> pid)
        {
            InformationError ret;

            Pids = pid.ToArray<int>();
            IntPtr ptr = new IntPtr();
            Count = Pids.Count<int>();

            ret = Interop.RuntimeInfo.GetProcessCpuUsage(Pids, Count, ref ptr);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get Process cpu usage");
                InformationErrorFactory.ThrowException(ret);
            }

            Usages = new Interop.RuntimeInfo.ProcessCpuUsage[Count];
            for (int i = 0; i < Count; i++)
            {
                Usages[i] = Marshal.PtrToStructure<Interop.RuntimeInfo.ProcessCpuUsage>(ptr);
                ptr += Marshal.SizeOf<Interop.RuntimeInfo.ProcessCpuUsage>();
            }
        }
    }
}
