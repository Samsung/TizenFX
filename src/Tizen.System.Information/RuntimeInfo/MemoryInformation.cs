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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// Memory information.
    /// </summary>
    public class SystemMemoryInformation
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal SystemMemoryInformation(Interop.RuntimeInfo.MemoryInfo info)
        {
            Total = info.Total;
            Used = info.Used;
            Cache = info.Cache;
            Free = info.Free;
            Swap = info.Swap;
        }
        /// <summary>
        /// Total memory (KiB).
        /// </summary>
        public int Total { get; internal set; }
        /// <summary>
        /// Used memory (KiB).
        /// </summary>
        public int Used { get; internal set; }
        /// <summary>
        /// Free memory (KiB).
        /// </summary>
        public int Free { get; internal set; }
        /// <summary>
        /// Cache memory (KiB).
        /// </summary>
        public int Cache { get; internal set; }
        /// <summary>
        /// Swap memory (KiB).
        /// </summary>
        public int Swap { get; internal set; }
    }

    /// <summary>
    /// Memory information per process.
    /// </summary>
    public class ProcessMemoryInformation
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ProcessMemoryInformation(Interop.RuntimeInfo.ProcessMemoryInfo info)
        {
            PrivateClean = info.PrivateClean;
            PrivateDirty = info.PrivateDirty;
            Pss = info.Pss;
            Rss = info.Rss;
            SharedClean = info.SharedClean;
            SharedDirty = info.SharedDirty;
            Vsz = info.Vsz;
        }
        /// <summary>
        /// Virtual memory size (KiB).
        /// </summary>
        public int Vsz { get; internal set; }
        /// <summary>
        /// Resident set size (KiB).
        /// </summary>
        public int Rss { get; internal set; }
        /// <summary>
        /// Proportional set size (KiB).
        /// </summary>
        public int Pss { get; internal set; }
        /// <summary>
        /// Not modified and mapped by other processes (KiB).
        /// </summary>
        public int SharedClean { get; internal set; }
        /// <summary>
        /// Modified and mapped by other processes (KiB).
        /// </summary>
        public int SharedDirty { get; internal set; }
        /// <summary>
        /// Not modified and available only to that process (KiB).
        /// </summary>
        public int PrivateClean { get; internal set; }
        /// <summary>
        /// Modified and available only to that process (KiB).
        /// </summary>
        public int PrivateDirty { get; internal set; }
    }
}
