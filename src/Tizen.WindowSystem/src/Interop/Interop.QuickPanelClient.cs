using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class QuickPanelClient
        {
            const string lib = "libtzsh_quickpanel.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_create_with_type")]
            internal static extern SafeHandles.QuickPanelClientHandle CreateWithType(SafeHandles.TizenShellHandle tzsh, uint win, QuickPanelCategory type);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_destroy")]
            internal static extern int Destroy(IntPtr qpClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_visible_get")]
            internal static extern int GetVisible(SafeHandles.QuickPanelClientHandle qpClient, out int vis);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_scrollable_state_get")]
            internal static extern int GetScrollableState(SafeHandles.QuickPanelClientHandle qpClient, out int scroll);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_scrollable_state_set")]
            internal static extern int SetScrollableState(SafeHandles.QuickPanelClientHandle qpClient, QuickPanelScrollMode scroll);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_orientation_get")]
            internal static extern int GetOrientation(SafeHandles.QuickPanelClientHandle qpClient, out int orientation);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_show")]
            internal static extern int Show(SafeHandles.QuickPanelClientHandle qpClient);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_hide")]
            internal static extern int Hide(SafeHandles.QuickPanelClientHandle qpClient);

            internal delegate void QuickPanelEventCallback(int type, IntPtr ev_info, IntPtr data);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_event_handler_add")]
            internal static extern IntPtr AddEventHandler(SafeHandles.QuickPanelClientHandle qpClient, int type, QuickPanelEventCallback func, IntPtr data);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_event_handler_del")]
            internal static extern int DelEventHandler(SafeHandles.QuickPanelClientHandle qpClient, IntPtr eventHandler);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_event_visible_get")]
            internal static extern int GetEventVisible(IntPtr ev_info, out int state);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_event_orientation_get")]
            internal static extern int GetEventOrientation(IntPtr ev_info, out int state);

            internal const string EventStringVisible = "tzsh_quickpanel_event_visible";
            internal const string EventStringOrientation = "tzsh_quickpanel_event_orientation";
        }
    }
}
