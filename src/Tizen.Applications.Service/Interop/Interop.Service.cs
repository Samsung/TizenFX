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
using Tizen.Applications.CoreBackend;
using Tizen.Internals;
using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class Service
    {
        internal delegate void AppEventCallback(IntPtr handle, IntPtr data);

        internal delegate bool ServiceAppCreateCallback(IntPtr userData);

        internal delegate void ServiceAppTerminateCallback(IntPtr userData);

        internal delegate void ServiceAppControlCallback(IntPtr appControl, IntPtr userData);

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_main")]
        internal static extern ErrorCode Main(int argc, string[] argv, ref ServiceAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_exit")]
        internal static extern void Exit();

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(out IntPtr handle, DefaultCoreBackend.AppEventType eventType, AppEventCallback callback, IntPtr data);

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_remove_event_handler")]
        internal static extern ErrorCode RemoveEventHandler(IntPtr handle);

        [NativeStruct("service_app_lifecycle_callback_s", Include="service_app.h", PkgConfig="capi-appfw-service-application")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct ServiceAppLifecycleCallbacks
        {
            public ServiceAppCreateCallback OnCreate;
            public ServiceAppTerminateCallback OnTerminate;
            public ServiceAppControlCallback OnAppControl;
        }
    }
}
