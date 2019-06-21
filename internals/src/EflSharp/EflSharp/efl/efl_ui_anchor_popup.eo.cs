#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>EFL UI Anchor Popup class</summary>
[Efl.Ui.AnchorPopup.NativeMethods]
public class AnchorPopup : Efl.Ui.Popup
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AnchorPopup))
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
        efl_ui_anchor_popup_class_get();
    /// <summary>Initializes a new instance of the <see cref="AnchorPopup"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public AnchorPopup(Efl.Object parent
            , System.String style = null) : base(efl_ui_anchor_popup_class_get(), typeof(AnchorPopup), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="AnchorPopup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected AnchorPopup(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnchorPopup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AnchorPopup(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Returns the anchor object which the popup is following.</summary>
    /// <returns>The object which popup is following.</returns>
    virtual public Efl.Canvas.Object GetAnchor() {
         var _ret_var = Efl.Ui.AnchorPopup.NativeMethods.efl_ui_anchor_popup_anchor_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set anchor popup to follow an anchor object. If anchor object is moved or parent window is resized, the anchor popup moves to the new position. If anchor object is set to NULL, the anchor popup stops following the anchor object. When the popup is moved by using gfx_position_set, anchor is set NULL.</summary>
    /// <param name="anchor">The object which popup is following.</param>
    virtual public void SetAnchor(Efl.Canvas.Object anchor) {
                                 Efl.Ui.AnchorPopup.NativeMethods.efl_ui_anchor_popup_anchor_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),anchor);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the align priority of a popup.</summary>
    /// <param name="first">First align priority</param>
    /// <param name="second">Second align priority</param>
    /// <param name="third">Third align priority</param>
    /// <param name="fourth">Fourth align priority</param>
    /// <param name="fifth">Fifth align priority</param>
    virtual public void GetAlignPriority(out Efl.Ui.PopupAlign first, out Efl.Ui.PopupAlign second, out Efl.Ui.PopupAlign third, out Efl.Ui.PopupAlign fourth, out Efl.Ui.PopupAlign fifth) {
                                                                                                                                 Efl.Ui.AnchorPopup.NativeMethods.efl_ui_anchor_popup_align_priority_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out first, out second, out third, out fourth, out fifth);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the align priority of a popup.</summary>
    /// <param name="first">First align priority</param>
    /// <param name="second">Second align priority</param>
    /// <param name="third">Third align priority</param>
    /// <param name="fourth">Fourth align priority</param>
    /// <param name="fifth">Fifth align priority</param>
    virtual public void SetAlignPriority(Efl.Ui.PopupAlign first, Efl.Ui.PopupAlign second, Efl.Ui.PopupAlign third, Efl.Ui.PopupAlign fourth, Efl.Ui.PopupAlign fifth) {
                                                                                                                                 Efl.Ui.AnchorPopup.NativeMethods.efl_ui_anchor_popup_align_priority_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),first, second, third, fourth, fifth);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Returns the anchor object which the popup is following.</summary>
    /// <value>The object which popup is following.</value>
    public Efl.Canvas.Object Anchor {
        get { return GetAnchor(); }
        set { SetAnchor(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AnchorPopup.efl_ui_anchor_popup_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Popup.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_anchor_popup_anchor_get_static_delegate == null)
            {
                efl_ui_anchor_popup_anchor_get_static_delegate = new efl_ui_anchor_popup_anchor_get_delegate(anchor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnchor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_anchor_popup_anchor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_anchor_get_static_delegate) });
            }

            if (efl_ui_anchor_popup_anchor_set_static_delegate == null)
            {
                efl_ui_anchor_popup_anchor_set_static_delegate = new efl_ui_anchor_popup_anchor_set_delegate(anchor_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnchor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_anchor_popup_anchor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_anchor_set_static_delegate) });
            }

            if (efl_ui_anchor_popup_align_priority_get_static_delegate == null)
            {
                efl_ui_anchor_popup_align_priority_get_static_delegate = new efl_ui_anchor_popup_align_priority_get_delegate(align_priority_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlignPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_anchor_popup_align_priority_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_align_priority_get_static_delegate) });
            }

            if (efl_ui_anchor_popup_align_priority_set_static_delegate == null)
            {
                efl_ui_anchor_popup_align_priority_set_static_delegate = new efl_ui_anchor_popup_align_priority_set_delegate(align_priority_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlignPriority") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_anchor_popup_align_priority_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_anchor_popup_align_priority_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.AnchorPopup.efl_ui_anchor_popup_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_anchor_popup_anchor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_anchor_popup_anchor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_get_api_delegate> efl_ui_anchor_popup_anchor_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_get_api_delegate>(Module, "efl_ui_anchor_popup_anchor_get");

        private static Efl.Canvas.Object anchor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_anchor_popup_anchor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((AnchorPopup)ws.Target).GetAnchor();
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
                return efl_ui_anchor_popup_anchor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_anchor_popup_anchor_get_delegate efl_ui_anchor_popup_anchor_get_static_delegate;

        
        private delegate void efl_ui_anchor_popup_anchor_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object anchor);

        
        public delegate void efl_ui_anchor_popup_anchor_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object anchor);

        public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_set_api_delegate> efl_ui_anchor_popup_anchor_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_anchor_set_api_delegate>(Module, "efl_ui_anchor_popup_anchor_set");

        private static void anchor_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object anchor)
        {
            Eina.Log.Debug("function efl_ui_anchor_popup_anchor_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnchorPopup)ws.Target).SetAnchor(anchor);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_anchor_popup_anchor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), anchor);
            }
        }

        private static efl_ui_anchor_popup_anchor_set_delegate efl_ui_anchor_popup_anchor_set_static_delegate;

        
        private delegate void efl_ui_anchor_popup_align_priority_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth);

        
        public delegate void efl_ui_anchor_popup_align_priority_get_api_delegate(System.IntPtr obj,  out Efl.Ui.PopupAlign first,  out Efl.Ui.PopupAlign second,  out Efl.Ui.PopupAlign third,  out Efl.Ui.PopupAlign fourth,  out Efl.Ui.PopupAlign fifth);

        public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_get_api_delegate> efl_ui_anchor_popup_align_priority_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_get_api_delegate>(Module, "efl_ui_anchor_popup_align_priority_get");

        private static void align_priority_get(System.IntPtr obj, System.IntPtr pd, out Efl.Ui.PopupAlign first, out Efl.Ui.PopupAlign second, out Efl.Ui.PopupAlign third, out Efl.Ui.PopupAlign fourth, out Efl.Ui.PopupAlign fifth)
        {
            Eina.Log.Debug("function efl_ui_anchor_popup_align_priority_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                first = default(Efl.Ui.PopupAlign);        second = default(Efl.Ui.PopupAlign);        third = default(Efl.Ui.PopupAlign);        fourth = default(Efl.Ui.PopupAlign);        fifth = default(Efl.Ui.PopupAlign);                                                    
                try
                {
                    ((AnchorPopup)ws.Target).GetAlignPriority(out first, out second, out third, out fourth, out fifth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_anchor_popup_align_priority_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out first, out second, out third, out fourth, out fifth);
            }
        }

        private static efl_ui_anchor_popup_align_priority_get_delegate efl_ui_anchor_popup_align_priority_get_static_delegate;

        
        private delegate void efl_ui_anchor_popup_align_priority_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth);

        
        public delegate void efl_ui_anchor_popup_align_priority_set_api_delegate(System.IntPtr obj,  Efl.Ui.PopupAlign first,  Efl.Ui.PopupAlign second,  Efl.Ui.PopupAlign third,  Efl.Ui.PopupAlign fourth,  Efl.Ui.PopupAlign fifth);

        public static Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_set_api_delegate> efl_ui_anchor_popup_align_priority_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_anchor_popup_align_priority_set_api_delegate>(Module, "efl_ui_anchor_popup_align_priority_set");

        private static void align_priority_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.PopupAlign first, Efl.Ui.PopupAlign second, Efl.Ui.PopupAlign third, Efl.Ui.PopupAlign fourth, Efl.Ui.PopupAlign fifth)
        {
            Eina.Log.Debug("function efl_ui_anchor_popup_align_priority_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((AnchorPopup)ws.Target).SetAlignPriority(first, second, third, fourth, fifth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_anchor_popup_align_priority_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), first, second, third, fourth, fifth);
            }
        }

        private static efl_ui_anchor_popup_align_priority_set_delegate efl_ui_anchor_popup_align_priority_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

