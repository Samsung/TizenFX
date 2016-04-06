/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.System
{
    /// <summary>
    /// Memory information.
    /// </summary>
    public class SystemMemoryInformation
    {
        internal SystemMemoryInformation(Interop.RuntimeInfo.MemoryInfo info)
        {
            Total = info.Total;
            Used = info.Used;
            Cache = info.Cache;
            Free = info.Free;
            Swap = info.Swap;
        }
        /// <summary>
        /// Total memory (KiB)
        /// </summary>
        public int Total { get; internal set; }
        /// <summary>
        /// Used memory (KiB)
        /// </summary>
        public int Used { get; internal set; }
        /// <summary>
        /// Free memory (KiB)
        /// </summary>
        public int Free { get; internal set; }
        /// <summary>
        /// Cache memory (KiB)
        /// </summary>
        public int Cache { get; internal set; }
        /// <summary>
        /// Swap memory (KiB)
        /// </summary>
        public int Swap { get; internal set; }
    }

    /// <summary>
    /// Memory information per processes
    /// </summary>
    public class ProcessMemoryInformation
    {
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
        /// Virtual memory size (KiB)
        /// </summary>
        public int Vsz { get; internal set; }
        /// <summary>
        /// Resident set size (KiB)
        /// </summary>
        public int Rss { get; internal set; }
        /// <summary>
        /// Proportional set size (KiB)
        /// </summary>
        public int Pss { get; internal set; }
        /// <summary>
        /// Not modified and mapped by other processes (KiB)
        /// </summary>
        public int SharedClean { get; internal set; }
        /// <summary>
        /// Modified and mapped by other processes (KiB)
        /// </summary>
        public int SharedDirty { get; internal set; }
        /// <summary>
        /// Not modified and available only to that process (KiB)
        /// </summary>
        public int PrivateClean { get; internal set; }
        /// <summary>
        /// Modified and available only to that process (KiB)
        /// </summary>
        public int PrivateDirty { get; internal set; }
    }
}
