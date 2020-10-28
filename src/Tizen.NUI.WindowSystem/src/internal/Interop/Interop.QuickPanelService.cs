using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class QuickPanelService
        {
            const string lib = "libtzsh_quickpanel_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_create_with_type")]
            internal static extern IntPtr CreateWithType(IntPtr tzsh, IntPtr win, int type);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_destroy")]
            internal static extern int Destroy(IntPtr service);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_type_get")]
            internal static extern int GetType(IntPtr service, out int type);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_show")]
            internal static extern int Show(IntPtr service);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_hide")]
            internal static extern int Hide(IntPtr service);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_content_region_set")]
            internal static extern int SetContentRegion(IntPtr service, uint angle, IntPtr region);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_handler_region_set")]
            internal static extern int SetHandlerRegion(IntPtr service, uint angle, IntPtr region);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_effect_type_set")]
            internal static extern int SetEffectType(IntPtr service, int type);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_quickpanel_service_scroll_lock")]
            internal static extern int LockScroll(IntPtr service, bool locked);
        }
    }
}
