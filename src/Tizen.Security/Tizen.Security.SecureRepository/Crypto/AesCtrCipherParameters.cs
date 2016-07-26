
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for AES algorithm with counter mode.
    /// </summary>
    public class AesCtrCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesCtr.</remarks>
        public AesCtrCipherParameters() : base(CipherAlgorithmType.AesCtr)
        {
        }

        /// <summary>
        /// Length of counter block in bits. 
        /// </summary>
        /// <remarks>Optional, only 128b is supported at the moment.</remarks>
        public long CounterLength
        {
            get
            {
                return (uint)GetInteger(CipherParameterName.CounterLength);
            }
            set
            {
                Add(CipherParameterName.CounterLength, value);
            }
        }
    }
}
