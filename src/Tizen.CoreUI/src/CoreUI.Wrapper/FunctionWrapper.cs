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

/// <summary>Class to load functions pointers from a native module.
///
/// <para>This class has a platform-dependent implementation on whether it
/// is compiled for Windows (using LoadLibrary/GetProcAddress) or Unix
/// (dlopen/dlsym).</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
internal static partial class FunctionInterop
{
    /// <summary>Loads a function pointer from the given module.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="moduleName">The name of the module containing the function.</param>
    /// <param name="functionName">The name of the function to search for.</param>
    /// <returns>A function pointer that can be used with delegates.</returns>
    internal static IntPtr LoadFunctionPointer(string moduleName, string functionName)
    {
        IntPtr module = NativeModule.LoadLibrary(moduleName);
        CoreUI.DataTypes.Log.Debug($"searching {module} for {functionName}");
        var s = FunctionInterop.dlsym(module, functionName);
        CoreUI.DataTypes.Log.Debug($"searching {module} for{functionName}, result {s}");
        return s;
    }

    /// <summary>Loads a function pointer from the default module.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="functionName">The name of the function to search for.</param>
    /// <returns>A function pointer that can be used with delegates.</returns>
    internal static IntPtr LoadFunctionPointer(string functionName)
    {
        CoreUI.DataTypes.Log.Debug($"searching {null} for {functionName}");
        var s = FunctionInterop.dlsym(IntPtr.Zero, functionName);
        CoreUI.DataTypes.Log.Debug($"searching {null} for {functionName}, result {s}");
        return s;
    }
}

/// <summary>Wraps a native function in a portable manner.
///
/// <para>This is intended as a workaround DllImport limitations when switching between mono and dotnet.</para>
/// <para>The parameter T must be a delegate.</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
class FunctionWrapper<T> // NOTE: When supporting C# >=7.3, add a where T: System.Delegate?
{
    private Lazy<FunctionLoadResult<T>> loadResult;
#pragma warning disable 0414
    private NativeModule module; // so it doesn't get unloaded
#pragma warning restore 0414

    private static FunctionLoadResult<T> LazyInitialization(NativeModule module, string functionName)
    {
        if (module.Module == IntPtr.Zero)
        {
            return new FunctionLoadResult<T>(FunctionLoadResultKind.LibraryNotFound);
        }
        else
        {
            IntPtr funcptr = FunctionInterop.LoadFunctionPointer(module.Module, functionName);
            if (funcptr == IntPtr.Zero)
            {
                return new FunctionLoadResult<T>(FunctionLoadResultKind.FunctionNotFound);
            }
            else
            {
                return new FunctionLoadResult<T>(Marshal.GetDelegateForFunctionPointer<T>(funcptr));
            }
        }
    }

    /// <summary>Creates a wrapper for the given function of the given module.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="moduleName">The name of the module containing the function.</param>
    /// <param name="functionName">The name of the function to search for.</param>
    internal FunctionWrapper(string moduleName, string functionName)
        : this(new NativeModule(moduleName), functionName)
    {
    }

    /// <summary>Creates a wrapper for the given function of the given module.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="module">The module wrapper containing the function.</param>
    /// <param name="functionName">The name of the function to search for.</param>
    internal FunctionWrapper(NativeModule module, string functionName)
    {
        this.module = module;
        loadResult = new Lazy<FunctionLoadResult<T>>
            (() =>
            {
                return LazyInitialization(module, functionName);
            });
    }

    /// <summary>Retrieves the result of function load.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The load result.</returns>
    internal FunctionLoadResult<T> Value
    {
        get
        {
            return loadResult.Value;
        }
    }
}

/// <summary>The outcome of the function load process.
/// </summary>
/// <since_tizen> 6 </since_tizen>
enum FunctionLoadResultKind
{
    ///<summary>Function was loaded successfully.</summary>
    /// <since_tizen> 6 </since_tizen>
    Success,
    ///<summary>Library was not found.</summary>
    /// <since_tizen> 6 </since_tizen>
    LibraryNotFound,
    ///<summary>Function symbol was not found in the given module.</summary>
    /// <since_tizen> 6 </since_tizen>
    FunctionNotFound
}

/// <summary>Represents the result of loading a function pointer.
/// </summary>
/// <since_tizen> 6 </since_tizen>
class FunctionLoadResult<T>
{
    /// <summary>The status of the load.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    FunctionLoadResultKind Kind;
    private T _Delegate;

    /// <summary>The delegate wrapping the loaded function pointer.
    ///
    /// <para>Throws InvalidOperationException if trying to access while not loaded.</para>
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The <c>delegate</c> wrapping the native function.</value>
    internal T Delegate
    {
        get
        {
            if (_Delegate == null)
            {
                throw new InvalidOperationException($"Trying to get Delegate of type {typeof(T).FullName} while not loaded. Load result: {Kind}");
            }

            return _Delegate;
        }
    }

    /// <summary>Creates a new load result of the given kind.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="kind">The outcome of the load process.</param>
    internal FunctionLoadResult(FunctionLoadResultKind kind)
    {
        this.Kind = kind;
    }

    /// <summary>Creates a new load result with the given delegate.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="Delegate">The delegate wrapping the native function.</param>
    internal FunctionLoadResult(T Delegate)
    {
        this._Delegate = Delegate;
        this.Kind = FunctionLoadResultKind.Success;
    }
}

}
