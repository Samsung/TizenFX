namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// Enumeration for crypto cipher algorithm types.
    /// </summary>
    public enum CipherAlgorithmType : int
    {
        /// <summary>
        /// AES-CTR algorithm
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesCtr(mandatory),
        /// - ParameterName.IV = 16 - byte initialization vector(mandatory)
        /// - ParameterName.CounterLength = length of counter block in bits
        ///   (optional, only 128b is supported at the moment)
        /// </summary>
        AesCtr = 0x01,
        /// <summary>
        /// AES-CBC algorithm
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesCbc(mandatory),
        /// - ParameterName.IV = 16-byte initialization vector(mandatory)
        /// </summary>
        AesCbc,
        /// <summary>
        /// AES-GCM algorithm
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AesGcm(mandatory),
        /// - ParameterName.IV = initialization vector(mandatory)
        /// - ParameterName.TagLength = GCM tag length in bits. One of
        ///   {32, 64, 96, 104, 112, 120, 128} (optional, if not present the length 128 is used)
        /// - CKMC_PARAM_ED_AAD = additional authentication data(optional)
        /// </summary>
        AesGcm,
        /// <summary>
        /// AES-CFB algorithm
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = AecCfb(mandatory),
        /// - ParameterName.IV = 16-byte initialization vector(mandatory)
        /// </summary>
        AecCfb,
        /// <summary>
        /// RSA-OAEP algorithm
        /// Supported parameters:
        /// - ParameterName.AlgorithmType = RsaOaep(required),
        /// - ParameterName.Label = label to be associated with the message
        ///   (optional, not supported at the moment)
        /// </summary>
        RsaOaep
    }
}
