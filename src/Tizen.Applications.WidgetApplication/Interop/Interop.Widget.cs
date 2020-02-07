/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Widget
    {
        internal enum WidgetAppDestroyType
        {
            Permanent = 0,
            Temporary
        }

        internal enum AppEventType
        {
            LowMemory = 0,
            LowBattery,
            LanguageChanged,
            DeviceOrientationChanged,
            RegionFormatChanged,
            SuspendedStateChanged
        }

        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            Canceled = Tizen.Internals.Errors.ErrorCode.Canceled,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            FileNoSpaceOnDevice = Tizen.Internals.Errors.ErrorCode.FileNoSpaceOnDevice,
            Fault = -0x02F40000 | 0x0001,
            AlreadyExist = -0x02F40000 | 0x0002,
            AlreadyStarted = -0x02F40000 | 0x0004,
            NotExist = -0x02F40000 | 0x0008,
            Disabled = -0x02F40000 | 0x0010,
            MaxExceeded = -0x02F40000 | 0x0011,
        }

        internal delegate void AppEventCallback(IntPtr handle, IntPtr data);

        internal delegate IntPtr WidgetAppCreateCallback(IntPtr userData);

        internal delegate void WidgetAppTerminateCallback(IntPtr userData);

        internal delegate int WidgetInstanceCreateCallback(IntPtr context, IntPtr content, int w, int h, IntPtr userData);

        internal delegate int WidgetInstanceDestroyCallback(IntPtr context, WidgetAppDestroyType reason, IntPtr content, IntPtr userData);

        internal delegate int WidgetInstancePauseCallback(IntPtr context, IntPtr userData);

        internal delegate int WidgetInstanceResumeCallback(IntPtr context, IntPtr userData);

        internal delegate int WidgetInstanceResizeCallback(IntPtr context, int w, int h, IntPtr userData);

        internal delegate int WidgetInstanceUpdateCallback(IntPtr context, IntPtr content, int force, IntPtr userData);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_main")]
        internal static extern ErrorCode Main(int argc, string[] argv, ref WidgetAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_exit")]
        internal static extern void Exit();

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(out IntPtr handle, AppEventType eventType, AppEventCallback callback, IntPtr data);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_remove_event_handler")]
        internal static extern ErrorCode RemoveEventHandler(IntPtr handle);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_class_create")]
        internal static extern IntPtr CreateClass(WidgetiInstanceLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_class_add")]
        internal static extern IntPtr AddClass(IntPtr handle, string classId, WidgetiInstanceLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_terminate_context")]
        internal static extern ErrorCode TerminateContext(IntPtr handle);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_context_set_content_info")]
        internal static extern ErrorCode SetContent(IntPtr handle, SafeBundleHandle content);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_context_set_title")]
        internal static extern ErrorCode SetTitle(IntPtr handle, string title);

        [DllImport(Libraries.AppcoreWidget, EntryPoint = "widget_app_get_elm_win")]
        internal static extern ErrorCode GetWin(IntPtr handle, out IntPtr win);

        [DllImport(Libraries.AppcoreWidget)]
        internal static extern IntPtr widget_app_get_id(IntPtr handle);

        internal static string GetId(IntPtr handle)
        {
            return Marshal.PtrToStringAnsi(widget_app_get_id(handle));
        }

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_memory_status")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLowMemoryStatus(IntPtr handle, out LowMemoryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_battery_status")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLowBatteryStatus(IntPtr handle, out LowBatteryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_language")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLanguage(IntPtr handle, out string lang);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_region_format")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetRegionFormat(IntPtr handle, out string region);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct WidgetAppLifecycleCallbacks
        {
            public WidgetAppCreateCallback OnCreate;
            public WidgetAppTerminateCallback OnTerminate;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct WidgetiInstanceLifecycleCallbacks
        {
            public WidgetInstanceCreateCallback OnCreate;
            public WidgetInstanceDestroyCallback OnDestroy;
            public WidgetInstancePauseCallback OnPause;
            public WidgetInstanceResumeCallback OnResume;
            public WidgetInstanceResizeCallback OnResize;
            public WidgetInstanceUpdateCallback OnUpdate;
        }
    }
}
