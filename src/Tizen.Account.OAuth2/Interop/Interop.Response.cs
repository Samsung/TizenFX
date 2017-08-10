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
    internal static partial class Response
    {
        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_destroy")]
        internal static extern int Destroy(IntPtr /* oauth2_response_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_authorization_code")]
        internal static extern int GetAuthorizationCode(IntPtr /* oauth2_response_h */ handle, out IntPtr code);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_state")]
        internal static extern int GetState(IntPtr /* oauth2_response_h */ handle, out IntPtr state);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_access_token")]
        internal static extern int GetAccessToken(IntPtr /* oauth2_response_h */ handle, out IntPtr accessToken);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_token_type")]
        internal static extern int GetTokenType(IntPtr /* oauth2_response_h */ handle, out IntPtr tokenType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_expires_in")]
        internal static extern int GetExpiresIn(IntPtr /* oauth2_response_h */ handle, out long expiresIn);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_refresh_token")]
        internal static extern int GetRefreshToken(IntPtr /* oauth2_response_h */ handle, out IntPtr refreshToken);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_scope")]
        internal static extern int GetScope(IntPtr /* oauth2_response_h */ handle, out IntPtr scope);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_error")]
        internal static extern int GetError(IntPtr /* oauth2_response_h */ handle, out IntPtr /* oauth2_error_h */ error);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_response_get_custom_data")]
        internal static extern int GetCustomData(IntPtr /* oauth2_response_h */ handle, string customKey, out IntPtr customValue);


   }
}
