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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.AlertPopup.ButtonClickedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class AlertPopupButtonClickedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when an Alert_Popup button was clicked.</value>
    public Efl.Ui.AlertPopupButtonClickedEvent arg { get; set; }
}

/// <summary>A variant of <see cref="Efl.Ui.Popup"/> which uses a layout containing a content object and a variable number of buttons (up to 3 total).
/// An Alert_Popup is a popup which can be used when an application requires user interaction. It provides functionality for easily creating button objects on the popup and passing information about which button has been pressed to the button event callback.</summary>
[Efl.Ui.AlertPopup.NativeMethods]
[Efl.Eo.BindingEntity]
public class AlertPopup : Efl.Ui.Popup
{
    /// <summary>Pointer to the native class description.</summary>
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
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public AlertPopup(Efl.Object parent
            , System.String style = null) : base(efl_ui_alert_popup_class_get(), parent)
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
    protected AlertPopup(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AlertPopup(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AlertPopup(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when an Alert_Popup button was clicked.</summary>
    /// <value><see cref="Efl.Ui.AlertPopupButtonClickedEventArgs"/></value>
    public event EventHandler<Efl.Ui.AlertPopupButtonClickedEventArgs> ButtonClickedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.AlertPopupButtonClickedEventArgs args = new Efl.Ui.AlertPopupButtonClickedEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ButtonClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnButtonClickedEvent(Efl.Ui.AlertPopupButtonClickedEventArgs e)
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


    /// <summary>This property changes the text and icon for the specified button object.
    /// When set, the Alert_Popup will create a button for the specified type if it does not yet exist. The button&apos;s content and text will be set using the passed values.
    /// 
    /// Exactly one button may exist for each <see cref="Efl.Ui.AlertPopupButton"/> type. Repeated calls to set values for the same button type will overwrite previous values.
    /// 
    /// By default, no buttons are created. Once a button is added to the Popup using this property it cannot be removed.</summary>
    /// <param name="type">Alert_Popup button type.</param>
    /// <param name="text">Text of the specified button type.</param>
    /// <param name="icon">Visual to use as an icon for the specified button type.</param>
    public virtual void SetButton(Efl.Ui.AlertPopupButton type, System.String text, Efl.Canvas.Object icon) {
        Efl.Ui.AlertPopup.NativeMethods.efl_ui_alert_popup_button_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, text, icon);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This property changes the text and icon for the specified button object.
    /// When set, the Alert_Popup will create a button for the specified type if it does not yet exist. The button&apos;s content and text will be set using the passed values.
    /// 
    /// Exactly one button may exist for each <see cref="Efl.Ui.AlertPopupButton"/> type. Repeated calls to set values for the same button type will overwrite previous values.
    /// 
    /// By default, no buttons are created. Once a button is added to the Popup using this property it cannot be removed.</summary>
    /// <value>Alert_Popup button type.</value>
    public (Efl.Ui.AlertPopupButton, System.String, Efl.Canvas.Object) Button {
        set { SetButton( value.Item1,  value.Item2,  value.Item3); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Popup.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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
            return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_alert_popup_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object icon);

        
        public delegate void efl_ui_alert_popup_button_set_api_delegate(System.IntPtr obj,  Efl.Ui.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate> efl_ui_alert_popup_button_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate>(Module, "efl_ui_alert_popup_button_set");

        private static void button_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.AlertPopupButton type, System.String text, Efl.Canvas.Object icon)
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

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiAlertPopup_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Defines the type of the alert button.</summary>
[Efl.Eo.BindingEntity]
public enum AlertPopupButton
{
/// <summary>Button having positive meaning. E.g. &quot;Yes&quot;.</summary>
Positive = 0,
/// <summary>Button having negative meaning. E.g. &quot;No&quot;.</summary>
Negative = 1,
/// <summary>Button having user-defined meaning. E.g. &quot;More information&quot;.</summary>
User = 2,
}
}
}

namespace Efl {

namespace Ui {

/// <summary>Information for <see cref="Efl.Ui.AlertPopup.ButtonClickedEvent"/> event.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct AlertPopupButtonClickedEvent
{
    /// <summary>Clicked button type.</summary>
    /// <value>Defines the type of the alert button.</value>
    public Efl.Ui.AlertPopupButton Button_type;
    /// <summary>Constructor for AlertPopupButtonClickedEvent.</summary>
    /// <param name="Button_type">Clicked button type.</param>
    public AlertPopupButtonClickedEvent(
        Efl.Ui.AlertPopupButton Button_type = default(Efl.Ui.AlertPopupButton)    )
    {
        this.Button_type = Button_type;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator AlertPopupButtonClickedEvent(IntPtr ptr)
    {
        var tmp = (AlertPopupButtonClickedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(AlertPopupButtonClickedEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct AlertPopupButtonClickedEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Ui.AlertPopupButton Button_type;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator AlertPopupButtonClickedEvent.NativeStruct(AlertPopupButtonClickedEvent _external_struct)
        {
            var _internal_struct = new AlertPopupButtonClickedEvent.NativeStruct();
            _internal_struct.Button_type = _external_struct.Button_type;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
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

