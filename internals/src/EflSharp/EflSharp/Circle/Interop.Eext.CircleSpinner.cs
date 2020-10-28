using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_spinner_add(IntPtr spinner, IntPtr surface);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_spinner_angle_set(IntPtr spinner, double angle);
    }
}