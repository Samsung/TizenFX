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

namespace Tizen.BatteryMonitor
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.BatteryMonitor";
    }

    /// <summary>
    /// Provides information related to the power consumption by applications or by hardware resources on a battery-powered device for a given duration of time.
    /// </summary>
    /// <feature>http://tizen.org/feature/battery</feature>
    /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
    /// <since_tizen> 7 </since_tizen>
    public static class BatteryMonitor
    {
        static BatteryMonitor()
        {
        }

        private static double GetPowerUsageForResource(IntPtr BMHandle, ResourceType rtype)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetPowerUsageForResource(BMHandle, rtype, out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for resource" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
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
        public static IList<double> GetPowerUsageByAppForAllResources(string appID, DateTime start, DateTime end, IList<ResourceType> rtypes)
        {
            IntPtr bmHandle = IntPtr.Zero;
            IList<double> batteryUsage = new List<double>();
            int ret = Interop.BatteryMonitor.GetPowerUsageByAppForAllResource(appID, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for all resources" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }

            foreach(ResourceType type in rtypes) {
                batteryUsage.Add(GetPowerUsageForResource(bmHandle,type));
            }
            ret = Interop.BatteryMonitor.Destroy(bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error in Destroy handle, " + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
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
        public static double GetPowerUsageByAppForResource(string appID, ResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetPowerUsageByAppForResource(appID, rtype, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage by app for resrource" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
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
        public static double GetTotalPowerUsage(string appID, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalPowerUsage(appID, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total  battery usage by app," + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
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
        public static double GetTotalPowerUsage(ResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalPowerUsage(rtype, ConvertDateTimeToTimestamp(start), ConvertDateTimeToTimestamp(end), out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total battery usage by resource ," + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
            return batteryUsage;
        }
    }
}
