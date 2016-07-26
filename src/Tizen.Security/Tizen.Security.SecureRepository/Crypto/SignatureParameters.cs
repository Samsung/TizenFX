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
