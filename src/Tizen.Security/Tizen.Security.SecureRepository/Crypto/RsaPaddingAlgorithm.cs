namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for RSA padding algorithm
    /// </summary>
    public enum RsaPaddingAlgorithm : int
    {
        /// <summary>
        /// No Padding
        /// </summary>
        None = 0,
        /// <summary>
        /// PKCS#1 Padding
        /// </summary>
        Pkcs1,
        /// <summary>
        /// X9.31 padding
        /// </summary>
        X931
    }
}
