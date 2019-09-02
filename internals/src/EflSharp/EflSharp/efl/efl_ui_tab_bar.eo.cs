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

/// <summary>Tab Bar class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.TabBar.NativeMethods]
[Efl.Eo.BindingEntity]
public class TabBar : Efl.Ui.LayoutBase
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TabBar))
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
        efl_ui_tab_bar_class_get();
    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public TabBar(Efl.Object parent
            , System.String style = null) : base(efl_ui_tab_bar_class_get(), parent)
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
    protected TabBar(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected TabBar(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TabBar(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    virtual public int GetCurrentTab() {
         var _ret_var = Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public void SetCurrentTab(int index) {
                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    virtual public uint TabCount() {
         var _ret_var = Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public void AddTab(int index, System.String label, System.String icon) {
                                                                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index, label, icon);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    virtual public void TabRemove(int index) {
                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    virtual public void SetTabLabel(int index, System.String label) {
                                                         Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index, label);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    virtual public void SetTabIcon(int index, System.String icon) {
                                                         Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),index, icon);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    public int CurrentTab {
        get { return GetCurrentTab(); }
        set { SetCurrentTab(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_tab_bar_current_tab_get_static_delegate == null)
            {
                efl_ui_tab_bar_current_tab_get_static_delegate = new efl_ui_tab_bar_current_tab_get_delegate(current_tab_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCurrentTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_current_tab_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_get_static_delegate) });
            }

            if (efl_ui_tab_bar_current_tab_set_static_delegate == null)
            {
                efl_ui_tab_bar_current_tab_set_static_delegate = new efl_ui_tab_bar_current_tab_set_delegate(current_tab_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCurrentTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_current_tab_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_set_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_count_static_delegate == null)
            {
                efl_ui_tab_bar_tab_count_static_delegate = new efl_ui_tab_bar_tab_count_delegate(tab_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "TabCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_count"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_count_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_add_static_delegate == null)
            {
                efl_ui_tab_bar_tab_add_static_delegate = new efl_ui_tab_bar_tab_add_delegate(tab_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_add_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_remove_static_delegate == null)
            {
                efl_ui_tab_bar_tab_remove_static_delegate = new efl_ui_tab_bar_tab_remove_delegate(tab_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "TabRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_remove_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_label_set_static_delegate == null)
            {
                efl_ui_tab_bar_tab_label_set_static_delegate = new efl_ui_tab_bar_tab_label_set_delegate(tab_label_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabLabel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_label_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_label_set_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_icon_set_static_delegate == null)
            {
                efl_ui_tab_bar_tab_icon_set_static_delegate = new efl_ui_tab_bar_tab_icon_set_delegate(tab_icon_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_icon_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_tab_bar_current_tab_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_tab_bar_current_tab_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate> efl_ui_tab_bar_current_tab_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate>(Module, "efl_ui_tab_bar_current_tab_get");

        private static int current_tab_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_current_tab_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((TabBar)ws.Target).GetCurrentTab();
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
                return efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_bar_current_tab_get_delegate efl_ui_tab_bar_current_tab_get_static_delegate;

        
        private delegate void efl_ui_tab_bar_current_tab_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        
        public delegate void efl_ui_tab_bar_current_tab_set_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate> efl_ui_tab_bar_current_tab_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate>(Module, "efl_ui_tab_bar_current_tab_set");

        private static void current_tab_set(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_current_tab_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((TabBar)ws.Target).SetCurrentTab(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_ui_tab_bar_current_tab_set_delegate efl_ui_tab_bar_current_tab_set_static_delegate;

        
        private delegate uint efl_ui_tab_bar_tab_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_ui_tab_bar_tab_count_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate> efl_ui_tab_bar_tab_count_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate>(Module, "efl_ui_tab_bar_tab_count");

        private static uint tab_count(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_count was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((TabBar)ws.Target).TabCount();
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
                return efl_ui_tab_bar_tab_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_bar_tab_count_delegate efl_ui_tab_bar_tab_count_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_add_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        
        public delegate void efl_ui_tab_bar_tab_add_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate> efl_ui_tab_bar_tab_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate>(Module, "efl_ui_tab_bar_tab_add");

        private static void tab_add(System.IntPtr obj, System.IntPtr pd, int index, System.String label, System.String icon)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((TabBar)ws.Target).AddTab(index, label, icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_tab_bar_tab_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, label, icon);
            }
        }

        private static efl_ui_tab_bar_tab_add_delegate efl_ui_tab_bar_tab_add_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_remove_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        
        public delegate void efl_ui_tab_bar_tab_remove_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate> efl_ui_tab_bar_tab_remove_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate>(Module, "efl_ui_tab_bar_tab_remove");

        private static void tab_remove(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_remove was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((TabBar)ws.Target).TabRemove(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tab_bar_tab_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_ui_tab_bar_tab_remove_delegate efl_ui_tab_bar_tab_remove_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_label_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label);

        
        public delegate void efl_ui_tab_bar_tab_label_set_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate> efl_ui_tab_bar_tab_label_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate>(Module, "efl_ui_tab_bar_tab_label_set");

        private static void tab_label_set(System.IntPtr obj, System.IntPtr pd, int index, System.String label)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_label_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((TabBar)ws.Target).SetTabLabel(index, label);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, label);
            }
        }

        private static efl_ui_tab_bar_tab_label_set_delegate efl_ui_tab_bar_tab_label_set_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_icon_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        
        public delegate void efl_ui_tab_bar_tab_icon_set_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate> efl_ui_tab_bar_tab_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate>(Module, "efl_ui_tab_bar_tab_icon_set");

        private static void tab_icon_set(System.IntPtr obj, System.IntPtr pd, int index, System.String icon)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_icon_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((TabBar)ws.Target).SetTabIcon(index, icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, icon);
            }
        }

        private static efl_ui_tab_bar_tab_icon_set_delegate efl_ui_tab_bar_tab_icon_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiTabBar_ExtensionMethods {
    public static Efl.BindableProperty<int> CurrentTab<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.TabBar, T>magic = null) where T : Efl.Ui.TabBar {
        return new Efl.BindableProperty<int>("current_tab", fac);
    }

}
#pragma warning restore CS1591
#endif
