#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Timers are objects that will call a given callback at some point in the future and repeat that tick at a given interval.
/// Timers require the ecore main loop to be running and functioning properly. They do not guarantee exact timing but try to work on a &quot;best effort&quot; basis.
/// 
/// The <see cref="Efl.Object.FreezeEvent"/> and <see cref="Efl.Object.ThawEvent"/> calls are used to pause and unpause the timer.
/// (Since EFL 1.22)</summary>
[LoopTimerNativeInherit]
public class LoopTimer : Efl.LoopConsumer, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LoopTimer))
                return Efl.LoopTimerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_timer_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="timerInterval">Interval the timer ticks on. See <see cref="Efl.LoopTimer.SetTimerInterval"/></param>
    public LoopTimer(Efl.Object parent
            , double timerInterval) :
        base(efl_loop_timer_class_get(), typeof(LoopTimer), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(timerInterval))
            SetTimerInterval(Efl.Eo.Globals.GetParamHelper(timerInterval));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LoopTimer(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LoopTimer(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object TimerTickEvtKey = new object();
    /// <summary>Event triggered when the specified time as passed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler TimerTickEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_TimerTickEvt_delegate)) {
                    eventHandlers.AddHandler(TimerTickEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                if (RemoveNativeEventHandler(key, this.evt_TimerTickEvt_delegate)) { 
                    eventHandlers.RemoveHandler(TimerTickEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event TimerTickEvt.</summary>
    public void On_TimerTickEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[TimerTickEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_TimerTickEvt_delegate;
    private void on_TimerTickEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_TimerTickEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_TimerTickEvt_delegate = new Efl.EventCb(on_TimerTickEvt_NativeCallback);
    }
    /// <summary>Gets the interval the timer ticks on.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new interval in seconds</returns>
    virtual public double GetTimerInterval() {
         var _ret_var = Efl.LoopTimerNativeInherit.efl_loop_timer_interval_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the interval the timer ticks off. If set during a timer call this will affect the next interval.
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_in">The new interval in seconds</param>
    /// <returns></returns>
    virtual public void SetTimerInterval( double kw_in) {
                                 Efl.LoopTimerNativeInherit.efl_loop_timer_interval_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_in);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the pending time regarding a timer.
    /// (Since EFL 1.22)</summary>
    /// <returns>Pending time</returns>
    virtual public double GetTimePending() {
         var _ret_var = Efl.LoopTimerNativeInherit.efl_loop_timer_time_pending_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets a timer to its full interval. This effectively makes the timer start ticking off from zero now.
    /// This is equal to delaying the timer by the already passed time, since the timer started ticking
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    virtual public void ResetTimer() {
         Efl.LoopTimerNativeInherit.efl_loop_timer_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This effectively resets a timer but based on the time when this iteration of the main loop started.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    virtual public void ResetTimerLoop() {
         Efl.LoopTimerNativeInherit.efl_loop_timer_loop_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Adds a delay to the next occurrence of a timer. This doesn&apos;t affect the timer interval.
    /// (Since EFL 1.22)</summary>
    /// <param name="add">The amount of time by which to delay the timer in seconds</param>
    /// <returns></returns>
    virtual public void TimerDelay( double add) {
                                 Efl.LoopTimerNativeInherit.efl_loop_timer_delay_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), add);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Interval the timer ticks on.
/// (Since EFL 1.22)</summary>
/// <value>The new interval in seconds</value>
    public double TimerInterval {
        get { return GetTimerInterval(); }
        set { SetTimerInterval( value); }
    }
    /// <summary>Pending time regarding a timer.
/// (Since EFL 1.22)</summary>
/// <value>Pending time</value>
    public double TimePending {
        get { return GetTimePending(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopTimer.efl_loop_timer_class_get();
    }
}
public class LoopTimerNativeInherit : Efl.LoopConsumerNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_loop_timer_interval_get_static_delegate == null)
            efl_loop_timer_interval_get_static_delegate = new efl_loop_timer_interval_get_delegate(timer_interval_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTimerInterval") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_interval_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_get_static_delegate)});
        if (efl_loop_timer_interval_set_static_delegate == null)
            efl_loop_timer_interval_set_static_delegate = new efl_loop_timer_interval_set_delegate(timer_interval_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTimerInterval") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_interval_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_set_static_delegate)});
        if (efl_loop_timer_time_pending_get_static_delegate == null)
            efl_loop_timer_time_pending_get_static_delegate = new efl_loop_timer_time_pending_get_delegate(time_pending_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTimePending") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_time_pending_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_time_pending_get_static_delegate)});
        if (efl_loop_timer_reset_static_delegate == null)
            efl_loop_timer_reset_static_delegate = new efl_loop_timer_reset_delegate(timer_reset);
        if (methods.FirstOrDefault(m => m.Name == "ResetTimer") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_reset_static_delegate)});
        if (efl_loop_timer_loop_reset_static_delegate == null)
            efl_loop_timer_loop_reset_static_delegate = new efl_loop_timer_loop_reset_delegate(timer_loop_reset);
        if (methods.FirstOrDefault(m => m.Name == "ResetTimerLoop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_loop_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_loop_reset_static_delegate)});
        if (efl_loop_timer_delay_static_delegate == null)
            efl_loop_timer_delay_static_delegate = new efl_loop_timer_delay_delegate(timer_delay);
        if (methods.FirstOrDefault(m => m.Name == "TimerDelay") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_timer_delay"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_delay_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.LoopTimer.efl_loop_timer_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.LoopTimer.efl_loop_timer_class_get();
    }


     private delegate double efl_loop_timer_interval_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_loop_timer_interval_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_interval_get_api_delegate> efl_loop_timer_interval_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_interval_get_api_delegate>(_Module, "efl_loop_timer_interval_get");
     private static double timer_interval_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_timer_interval_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((LoopTimer)wrapper).GetTimerInterval();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_timer_interval_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_timer_interval_get_delegate efl_loop_timer_interval_get_static_delegate;


     private delegate void efl_loop_timer_interval_set_delegate(System.IntPtr obj, System.IntPtr pd,   double kw_in);


     public delegate void efl_loop_timer_interval_set_api_delegate(System.IntPtr obj,   double kw_in);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_interval_set_api_delegate> efl_loop_timer_interval_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_interval_set_api_delegate>(_Module, "efl_loop_timer_interval_set");
     private static void timer_interval_set(System.IntPtr obj, System.IntPtr pd,  double kw_in)
    {
        Eina.Log.Debug("function efl_loop_timer_interval_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LoopTimer)wrapper).SetTimerInterval( kw_in);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_timer_interval_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_in);
        }
    }
    private static efl_loop_timer_interval_set_delegate efl_loop_timer_interval_set_static_delegate;


     private delegate double efl_loop_timer_time_pending_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_loop_timer_time_pending_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate> efl_loop_timer_time_pending_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate>(_Module, "efl_loop_timer_time_pending_get");
     private static double time_pending_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_timer_time_pending_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((LoopTimer)wrapper).GetTimePending();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_timer_time_pending_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_timer_time_pending_get_delegate efl_loop_timer_time_pending_get_static_delegate;


     private delegate void efl_loop_timer_reset_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_loop_timer_reset_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_reset_api_delegate> efl_loop_timer_reset_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_reset_api_delegate>(_Module, "efl_loop_timer_reset");
     private static void timer_reset(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_timer_reset was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((LoopTimer)wrapper).ResetTimer();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_loop_timer_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_timer_reset_delegate efl_loop_timer_reset_static_delegate;


     private delegate void efl_loop_timer_loop_reset_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_loop_timer_loop_reset_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate> efl_loop_timer_loop_reset_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate>(_Module, "efl_loop_timer_loop_reset");
     private static void timer_loop_reset(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_timer_loop_reset was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((LoopTimer)wrapper).ResetTimerLoop();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_loop_timer_loop_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_timer_loop_reset_delegate efl_loop_timer_loop_reset_static_delegate;


     private delegate void efl_loop_timer_delay_delegate(System.IntPtr obj, System.IntPtr pd,   double add);


     public delegate void efl_loop_timer_delay_api_delegate(System.IntPtr obj,   double add);
     public static Efl.Eo.FunctionWrapper<efl_loop_timer_delay_api_delegate> efl_loop_timer_delay_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_delay_api_delegate>(_Module, "efl_loop_timer_delay");
     private static void timer_delay(System.IntPtr obj, System.IntPtr pd,  double add)
    {
        Eina.Log.Debug("function efl_loop_timer_delay was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LoopTimer)wrapper).TimerDelay( add);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_loop_timer_delay_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  add);
        }
    }
    private static efl_loop_timer_delay_delegate efl_loop_timer_delay_static_delegate;
}
} 
