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
    /// Structure for cpu usage.
    /// </summary>
    public class CpuUsage
    {
        internal CpuUsage(Interop.RuntimeInfo.CpuUsage usage)
        {
            IoWait = usage.IoWait;
            Nice = usage.IoWait;
            System = usage.System;
            User = usage.User;
        }
        /// <summary>
        /// Time running un-niced user processes (Percent)
        /// </summary>
        public double User { get; internal set; }
        /// <summary>
        /// Time running kernel processes (Percent)
        /// </summary>
        public double System { get; internal set; }
        /// <summary>
        /// Time running niced user processes (Percent)
        /// </summary>
        public double Nice { get; internal set; }
        /// <summary>
        /// Time waiting for I/O completion (Percent)
        /// </summary>
        public double IoWait { get; internal set; }
    }

    /// <summary>
    /// Structure for cpu usage per processes
    /// </summary>
    public class ProcessCpuUsage
    {
        internal ProcessCpuUsage(Interop.RuntimeInfo.ProcessCpuUsage usage)
        {
            UTime = usage.UTime;
            STime = usage.STime;
        }
        /// <summary>
        /// Amount of time that this process has been scheduled in user mode (clock ticks)
        /// </summary>
        public uint UTime { get; internal set; }
        /// <summary>
        /// Amount of time that this process has been scheduled in kernel mode (clock ticks)
        /// </summary>
        public uint STime { get; internal set; }
    }
}
