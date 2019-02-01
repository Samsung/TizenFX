#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>A common Internationalization interface for UI objects.</summary>
[I18nConcreteNativeInherit]
public interface I18n : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
/// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
bool GetMirrored();
   /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
/// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
/// <returns></returns>
 void SetMirrored( bool rtl);
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
/// <returns>Whether the widget uses automatic mirroring</returns>
bool GetMirroredAutomatic();
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
/// <param name="automatic">Whether the widget uses automatic mirroring</param>
/// <returns></returns>
 void SetMirroredAutomatic( bool automatic);
   /// <summary>Gets the language for this object.</summary>
/// <returns>The current language.</returns>
 System.String GetLanguage();
   /// <summary>Sets the language for this object.</summary>
/// <param name="language">The current language.</param>
/// <returns></returns>
 void SetLanguage(  System.String language);
                     /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   bool Mirrored {
      get ;
      set ;
   }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   bool MirroredAutomatic {
      get ;
      set ;
   }
   /// <summary>The (human) language for this object.</summary>
    System.String Language {
      get ;
      set ;
   }
}
/// <summary>A common Internationalization interface for UI objects.</summary>
sealed public class I18nConcrete : 

I18n
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (I18nConcrete))
            return Efl.Ui.I18nConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_i18n_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public I18nConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~I18nConcrete()
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
   public static I18nConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new I18nConcrete(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_get(System.IntPtr obj);
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
   public bool GetMirrored() {
       var _ret_var = efl_ui_mirrored_get(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_mirrored_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
   /// <returns></returns>
   public  void SetMirrored( bool rtl) {
                         efl_ui_mirrored_set(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get(),  rtl);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_automatic_get(System.IntPtr obj);
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <returns>Whether the widget uses automatic mirroring</returns>
   public bool GetMirroredAutomatic() {
       var _ret_var = efl_ui_mirrored_automatic_get(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_mirrored_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <param name="automatic">Whether the widget uses automatic mirroring</param>
   /// <returns></returns>
   public  void SetMirroredAutomatic( bool automatic) {
                         efl_ui_mirrored_automatic_set(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get(),  automatic);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_ui_language_get(System.IntPtr obj);
   /// <summary>Gets the language for this object.</summary>
   /// <returns>The current language.</returns>
   public  System.String GetLanguage() {
       var _ret_var = efl_ui_language_get(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_language_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
   /// <summary>Sets the language for this object.</summary>
   /// <param name="language">The current language.</param>
   /// <returns></returns>
   public  void SetLanguage(  System.String language) {
                         efl_ui_language_set(Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get(),  language);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   public bool Mirrored {
      get { return GetMirrored(); }
      set { SetMirrored( value); }
   }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   public bool MirroredAutomatic {
      get { return GetMirroredAutomatic(); }
      set { SetMirroredAutomatic( value); }
   }
   /// <summary>The (human) language for this object.</summary>
   public  System.String Language {
      get { return GetLanguage(); }
      set { SetLanguage( value); }
   }
}
public class I18nConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_mirrored_get_static_delegate = new efl_ui_mirrored_get_delegate(mirrored_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_get_static_delegate)});
      efl_ui_mirrored_set_static_delegate = new efl_ui_mirrored_set_delegate(mirrored_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_set_static_delegate)});
      efl_ui_mirrored_automatic_get_static_delegate = new efl_ui_mirrored_automatic_get_delegate(mirrored_automatic_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_get_static_delegate)});
      efl_ui_mirrored_automatic_set_static_delegate = new efl_ui_mirrored_automatic_set_delegate(mirrored_automatic_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_set_static_delegate)});
      efl_ui_language_get_static_delegate = new efl_ui_language_get_delegate(language_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_get_static_delegate)});
      efl_ui_language_set_static_delegate = new efl_ui_language_set_delegate(language_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.I18nConcrete.efl_ui_i18n_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_get(System.IntPtr obj);
    private static bool mirrored_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_mirrored_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((I18n)wrapper).GetMirrored();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_mirrored_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_mirrored_get_delegate efl_ui_mirrored_get_static_delegate;


    private delegate  void efl_ui_mirrored_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_mirrored_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
    private static  void mirrored_set(System.IntPtr obj, System.IntPtr pd,  bool rtl)
   {
      Eina.Log.Debug("function efl_ui_mirrored_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((I18n)wrapper).SetMirrored( rtl);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_mirrored_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rtl);
      }
   }
   private efl_ui_mirrored_set_delegate efl_ui_mirrored_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_automatic_get(System.IntPtr obj);
    private static bool mirrored_automatic_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_mirrored_automatic_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((I18n)wrapper).GetMirroredAutomatic();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_mirrored_automatic_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_mirrored_automatic_get_delegate efl_ui_mirrored_automatic_get_static_delegate;


    private delegate  void efl_ui_mirrored_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_mirrored_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
    private static  void mirrored_automatic_set(System.IntPtr obj, System.IntPtr pd,  bool automatic)
   {
      Eina.Log.Debug("function efl_ui_mirrored_automatic_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((I18n)wrapper).SetMirroredAutomatic( automatic);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_mirrored_automatic_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  automatic);
      }
   }
   private efl_ui_mirrored_automatic_set_delegate efl_ui_mirrored_automatic_set_static_delegate;


    private delegate  System.IntPtr efl_ui_language_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_ui_language_get(System.IntPtr obj);
    private static  System.IntPtr language_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_language_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((I18n)wrapper).GetLanguage();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((I18nConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_language_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_language_get_delegate efl_ui_language_get_static_delegate;


    private delegate  void efl_ui_language_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_language_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
    private static  void language_set(System.IntPtr obj, System.IntPtr pd,   System.String language)
   {
      Eina.Log.Debug("function efl_ui_language_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((I18n)wrapper).SetLanguage( language);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_language_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  language);
      }
   }
   private efl_ui_language_set_delegate efl_ui_language_set_static_delegate;
}
} } 
