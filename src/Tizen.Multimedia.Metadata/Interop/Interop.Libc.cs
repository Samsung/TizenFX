using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free")]
        public static extern void Free(IntPtr userData);
    }
}
