#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl observer interface</summary>
[ObserverNativeInherit]
public interface Observer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Update observer according to the changes of observable object.
/// 1.19</summary>
/// <param name="obs">An observable object</param>
/// <param name="key">A key to classify observer groups</param>
/// <param name="data">Required data to update the observer, usually passed by observable object</param>
/// <returns></returns>
 void Update( Efl.Object obs,   System.String key,   System.IntPtr data);
   }
/// <summary>Efl observer interface</summary>
sealed public class ObserverConcrete : 

Observer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ObserverConcrete))
            return Efl.ObserverNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_observer_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ObserverConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ObserverConcrete()
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
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static ObserverConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ObserverConcrete(obj.NativeHandle);
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
   /// <summary>Update observer according to the changes of observable object.
   /// 1.19</summary>
   /// <param name="obs">An observable object</param>
   /// <param name="key">A key to classify observer groups</param>
   /// <param name="data">Required data to update the observer, usually passed by observable object</param>
   /// <returns></returns>
   public  void Update( Efl.Object obs,   System.String key,   System.IntPtr data) {
                                                             Efl.ObserverNativeInherit.efl_observer_update_ptr.Value.Delegate(this.NativeHandle, obs,  key,  data);
      Eina.Error.RaiseIfUnhandledException();
                                           }
}
public class ObserverNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_observer_update_static_delegate == null)
      efl_observer_update_static_delegate = new efl_observer_update_delegate(update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_observer_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observer_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ObserverConcrete.efl_observer_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.ObserverConcrete.efl_observer_interface_get();
   }


    private delegate  void efl_observer_update_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obs,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);


    public delegate  void efl_observer_update_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obs,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate> efl_observer_update_ptr = new Efl.Eo.FunctionWrapper<efl_observer_update_api_delegate>(_Module, "efl_observer_update");
    private static  void update(System.IntPtr obj, System.IntPtr pd,  Efl.Object obs,   System.String key,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_observer_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Observer)wrapper).Update( obs,  key,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_observer_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  obs,  key,  data);
      }
   }
   private static efl_observer_update_delegate efl_observer_update_static_delegate;
}
} 
