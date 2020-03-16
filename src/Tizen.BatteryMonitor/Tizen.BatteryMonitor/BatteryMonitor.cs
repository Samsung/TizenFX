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

    public class BatteryMonitor : IDisposable
    {
        internal IntPtr bmHandle;
        private static BatteryMonitor _instance = null;
        private bool _disposed = false;


        /// <summary>
        /// The constructor of the BatteryMonitor class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <privilege>http://tizen.org/privilege/systemmonitor</privilege>
        public static BatteryMonitor CreateBatteryMonitor()
        {
            if (_instance == null)
            {
                BatteryMonitor bmInstance = new BatteryMonitor();
                _instance = bmInstance;
                _instance.CreateBatteryMonitorDataHandle();
            }

            return _instance;
        }

        /// <summary>
        /// The destructor of the BatteryMonitor class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~BatteryMonitor()
        {
            Dispose(false);
        }

        internal void CreateBatteryMonitorDataHandle() {
            int ret = Interop.BatteryMonitor.Create(out bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error Creating Battery Monitor Data Handle" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
        }

        internal int GetUsagePercentForResource(IntPtr BMHandle, ResourceType rtype)
        {
            int batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetUsagePercentForResource(BMHandle, rtype, out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for resource" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
            return batteryUsage;
        }


        /// <summary>
        /// Gets the battery-percent for specific resources by the specified application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="dtype">Time duration for which battery usage is requested.</param>
        /// <param name="rtypes">list of resource type identifiers like BLE, WiFi, CPU etc.</param>
        /// <returns>Returns the  battery-percent for specific resources by the specified application.</returns>
        public List<int> GetUsagePercentByAppForAllResource(string appID, DurationType dtype, List<ResourceType> rtypes)
        {
            List<int> batteryUsage = new List<int>();
            int ret = Interop.BatteryMonitor.GetUsagePercentByAppForAllResource(appID, dtype, bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage for all resources" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }

            foreach(ResourceType type in rtypes) {
                batteryUsage.Add(_instance.GetUsagePercentForResource(bmHandle,type));
            }

            return batteryUsage;
        }

        /// <summary>
        /// Gets the battery consumption for the specific resource for the given application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="dtype">Time duration for which battery usage is requested.</param>
        /// <returns>Returns the battery consumption for the specific resource for the given application.</returns>
        public int GetUsagePercentByAppForResource(string appID, ResourceType rtype, DurationType dtype)
        {
            int batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetUsagePercentByAppForResource(appID, rtype, dtype, out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting battery usage by app for resrource" + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
            return batteryUsage;
        }

        /// <summary>
        /// Gets the total battery usage in percent by an application for certain time duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="appID">Application ID of the application for which battery usage is required.</param>
        /// <param name="dtype">Time duration for which battery usage is requested.</param>
        /// <returns>Returns the total battery usage in percent by an application for certain time duration.</returns>
        public int GetTotalUsagePercentByApp(string appID, DurationType dtype)
        {
            int batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalUsagePercentByApp(appID, dtype, out batteryUsage);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error getting total  battery usage by app," + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
            return batteryUsage;

        }

        /// <summary>
        /// Gets the battery-percent usage by a resource for certain time duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rtype">Identifier of resource type. BLE, WiFi, CPU etc.</param>
        /// <param name="dtype">Time duration for which battery usage is requested.</param>
        /// <returns>Returns the battery-percent usage by a resource for certain time duration.</returns>
        public int GetTotalUsagePercentByResource(ResourceType rtype, DurationType dtype)
        {
            int batteryUsage = 0;
            int ret = Interop.BatteryMonitor.GetTotalUsagePercentByResource(rtype, dtype, out batteryUsage);
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
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                DestroyHandle();

            _disposed = true;
        }

        private void DestroyHandle()
        {
            int ret = Interop.BatteryMonitor.Destroy(bmHandle);
            if (((BatteryMonitorError)ret != BatteryMonitorError.None))
            {
                Log.Error(Globals.LogTag, "Error in Destroy handle, " + (BatteryMonitorError)ret);
                throw BatteryMonitorErrorFactory.ThrowBatteryMonitorException(ret);
            }
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
