// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tizen.Applications;
using Tizen.Account.AccountManager;

internal static partial class Interop
{
    internal static partial class Manager
    {
        [LibraryImport(Libraries.SyncManager, EntryPoint = "sync_manager_on_demand_sync_job", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RequestOnDemandSyncJob(SafeAccountHandle account, string syncJobName, int syncOption, SafeBundleHandle syncJobUserData, out int syncJobId);

        [LibraryImport(Libraries.SyncManager, EntryPoint = "sync_manager_add_periodic_sync_job", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddPeriodicSyncJob(SafeAccountHandle account, string syncJobName, int syncPeriod, int syncOption, SafeBundleHandle syncJobUserData, out int syncJobId);

        [LibraryImport(Libraries.SyncManager, EntryPoint = "sync_manager_add_data_change_sync_job", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddDataChangeSyncJob(SafeAccountHandle account, string syncCapability, int syncOption, SafeBundleHandle syncJobUserData, out int syncJobId);

        [LibraryImport(Libraries.SyncManager, EntryPoint = "sync_manager_remove_sync_job", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemoveSyncJob(int syncJobId);

        [LibraryImport(Libraries.SyncManager, EntryPoint = "sync_manager_foreach_sync_job", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ForeachSyncJob(SyncManagerSyncJobCallback syncJobCb, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool SyncManagerSyncJobCallback(IntPtr account, string syncJobName, string syncCapability, int syncJobId, IntPtr syncJobUserData, IntPtr userData);
    }
}
