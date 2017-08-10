
using System;

namespace Tizen.Multimedia
{
    internal static class LibcSupport
    {
        internal static void Free(IntPtr ptr)
        {
            Interop.Libc.Free(ptr);
        }
    }
}
