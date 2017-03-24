using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class EvasObject
        {
            [DllImport("libevas.so.1")]
            internal static extern IntPtr evas_object_image_add(IntPtr parent);
            [DllImport("libevas.so.1")]
            internal static extern IntPtr evas_object_evas_get(IntPtr obj);
            [DllImport("libevas.so.1")]
            internal static extern void evas_object_show(IntPtr obj);
        }
    }
}