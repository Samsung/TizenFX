namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for cipher algorithm parameters.
    /// </summary>
    public enum CipherParameterName : int
    {
        /// <summary>
        /// Algorithm Type
        /// </summary>
        AlgorithmType = 0x01,
        /// <summary>
        /// Initial Vector,  16B buffer (up to 2^64-1 bytes long in case of AES GCM)
        /// </summary>
        IV = 101,
        /// <summary>
        /// Integer - ctr length in bits
        /// </summary>
        CounterLength = 102,
        /// <summary>
        /// Additional authenticated data(AAD)
        /// </summary>
        AAD = 103,
        /// <summary>
        /// Tag Length
        /// </summary>
        TagLength = 104,
        /// <summary>
        /// Label
        /// </summary>
        Label = 105
    }

}
