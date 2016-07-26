namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for signature algorithm types.
    /// </summary>
    public enum SignatureAlgorithmType : int
    {
        /// <summary>
        /// RSA signature algorithm
        /// </summary>
        RsaSignature = 0x01,
        /// <summary>
        /// DSA signature algorithm
        /// </summary>
        DsaSignature,
        /// <summary>
        /// ECDSA signature algorithm
        /// </summary>
        EcdsaSignature
    }
}
