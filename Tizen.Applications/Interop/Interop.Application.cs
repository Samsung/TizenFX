// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class Application
    {
        internal delegate bool AppCreateCallback(IntPtr userData);

        internal delegate void AppPauseCallback(IntPtr userData);

        internal delegate void AppResumeCallback(IntPtr userData);

        internal delegate void AppTerminateCallback(IntPtr userData);

        internal delegate void AppControlCallback(IntPtr appControl, IntPtr userData);

        [DllImport(Libraries.Application, EntryPoint = "ui_app_main")]
        internal static extern ErrorCode Main(int argc, string[] argv, ref UIAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.Application, EntryPoint = "ui_app_exit")]
        internal static extern void Exit();

        [DllImport(Libraries.Application, EntryPoint = "ui_app_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(out IntPtr handle, AppCommon.AppEventType eventType, AppCommon.AppEventCallback callback, IntPtr data);

        [DllImport(Libraries.Application, EntryPoint = "ui_app_remove_event_handler")]
        internal static extern ErrorCode RemoveEventHandler(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        internal struct UIAppLifecycleCallbacks
        {
            public AppCreateCallback OnCreate;
            public AppTerminateCallback OnTerminate;
            public AppPauseCallback OnPause;
            public AppResumeCallback OnResume;
            public AppControlCallback OnAppControl;
        }
    }
}

