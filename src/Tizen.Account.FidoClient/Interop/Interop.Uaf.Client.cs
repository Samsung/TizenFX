// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class UafClient
    {
        [DllImport(Libraries.FidoClient, EntryPoint = "fido_get_client_vendor")]
        internal static extern int FidoGetClientVendor(out string vendorName);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_get_client_version")]
        internal static extern int FidoGetClientVersion(out int clientMajorVersion, out int clientMinorVersion);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_uaf_is_supported")]
        internal static extern int FidoUafIsSupported(string uafMessageJson, out bool isSupported);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_uaf_get_response_message")]
        internal static extern int FidoUafGetResponseMessage(string uafRequestJson, string channelBinding, FidoUafResponseMessageCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_uaf_set_server_result")]
        internal static extern int FidoUafSetServerResult(int responseCode, string uafResponseJson);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void FidoUafResponseMessageCallback(int /* fido_error_e */ tizenErrorCode, string uafResponseJson, IntPtr /* void */ userData);
    }
}
