namespace Tizen.Security.SecureRepository
{

    /// <summary>
    /// Enumeration for permissions to access/modify alias.
    /// </summary>
    public enum Permission : int
    {
        /// <summary>
        /// Clear permissions
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Eead allowed
        /// </summary>
        Read = 0x01,
        /// <summary>
        /// Remove allowed
        /// </summary>
        Remove = 0x02
    }
}
