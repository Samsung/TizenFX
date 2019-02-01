#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

/// <summary></summary>
/// <param name="kw_event">No description supplied.</param>
/// <returns></returns>
public delegate  void EFlThreadIOCall( ref Efl.Event kw_event);
public delegate  void EFlThreadIOCallInternal(IntPtr data,   ref Efl.Event_StructInternal kw_event);
internal class EFlThreadIOCallWrapper
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
      if (this._cb_free_cb != null)
         this._cb_free_cb(this._cb_data);
   }

   internal  void ManagedCb( ref Efl.Event kw_event)
   {
      var _in_kw_event = Efl.Event_StructConversion.ToInternal(kw_event);
                  _cb(_cb_data,  ref _in_kw_event);
      Eina.Error.RaiseIfUnhandledException();
            kw_event = Efl.Event_StructConversion.ToManaged(_in_kw_event);
         }

      internal static  void Cb(IntPtr cb_data,   ref Efl.Event_StructInternal kw_event)
   {
      GCHandle handle = GCHandle.FromIntPtr(cb_data);
      EFlThreadIOCall cb = (EFlThreadIOCall)handle.Target;
      var _in_kw_event = Efl.Event_StructConversion.ToManaged(kw_event);
                     
      try {
         cb( ref _in_kw_event);
      } catch (Exception e) {
         Eina.Log.Warning($"Callback error: {e.ToString()}");
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
            kw_event = Efl.Event_StructConversion.ToInternal(_in_kw_event);
         }
}


/// <summary></summary>
/// <param name="kw_event">No description supplied.</param>
/// <returns></returns>
public delegate  System.IntPtr EFlThreadIOCallSync( ref Efl.Event kw_event);
public delegate  System.IntPtr EFlThreadIOCallSyncInternal(IntPtr data,   ref Efl.Event_StructInternal kw_event);
internal class EFlThreadIOCallSyncWrapper
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
      if (this._cb_free_cb != null)
         this._cb_free_cb(this._cb_data);
   }

   internal  System.IntPtr ManagedCb( ref Efl.Event kw_event)
   {
      var _in_kw_event = Efl.Event_StructConversion.ToInternal(kw_event);
                  var _ret_var = _cb(_cb_data,  ref _in_kw_event);
      Eina.Error.RaiseIfUnhandledException();
            kw_event = Efl.Event_StructConversion.ToManaged(_in_kw_event);
      return _ret_var;
   }

      internal static  System.IntPtr Cb(IntPtr cb_data,   ref Efl.Event_StructInternal kw_event)
   {
      GCHandle handle = GCHandle.FromIntPtr(cb_data);
      EFlThreadIOCallSync cb = (EFlThreadIOCallSync)handle.Target;
      var _in_kw_event = Efl.Event_StructConversion.ToManaged(kw_event);
                      System.IntPtr _ret_var = default( System.IntPtr);
      try {
         _ret_var = cb( ref _in_kw_event);
      } catch (Exception e) {
         Eina.Log.Warning($"Callback error: {e.ToString()}");
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
            kw_event = Efl.Event_StructConversion.ToInternal(_in_kw_event);
      return _ret_var;
   }
}

namespace Efl { 
/// <summary>No description supplied.</summary>
[ThreadIOConcreteNativeInherit]
public interface ThreadIO : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary></summary>
/// <returns>No description supplied.</returns>
 System.IntPtr GetIndata();
   /// <summary></summary>
/// <param name="data">No description supplied.</param>
/// <returns></returns>
 void SetIndata(  System.IntPtr data);
   /// <summary></summary>
/// <returns>No description supplied.</returns>
 System.IntPtr GetOutdata();
   /// <summary></summary>
/// <param name="data">No description supplied.</param>
/// <returns></returns>
 void SetOutdata(  System.IntPtr data);
   /// <summary></summary>
/// <param name="func">No description supplied.</param>
/// <returns></returns>
 void Call( EFlThreadIOCall func);
   /// <summary></summary>
/// <param name="func">No description supplied.</param>
/// <returns>No description supplied.</returns>
 System.IntPtr CallSync( EFlThreadIOCallSync func);
                     /// <summary></summary>
    System.IntPtr Indata {
      get ;
      set ;
   }
   /// <summary></summary>
    System.IntPtr Outdata {
      get ;
      set ;
   }
}
/// <summary>No description supplied.</summary>
sealed public class ThreadIOConcrete : 

ThreadIO
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ThreadIOConcrete))
            return Efl.ThreadIOConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_threadio_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ThreadIOConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ThreadIOConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ThreadIOConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ThreadIOConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  System.IntPtr efl_threadio_indata_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   public  System.IntPtr GetIndata() {
       var _ret_var = efl_threadio_indata_get(Efl.ThreadIOConcrete.efl_threadio_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  void efl_threadio_indata_set(System.IntPtr obj,    System.IntPtr data);
   /// <summary></summary>
   /// <param name="data">No description supplied.</param>
   /// <returns></returns>
   public  void SetIndata(  System.IntPtr data) {
                         efl_threadio_indata_set(Efl.ThreadIOConcrete.efl_threadio_mixin_get(),  data);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  System.IntPtr efl_threadio_outdata_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   public  System.IntPtr GetOutdata() {
       var _ret_var = efl_threadio_outdata_get(Efl.ThreadIOConcrete.efl_threadio_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  void efl_threadio_outdata_set(System.IntPtr obj,    System.IntPtr data);
   /// <summary></summary>
   /// <param name="data">No description supplied.</param>
   /// <returns></returns>
   public  void SetOutdata(  System.IntPtr data) {
                         efl_threadio_outdata_set(Efl.ThreadIOConcrete.efl_threadio_mixin_get(),  data);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  void efl_threadio_call(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);
   /// <summary></summary>
   /// <param name="func">No description supplied.</param>
   /// <returns></returns>
   public  void Call( EFlThreadIOCall func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      efl_threadio_call(Efl.ThreadIOConcrete.efl_threadio_mixin_get(), GCHandle.ToIntPtr(func_handle), EFlThreadIOCallWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    private static extern  System.IntPtr efl_threadio_call_sync(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);
   /// <summary></summary>
   /// <param name="func">No description supplied.</param>
   /// <returns>No description supplied.</returns>
   public  System.IntPtr CallSync( EFlThreadIOCallSync func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      var _ret_var = efl_threadio_call_sync(Efl.ThreadIOConcrete.efl_threadio_mixin_get(), GCHandle.ToIntPtr(func_handle), EFlThreadIOCallSyncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary></summary>
   public  System.IntPtr Indata {
      get { return GetIndata(); }
      set { SetIndata( value); }
   }
   /// <summary></summary>
   public  System.IntPtr Outdata {
      get { return GetOutdata(); }
      set { SetOutdata( value); }
   }
}
public class ThreadIOConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_threadio_indata_get_static_delegate = new efl_threadio_indata_get_delegate(indata_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_indata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_get_static_delegate)});
      efl_threadio_indata_set_static_delegate = new efl_threadio_indata_set_delegate(indata_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_indata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_indata_set_static_delegate)});
      efl_threadio_outdata_get_static_delegate = new efl_threadio_outdata_get_delegate(outdata_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_outdata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_get_static_delegate)});
      efl_threadio_outdata_set_static_delegate = new efl_threadio_outdata_set_delegate(outdata_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_outdata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_outdata_set_static_delegate)});
      efl_threadio_call_static_delegate = new efl_threadio_call_delegate(call);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_call"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_static_delegate)});
      efl_threadio_call_sync_static_delegate = new efl_threadio_call_sync_delegate(call_sync);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_threadio_call_sync"), func = Marshal.GetFunctionPointerForDelegate(efl_threadio_call_sync_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ThreadIOConcrete.efl_threadio_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.ThreadIOConcrete.efl_threadio_mixin_get();
   }


    private delegate  System.IntPtr efl_threadio_indata_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_threadio_indata_get(System.IntPtr obj);
    private static  System.IntPtr indata_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_threadio_indata_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((ThreadIOConcrete)wrapper).GetIndata();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_threadio_indata_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_threadio_indata_get_delegate efl_threadio_indata_get_static_delegate;


    private delegate  void efl_threadio_indata_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_threadio_indata_set(System.IntPtr obj,    System.IntPtr data);
    private static  void indata_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_threadio_indata_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ThreadIOConcrete)wrapper).SetIndata( data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_threadio_indata_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  data);
      }
   }
   private efl_threadio_indata_set_delegate efl_threadio_indata_set_static_delegate;


    private delegate  System.IntPtr efl_threadio_outdata_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_threadio_outdata_get(System.IntPtr obj);
    private static  System.IntPtr outdata_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_threadio_outdata_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((ThreadIOConcrete)wrapper).GetOutdata();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_threadio_outdata_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_threadio_outdata_get_delegate efl_threadio_outdata_get_static_delegate;


    private delegate  void efl_threadio_outdata_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_threadio_outdata_set(System.IntPtr obj,    System.IntPtr data);
    private static  void outdata_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_threadio_outdata_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ThreadIOConcrete)wrapper).SetOutdata( data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_threadio_outdata_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  data);
      }
   }
   private efl_threadio_outdata_set_delegate efl_threadio_outdata_set_static_delegate;


    private delegate  void efl_threadio_call_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_threadio_call(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);
    private static  void call(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_threadio_call was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              EFlThreadIOCallWrapper func_wrapper = new EFlThreadIOCallWrapper(func, func_data, func_free_cb);
         
         try {
            ((ThreadIOConcrete)wrapper).Call( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_threadio_call(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private efl_threadio_call_delegate efl_threadio_call_static_delegate;


    private delegate  System.IntPtr efl_threadio_call_sync_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_threadio_call_sync(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);
    private static  System.IntPtr call_sync(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_threadio_call_sync was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              EFlThreadIOCallSyncWrapper func_wrapper = new EFlThreadIOCallSyncWrapper(func, func_data, func_free_cb);
          System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((ThreadIOConcrete)wrapper).CallSync( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_threadio_call_sync(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private efl_threadio_call_sync_delegate efl_threadio_call_sync_static_delegate;
}
} 
