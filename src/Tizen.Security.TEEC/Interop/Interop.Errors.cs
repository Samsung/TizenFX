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
        Generic = 0xFFFF0000,
        NotImplemented = 0xFFFF0009,
        NotSupported = 0xFFFF000A,
        CommunicationFailed = 0xFFFF000E,
    };

    internal static void CheckNThrowException(int err, string msg)
    {
        switch ((uint)err)
        {
            case (uint)LibteecError.None:
                return ;
            case (uint)LibteecError.NotImplemented:
            case (uint)LibteecError.NotSupported:
                throw new NotSupportedException($"[{LogTag}] {msg} error=0x{err.ToString("X")}");
            case (uint)LibteecError.CommunicationFailed:
            case (uint)LibteecError.Generic:
                throw new Exception($"[{LogTag}] {msg} error=0x{err.ToString("X")}");
            default:
                throw new InvalidOperationException($"[{LogTag}] {msg}, error=0x{err.ToString("X")}");

        }
    }
}
