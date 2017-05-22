/*
 * Interop.Errors.cs
 *
 *  Created on: Apr 4, 2017
 *      Author: k.dynowski
 */

using System;

internal static partial class Interop
{

    private const string LogTag = "Tizen.Security.Libteec";
    internal enum LibteecError : uint
    {
        None = 0,
        NotImplemented = 0xFFFF0009,
        CommunicationFailed = 0xFFFF000E,
    };

    internal static void CheckNThrowException(int err, string msg)
    {
        switch ((uint)err)
        {
            case (uint)LibteecError.None:
                return ;
            case (uint)LibteecError.NotImplemented:
                throw new NotSupportedException(string.Format("[{0}] {1} error=0x{2}",
                        LogTag, msg, err.ToString("X")));
            case (uint)LibteecError.CommunicationFailed:
                throw new Exception(string.Format("[{0}] {1} error=0x{2}",
                        LogTag, msg, err.ToString("X")));
            default:
                throw new InvalidOperationException(string.Format("[{0}] {1}, error=0x{2}",
                        LogTag, msg, err.ToString("X")));

        }
    }
}
