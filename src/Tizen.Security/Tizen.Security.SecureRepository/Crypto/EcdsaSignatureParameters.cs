
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for ECDSA signature algorithm.
    /// </summary>
    public class EcdsaSignatureParameters : SignatureParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The SignatureAlgorithmType in SignatureParameters is set to SignatureAlgorithmType.EcdsaSignature.</remarks>
        public EcdsaSignatureParameters() : base(SignatureAlgorithmType.EcdsaSignature)
        {
        }
    }
}