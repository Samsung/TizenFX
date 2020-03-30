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
    /// <since_tizen> 6 </since_tizen>
    public sealed class BatteryMonitor : IDisposable
    {
        private static volatile BatteryMonitor _instance = null;
        private static readonly object _syncLock = new object();
        private bool _disposed = false;

        /// <summary>
        /// The constructor of the BatteryMonitor class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        private BatteryMonitor()
        {
        }

        /// <summary>
        /// Returns an instance of BatteryMonitor class
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static BatteryMonitor Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_syncLock)
                {
                    if (_instance == null) {
                        _instance = new BatteryMonitor();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// The destructor of the BatteryMonitor class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~BatteryMonitor()
        {
            Dispose(false);
        }

        internal double GetPowerUsageForResource(IntPtr BMHandle, ResourceType rtype)
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

        /// <summary>
        /// Gets the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="stime">Start Time for data in Epoch Time (in seconds).</param>
        /// <param name="etime">End Time for data in Epoch Time (in seconds).</param>
        /// <param name="rtypes">list of resource type identifiers like BLE, WiFi, CPU etc.</param>
        /// <returns>Returns the battery consumption in mAh(milli-Ampere hour) for the resources specified by the application in custom interval.</returns>
        public List<double> GetPowerUsageByAppForAllResource(string appID, long stime, long etime, List<ResourceType> rtypes)
        {
            IntPtr bmHandle = IntPtr.Zero;
            List<double> batteryUsage = new List<double>();
            int ret = Interop.BatteryMonitor.GetPowerUsageByAppForAllResource(appID, stime, etime, bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for all resources" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }

            foreach(ResourceType type in rtypes) {
                batteryUsage.Add(_instance.GetPowerUsageForResource(bmHandle,type));
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
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="stime">Start Time for data in Epoch Time (in seconds).</param>
        /// <param name="etime">End Time for data in Epoch Time (in seconds).</param>
        /// <returns>Returns the battery consumption in mAh(milli-Ampere hour) for the specific resource for the given application in custom interval.</returns>
        public double GetPowerUsageByAppForResource(string appID, ResourceType rtype, long stime, long etime)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetPowerUsageByAppForResource(appID, rtype, stime, etime, out batteryUsage);
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
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="stime">Start Time for data in Epoch Time (in seconds).</param>
        /// <param name="etime">End Time for data in Epoch Time (in seconds).</param>
        /// <returns>Returns the total battery usage in mAh(milli-Ampere hour) by an application for certain time interval.</returns>
        public double GetTotalPowerUsageByApp(string appID, long stime, long etime)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalPowerUsageByApp(appID, stime, etime, out batteryUsage);
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
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="stime">Start Time for data in Epoch Time (in seconds).</param>
        /// <param name="etime">End Time for data in Epoch Time (in seconds).</param>
        /// <returns>Returns the battery usage in mAh(milli-Ampere hour) by a resource for certain time interval.</returns>
        public double GetTotalPowerUsageByResource(ResourceType rtype, long stime, long etime)
        {
            double batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalPowerUsageByResource(rtype, stime, etime, out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total battery usage by resource ," + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
            return batteryUsage;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing) {
                _instance = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
