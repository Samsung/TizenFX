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
using Tizen.Account.AccountManager;

/// <summary>
/// Interop for Account class APIs.
/// </summary>
/// <since_tizen> 3 </since_tizen>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Account class APIs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    internal static partial class AccountService
    {
        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_update_to_db_by_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UpdateAccountToDBById(SafeAccountHandle handle, int id);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_update_to_db_by_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UpdateAccountToDBByUserName(IntPtr handle, string userName, string packageName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_account_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int QueryAccountById(int accountId, ref SafeAccountHandle handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int QueryAccountByUserName(Interop.Account.AccountCallback callback, string userName, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_package_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int QueryAccountByPackageName(Interop.Account.AccountCallback callback, string packageName, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_capability_by_account_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int QueryAccountCapabilityById(Interop.Account.AccountCapabilityCallback callback, int accoutId, IntPtr data);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_update_sync_status_by_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UpdateAccountSyncStatusById(int accoutId, int status);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_insert_to_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddAccount(SafeAccountHandle handle, out int accountId);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DeleteAccountById(int accountId);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DeleteAccountByUser(string userName, string packageName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_package_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DeleteAccountByPackage(string packageName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_total_count_from_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountCount(out int count);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_foreach_account_from_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AccountForeachAccountFromDb(Interop.Account.AccountCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_capability", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountByCapability(Interop.Account.AccountCallback callback, string capabilityType, int value, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_capability_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountByCapabilityType(Interop.Account.AccountCallback callback, string capabilityType, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_type_foreach_account_type_from_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAllAccountproviders(Interop.AccountProvider.AccountProviderCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_type_query_by_provider_feature", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountProviderByFeature(Interop.AccountProvider.AccountProviderCallback callback, string key, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_type_query_by_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountProviderByAppId(string appId, out IntPtr handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_subscribe_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CreateAccountSubscriber(out Interop.AccountService.SafeAccountSubscriberHandle handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_subscribe_notification", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RegisterSubscriber(Interop.AccountService.SafeAccountSubscriberHandle handle, Interop.AccountService.SubscribeCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_unsubscribe_notification", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UnregisterSubscriber(Interop.AccountService.SafeAccountSubscriberHandle handle);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SubscribeCallback(string eventType, int accountId, IntPtr userData);

        internal sealed class SafeAccountSubscriberHandle : SafeHandle
        {
            public SafeAccountSubscriberHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
