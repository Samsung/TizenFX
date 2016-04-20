// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

namespace Tizen.Internals.Errors
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ErrorFacts
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static int GetLastResult()
        {
            return Interop.CommonError.GetLastResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        internal static string GetErrorMessage(int errorCode)
        {
            IntPtr errorPtr = Interop.CommonError.GetErrorMessage(errorCode);
            return Marshal.PtrToStringAuto(errorPtr);
        }
    }
}
