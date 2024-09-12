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

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// WebAuthn authenticator transports.
    /// </summary>
    /// <remarks>
    /// Multiple transport values can be combined using bit-wise operation.
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#enum-transport
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    [Flags]
    public enum AuthenticatorTransport : uint
    {
        /// <summary>
        /// No transport specified.
        /// </summary>
        None                        = 0x00000000,
        /// <summary>
        /// Authenticator reachable over USB.
        /// </summary>
        Usb                         = 0x00000001,
        /// <summary>
        /// Authenticator reachable over NFC.
        /// </summary>
        Nfc                         = 0x00000002,
        /// <summary>
        /// Authenticator reachable over BLE.
        /// </summary>
        Ble                         = 0x00000004,
        /// <summary>
        /// Authenticator reachable using Smart Card.
        /// </summary>
        Smartcard                   = 0x00000008,
        /// <summary>
        /// Authenticator reachable using a combination of mechanisms.
        /// </summary>
        Hybrid                      = 0x00000010,
        /// <summary>
        /// Authenticator reachable using a client device-specific transport.
        /// </summary>
        Internal                    = 0x00000020,
    }
}