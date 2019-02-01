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
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.AlertPopupNativeInherit nativeInherit = new Efl.Ui.AlertPopupNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AlertPopup))
            return Efl.Ui.AlertPopupNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AlertPopup obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_alert_popup_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AlertPopup(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AlertPopup", efl_ui_alert_popup_class_get(), typeof(AlertPopup), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AlertPopup(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AlertPopup(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AlertPopup static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AlertPopup(obj.NativeHandle);
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
private static object ButtonClickedEvtKey = new object();
   /// <summary>Called when alert popup was clicked</summary>
   public event EventHandler<Efl.Ui.AlertPopupButtonClickedEvt_Args> ButtonClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
            if (add_cpp_event_handler(key, this.evt_ButtonClickedEvt_delegate)) {
               eventHandlers.AddHandler(ButtonClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
            if (remove_cpp_event_handler(key, this.evt_ButtonClickedEvt_delegate)) { 
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
   private void on_ButtonClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ButtonClickedEvt_delegate = new Efl.EventCb(on_ButtonClickedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_alert_popup_button_set(System.IntPtr obj,   Efl.Ui.AlertPopupButton type,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object icon);
   /// <summary>Set popup buttons.</summary>
   /// <param name="type">Alert popup button type</param>
   /// <param name="text">Alert string on button</param>
   /// <param name="icon">Alert icon on button</param>
   /// <returns></returns>
   virtual public  void SetButton( Efl.Ui.AlertPopupButton type,   System.String text,  Efl.Object icon) {
                                                             efl_ui_alert_popup_button_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  type,  text,  icon);
      Eina.Error.RaiseIfUnhandledException();
                                           }
}
public class AlertPopupNativeInherit : Efl.Ui.PopupNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_alert_popup_button_set_static_delegate = new efl_ui_alert_popup_button_set_delegate(button_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_alert_popup_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_alert_popup_button_set_static_delegate)});
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


    private delegate  void efl_ui_alert_popup_button_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.AlertPopupButton type,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object icon);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_alert_popup_button_set(System.IntPtr obj,   Efl.Ui.AlertPopupButton type,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object icon);
    private static  void button_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.AlertPopupButton type,   System.String text,  Efl.Object icon)
   {
      Eina.Log.Debug("function efl_ui_alert_popup_button_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((AlertPopup)wrapper).SetButton( type,  text,  icon);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_alert_popup_button_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  text,  icon);
      }
   }
   private efl_ui_alert_popup_button_set_delegate efl_ui_alert_popup_button_set_static_delegate;
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
      Efl.Ui.AlertPopupButton Button_type=default(Efl.Ui.AlertPopupButton)   )
   {
      this.Button_type = Button_type;
   }
public static implicit operator AlertPopupButtonClickedEvent(IntPtr ptr)
   {
      var tmp = (AlertPopupButtonClickedEvent_StructInternal)Marshal.PtrToStructure(ptr, typeof(AlertPopupButtonClickedEvent_StructInternal));
      return AlertPopupButtonClickedEvent_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct AlertPopupButtonClickedEvent.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct AlertPopupButtonClickedEvent_StructInternal
{
   
   public Efl.Ui.AlertPopupButton Button_type;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator AlertPopupButtonClickedEvent(AlertPopupButtonClickedEvent_StructInternal struct_)
   {
      return AlertPopupButtonClickedEvent_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator AlertPopupButtonClickedEvent_StructInternal(AlertPopupButtonClickedEvent struct_)
   {
      return AlertPopupButtonClickedEvent_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct AlertPopupButtonClickedEvent</summary>
public static class AlertPopupButtonClickedEvent_StructConversion
{
   internal static AlertPopupButtonClickedEvent_StructInternal ToInternal(AlertPopupButtonClickedEvent _external_struct)
   {
      var _internal_struct = new AlertPopupButtonClickedEvent_StructInternal();

      _internal_struct.Button_type = _external_struct.Button_type;

      return _internal_struct;
   }

   internal static AlertPopupButtonClickedEvent ToManaged(AlertPopupButtonClickedEvent_StructInternal _internal_struct)
   {
      var _external_struct = new AlertPopupButtonClickedEvent();

      _external_struct.Button_type = _internal_struct.Button_type;

      return _external_struct;
   }

}
} } 
