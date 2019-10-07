#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl Ui Theme class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Theme.NativeMethods]
[Efl.Eo.BindingEntity]
public class Theme : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Theme))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_theme_class_get();

    /// <summary>Initializes a new instance of the <see cref="Theme"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Theme(Efl.Object parent= null
            ) : base(efl_ui_theme_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Theme(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Theme"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Theme(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Theme"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Theme(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Gets the default theme handle.</summary>
    /// <returns>The default theme handle</returns>
    public static Efl.Ui.Theme GetDefault() {
        var _ret_var = Efl.Ui.Theme.NativeMethods.efl_ui_theme_default_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Appends a theme extension to the list of extensions. This is intended when an application needs more styles of widgets or new widget themes that the default does not provide (or may not provide). The application has &quot;extended&quot; usage by coming up with new custom style names for widgets for specific uses, but as these are not &quot;standard&quot;, they are not guaranteed to be provided by a default theme. This means the application is required to provide these extra elements itself in specific Edje files. This call adds one of those Edje files to the theme search path to be searched after the default theme. The use of this call is encouraged when default styles do not meet the needs of the application. Use this call instead of <see cref="Efl.Ui.Theme.AddOverlay"/> for almost all cases.</summary>
    /// <param name="item">The Edje file path to be used</param>
    public virtual void AddExtension(System.String item) {
        Efl.Ui.Theme.NativeMethods.efl_ui_theme_extension_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Deletes a theme extension from the list of extensions.</summary>
    /// <param name="item">The Edje file path not to be used</param>
    public virtual void DelExtension(System.String item) {
        Efl.Ui.Theme.NativeMethods.efl_ui_theme_extension_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Prepends a theme overlay to the list of overlays. Use this if your application needs to provide some custom overlay theme (An Edje file that replaces some default styles of widgets) where adding new styles, or changing system theme configuration is not possible. Do NOT use this instead of a proper system theme configuration. Use proper configuration files, profiles, environment variables etc. to set a theme so that the theme can be altered by simple configuration by a user. Using this call to achieve that effect is abusing the API and will create lots of trouble.</summary>
    /// <param name="item">The Edje file path to be used</param>
    public virtual void AddOverlay(System.String item) {
        Efl.Ui.Theme.NativeMethods.efl_ui_theme_overlay_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Delete a theme overlay from the list of overlays.</summary>
    /// <param name="item">The Edje file path not to be used</param>
    public virtual void DelOverlay(System.String item) {
        Efl.Ui.Theme.NativeMethods.efl_ui_theme_overlay_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This is the default theme.
    /// All widgets use the default theme implicitly unless a specific theme is set.</summary>
    /// <value>The default theme handle</value>
    public static Efl.Ui.Theme Default {
        get { return GetDefault(); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Theme.efl_ui_theme_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_theme_extension_add_static_delegate == null)
            {
                efl_ui_theme_extension_add_static_delegate = new efl_ui_theme_extension_add_delegate(extension_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddExtension") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_theme_extension_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_extension_add_static_delegate) });
            }

            if (efl_ui_theme_extension_del_static_delegate == null)
            {
                efl_ui_theme_extension_del_static_delegate = new efl_ui_theme_extension_del_delegate(extension_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelExtension") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_theme_extension_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_extension_del_static_delegate) });
            }

            if (efl_ui_theme_overlay_add_static_delegate == null)
            {
                efl_ui_theme_overlay_add_static_delegate = new efl_ui_theme_overlay_add_delegate(overlay_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddOverlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_theme_overlay_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_overlay_add_static_delegate) });
            }

            if (efl_ui_theme_overlay_del_static_delegate == null)
            {
                efl_ui_theme_overlay_del_static_delegate = new efl_ui_theme_overlay_del_delegate(overlay_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelOverlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_theme_overlay_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_theme_overlay_del_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Theme.efl_ui_theme_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Theme efl_ui_theme_default_get_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Theme efl_ui_theme_default_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_ui_theme_default_get_api_delegate> efl_ui_theme_default_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_theme_default_get_api_delegate>(Module, "efl_ui_theme_default_get");

        private static Efl.Ui.Theme default_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_theme_default_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Ui.Theme _ret_var = default(Efl.Ui.Theme);
                try
                {
                    _ret_var = Theme.GetDefault();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_ui_theme_default_get_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_ui_theme_extension_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        
        public delegate void efl_ui_theme_extension_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        public static Efl.Eo.FunctionWrapper<efl_ui_theme_extension_add_api_delegate> efl_ui_theme_extension_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_theme_extension_add_api_delegate>(Module, "efl_ui_theme_extension_add");

        private static void extension_add(System.IntPtr obj, System.IntPtr pd, System.String item)
        {
            Eina.Log.Debug("function efl_ui_theme_extension_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Theme)ws.Target).AddExtension(item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_theme_extension_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item);
            }
        }

        private static efl_ui_theme_extension_add_delegate efl_ui_theme_extension_add_static_delegate;

        
        private delegate void efl_ui_theme_extension_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        
        public delegate void efl_ui_theme_extension_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        public static Efl.Eo.FunctionWrapper<efl_ui_theme_extension_del_api_delegate> efl_ui_theme_extension_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_theme_extension_del_api_delegate>(Module, "efl_ui_theme_extension_del");

        private static void extension_del(System.IntPtr obj, System.IntPtr pd, System.String item)
        {
            Eina.Log.Debug("function efl_ui_theme_extension_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Theme)ws.Target).DelExtension(item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_theme_extension_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item);
            }
        }

        private static efl_ui_theme_extension_del_delegate efl_ui_theme_extension_del_static_delegate;

        
        private delegate void efl_ui_theme_overlay_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        
        public delegate void efl_ui_theme_overlay_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        public static Efl.Eo.FunctionWrapper<efl_ui_theme_overlay_add_api_delegate> efl_ui_theme_overlay_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_theme_overlay_add_api_delegate>(Module, "efl_ui_theme_overlay_add");

        private static void overlay_add(System.IntPtr obj, System.IntPtr pd, System.String item)
        {
            Eina.Log.Debug("function efl_ui_theme_overlay_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Theme)ws.Target).AddOverlay(item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_theme_overlay_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item);
            }
        }

        private static efl_ui_theme_overlay_add_delegate efl_ui_theme_overlay_add_static_delegate;

        
        private delegate void efl_ui_theme_overlay_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        
        public delegate void efl_ui_theme_overlay_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String item);

        public static Efl.Eo.FunctionWrapper<efl_ui_theme_overlay_del_api_delegate> efl_ui_theme_overlay_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_theme_overlay_del_api_delegate>(Module, "efl_ui_theme_overlay_del");

        private static void overlay_del(System.IntPtr obj, System.IntPtr pd, System.String item)
        {
            Eina.Log.Debug("function efl_ui_theme_overlay_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Theme)ws.Target).DelOverlay(item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_theme_overlay_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item);
            }
        }

        private static efl_ui_theme_overlay_del_delegate efl_ui_theme_overlay_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiTheme_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
