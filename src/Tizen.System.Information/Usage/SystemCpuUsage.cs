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
using System.IO;

namespace Tizen.System
{
    /// <summary>
    /// The class for CPU usage information of the system.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SystemCpuUsage
    {
        private Interop.RuntimeInfo.CpuUsage Usage;
        private int[] CurrentFrequencies;
        private int[] MaxFrequencies;

        /// <summary>
        /// The constructor of SystemCpuUsage class. It internally call Update() on constructing an instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system.</exception>
        /// <exception cref="NotSupportedException">Thrown when this system does not store the current CPU frequency.</exception>
        public SystemCpuUsage()
        {
            Update();
        }

        /// <summary>
        /// Running time of un-niced user processes (Percent). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public double User
        {
            get
            {
                return Usage.User;
            }
        }

        /// <summary>
        /// Running time of kernel processes (Percent). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public double System
        {
            get
            {
                return Usage.System;
            }
        }

        /// <summary>
        /// Running time of niced user processes (Percent). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public double Nice
        {
            get
            {
                return Usage.Nice;
            }
        }

        /// <summary>
        /// Time waiting for I/O completion (Percent). To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public double IoWait
        {
            get
            {
                return Usage.IoWait;
            }
        }

        /// <summary>
        /// The number of processors.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int ProcessorCount { get; internal set; }

        /// <summary>
        /// Gets the current frequency of the processor. To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="coreId">The index (from 0) of the CPU core that you want to know the frequency of.</param>
        /// <returns>The current frequency(MHz) of processor.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="coreId"/> is invalid.</exception>
        public int GetCurrentFrequency(int coreId)
        {
            if(coreId < 0 || coreId >= ProcessorCount)
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid core ID " + coreId);
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            return CurrentFrequencies[coreId];
        }

        /// <summary>
        /// Gets the max frequency of the processor. To get the latest value, it is recommended to call Update() before it.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="coreId">The index (from 0) of CPU core that you want to know the frequency of.</param>
        /// <returns>The max frequency(MHz) of processor.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="coreId"/> is invalid.</exception>
        public int GetMaxFrequency(int coreId)
        {
            if (coreId < 0 || coreId >= ProcessorCount)
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid core ID " + coreId);
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            return MaxFrequencies[coreId];
        }

        /// <summary>
        /// Update the system CPU usage information to the latest.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="IOException">Thrown when an I/O error occurs while reading from the system.</exception>
        /// <exception cref="NotSupportedException">Thrown when this system does not store the current CPU frequency.</exception>
        public void Update()
        {
            InformationError ret;
            int count;

            ret = Interop.RuntimeInfo.GetCpuUsage(out Usage);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get cpu usage");
                InformationErrorFactory.ThrowException(ret);
            }

            ret = Interop.RuntimeInfo.GetProcessorCount(out count);
            if (ret != InformationError.None)
            {
                Log.Error(InformationErrorFactory.LogTag, "Interop failed to get Processor count");
                InformationErrorFactory.ThrowException(ret);
                return;
            }

            ProcessorCount = count;
            CurrentFrequencies = new int[ProcessorCount];
            MaxFrequencies = new int[ProcessorCount];

            for (int coreId = 0; coreId < ProcessorCount; coreId++)
            {
                ret = Interop.RuntimeInfo.GetProcessorCurrentFrequency(coreId, out CurrentFrequencies[coreId]);
                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get the current frequency of processor " + coreId);
                    InformationErrorFactory.ThrowException(ret);
                }

                ret = Interop.RuntimeInfo.GetProcessorMaxFrequency(coreId, out MaxFrequencies[coreId]);
                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get the max frequency of processor " + coreId);
                    InformationErrorFactory.ThrowException(ret);
                }
            }
        }
    }
}
