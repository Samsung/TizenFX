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
/// Contains Interop declarations of OAuth2 classes.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Wrapper class for OAuth2 native API.
    /// </summary>
    internal static partial class Manager
    {
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void Oauth2TokenCallback(IntPtr /* oauth2_response_h */ response, IntPtr /* void */ userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void Oauth2AuthGrantCallback(IntPtr /* oauth2_response_h */ response, IntPtr /* void */ userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void Oauth2AccessTokenCallback(IntPtr /* oauth2_response_h */ response, IntPtr /* void */ userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void Oauth2RefreshTokenCallback(IntPtr /* oauth2_response_h */ response, IntPtr /* void */ userData);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_create")]
        internal static extern int Create(out IntPtr /* oauth2_manager_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_destroy")]
        internal static extern int Destroy(IntPtr /* oauth2_manager_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_request_token")]
        internal static extern int RequestToken(IntPtr /* oauth2_manager_h */ handle, IntPtr /* oauth2_request_h */ request, Oauth2TokenCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_request_authorization_grant")]
        internal static extern int RequestAuthorizationGrant(IntPtr /* oauth2_manager_h */ handle, IntPtr /* oauth2_request_h */ request, Oauth2AuthGrantCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_request_access_token")]
        internal static extern int RequestAccessToken(IntPtr /* oauth2_manager_h */ handle, IntPtr /* oauth2_request_h */ request, Oauth2AccessTokenCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_refresh_access_token")]
        internal static extern int RefreshAccessToken(IntPtr /* oauth2_manager_h */ handle, IntPtr /* oauth2_request_h */ request, Oauth2RefreshTokenCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_is_request_in_progress")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsRequestInProgress(IntPtr /* oauth2_manager_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_clear_cookies")]
        internal static extern int ClearCookies(IntPtr /* oauth2_manager_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_manager_clear_cache")]
        internal static extern int ClearCache(IntPtr /* oauth2_manager_h */ handle);
    }
}
