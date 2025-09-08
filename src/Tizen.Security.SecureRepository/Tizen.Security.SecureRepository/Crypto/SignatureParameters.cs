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
using System.Collections.Generic;

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Holds parameters for signing and verification.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    abstract public class SignatureParameters
    {
        private Dictionary<SignatureParameterName, int> _parameters;

        /// <summary>
        /// Gets signature algorithm type.
        /// </summary>
        /// <value>
        /// Signature algorithm type.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public SignatureAlgorithmType SignatureAlgorithm
        {
            get { return (SignatureAlgorithmType)Get(SignatureParameterName.AlgorithmType); }
        }

        /// <summary>
        /// Gets and sets hash algorithm.
        /// </summary>
        /// <value>
        /// Hash algorithm used in signing and verification.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public HashAlgorithm HashAlgorithm
        {
            get { return (HashAlgorithm)Get(SignatureParameterName.HashAlgorithm); }
            set { Add(SignatureParameterName.HashAlgorithm, (int)value); }
        }

        // for inherited in internal only
        internal SignatureParameters()
        {
        }

        internal SignatureParameters(SignatureAlgorithmType algorithm)
        {
            _parameters = new Dictionary<SignatureParameterName, int>();
            Add(SignatureParameterName.AlgorithmType, (int)algorithm);
        }

        internal void Add(SignatureParameterName name, int value)
        {
            _parameters.Add(name, value);
        }

        internal int Get(SignatureParameterName name)
        {
            if (_parameters.ContainsKey(name))
                return _parameters[name];
            else
                throw new ArgumentException("No parameter for a given SignatureParameterName ");
        }
    }
}
