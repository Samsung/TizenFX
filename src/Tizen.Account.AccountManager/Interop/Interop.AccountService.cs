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

/// <summary>
/// Interop for Account class APIs
/// </summary>
/// <since_tizen> 3 </since_tizen>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Account class APIs
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    internal static partial class AccountService
    {
        [DllImport(Libraries.AccountSvc, EntryPoint = "account_update_to_db_by_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateAccountToDBById(IntPtr handle, int id);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_update_to_db_by_user_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateAccountToDBByUserName(IntPtr handle, string userName, string packageName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_account_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryAccountById(int accountId, out IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_user_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryAccountByUserName(Interop.Account.AccountCallback callback, string userName, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_package_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryAccountByPackageName(Interop.Account.AccountCallback callback, string packageName, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_capability_by_account_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryAccountCapabilityById(Interop.Account.AccountCapabilityCallback callback, int accoutId, IntPtr data);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_update_sync_status_by_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateAccountSyncStatusById(int accoutId, int status);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_insert_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AddAccount(IntPtr handle, out int accountId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeleteAccountById(int accountId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_user_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeleteAccountByUser(string userName, string packageName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_delete_from_db_by_package_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeleteAccountByPackage(string packageName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_total_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountCount(out int count);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_foreach_account_from_db")]
        internal static extern int AccountForeachAccountFromDb(Interop.Account.AccountCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_capability")]
        internal static extern int GetAccountByCapability(Interop.Account.AccountCallback callback, string capabilityType, int value, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_account_by_capability_type")]
        internal static extern int GetAccountByCapabilityType(Interop.Account.AccountCallback callback, string capabilityType, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_foreach_account_type_from_db")]
        internal static extern int GetAllAccountproviders(Interop.AccountProvider.AccountProviderCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_by_provider_feature")]
        internal static extern int GetAccountProviderByFeature(Interop.AccountProvider.AccountProviderCallback callback, string key, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_by_app_id")]
        internal static extern int GetAccountProviderByAppId(string appId, out IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_subscribe_create")]
        internal static extern int CreateAccountSubscriber(out Interop.AccountService.SafeAccountSubscriberHandle handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_subscribe_notification")]
        internal static extern int RegisterSubscriber(Interop.AccountService.SafeAccountSubscriberHandle handle, Interop.AccountService.SubscribeCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_unsubscribe_notification")]
        internal static extern int UnregisterSubscriber(Interop.AccountService.SafeAccountSubscriberHandle handle);

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
