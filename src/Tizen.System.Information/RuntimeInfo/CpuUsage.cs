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

namespace Tizen.System
{
    /// <summary>
    /// Structure for CPU usage.
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
    /// Structure for CPU usage per processes
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
