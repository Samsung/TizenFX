using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_slider_add(IntPtr parent, IntPtr surface);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_slider_step_set(IntPtr obj, double value);

        [DllImport(efl.Libs.Eext)]
        internal static extern double eext_circle_object_slider_step_get(IntPtr obj);
    }
}