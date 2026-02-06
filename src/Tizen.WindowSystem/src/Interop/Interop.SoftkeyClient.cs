using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class SoftkeyClient
        {
            const string lib = "libtzsh_softkey.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_create")]
            internal static extern SafeHandles.SoftkeyClientHandle Create(SafeHandles.TizenShellHandle tzsh, uint win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_destroy")]
            internal static extern int Destroy(IntPtr softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_show")]
            internal static extern int Show(SafeHandles.SoftkeyClientHandle softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_hide")]
            internal static extern int Hide(SafeHandles.SoftkeyClientHandle softkeyClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_visible_state_get")]
            internal static extern int GetVisibleState(SafeHandles.SoftkeyClientHandle softkeyClient, out int visible);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_expand_state_set")]
            internal static extern int SetExpandState(SafeHandles.SoftkeyClientHandle softkeyClient, SoftkeyExpandMode expand);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_expand_state_get")]
            internal static extern int GetExpandState(SafeHandles.SoftkeyClientHandle softkeyClient, out int expand);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_opacity_state_set")]
            internal static extern int SetOpacityState(SafeHandles.SoftkeyClientHandle softkeyClient, SoftkeyOpacity opacity);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_softkey_global_opacity_state_get")]
            internal static extern int GetOpacityState(SafeHandles.SoftkeyClientHandle softkeyClient, out int opacity);
        }
    }
}
