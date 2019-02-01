#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get(). Calling Efl.Part.part_get() directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)</summary>
[PartConcreteNativeInherit]
public interface Part : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get a proxy object referring to a part of an object.</summary>
/// <param name="name">The part name.</param>
/// <returns>A (proxy) object, valid for a single call.</returns>
Efl.Object GetPart(  System.String name);
   }
/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get(). Calling Efl.Part.part_get() directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)</summary>
sealed public class PartConcrete : 

Part
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PartConcrete))
            return Efl.PartConcreteNativeInherit.GetEflClassStatic();
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
      efl_part_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public PartConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PartConcrete()
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
   public static PartConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PartConcrete(obj.NativeHandle);
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
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_part_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   /// <summary>Get a proxy object referring to a part of an object.</summary>
   /// <param name="name">The part name.</param>
   /// <returns>A (proxy) object, valid for a single call.</returns>
   public Efl.Object GetPart(  System.String name) {
                         var _ret_var = efl_part_get(Efl.PartConcrete.efl_part_interface_get(),  name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
}
public class PartConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PartConcrete.efl_part_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PartConcrete.efl_part_interface_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_part_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_part_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Part)wrapper).GetPart( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_part_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private efl_part_get_delegate efl_part_get_static_delegate;
}
} 
