using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Evas
    {
        public delegate void SmartCallback(IntPtr data, IntPtr obj, IntPtr info);

        [DllImport(CoreUI.Libs.Evas)]
        internal static extern void evas_object_smart_callback_add(IntPtr obj, string eventName, SmartCallback func, IntPtr data);

        [DllImport(CoreUI.Libs.Evas)]
        internal static extern void evas_object_smart_callback_del(IntPtr obj, string eventName, SmartCallback func);
    }
}
