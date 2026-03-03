using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class TizenShell
        {
            const string lib = "libtzsh_common.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_create")]
            internal static extern IntPtr Create(int type);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_destroy")]
            internal static extern int Destroy(IntPtr tzsh);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_event_type_new")]
            internal static extern int NewEventType(IntPtr tzsh, string name);

            internal enum ToolKitType
            {
                Unknown = 0,
                Efl = 1,
            }

            private const int ErrorTzsh = -0x02860000;

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            /* Successful */
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              /* Out of memory */
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    /* Invalid parameter */
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    /* Permission denied */
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            /* NOT supported */
                NoService = ErrorTzsh | 0x01,                                            /* Service does not exist */
            }
        }
    }
}
