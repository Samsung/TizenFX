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
using Tizen;
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
        internal delegate CallbackRet StatsInfoCallback(int result, SafeStatsHandle info, IntPtr userData);

        // Callback for getting All Statistics Information in one handle
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void GetAllStatsFinishedCallback(int result, IntPtr infoList, IntPtr userData);

        [DllImport(Libraries.Stc,EntryPoint = "stc_initialize")]
        internal static extern int Initialize(out SafeStcHandle stc);
        [DllImport(Libraries.Stc,EntryPoint = "stc_deinitialize")]
        internal static extern int Deinitialize(IntPtr stc);

        [DllImport(Libraries.Stc,EntryPoint = "stc_get_all_stats")]
        internal static extern int GetAllStats(SafeStcHandle stc, SafeFilterHandle filter, GetAllStatsFinishedCallback infoCb, IntPtr userData);
        [DllImport(Libraries.Stc,EntryPoint = "stc_foreach_all_stats")]
        internal static extern int ForeachAllStats(IntPtr infoList, StatsInfoCallback infoCb, IntPtr userData);

        internal static class Filter {
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_create")]
            internal static extern int Create(SafeStcHandle stc, out SafeFilterHandle filter);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_destroy")]
            internal static extern int Destroy(IntPtr filter);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_app_id")]
            internal static extern int SetAppId(SafeFilterHandle filter, string appId);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_time_interval")]
            internal static extern int SetTimeInterval(SafeFilterHandle filter, DateTime from, DateTime to);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_iface_type")]
            internal static extern int SetInterfaceType(SafeFilterHandle filter, NetworkInterface ifaceType);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_rule_set_time_period")]
            internal static extern int SetTimePeriod(SafeFilterHandle filter, NativeTimePeriodType timePeriod);
        }

        internal static class Info {
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_clone")]
            internal static extern int StatsClone(SafeStatsHandle info, out SafeStatsHandle cloned);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_destroy")]
            internal static extern int StatsDestroy(IntPtr info);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_app_id")]
            internal static extern int GetAppId(SafeStatsHandle info, out string appId);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_iface_name")]
            internal static extern int GetInterfaceName(SafeStatsHandle info, out string IfaceName);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_time_interval")]
            internal static extern int GetTimeInterval(SafeStatsHandle info, out DateTime from, out DateTime to);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_iface_type")]
            internal static extern int GetInterfaceType(SafeStatsHandle info, out NetworkInterface ifaceType);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_counter")]
            internal static extern int GetCounter(SafeStatsHandle info, out long incoming, out long outgoing);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_roaming_type")]
            internal static extern int GetRoaming(SafeStatsHandle info, out RoamingType roaming);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_protocol_type")]
            internal static extern int GetProtocol(SafeStatsHandle info, out NetworkProtocol protocol);
            [DllImport(Libraries.Stc,EntryPoint = "stc_stats_info_get_process_state")]
            internal static extern int GetProcessState(SafeStatsHandle info, out ApplicationStateType state);
        }

        internal sealed class SafeFilterHandle : SafeHandle
        {
            public SafeFilterHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeFilterHandle(IntPtr handle) : base(handle, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                int ret = Interop.Stc.Filter.Destroy(this.handle);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to release Filter handle, Error - " + (StcError)ret);
                    return false;
                }
                return true;
            }
        }

        internal sealed class SafeStatsHandle : SafeHandle
        {
            public SafeStatsHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeStatsHandle(IntPtr handle) : base(handle, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                int ret = Interop.Stc.Info.StatsDestroy(this.handle);
                if (ret != (int)StcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to release network statistics handle, Error - " + (StcError)ret);
                    return false;
                }
                return true;
            }
        }
    }
}
