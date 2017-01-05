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
using System.Collections.Generic;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// Structure containing the information of Tag data.
    /// </summary>
    public class NfcTagInformation
    {
        internal NfcTagInformation()
        {

        }
        /// <summary>
        /// Key value.
        /// </summary>
        public string Key;
        /// <summary>
        /// Information value.
        /// </summary>
        public byte[] InformationValue;
    }

    /// <summary>
    /// Structure containing the information of Secure element Aid(Application Identifier).
    /// </summary>
    public class NfcRegisteredAidInformation
    {
        internal NfcRegisteredAidInformation()
        {

        }
        /// <summary>
        /// Secure Element Type value.
        /// </summary>
        public NfcSecureElementType SeType;
        /// <summary>
        /// Aid value.
        /// </summary>
        public string Aid;
        /// <summary>
        /// Read-only value.
        /// </summary>
        public bool ReadOnly;
    }
}
