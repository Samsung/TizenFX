#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Timepicker widget
/// This is a widget which allows the user to pick a time using internal spinner. User can use the internal spinner to select hour, minute, AM/PM or user can input value using internal entry.</summary>
[TimepickerNativeInherit]
public class Timepicker : Efl.Ui.LayoutBase, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Timepicker))
                return Efl.Ui.TimepickerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_timepicker_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Timepicker(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_timepicker_class_get(), typeof(Timepicker), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Timepicker(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Timepicker(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object ChangedEvtKey = new object();
    /// <summary>Called when date is changed</summary>
    public event EventHandler ChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_ChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void On_ChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ChangedEvt_delegate;
    private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
    }
    /// <summary>The current value of time
    /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
    /// 
    /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
    /// <param name="hour">The hour value from 0 to 23.</param>
    /// <param name="min">The minute value from 0 to 59.</param>
    /// <returns></returns>
    virtual public void GetTime( out int hour,  out int min) {
                                                         Efl.Ui.TimepickerNativeInherit.efl_ui_timepicker_time_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out hour,  out min);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The current value of time
    /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
    /// 
    /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
    /// <param name="hour">The hour value from 0 to 23.</param>
    /// <param name="min">The minute value from 0 to 59.</param>
    /// <returns></returns>
    virtual public void SetTime( int hour,  int min) {
                                                         Efl.Ui.TimepickerNativeInherit.efl_ui_timepicker_time_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hour,  min);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
    /// <returns><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</returns>
    virtual public bool GetAmpm() {
         var _ret_var = Efl.Ui.TimepickerNativeInherit.efl_ui_timepicker_ampm_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
    /// <param name="is_24hour"><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</param>
    /// <returns></returns>
    virtual public void SetAmpm( bool is_24hour) {
                                 Efl.Ui.TimepickerNativeInherit.efl_ui_timepicker_ampm_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), is_24hour);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
/// <value><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</value>
    public bool Ampm {
        get { return GetAmpm(); }
        set { SetAmpm( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Timepicker.efl_ui_timepicker_class_get();
    }
}
public class TimepickerNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_timepicker_time_get_static_delegate == null)
            efl_ui_timepicker_time_get_static_delegate = new efl_ui_timepicker_time_get_delegate(time_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTime") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_timepicker_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_get_static_delegate)});
        if (efl_ui_timepicker_time_set_static_delegate == null)
            efl_ui_timepicker_time_set_static_delegate = new efl_ui_timepicker_time_set_delegate(time_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTime") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_timepicker_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_set_static_delegate)});
        if (efl_ui_timepicker_ampm_get_static_delegate == null)
            efl_ui_timepicker_ampm_get_static_delegate = new efl_ui_timepicker_ampm_get_delegate(ampm_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAmpm") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_timepicker_ampm_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_get_static_delegate)});
        if (efl_ui_timepicker_ampm_set_static_delegate == null)
            efl_ui_timepicker_ampm_set_static_delegate = new efl_ui_timepicker_ampm_set_delegate(ampm_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAmpm") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_timepicker_ampm_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Timepicker.efl_ui_timepicker_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Timepicker.efl_ui_timepicker_class_get();
    }


     private delegate void efl_ui_timepicker_time_get_delegate(System.IntPtr obj, System.IntPtr pd,   out int hour,   out int min);


     public delegate void efl_ui_timepicker_time_get_api_delegate(System.IntPtr obj,   out int hour,   out int min);
     public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate> efl_ui_timepicker_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate>(_Module, "efl_ui_timepicker_time_get");
     private static void time_get(System.IntPtr obj, System.IntPtr pd,  out int hour,  out int min)
    {
        Eina.Log.Debug("function efl_ui_timepicker_time_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    hour = default(int);        min = default(int);                            
            try {
                ((Timepicker)wrapper).GetTime( out hour,  out min);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_timepicker_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hour,  out min);
        }
    }
    private static efl_ui_timepicker_time_get_delegate efl_ui_timepicker_time_get_static_delegate;


     private delegate void efl_ui_timepicker_time_set_delegate(System.IntPtr obj, System.IntPtr pd,   int hour,   int min);


     public delegate void efl_ui_timepicker_time_set_api_delegate(System.IntPtr obj,   int hour,   int min);
     public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate> efl_ui_timepicker_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate>(_Module, "efl_ui_timepicker_time_set");
     private static void time_set(System.IntPtr obj, System.IntPtr pd,  int hour,  int min)
    {
        Eina.Log.Debug("function efl_ui_timepicker_time_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Timepicker)wrapper).SetTime( hour,  min);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_timepicker_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hour,  min);
        }
    }
    private static efl_ui_timepicker_time_set_delegate efl_ui_timepicker_time_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_timepicker_ampm_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_timepicker_ampm_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_get_api_delegate> efl_ui_timepicker_ampm_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_get_api_delegate>(_Module, "efl_ui_timepicker_ampm_get");
     private static bool ampm_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_timepicker_ampm_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Timepicker)wrapper).GetAmpm();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_timepicker_ampm_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_timepicker_ampm_get_delegate efl_ui_timepicker_ampm_get_static_delegate;


     private delegate void efl_ui_timepicker_ampm_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_24hour);


     public delegate void efl_ui_timepicker_ampm_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_24hour);
     public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_set_api_delegate> efl_ui_timepicker_ampm_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_set_api_delegate>(_Module, "efl_ui_timepicker_ampm_set");
     private static void ampm_set(System.IntPtr obj, System.IntPtr pd,  bool is_24hour)
    {
        Eina.Log.Debug("function efl_ui_timepicker_ampm_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Timepicker)wrapper).SetAmpm( is_24hour);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_timepicker_ampm_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_24hour);
        }
    }
    private static efl_ui_timepicker_ampm_set_delegate efl_ui_timepicker_ampm_set_static_delegate;
}
} } 
