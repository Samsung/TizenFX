using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        public enum EextCallbackType
        {
            EEXT_CALLBACK_BACK, // H/W Back Key Event
            EEXT_CALLBACK_MORE,  // H/W More Key Event
        }
        internal delegate void EextEventCallback(IntPtr data, IntPtr obj, IntPtr info);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_object_event_callback_add(IntPtr obj, EextCallbackType type, EextEventCallback callback, IntPtr data);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_object_event_callback_del(IntPtr obj, EextCallbackType type, EextEventCallback callback);
    }
}
