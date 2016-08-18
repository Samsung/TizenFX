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
using System.Collections;

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A abstract class holding parameters for signing and verification.
    /// </summary>
    abstract public class SignatureParameters
    {
        private Hashtable _parameters;

        /// <summary>
        /// A constructor with algorithm
        /// </summary>
        /// <param name="algorithm">An algorithm that this parameters are prepared for.</param>
        protected SignatureParameters(SignatureAlgorithmType algorithm)
        {
            _parameters = new Hashtable();
            Add(SignatureParameterName.AlgorithmType, (int)algorithm);
        }

        /// <summary>
        /// Signature algorithm type.
        /// </summary>
        public SignatureAlgorithmType SignatureAlgorithm
        {
            get { return (SignatureAlgorithmType)Get(SignatureParameterName.AlgorithmType); }
        }

        /// <summary>
        /// Hash algorithm used in signing anve verification.
        /// </summary>
        public HashAlgorithm HashAlgorithm
        {
            get { return (HashAlgorithm)Get(SignatureParameterName.HashAlgorithm); }
            set { Add(SignatureParameterName.HashAlgorithm, (int)value); }
        }

        /// <summary>
        /// Adds integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        internal void Add(SignatureParameterName name, int value)
        {
            _parameters.Add((int)name, value);
        }

        /// <summary>
        /// Gets integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        internal int Get(SignatureParameterName name)
        {
            if (_parameters.ContainsKey((int)name))
                return (int)_parameters[(int)name];
            else
                throw new ArgumentException("No parameter for a given SignatureParameterName ");
        }
    }
}
