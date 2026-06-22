/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals;

namespace Tizen.Applications {
    internal static partial class Interop
    {
        internal static partial class TeamMember
        {
            internal delegate void AppTerminateCallback(IntPtr context, IntPtr userdata);
            internal delegate void AppControlCallback(IntPtr context, IntPtr appControl, IntPtr userdata);
            internal delegate void AppResumeCallback(IntPtr context, IntPtr userdata);
            internal delegate void AppPauseCallback(IntPtr context, IntPtr userdata);
            internal delegate void AppLowMemoryCallback(IntPtr context, int status, IntPtr userdata);
            internal delegate void AppLowBatteryCallback(IntPtr context, int status, IntPtr userdata);
            internal delegate void AppLanguageChangedCallback(IntPtr context,
                [MarshalAs(UnmanagedType.LPStr)] string language, IntPtr userdata);
            internal delegate void AppDeviceOrientationChangedCallback(IntPtr context, int status, IntPtr userdata);
            internal delegate void AppRegionFormatChangedCallback(IntPtr context,
                [MarshalAs(UnmanagedType.LPStr)] string region, IntPtr userdata);
            internal delegate void AppSuspendStateChangedCallback(IntPtr context, int status, IntPtr userdata);
            internal delegate void AppTimeZoneChangedCallback(IntPtr context,
                [MarshalAs(UnmanagedType.LPStr)] string timeZone,
                [MarshalAs(UnmanagedType.LPStr)] string timeZoneId,
                IntPtr userdata);
            internal delegate IntPtr UIAppCreateCallback(IntPtr context, IntPtr userdata);
            internal delegate IntPtr ViewAppCreateCallback(IntPtr context, IntPtr userdata);
            internal delegate bool ServiceAppCreateCallback(IntPtr context, IntPtr userdata);
            [StructLayout(LayoutKind.Sequential)]
            internal struct UIMemberLifecycleCallbacks
            {
                public UIAppCreateCallback Create;
                public AppTerminateCallback Terminate;
                public AppControlCallback Control;
                public AppResumeCallback Resume;
                public AppPauseCallback Pause;
                public AppLowMemoryCallback LowMemory;
                public AppLowBatteryCallback LowBattery;
                public AppLanguageChangedCallback LanguageChanged;
                public AppDeviceOrientationChangedCallback DeviceOrientationChanged;
                public AppRegionFormatChangedCallback RegionFormatChanged;
                public AppSuspendStateChangedCallback SuspendStateChanged;
                public AppTimeZoneChangedCallback TimezoneChanged;
            }
            [StructLayout(LayoutKind.Sequential)]
            internal struct ServiceMemberLifecycleCallbacks
            {
                public ServiceAppCreateCallback Create;
                public AppTerminateCallback Terminate;
                public AppControlCallback Control;
                public AppLowMemoryCallback LowMemory;
                public AppLowBatteryCallback LowBattery;
                public AppLanguageChangedCallback LanguageChanged;
                public AppDeviceOrientationChangedCallback DeviceOrientationChanged;
                public AppRegionFormatChangedCallback RegionFormatChanged;
                public AppSuspendStateChangedCallback SuspendStateChanged;
                public AppTimeZoneChangedCallback TimezoneChanged;
            }

            [DllImport(Libraries.TeamLib, EntryPoint = "team_ui_app_teamup")]
            internal static extern IntPtr UIMemberTeamup(UIMemberLifecycleCallbacks callbacks, IntPtr userdata);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_ui_app_quit")]
            internal static extern void UIMemberQuit(IntPtr member);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_service_app_teamup")]
            internal static extern IntPtr ServiceMemberTeamup(ServiceMemberLifecycleCallbacks callbacks, IntPtr userdata);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_service_app_quit")]
            internal static extern void ServiceMemberQuit(IntPtr member);

            [StructLayout(LayoutKind.Sequential)]
            internal struct ViewMemberLifecycleCallbacks
            {
                public ViewAppCreateCallback Create;
                public AppTerminateCallback Terminate;
                public AppControlCallback Control;
                public AppResumeCallback Resume;
                public AppPauseCallback Pause;
                public AppLowMemoryCallback LowMemory;
                public AppLowBatteryCallback LowBattery;
                public AppLanguageChangedCallback LanguageChanged;
                public AppDeviceOrientationChangedCallback DeviceOrientationChanged;
                public AppRegionFormatChangedCallback RegionFormatChanged;
                public AppSuspendStateChangedCallback SuspendStateChanged;
                public AppTimeZoneChangedCallback TimezoneChanged;
            }

            [DllImport(Libraries.TeamLib, EntryPoint = "team_view_app_teamup")]
            internal static extern IntPtr ViewMemberTeamup(ViewMemberLifecycleCallbacks callbacks, IntPtr userdata);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_view_app_quit")]
            internal static extern void ViewMemberQuit(IntPtr member);
        }
    }
}