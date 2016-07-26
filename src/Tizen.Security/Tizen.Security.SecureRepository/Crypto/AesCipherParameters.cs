
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A abstract class holding parameters for AES algorithm.
    /// </summary>
    public abstract class AesCipherParameters : CipherParameters
    {
        /// <summary>
        /// A constructor with algorithm
        /// </summary>
        /// <param name="algorithm">An algorithm that this parameters are prepared for.</param>
        public AesCipherParameters(CipherAlgorithmType algorithm) : base(algorithm)
        {
        }

        /// <summary>
        /// An initialization vector.
        /// </summary>
        public byte[] IV
        {
            get { return GetBuffer(CipherParameterName.IV); }
            set { Add(CipherParameterName.IV, value); }
        }
    }
}
