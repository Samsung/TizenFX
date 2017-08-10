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
    internal static partial class UafAuthenticator
    {
        [DllImport(Libraries.FidoClient, EntryPoint = "fido_foreach_authenticator")]
        internal static extern int ForeachAuthenticator(FidoAuthenticatorCallback cb, IntPtr /* void */ userData);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_title")]
        internal static extern int GetTitle(IntPtr /* fido_authenticator_h */ auth, out IntPtr title);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_aaid")]
        internal static extern int GetAaid(IntPtr /* fido_authenticator_h */ auth, out IntPtr aaid);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_description")]
        internal static extern int GetDescription(IntPtr /* fido_authenticator_h */ auth, out IntPtr desc);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_assertion_scheme")]
        internal static extern int GetAssertionScheme(IntPtr /* fido_authenticator_h */ auth, out IntPtr scheme);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_algorithm")]
        internal static extern int GetAlgorithm(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_algo_e */ algo);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_foreach_attestation_type")]
        internal static extern int ForeachAttestationType(IntPtr /* fido_authenticator_h */ auth, FidoAttestationTypeCallback cb, IntPtr /* void */ userData);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_verification_method")]
        internal static extern int GetVerificationMethod(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_user_verify_type_e */ userVerification);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_key_protection_method")]
        internal static extern int GetKeyProtectionMethod(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_key_protection_type_e */ keyProtection);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_matcher_protection_method")]
        internal static extern int GetMatcherProtectionMethod(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_matcher_protection_type_e */ matcherProtection);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_attachment_hint")]
        internal static extern int GetAttachmentHint(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_attachment_hint_e */ attachmentHint);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_is_second_factor_only")]
        internal static extern bool GetIsSecondFactorOnly(IntPtr /* fido_authenticator_h */ auth);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_tc_discplay")]
        internal static extern int GetTcDiscplay(IntPtr /* fido_authenticator_h */ auth, out int /* fido_auth_tc_display_type_e */ tcDisplay);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_tc_display_type")]
        internal static extern int GetTcDisplayType(IntPtr /* fido_authenticator_h */ auth, out IntPtr tcDisplayContentType);

        [DllImport(Libraries.FidoClient, EntryPoint = "fido_authenticator_get_icon")]
        internal static extern int GetIcon(IntPtr /* fido_authenticator_h */ auth, out IntPtr icon);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void FidoAuthenticatorCallback(IntPtr /* fido_authenticator_h */ authInfo, IntPtr /* void */ userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void FidoAttestationTypeCallback(int /* fido_auth_attestation_type_e */ attType, IntPtr /* void */ userData);
    }
}
