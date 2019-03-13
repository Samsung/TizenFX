using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_scroller_add(IntPtr scroller, IntPtr surface);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_scroller_policy_set(IntPtr obj, int policy_h, int policy_v);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_scroller_policy_get(IntPtr obj, IntPtr policy_h, IntPtr policy_v);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_scroller_policy_get(IntPtr obj, out int policy_h, IntPtr policy_v);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_scroller_policy_get(IntPtr obj, IntPtr policy_h, out int policy_v);
    }
}