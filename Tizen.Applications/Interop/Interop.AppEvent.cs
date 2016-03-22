/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class AppEvent
    {
        internal delegate void AppEventCallback(string eventName, IntPtr bundle, IntPtr data);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(string eventName, AppEventCallback callback, IntPtr data, out SafeAppEventHandle eventHandler);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_remove_event_handler")]
        internal static extern ErrorCode DangerousRemoveEventHandler(IntPtr eventHandler);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_publish_app_event")]
        internal static extern ErrorCode Publish(string eventName, IntPtr bundle);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_publish_trusted_app_event")]
        internal static extern ErrorCode PublishTrusted(string eventName, IntPtr bundle);

        internal sealed class SafeAppEventHandle : SafeHandle
        {
            public SafeAppEventHandle() : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                DangerousRemoveEventHandler(handle);
                SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal class EventNames
        {
            internal const string LowMemory = "tizen.system.event.low_memory";
            internal const string LanguageSet = "tizen.system.event.language_set";
        }

        internal class EventKeys
        {
            internal const string LowMemory = "low_memory";
            internal const string LanguageSet = "language_set";
        }

        internal class EventValues
        {
            internal const string MemoryNormal = "normal";
            internal const string MemorySoftWarning = "soft_warning";
            internal const string MemoryHardWarning = "hard_warning";
        }
    }
}

