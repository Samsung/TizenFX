using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class Libc
        {
            [DllImport(Libraries.Libc, EntryPoint = "free")]
            public static extern void Free(IntPtr ptr);
        }
    }
}