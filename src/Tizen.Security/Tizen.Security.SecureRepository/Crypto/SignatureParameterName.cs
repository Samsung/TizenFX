namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for signature algorithm parameters.
    /// </summary>
    internal enum SignatureParameterName : int
    {
        /// <summary>
        /// Signaturea Algorithm Type
        /// </summary>
        AlgorithmType = 0x01,
        /// <summary>
        /// Hash Algorithm Type
        /// </summary>
        HashAlgorithm,
        /// <summary>
        /// RSA Padding Algorithm Type
        /// </summary>
        RsaPaddingAlgorithm
    }
}
