namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Enumeration for elliptic curve
    /// </summary>
    public enum EllipticCurveType : int
    {
        /// <summary>
        /// Elliptic curve domain "secp192r1" listed in "SEC 2" recommended elliptic curve domain
        /// </summary>
        Prime192V1 = 0,
        /// <summary>
        /// "SEC 2" recommended elliptic curve domain - secp256r1
        /// </summary>
        Prime256V1,
        /// <summary>
        /// NIST curve P-384(covers "secp384r1", the elliptic curve domain listed in See SEC 2
        /// </summary>
        Secp384R1
    }
}
