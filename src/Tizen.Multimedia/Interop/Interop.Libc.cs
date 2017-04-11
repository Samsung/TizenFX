using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class Libc
        {
            internal static class AccessMode
            {
                internal const int W_OK = 0x02;
                internal const int R_OK = 0x04;
            }

            [DllImport(Libraries.Libc, EntryPoint = "free")]
            public static extern void Free(IntPtr ptr);



            [DllImport(Libraries.Libc, EntryPoint = "access")]
            public static extern int Access(string path, int mode);
        }
    }
}