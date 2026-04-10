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
    internal static partial class Error
    {
        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_error_get_code")]
        internal static extern int GetCode(IntPtr /* oauth2_error_h */ handle, out int serverErrorCode, out int platformErrorCode);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_error_get_description")]
        internal static extern int GetDescription(IntPtr /* oauth2_error_h */ handle, out string description);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_error_get_uri")]
        internal static extern int GetUri(IntPtr /* oauth2_error_h */ handle, out string uri);

        [DllImport(Libraries.OAuth2, EntryPoint = "oauth2_error_get_custom_data")]
        internal static extern int GetCustomData(IntPtr /* oauth2_error_h */ handle, string customKey, out string customValue);


    }
}
