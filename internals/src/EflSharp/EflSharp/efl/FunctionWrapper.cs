using System;
using System.Runtime.InteropServices;

namespace Efl
{

namespace Eo
{

///<summary>Class to load functions pointers from a native module.
///
///This class has a platform-dependent implementation on whether it
///is compiled for Windows (using LoadLibrary/GetProcAddress) or Unix
///(dlopen/dlsym).</summary>
public partial class FunctionInterop
{
    ///<summary>Loads a function pointer from the given module.</summary>
    ///<param name="moduleName">The name of the module containing the function.</param>
    ///<param name="functionName">The name of the function to search for.</param>
    ///<returns>A function pointer that can be used with delegates.</returns>
    public static IntPtr LoadFunctionPointer(string moduleName, string functionName)
    {
        NativeModule module = new NativeModule(moduleName);
        Eina.Log.Debug($"searching {module.Module} for {functionName}");
        var s = FunctionInterop.dlsym(module.Module, functionName);
        Eina.Log.Debug($"searching {module.Module} for{functionName}, result {s}");
        return s;
    }

    ///<summary>Loads a function pointer from the default module.</summary>
    ///<param name="functionName">The name of the function to search for.</param>
    ///<returns>A function pointer that can be used with delegates.</returns>
    public static IntPtr LoadFunctionPointer(string functionName)
    {
        Eina.Log.Debug($"searching {null} for {functionName}");
        var s = FunctionInterop.dlsym(IntPtr.Zero, functionName);
        Eina.Log.Debug($"searching {null} for {functionName}, result {s}");
        return s;
    }
}

///<summary>Wraps a native function in a portable manner.
///
///This is intended as a workaround DllImport limitations when switching between mono and dotnet.
///
///The parameter T must be a delegate.
///</summary>
public class FunctionWrapper<T> // NOTE: When supporting C# >=7.3, add a where T: System.Delegate?
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

    ///<summary>Creates a wrapper for the given function of the given module.</summary>
    ///<param name="moduleName">The name of the module containing the function.</param>
    ///<param name="functionName">The name of the function to search for.</param>
    public FunctionWrapper(string moduleName, string functionName)
        : this(new NativeModule(moduleName), functionName)
    {
    }

    ///<summary>Creates a wrapper for the given function of the given module.</summary>
    ///<param name="module">The module wrapper containing the function.</param>
    ///<param name="functionName">The name of the function to search for.</param>
    public FunctionWrapper(NativeModule module, string functionName)
    {
        this.module = module;
        loadResult = new Lazy<FunctionLoadResult<T>>
            (() =>
            {
                return LazyInitialization(module, functionName);
            });
    }

    ///<summary>Retrieves the result of function load.</summary>
    ///<returns>The load result.</returns>
    public FunctionLoadResult<T> Value
    {
        get
        {
            return loadResult.Value;
        }
    }
}

///<summary>The outcome of the function load process.</summary>
public enum FunctionLoadResultKind
{
    ///<summary>Function was loaded successfully.</summary>
    Success,
    ///<summary>Library was not found.</summary>
    LibraryNotFound,
    ///<summary>Function symbol was not found in the given module.</summary>
    FunctionNotFound
}

///<summary>Represents the result of loading a function pointer.</summary>
public class FunctionLoadResult<T>
{
    ///<summary>The status of the load.</summary>
    public FunctionLoadResultKind Kind;
    private T _Delegate;

    ///<summary>The delegate wrapping the loaded function pointer.
    ///
    ///Throws InvalidOperationException if trying to access while not loaded.</summary>
    public T Delegate
    {
        get
        {
            if (_Delegate == null)
            {
                throw new InvalidOperationException($"Trying to get Delegate while not loaded. Load result: {Kind}");
            }

            return _Delegate;
        }
    }

    ///<summary>Creates a new load result of the given kind.</summary>
    ///<param name="kind">The outcome of the load process.</param>
    public FunctionLoadResult(FunctionLoadResultKind kind)
    {
        this.Kind = kind;
    }

    ///<summary>Creates a new load result with the given delegate.</summary>
    ///<param name="Delegate">The delegate wrapping the native function.</param>
    public FunctionLoadResult(T Delegate)
    {
        this._Delegate = Delegate;
        this.Kind = FunctionLoadResultKind.Success;
    }
}

}

}
