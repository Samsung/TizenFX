#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Cached { 
/// <summary>Efl Cached Item interface</summary>
[ItemNativeInherit]
public interface Item : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the memory size associated with an object.</summary>
/// <returns>Bytes of memory consumed by this object.</returns>
 uint GetMemorySize();
      /// <summary>Get the memory size associated with an object.</summary>
/// <value>Bytes of memory consumed by this object.</value>
    uint MemorySize {
      get ;
   }
}
/// <summary>Efl Cached Item interface</summary>
sealed public class ItemConcrete : 

Item
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ItemConcrete))
            return Efl.Cached.ItemNativeInherit.GetEflClassStatic();
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
      efl_cached_item_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ItemConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ItemConcrete()
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
   public static ItemConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ItemConcrete(obj.NativeHandle);
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
   /// <summary>Get the memory size associated with an object.</summary>
   /// <returns>Bytes of memory consumed by this object.</returns>
   public  uint GetMemorySize() {
       var _ret_var = Efl.Cached.ItemNativeInherit.efl_cached_item_memory_size_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the memory size associated with an object.</summary>
/// <value>Bytes of memory consumed by this object.</value>
   public  uint MemorySize {
      get { return GetMemorySize(); }
   }
}
public class ItemNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_cached_item_memory_size_get_static_delegate == null)
      efl_cached_item_memory_size_get_static_delegate = new efl_cached_item_memory_size_get_delegate(memory_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_cached_item_memory_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_cached_item_memory_size_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Cached.ItemConcrete.efl_cached_item_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Cached.ItemConcrete.efl_cached_item_interface_get();
   }


    private delegate  uint efl_cached_item_memory_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  uint efl_cached_item_memory_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate> efl_cached_item_memory_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_cached_item_memory_size_get_api_delegate>(_Module, "efl_cached_item_memory_size_get");
    private static  uint memory_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_cached_item_memory_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Item)wrapper).GetMemorySize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_cached_item_memory_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_cached_item_memory_size_get_delegate efl_cached_item_memory_size_get_static_delegate;
}
} } 
