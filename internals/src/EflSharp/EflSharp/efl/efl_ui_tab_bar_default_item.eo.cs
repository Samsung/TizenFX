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

/// <summary>A icon that represents the default parts in the appearance of the tab bar.
/// Setting the icon again after there was a previous one, will trigger an animation.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.TabBarDefaultItem.NativeMethods]
[Efl.Eo.BindingEntity]
public class TabBarDefaultItem : Efl.Ui.DefaultItem
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TabBarDefaultItem))
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
        efl_ui_tab_bar_default_item_class_get();

    /// <summary>Initializes a new instance of the <see cref="TabBarDefaultItem"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public TabBarDefaultItem(Efl.Object parent
            , System.String style = null) : base(efl_ui_tab_bar_default_item_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected TabBarDefaultItem(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TabBarDefaultItem"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected TabBarDefaultItem(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TabBarDefaultItem"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TabBarDefaultItem(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Set the content of the default item as a image.
    /// The content will be re-set (means, the old content is deleted).</summary>
    /// <returns>The icon name, names are defined as standard free desktop icon names.</returns>
    public virtual System.String GetIcon() {
        var _ret_var = Efl.Ui.TabBarDefaultItem.NativeMethods.efl_ui_tab_bar_default_item_icon_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set the content of the default item as a image.
    /// The content will be re-set (means, the old content is deleted).</summary>
    /// <param name="standard_name">The icon name, names are defined as standard free desktop icon names.</param>
    public virtual void SetIcon(System.String standard_name) {
        Efl.Ui.TabBarDefaultItem.NativeMethods.efl_ui_tab_bar_default_item_icon_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),standard_name);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the content of the default item as a image.
    /// The content will be re-set (means, the old content is deleted).</summary>
    /// <value>The icon name, names are defined as standard free desktop icon names.</value>
    public System.String Icon {
        get { return GetIcon(); }
        set { SetIcon(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabBarDefaultItem.efl_ui_tab_bar_default_item_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.DefaultItem.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_tab_bar_default_item_icon_get_static_delegate == null)
            {
                efl_ui_tab_bar_default_item_icon_get_static_delegate = new efl_ui_tab_bar_default_item_icon_get_delegate(icon_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_default_item_icon_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_default_item_icon_get_static_delegate) });
            }

            if (efl_ui_tab_bar_default_item_icon_set_static_delegate == null)
            {
                efl_ui_tab_bar_default_item_icon_set_static_delegate = new efl_ui_tab_bar_default_item_icon_set_delegate(icon_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_default_item_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_default_item_icon_set_static_delegate) });
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
            return Efl.Ui.TabBarDefaultItem.efl_ui_tab_bar_default_item_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_tab_bar_default_item_icon_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_tab_bar_default_item_icon_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_default_item_icon_get_api_delegate> efl_ui_tab_bar_default_item_icon_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_default_item_icon_get_api_delegate>(Module, "efl_ui_tab_bar_default_item_icon_get");

        private static System.String icon_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_default_item_icon_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((TabBarDefaultItem)ws.Target).GetIcon();
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
                return efl_ui_tab_bar_default_item_icon_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_bar_default_item_icon_get_delegate efl_ui_tab_bar_default_item_icon_get_static_delegate;

        
        private delegate void efl_ui_tab_bar_default_item_icon_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String standard_name);

        
        public delegate void efl_ui_tab_bar_default_item_icon_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String standard_name);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_default_item_icon_set_api_delegate> efl_ui_tab_bar_default_item_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_default_item_icon_set_api_delegate>(Module, "efl_ui_tab_bar_default_item_icon_set");

        private static void icon_set(System.IntPtr obj, System.IntPtr pd, System.String standard_name)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_default_item_icon_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((TabBarDefaultItem)ws.Target).SetIcon(standard_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_tab_bar_default_item_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), standard_name);
            }
        }

        private static efl_ui_tab_bar_default_item_icon_set_delegate efl_ui_tab_bar_default_item_icon_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiTabBarDefaultItem_ExtensionMethods {
    public static Efl.BindableProperty<System.String> Icon<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.TabBarDefaultItem, T>magic = null) where T : Efl.Ui.TabBarDefaultItem {
        return new Efl.BindableProperty<System.String>("icon", fac);
    }

}
#pragma warning restore CS1591
#endif
