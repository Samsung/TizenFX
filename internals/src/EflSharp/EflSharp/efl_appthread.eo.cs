#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>No description supplied.</summary>
[AppthreadNativeInherit]
public class Appthread : Efl.Loop, Efl.Eo.IWrapper,Efl.ThreadIO
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.AppthreadNativeInherit nativeInherit = new Efl.AppthreadNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Appthread))
            return Efl.AppthreadNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Appthread obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_appthread_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Appthread(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Appthread", efl_appthread_class_get(), typeof(Appthread), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Appthread(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Appthread(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Appthread static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Appthread(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_threadio_indata_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   virtual public  System.IntPtr GetIndata() {
       var _ret_var = efl_threadio_indata_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_threadio_indata_set(System.IntPtr obj,    System.IntPtr data);
   /// <summary></summary>
   /// <param name="data">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetIndata(  System.IntPtr data) {
                         efl_threadio_indata_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  data);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_threadio_outdata_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns>No description supplied.</returns>
   virtual public  System.IntPtr GetOutdata() {
       var _ret_var = efl_threadio_outdata_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_threadio_outdata_set(System.IntPtr obj,    System.IntPtr data);
   /// <summary></summary>
   /// <param name="data">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetOutdata(  System.IntPtr data) {
                         efl_threadio_outdata_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  data);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_threadio_call(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallInternal func, EinaFreeCb func_free_cb);
   /// <summary></summary>
   /// <param name="func">No description supplied.</param>
   /// <returns></returns>
   virtual public  void Call( EFlThreadIOCall func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      efl_threadio_call((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), GCHandle.ToIntPtr(func_handle), EFlThreadIOCallWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_threadio_call_sync(System.IntPtr obj,  IntPtr func_data, EFlThreadIOCallSyncInternal func, EinaFreeCb func_free_cb);
   /// <summary></summary>
   /// <param name="func">No description supplied.</param>
   /// <returns>No description supplied.</returns>
   virtual public  System.IntPtr CallSync( EFlThreadIOCallSync func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      var _ret_var = efl_threadio_call_sync((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), GCHandle.ToIntPtr(func_handle), EFlThreadIOCallSyncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
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
public class AppthreadNativeInherit : Efl.LoopNativeInherit{
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Appthread.efl_appthread_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Appthread.efl_appthread_class_get();
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
            _ret_var = ((Appthread)wrapper).GetIndata();
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
            ((Appthread)wrapper).SetIndata( data);
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
            _ret_var = ((Appthread)wrapper).GetOutdata();
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
            ((Appthread)wrapper).SetOutdata( data);
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
            ((Appthread)wrapper).Call( func_wrapper.ManagedCb);
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
            _ret_var = ((Appthread)wrapper).CallSync( func_wrapper.ManagedCb);
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
