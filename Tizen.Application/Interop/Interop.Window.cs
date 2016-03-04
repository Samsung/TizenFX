using System;
using System.Runtime.InteropServices;

internal static partial class Interop {
    internal static partial class Window {
        [DllImport(Libraries.Elementary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr elm_win_add(IntPtr parent, string name, int type);

        [DllImport(Libraries.Evas, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void evas_object_show(IntPtr obj);

        [DllImport(Libraries.Evas, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void evas_object_hide(IntPtr obj);

        [DllImport(Libraries.Evas, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool evas_object_visible_get(IntPtr obj);

        [DllImport(Libraries.Evas, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void evas_object_unref(IntPtr obj);

        [DllImport(Libraries.Elementary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void elm_win_activate(IntPtr obj);

        [DllImport(Libraries.Elementary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void elm_win_lower(IntPtr obj);
    }
}
