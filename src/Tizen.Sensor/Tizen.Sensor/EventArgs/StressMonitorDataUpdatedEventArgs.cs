/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Sensor
{
    /// <summary>
    ///StressMonitorData
    /// </summary>
    public struct SensorStressMonitorData
    {
        internal const int SENSOR_STRESS_MONITOR_DATA_SIZE = 600;
        internal const int SENSOR_STRESS_MONITOR_BUF_SIZE = 44;
        public int Mode;
        public int Accuracy;
        public int ValueCount;

        /// <summary>
        ///StressMonitorValue
        /// </summary>
        public struct StressMonitorValue
        {
            public UInt64 TimeStamp;
            public Byte Flag;
            public Byte Stress;
            public Byte Progress;
            public Byte InfoAlgo;
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SENSOR_STRESS_MONITOR_DATA_SIZE)]
        public StressMonitorValue[] Values;

        public UInt32 BaseHr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SENSOR_STRESS_MONITOR_BUF_SIZE)]
        public UInt32[] Histogram;
    }
    /// <summary>
    /// The StressMonitor changed event arguments class is used for storing the data returned by a stress monitor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class StressMonitorDataUpdatedEventArgs : EventArgs
    {
        internal StressMonitorDataUpdatedEventArgs(IntPtr stressValue)
        {
            Data = Interop.IntPtrToStressMonitorData(stressValue);
        }

        /// <summary>
        /// Gets the value of the stress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The stress monitor data. </value>
        public SensorStressMonitorData Data { get; private set; }
    }
}
