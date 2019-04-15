using System;
using System.Runtime.InteropServices;

namespace Efl
{

namespace Eo
{

public partial class NativeModule
{
    private const int RTLD_NOW = 0x002;
    // Currently we are using GLOBAL due to issues
    // with the way evas modules are built.
    private const int RTLD_GLOBAL = 0x100;

    [DllImport(efl.Libs.Libdl)]
    private static extern IntPtr dlopen(string fileName, int flag);
    [DllImport(efl.Libs.Libdl)]
    private static extern int dlclose(IntPtr handle);

    ///<summary>Closes the library handle.</summary>
    ///<param name="handle">The handle to the library.</param>
    public static void UnloadLibrary(IntPtr handle)
    {
        dlclose(handle);
    }

    ///<summary>Loads the given library.
    ///
    ///It attempts to load using the following list of names based on the <c>filename</c>
    ///parameter:
    ///
    ///<list type="bullet">
    ///<item>
    ///<description><c>filename</c></description>
    ///</item>
    ///<item>
    ///<description><c>libfilename</c></description>
    ///</item>
    ///<item>
    ///<description><c>filename.so</c></description>
    ///</item>
    ///<item>
    ///<description><c>libfilename.so</c></description>
    ///</item>
    ///</list>
    ///</summary>
    ///<param name="filename">The name to search for.</param>
    ///<returns>The loaded library handle or <see cref="System.IntPtr.Zero"/> on failure.</returns>
    public static IntPtr LoadLibrary(string filename)
    {
        Eina.Log.Debug($"Loading library {filename}");
        var r = dlopen(filename, RTLD_NOW | RTLD_GLOBAL);
        if (r == IntPtr.Zero)
        {
            r = dlopen("lib" + filename, RTLD_NOW | RTLD_GLOBAL);
            if (r == IntPtr.Zero)
            {
                r = dlopen(filename + ".so", RTLD_NOW | RTLD_GLOBAL);
                if (r == IntPtr.Zero)
                {
                    r = dlopen("lib" + filename + ".so", RTLD_NOW | RTLD_GLOBAL);
                }
            }
        }

        return r;
    }
}

}

}
