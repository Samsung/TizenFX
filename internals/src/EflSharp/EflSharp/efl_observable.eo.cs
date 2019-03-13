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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_observable_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Observable(Efl.Object parent= null
         ) :
      base(efl_observable_class_get(), typeof(Observable), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Observable(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Observable(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>Add an observer to a group of observers.
   /// Note: Observers that observe this observable are grouped by the <c>key</c> and an observer can belong to multiple groups at the same time.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void AddObserver(  System.String key,  Efl.Observer obs) {
                                           Efl.ObservableNativeInherit.efl_observable_observer_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  obs);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Delete an observer from a group of observers.
   /// See also <see cref="Efl.Observable.AddObserver"/>.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void DelObserver(  System.String key,  Efl.Observer obs) {
                                           Efl.ObservableNativeInherit.efl_observable_observer_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  obs);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Clear an observer from all groups of observers.
   /// 1.19</summary>
   /// <param name="obs">An observer object</param>
   /// <returns></returns>
   virtual public  void ObserverClean( Efl.Observer obs) {
                         Efl.ObservableNativeInherit.efl_observable_observer_clean_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), obs);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Return a new iterator associated with a group of observers.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <returns>Iterator for observers group</returns>
   virtual public Eina.Iterator<Efl.Observer> NewObserversIterator(  System.String key) {
                         var _ret_var = Efl.ObservableNativeInherit.efl_observable_observers_iterator_new_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Observer>(_ret_var, true, false);
 }
   /// <summary>Update all observers in a group by calling their update() method.
   /// 1.19</summary>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="data">Required data to update observer</param>
   /// <returns></returns>
   virtual public  void UpdateObservers(  System.String key,   System.IntPtr data) {
                                           Efl.ObservableNativeInherit.efl_observable_observers_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  data);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Return a new iterator associated to this observable.
   /// 1.19</summary>
   /// <returns>Iterator for observer</returns>
   virtual public Eina.Iterator<Efl.ObservableTuple> NewIteratorTuple() {
       var _ret_var = Efl.ObservableNativeInherit.efl_observable_iterator_tuple_new_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.ObservableTuple>(_ret_var, true, false);
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Observable.efl_observable_class_get();
   }
}
public class ObservableNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_observable_observer_add_static_delegate == null)
      efl_observable_observer_add_static_delegate = new efl_observable_observer_add_delegate(observer_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_observer_add"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_add_static_delegate)});
      if (efl_observable_observer_del_static_delegate == null)
      efl_observable_observer_del_static_delegate = new efl_observable_observer_del_delegate(observer_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_observer_del"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_del_static_delegate)});
      if (efl_observable_observer_clean_static_delegate == null)
      efl_observable_observer_clean_static_delegate = new efl_observable_observer_clean_delegate(observer_clean);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_observer_clean"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_clean_static_delegate)});
      if (efl_observable_observers_iterator_new_static_delegate == null)
      efl_observable_observers_iterator_new_static_delegate = new efl_observable_observers_iterator_new_delegate(observers_iterator_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_observers_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_iterator_new_static_delegate)});
      if (efl_observable_observers_update_static_delegate == null)
      efl_observable_observers_update_static_delegate = new efl_observable_observers_update_delegate(observers_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_observers_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_update_static_delegate)});
      if (efl_observable_iterator_tuple_new_static_delegate == null)
      efl_observable_iterator_tuple_new_static_delegate = new efl_observable_iterator_tuple_new_delegate(iterator_tuple_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observable_iterator_tuple_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_iterator_tuple_new_static_delegate)});
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


    private delegate  void efl_observable_observer_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);


    public delegate  void efl_observable_observer_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    public static Efl.Eo.FunctionWrapper<efl_observable_observer_add_api_delegate> efl_observable_observer_add_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_add_api_delegate>(_Module, "efl_observable_observer_add");
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
         efl_observable_observer_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  obs);
      }
   }
   private static efl_observable_observer_add_delegate efl_observable_observer_add_static_delegate;


    private delegate  void efl_observable_observer_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);


    public delegate  void efl_observable_observer_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    public static Efl.Eo.FunctionWrapper<efl_observable_observer_del_api_delegate> efl_observable_observer_del_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_del_api_delegate>(_Module, "efl_observable_observer_del");
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
         efl_observable_observer_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  obs);
      }
   }
   private static efl_observable_observer_del_delegate efl_observable_observer_del_static_delegate;


    private delegate  void efl_observable_observer_clean_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);


    public delegate  void efl_observable_observer_clean_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.ObserverConcrete, Efl.Eo.NonOwnTag>))]  Efl.Observer obs);
    public static Efl.Eo.FunctionWrapper<efl_observable_observer_clean_api_delegate> efl_observable_observer_clean_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_clean_api_delegate>(_Module, "efl_observable_observer_clean");
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
         efl_observable_observer_clean_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  obs);
      }
   }
   private static efl_observable_observer_clean_delegate efl_observable_observer_clean_static_delegate;


    private delegate  System.IntPtr efl_observable_observers_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);


    public delegate  System.IntPtr efl_observable_observers_iterator_new_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    public static Efl.Eo.FunctionWrapper<efl_observable_observers_iterator_new_api_delegate> efl_observable_observers_iterator_new_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observers_iterator_new_api_delegate>(_Module, "efl_observable_observers_iterator_new");
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
         return efl_observable_observers_iterator_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_observable_observers_iterator_new_delegate efl_observable_observers_iterator_new_static_delegate;


    private delegate  void efl_observable_observers_update_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);


    public delegate  void efl_observable_observers_update_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_observable_observers_update_api_delegate> efl_observable_observers_update_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observers_update_api_delegate>(_Module, "efl_observable_observers_update");
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
         efl_observable_observers_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  data);
      }
   }
   private static efl_observable_observers_update_delegate efl_observable_observers_update_static_delegate;


    private delegate  System.IntPtr efl_observable_iterator_tuple_new_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_observable_iterator_tuple_new_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_observable_iterator_tuple_new_api_delegate> efl_observable_iterator_tuple_new_ptr = new Efl.Eo.FunctionWrapper<efl_observable_iterator_tuple_new_api_delegate>(_Module, "efl_observable_iterator_tuple_new");
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
         return efl_observable_iterator_tuple_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_observable_iterator_tuple_new_delegate efl_observable_iterator_tuple_new_static_delegate;
}
} 
namespace Efl { 
/// <summary>This type describes an observable touple</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObservableTuple
{
   /// <summary>Touple key</summary>
   public  System.String Key;
   /// <summary>Touple data</summary>
   public Eina.Iterator<Efl.Observer> Data;
   ///<summary>Constructor for ObservableTuple.</summary>
   public ObservableTuple(
       System.String Key=default( System.String),
      Eina.Iterator<Efl.Observer> Data=default(Eina.Iterator<Efl.Observer>)   )
   {
      this.Key = Key;
      this.Data = Data;
   }
public static implicit operator ObservableTuple(IntPtr ptr)
   {
      var tmp = (ObservableTuple_StructInternal)Marshal.PtrToStructure(ptr, typeof(ObservableTuple_StructInternal));
      return ObservableTuple_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ObservableTuple.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObservableTuple_StructInternal
{
///<summary>Internal wrapper for field Key</summary>
public System.IntPtr Key;
   
   public  System.IntPtr Data;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ObservableTuple(ObservableTuple_StructInternal struct_)
   {
      return ObservableTuple_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ObservableTuple_StructInternal(ObservableTuple struct_)
   {
      return ObservableTuple_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ObservableTuple</summary>
public static class ObservableTuple_StructConversion
{
   internal static ObservableTuple_StructInternal ToInternal(ObservableTuple _external_struct)
   {
      var _internal_struct = new ObservableTuple_StructInternal();

      _internal_struct.Key = Eina.MemoryNative.StrDup(_external_struct.Key);
      _internal_struct.Data = _external_struct.Data.Handle;

      return _internal_struct;
   }

   internal static ObservableTuple ToManaged(ObservableTuple_StructInternal _internal_struct)
   {
      var _external_struct = new ObservableTuple();

      _external_struct.Key = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Key);
      _external_struct.Data = new Eina.Iterator<Efl.Observer>(_internal_struct.Data, false, false);

      return _external_struct;
   }

}
} 
