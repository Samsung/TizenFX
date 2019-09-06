using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary, EntryPoint = "elm_init")]
        internal static extern void ElmInit(int argc, string[] argv);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_config_accel_preference_set")]
        internal static extern IntPtr ElmConfigAccelPreferenceSet(string preference);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_run")]
        internal static extern void ElmRun();

        [DllImport(Libraries.Elementary, EntryPoint = "elm_exit")]
        internal static extern void ElmExit();

        [DllImport(Libraries.Elementary, EntryPoint = "elm_shutdown")]
        internal static extern void ElmShutdown();
    }
}
