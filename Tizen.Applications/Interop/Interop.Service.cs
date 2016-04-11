// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Service
    {
        internal delegate bool ServiceAppCreateCallback(IntPtr userData);

        internal delegate void ServiceAppTerminateCallback(IntPtr userData);

        internal delegate void ServiceAppControlCallback(IntPtr appControl, IntPtr userData);

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_main")]
        internal static extern int Main(int argc, string[] argv, ref ServiceAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppcoreAgent, EntryPoint = "service_app_exit")]
        internal static extern void Exit();

        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct ServiceAppLifecycleCallbacks
        {
            public ServiceAppCreateCallback OnCreate;
            public ServiceAppTerminateCallback OnTerminate;
            public ServiceAppControlCallback OnAppControl;
        }
    }
}
