/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Holds parameters for encryption and decryption.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    abstract public class CipherParameters
    {
        private SafeCipherParametersHandle _handle;

        /// <summary>
        /// Gets cipher algorithm type.
        /// </summary>
        /// <value>
        /// Cipher algorithm type.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public CipherAlgorithmType Algorithm
        {
            get
            {
                return (CipherAlgorithmType)GetInteger(
                    CipherParameterName.AlgorithmType);
            }
        }

        // for inherited in internal only
        internal CipherParameters()
        {
        }

        internal CipherParameters(CipherAlgorithmType algorithm)
        {
            this._handle = new SafeCipherParametersHandle(algorithm);
        }

        internal void Add(CipherParameterName name, long value)
        {
            this._handle.SetInteger(name, value);
        }

        internal void Add(CipherParameterName name, byte[] value)
        {
            this._handle.SetBuffer(name, value);
        }

        internal long GetInteger(CipherParameterName name)
        {
            return this._handle.GetInteger(name);
        }

        internal byte[] GetBuffer(CipherParameterName name)
        {
            return this._handle.GetBuffer(name);
        }

        internal IntPtr Ptr
        {
            get { return this._handle.Ptr; }
        }
    }
}
