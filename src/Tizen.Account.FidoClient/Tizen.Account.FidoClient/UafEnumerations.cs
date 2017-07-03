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

namespace Tizen.Account.FidoClient
{
    /// <summary>
    /// Authenticator's supported algorithm and encoding
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AuthenticationAlgorithm
    {
        /// <summary>
        /// SECP256R1 ECDSA SHA256 Raw
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Secp256r1EcdsaSha256Raw = 0X01,

        /// <summary>
        /// SECP256R1 ECDSA SHA256 DER
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Secp256r1EcdsaSha256Der = 0X02,

        /// <summary>
        /// RSA PSS SHA256 Raw
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RsassaPssSha256Raw = 0X03,

        /// <summary>
        /// RSA PSS SHA256 DER
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RsassaPssSha256Der = 0X04,

        /// <summary>
        /// SECP256K1 ECDSA SHA256 Raw
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Secp256k1EcdsaSha256Raw = 0X05,

        /// <summary>
        /// SECP256K1 ECDSA SHA256 DER
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Secp256k1EcdsaSha256Der = 0X06
    }

    /// <summary>
    /// Authenticator's supported user verification method type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum UserVerificationMethod
    {
        /// <summary>
        /// User presence verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Presence = 0X01,

        /// <summary>
        /// User fingerprint verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Fingerprint = 0X02,

        /// <summary>
        /// User passcode verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Passcode = 0X04,

        /// <summary>
        /// User voiceprint verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Voiceprint = 0X08,

        /// <summary>
        /// User faceprint verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Faceprint = 0X10,
        /// <summary>
        /// User location verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Location = 0X20,

        /// <summary>
        /// User eyeprint verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Eyeprint = 0X40,

        /// <summary>
        /// User pattern verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pattern = 0X80,

        /// <summary>
        /// User handprint verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Handprint = 0X100,

        /// <summary>
        /// Silent verification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None = 0X200,

        /// <summary>
        /// If an authenticator sets multiple flags for user verification types, it may also set this flag to indicate that all verification methods will be enforced (e.g. faceprint AND voiceprint). If flags for multiple user verification methods are set and this flag is not set, verification with only one is necessary (e.g. fingerprint OR passcode).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        All = 0X400
    }

    /// <summary>
    /// Authenticator's supported key protection method type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum KeyProtectionType
    {
        /// <summary>
        /// Software based key management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Software = 0X01,

        /// <summary>
        /// Hardware based key management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Hardware = 0X02,

        /// <summary>
        /// Trusted Execution Environment based key management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tee = 0X04,

        /// <summary>
        /// Secure Element based key management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        SecureElement = 0X08,

        /// <summary>
        /// Authenticator does not store (wrapped) UAuth keys at the client, but relies on a server-provided key handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RemoteHandle = 0X10
    }

    /// <summary>
    /// Authenticator's supported matcher protection type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MatcherProtectionType
    {
        /// <summary>
        /// Authenticator's matcher is running in software.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Software = 0X01,

        /// <summary>
        /// Authenticator's matcher is running inside the Trusted Execution Environment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tee = 0X02,

        /// <summary>
        /// Aauthenticator's matcher is running on the chip.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OnChip = 0X04
    }

    /// <summary>
    /// Authenticator's supproted method to communicate to FIDO user device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AuthenticatorAttachmentHint
    {
        /// <summary>
        /// Authenticator is permanently attached to the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Internal = 0X01,

        /// <summary>
        /// Authenticator is removable or remote from the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        External = 0X02,

        /// <summary>
        /// The external authenticator currently has an exclusive wired connection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wired = 0X04,

        /// <summary>
        /// The external authenticator communicates with the FIDO User Device through wireless means.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wireless = 0X08,

        /// <summary>
        /// Authenticator is able to communicate by NFC to the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Nfc = 0X10,

        /// <summary>
        /// Authenticator is able to communicate by Bluetooth to the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Bt = 0X20,

        /// <summary>
        /// Authenticator is connected to the FIDO User Device ver a non-exclusive network (e.g. over a TCP/IP LAN or WAN, as opposed to a PAN or point-to-point connection).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Nw = 0X40,

        /// <summary>
        /// The external authenticator is in a "ready" state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ready = 0X80,

        /// <summary>
        /// The external authenticator is able to communicate using WiFi Direct with the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WifiDirect = 0X100
    }

    /// <summary>
    /// Authenticator's supported Attestation type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AuthenticatorAttestationType
    {
        /// <summary>
        /// Full basic attestation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BasicFull = 0X3e07,

        /// <summary>
        /// Surrogate basic attestation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BasicSurrogate = 0X3e08,
    }

    /// <summary>
    /// Transaction confirmation display capability type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TransactionConfirmationDisplayType
    {
        /// <summary>
        /// Some form of transaction confirmation display is available on this authenticator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Any = 0X01,

        /// <summary>
        /// Software-based transaction confirmation display operating in a privileged context is available on this authenticator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PrivilegedSoftware = 0X02,

        /// <summary>
        /// Transaction confirmation display is in a Trusted Execution Environment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tee = 0X04,

        /// <summary>
        /// Transaction confirmation display based on hardware assisted capabilities is available on this authenticator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Hw = 0X08,

        /// <summary>
        /// Transaction confirmation display is provided on a distinct device from the FIDO User Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Remote = 0X10
    }
}
