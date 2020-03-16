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
        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_create")]
        internal static extern int Create(out IntPtr bmHandle);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_destroy")]
        internal static extern int Destroy(IntPtr bmHandle);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_usage_for_resource_id")]
        internal static extern int GetUsagePercentForResource(IntPtr BMHandle, ResourceType rtype, out int batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_usage_by_app_id_for_all_resource_id")]
        internal static extern int GetUsagePercentByAppForAllResource(string appID, DurationType dtype, IntPtr bmHandle);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_usage_by_app_id_for_resource_id")]
        internal static extern int GetUsagePercentByAppForResource(string appID, ResourceType rtype, DurationType dtype, out int batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_total_usage_by_app_id")]
        internal static extern int GetTotalUsagePercentByApp(string appID, DurationType dtype, out int batteryUsage);

        [DllImport(Libraries.BatteryMonitor, EntryPoint = "battery_monitor_get_total_usage_by_resource_id")]
        internal static extern int GetTotalUsagePercentByResource(ResourceType rtype, DurationType dtype, out int batteryUsage);
    }
}