
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for RSA signature algorithm.
    /// </summary>
    public class RsaSignatureParameters : SignatureParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The SignatureAlgorithmType in SignatureParameters is set to SignatureAlgorithmType.RsaSignature.</remarks>
        /// <remarks>The RsaPadding is set to RsaPaddingAlgorithm.None.</remarks>
        public RsaSignatureParameters() : base(SignatureAlgorithmType.RsaSignature)
        {
        }

        /// <summary>
        /// RSA padding algorithm
        /// </summary>
        public RsaPaddingAlgorithm RsaPadding
        {
            get { return (RsaPaddingAlgorithm)Get(SignatureParameterName.RsaPaddingAlgorithm); }
            set { Add(SignatureParameterName.RsaPaddingAlgorithm, (int)value); }
        }
    }
}
