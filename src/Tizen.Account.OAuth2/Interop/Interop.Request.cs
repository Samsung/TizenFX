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
        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int Create(out IntPtr /* oauth2_request_h */ handle);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int Destroy(IntPtr /* oauth2_request_h */ handle);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_auth_end_point_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAuthEndPointUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_token_end_point_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetTokenEndPointUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_redirection_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetRedirectionUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_refresh_token_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetRefreshTokenUrl(IntPtr /* oauth2_request_h */ handle, string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_refresh_token", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetRefreshToken(IntPtr /* oauth2_request_h */ handle, string refreshToken);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_response_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetResponseType(IntPtr /* oauth2_request_h */ handle, ResponseType /* oauth2_response_type_e */ responseType);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetClientId(IntPtr /* oauth2_request_h */ handle, string clientId);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_secret", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetClientSecret(IntPtr /* oauth2_request_h */ handle, string clientSecret);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_client_authentication_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetClientAuthenticationType(IntPtr /* oauth2_request_h */ handle, int /* oauth2_client_authentication_type_e */ clientAuthType);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_scope", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetScope(IntPtr /* oauth2_request_h */ handle, string scope);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetState(IntPtr /* oauth2_request_h */ handle, string state);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_grant_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetGrantType(IntPtr /* oauth2_request_h */ handle, GrantType /* oauth2_grant_type_e */ grantType);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_authorization_code", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAuthorizationCode(IntPtr /* oauth2_request_h */ handle, string code);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetUserName(IntPtr /* oauth2_request_h */ handle, string userName);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_set_password", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetPassword(IntPtr /* oauth2_request_h */ handle, string password);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_add_custom_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddCustomData(IntPtr /* oauth2_request_h */ handle, string key, string value);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_auth_end_point_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAuthEndPointUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_token_end_point_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetTokenEndPointUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_redirection_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetRedirectionUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_refresh_token_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetRefreshTokenUrl(IntPtr /* oauth2_request_h */ handle, out string url);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_refresh_token", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetRefreshToken(IntPtr /* oauth2_request_h */ handle, out string refreshToken);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_response_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetResponseType(IntPtr /* oauth2_request_h */ handle, out ResponseType /* oauth2_response_type_e */ responseType);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_client_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetClientId(IntPtr /* oauth2_request_h */ handle, out string clientId);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_client_secret", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetClientSecret(IntPtr /* oauth2_request_h */ handle, out string clientSecret);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_scope", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetScope(IntPtr /* oauth2_request_h */ handle, out string scope);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetState(IntPtr /* oauth2_request_h */ handle, out string state);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_grant_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetGrantType(IntPtr /* oauth2_request_h */ handle, out GrantType /* oauth2_grant_type_e */ grantType);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_authorization_code", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAuthorizationCode(IntPtr /* oauth2_request_h */ handle, out string code);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_user_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetUserName(IntPtr /* oauth2_request_h */ handle, out string userName);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_password", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetPassword(IntPtr /* oauth2_request_h */ handle, out string password);

        [LibraryImport(Libraries.OAuth2, EntryPoint = "oauth2_request_get_custom_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetCustomData(IntPtr /* oauth2_request_h */ handle, string customKey, out string customValue);
    }
}
