using System;
using System.Runtime.InteropServices;

namespace Efl { namespace Eo {

public partial class FunctionInterop
{
    public static IntPtr LoadFunctionPointer(string moduleName, string functionName)
    {
        NativeModule module = new NativeModule(moduleName);
        Eina.Log.Debug($"searching {module.Module} for {functionName}");
        var s = FunctionInterop.dlsym(module.Module, functionName);
        Eina.Log.Debug($"searching {module.Module} for{functionName}, result {s}");
        return s;
    }
    public static IntPtr LoadFunctionPointer(string functionName)
    {
        Eina.Log.Debug($"searching {null} for {functionName}");
        var s = FunctionInterop.dlsym(IntPtr.Zero, functionName);
        Eina.Log.Debug($"searching {null} for {functionName}, result {s}");
        return s;
    }
}
        
public class FunctionWrapper<T>
{
    private Lazy<FunctionLoadResult<T>> loadResult;
    private NativeModule module; // so it doesn't get unloaded

    private static FunctionLoadResult<T> LazyInitialization(NativeModule module, string functionName)
    {
        if (module.Module == IntPtr.Zero)
            return new FunctionLoadResult<T>(FunctionLoadResultKind.LibraryNotFound);
        else
        {
            IntPtr funcptr = FunctionInterop.LoadFunctionPointer(module.Module, functionName);
            if (funcptr == IntPtr.Zero)
                return new FunctionLoadResult<T>(FunctionLoadResultKind.FunctionNotFound);
            else
                return new FunctionLoadResult<T>(Marshal.GetDelegateForFunctionPointer<T>(funcptr));
        }
    }
    
    public FunctionWrapper(string moduleName, string functionName)
        : this (new NativeModule(moduleName), functionName)
    {
    }
    
    public FunctionWrapper(NativeModule module, string functionName)
    {
        this.module = module;
        loadResult = new Lazy<FunctionLoadResult<T>>
            (() =>
            {
                return LazyInitialization(module, functionName);
            });
    }

    public FunctionLoadResult<T> Value
    {
        get
        {
            return loadResult.Value;
        }
    }
}

public enum FunctionLoadResultKind { Success, LibraryNotFound, FunctionNotFound }
    
public class FunctionLoadResult<T>
{
    public FunctionLoadResultKind Kind;
    public T _Delegate;
    public T Delegate
    {
        get {
            if (_Delegate == null)
                throw new InvalidOperationException($"Trying to get Delegate while not loaded. Load result: {Kind}");
            return _Delegate;
        }
    }

    public FunctionLoadResult(FunctionLoadResultKind kind)
    {
        this.Kind = kind;
    }
    public FunctionLoadResult(T Delegate)
    {
        this._Delegate = Delegate;
        this.Kind = FunctionLoadResultKind.Success;
    }
}


} }
