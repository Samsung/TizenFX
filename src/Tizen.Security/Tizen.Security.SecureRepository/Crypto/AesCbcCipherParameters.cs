
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for AES algorithm with CBC mode.
    /// </summary>
    public class AesCbcCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCbc.</remarks>
        public AesCbcCipherParameters() : base(CipherAlgorithmType.AesCbc)
        {
        }
    }
}
