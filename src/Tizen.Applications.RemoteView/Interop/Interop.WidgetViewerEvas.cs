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

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_init")]
        internal static extern ErrorCode Init(IntPtr win);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_fini")]
        internal static extern ErrorCode Fini();

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_add_widget")]
        internal static extern IntPtr AddWidget(IntPtr parent, string widgetId, string content, double period);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_notify_resumed_status_of_viewer")]
        internal static extern ErrorCode NotifyResumedStatusOfViewer();

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_notify_paused_status_of_viewer")]
        internal static extern ErrorCode NotifyPausedStatusOfViewer();

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_pause_widget")]
        internal static extern ErrorCode PauseWidget(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_resume_widget")]
        internal static extern ErrorCode ResumeWidget(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_content_info")]
        internal static extern IntPtr GetContentInfo(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_title_string")]
        internal static extern IntPtr GetTitleString(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_widget_id")]
        internal static extern IntPtr GetWidgetId(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_get_period")]
        internal static extern double GetPeriod(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_cancel_click_event")]
        internal static extern void CancelClickEvent(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_loading")]
        internal static extern void DisableLoading(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_feed_mouse_up_event")]
        internal static extern ErrorCode FeedMouseUpEvent(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_preview")]
        internal static extern void DisablePreview(IntPtr widget);

        [DllImport(Libraries.WidgetViewerEvas, EntryPoint = "widget_viewer_evas_disable_overlay_text")]
        internal static extern void DisableOverlayText(IntPtr widget);

    }
}
