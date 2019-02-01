#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Timers are objects that will call a given callback at some point in the future and repeat that tick at a given interval.
/// Timers require the ecore main loop to be running and functioning properly. They do not guarantee exact timing but try to work on a &quot;best effort&quot; basis.</summary>
[LoopTimerNativeInherit]
public class LoopTimer : Efl.LoopConsumer, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopTimerNativeInherit nativeInherit = new Efl.LoopTimerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopTimer))
            return Efl.LoopTimerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LoopTimer obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_timer_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LoopTimer(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LoopTimer", efl_loop_timer_class_get(), typeof(LoopTimer), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LoopTimer(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LoopTimer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopTimer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopTimer(obj.NativeHandle);
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
private static object TickEvtKey = new object();
   /// <summary>Event triggered when the specified time as passed.</summary>
   public event EventHandler TickEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_TIMER_EVENT_TICK";
            if (add_cpp_event_handler(key, this.evt_TickEvt_delegate)) {
               eventHandlers.AddHandler(TickEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_TIMER_EVENT_TICK";
            if (remove_cpp_event_handler(key, this.evt_TickEvt_delegate)) { 
               eventHandlers.RemoveHandler(TickEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event TickEvt.</summary>
   public void On_TickEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[TickEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_TickEvt_delegate;
   private void on_TickEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_TickEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_TickEvt_delegate = new Efl.EventCb(on_TickEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern double efl_loop_timer_interval_get(System.IntPtr obj);
   /// <summary>Gets the interval the timer ticks on.</summary>
   /// <returns>The new interval in seconds</returns>
   virtual public double GetInterval() {
       var _ret_var = efl_loop_timer_interval_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_timer_interval_set(System.IntPtr obj,   double kw_in);
   /// <summary>Changes the interval the timer ticks off. If set during a timer call this will affect the next interval.</summary>
   /// <param name="kw_in">The new interval in seconds</param>
   /// <returns></returns>
   virtual public  void SetInterval( double kw_in) {
                         efl_loop_timer_interval_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_in);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern double efl_loop_timer_pending_get(System.IntPtr obj);
   /// <summary>Gets the pending time regarding a timer.</summary>
   /// <returns>Pending time</returns>
   virtual public double GetPending() {
       var _ret_var = efl_loop_timer_pending_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_timer_reset(System.IntPtr obj);
   /// <summary>Resets a timer to its full interval. This effectively makes the timer start ticking off from zero now.
   /// 1.2</summary>
   /// <returns></returns>
   virtual public  void Reset() {
       efl_loop_timer_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_timer_loop_reset(System.IntPtr obj);
   /// <summary>This effectively resets a timer but based on the time when this iteration of the main loop started.
   /// 1.18</summary>
   /// <returns></returns>
   virtual public  void ResetLoop() {
       efl_loop_timer_loop_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_timer_delay(System.IntPtr obj,   double add);
   /// <summary>Adds a delay to the next occurrence of a timer. This doesn&apos;t affect the timer interval.</summary>
   /// <param name="add">The amount of time by which to delay the timer in seconds</param>
   /// <returns></returns>
   virtual public  void Delay( double add) {
                         efl_loop_timer_delay((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  add);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Interval the timer ticks on.</summary>
   public double Interval {
      get { return GetInterval(); }
      set { SetInterval( value); }
   }
   /// <summary>Pending time regarding a timer.</summary>
   public double Pending {
      get { return GetPending(); }
   }
}
public class LoopTimerNativeInherit : Efl.LoopConsumerNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_loop_timer_interval_get_static_delegate = new efl_loop_timer_interval_get_delegate(interval_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_interval_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_get_static_delegate)});
      efl_loop_timer_interval_set_static_delegate = new efl_loop_timer_interval_set_delegate(interval_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_interval_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_set_static_delegate)});
      efl_loop_timer_pending_get_static_delegate = new efl_loop_timer_pending_get_delegate(pending_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_pending_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_pending_get_static_delegate)});
      efl_loop_timer_reset_static_delegate = new efl_loop_timer_reset_delegate(reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_reset_static_delegate)});
      efl_loop_timer_loop_reset_static_delegate = new efl_loop_timer_loop_reset_delegate(loop_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_loop_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_loop_reset_static_delegate)});
      efl_loop_timer_delay_static_delegate = new efl_loop_timer_delay_delegate(delay);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_timer_delay"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_delay_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern double efl_loop_timer_interval_get(System.IntPtr obj);
    private static double interval_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_timer_interval_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LoopTimer)wrapper).GetInterval();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_timer_interval_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_timer_interval_get_delegate efl_loop_timer_interval_get_static_delegate;


    private delegate  void efl_loop_timer_interval_set_delegate(System.IntPtr obj, System.IntPtr pd,   double kw_in);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_timer_interval_set(System.IntPtr obj,   double kw_in);
    private static  void interval_set(System.IntPtr obj, System.IntPtr pd,  double kw_in)
   {
      Eina.Log.Debug("function efl_loop_timer_interval_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopTimer)wrapper).SetInterval( kw_in);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_timer_interval_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_in);
      }
   }
   private efl_loop_timer_interval_set_delegate efl_loop_timer_interval_set_static_delegate;


    private delegate double efl_loop_timer_pending_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern double efl_loop_timer_pending_get(System.IntPtr obj);
    private static double pending_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_timer_pending_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((LoopTimer)wrapper).GetPending();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_timer_pending_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_timer_pending_get_delegate efl_loop_timer_pending_get_static_delegate;


    private delegate  void efl_loop_timer_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_timer_reset(System.IntPtr obj);
    private static  void reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_timer_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((LoopTimer)wrapper).Reset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_loop_timer_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_timer_reset_delegate efl_loop_timer_reset_static_delegate;


    private delegate  void efl_loop_timer_loop_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_timer_loop_reset(System.IntPtr obj);
    private static  void loop_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_timer_loop_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((LoopTimer)wrapper).ResetLoop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_loop_timer_loop_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_timer_loop_reset_delegate efl_loop_timer_loop_reset_static_delegate;


    private delegate  void efl_loop_timer_delay_delegate(System.IntPtr obj, System.IntPtr pd,   double add);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_timer_delay(System.IntPtr obj,   double add);
    private static  void delay(System.IntPtr obj, System.IntPtr pd,  double add)
   {
      Eina.Log.Debug("function efl_loop_timer_delay was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopTimer)wrapper).Delay( add);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_timer_delay(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  add);
      }
   }
   private efl_loop_timer_delay_delegate efl_loop_timer_delay_static_delegate;
}
} 
