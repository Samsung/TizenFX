#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
/// <param name="kw_event">No description supplied.</param>
public delegate void EFlThreadIOCall(ref Efl.Event kw_event);
public delegate void EFlThreadIOCallInternal(IntPtr data,  ref Efl.Event.NativeStruct kw_event);
internal class EFlThreadIOCallWrapper : IDisposable
{

    private EFlThreadIOCallInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EFlThreadIOCallWrapper (EFlThreadIOCallInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EFlThreadIOCallWrapper()
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

    internal void ManagedCb(ref Efl.Event kw_event)
    {
        Efl.Event.NativeStruct _in_kw_event = kw_event;
                        _cb(_cb_data, ref _in_kw_event);
        Eina.Error.RaiseIfUnhandledException();
                kw_event = _in_kw_event;
            }

        internal static void Cb(IntPtr cb_data,  ref Efl.Event.NativeStruct kw_event)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EFlThreadIOCall cb = (EFlThreadIOCall)handle.Target;
        Efl.Event _in_kw_event = kw_event;
                            
        try {
            cb(ref _in_kw_event);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                kw_event = _in_kw_event;
            }
}


/// <param name="kw_event">No description supplied.</param>
public delegate System.IntPtr EFlThreadIOCallSync(ref Efl.Event kw_event);
public delegate System.IntPtr EFlThreadIOCallSyncInternal(IntPtr data,  ref Efl.Event.NativeStruct kw_event);
internal class EFlThreadIOCallSyncWrapper : IDisposable
{

    private EFlThreadIOCallSyncInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal EFlThreadIOCallSyncWrapper (EFlThreadIOCallSyncInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~EFlThreadIOCallSyncWrapper()
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

    internal System.IntPtr ManagedCb(ref Efl.Event kw_event)
    {
        Efl.Event.NativeStruct _in_kw_event = kw_event;
                        var _ret_var = _cb(_cb_data, ref _in_kw_event);
        Eina.Error.RaiseIfUnhandledException();
                kw_event = _in_kw_event;
        return _ret_var;
    }

        internal static System.IntPtr Cb(IntPtr cb_data,  ref Efl.Event.NativeStruct kw_event)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        EFlThreadIOCallSync cb = (EFlThreadIOCallSync)handle.Target;
        Efl.Event _in_kw_event = kw_event;
                            System.IntPtr _ret_var = default(System.IntPtr);
        try {
            _ret_var = cb(ref _in_kw_event);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                kw_event = _in_kw_event;
        return _ret_var;
    }
}


namespace Efl {

/// <summary>No description supplied.</summary>
[Efl.IThreadIOConcrete.NativeMethods]
public interface IThreadIO : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <returns>No description supplied.</returns>
System.IntPtr GetIndata();
    /// <param name="data">No description supplied.</param>
void SetIndata(System.IntPtr data);
    /// <returns>No description supplied.</returns>
System.IntPtr GetOutdata();
    /// <param name="data">No description supplied.</param>
void SetOutdata(System.IntPtr data);
    /// <param name="func">No description supplied.</param>
void Call(EFlThreadIOCall func);
    /// <param name="func">No description supplied.</param>
/// <returns>No description supplied.</returns>
System.IntPtr CallSync(EFlThreadIOCallSync func);
                            /// <value>No description supplied.</value>
    System.IntPtr Indata {
        get ;
        set ;
    }
    /// <value>No description supplied.</value>
    System.IntPtr Outdata {
        get ;
        set ;
    }
}
/// <summary>No description supplied.</summary>
sealed public class IThreadIOConcrete :
    Efl.Eo.EoWrapper
    , IThreadIO
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IThreadIOConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_threadio_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IThreadIO"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IThreadIOConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <returns>No description supplied.</returns>
    public System.IntPtr GetIndata() {
         var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_indata_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <param name="data">No description supplied.</param>
    public void SetIndata(System.IntPtr data) {
                                 Efl.IThreadIOConcrete.NativeMethods.efl_threadio_indata_set_ptr.Value.Delegate(this.NativeHandle,data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <returns>No description supplied.</returns>
    public System.IntPtr GetOutdata() {
         var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_outdata_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <param name="data">No description supplied.</param>
    public void SetOutdata(System.IntPtr data) {
                                 Efl.IThreadIOConcrete.NativeMethods.efl_threadio_outdata_set_ptr.Value.Delegate(this.NativeHandle,data);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <param name="func">No description supplied.</param>
    public void Call(EFlThreadIOCall func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.IThreadIOConcrete.NativeMethods.efl_threadio_call_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), EFlThreadIOCallWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <param name="func">No description supplied.</param>
    /// <returns>No description supplied.</returns>
    public System.IntPtr CallSync(EFlThreadIOCallSync func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.IThreadIOConcrete.NativeMethods.efl_threadio_call_sync_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), EFlThreadIOCallSyncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <value>No description supplied.</value>
    public System.IntPtr Indata {
        get { return GetIndata(); }
        set { SetIndata(value); }
    }
    /// <value>No description supplied.</value>
    public System.IntPtr Outdata {
        get { return GetOutdata(); }
        set { SetOutdata(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IThreadIOConcrete.efl_threadio_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (methods.FirstOrDefault(m => m.Name == "CallSync") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_threadio_call_sync"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_sync_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IThreadIOConcrete.efl_threadio_mixin_get();
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

        
        private delegate void efl_threadio_call_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_threadio_call_api_delegate(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate> efl_threadio_call_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_api_delegate>(Module, "efl_threadio_call");

        private static void call(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            EFlThreadIOCallWrapper func_wrapper = new EFlThreadIOCallWrapper(func, func_data, func_free_cb);
            
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

        
        private delegate System.IntPtr efl_threadio_call_sync_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        
        public delegate System.IntPtr efl_threadio_call_sync_api_delegate(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate> efl_threadio_call_sync_ptr = new Efl.Eo.FunctionWrapper<efl_threadio_call_sync_api_delegate>(Module, "efl_threadio_call_sync");

        private static System.IntPtr call_sync(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_threadio_call_sync was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            EFlThreadIOCallSyncWrapper func_wrapper = new EFlThreadIOCallSyncWrapper(func, func_data, func_free_cb);
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((IThreadIO)ws.Target).CallSync(func_wrapper.ManagedCb);
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

