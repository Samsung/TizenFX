﻿/*
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
    /// The class for memory information per process.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ProcessMemoryUsage
    {
        private int[] Pids;
        private Interop.RuntimeInfo.ProcessMemoryInfo[] Usages;
        private int[] Swaps;
        private int[] Gpus;
        private int[] Gems;

        /// <summary>
        /// The constructor of ProcessMemoryInformation class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">List of unique process ids.</param>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is empty.</exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system or requesting to the resource management daemon.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have privilege to use this method.</exception>
        public ProcessMemoryUsage(IEnumerable<int> pid)
        {
            Update(pid);
        }

        /// <summary>
        /// The number of usage entries.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Count { get; internal set; }

        /// <summary>
        /// Gets the virtual memory size of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The virtual memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetVsz(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].Vsz;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the resident set size of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The resident set size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetRss(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].Rss;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the proportional set size of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The proportional set size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetPss(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].Pss;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the size not modified and mapped by other processes of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The shared clean memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetSharedClean(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].SharedClean;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the size modified and mapped by other processes of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The shared dirty memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetSharedDirty(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].SharedDirty;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the size not modified and available only to that process of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The private clean memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetPrivateClean(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].PrivateClean;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the size modified and available only to that process of a process.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The private dirty memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetPrivateDirty(int pid)
        {
            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Usages[i].PrivateDirty;

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the GPU memory size of a process.
        /// </summary>
        /// <since_tizen> 6.5 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The GPU memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetGPU(int pid)
        {
            if (Gpus == null)
            {
                Log.Error(InformationErrorFactory.LogTag, "No data");
                InformationErrorFactory.ThrowException(InformationError.NoData);
            }

            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Gpus[i];

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the resident set size in graphic execution manager of a process.
        /// </summary>
        /// <since_tizen> 6.5 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The resident set size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetGemRss(int pid)
        {
            if (Gems == null)
            {
                Log.Error(InformationErrorFactory.LogTag, "No data");
                InformationErrorFactory.ThrowException(InformationError.NoData);
            }

            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Gems[i];

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        /// <summary>
        /// Gets the SWAP memory size of a process.
        /// </summary>
        /// <since_tizen> 6.5 </since_tizen>
        /// <param name="pid">The process id.</param>
        /// <returns>The SWAP memory size <paramref name="pid"/> is using (KiB).</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="pid"/> is invalid.</exception>
        public int GetSwap(int pid)
        {
            if (Swaps == null)
            {
                Log.Error(InformationErrorFactory.LogTag, "No data");
                InformationErrorFactory.ThrowException(InformationError.NoData);
            }

            for (int i = 0; i < Count; i++)
                if (pid == Pids[i])
                    return Swaps[i];

            Log.Error(InformationErrorFactory.LogTag, "Invalid pid");
            InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            return 0;
        }

        private void GetProcessMemoryValueInt(Interop.RuntimeInfo.ProcessMemoryInfoKey key, out int[] array)
        {
            InformationError ret;
            IntPtr ptr = new IntPtr();

            ret = Interop.RuntimeInfo.GetProcessMemoryValueInt(Pids, Count, key, out ptr);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get process memory info: " + key.ToString());
                InformationErrorFactory.ThrowException(ret);
            }

            array = new int[Count];
            unsafe
            {
                for (int i = 0; i < Count; i++)
                    array[i] = *((int*)ptr.ToPointer() + (i * sizeof(int)));
            }
        }

        /// <summary>
        /// Update the process memory information to the latest.
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

            ret = Interop.RuntimeInfo.GetProcessMemoryInfo(Pids, Count, ref ptr);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get Process cpu usage.");
                InformationErrorFactory.ThrowException(ret);
            }

            Usages = new Interop.RuntimeInfo.ProcessMemoryInfo[Count];
            for (int i = 0; i < Count; i++)
            {
                Usages[i] = Marshal.PtrToStructure<Interop.RuntimeInfo.ProcessMemoryInfo>(ptr);
                ptr += Marshal.SizeOf<Interop.RuntimeInfo.ProcessCpuUsage>();
            }

            try
            {
                GetProcessMemoryValueInt(Interop.RuntimeInfo.ProcessMemoryInfoKey.Gpu, out Gpus);
            }
            catch (NotSupportedException)
            {
            }

            try
            {
                GetProcessMemoryValueInt(Interop.RuntimeInfo.ProcessMemoryInfoKey.GemRss, out Gems); ;
            }
            catch (NotSupportedException)
            {
            }

            try
            {
                GetProcessMemoryValueInt(Interop.RuntimeInfo.ProcessMemoryInfoKey.Swap, out Swaps); ;
            }
            catch (NotSupportedException)
            {
            }
        }
    }
}
