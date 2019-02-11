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
using Tizen.Applications.CoreBackend;
using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class Application
    {
        internal delegate void AppEventCallback(IntPtr handle, IntPtr data);

        internal delegate bool AppCreateCallback(IntPtr userData);

        internal delegate void AppPauseCallback(IntPtr userData);

        internal delegate void AppResumeCallback(IntPtr userData);

        internal delegate void AppTerminateCallback(IntPtr userData);

        internal delegate void AppControlCallback(IntPtr appControl, IntPtr userData);


        [DllImport(Libraries.Application, EntryPoint = "app_get_device_orientation")]
        internal static extern DeviceOrientation AppGetDeviceOrientation();

        [DllImport(Libraries.Application, EntryPoint = "ui_app_main")]
        internal static extern ErrorCode Main(int argc, string[] argv, ref UIAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.Application, EntryPoint = "ui_app_exit")]
        internal static extern void Exit();

        [DllImport(Libraries.Application, EntryPoint = "ui_app_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(out IntPtr handle, DefaultCoreBackend.AppEventType eventType, AppEventCallback callback, IntPtr data);

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

