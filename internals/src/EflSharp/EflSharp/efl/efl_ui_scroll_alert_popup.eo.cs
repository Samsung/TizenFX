#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>EFL UI Scroll Alert Popup class</summary>
[Efl.Ui.ScrollAlertPopup.NativeMethods]
public class ScrollAlertPopup : Efl.Ui.AlertPopup
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ScrollAlertPopup))
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
        efl_ui_scroll_alert_popup_class_get();
    /// <summary>Initializes a new instance of the <see cref="ScrollAlertPopup"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public ScrollAlertPopup(Efl.Object parent
            , System.String style = null) : base(efl_ui_scroll_alert_popup_class_get(), typeof(ScrollAlertPopup), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="ScrollAlertPopup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected ScrollAlertPopup(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ScrollAlertPopup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ScrollAlertPopup(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Get the expandable max size of popup.
    /// If the given max_size is -1, then popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
    /// <returns>A 2D max size in pixel units.</returns>
    virtual public Eina.Size2D GetExpandable() {
         var _ret_var = Efl.Ui.ScrollAlertPopup.NativeMethods.efl_ui_scroll_alert_popup_expandable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the expandable max size of popup.
    /// If the given max_size is -1, then a popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
    /// <param name="max_size">A 2D max size in pixel units.</param>
    virtual public void SetExpandable(Eina.Size2D max_size) {
         Eina.Size2D.NativeStruct _in_max_size = max_size;
                        Efl.Ui.ScrollAlertPopup.NativeMethods.efl_ui_scroll_alert_popup_expandable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_max_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the expandable max size of popup.
    /// If the given max_size is -1, then popup appears with its size. However, if the given max_size is bigger than 0 the popup size is up to the given max_size. If popup content&apos;s min size is bigger than the given max_size the scroller appears in the popup content area.</summary>
    /// <value>A 2D max size in pixel units.</value>
    public Eina.Size2D Expandable {
        get { return GetExpandable(); }
        set { SetExpandable(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ScrollAlertPopup.efl_ui_scroll_alert_popup_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.AlertPopup.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_scroll_alert_popup_expandable_get_static_delegate == null)
            {
                efl_ui_scroll_alert_popup_expandable_get_static_delegate = new efl_ui_scroll_alert_popup_expandable_get_delegate(expandable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExpandable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scroll_alert_popup_expandable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scroll_alert_popup_expandable_get_static_delegate) });
            }

            if (efl_ui_scroll_alert_popup_expandable_set_static_delegate == null)
            {
                efl_ui_scroll_alert_popup_expandable_set_static_delegate = new efl_ui_scroll_alert_popup_expandable_set_delegate(expandable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExpandable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scroll_alert_popup_expandable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scroll_alert_popup_expandable_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ScrollAlertPopup.efl_ui_scroll_alert_popup_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_ui_scroll_alert_popup_expandable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_scroll_alert_popup_expandable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scroll_alert_popup_expandable_get_api_delegate> efl_ui_scroll_alert_popup_expandable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scroll_alert_popup_expandable_get_api_delegate>(Module, "efl_ui_scroll_alert_popup_expandable_get");

        private static Eina.Size2D.NativeStruct expandable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scroll_alert_popup_expandable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((ScrollAlertPopup)ws.Target).GetExpandable();
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
                return efl_ui_scroll_alert_popup_expandable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scroll_alert_popup_expandable_get_delegate efl_ui_scroll_alert_popup_expandable_get_static_delegate;

        
        private delegate void efl_ui_scroll_alert_popup_expandable_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct max_size);

        
        public delegate void efl_ui_scroll_alert_popup_expandable_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct max_size);

        public static Efl.Eo.FunctionWrapper<efl_ui_scroll_alert_popup_expandable_set_api_delegate> efl_ui_scroll_alert_popup_expandable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scroll_alert_popup_expandable_set_api_delegate>(Module, "efl_ui_scroll_alert_popup_expandable_set");

        private static void expandable_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct max_size)
        {
            Eina.Log.Debug("function efl_ui_scroll_alert_popup_expandable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_max_size = max_size;
                            
                try
                {
                    ((ScrollAlertPopup)ws.Target).SetExpandable(_in_max_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scroll_alert_popup_expandable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), max_size);
            }
        }

        private static efl_ui_scroll_alert_popup_expandable_set_delegate efl_ui_scroll_alert_popup_expandable_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

