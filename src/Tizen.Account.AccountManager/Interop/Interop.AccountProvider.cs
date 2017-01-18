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
/// Interop for AccountProvider class APIs
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for AccountProvider class APIs
    /// </summary>
    internal static partial class AccountProvider
    {

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Create(out IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_app_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAppId(IntPtr handle, out string appId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_supported_feature", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsFeatureSupported(string appId, string capability);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_service_provider_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetServiceProviderId(IntPtr handle, out string providerId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_icon_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountProviderIconPath(IntPtr handle, out string iconPath);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_small_icon_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAccountProviderSmallIconPath(IntPtr handle, out string iconPath);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_multiple_account_support", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMultipleAccountSupport(IntPtr handle, out int suppport);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_label_by_locale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetlabelbyLocale(IntPtr handle, string locale, out string label);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_app_id_exist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAppIdExists(string appId);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_foreach_account_type_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAllAccountProviders(AccountProviderCallback callback, IntPtr data);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_provider_feature_by_app_id")]
        internal static extern int GetAccountProviderFeaturesByAppId(AccountProviderFeatureCallback callback, string appId, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_provider_feature_all")]
        internal static extern int GetAccountProviderFeatures(IntPtr handle, AccountProviderFeatureCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_get_label")]
        internal static extern int GetAccountProviderLabels(IntPtr handle, LabelCallback callback, IntPtr userData);

        [DllImport(Libraries.AccountSvc, EntryPoint = "account_type_query_label_by_app_id")]
        internal static extern int GetLablesByAppId(LabelCallback callback, string appId, IntPtr userData);


        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountProviderFeatureCallback(string appId, string key, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AccountProviderCallback(IntPtr handle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool LabelCallback(string appId, string label, string locale, IntPtr user_data);

    }
}
