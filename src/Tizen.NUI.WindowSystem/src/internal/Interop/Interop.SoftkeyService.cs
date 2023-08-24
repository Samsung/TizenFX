using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class SoftkeyService
        {
            const string lib = "libtzsh_softkey_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_create")]
            internal static extern IntPtr Create(IntPtr tzsh, IntPtr win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_destroy")]
            internal static extern int Destroy(IntPtr softkeyService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_show")]
            internal static extern int Show(IntPtr softkeyService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_hide")]
            internal static extern int Hide(IntPtr softkeyService);

            internal delegate void SoftkeyVisibleEventCallback(IntPtr data, IntPtr softkeyService, int visible);
            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_visible_request_cb_set")]
            internal static extern int SetVisibleEventHandler(IntPtr softkeyService, SoftkeyVisibleEventCallback func, IntPtr data);

            internal delegate void SoftkeyExpandEventCallback(IntPtr data, IntPtr softkeyService, int expand);
            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_expand_request_cb_set")]
            internal static extern int SetExpandEventHandler(IntPtr softkeyService, SoftkeyExpandEventCallback func, IntPtr data);

            internal delegate void SoftkeyOpacityEventCallback(IntPtr data, IntPtr softkeyService, int opacity);
            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_service_opacity_request_cb_set")]
            internal static extern int SetOpacityEventHandler(IntPtr softkeyService, SoftkeyOpacityEventCallback func, IntPtr data);

            internal enum VisibleState
            {
                Hide = 0x0,
                Show = 0x1,
            }

            internal enum ExpandState
            {
                Off = 0x0,
                On = 0x1,
            }

            internal enum OpacityState
            {
                Opaque = 0x0,
                Transparent = 0x1,
            }
        }
    }
}
