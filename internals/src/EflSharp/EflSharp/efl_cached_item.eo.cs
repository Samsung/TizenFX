#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Cached { 
/// <summary>Efl Cached Item interface</summary>
[ItemConcreteNativeInherit]
public interface Item : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the memory size associated with an object.</summary>
/// <returns>Bytes of memory consumed by this object.</returns>
 uint GetMemorySize();
      /// <summary>Get the memory size associated with an object.</summary>
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
            return Efl.Cached.ItemConcreteNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_cached_item_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  uint efl_cached_item_memory_size_get(System.IntPtr obj);
   /// <summary>Get the memory size associated with an object.</summary>
   /// <returns>Bytes of memory consumed by this object.</returns>
   public  uint GetMemorySize() {
       var _ret_var = efl_cached_item_memory_size_get(Efl.Cached.ItemConcrete.efl_cached_item_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the memory size associated with an object.</summary>
   public  uint MemorySize {
      get { return GetMemorySize(); }
   }
}
public class ItemConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_cached_item_memory_size_get_static_delegate = new efl_cached_item_memory_size_get_delegate(memory_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_cached_item_memory_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_cached_item_memory_size_get_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  uint efl_cached_item_memory_size_get(System.IntPtr obj);
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
         return efl_cached_item_memory_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_cached_item_memory_size_get_delegate efl_cached_item_memory_size_get_static_delegate;
}
} } 
