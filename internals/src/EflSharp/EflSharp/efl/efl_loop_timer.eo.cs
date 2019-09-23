#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Timers are objects that will call a given callback at some point in the future and repeat that tick at a given interval.
/// Timers require the ecore main loop to be running and functioning properly. They do not guarantee exact timing but try to work on a &quot;best effort&quot; basis.
/// 
/// The <see cref="Efl.Object.FreezeEvent"/> and <see cref="Efl.Object.ThawEvent"/> calls are used to pause and unpause the timer.
/// (Since EFL 1.22)</summary>
[Efl.LoopTimer.NativeMethods]
[Efl.Eo.BindingEntity]
public class LoopTimer : Efl.LoopConsumer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopTimer))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_timer_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="timerInterval">Interval the timer ticks on. See <see cref="Efl.LoopTimer.SetTimerInterval" /></param>
    public LoopTimer(Efl.Object parent
            , double timerInterval) : base(efl_loop_timer_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(timerInterval))
        {
            SetTimerInterval(Efl.Eo.Globals.GetParamHelper(timerInterval));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected LoopTimer(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LoopTimer(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopTimer(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Event triggered when the specified time as passed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler TimerTickEvent
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
                        EventArgs args = EventArgs.Empty;
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

                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event TimerTickEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnTimerTickEvent(EventArgs e)
    {
        var key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Gets the interval the timer ticks on.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new interval in seconds</returns>
    public virtual double GetTimerInterval() {
         var _ret_var = Efl.LoopTimer.NativeMethods.efl_loop_timer_interval_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the interval the timer ticks off. If set during a timer call this will affect the next interval.
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_in">The new interval in seconds</param>
    public virtual void SetTimerInterval(double kw_in) {
                                 Efl.LoopTimer.NativeMethods.efl_loop_timer_interval_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_in);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the pending time regarding a timer.
    /// (Since EFL 1.22)</summary>
    /// <returns>Pending time</returns>
    public virtual double GetTimePending() {
         var _ret_var = Efl.LoopTimer.NativeMethods.efl_loop_timer_time_pending_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets a timer to its full interval. This effectively makes the timer start ticking off from zero now.
    /// This is equal to delaying the timer by the already passed time, since the timer started ticking
    /// (Since EFL 1.22)</summary>
    public virtual void ResetTimer() {
         Efl.LoopTimer.NativeMethods.efl_loop_timer_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This effectively resets a timer but based on the time when this iteration of the main loop started.
    /// (Since EFL 1.22)</summary>
    public virtual void ResetTimerLoop() {
         Efl.LoopTimer.NativeMethods.efl_loop_timer_loop_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Adds a delay to the next occurrence of a timer. This doesn&apos;t affect the timer interval.
    /// (Since EFL 1.22)</summary>
    /// <param name="add">The amount of time by which to delay the timer in seconds</param>
    public virtual void TimerDelay(double add) {
                                 Efl.LoopTimer.NativeMethods.efl_loop_timer_delay_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),add);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Interval the timer ticks on.
    /// (Since EFL 1.22)</summary>
    /// <value>The new interval in seconds</value>
    public double TimerInterval {
        get { return GetTimerInterval(); }
        set { SetTimerInterval(value); }
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
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_timer_interval_get_static_delegate == null)
            {
                efl_loop_timer_interval_get_static_delegate = new efl_loop_timer_interval_get_delegate(timer_interval_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimerInterval") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_interval_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_get_static_delegate) });
            }

            if (efl_loop_timer_interval_set_static_delegate == null)
            {
                efl_loop_timer_interval_set_static_delegate = new efl_loop_timer_interval_set_delegate(timer_interval_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimerInterval") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_interval_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_set_static_delegate) });
            }

            if (efl_loop_timer_time_pending_get_static_delegate == null)
            {
                efl_loop_timer_time_pending_get_static_delegate = new efl_loop_timer_time_pending_get_delegate(time_pending_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimePending") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_time_pending_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_time_pending_get_static_delegate) });
            }

            if (efl_loop_timer_reset_static_delegate == null)
            {
                efl_loop_timer_reset_static_delegate = new efl_loop_timer_reset_delegate(timer_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetTimer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_reset_static_delegate) });
            }

            if (efl_loop_timer_loop_reset_static_delegate == null)
            {
                efl_loop_timer_loop_reset_static_delegate = new efl_loop_timer_loop_reset_delegate(timer_loop_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetTimerLoop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_loop_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_loop_reset_static_delegate) });
            }

            if (efl_loop_timer_delay_static_delegate == null)
            {
                efl_loop_timer_delay_static_delegate = new efl_loop_timer_delay_delegate(timer_delay);
            }

            if (methods.FirstOrDefault(m => m.Name == "TimerDelay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_delay"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_delay_static_delegate) });
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
            return Efl.LoopTimer.efl_loop_timer_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_loop_timer_interval_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_loop_timer_interval_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_interval_get_api_delegate> efl_loop_timer_interval_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_interval_get_api_delegate>(Module, "efl_loop_timer_interval_get");

        private static double timer_interval_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_timer_interval_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((LoopTimer)ws.Target).GetTimerInterval();
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
                return efl_loop_timer_interval_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_timer_interval_get_delegate efl_loop_timer_interval_get_static_delegate;

        
        private delegate void efl_loop_timer_interval_set_delegate(System.IntPtr obj, System.IntPtr pd,  double kw_in);

        
        public delegate void efl_loop_timer_interval_set_api_delegate(System.IntPtr obj,  double kw_in);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_interval_set_api_delegate> efl_loop_timer_interval_set_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_interval_set_api_delegate>(Module, "efl_loop_timer_interval_set");

        private static void timer_interval_set(System.IntPtr obj, System.IntPtr pd, double kw_in)
        {
            Eina.Log.Debug("function efl_loop_timer_interval_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopTimer)ws.Target).SetTimerInterval(kw_in);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_timer_interval_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_in);
            }
        }

        private static efl_loop_timer_interval_set_delegate efl_loop_timer_interval_set_static_delegate;

        
        private delegate double efl_loop_timer_time_pending_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_loop_timer_time_pending_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate> efl_loop_timer_time_pending_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate>(Module, "efl_loop_timer_time_pending_get");

        private static double time_pending_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_timer_time_pending_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((LoopTimer)ws.Target).GetTimePending();
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
                return efl_loop_timer_time_pending_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_timer_time_pending_get_delegate efl_loop_timer_time_pending_get_static_delegate;

        
        private delegate void efl_loop_timer_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_loop_timer_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_reset_api_delegate> efl_loop_timer_reset_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_reset_api_delegate>(Module, "efl_loop_timer_reset");

        private static void timer_reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_timer_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((LoopTimer)ws.Target).ResetTimer();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_loop_timer_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_timer_reset_delegate efl_loop_timer_reset_static_delegate;

        
        private delegate void efl_loop_timer_loop_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_loop_timer_loop_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate> efl_loop_timer_loop_reset_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate>(Module, "efl_loop_timer_loop_reset");

        private static void timer_loop_reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_timer_loop_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((LoopTimer)ws.Target).ResetTimerLoop();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_loop_timer_loop_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_timer_loop_reset_delegate efl_loop_timer_loop_reset_static_delegate;

        
        private delegate void efl_loop_timer_delay_delegate(System.IntPtr obj, System.IntPtr pd,  double add);

        
        public delegate void efl_loop_timer_delay_api_delegate(System.IntPtr obj,  double add);

        public static Efl.Eo.FunctionWrapper<efl_loop_timer_delay_api_delegate> efl_loop_timer_delay_ptr = new Efl.Eo.FunctionWrapper<efl_loop_timer_delay_api_delegate>(Module, "efl_loop_timer_delay");

        private static void timer_delay(System.IntPtr obj, System.IntPtr pd, double add)
        {
            Eina.Log.Debug("function efl_loop_timer_delay was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopTimer)ws.Target).TimerDelay(add);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_timer_delay_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), add);
            }
        }

        private static efl_loop_timer_delay_delegate efl_loop_timer_delay_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflLoopTimer_ExtensionMethods {
    public static Efl.BindableProperty<double> TimerInterval<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.LoopTimer, T>magic = null) where T : Efl.LoopTimer {
        return new Efl.BindableProperty<double>("timer_interval", fac);
    }

    
}
#pragma warning restore CS1591
#endif
