#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Theme class</summary>
[ThemeNativeInherit]
public class Theme : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ThemeNativeInherit nativeInherit = new Efl.Ui.ThemeNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Theme))
            return Efl.Ui.ThemeNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Theme obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_theme_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Theme(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Theme", efl_ui_theme_class_get(), typeof(Theme), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Theme(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Theme(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Theme static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Theme(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Theme, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Theme efl_ui_theme_default_get(System.IntPtr obj);
   /// <summary>Gets the default theme handle.</summary>
   /// <returns>The default theme handle</returns>
   public static Efl.Ui.Theme GetDefault() {
       var _ret_var = efl_ui_theme_default_get(Efl.Ui.Theme.efl_ui_theme_class_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_theme_extension_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   /// <summary>Appends a theme extension to the list of extensions. This is intended when an application needs more styles of widgets or new widget themes that the default does not provide (or may not provide). The application has &quot;extended&quot; usage by coming up with new custom style names for widgets for specific uses, but as these are not &quot;standard&quot;, they are not guaranteed to be provided by a default theme. This means the application is required to provide these extra elements itself in specific Edje files. This call adds one of those Edje files to the theme search path to be searched after the default theme. The use of this call is encouraged when default styles do not meet the needs of the application. Use this call instead of <see cref="Efl.Ui.Theme.AddOverlay"/> for almost all cases.</summary>
   /// <param name="item">The Edje file path to be used</param>
   /// <returns></returns>
   virtual public  void AddExtension(  System.String item) {
                         efl_ui_theme_extension_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  item);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_theme_extension_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   /// <summary>Deletes a theme extension from the list of extensions.</summary>
   /// <param name="item">The Edje file path not to be used</param>
   /// <returns></returns>
   virtual public  void DelExtension(  System.String item) {
                         efl_ui_theme_extension_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  item);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_theme_overlay_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   /// <summary>Prepends a theme overlay to the list of overlays. Use this if your application needs to provide some custom overlay theme (An Edje file that replaces some default styles of widgets) where adding new styles, or changing system theme configuration is not possible. Do NOT use this instead of a proper system theme configuration. Use proper configuration files, profiles, environment variables etc. to set a theme so that the theme can be altered by simple configuration by a user. Using this call to achieve that effect is abusing the API and will create lots of trouble.</summary>
   /// <param name="item">The Edje file path to be used</param>
   /// <returns></returns>
   virtual public  void AddOverlay(  System.String item) {
                         efl_ui_theme_overlay_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  item);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_theme_overlay_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   /// <summary>Delete a theme overlay from the list of overlays.</summary>
   /// <param name="item">The Edje file path not to be used</param>
   /// <returns></returns>
   virtual public  void DelOverlay(  System.String item) {
                         efl_ui_theme_overlay_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  item);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This is the default theme.
/// All widgets use the default theme implicitly unless a specific theme is set.</summary>
   public static Efl.Ui.Theme Default {
      get { return GetDefault(); }
   }
}
public class ThemeNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_theme_extension_add_static_delegate = new efl_ui_theme_extension_add_delegate(extension_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_theme_extension_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_extension_add_static_delegate)});
      efl_ui_theme_extension_del_static_delegate = new efl_ui_theme_extension_del_delegate(extension_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_theme_extension_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_extension_del_static_delegate)});
      efl_ui_theme_overlay_add_static_delegate = new efl_ui_theme_overlay_add_delegate(overlay_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_theme_overlay_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_overlay_add_static_delegate)});
      efl_ui_theme_overlay_del_static_delegate = new efl_ui_theme_overlay_del_delegate(overlay_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_theme_overlay_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_overlay_del_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Theme.efl_ui_theme_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Theme.efl_ui_theme_class_get();
   }


    private delegate  void efl_ui_theme_extension_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_theme_extension_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
    private static  void extension_add(System.IntPtr obj, System.IntPtr pd,   System.String item)
   {
      Eina.Log.Debug("function efl_ui_theme_extension_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Theme)wrapper).AddExtension( item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_theme_extension_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item);
      }
   }
   private efl_ui_theme_extension_add_delegate efl_ui_theme_extension_add_static_delegate;


    private delegate  void efl_ui_theme_extension_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_theme_extension_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
    private static  void extension_del(System.IntPtr obj, System.IntPtr pd,   System.String item)
   {
      Eina.Log.Debug("function efl_ui_theme_extension_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Theme)wrapper).DelExtension( item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_theme_extension_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item);
      }
   }
   private efl_ui_theme_extension_del_delegate efl_ui_theme_extension_del_static_delegate;


    private delegate  void efl_ui_theme_overlay_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_theme_overlay_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
    private static  void overlay_add(System.IntPtr obj, System.IntPtr pd,   System.String item)
   {
      Eina.Log.Debug("function efl_ui_theme_overlay_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Theme)wrapper).AddOverlay( item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_theme_overlay_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item);
      }
   }
   private efl_ui_theme_overlay_add_delegate efl_ui_theme_overlay_add_static_delegate;


    private delegate  void efl_ui_theme_overlay_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_theme_overlay_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String item);
    private static  void overlay_del(System.IntPtr obj, System.IntPtr pd,   System.String item)
   {
      Eina.Log.Debug("function efl_ui_theme_overlay_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Theme)wrapper).DelOverlay( item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_theme_overlay_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item);
      }
   }
   private efl_ui_theme_overlay_del_delegate efl_ui_theme_overlay_del_static_delegate;
}
} } 
