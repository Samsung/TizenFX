
namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A class holding parameters for AES algorithm with GCM mode.
    /// </summary>
    public class AesGcmCipherParameters : AesCipherParameters
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <remarks>The CipherAlgorithmType in CipherParameters is set to CipherAlgorithmType.AesGcm.</remarks>
        public AesGcmCipherParameters() : base(CipherAlgorithmType.AesGcm)
        {
        }

        /// <summary>
        /// GCM tag length in bits.
        /// </summary>
        /// <remarks>One of {32, 64, 96, 104, 112, 120, 128} (optional, if not present the length 128 is used.</remarks>
        public long TagLength
        {
            get { return GetInteger(CipherParameterName.TagLength); }
            set { Add(CipherParameterName.TagLength, value); }
        }

        /// <summary>
        /// Additional authentication data(optional)
        /// </summary>
        public byte[] AAD
        {
            get { return GetBuffer(CipherParameterName.AAD); }
            set { Add(CipherParameterName.AAD, value); }
        }
    }
}
