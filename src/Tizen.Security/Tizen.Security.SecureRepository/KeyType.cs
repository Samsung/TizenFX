namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for key types of key manager.
    /// </summary>
    public enum KeyType : int
    {
        /// <summary>
        /// Key type not specified
        /// </summary>
        None = 0,
        /// <summary>
        /// RSA public key
        /// </summary>
        RsaPublic,
        /// <summary>
        /// RSA private key
        /// </summary>
        RsaPrivate,
        /// <summary>
        /// ECDSA public key
        /// </summary>
        EcdsaPublic,
        /// <summary>
        /// ECDSA private key
        /// </summary>
        EcdsaPrivate,
        /// <summary>
        /// DSA public key
        /// </summary>
        DsaPublic,
        /// <summary>
        /// DSA private key
        /// </summary>
        DsaPrivate,
        /// <summary>
        /// AES key
        /// </summary>
        Aes
    }
}
