using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

internal static partial class Interop
{
    internal static partial class EflCBApplication
    {
        [DllImport(Libraries.CompApplication, EntryPoint = "frame_component_get_resource_id")]
        internal static extern int GetResourceId(IntPtr win, out int resId);
    }
}
