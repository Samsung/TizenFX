#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="kw_event">Event struct with an <see cref="Efl.LoopHandler"/> as payload.</param>
[Efl.Eo.BindingEntity]
public delegate void EflThreadIOCall(Efl.Event kw_event);
public delegate void EflThreadIOCallInternal(IntPtr data,  Efl.Event.NativeStruct kw_event);
internal class EflThreadIOCallWrapper : IDisposable
{

    private EflThreadIOCallInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflThreadIOCallWrapper (EflThreadIOCallInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflThreadIOCallWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal void ManagedCb(Efl.Event kw_event)
    {
_cb(_cb_data, kw_event);
Eina.Error.RaiseIfUnhandledException();
        
    }

        internal static void Cb(IntPtr cb_data,  Efl.Event.NativeStruct kw_event)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflThreadIOCall cb = (EflThreadIOCall)handle.Target;
        try {
            cb(kw_event);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
            }
}


/// <param name="kw_event">Event struct with an <see cref="Efl.LoopHandler"/> as payload.</param>
/// <returns>Data that the function executed on the other thread returned.</returns>
[Efl.Eo.BindingEntity]
public delegate System.IntPtr EflThreadIOCallSync(Efl.Event kw_event);
public delegate System.IntPtr EflThreadIOCallSyncInternal(IntPtr data,  Efl.Event.NativeStruct kw_event);
internal class EflThreadIOCallSyncWrapper : IDisposable
{

    private EflThreadIOCallSyncInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EflThreadIOCallSyncWrapper (EflThreadIOCallSyncInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EflThreadIOCallSyncWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal System.IntPtr ManagedCb(Efl.Event kw_event)
    {
var _ret_var = _cb(_cb_data, kw_event);
Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

        internal static System.IntPtr Cb(IntPtr cb_data,  Efl.Event.NativeStruct kw_event)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EflThreadIOCallSync cb = (EflThreadIOCallSync)handle.Target;
System.IntPtr _ret_var = default(System.IntPtr);        try {
            _ret_var = cb(kw_event);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}


namespace Efl {

/// <summary>This mixin defines input and output pointers to allow exchanging data with another thread. It also defines a mechanism to call methods on that thread.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.ThreadIOConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IThreadIO : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Input data pointer for the thread.</summary>
    /// <returns>Data pointer.</returns>
    System.IntPtr GetIndata();

    /// <summary>Input data pointer for the thread.</summary>
    /// <param name="data">Data pointer.</param>
    void SetIndata(System.IntPtr data);

    /// <summary>Output data pointer for the thread.</summary>
    /// <returns>Data pointer.</returns>
    System.IntPtr GetOutdata();

    /// <summary>Output data pointer for the thread.</summary>
    /// <param name="data">Data pointer.</param>
    void SetOutdata(System.IntPtr data);

    /// <summary>Executes a method on a different thread, asynchronously.</summary>
    /// <param name="func">The method to execute asynchronously.</param>
    void Call(EflThreadIOCall func);

    /// <summary>Executes a method on a different thread, synchronously. This call will not return until the method finishes and its return value can be recovered.</summary>
    /// <param name="func">The method to execute synchronously.</param>
    /// <returns>The return value from the method.</returns>
    System.IntPtr SyncCall(EflThreadIOCallSync func);

    /// <summary>Input data pointer for the thread.</summary>
    /// <value>Data pointer.</value>
    System.IntPtr Indata {
        get;
        set;
    }

    /// <summary>Output data pointer for the thread.</summary>
    /// <value>Data pointer.</value>
    System.IntPtr Outdata {
        get;
        set;
    }

}

/// <summary>This mixin defines input and output pointers to allow exchanging data with another thread. It also defines a mechanism to call methods on that thread.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ThreadIOConcrete :
    Efl.Eo.EoWrapper
    , IThreadIO
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ThreadIOConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ThreadIOConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_threadio_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IThreadIO"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ThreadIOConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Input data pointer for the thread.</summary>
    /// <returns>Data pointer.</returns>
    public System.IntPtr GetIndata() {
        var _ret_var = Efl.ThreadIOConcrete.NativeMethods.efl_threadio_indata_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Input data pointer for the thread.</summary>
    /// <param name="data">Data pointer.</param>
    public void SetIndata(System.IntPtr data) {
        Efl.ThreadIOConcrete.NativeMethods.efl_threadio_indata_set_ptr.Value.Delegate(this.NativeHandle,data);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Output data pointer for the thread.</summary>
    /// <returns>Data pointer.</returns>
    public System.IntPtr GetOutdata() {
        var _ret_var = Efl.ThreadIOConcrete.NativeMethods.efl_threadio_outdata_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Output data pointer for the thread.</summary>
    /// <param name="data">Data pointer.</param>
    public void SetOutdata(System.IntPtr data) {
        Efl.ThreadIOConcrete.NativeMethods.efl_threadio_outdata_set_ptr.Value.Delegate(this.NativeHandle,data);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Executes a method on a different thread, asynchronously.</summary>
    /// <param name="func">The method to execute asynchronously.</param>
    public void Call(EflThreadIOCall func) {
        GCHandle func_handle = GCHandle.Alloc(func);
Efl.ThreadIOConcrete.NativeMethods.efl_threadio_call_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), EflThreadIOCallWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Executes a method on a different thread, synchronously. This call will not return until the method finishes and its return value can be recovered.</summary>
    /// <param name="func">The method to execute synchronously.</param>
    /// <returns>The return value from the method.</returns>
    public System.IntPtr SyncCall(EflThreadIOCallSync func) {
        GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = Efl.ThreadIOConcrete.NativeMethods.efl_threadio_call_sync_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), EflThreadIOCallSyncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Input data pointer for the thread.</summary>
    /// <value>Data pointer.</value>
    public System.IntPtr Indata {
        get { return GetIndata(); }
        set { SetIndata(value); }
    }

    /// <summary>Output data pointer for the thread.</summary>
    /// <value>Data pointer.</value>
    public System.IntPtr Outdata {
        get { return GetOutdata(); }
        set { SetOutdata(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ThreadIOConcrete.efl_threadio_mixin_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_threadio_indata_get_static_delegate == null)
            {
                efl_threadio_indata_get_static_delegate = new efl_threadio_indata_get_delegate(indata_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_indata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_get_static_delegate) });
            }

            if (efl_threadio_indata_set_static_delegate == null)
            {
                efl_threadio_indata_set_static_delegate = new efl_threadio_indata_set_delegate(indata_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIndata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_indata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_set_static_delegate) });
            }

            if (efl_threadio_outdata_get_static_delegate == null)
            {
                efl_threadio_outdata_get_static_delegate = new efl_threadio_outdata_get_delegate(outdata_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOutdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_outdata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_get_static_delegate) });
            }

            if (efl_threadio_outdata_set_static_delegate == null)
            {
                efl_threadio_outdata_set_static_delegate = new efl_threadio_outdata_set_delegate(outdata_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOutdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_outdata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_set_static_delegate) });
            }

            if (efl_threadio_call_static_delegate == null)
            {
                efl_threadio_call_static_delegate = new efl_threadio_call_delegate(call);
            }

            if (methods.FirstOrDefault(m => m.Name == "Call") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_call"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_static_delegate) });
            }

            if (efl_threadio_call_sync_static_delegate == null)
            {
                efl_threadio_call_sync_static_delegate = new efl_threadio_call_sync_delegate(call_sync);
            }

            if (methods.FirstOrDefault(m => m.Name == "SyncCall") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_call_sync"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_sync_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.ThreadIOConcrete.efl_threadio_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_threadio_indata_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_threadio_indata_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_threadio_indata_get_api_delegate> efl_threadio_indata_get_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_indata_get_api_delegate>(Module, "efl_threadio_indata_get");

        private static System.IntPtr indata_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_threadio_indata_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((IThreadIO)ws.Target).GetIndata();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_threadio_indata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_threadio_indata_get_delegate efl_threadio_indata_get_static_delegate;

        
        private delegate void efl_threadio_indata_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data);

        
        public delegate void efl_threadio_indata_set_api_delegate(System.IntPtr obj,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_threadio_indata_set_api_delegate> efl_threadio_indata_set_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_indata_set_api_delegate>(Module, "efl_threadio_indata_set");

        private static void indata_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_threadio_indata_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IThreadIO)ws.Target).SetIndata(data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_threadio_indata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data);
            }
        }

        private static efl_threadio_indata_set_delegate efl_threadio_indata_set_static_delegate;

        
        private delegate System.IntPtr efl_threadio_outdata_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_threadio_outdata_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_threadio_outdata_get_api_delegate> efl_threadio_outdata_get_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_outdata_get_api_delegate>(Module, "efl_threadio_outdata_get");

        private static System.IntPtr outdata_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_threadio_outdata_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((IThreadIO)ws.Target).GetOutdata();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_threadio_outdata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_threadio_outdata_get_delegate efl_threadio_outdata_get_static_delegate;

        
        private delegate void efl_threadio_outdata_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data);

        
        public delegate void efl_threadio_outdata_set_api_delegate(System.IntPtr obj,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_threadio_outdata_set_api_delegate> efl_threadio_outdata_set_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_outdata_set_api_delegate>(Module, "efl_threadio_outdata_set");

        private static void outdata_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_threadio_outdata_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IThreadIO)ws.Target).SetOutdata(data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_threadio_outdata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data);
            }
        }

        private static efl_threadio_outdata_set_delegate efl_threadio_outdata_set_static_delegate;

        
        private delegate void efl_threadio_call_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EflThreadIOCallInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_threadio_call_api_delegate(System.IntPtr obj,  IntPtr func_data, EflThreadIOCallInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate> efl_threadio_call_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate>(Module, "efl_threadio_call");

        private static void call(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EflThreadIOCallInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    EflThreadIOCallWrapper func_wrapper = new EflThreadIOCallWrapper(func, func_data, func_free_cb);

                try
                {
                    ((IThreadIO)ws.Target).Call(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_threadio_call_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_threadio_call_delegate efl_threadio_call_static_delegate;

        
        private delegate System.IntPtr efl_threadio_call_sync_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EflThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        
        public delegate System.IntPtr efl_threadio_call_sync_api_delegate(System.IntPtr obj,  IntPtr func_data, EflThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate> efl_threadio_call_sync_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate>(Module, "efl_threadio_call_sync");

        private static System.IntPtr call_sync(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EflThreadIOCallSyncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call_sync was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    EflThreadIOCallSyncWrapper func_wrapper = new EflThreadIOCallSyncWrapper(func, func_data, func_free_cb);
System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((IThreadIO)ws.Target).SyncCall(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_threadio_call_sync_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_threadio_call_sync_delegate efl_threadio_call_sync_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflThreadIOConcrete_ExtensionMethods {
    public static Efl.BindableProperty<System.IntPtr> Indata<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IThreadIO, T>magic = null) where T : Efl.IThreadIO {
        return new Efl.BindableProperty<System.IntPtr>("indata", fac);
    }

    public static Efl.BindableProperty<System.IntPtr> Outdata<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IThreadIO, T>magic = null) where T : Efl.IThreadIO {
        return new Efl.BindableProperty<System.IntPtr>("outdata", fac);
    }

}
#pragma warning restore CS1591
#endif
