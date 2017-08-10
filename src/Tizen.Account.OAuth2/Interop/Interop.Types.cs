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
    internal enum GrantType
    {
        AuthCode, // OAUTH2_GRANT_TYPE_AUTH_CODE
        Password, // OAUTH2_GRANT_TYPE_PASSWORD
        ClientCredentials, // OAUTH2_GRANT_TYPE_CLIENT_CREDENTIALS
        Refresh, // OAUTH2_GRANT_TYPE_REFRESH
    }

    internal enum ResponseType
    {
        Code, // OAUTH2_RESPONSE_TYPE_CODE
        Token, // OAUTH2_RESPONSE_TYPE_TOKEN
    }
}
