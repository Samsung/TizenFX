namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for data format
    /// </summary>
    public enum DataFormat : int
    {
        /// <summary>
        /// DER format base64 encoded data
        /// </summary>
        DerBase64 = 0,
        /// <summary>
        /// DER encoded data
        /// </summary>
        Der,
        /// <summary>
        /// PEM encoded data. It consists of the DER format base64 encoded
        /// with additional header and footer lines.
        /// </summary>
        Pem
    }
}
