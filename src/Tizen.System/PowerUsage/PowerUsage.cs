/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.System
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.System.PowerUsage";
    }

    /// <summary>
    /// Enumeration for battery consuming features.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum ResourceType
    {
        /// <summary>
        /// Bluetooth Low Energy.
        /// </summary>
        Ble = 0,

        /// <summary>
        /// Wi-Fi.
        /// </summary>
        Wifi = 1,

        /// <summary>
        /// CPU.
        /// </summary>
        Cpu = 2,

        /// <summary>
        /// Display.
        /// </summary>
        Display = 3,

        /// <summary>
        /// Device Network.
        /// </summary>
        DeviceNetwork = 4,

        /// <summary>
        /// GPS Sensor.
        /// </summary>
        Gps = 5
    }

    /// <summary>
    /// Provides information related to the power consumption by applications or by hardware resources on a battery-powered device for a given duration of time.
    /// </summary>
    /// <feature>http://tizen.org/feature/battery</feature>
    /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
    /// <since_tizen> 7 </since_tizen>
    public static class PowerUsage
    {
        static PowerUsage()
        {
        }

        private static double GetPowerUsage(IntPtr BMHandle, ResourceType rtype)
        {
            double batteryUsage = 0;
            int ret = Interop.PowerUsage.GetPowerUsage(BMHandle, rtype, out batteryUsage);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for resource" + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }

        private static long ConvertDateTimeToTimestamp(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)((dateTime.ToUniversalTime() - epoch).TotalSeconds);
        }

        /// <summary>
        /// Gets the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="start">Start Time for data in DateTime.</param>
        /// <param name="end">End Time for data in DateTime.</param>
        /// <param name="rtypes">list of resource type identifiers like BLE, WiFi, CPU etc.</param>
        /// <returns>Returns the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.</returns>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static IList<double> GetPowerUsage(string appID, IList<ResourceType> rtypes, DateTime start, DateTime end)
        {
            IntPtr bmHandle = IntPtr.Zero;
            IList<double> batteryUsage = new List<double>();
            int ret = Interop.PowerUsage.GetPowerUsage(appID, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), bmHandle);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for all resources" + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }

            if (rtypes != null)
            {
                foreach (ResourceType type in rtypes)
                {
                    batteryUsage.Add(GetPowerUsage(bmHandle, type));
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Resource types parameter is empty");
            }

            ret = Interop.PowerUsage.Destroy(bmHandle);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error in Destroy handle, " + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }

        /// <summary>
        /// Gets the battery consumption in mAh(milli-Ampere hour) for the specific resource for the given application in custom interval.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="start">Start Time for data in DateTime.</param>
        /// <param name="end">End Time for data in DateTime.</param>
        /// <returns>Returns the battery consumption in mAh(milli-Ampere hour) for the specific resource for the given application in custom interval.</returns>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(string appID, ResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.PowerUsage.GetPowerUsage(appID, rtype, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage by app for resrource" + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }

        /// <summary>
        /// Gets the total battery usage in mAh(milli-Ampere hour) by an application for certain time interval.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="start">Start Time for data in DateTime.</param>
        /// <param name="end">End Time for data in DateTime.</param>
        /// <returns>Returns the total battery usage in mAh(milli-Ampere hour) by an application for certain time interval.</returns>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(string appID, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.PowerUsage.GetPowerUsage(appID, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total  battery usage by app," + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }

        /// <summary>
        /// Gets the battery usage in mAh(milli-Ampere hour) by a resource for certain time interval.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="start">Start Time for data in DateTime.</param>
        /// <param name="end">End Time for data in DateTime.</param>
        /// <returns>Returns the battery usage in mAh(milli-Ampere hour) by a resource for certain time interval.</returns>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(ResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.PowerUsage.GetPowerUsage(rtype, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((PowerUsageError)ret != PowerUsageError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total battery usage by resource ," + (PowerUsageError)ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }
    }
}
