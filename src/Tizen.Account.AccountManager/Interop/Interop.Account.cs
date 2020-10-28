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
    internal static partial class Account
    {
        [DllImport(Libraries.AccountSvc, EntryPoint = "account_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Create(out SafeAccountHandle handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateUnmanagedHandle(out IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_account_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountId(SafeAccountHandle data, out int accountId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_user_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountUserName(SafeAccountHandle data, out string userName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_user_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountUserName(SafeAccountHandle handle, string userName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountDisplayName(SafeAccountHandle handle, out string displayName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountDisplayName(SafeAccountHandle handle, string displayName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_capability", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountCapability(SafeAccountHandle handle, string capabilityType, out int capabilityValue);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_capability", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountCapability(SafeAccountHandle handle, string capabilityType, int capabilityValue);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_icon_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountIconPath(SafeAccountHandle handle, out string iconPath);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_icon_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountIconPath(SafeAccountHandle handle, string iconPath);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_domain_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountDomainName(SafeAccountHandle handle, out string domainName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_domain_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountDomainName(SafeAccountHandle handle, string domainName);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_email_address", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountEmail(SafeAccountHandle handle, out string email);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_email_address", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountEmail(SafeAccountHandle handle, string email);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_package_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountPackageName(SafeAccountHandle handle, out string name);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_package_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountPackageName(SafeAccountHandle handle, string name);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_access_token", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountAccessToken(SafeAccountHandle handle, out string accessToken);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_access_token", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountAccessToken(SafeAccountHandle handle, string accessToken);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_user_text", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountUserText(SafeAccountHandle handle, int index, out string userText);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_user_text", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountUserText(SafeAccountHandle handle, int index, string userText);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_user_int", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountUserInt(SafeAccountHandle handle, int index, out int value);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_user_int", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountUserInt(SafeAccountHandle handle, int index, int value);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_auth_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountAuthType(SafeAccountHandle handle, out int authType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_auth_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountAuthType(SafeAccountHandle handle, int authType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_secret", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountSercet(SafeAccountHandle handle, out int secretType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_secret", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountSecret(SafeAccountHandle handle, int secretType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_sync_support", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountSyncSupport(SafeAccountHandle handle, out int syncType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_sync_support", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountSyncSupport(SafeAccountHandle handle, int syncType);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_source", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountSource(SafeAccountHandle handle, out string source);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_source", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountSource(SafeAccountHandle handle, string source);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountCustomValue(SafeAccountHandle handle, string key, out string value);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_set_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAccountCustomValue(SafeAccountHandle handle, string key, string value);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_update_sync_status_by_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateAccountSyncStatusById(int accountId, int status);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_capability_all")]
        internal static extern int GetAllAccountCapabilities(SafeAccountHandle handle, AccountCapabilityCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_query_capability_by_account_id")]
        internal static extern int QueryAccountCapabilityById(AccountCapabilityCallback callback, int accountId, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_get_custom_all")]
        internal static extern int GetAllAccountCustomValues(SafeAccountHandle handle, AccountCustomCallback callback, IntPtr userData);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCapabilityCallback(string capabilityType, int capabilityState, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCustomCallback(string key, string value, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCallback(IntPtr data, IntPtr userData);
    }
}
