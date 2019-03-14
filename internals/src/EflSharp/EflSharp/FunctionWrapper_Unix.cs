using System;
using System.Runtime.InteropServices;

namespace Efl { namespace Eo {

public partial class FunctionInterop
{
    [DllImport(efl.Libs.Libdl)]
    public static extern IntPtr dlsym(IntPtr handle, string symbol);
        
    public static IntPtr LoadFunctionPointer(IntPtr nativeLibraryHandle, string functionName)
    {
        Eina.Log.Debug("searching {nativeLibraryHandle} for {functionName}");
        var s = FunctionInterop.dlsym(nativeLibraryHandle, functionName);
        Eina.Log.Debug("searching {nativeLibraryHandle} for {functionName}, result {s}");
        return s;
    }
}


} }
