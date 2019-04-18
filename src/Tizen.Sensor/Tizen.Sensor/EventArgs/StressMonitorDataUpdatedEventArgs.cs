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
    /// Data of the stress monitor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SensorStressMonitorData
    {
        internal const int SENSOR_STRESS_MONITOR_DATA_SIZE = 600;
        internal const int SENSOR_STRESS_MONITOR_BUF_SIZE = 44;

        /// <summary> 
        /// Mode value 
        /// </summary>
        public int Mode
        {
            get { return Mode; }
            private set { }
        }

        /// <summary>
        /// Accuracy value
        /// </summary>
        public int Accuracy
        {
            get { return Accuracy; }
            private set { }
        }

        /// <summary>
        /// Value Count
        /// </summary>
        public int ValueCount
        {
            get { return ValueCount; }
            private set { }
        }

        /// <summary>
        /// Values of the stress monitor sensor
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct StressMonitorValue
        {
            /// <summary> 
            /// Time stamp value 
            /// </summary>
            public UInt64 TimeStamp
            {
                get { return TimeStamp; }
                private set { }
            }

            /// <summary> 
            /// Flag value 
            /// </summary>
            public Byte Flag
            {
                get { return Flag; }
                private set { }
            }

            /// <summary>
            /// Stress value
            /// </summary>
            public Byte Stress
            {
                get { return Stress; }
                private set { }
            }

            /// <summary>
            /// Progress value
            /// </summary>
            public Byte Progress
            {
                get { return Progress; }
                private set { }
            }

            /// <summary>
            /// Info algo value 
            /// </summary>
            public Byte InfoAlgo
            {
                get { return InfoAlgo; }
                private set { }
            }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SENSOR_STRESS_MONITOR_DATA_SIZE)]
        private StressMonitorValue[] values;

        /// <summary> 
        /// Array of StressMonitorValue
        /// </summary>
        public StressMonitorValue[] Values
        {
            get { return values; }
            private set { }
        }

    /// <summary>
    /// Base Hr value
    /// </summary>
    public UInt32 BaseHr
        {
            get { return BaseHr; }
            private set { }
        }


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SENSOR_STRESS_MONITOR_BUF_SIZE)]
        private UInt32[] histogram;

        /// <summary> 
        /// Array of Histogram values
        /// </summary>
        public UInt32[] Histogram
        {
            get { return histogram; }
            private set { }
        }
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
        /// <value>
        /// The stress monitor data.
        /// </value>
        public SensorStressMonitorData Data { get; private set; }
    }
}
