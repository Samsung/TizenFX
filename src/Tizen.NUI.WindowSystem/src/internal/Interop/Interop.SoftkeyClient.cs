using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class SoftkeyClient
        {
            const string lib = "libtzsh_softkey.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_create")]
            internal static extern IntPtr Create(IntPtr tzsh, IntPtr win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_destroy")]
            internal static extern int Destroy(IntPtr softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_show")]
            internal static extern int Show(IntPtr softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_hide")]
            internal static extern int Hide(IntPtr softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_visible_state_get")]
            internal static extern int GetVisibleState(IntPtr softkeyClient, out int visible);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_expand_state_set")]
            internal static extern int SetExpandState(IntPtr softkeyClient, int expand);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_expand_state_get")]
            internal static extern int GetExpandState(IntPtr softkeyClient, out int expand);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_opacity_state_set")]
            internal static extern int SetOpacityState(IntPtr softkeyClient, int opacity);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_opacity_state_get")]
            internal static extern int GetOpacityState(IntPtr softkeyClient, out int opacity);

            internal enum VisibleState
            {
                Unknown = 0x0,
                Shown = 0x1,
                Hidden = 0x2,
            }

            internal enum ExpandState
            {
                Unknown = 0x0,
                On = 0x1,
                Off = 0x2,
            }

            internal enum OpacityState
            {
                Unknown = 0x0,
                Opaque = 0x1,
                Transparent = 0x2,
            }
        }
    }
}
