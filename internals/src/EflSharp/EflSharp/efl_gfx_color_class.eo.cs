#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Color Class interface</summary>
[ColorClassConcreteNativeInherit]
public interface ColorClass : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the color of color class.
/// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <param name="r">The intensity of the red color</param>
/// <param name="g">The intensity of the green color</param>
/// <param name="b">The intensity of the blue color</param>
/// <param name="a">The alpha value</param>
/// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
bool GetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out  int r,  out  int g,  out  int b,  out  int a);
   /// <summary>Set the color of color class.
/// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
/// 
/// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
/// 
/// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
/// 
/// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
/// <param name="color_class">The name of color class</param>
/// <param name="layer">The layer to set the color</param>
/// <param name="r">The intensity of the red color</param>
/// <param name="g">The intensity of the green color</param>
/// <param name="b">The intensity of the blue color</param>
/// <param name="a">The alpha value</param>
/// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
bool SetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a);
   /// <summary>Get the description of a color class.
/// This function gets the description of a color class in use by an object.</summary>
/// <param name="color_class">The name of color class</param>
/// <returns>The description of the target color class or <c>null</c> if not found</returns>
 System.String GetColorClassDescription(  System.String color_class);
   /// <summary>Delete the color class.
/// This function deletes any values for the specified color class.
/// 
/// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.ColorClass.GetColorClass"/> or the color class defined in the theme file.
/// 
/// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
/// <param name="color_class">The name of color_class</param>
/// <returns></returns>
 void DelColorClass(  System.String color_class);
   /// <summary>Delete all color classes defined in object level.
/// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.
/// 1.17.0</summary>
/// <returns></returns>
 void ClearColorClass();
               }
/// <summary>Efl Gfx Color Class interface</summary>
sealed public class ColorClassConcrete : 

ColorClass
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ColorClassConcrete))
            return Efl.Gfx.ColorClassConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_color_class_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ColorClassConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ColorClassConcrete()
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
   public static ColorClassConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ColorClassConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_color_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>Get the color of color class.
   /// This function gets the color values for a color class. If no explicit object color is set, then global values will be used.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="r">The intensity of the red color</param>
   /// <param name="g">The intensity of the green color</param>
   /// <param name="b">The intensity of the blue color</param>
   /// <param name="a">The alpha value</param>
   /// <returns><c>true</c> if getting the color succeeded, <c>false</c> otherwise</returns>
   public bool GetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out  int r,  out  int g,  out  int b,  out  int a) {
                                                                                                                   var _ret_var = efl_gfx_color_class_get(Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get(),  color_class,  layer,  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_color_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,    int r,    int g,    int b,    int a);
   /// <summary>Set the color of color class.
   /// This function sets the color values for a color class. This will cause all edje parts in the specified object that have the specified color class to have their colors multiplied by these values.
   /// 
   /// The first color is the object, the second is the text outline, and the third is the text shadow. (Note that the second two only apply to text parts).
   /// 
   /// Setting color emits a signal &quot;color_class,set&quot; with source being the given color.
   /// 
   /// Note: These color values are expected to be premultiplied by <c>a</c>.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="r">The intensity of the red color</param>
   /// <param name="g">The intensity of the green color</param>
   /// <param name="b">The intensity of the blue color</param>
   /// <param name="a">The alpha value</param>
   /// <returns><c>true</c> if setting the color succeeded, <c>false</c> otherwise</returns>
   public bool SetColorClass(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a) {
                                                                                                                   var _ret_var = efl_gfx_color_class_set(Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get(),  color_class,  layer,  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_gfx_color_class_description_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
   /// <summary>Get the description of a color class.
   /// This function gets the description of a color class in use by an object.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <returns>The description of the target color class or <c>null</c> if not found</returns>
   public  System.String GetColorClassDescription(  System.String color_class) {
                         var _ret_var = efl_gfx_color_class_description_get(Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get(),  color_class);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_color_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
   /// <summary>Delete the color class.
   /// This function deletes any values for the specified color class.
   /// 
   /// Deleting the color class will revert it to the values defined by <see cref="Efl.Gfx.ColorClass.GetColorClass"/> or the color class defined in the theme file.
   /// 
   /// Deleting the color class will emit the signal &quot;color_class,del&quot; for the given Edje object.</summary>
   /// <param name="color_class">The name of color_class</param>
   /// <returns></returns>
   public  void DelColorClass(  System.String color_class) {
                         efl_gfx_color_class_del(Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get(),  color_class);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_color_class_clear(System.IntPtr obj);
   /// <summary>Delete all color classes defined in object level.
   /// This function deletes any color classes defined in object level. Clearing color classes will revert the color of all edje parts to the values defined in global level or theme file.
   /// 1.17.0</summary>
   /// <returns></returns>
   public  void ClearColorClass() {
       efl_gfx_color_class_clear(Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class ColorClassConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_color_class_get_static_delegate = new efl_gfx_color_class_get_delegate(color_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_get_static_delegate)});
      efl_gfx_color_class_set_static_delegate = new efl_gfx_color_class_set_delegate(color_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_set_static_delegate)});
      efl_gfx_color_class_description_get_static_delegate = new efl_gfx_color_class_description_get_delegate(color_class_description_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_description_get_static_delegate)});
      efl_gfx_color_class_del_static_delegate = new efl_gfx_color_class_del_delegate(color_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_del_static_delegate)});
      efl_gfx_color_class_clear_static_delegate = new efl_gfx_color_class_clear_delegate(color_class_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_clear_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.ColorClassConcrete.efl_gfx_color_class_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_color_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,   out  int r,   out  int g,   out  int b,   out  int a);
    private static bool color_class_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_color_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                               r = default( int);      g = default( int);      b = default( int);      a = default( int);                                             bool _ret_var = default(bool);
         try {
            _ret_var = ((ColorClass)wrapper).GetColorClass( color_class,  layer,  out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                              return _ret_var;
      } else {
         return efl_gfx_color_class_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_color_class_get_delegate efl_gfx_color_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_color_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_color_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,    int r,    int g,    int b,    int a);
    private static bool color_class_set(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_color_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              bool _ret_var = default(bool);
         try {
            _ret_var = ((ColorClass)wrapper).SetColorClass( color_class,  layer,  r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                              return _ret_var;
      } else {
         return efl_gfx_color_class_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  r,  g,  b,  a);
      }
   }
   private efl_gfx_color_class_set_delegate efl_gfx_color_class_set_static_delegate;


    private delegate  System.IntPtr efl_gfx_color_class_description_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_gfx_color_class_description_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
    private static  System.IntPtr color_class_description_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class)
   {
      Eina.Log.Debug("function efl_gfx_color_class_description_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ColorClass)wrapper).GetColorClassDescription( color_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Efl.Eo.Globals.cached_string_to_intptr(((ColorClassConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_gfx_color_class_description_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
      }
   }
   private efl_gfx_color_class_description_get_delegate efl_gfx_color_class_description_get_static_delegate;


    private delegate  void efl_gfx_color_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class);
    private static  void color_class_del(System.IntPtr obj, System.IntPtr pd,   System.String color_class)
   {
      Eina.Log.Debug("function efl_gfx_color_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ColorClass)wrapper).DelColorClass( color_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_color_class_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class);
      }
   }
   private efl_gfx_color_class_del_delegate efl_gfx_color_class_del_static_delegate;


    private delegate  void efl_gfx_color_class_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_class_clear(System.IntPtr obj);
    private static  void color_class_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_color_class_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ColorClass)wrapper).ClearColorClass();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_color_class_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_color_class_clear_delegate efl_gfx_color_class_clear_static_delegate;
}
} } 
