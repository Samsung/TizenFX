#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

///<summary>Event argument wrapper for event <see cref="Efl.Ui.AlertPopup.ButtonClickedEvt"/>.</summary>
public class AlertPopupButtonClickedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.AlertPopupButtonClickedEvent arg { get; set; }
}
/// <summary>EFL UI Alert Popup class</summary>
[Efl.Ui.AlertPopup.NativeMethods]
public class AlertPopup : Efl.Ui.Popup
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AlertPopup))
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
        efl_ui_alert_popup_class_get();
    /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public AlertPopup(Efl.Object parent
            , System.String style = null) : base(efl_ui_alert_popup_class_get(), typeof(AlertPopup), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected AlertPopup(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AlertPopup(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Called when alert popup was clicked</summary>
    public event EventHandler<Efl.Ui.AlertPopupButtonClickedEvt_Args> ButtonClickedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.AlertPopupButtonClickedEvt_Args args = new Efl.Ui.AlertPopupButtonClickedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ButtonClickedEvt.</summary>
    public void OnButtonClickedEvt(Efl.Ui.AlertPopupButtonClickedEvt_Args e)
    {
        var key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Set popup buttons.</summary>
    /// <param name="type">Alert popup button type</param>
    /// <param name="text">Alert string on button</param>
    /// <param name="icon">Alert icon on button</param>
    virtual public void SetButton(Efl.Ui.AlertPopupButton type, System.String text, Efl.Object icon) {
                                                                                 Efl.Ui.AlertPopup.NativeMethods.efl_ui_alert_popup_button_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),type, text, icon);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
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

            if (efl_ui_alert_popup_button_set_static_delegate == null)
            {
                efl_ui_alert_popup_button_set_static_delegate = new efl_ui_alert_popup_button_set_delegate(button_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButton") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_alert_popup_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_alert_popup_button_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_alert_popup_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object icon);

        
        public delegate void efl_ui_alert_popup_button_set_api_delegate(System.IntPtr obj,  Efl.Ui.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate> efl_ui_alert_popup_button_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate>(Module, "efl_ui_alert_popup_button_set");

        private static void button_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.AlertPopupButton type, System.String text, Efl.Object icon)
        {
            Eina.Log.Debug("function efl_ui_alert_popup_button_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((AlertPopup)ws.Target).SetButton(type, text, icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_alert_popup_button_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, text, icon);
            }
        }

        private static efl_ui_alert_popup_button_set_delegate efl_ui_alert_popup_button_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Defines the type of the alert button.</summary>
public enum AlertPopupButton
{
/// <summary>Button having positive meaning. e.g. &quot;Yes&quot;</summary>
Positive = 0,
/// <summary>Button having negative meaning. e.g. &quot;No&quot;</summary>
Negative = 1,
/// <summary>Button having user-defined meaning. e.g. &quot;Cancel&quot;</summary>
User = 2,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Information of clicked event</summary>
[StructLayout(LayoutKind.Sequential)]
public struct AlertPopupButtonClickedEvent
{
    /// <summary>Clicked button type</summary>
    public Efl.Ui.AlertPopupButton Button_type;
    ///<summary>Constructor for AlertPopupButtonClickedEvent.</summary>
    public AlertPopupButtonClickedEvent(
        Efl.Ui.AlertPopupButton Button_type = default(Efl.Ui.AlertPopupButton)    )
    {
        this.Button_type = Button_type;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator AlertPopupButtonClickedEvent(IntPtr ptr)
    {
        var tmp = (AlertPopupButtonClickedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(AlertPopupButtonClickedEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct AlertPopupButtonClickedEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Ui.AlertPopupButton Button_type;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator AlertPopupButtonClickedEvent.NativeStruct(AlertPopupButtonClickedEvent _external_struct)
        {
            var _internal_struct = new AlertPopupButtonClickedEvent.NativeStruct();
            _internal_struct.Button_type = _external_struct.Button_type;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator AlertPopupButtonClickedEvent(AlertPopupButtonClickedEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new AlertPopupButtonClickedEvent();
            _external_struct.Button_type = _internal_struct.Button_type;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

