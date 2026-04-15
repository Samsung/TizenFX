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
    internal static partial class Account
    {
        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_create")]
        internal static partial int Create(out SafeAccountHandle handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_create")]
        internal static partial int CreateUnmanagedHandle(out IntPtr handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_destroy")]
        internal static partial int Destroy(IntPtr handle);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_account_id")]
        internal static partial int GetAccountId(SafeAccountHandle data, out int accountId);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountUserName(SafeAccountHandle data, out string userName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountUserName(SafeAccountHandle handle, string userName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_display_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountDisplayName(SafeAccountHandle handle, out string displayName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_display_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountDisplayName(SafeAccountHandle handle, string displayName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_capability", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountCapability(SafeAccountHandle handle, string capabilityType, out int capabilityValue);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_capability", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountCapability(SafeAccountHandle handle, string capabilityType, int capabilityValue);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_icon_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountIconPath(SafeAccountHandle handle, out string iconPath);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_icon_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountIconPath(SafeAccountHandle handle, string iconPath);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_domain_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountDomainName(SafeAccountHandle handle, out string domainName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_domain_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountDomainName(SafeAccountHandle handle, string domainName);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_email_address", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountEmail(SafeAccountHandle handle, out string email);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_email_address", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountEmail(SafeAccountHandle handle, string email);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_package_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountPackageName(SafeAccountHandle handle, out string name);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_package_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountPackageName(SafeAccountHandle handle, string name);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_access_token", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountAccessToken(SafeAccountHandle handle, out string accessToken);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_access_token", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountAccessToken(SafeAccountHandle handle, string accessToken);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_user_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountUserText(SafeAccountHandle handle, int index, out string userText);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_user_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountUserText(SafeAccountHandle handle, int index, string userText);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_user_int")]
        internal static partial int GetAccountUserInt(SafeAccountHandle handle, int index, out int value);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_user_int")]
        internal static partial int SetAccountUserInt(SafeAccountHandle handle, int index, int value);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_auth_type")]
        internal static partial int GetAccountAuthType(SafeAccountHandle handle, out int authType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_auth_type")]
        internal static partial int SetAccountAuthType(SafeAccountHandle handle, int authType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_secret")]
        internal static partial int GetAccountSercet(SafeAccountHandle handle, out int secretType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_secret")]
        internal static partial int SetAccountSecret(SafeAccountHandle handle, int secretType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_sync_support")]
        internal static partial int GetAccountSyncSupport(SafeAccountHandle handle, out int syncType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_sync_support")]
        internal static partial int SetAccountSyncSupport(SafeAccountHandle handle, int syncType);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_source", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountSource(SafeAccountHandle handle, out string source);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_source", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountSource(SafeAccountHandle handle, string source);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_custom", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAccountCustomValue(SafeAccountHandle handle, string key, out string value);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_set_custom", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAccountCustomValue(SafeAccountHandle handle, string key, string value);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_update_sync_status_by_id")]
        internal static partial int UpdateAccountSyncStatusById(int accountId, int status);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_capability_all")]
        internal static partial int GetAllAccountCapabilities(SafeAccountHandle handle, AccountCapabilityCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_query_capability_by_account_id")]
        internal static partial int QueryAccountCapabilityById(AccountCapabilityCallback callback, int accountId, IntPtr userData);

        [LibraryImport(Libraries.AccountSvc, EntryPoint = "account_get_custom_all")]
        internal static partial int GetAllAccountCustomValues(SafeAccountHandle handle, AccountCustomCallback callback, IntPtr userData);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCapabilityCallback(string capabilityType, int capabilityState, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCustomCallback(string key, string value, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountCallback(IntPtr data, IntPtr userData);
    }
}

