using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [LibraryImport(Libraries.Elementary, EntryPoint = "elm_init", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void ElmInit(int argc, string[] argv);

        [LibraryImport(Libraries.Elementary, EntryPoint = "elm_config_accel_preference_set", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr ElmConfigAccelPreferenceSet(string preference);

        [LibraryImport(Libraries.Elementary, EntryPoint = "elm_run", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void ElmRun();

        [LibraryImport(Libraries.Elementary, EntryPoint = "elm_exit", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void ElmExit();

        [LibraryImport(Libraries.Elementary, EntryPoint = "elm_shutdown", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void ElmShutdown();
    }
}



