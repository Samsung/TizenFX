#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Interface for all translatable text APIs.
/// This is intended for translation of human readable on-screen text strings but may also be used in text-to-speech situations.</summary>
[L10nNativeInherit]
public interface L10n : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>A unique string to be translated.
/// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
/// 
/// Setting this property will enable translation for this object or part.</summary>
/// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
/// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.Text.GetText"/>.</returns>
 System.String GetL10nText( out  System.String domain);
   /// <summary>Sets the new untranslated string and domain for this object.</summary>
/// <param name="label">A unique (untranslated) string.</param>
/// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
/// <returns></returns>
 void SetL10nText(  System.String label,   System.String domain);
   /// <summary>Requests this object to update its text strings for the current locale.
/// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
/// 
/// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.L10n.UpdateTranslation"/> to children objects.</summary>
/// <returns></returns>
 void UpdateTranslation();
         }
/// <summary>Interface for all translatable text APIs.
/// This is intended for translation of human readable on-screen text strings but may also be used in text-to-speech situations.</summary>
sealed public class L10nConcrete : 

L10n
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (L10nConcrete))
            return Efl.Ui.L10nNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_l10n_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public L10nConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~L10nConcrete()
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
   public static L10nConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new L10nConcrete(obj.NativeHandle);
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
   /// <summary>A unique string to be translated.
   /// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
   /// 
   /// Setting this property will enable translation for this object or part.</summary>
   /// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
   /// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.Text.GetText"/>.</returns>
   public  System.String GetL10nText( out  System.String domain) {
                         var _ret_var = Efl.Ui.L10nNativeInherit.efl_ui_l10n_text_get_ptr.Value.Delegate(this.NativeHandle, out domain);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Sets the new untranslated string and domain for this object.</summary>
   /// <param name="label">A unique (untranslated) string.</param>
   /// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
   /// <returns></returns>
   public  void SetL10nText(  System.String label,   System.String domain) {
                                           Efl.Ui.L10nNativeInherit.efl_ui_l10n_text_set_ptr.Value.Delegate(this.NativeHandle, label,  domain);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Requests this object to update its text strings for the current locale.
   /// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
   /// 
   /// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.L10n.UpdateTranslation"/> to children objects.</summary>
   /// <returns></returns>
   public  void UpdateTranslation() {
       Efl.Ui.L10nNativeInherit.efl_ui_l10n_translation_update_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class L10nNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_l10n_text_get_static_delegate == null)
      efl_ui_l10n_text_get_static_delegate = new efl_ui_l10n_text_get_delegate(l10n_text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_l10n_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_get_static_delegate)});
      if (efl_ui_l10n_text_set_static_delegate == null)
      efl_ui_l10n_text_set_static_delegate = new efl_ui_l10n_text_set_delegate(l10n_text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_l10n_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_set_static_delegate)});
      if (efl_ui_l10n_translation_update_static_delegate == null)
      efl_ui_l10n_translation_update_static_delegate = new efl_ui_l10n_translation_update_delegate(translation_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_l10n_translation_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_translation_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.L10nConcrete.efl_ui_l10n_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.L10nConcrete.efl_ui_l10n_interface_get();
   }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_ui_l10n_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String domain);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_ui_l10n_text_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String domain);
    public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate> efl_ui_l10n_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate>(_Module, "efl_ui_l10n_text_get");
    private static  System.String l10n_text_get(System.IntPtr obj, System.IntPtr pd,  out  System.String domain)
   {
      Eina.Log.Debug("function efl_ui_l10n_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                      System.String _out_domain = default( System.String);
                System.String _ret_var = default( System.String);
         try {
            _ret_var = ((L10n)wrapper).GetL10nText( out _out_domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      domain = _out_domain;
            return _ret_var;
      } else {
         return efl_ui_l10n_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out domain);
      }
   }
   private static efl_ui_l10n_text_get_delegate efl_ui_l10n_text_get_static_delegate;


    private delegate  void efl_ui_l10n_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);


    public delegate  void efl_ui_l10n_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String domain);
    public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate> efl_ui_l10n_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate>(_Module, "efl_ui_l10n_text_set");
    private static  void l10n_text_set(System.IntPtr obj, System.IntPtr pd,   System.String label,   System.String domain)
   {
      Eina.Log.Debug("function efl_ui_l10n_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((L10n)wrapper).SetL10nText( label,  domain);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_l10n_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  label,  domain);
      }
   }
   private static efl_ui_l10n_text_set_delegate efl_ui_l10n_text_set_static_delegate;


    private delegate  void efl_ui_l10n_translation_update_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_l10n_translation_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate> efl_ui_l10n_translation_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate>(_Module, "efl_ui_l10n_translation_update");
    private static  void translation_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_l10n_translation_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((L10n)wrapper).UpdateTranslation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_l10n_translation_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_l10n_translation_update_delegate efl_ui_l10n_translation_update_static_delegate;
}
} } 
