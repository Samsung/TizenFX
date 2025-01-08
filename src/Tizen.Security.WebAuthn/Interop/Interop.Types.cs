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
using Tizen.Internals;
using Tizen.Security.WebAuthn;

internal static partial class Interop
{
    private const string pkg = "webauthn";

    #region Delegates

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void WauthnDisplayQrcodeCallback([In][MarshalAs(UnmanagedType.LPStr)] string qrContents, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void WauthnMcOnResponseCallback([In] WauthnPubkeyCredentialAttestation pubkeyCred, WauthnError result, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void WauthnGaOnResponseCallback([In] WauthnPubkeyCredentialAssertion pubkeyCred, WauthnError result, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void WauthnUpdateLinkedDataCallback([In] IntPtr linkedData, WauthnError result, IntPtr userData);

    #endregion
    #region Classes

    [NativeStruct("wauthn_rp_entity_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnRpEntity
    {
        public readonly IntPtr name;                        // string
        public readonly IntPtr id;                          // string

        public WauthnRpEntity(IntPtr name, IntPtr id)
        {
            this.name = name;
            this.id = id;
        }
    }

    [NativeStruct("wauthn_user_entity_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnUserEntity
    {
        public readonly IntPtr name;                        // string
        public readonly IntPtr id;                          // WauthnConstBuffer*
        public readonly IntPtr displayName;                 // string

        public WauthnUserEntity(IntPtr name, IntPtr id, IntPtr displayName)
        {
            this.name = name;
            this.id = id;
            this.displayName = displayName;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_params_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredParams
    {
        public readonly nuint size;
        public readonly IntPtr parameters;                  // WauthnPubkeyCredParam[]

        public WauthnPubkeyCredParams(nuint size, IntPtr parameters)
        {
            this.size = size;
            this.parameters = parameters;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_descriptors_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredDescriptors
    {
        public readonly nuint size;
        public readonly IntPtr descriptors;                 // WauthnPubkeyCredDescriptor[]

        public WauthnPubkeyCredDescriptors(nuint size, IntPtr descriptors)
        {
            this.size = size;
            this.descriptors = descriptors;
        }
    }

    [NativeStruct("wauthn_authenticator_sel_cri_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnAuthenticationSelCri
    {
        public readonly AuthenticatorAttachment attachment;
        public readonly ResidentKeyRequirement residentKey;
        public readonly byte requireResidentKey;
        public readonly UserVerificationRequirement userVerification;

        public WauthnAuthenticationSelCri(
            AuthenticatorAttachment attachment,
            ResidentKeyRequirement residentKey,
            byte requireResidentKey,
            UserVerificationRequirement userVerification)
        {
            this.attachment = attachment;
            this.residentKey = residentKey;
            this.requireResidentKey = requireResidentKey;
            this.userVerification = userVerification;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_hints_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredHints
    {
        public readonly nuint size;
        public readonly IntPtr hints;                       // PubkeyCredHint[]

        public WauthnPubkeyCredHints(nuint size, IntPtr hints)
        {
            this.size = size;
            this.hints = hints;
        }
    }

    [NativeStruct("wauthn_attestation_formats_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnAttestationFormats
    {
        public readonly nuint size;
        public readonly IntPtr attestationFormats;          // WauthnConstBuffer[]

        public WauthnAttestationFormats(nuint size, IntPtr attestationFormats)
        {
            this.size = size;
            this.attestationFormats = attestationFormats;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_creation_options_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredCreationOptions
    {
        public readonly IntPtr rp;                          // WauthnRpEntity*
        public readonly IntPtr user;                        // WauthnUserEntity*
        public readonly IntPtr pubkeyCredParams;            // WauthnPubkeyCredParams*
        public readonly nuint timeout;
        public readonly IntPtr excludeCredentials;          // WauthnPubkeyCredDescriptors*
        public readonly IntPtr authenticatorSelection;      // WauthnAuthenticationSelCri*
        public readonly IntPtr hints;                       // WauthnPubkeyCredHints*
        public readonly AttestationPref attestation;
        public readonly IntPtr attestationFormats;          // WauthnAttestationFormats*
        public readonly IntPtr extensions;                  // WauthnAuthenticationExts*
        public readonly IntPtr linkedDevice;                // WauthnHybridLinkedData*

        public WauthnPubkeyCredCreationOptions(
            IntPtr rp,
            IntPtr user,
            IntPtr pubkeyCredParams,
            nuint timeout,
            IntPtr excludeCredentials,
            IntPtr authenticatorSelection,
            IntPtr hints,
            AttestationPref attestation,
            IntPtr attestationFormats,
            IntPtr extensions,
            IntPtr linkedDevice)
        {
            this.rp = rp;
            this.user = user;
            this.pubkeyCredParams = pubkeyCredParams;
            this.timeout = timeout;
            this.excludeCredentials = excludeCredentials;
            this.authenticatorSelection = authenticatorSelection;
            this.hints = hints;
            this.attestation = attestation;
            this.attestationFormats = attestationFormats;
            this.extensions = extensions;
            this.linkedDevice = linkedDevice;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_request_options_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredRequestOptions
    {
        public readonly nuint timeout;
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string rpId;
        public readonly IntPtr allowCredentials;            // WauthnPubkeyCredDescriptors*
        public readonly UserVerificationRequirement userVerification;
        public readonly IntPtr hints;                       // WauthnPubkeyCredHints*
        public readonly AttestationPref attestation;
        public readonly IntPtr attestationFormats;          // WauthnAttestationFormats*
        public readonly IntPtr extensions;                  // WauthnAuthenticationExt*
        public readonly IntPtr linkedDevice;                // WauthnHybridLinkedData*

        public WauthnPubkeyCredRequestOptions(
            nuint timeout,
            string rpId,
            IntPtr allowCredentials,
            UserVerificationRequirement userVerification,
            IntPtr hints,
            AttestationPref attestation,
            IntPtr attestationFormats,
            IntPtr extensions,
            IntPtr linkedDevice)
        {
            this.timeout = timeout;
            this.rpId = rpId;
            this.allowCredentials = allowCredentials;
            this.userVerification = userVerification;
            this.hints = hints;
            this.attestation = attestation;
            this.attestationFormats = attestationFormats;
            this.extensions = extensions;
            this.linkedDevice = linkedDevice;
        }
    }

    [NativeStruct("wauthn_pubkey_credential_attestation_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredentialAttestation
    {
        public readonly IntPtr id;                          // WauthnConstBuffer*
        public readonly PubkeyCredType type;
        public readonly IntPtr rawId;                       // WauthnConstBuffer*
        public readonly IntPtr response;                    // WauthnAuthenticatorAttestationResponse*
        public readonly AuthenticatorAttachment authenticatorAttachment;
        public readonly IntPtr extensions;                  // WauthnAuthenticationExts*
        public readonly IntPtr linkedDevice;                // WauthnHybridLinkedData*

        public WauthnPubkeyCredentialAttestation(
            IntPtr id,
            PubkeyCredType type,
            IntPtr rawId,
            IntPtr response,
            AuthenticatorAttachment authenticatorAttachment,
            IntPtr extensions,
            IntPtr linkedDevice)
        {
            this.id = id;
            this.type = type;
            this.rawId = rawId;
            this.response = response;
            this.authenticatorAttachment = authenticatorAttachment;
            this.extensions = extensions;
            this.linkedDevice = linkedDevice;
        }
    }

    [NativeStruct("wauthn_pubkey_credential_assertion_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnPubkeyCredentialAssertion
    {
        public readonly IntPtr id;                          // WauthnConstBuffer*
        public readonly PubkeyCredType type;
        public readonly IntPtr rawId;                       // WauthnConstBuffer*
        public readonly IntPtr response;                    // WauthnAuthenticatorAssertionResponse*
        public readonly AuthenticatorAttachment authenticatorAttachment;
        public readonly IntPtr extensions;                  // WauthnAuthenticationExts*
        public readonly IntPtr linkedDevice;                // WauthnHybridLinkedData*

        public WauthnPubkeyCredentialAssertion(
            IntPtr id,
            IntPtr rawId,
            IntPtr response,
            AuthenticatorAttachment authenticatorAttachment,
            IntPtr extensions,
            IntPtr linkedDevice)
        {
            this.id = id;
            this.rawId = rawId;
            this.response = response;
            this.authenticatorAttachment = authenticatorAttachment;
            this.extensions = extensions;
            this.linkedDevice = linkedDevice;
        }
    }

    [NativeStruct("wauthn_client_data_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnClientData
    {
        public readonly IntPtr clientDataJson;              // WauthnConstBuffer*
        public readonly HashAlgorithm hashAlgo;

        public WauthnClientData(IntPtr clientDataJson, HashAlgorithm hashAlgo)
        {
            this.clientDataJson = clientDataJson;
            this.hashAlgo = hashAlgo;
        }
    }

    [NativeStruct("wauthn_mc_callbacks_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnMcCallbacks
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnDisplayQrcodeCallback qrcodeCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnMcOnResponseCallback responseCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnUpdateLinkedDataCallback linkedDataCallback;
        public readonly IntPtr userData = IntPtr.Zero;

        public WauthnMcCallbacks(
            WauthnDisplayQrcodeCallback qrcodeCallback,
            WauthnMcOnResponseCallback responseCallback,
            WauthnUpdateLinkedDataCallback linkedDataCallback)
        {
            this.qrcodeCallback = qrcodeCallback;
            this.responseCallback = responseCallback;
            this.linkedDataCallback = linkedDataCallback;
        }
    }

    [NativeStruct("wauthn_ga_callbacks_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class WauthnGaCallbacks
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnDisplayQrcodeCallback qrcodeCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnGaOnResponseCallback responseCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly WauthnUpdateLinkedDataCallback linkedDataCallback;
        public readonly IntPtr userData = IntPtr.Zero;

        public WauthnGaCallbacks(
            WauthnDisplayQrcodeCallback qrcodeCallback,
            WauthnGaOnResponseCallback responseCallback,
            WauthnUpdateLinkedDataCallback linkedDataCallback)
        {
            this.qrcodeCallback = qrcodeCallback;
            this.responseCallback = responseCallback;
            this.linkedDataCallback = linkedDataCallback;
        }
    }
    #endregion
    #region Structs

    [NativeStruct("wauthn_const_buffer_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnConstBuffer
    {
        public readonly IntPtr data;                        // byte[]
        public readonly nuint size;

        public WauthnConstBuffer(IntPtr data, nuint size)
        {
            this.data = data;
            this.size = size;
        }

        public readonly byte[] ToArray()
        {
            var ret = new byte[size];
            Marshal.Copy(data, ret, 0, (int)size);
            return ret;
        }
    }

    [NativeStruct("wauthn_authenticator_attestation_response_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnAuthenticatorAttestationResponse
    {
        public readonly IntPtr clientDataJson;              // WauthnConstBuffer*
        public readonly IntPtr attestationObject;           // WauthnConstBuffer*
        public readonly uint transports;
        public readonly IntPtr authenticatorData;           // WauthnConstBuffer*
        public readonly IntPtr subjectPubkeyInfo;           // WauthnConstBuffer*
        public readonly CoseAlgorithm pubkeyAlg;

        public WauthnAuthenticatorAttestationResponse(
            IntPtr clientDataJson,
            IntPtr attestationObject,
            uint transports,
            IntPtr authenticatorData,
            IntPtr subjectPubkeyInfo,
            CoseAlgorithm pubkeyAlg)
        {
            this.clientDataJson = clientDataJson;
            this.attestationObject = attestationObject;
            this.transports = transports;
            this.authenticatorData = authenticatorData;
            this.subjectPubkeyInfo = subjectPubkeyInfo;
            this.pubkeyAlg = pubkeyAlg;
        }
    }

    [NativeStruct("wauthn_authenticator_assertion_response_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnAuthenticatorAssertionResponse
    {
        public readonly IntPtr clientDataJson;            // WauthnConstBuffer*
        public readonly IntPtr authenticatorData;         // WauthnConstBuffer*
        public readonly IntPtr signature;                 // WauthnConstBuffer*
        public readonly IntPtr userHandle;                // WauthnConstBuffer*
        public readonly IntPtr attestationObject;         // WauthnConstBuffer*

        public WauthnAuthenticatorAssertionResponse(
            IntPtr clientDataJson,
            IntPtr authenticatorData,
            IntPtr signature,
            IntPtr userHandle,
            IntPtr attestationObject)
        {
            this.clientDataJson = clientDataJson;
            this.authenticatorData = authenticatorData;
            this.signature = signature;
            this.userHandle = userHandle;
            this.attestationObject = attestationObject;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_param_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnPubkeyCredParam
    {
        public readonly PubkeyCredType type;
        public readonly CoseAlgorithm alg;

        public WauthnPubkeyCredParam(PubkeyCredType type, CoseAlgorithm alg)
        {
            this.type = type;
            this.alg = alg;
        }
    }

    [NativeStruct("wauthn_pubkey_cred_descriptor_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnPubkeyCredDescriptor
    {
        public readonly PubkeyCredType type;
        public readonly IntPtr id;                          // WauthnConstBuffer*
        public readonly AuthenticatorTransport transport;

        public WauthnPubkeyCredDescriptor(PubkeyCredType type, IntPtr id, AuthenticatorTransport transport)
        {
            this.type = type;
            this.id = id;
            this.transport = transport;
        }
    }

    [NativeStruct("wauthn_authentication_ext_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnAuthenticationExt
    {
        public readonly IntPtr extensionId;                 // WauthnConstBuffer*
        public readonly IntPtr extensionValue;              // WauthnConstBuffer*

        public WauthnAuthenticationExt(IntPtr extensionId, IntPtr extensionValue)
        {
            this.extensionId = extensionId;
            this.extensionValue = extensionValue;
        }
    }

    [NativeStruct("wauthn_authentication_exts_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnAuthenticationExts
    {
        public readonly nuint size;
        public readonly IntPtr descriptors;                 // WauthnAuthenticationExt[]

        public WauthnAuthenticationExts(nuint size, IntPtr descriptors)
        {
            this.size = size;
            this.descriptors = descriptors;
        }
    }

    [NativeStruct("wauthn_hybrid_linked_data_s", Include="webauthn-types.h", PkgConfig=pkg)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct WauthnHybridLinkedData
    {
        public readonly IntPtr contactId;                   // WauthnConstBuffer*
        public readonly IntPtr linkId;                      // WauthnConstBuffer*
        public readonly IntPtr linkSecret;                  // WauthnConstBuffer*
        public readonly IntPtr authenticatorPubkey;         // WauthnConstBuffer*
        public readonly IntPtr authenticatorName;           // WauthnConstBuffer*
        public readonly IntPtr signature;                   // WauthnConstBuffer*
        public readonly IntPtr tunnelServerDomain;          // WauthnConstBuffer*
        public readonly IntPtr identityKey;                 // WauthnConstBuffer*

        public WauthnHybridLinkedData(
            IntPtr contactId,
            IntPtr linkId,
            IntPtr linkSecret,
            IntPtr authenticatorPubkey,
            IntPtr authenticatorName,
            IntPtr signature,
            IntPtr tunnelServerDomain,
            IntPtr identityKey)
        {
            this.contactId = contactId;
            this.linkId = linkId;
            this.linkSecret = linkSecret;
            this.authenticatorPubkey = authenticatorPubkey;
            this.authenticatorName = authenticatorName;
            this.signature = signature;
            this.tunnelServerDomain = tunnelServerDomain;
            this.identityKey = identityKey;
        }
    }

    #endregion
}
