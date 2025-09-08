/*
 *  Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        public const string Libwebauthn = "libwebauthn-client.so.1";
    }

    internal static partial class Libwebauthn
    {
        [DllImport(Libraries.Libwebauthn, EntryPoint = "wauthn_set_api_version", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetApiVersion(int apiVersionNumber);
        // int wauthn_set_api_version(int api_version_number);

        [DllImport(Libraries.Libwebauthn, EntryPoint = "wauthn_supported_authenticators", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SupportedAuthenticators(out uint supported);
        // int wauthn_supported_authenticators(unsigned int *supported);

        [DllImport(Libraries.Libwebauthn, EntryPoint = "wauthn_make_credential", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MakeCredential([In] WauthnClientData clientData, [In] WauthnPubkeyCredCreationOptions options, [In, Out] WauthnMcCallbacks callbacks);
        // int wauthn_make_credential( const wauthn_client_data_s *client_data, const wauthn_pubkey_cred_creation_options_s *options, wauthn_mc_callbacks_s *callbacks);

        [DllImport(Libraries.Libwebauthn, EntryPoint = "wauthn_get_assertion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetAssertion([In] WauthnClientData clientData, [In] WauthnPubkeyCredRequestOptions options, [In, Out] WauthnGaCallbacks callbacks);
        // int wauthn_get_assertion( const wauthn_client_data_s *client_data, const wauthn_pubkey_cred_request_options_s *options, wauthn_ga_callbacks_s *callbacks);

        [DllImport(Libraries.Libwebauthn, EntryPoint = "wauthn_cancel", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Cancel();
        // int wauthn_cancel();
    }
}
