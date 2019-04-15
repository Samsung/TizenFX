using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{

    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_surface_conformant_add(IntPtr conformant);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_surface_layout_add(IntPtr layout);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_surface_naviframe_add(IntPtr naviframe);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_surface_del(IntPtr surface);
    }
}