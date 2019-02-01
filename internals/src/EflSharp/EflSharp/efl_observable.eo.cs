#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl observable class</summary>
[ObservableNativeInherit]
public class Observable : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ObservableNativeInherit nativeInherit = new Efl.ObservableNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Observable))
            return Efl.ObservableNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Observable obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_observable_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Observable(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Observable", efl_observable_class_get(), typeof(Observable), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Observable(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Observable(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Observable static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Observable(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_observable_observer_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   /// <summary>Add an observer to a group of observers.
   /// Note: Observers that observe this observable are grouped by the <c>key</c> and an observer can belong to multiple groups at the same time.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void AddObserver(  System.String key,  Efl.Observer obs) {
                                           efl_observable_observer_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key,  obs);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_observable_observer_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   /// <summary>Delete an observer from a group of observers.
   /// See also <see cref="Efl.Observable.AddObserver"/>.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void DelObserver(  System.String key,  Efl.Observer obs) {
                                           efl_observable_observer_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key,  obs);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_observable_observer_clean(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   /// <summary>Clear an observer from all groups of observers.
   /// 1.19</summary>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void ObserverClean( Efl.Observer obs) {
                         efl_observable_observer_clean((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  obs);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  System.IntPtr efl_observable_observers_iterator_new(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Return a new iterator associated with a group of observers.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <returns>Iterator for observers group</returns>
   virtual public Eina.Iterator<Efl.Observer> NewObserversIterator(  System.String key) {
                         var _ret_var = efl_observable_observers_iterator_new((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Observer>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_observable_observers_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
   /// <summary>Update all observers in a group by calling their update() method.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="data">Required data to update observer</param>
   /// <returns></returns>
   virtual public  void UpdateObservers(  System.String key,   System.IntPtr data) {
                                           efl_observable_observers_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  System.IntPtr efl_observable_iterator_tuple_new(System.IntPtr obj);
   /// <summary>Return a new iterator associated to this observable.
   /// 1.19</summary>
   /// <returns>Iterator for observer</returns>
   virtual public Eina.Iterator<Efl.ObservableTuple> NewIteratorTuple() {
       var _ret_var = efl_observable_iterator_tuple_new((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.ObservableTuple>(_ret_var, true, false);
 }
}
public class ObservableNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_observable_observer_add_static_delegate = new efl_observable_observer_add_delegate(observer_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_observer_add"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_add_static_delegate)});
      efl_observable_observer_del_static_delegate = new efl_observable_observer_del_delegate(observer_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_observer_del"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_del_static_delegate)});
      efl_observable_observer_clean_static_delegate = new efl_observable_observer_clean_delegate(observer_clean);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_observer_clean"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_clean_static_delegate)});
      efl_observable_observers_iterator_new_static_delegate = new efl_observable_observers_iterator_new_delegate(observers_iterator_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_observers_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_iterator_new_static_delegate)});
      efl_observable_observers_update_static_delegate = new efl_observable_observers_update_delegate(observers_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_observers_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_update_static_delegate)});
      efl_observable_iterator_tuple_new_static_delegate = new efl_observable_iterator_tuple_new_delegate(iterator_tuple_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_observable_iterator_tuple_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_iterator_tuple_new_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Observable.efl_observable_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Observable.efl_observable_class_get();
   }


    private delegate  void efl_observable_observer_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_observable_observer_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    private static  void observer_add(System.IntPtr obj, System.IntPtr pd,   System.String key,  Efl.Observer obs)
   {
      Eina.Log.Debug("function efl_observable_observer_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Observable)wrapper).AddObserver( key,  obs);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_observable_observer_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  obs);
      }
   }
   private efl_observable_observer_add_delegate efl_observable_observer_add_static_delegate;


    private delegate  void efl_observable_observer_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_observable_observer_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    private static  void observer_del(System.IntPtr obj, System.IntPtr pd,   System.String key,  Efl.Observer obs)
   {
      Eina.Log.Debug("function efl_observable_observer_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Observable)wrapper).DelObserver( key,  obs);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_observable_observer_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  obs);
      }
   }
   private efl_observable_observer_del_delegate efl_observable_observer_del_static_delegate;


    private delegate  void efl_observable_observer_clean_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_observable_observer_clean(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    private static  void observer_clean(System.IntPtr obj, System.IntPtr pd,  Efl.Observer obs)
   {
      Eina.Log.Debug("function efl_observable_observer_clean was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Observable)wrapper).ObserverClean( obs);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_observable_observer_clean(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  obs);
      }
   }
   private efl_observable_observer_clean_delegate efl_observable_observer_clean_static_delegate;


    private delegate  System.IntPtr efl_observable_observers_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_observable_observers_iterator_new(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static  System.IntPtr observers_iterator_new(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_observable_observers_iterator_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Iterator<Efl.Observer> _ret_var = default(Eina.Iterator<Efl.Observer>);
         try {
            _ret_var = ((Observable)wrapper).NewObserversIterator( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_observable_observers_iterator_new(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_observable_observers_iterator_new_delegate efl_observable_observers_iterator_new_static_delegate;


    private delegate  void efl_observable_observers_update_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_observable_observers_update(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
    private static  void observers_update(System.IntPtr obj, System.IntPtr pd,   System.String key,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_observable_observers_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Observable)wrapper).UpdateObservers( key,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_observable_observers_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  data);
      }
   }
   private efl_observable_observers_update_delegate efl_observable_observers_update_static_delegate;


    private delegate  System.IntPtr efl_observable_iterator_tuple_new_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_observable_iterator_tuple_new(System.IntPtr obj);
    private static  System.IntPtr iterator_tuple_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_observable_iterator_tuple_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.ObservableTuple> _ret_var = default(Eina.Iterator<Efl.ObservableTuple>);
         try {
            _ret_var = ((Observable)wrapper).NewIteratorTuple();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_observable_iterator_tuple_new(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_observable_iterator_tuple_new_delegate efl_observable_iterator_tuple_new_static_delegate;
}
} 
