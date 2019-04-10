/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Network.Stc;
using System.Runtime.InteropServices;

/// <summary>
/// The Interop class for Stc.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The Stc native APIs.
    /// </summary>
    internal static class Stc
    {
        // Callback for Statistics Information
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate CallbackRet StatsInfoCallback(int result, IntPtr info, IntPtr userData);

        // Callback for getting All Statistics Information in one handle
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void GetAllStatsFinishedCallback(int result, IntPtr infoList, IntPtr userData);

        [DllImport(Libraries.Stc,EntryPoint = "stc_initialize")]
        internal static extern int Initialize(out SafeStcHandle stc);
        [DllImport(Libraries.Stc,EntryPoint = "stc_deinitialize")]
        internal static extern int Deinitialize(IntPtr stc);

        [DllImport(Libraries.Stc,EntryPoint = "stc_get_stats")]
        internal static extern int GetStats(SafeStcHandle stc, IntPtr rule, StatsInfoCallback infoCb, IntPtr userData);
        [DllImport(Libraries.Stc,EntryPoint = "stc_get_all_stats")]
        internal static extern int GetAllStats(SafeStcHandle stc, IntPtr rule, GetAllStatsFinishedCallback infoCb, IntPtr userData);
        [DllImport(Libraries.Stc,EntryPoint = "stc_foreach_all_stats")]
        internal static extern int ForeachAllStats(IntPtr info, StatsInfoCallback infoCb, IntPtr userData);
        [DllImport(Libraries.Stc,EntryPoint = "stc_get_total_stats")]
        internal static extern int GetTotalStats(SafeStcHandle stc, IntPtr rule, StatsInfoCallback infoCb, IntPtr userData);

        internal static class Rule {
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_create")]
            internal static extern int Create(SafeStcHandle stc, out IntPtr rule);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_destroy")]
            internal static extern int Destroy(IntPtr rule);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_app_id")]
            internal static extern int SetAppId(IntPtr rule, string appId);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_get_app_id")]
            internal static extern int GetAppId(IntPtr rule, out string appId);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_time_interval")]
            internal static extern int SetTimeInterval(IntPtr rule, DateTime from, DateTime to);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_get_time_interval")]
            internal static extern int GetTimeInterval(IntPtr rule, out DateTime from, out DateTime to);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_iface_type")]
            internal static extern int SetInterfaceType(IntPtr rule, NativeNetworkInterface ifaceType);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_get_iface_type")]
            internal static extern int GetInterfaceType(IntPtr rule, out NativeNetworkInterface ifaceType);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_time_period")]
            internal static extern int SetTimePeriod(IntPtr rule, NativeTimePeriodType timePeriod);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_get_time_period")]
            internal static extern int GetTimePeriod(IntPtr rule, out NativeTimePeriodType timePeriod);
        }

        internal static class Info {
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_clone")]
            internal static extern int StatsClone(IntPtr info, out IntPtr cloned);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_destroy")]
            internal static extern int StatsDestroy(IntPtr info);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_app_id")]
            internal static extern int GetAppId(IntPtr info, out string appId);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_iface_name")]
            internal static extern int GetInterfaceName(IntPtr info, out string IfaceName);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_time_interval")]
            internal static extern int GetTimeInterval(IntPtr info, out DateTime from, out DateTime to);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_iface_type")]
            internal static extern int GetInterfaceType(IntPtr info, out NativeNetworkInterface ifaceType);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_counter")]
            internal static extern int GetCounter(IntPtr info, out long incoming, out long outgoing);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_roaming_type")]
            internal static extern int GetRoaming(IntPtr info, out RoamingType roaming);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_protocol_type")]
            internal static extern int GetProtocol(IntPtr info, out NativeNetworkProtocol protocol);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_process_state")]
            internal static extern int GetProcessState(IntPtr info, out ProcessState state);
        }
    }
}
