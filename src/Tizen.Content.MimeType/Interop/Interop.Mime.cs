using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Mime
    {
        [DllImport(Libraries.Mime, EntryPoint = "mime_type_get_mime_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMime(
            [System.Runtime.InteropServices.InAttribute()]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_extension
            , out string mime_type);

        [DllImport(Libraries.Mime, EntryPoint = "mime_type_get_file_extension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFile(
            [System.Runtime.InteropServices.InAttribute()]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string mime_type
            , out System.IntPtr file_extension, out int length);
    }
}