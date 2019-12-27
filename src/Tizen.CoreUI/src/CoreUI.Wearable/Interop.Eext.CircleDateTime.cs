using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(CoreUI.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_datetime_add(IntPtr datetime, IntPtr surface);
    }
}
