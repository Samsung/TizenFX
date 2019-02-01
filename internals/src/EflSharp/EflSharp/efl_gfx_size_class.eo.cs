#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Size Class interface</summary>
[SizeClassConcreteNativeInherit]
public interface SizeClass : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get width and height of size class.
/// This function gets width and height for a size class. These values will only be valid until the size class is changed or the edje object is deleted.
/// 1.17</summary>
/// <param name="size_class">The name of size class</param>
/// <param name="minw">minimum width</param>
/// <param name="minh">minimum height</param>
/// <param name="maxw">maximum width</param>
/// <param name="maxh">maximum height</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool GetSizeClass(  System.String size_class,  out  int minw,  out  int minh,  out  int maxw,  out  int maxh);
   /// <summary>Set width and height of size class.
/// This function sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values.
/// 1.17</summary>
/// <param name="size_class">The name of size class</param>
/// <param name="minw">minimum width</param>
/// <param name="minh">minimum height</param>
/// <param name="maxw">maximum width</param>
/// <param name="maxh">maximum height</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool SetSizeClass(  System.String size_class,   int minw,   int minh,   int maxw,   int maxh);
   /// <summary>Delete the size class.
/// This function deletes any values for the specified size class.
/// 
/// Deleting the size class will revert it to the values defined by <see cref="Efl.Gfx.SizeClass.GetSizeClass"/> or the size class defined in the theme file.
/// 1.17</summary>
/// <param name="size_class">The size class to be deleted.</param>
/// <returns></returns>
 void DelSizeClass(  System.String size_class);
         }
/// <summary>Efl Gfx Size Class interface</summary>
sealed public class SizeClassConcrete : 

SizeClass
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SizeClassConcrete))
            return Efl.Gfx.SizeClassConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_size_class_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SizeClassConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SizeClassConcrete()
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
   public static SizeClassConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SizeClassConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_size_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,   out  int minw,   out  int minh,   out  int maxw,   out  int maxh);
   /// <summary>Get width and height of size class.
   /// This function gets width and height for a size class. These values will only be valid until the size class is changed or the edje object is deleted.
   /// 1.17</summary>
   /// <param name="size_class">The name of size class</param>
   /// <param name="minw">minimum width</param>
   /// <param name="minh">minimum height</param>
   /// <param name="maxw">maximum width</param>
   /// <param name="maxh">maximum height</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   public bool GetSizeClass(  System.String size_class,  out  int minw,  out  int minh,  out  int maxw,  out  int maxh) {
                                                                                                 var _ret_var = efl_gfx_size_class_get(Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get(),  size_class,  out minw,  out minh,  out maxw,  out maxh);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_size_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,    int minw,    int minh,    int maxw,    int maxh);
   /// <summary>Set width and height of size class.
   /// This function sets width and height for a size class. This will make all edje parts in the specified object that have the specified size class update their size with given values.
   /// 1.17</summary>
   /// <param name="size_class">The name of size class</param>
   /// <param name="minw">minimum width</param>
   /// <param name="minh">minimum height</param>
   /// <param name="maxw">maximum width</param>
   /// <param name="maxh">maximum height</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   public bool SetSizeClass(  System.String size_class,   int minw,   int minh,   int maxw,   int maxh) {
                                                                                                 var _ret_var = efl_gfx_size_class_set(Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get(),  size_class,  minw,  minh,  maxw,  maxh);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_size_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class);
   /// <summary>Delete the size class.
   /// This function deletes any values for the specified size class.
   /// 
   /// Deleting the size class will revert it to the values defined by <see cref="Efl.Gfx.SizeClass.GetSizeClass"/> or the size class defined in the theme file.
   /// 1.17</summary>
   /// <param name="size_class">The size class to be deleted.</param>
   /// <returns></returns>
   public  void DelSizeClass(  System.String size_class) {
                         efl_gfx_size_class_del(Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get(),  size_class);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class SizeClassConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_size_class_get_static_delegate = new efl_gfx_size_class_get_delegate(size_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_get_static_delegate)});
      efl_gfx_size_class_set_static_delegate = new efl_gfx_size_class_set_delegate(size_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_set_static_delegate)});
      efl_gfx_size_class_del_static_delegate = new efl_gfx_size_class_del_delegate(size_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_class_del_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.SizeClassConcrete.efl_gfx_size_class_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_size_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,   out  int minw,   out  int minh,   out  int maxw,   out  int maxh);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_size_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,   out  int minw,   out  int minh,   out  int maxw,   out  int maxh);
    private static bool size_class_get(System.IntPtr obj, System.IntPtr pd,   System.String size_class,  out  int minw,  out  int minh,  out  int maxw,  out  int maxh)
   {
      Eina.Log.Debug("function efl_gfx_size_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   minw = default( int);      minh = default( int);      maxw = default( int);      maxh = default( int);                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((SizeClass)wrapper).GetSizeClass( size_class,  out minw,  out minh,  out maxw,  out maxh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_size_class_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class,  out minw,  out minh,  out maxw,  out maxh);
      }
   }
   private efl_gfx_size_class_get_delegate efl_gfx_size_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_size_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,    int minw,    int minh,    int maxw,    int maxh);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_size_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class,    int minw,    int minh,    int maxw,    int maxh);
    private static bool size_class_set(System.IntPtr obj, System.IntPtr pd,   System.String size_class,   int minw,   int minh,   int maxw,   int maxh)
   {
      Eina.Log.Debug("function efl_gfx_size_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            bool _ret_var = default(bool);
         try {
            _ret_var = ((SizeClass)wrapper).SetSizeClass( size_class,  minw,  minh,  maxw,  maxh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_size_class_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class,  minw,  minh,  maxw,  maxh);
      }
   }
   private efl_gfx_size_class_set_delegate efl_gfx_size_class_set_static_delegate;


    private delegate  void efl_gfx_size_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String size_class);
    private static  void size_class_del(System.IntPtr obj, System.IntPtr pd,   System.String size_class)
   {
      Eina.Log.Debug("function efl_gfx_size_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SizeClass)wrapper).DelSizeClass( size_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_class_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size_class);
      }
   }
   private efl_gfx_size_class_del_delegate efl_gfx_size_class_del_static_delegate;
}
} } 
