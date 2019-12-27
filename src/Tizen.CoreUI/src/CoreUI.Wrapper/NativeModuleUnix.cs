/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Runtime.InteropServices;

namespace CoreUI.Wrapper
{

internal partial class NativeModule
{
    private const int RTLD_NOW = 0x002;
    // Currently we are using GLOBAL due to issues
    // with the way evas modules are built.
    private const int RTLD_GLOBAL = 0x100;

    [DllImport(CoreUI.Libs.Libdl)]
    private static extern IntPtr dlopen(string fileName, int flag);
    [DllImport(CoreUI.Libs.Libdl)]
    private static extern int dlclose(IntPtr handle);

    ///<summary>Closes the library handle.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="handle">The handle to the library.</param>
    internal static void UnloadLibrary(IntPtr handle)
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
    /// <since_tizen> 6 </since_tizen>
    ///<param name="filename">The name to search for.</param>
    ///<returns>The loaded library handle or <see cref="System.IntPtr.Zero"/> on failure.</returns>
    internal static IntPtr LoadLibrary(string filename)
    {
        CoreUI.DataTypes.Log.Debug($"Loading library {filename}");
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
