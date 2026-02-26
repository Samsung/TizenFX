using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

internal static partial class Interop
{
    internal static partial class EflCBApplication
    {
        [LibraryImport(Libraries.CompApplication, EntryPoint = "frame_component_get_resource_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetResourceId(IntPtr win, out int resId);
    }
}



