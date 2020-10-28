#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;


namespace Eina
{

public class Stringshare
{
    [DllImport(efl.Libs.Eina)] public static extern System.IntPtr
        eina_stringshare_add_length(string str, System.UInt32 slen);
    [DllImport(efl.Libs.Eina)] public static extern System.IntPtr
        eina_stringshare_add(string str);
    [DllImport(efl.Libs.Eina)] public static extern void
        eina_stringshare_del(System.IntPtr str);
}

}
