#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary layout internal part class</summary>
[LayoutPartNativeInherit]
public class LayoutPart : Efl.Ui.WidgetPart, Efl.Eo.IWrapper,Efl.Ui.Cursor
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.LayoutPartNativeInherit nativeInherit = new Efl.Ui.LayoutPartNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LayoutPart))
            return Efl.Ui.LayoutPartNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LayoutPart obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_layout_part_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LayoutPart(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LayoutPart", efl_ui_layout_part_class_get(), typeof(LayoutPart), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LayoutPart(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LayoutPart(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LayoutPart static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LayoutPart(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_cursor_get(System.IntPtr obj);
   /// <summary>Returns the current cursor name.</summary>
   /// <returns>The cursor name, defined either by the display system or the theme.</returns>
   virtual public  System.String GetCursor() {
       var _ret_var = efl_ui_cursor_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
   /// <summary>Sets or unsets the current cursor.
   /// If <c>cursor</c> is <c>null</c> this function will reset the cursor to the default one.</summary>
   /// <param name="cursor">The cursor name, defined either by the display system or the theme.</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursor(  System.String cursor) {
                         var _ret_var = efl_ui_cursor_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  cursor);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_cursor_style_get(System.IntPtr obj);
   /// <summary>Returns the current cursor style name.</summary>
   /// <returns>A specific style to use, eg. default, transparent, ....</returns>
   virtual public  System.String GetCursorStyle() {
       var _ret_var = efl_ui_cursor_style_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   /// <summary>Sets a style for the current cursor. Call after <see cref="Efl.Ui.Cursor.SetCursor"/>.</summary>
   /// <param name="style">A specific style to use, eg. default, transparent, ....</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursorStyle(  System.String style) {
                         var _ret_var = efl_ui_cursor_style_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_theme_search_enabled_get(System.IntPtr obj);
   /// <summary>Returns the current state of theme cursors search.</summary>
   /// <returns>Whether to use theme cursors.</returns>
   virtual public bool GetCursorThemeSearchEnabled() {
       var _ret_var = efl_ui_cursor_theme_search_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_cursor_theme_search_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   /// <summary>Enables or disables theme cursors.</summary>
   /// <param name="allow">Whether to use theme cursors.</param>
   /// <returns><c>true</c> if successful.</returns>
   virtual public bool SetCursorThemeSearchEnabled( bool allow) {
                         var _ret_var = efl_ui_cursor_theme_search_enabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  allow);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>The cursor to be shown when mouse is over the object
/// This is the cursor that will be displayed when mouse is over the object. The object can have only one cursor set to it so if <see cref="Efl.Ui.Cursor.SetCursor"/> is called twice for an object, the previous set will be unset.
/// 
/// If using X cursors, a definition of all the valid cursor names is listed on Elementary_Cursors.h. If an invalid name is set the default cursor will be used.</summary>
   public  System.String Cursor {
      get { return GetCursor(); }
      set { SetCursor( value); }
   }
   /// <summary>A different style for the cursor.
/// This only makes sense if theme cursors are used. The cursor should be set with <see cref="Efl.Ui.Cursor.SetCursor"/> first before setting its style with this property.</summary>
   public  System.String CursorStyle {
      get { return GetCursorStyle(); }
      set { SetCursorStyle( value); }
   }
   /// <summary>Whether the cursor may be looked in the theme or not.
/// If <c>false</c>, the cursor may only come from the render engine, i.e. from the display manager.</summary>
   public bool CursorThemeSearchEnabled {
      get { return GetCursorThemeSearchEnabled(); }
      set { SetCursorThemeSearchEnabled( value); }
   }
}
public class LayoutPartNativeInherit : Efl.Ui.WidgetPartNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_cursor_get_static_delegate = new efl_ui_cursor_get_delegate(cursor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_get_static_delegate)});
      efl_ui_cursor_set_static_delegate = new efl_ui_cursor_set_delegate(cursor_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_set_static_delegate)});
      efl_ui_cursor_style_get_static_delegate = new efl_ui_cursor_style_get_delegate(cursor_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_style_get_static_delegate)});
      efl_ui_cursor_style_set_static_delegate = new efl_ui_cursor_style_set_delegate(cursor_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_style_set_static_delegate)});
      efl_ui_cursor_theme_search_enabled_get_static_delegate = new efl_ui_cursor_theme_search_enabled_get_delegate(cursor_theme_search_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_theme_search_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_theme_search_enabled_get_static_delegate)});
      efl_ui_cursor_theme_search_enabled_set_static_delegate = new efl_ui_cursor_theme_search_enabled_set_delegate(cursor_theme_search_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_cursor_theme_search_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_cursor_theme_search_enabled_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.LayoutPart.efl_ui_layout_part_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.LayoutPart.efl_ui_layout_part_class_get();
   }


    private delegate  System.IntPtr efl_ui_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_cursor_get(System.IntPtr obj);
    private static  System.IntPtr cursor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPart)wrapper).GetCursor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPart)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_cursor_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_get_delegate efl_ui_cursor_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cursor);
    private static bool cursor_set(System.IntPtr obj, System.IntPtr pd,   System.String cursor)
   {
      Eina.Log.Debug("function efl_ui_cursor_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetCursor( cursor);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cursor);
      }
   }
   private efl_ui_cursor_set_delegate efl_ui_cursor_set_static_delegate;


    private delegate  System.IntPtr efl_ui_cursor_style_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_cursor_style_get(System.IntPtr obj);
    private static  System.IntPtr cursor_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((LayoutPart)wrapper).GetCursorStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((LayoutPart)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_cursor_style_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_style_get_delegate efl_ui_cursor_style_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String style);
    private static bool cursor_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function efl_ui_cursor_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetCursorStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_style_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_ui_cursor_style_set_delegate efl_ui_cursor_style_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_theme_search_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_theme_search_enabled_get(System.IntPtr obj);
    private static bool cursor_theme_search_enabled_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_cursor_theme_search_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).GetCursorThemeSearchEnabled();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_cursor_theme_search_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_cursor_theme_search_enabled_get_delegate efl_ui_cursor_theme_search_enabled_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_cursor_theme_search_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool allow);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_cursor_theme_search_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool allow);
    private static bool cursor_theme_search_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool allow)
   {
      Eina.Log.Debug("function efl_ui_cursor_theme_search_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((LayoutPart)wrapper).SetCursorThemeSearchEnabled( allow);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_cursor_theme_search_enabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  allow);
      }
   }
   private efl_ui_cursor_theme_search_enabled_set_delegate efl_ui_cursor_theme_search_enabled_set_static_delegate;
}
} } 
