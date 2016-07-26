
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for RSA algorithm with OAEP mode.
    /// </summary>
    public class RsaOaepParameters : CipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.RsaOaep.</remarks>
        public RsaOaepParameters() : base(CipherAlgorithmType.RsaOaep)
        {
        }
    }
}
