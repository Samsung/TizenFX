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
    internal static partial class WidgetService
    {
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

        internal enum LifecycleEvent : int
        {
            AppDead = 0,
            Created = 1,
            Destroyed = 2,
            Paused = 3,
            Resumed = 4,
            Max = 5
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InstanceCallback(string widgetId, string instanceId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int LifecycleCallback(string widgetId, LifecycleEvent e, string instanceId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void WidgetListCallback(string widgetId, int isPrime, IntPtr userData);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_icon")]
        internal static extern string GetIcon(string pkgId, string lang);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_name")]
        internal static extern string GetName(string widgetId, string lang);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_nodisplay")]
        internal static extern int GetNoDisplay(string widgetId);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_widget_instance_list")]
        internal static extern ErrorCode GetInstances(string widgetId, InstanceCallback callback, IntPtr userData);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_set_lifecycle_event_cb")]
        internal static extern ErrorCode SetLifecycleEvent(string widgetId, LifecycleCallback callback, IntPtr userData);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_unset_lifecycle_event_cb")]
        internal static extern ErrorCode UnsetLifecycleEvent(string widgetId, IntPtr userData);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_trigger_update")]
        internal static extern ErrorCode UpdateContent(string widgetId, string instanceId, SafeBundleHandle bundle, int force);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_change_period")]
        internal static extern ErrorCode ChangePeriod(string widgetId, string instanceId, double period);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_content_of_widget_instance")]
        internal static extern ErrorCode GetContent(string widgetId, string instanceId, out IntPtr bundle);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_package_id")]
        internal static extern string GetPkgId(string widgetId);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_supported_sizes")]
        internal static extern ErrorCode GetSupportedSizes(string widgetId, ref int cnt, out IntPtr w, out IntPtr h);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_supported_size_types")]
        internal static extern ErrorCode GetSupportedSizeTypes(string widgetId, ref int cnt, out IntPtr types);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_preview_image_path")]
        internal static extern string GetPreviewImagePath(string widgetId, int sizeType);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_widget_list_by_pkgid")]
        internal static extern ErrorCode GetWidgetListByPkgId(string pkgId, WidgetListCallback callback, IntPtr userData);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_main_app_id")]
        internal static extern string GetWidgetMainAppId(string widgetId);

        [DllImport(Libraries.WidgetService, EntryPoint = "widget_service_get_package_id")]
        internal static extern string GetWidgetPackageId(string widgetId);
    }
}
