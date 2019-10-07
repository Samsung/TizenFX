using System;
using System.Runtime.InteropServices;

namespace UIKit
{

namespace Wrapper
{

public partial class FunctionInterop
{
    [DllImport(UIKit.Libs.Libdl)]
    private static extern IntPtr dlsym(IntPtr handle, string symbol);

    ///<summary>Loads a function pointer from the given module.</summary>
    ///<param name="nativeLibraryHandle">The module containing the function.</param>
    ///<param name="functionName">The name of the function to search for.</param>
    ///<returns>A function pointer that can be used with delegates.</returns>
    public static IntPtr LoadFunctionPointer(IntPtr nativeLibraryHandle, string functionName)
    {
        UIKit.DataTypes.Log.Debug($"searching {nativeLibraryHandle} for {functionName}");
        var s = FunctionInterop.dlsym(nativeLibraryHandle, functionName);
        UIKit.DataTypes.Log.Debug($"searching {nativeLibraryHandle} for {functionName}, result {s}");
        return s;
    }
}

}

}
