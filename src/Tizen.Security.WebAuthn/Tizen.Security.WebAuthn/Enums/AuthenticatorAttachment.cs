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

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// WebAuthn authentication attachment value.
    /// </summary>
    /// <remarks>
    /// Refer to the following W3C specification for more information.
    /// https://www.w3.org/TR/webauthn-3/#enumdef-authenticatorattachment
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public enum AuthenticatorAttachment
    {
        /// <summary>
        /// No attachment.
        /// </summary>
        None                        = 0,
        /// <summary>
        /// Platform attachment.
        /// </summary>
        Platform                    = 1,
        /// <summary>
        /// Cross-platform attachment.
        /// </summary>
        CrossPlatform               = 2,
    }
}