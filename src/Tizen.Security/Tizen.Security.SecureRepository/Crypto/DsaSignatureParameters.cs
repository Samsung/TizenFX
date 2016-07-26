
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for DSA signature algorithm.
    /// </summary>
    public class DsaSignatureParameters : SignatureParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The SignatureAlgorithmType in SignatureParameters is set to SignatureAlgorithmType.DsaSignature.</remarks>
        public DsaSignatureParameters() : base(SignatureAlgorithmType.DsaSignature)
        {
        }
    }
}
