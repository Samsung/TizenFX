using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(CoreUI.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_spinner_add(IntPtr spinner, IntPtr surface);

        [DllImport(CoreUI.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_spinner_angle_set(IntPtr spinner, double angle);
    }
}