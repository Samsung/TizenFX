#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
[Efl.Ui.IMultiSelectableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IMultiSelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The mode type for children selection.</summary>
/// <returns>Type of selection of children</returns>
Efl.Ui.SelectMode GetSelectMode();
    /// <summary>The mode type for children selection.</summary>
/// <param name="mode">Type of selection of children</param>
void SetSelectMode(Efl.Ui.SelectMode mode);
            /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    Efl.Ui.SelectMode SelectMode {
        get ;
        set ;
    }
}
/// <summary>Efl UI Multi selectable interface. The container have to control select property of multiple chidren.</summary>
sealed public class IMultiSelectableConcrete :
    Efl.Eo.EoWrapper
    , IMultiSelectable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IMultiSelectableConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IMultiSelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_multi_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IMultiSelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IMultiSelectableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    public Efl.Ui.SelectMode GetSelectMode() {
         var _ret_var = Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    public void SetSelectMode(Efl.Ui.SelectMode mode) {
                                 Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_set_ptr.Value.Delegate(this.NativeHandle,mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    public Efl.Ui.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IMultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_select_mode_get_static_delegate == null)
            {
                efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate) });
            }

            if (efl_ui_select_mode_set_static_delegate == null)
            {
                efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IMultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectMode efl_ui_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate> efl_ui_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate>(Module, "efl_ui_select_mode_get");

        private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
                try
                {
                    _ret_var = ((IMultiSelectable)ws.Target).GetSelectMode();
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
                return efl_ui_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;

        
        private delegate void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode);

        
        public delegate void efl_ui_select_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate> efl_ui_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate>(Module, "efl_ui_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_select_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IMultiSelectable)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Type of multi selectable object.</summary>
[Efl.Eo.BindingEntity]
public enum SelectMode
{
/// <summary>Only single child is selected. if the child is selected, previous selected child will be unselected.</summary>
Single = 0,
/// <summary>Same as single select except, this will be selected in every select calls though child is already been selected.</summary>
SingleAlways = 1,
/// <summary>allow multiple selection of children.</summary>
Multi = 2,
/// <summary>Last value of select mode. child cannot be selected at all.</summary>
None = 3,
}

}

}

