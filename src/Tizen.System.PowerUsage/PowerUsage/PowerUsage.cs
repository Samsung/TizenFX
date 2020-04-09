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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for battery consuming features.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum PowerUsageResourceType
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
        /// <summary>
        /// Gets the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="rtypes">list of resource type identifiers like BLE, WiFi, CPU etc.</param>
        /// <param name="start">Start Time for data in DateTime.</param>
        /// <param name="end">End Time for data in DateTime.</param>
        /// <returns>Returns the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.</returns>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static IDictionary<PowerUsageResourceType, double> GetPowerUsage(string appID, IList<PowerUsageResourceType> rtypes, DateTime start, DateTime end)
        {
            IntPtr dataHandle = IntPtr.Zero;
            DateTimeOffset startTime = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            DateTimeOffset endTime = DateTime.SpecifyKind(end, DateTimeKind.Utc);
            IDictionary<PowerUsageResourceType, double> batteryUsage = new Dictionary<PowerUsageResourceType, double>();
            try
            {
                PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.GetPowerUsageByAppForAllResources(appID, startTime.ToUnixTimeSeconds(), endTime.ToUnixTimeSeconds(), out dataHandle);
                if (ret != PowerUsageError.None)
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error getting battery usage for all resources" + ret);
                    throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
                }

                if (rtypes != null)
                {
                    foreach (PowerUsageResourceType type in rtypes)
                    {
                        try
                        {
                            batteryUsage[type] = GetPowerUsage(dataHandle, type);
                        }
                        catch (InvalidOperationException)
                        {
                            Log.Error(PowerUsageErrorFactory.LogTag, $"Error getting battery usage for {type}");
                        }
                    }
                }
                else
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Power usage resource types parameter is empty");
                    throw new ArgumentNullException(nameof(rtypes));
                }
            }
            finally
            {
                PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.BatteryUsageDataDestroy(dataHandle);
                if (ret != PowerUsageError.None)
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error in Destroy handle, " + ret);
                }
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
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(string appID, PowerUsageResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            DateTimeOffset startTime = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            DateTimeOffset endTime = DateTime.SpecifyKind(end, DateTimeKind.Utc);
            PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.GetPowerUsageByAppPerResource(appID, rtype, startTime.ToUnixTimeSeconds(), endTime.ToUnixTimeSeconds(), out batteryUsage);
            if (ret != PowerUsageError.None)
            {
                if (ret == PowerUsageError.RecordNotFound)
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error PowerUsageResourceType is not supported");
                    throw new ArgumentException($"{rtype} is not supproted", nameof(rtype));
                }
                else
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error getting battery usage by app per resrource ," + ret);
                    throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
                }
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
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(string appID, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            DateTimeOffset startTime = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            DateTimeOffset endTime = DateTime.SpecifyKind(end, DateTimeKind.Utc);
            PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.GetPowerUsageByApp(appID, startTime.ToUnixTimeSeconds(), endTime.ToUnixTimeSeconds(), out batteryUsage);
            if (ret != PowerUsageError.None)
            {
                Log.Error(PowerUsageErrorFactory.LogTag, "Error getting battery usage by app," + ret);
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
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case power usage is not supported</exception>
        public static double GetPowerUsage(PowerUsageResourceType rtype, DateTime start, DateTime end)
        {
            double batteryUsage = 0;
            DateTimeOffset startTime = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            DateTimeOffset endTime = DateTime.SpecifyKind(end, DateTimeKind.Utc);

            PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.GetPowerUsageByResource(rtype, startTime.ToUnixTimeSeconds(), endTime.ToUnixTimeSeconds(), out batteryUsage);
            if (ret != PowerUsageError.None)
            {
                if (ret == PowerUsageError.RecordNotFound)
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error PowerUsageResourceType is not supported");
                    throw new ArgumentException($"{rtype} is not supproted", nameof(rtype));
                }
                else
                {
                    Log.Error(PowerUsageErrorFactory.LogTag, "Error getting battery usage by resource ," + ret);
                    throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
                }
            }
            return batteryUsage;
        }

        private static double GetPowerUsage(IntPtr dataHandle, PowerUsageResourceType rtype)
        {
            double batteryUsage = 0;
            PowerUsageError ret = (PowerUsageError)Interop.PowerUsage.UsageDataGetPowerUsagePerResource(dataHandle, rtype, out batteryUsage);
            if (ret != PowerUsageError.None)
            {
                Log.Error(PowerUsageErrorFactory.LogTag, "Error getting battery usage for resource" + ret);
                throw PowerUsageErrorFactory.ThrowPowerUsageException(ret);
            }
            return batteryUsage;
        }
    }
}
