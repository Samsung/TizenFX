using System;

internal static partial class Interop
{
    private const int TizenErrorKeyManager = -0x01E10000;

    internal enum KeyManagerError : int
    {
        // TODO : Add reference to real Tizen project
        //None = Tizen.Internals.Errors.ErrorCode.None,
        //InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter
        None = 0, // CKMC_ERROR_NONE
        InvalidParameter = -22, // CKMC_ERROR_INVALID_PARAMETER
        VerificationFailed = TizenErrorKeyManager | 0x0D // CKMC_ERROR_VERIFICATION_FAILED
    };

    internal class KeyManagerExceptionFactory
    {
        internal const string LogTag = "Tizen.Security.SecureRepository";

        internal static void CheckNThrowException(int err, string msg)
        {
            if (err == (int)KeyManagerError.None)
                return;

            switch (err)
            {
                case (int)KeyManagerError.InvalidParameter:
                    throw new ArgumentException(msg + ", error=" + Interop.GetErrorMessage(err));
                default:
                    throw new InvalidOperationException(msg + ", error=" + Interop.GetErrorMessage(err));
            }
        }
    }
}
