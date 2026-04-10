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
    internal static partial class Adapter
    {
        [DllImport(Libraries.SyncManager, EntryPoint = "sync_adapter_set_callbacks")]
        internal static extern int SetCallbacks(SyncAdapterStartSyncCallback onStartCb, SyncAdapterCancelSyncCallback onCancelCb);

        [DllImport(Libraries.SyncManager, EntryPoint = "sync_adapter_unset_callbacks")]
        internal static extern int UnsetCallbacks();

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool SyncAdapterStartSyncCallback(IntPtr account, string syncJobName, string syncCapability, IntPtr syncJobUserData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void SyncAdapterCancelSyncCallback(IntPtr account, string syncJobName, string syncCapability, IntPtr syncJobUserData);
    }
}
