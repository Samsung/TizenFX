#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Text Class interface</summary>
[TextClassConcreteNativeInherit]
public interface TextClass : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get font and font size from edje text class.
/// This function gets the font and the font size from text class. The font string will only be valid until the text class is changed or the edje object is deleted.</summary>
/// <param name="text_class">The text class name</param>
/// <param name="font">Font name</param>
/// <param name="size">Font Size</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool GetTextClass(  System.String text_class,  out  System.String font,  out Efl.Font.Size size);
   /// <summary>Set Edje text class.
/// This function sets the text class for the Edje.</summary>
/// <param name="text_class">The text class name</param>
/// <param name="font">Font name</param>
/// <param name="size">Font Size</param>
/// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
bool SetTextClass(  System.String text_class,   System.String font,  Efl.Font.Size size);
   /// <summary>Delete the text class.
/// This function deletes any values for the specified text class.
/// 
/// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.TextClass.GetTextClass"/> or the text class defined in the theme file.
/// 1.17</summary>
/// <param name="text_class">The text class to be deleted.</param>
/// <returns></returns>
 void DelTextClass(  System.String text_class);
         }
/// <summary>Efl Gfx Text Class interface</summary>
sealed public class TextClassConcrete : 

TextClass
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextClassConcrete))
            return Efl.Gfx.TextClassConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_text_class_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TextClassConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextClassConcrete()
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
   public static TextClassConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextClassConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_text_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
   /// <summary>Get font and font size from edje text class.
   /// This function gets the font and the font size from text class. The font string will only be valid until the text class is changed or the edje object is deleted.</summary>
   /// <param name="text_class">The text class name</param>
   /// <param name="font">Font name</param>
   /// <param name="size">Font Size</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   public bool GetTextClass(  System.String text_class,  out  System.String font,  out Efl.Font.Size size) {
                                                             var _ret_var = efl_gfx_text_class_get(Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get(),  text_class,  out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_text_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
   /// <summary>Set Edje text class.
   /// This function sets the text class for the Edje.</summary>
   /// <param name="text_class">The text class name</param>
   /// <param name="font">Font name</param>
   /// <param name="size">Font Size</param>
   /// <returns><c>true</c>, on success or <c>false</c>, on error</returns>
   public bool SetTextClass(  System.String text_class,   System.String font,  Efl.Font.Size size) {
                                                             var _ret_var = efl_gfx_text_class_set(Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get(),  text_class,  font,  size);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_text_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class);
   /// <summary>Delete the text class.
   /// This function deletes any values for the specified text class.
   /// 
   /// Deleting the text class will revert it to the values defined by <see cref="Efl.Gfx.TextClass.GetTextClass"/> or the text class defined in the theme file.
   /// 1.17</summary>
   /// <param name="text_class">The text class to be deleted.</param>
   /// <returns></returns>
   public  void DelTextClass(  System.String text_class) {
                         efl_gfx_text_class_del(Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get(),  text_class);
      Eina.Error.RaiseIfUnhandledException();
                   }
}
public class TextClassConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_text_class_get_static_delegate = new efl_gfx_text_class_get_delegate(text_class_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_text_class_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_get_static_delegate)});
      efl_gfx_text_class_set_static_delegate = new efl_gfx_text_class_set_delegate(text_class_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_text_class_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_set_static_delegate)});
      efl_gfx_text_class_del_static_delegate = new efl_gfx_text_class_del_delegate(text_class_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_text_class_del"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_text_class_del_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.TextClassConcrete.efl_gfx_text_class_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_text_class_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,   out  System.IntPtr font,   out Efl.Font.Size size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_text_class_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,   out  System.IntPtr font,   out Efl.Font.Size size);
    private static bool text_class_get(System.IntPtr obj, System.IntPtr pd,   System.String text_class,  out  System.IntPtr font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_gfx_text_class_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                        System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                           bool _ret_var = default(bool);
         try {
            _ret_var = ((TextClass)wrapper).GetTextClass( text_class,  out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            font= Efl.Eo.Globals.cached_string_to_intptr(((TextClassConcrete)wrapper).cached_strings, _out_font);
                              return _ret_var;
      } else {
         return efl_gfx_text_class_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class,  out font,  out size);
      }
   }
   private efl_gfx_text_class_get_delegate efl_gfx_text_class_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_text_class_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_text_class_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    private static bool text_class_set(System.IntPtr obj, System.IntPtr pd,   System.String text_class,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_gfx_text_class_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((TextClass)wrapper).SetTextClass( text_class,  font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_gfx_text_class_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class,  font,  size);
      }
   }
   private efl_gfx_text_class_set_delegate efl_gfx_text_class_set_static_delegate;


    private delegate  void efl_gfx_text_class_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_text_class_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text_class);
    private static  void text_class_del(System.IntPtr obj, System.IntPtr pd,   System.String text_class)
   {
      Eina.Log.Debug("function efl_gfx_text_class_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextClass)wrapper).DelTextClass( text_class);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_text_class_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text_class);
      }
   }
   private efl_gfx_text_class_del_delegate efl_gfx_text_class_del_static_delegate;
}
} } 
