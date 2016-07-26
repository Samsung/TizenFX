
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for AES algorithm with CFB mode.
    /// </summary>
    public class AesCfbCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCfb.</remarks>
        public AesCfbCipherParameters() : base(CipherAlgorithmType.AecCfb)
        {
        }
    }
}
