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
using System.Runtime.InteropServices.Marshalling;
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
        internal delegate int InstanceCallback(string widgetId, string instanceId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int LifecycleCallback(string widgetId, LifecycleEvent e, string instanceId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int WidgetListCallback(string widgetId, int isPrime, IntPtr userData);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_icon", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetIcon(string pkgId, string lang);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetName(string widgetId, string lang);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_nodisplay", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNoDisplay(string widgetId);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_widget_instance_list", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetInstances(string widgetId, InstanceCallback callback, IntPtr userData);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_set_lifecycle_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetLifecycleEvent(string widgetId, LifecycleCallback callback, IntPtr userData);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_unset_lifecycle_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode UnsetLifecycleEvent(string widgetId, IntPtr userData);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_trigger_update", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode UpdateContent(string widgetId, string instanceId, SafeBundleHandle bundle, int force);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_change_period", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ChangePeriod(string widgetId, string instanceId, double period);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_content_of_widget_instance", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetContent(string widgetId, string instanceId, out IntPtr bundle);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_package_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetPkgId(string widgetId);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_supported_sizes", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetSupportedSizes(string widgetId, ref int cnt, out IntPtr w, out IntPtr h);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_supported_size_types", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetSupportedSizeTypes(string widgetId, ref int cnt, out IntPtr types);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_preview_image_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetPreviewImagePath(string widgetId, int sizeType);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_widget_list_by_pkgid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetWidgetListByPkgId(string pkgId, WidgetListCallback callback, IntPtr userData);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_main_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetWidgetMainAppId(string widgetId);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_package_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetWidgetPackageId(string widgetId);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_widget_max_count", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetWidgetMaxCount(string widgetId);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_instance_count", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetWidgetInstanceCount(string widgetId, string cluster, string category);

        [LibraryImport(Libraries.WidgetService, EntryPoint = "widget_service_get_app_id_of_setup_app", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string GetSetupAppId(string widgetId);
    }
}



