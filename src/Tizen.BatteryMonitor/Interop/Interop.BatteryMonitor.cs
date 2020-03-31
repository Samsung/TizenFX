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
using System.Runtime.InteropServices;
using Tizen.BatteryMonitor;

internal static partial class Interop
{
    internal static class BatteryMonitor
    {
        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_destroy")]
        internal static extern int Destroy(IntPtr bmHandle);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_power_usage_for_resource_id_from_handle")]
        internal static extern int GetPowerUsageForResource(IntPtr BMHandle, ResourceType rtype, out double batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_power_usage_handle_by_app_id_for_all_resource_id")]
        internal static extern int GetPowerUsageByAppForAllResource(string appID, long stime, long etime, IntPtr bmHandle);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_power_usage_by_app_id_for_resource_id")]
        internal static extern int GetPowerUsageByAppForResource(string appID, ResourceType rtype, long stime, long etime, out double batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_total_power_usage_by_app_id")]
        internal static extern int GetTotalPowerUsage(string appID, long stime, long etime, out double batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_total_power_usage_by_resource_id")]
        internal static extern int GetTotalPowerUsage(ResourceType rtype, long stime, long etime, out double batteryUsage);
    }
}