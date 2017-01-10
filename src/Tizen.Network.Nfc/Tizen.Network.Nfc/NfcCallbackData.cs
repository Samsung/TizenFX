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
        private string _key;
        private byte[] _informationValue;

        internal NfcTagInformation(string key, byte[] informationValue)
        {
            _key = key;
            _informationValue = informationValue;
        }

        /// <summary>
        /// Key value.
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }
        }
        /// <summary>
        /// Information value.
        /// </summary>
        public byte[] InformationValue
        {
            get
            {
                return _informationValue;
            }
        }
    }

    /// <summary>
    /// Structure containing the information of Secure element Aid(Application Identifier).
    /// </summary>
    public class NfcRegisteredAidInformation
    {
        private NfcSecureElementType _seType;
        private string _aid;
        private bool _readOnly;

        internal NfcRegisteredAidInformation(NfcSecureElementType seType, string aid, bool readOnly)
        {
            _seType = seType;
            _aid = aid;
            _readOnly = readOnly;
        }

        /// <summary>
        /// Secure Element Type value.
        /// </summary>
        public NfcSecureElementType SeType
        {
            get
            {
                return _seType;
            }
        }

        /// <summary>
        /// 
        /// The targeted Aid (Application Identifier) value.
        /// </summary>
        public string Aid
        {
            get
            {
                return _aid;
            }
        }

        /// <summary>
        /// Read-only value. If this value is false, there are restrictions to the operation on this Aid.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
        }
    }
}
