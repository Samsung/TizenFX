/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

// Because Tizen.Internals assembly defines friends assembly attribute,
// Include the Interop class to the Tizen.Internals namespace to avoid conflicts with Interop classes in other assembly.
namespace Tizen.Internals
{
    internal static partial class Interop
    {
        internal static partial class Libraries
        {
            public const string Base = "libcapi-base-common.so.0";
        }

        internal static partial class CommonError
        {
            [DllImport(Libraries.Base, EntryPoint = "get_last_result")]
            internal static extern int GetLastResult();

            [DllImport(Libraries.Base, EntryPoint = "get_error_message")]
            internal static extern IntPtr GetErrorMessage(int errorCode);
        }
    }
}
