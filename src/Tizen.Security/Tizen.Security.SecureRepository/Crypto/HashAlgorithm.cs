namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for hash algorithm
    /// </summary>
    public enum HashAlgorithm : int
    {
        /// <summary>
        ///  No Hash Algorithm
        /// </summary>
        None = 0,
        /// <summary>
        /// Hash Algorithm SHA1
        /// </summary>
        Sha1,
        /// <summary>
        /// Hash Algorithm SHA256
        /// </summary>
        Sha256,
        /// <summary>
        /// Hash Algorithm SHA384
        /// </summary>
        Sha384,
        /// <summary>
        /// Hash Algorithm SHA512
        /// </summary>
        Sha512
    }
}
