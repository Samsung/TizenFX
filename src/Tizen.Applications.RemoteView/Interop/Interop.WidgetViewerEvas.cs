/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class WidgetViewerEvas
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

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_init", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Init(IntPtr win);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_fini", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Fini();

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_add_widget", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr AddWidget(IntPtr parent, string widgetId, string content, double period);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_notify_resumed_status_of_viewer", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode NotifyResumedStatusOfViewer();

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_notify_paused_status_of_viewer", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode NotifyPausedStatusOfViewer();

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_pause_widget", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PauseWidget(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_resume_widget", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ResumeWidget(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_content_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetContentInfo(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_title_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetTitleString(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_widget_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetWidgetId(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_period", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial double GetPeriod(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_cancel_click_event", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void CancelClickEvent(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_loading", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void DisableLoading(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_feed_mouse_up_event", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode FeedMouseUpEvent(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_preview", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void DisablePreview(IntPtr widget);

        [LibraryImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_overlay_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void DisableOverlayText(IntPtr widget);

    }
}



