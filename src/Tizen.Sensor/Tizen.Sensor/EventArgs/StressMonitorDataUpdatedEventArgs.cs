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
    /// Values of the stress monitor sensor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct StressMonitorValue : IEquatable<StressMonitorValue>
    {
        /// <summary> 
        /// Time stamp value 
        /// </summary>
        public UInt64 TimeStamp
        {
            get;
            private set;
        }

        /// <summary> 
        /// Flag value 
        /// </summary>
        public Byte Flag
        {
            get;
            private set;
        }

        /// <summary>
        /// Stress value
        /// </summary>
        public Byte Stress
        {
            get;
            private set;
        }

        /// <summary>
        /// Progress value
        /// </summary>
        public Byte Progress
        {
            get;
            private set;
        }

        /// <summary>
        /// Info algo value 
        /// </summary>
        public Byte InfoAlgo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="StressMonitorValue"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="StressMonitorValue"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return new { TimeStamp, Flag, Stress, Progress, InfoAlgo }.GetHashCode();
        }

        /// <summary>
        /// Compares two instances of <see cref="StressMonitorValue"/> for inequality.
        /// </summary>
        /// <param name="monitorValue1">A <see cref="StressMonitorValue"/> to compare.</param>
        /// <param name="monitorValue2">A <see cref="StressMonitorValue"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="StressMonitorValue"/> are equal; otherwise false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator !=(StressMonitorValue monitorValue1, StressMonitorValue monitorValue2)
        {
            return !(monitorValue1 == monitorValue2);
        }

        /// <summary>
        /// Compares two instances of <see cref="StressMonitorValue"/> for inequality.
        /// </summary>
        /// <param name="monitorValue1">A <see cref="StressMonitorValue"/> to compare.</param>
        /// <param name="monitorValue2">A <see cref="StressMonitorValue"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="StressMonitorValue"/> are not equal; otherwise false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator ==(StressMonitorValue monitorValue1, StressMonitorValue monitorValue2)
        {
            return !(monitorValue1 != monitorValue2);
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="StressMonitorValue"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the points are equal; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool Equals(object obj)
        {
            return obj is StressMonitorValue && this == (StressMonitorValue)obj;
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="StressMonitorValue"/> for equality.
        /// </summary>
        /// <param name="other">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the points are equal; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public bool Equals(StressMonitorValue other)
        {
            return this == (StressMonitorValue)other;
        }

    }

    /// <summary>
    /// Data of the stress monitor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SensorStressMonitorData : IEquatable<SensorStressMonitorData>
    {
        internal const int SENSOR_STRESS_MONITOR_DATA_SIZE = 600;
        internal const int SENSOR_STRESS_MONITOR_BUF_SIZE = 44;

        /// <summary> 
        /// Mode value 
        /// </summary>
        public int Mode
        {
            get;
            private set;
        }

        /// <summary>
        /// Accuracy value
        /// </summary>
        public int Accuracy
        {
            get;
            private set;
        }

        /// <summary>
        /// Value Count
        /// </summary>
        public int ValueCount
        {
            get;
            private set;
        }


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SENSOR_STRESS_MONITOR_DATA_SIZE)]
        private StressMonitorValue[] values;

        /// <summary> 
        /// Array of StressMonitorValue
        /// </summary>
        public StressMonitorValue[] Values
        {
            get;
            private set;
        }

        /// <summary>
        /// Base Hr value
        /// </summary>
        public UInt32 BaseHr
        {
            get;
            private set;
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

        /// <summary>
        /// Gets the hash code for this instance of <see cref="SensorStressMonitorData"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="SensorStressMonitorData"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return new { Mode, Accuracy, ValueCount, Values, BaseHr, Histogram }.GetHashCode();
        }

        /// <summary>
        /// Compares two instances of <see cref="SensorStressMonitorData"/> for inequality.
        /// </summary>
        /// <param name="monitorData1">A <see cref="SensorStressMonitorData"/> to compare.</param>
        /// <param name="monitorData2">A <see cref="SensorStressMonitorData"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="SensorStressMonitorData"/> are equal; otherwise false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator !=(SensorStressMonitorData monitorData1, SensorStressMonitorData monitorData2)
        {
            return !(monitorData1 == monitorData2);
        }

        /// <summary>
        /// Compares two instances of <see cref="SensorStressMonitorData"/> for inequality.
        /// </summary>
        /// <param name="monitorData1">A <see cref="SensorStressMonitorData"/> to compare.</param>
        /// <param name="monitorData2">A <see cref="SensorStressMonitorData"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="SensorStressMonitorData"/> are not equal; otherwise false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator ==(SensorStressMonitorData monitorData1, SensorStressMonitorData monitorData2)
        {
            return !(monitorData1 != monitorData2);
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="SensorStressMonitorData"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the points are equal; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool Equals(object obj)
        {
            return obj is SensorStressMonitorData && this == (SensorStressMonitorData)obj;
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="SensorStressMonitorData"/> for equality.
        /// </summary>
        /// <param name="other">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the points are equal; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public bool Equals(SensorStressMonitorData other)
        {
            return this == (SensorStressMonitorData)other;
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
