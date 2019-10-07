using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{

    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_circle_object_genlist_add(IntPtr genlist, IntPtr surface);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_genlist_scroller_policy_set(IntPtr circleGenlist, int policyHorisontal, int policyVertical);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_genlist_scroller_policy_get(IntPtr circleGenlist, out int policyHorisontal, out int policyVertical);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_genlist_scroller_policy_get(IntPtr circleGenlist, out int policyHorisontal, IntPtr policyVertical);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_circle_object_genlist_scroller_policy_get(IntPtr circleGenlist, IntPtr policyHorisontal, out int policyVertical);
    }
}
