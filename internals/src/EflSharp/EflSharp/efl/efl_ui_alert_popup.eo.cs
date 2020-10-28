#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.AlertPopup.ButtonClickedEvt"/>.</summary>
public class AlertPopupButtonClickedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.AlertPopupButtonClickedEvent arg { get; set; }
}
/// <summary>EFL UI Alert Popup class</summary>
[AlertPopupNativeInherit]
public class AlertPopup : Efl.Ui.Popup, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (AlertPopup))
                return Efl.Ui.AlertPopupNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_alert_popup_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public AlertPopup(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_alert_popup_class_get(), typeof(AlertPopup), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected AlertPopup(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected AlertPopup(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object ButtonClickedEvtKey = new object();
    /// <summary>Called when alert popup was clicked</summary>
    public event EventHandler<Efl.Ui.AlertPopupButtonClickedEvt_Args> ButtonClickedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ButtonClickedEvt_delegate)) {
                    eventHandlers.AddHandler(ButtonClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                if (RemoveNativeEventHandler(key, this.evt_ButtonClickedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ButtonClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ButtonClickedEvt.</summary>
    public void On_ButtonClickedEvt(Efl.Ui.AlertPopupButtonClickedEvt_Args e)
    {
        EventHandler<Efl.Ui.AlertPopupButtonClickedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.AlertPopupButtonClickedEvt_Args>)eventHandlers[ButtonClickedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ButtonClickedEvt_delegate;
    private void on_ButtonClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.AlertPopupButtonClickedEvt_Args args = new Efl.Ui.AlertPopupButtonClickedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_ButtonClickedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ButtonClickedEvt_delegate = new Efl.EventCb(on_ButtonClickedEvt_NativeCallback);
    }
    /// <summary>Set popup buttons.</summary>
    /// <param name="type">Alert popup button type</param>
    /// <param name="text">Alert string on button</param>
    /// <param name="icon">Alert icon on button</param>
    /// <returns></returns>
    virtual public void SetButton( Efl.Ui.AlertPopupButton type,  System.String text,  Efl.Object icon) {
                                                                                 Efl.Ui.AlertPopupNativeInherit.efl_ui_alert_popup_button_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), type,  text,  icon);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
    }
}
public class AlertPopupNativeInherit : Efl.Ui.PopupNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_alert_popup_button_set_static_delegate == null)
            efl_ui_alert_popup_button_set_static_delegate = new efl_ui_alert_popup_button_set_delegate(button_set);
        if (methods.FirstOrDefault(m => m.Name == "SetButton") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_alert_popup_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_alert_popup_button_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AlertPopup.efl_ui_alert_popup_class_get();
    }


     private delegate void efl_ui_alert_popup_button_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.AlertPopupButton type,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object icon);


     public delegate void efl_ui_alert_popup_button_set_api_delegate(System.IntPtr obj,   Efl.Ui.AlertPopupButton type,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object icon);
     public static Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate> efl_ui_alert_popup_button_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate>(_Module, "efl_ui_alert_popup_button_set");
     private static void button_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.AlertPopupButton type,  System.String text,  Efl.Object icon)
    {
        Eina.Log.Debug("function efl_ui_alert_popup_button_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((AlertPopup)wrapper).SetButton( type,  text,  icon);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_alert_popup_button_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  text,  icon);
        }
    }
    private static efl_ui_alert_popup_button_set_delegate efl_ui_alert_popup_button_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
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
} } 
namespace Efl { namespace Ui { 
/// <summary>Information of clicked event</summary>
[StructLayout(LayoutKind.Sequential)]
public struct AlertPopupButtonClickedEvent
{
    /// <summary>Clicked button type</summary>
    public Efl.Ui.AlertPopupButton Button_type;
    ///<summary>Constructor for AlertPopupButtonClickedEvent.</summary>
    public AlertPopupButtonClickedEvent(
        Efl.Ui.AlertPopupButton Button_type=default(Efl.Ui.AlertPopupButton)    )
    {
        this.Button_type = Button_type;
    }

    public static implicit operator AlertPopupButtonClickedEvent(IntPtr ptr)
    {
        var tmp = (AlertPopupButtonClickedEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(AlertPopupButtonClickedEvent.NativeStruct));
        return tmp;
    }

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

}

} } 
