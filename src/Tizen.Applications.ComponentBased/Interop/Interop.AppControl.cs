using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class AppControl
    {
        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_caller_instance_compId")]
        internal static extern int SetCallerInstanceId(SafeAppControlHandle appControl, string instanceId);
    }
}
