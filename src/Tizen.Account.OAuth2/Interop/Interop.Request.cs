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
    internal static partial class Request
    {
        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_create")]
        internal static extern int Create(out IntPtr /* oauth2_request_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_destroy")]
        internal static extern int Destroy(IntPtr /* oauth2_request_h */ handle);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_auth_end_point_url")]
        internal static extern int SetAuthEndPointUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_token_end_point_url")]
        internal static extern int SetTokenEndPointUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_redirection_url")]
        internal static extern int SetRedirectionUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_refresh_token_url")]
        internal static extern int SetRefreshTokenUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_refresh_token")]
        internal static extern int SetRefreshToken(IntPtr /* oauth2_request_h */ handle, string refreshToken);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_response_type")]
        internal static extern int SetResponseType(IntPtr /* oauth2_request_h */ handle, ResponseType /* oauth2_response_type_e */ responseType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_id")]
        internal static extern int SetClientId(IntPtr /* oauth2_request_h */ handle, string clientId);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_secret")]
        internal static extern int SetClientSecret(IntPtr /* oauth2_request_h */ handle, string clientSecret);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_authentication_type")]
        internal static extern int SetClientAuthenticationType(IntPtr /* oauth2_request_h */ handle, int /* oauth2_client_authentication_type_e */ clientAuthType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_scope")]
        internal static extern int SetScope(IntPtr /* oauth2_request_h */ handle, string scope);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_state")]
        internal static extern int SetState(IntPtr /* oauth2_request_h */ handle, string state);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_grant_type")]
        internal static extern int SetGrantType(IntPtr /* oauth2_request_h */ handle, GrantType /* oauth2_grant_type_e */ grantType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_authorization_code")]
        internal static extern int SetAuthorizationCode(IntPtr /* oauth2_request_h */ handle, string code);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_user_name")]
        internal static extern int SetUserName(IntPtr /* oauth2_request_h */ handle, string userName);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_password")]
        internal static extern int SetPassword(IntPtr /* oauth2_request_h */ handle, string password);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_add_custom_data")]
        internal static extern int AddCustomData(IntPtr /* oauth2_request_h */ handle, string key, string value);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_auth_end_point_url")]
        internal static extern int GetAuthEndPointUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_token_end_point_url")]
        internal static extern int GetTokenEndPointUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_redirection_url")]
        internal static extern int GetRedirectionUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_refresh_token_url")]
        internal static extern int GetRefreshTokenUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_refresh_token")]
        internal static extern int GetRefreshToken(IntPtr /* oauth2_request_h */ handle, out string refreshToken);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_response_type")]
        internal static extern int GetResponseType(IntPtr /* oauth2_request_h */ handle, out ResponseType /* oauth2_response_type_e */ responseType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_client_id")]
        internal static extern int GetClientId(IntPtr /* oauth2_request_h */ handle, out string clientId);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_client_secret")]
        internal static extern int GetClientSecret(IntPtr /* oauth2_request_h */ handle, out string clientSecret);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_scope")]
        internal static extern int GetScope(IntPtr /* oauth2_request_h */ handle, out string scope);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_state")]
        internal static extern int GetState(IntPtr /* oauth2_request_h */ handle, out string state);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_grant_type")]
        internal static extern int GetGrantType(IntPtr /* oauth2_request_h */ handle, out GrantType /* oauth2_grant_type_e */ grantType);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_authorization_code")]
        internal static extern int GetAuthorizationCode(IntPtr /* oauth2_request_h */ handle, out string code);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_user_name")]
        internal static extern int GetUserName(IntPtr /* oauth2_request_h */ handle, out string userName);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_password")]
        internal static extern int GetPassword(IntPtr /* oauth2_request_h */ handle, out string password);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_custom_data")]
        internal static extern int GetCustomData(IntPtr /* oauth2_request_h */ handle, string customKey, out string customValue);
    }
}
