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
using Tizen.System;

internal static partial class Interop
{
    internal static class PowerUsage
    {
        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_battery_usage_data_destroy")]
        internal static extern int BatteryUsageDataDestroy(IntPtr dataHandle);

        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_usage_data_get_power_usage_per_resource")]
        internal static extern int UsageDataGetPowerUsagePerResource(IntPtr dataHandle, PowerUsageResourceType rtype, out double batteryUsage);

        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_get_power_usage_by_app_for_all_resources")]
        internal static extern int GetPowerUsageByAppForAllResources(string appID, int startTime, int endTime, out IntPtr dataHandle);

        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_get_power_usage_by_app_per_resource")]
        internal static extern int GetPowerUsageByAppPerResource(string appID, PowerUsageResourceType rtype, int startTime, int endTime, out double batteryUsage);

        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_get_power_usage_by_app")]
        internal static extern int GetPowerUsageByApp(string appID, int startTime, int endTime, out double batteryUsage);

        [DllImport(Libraries.PowerUsage, EntryPoint = "battery_monitor_get_power_usage_by_resource")]
        internal static extern int GetPowerUsageByResource(PowerUsageResourceType rtype, int startTime, int endTime, out double batteryUsage);
    }
}