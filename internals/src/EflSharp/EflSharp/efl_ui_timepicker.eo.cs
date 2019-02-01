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
public class Timepicker : Efl.Ui.Layout, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.TimepickerNativeInherit nativeInherit = new Efl.Ui.TimepickerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Timepicker))
            return Efl.Ui.TimepickerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Timepicker obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_timepicker_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Timepicker(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Timepicker", efl_ui_timepicker_class_get(), typeof(Timepicker), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Timepicker(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Timepicker(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Timepicker static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Timepicker(obj.NativeHandle);
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
private static object ChangedEvtKey = new object();
   /// <summary>Called when date is changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) { 
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
   private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_timepicker_time_get(System.IntPtr obj,   out  int hour,   out  int min);
   /// <summary>The current value of time
   /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
   /// 
   /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
   /// <param name="hour">The hour value from 0 to 23.</param>
   /// <param name="min">The minute value from 0 to 59.</param>
   /// <returns></returns>
   virtual public  void GetTime( out  int hour,  out  int min) {
                                           efl_ui_timepicker_time_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out hour,  out min);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_timepicker_time_set(System.IntPtr obj,    int hour,    int min);
   /// <summary>The current value of time
   /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
   /// 
   /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
   /// <param name="hour">The hour value from 0 to 23.</param>
   /// <param name="min">The minute value from 0 to 59.</param>
   /// <returns></returns>
   virtual public  void SetTime(  int hour,   int min) {
                                           efl_ui_timepicker_time_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  hour,  min);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_timepicker_ampm_get(System.IntPtr obj);
   /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
   /// <returns><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</returns>
   virtual public bool GetAmpm() {
       var _ret_var = efl_ui_timepicker_ampm_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_timepicker_ampm_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_24hour);
   /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
   /// <param name="is_24hour"><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</param>
   /// <returns></returns>
   virtual public  void SetAmpm( bool is_24hour) {
                         efl_ui_timepicker_ampm_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  is_24hour);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
   public bool Ampm {
      get { return GetAmpm(); }
      set { SetAmpm( value); }
   }
}
public class TimepickerNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_timepicker_time_get_static_delegate = new efl_ui_timepicker_time_get_delegate(time_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_timepicker_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_get_static_delegate)});
      efl_ui_timepicker_time_set_static_delegate = new efl_ui_timepicker_time_set_delegate(time_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_timepicker_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_set_static_delegate)});
      efl_ui_timepicker_ampm_get_static_delegate = new efl_ui_timepicker_ampm_get_delegate(ampm_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_timepicker_ampm_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_get_static_delegate)});
      efl_ui_timepicker_ampm_set_static_delegate = new efl_ui_timepicker_ampm_set_delegate(ampm_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_timepicker_ampm_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_set_static_delegate)});
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


    private delegate  void efl_ui_timepicker_time_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int hour,   out  int min);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_timepicker_time_get(System.IntPtr obj,   out  int hour,   out  int min);
    private static  void time_get(System.IntPtr obj, System.IntPtr pd,  out  int hour,  out  int min)
   {
      Eina.Log.Debug("function efl_ui_timepicker_time_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           hour = default( int);      min = default( int);                     
         try {
            ((Timepicker)wrapper).GetTime( out hour,  out min);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_timepicker_time_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hour,  out min);
      }
   }
   private efl_ui_timepicker_time_get_delegate efl_ui_timepicker_time_get_static_delegate;


    private delegate  void efl_ui_timepicker_time_set_delegate(System.IntPtr obj, System.IntPtr pd,    int hour,    int min);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_timepicker_time_set(System.IntPtr obj,    int hour,    int min);
    private static  void time_set(System.IntPtr obj, System.IntPtr pd,   int hour,   int min)
   {
      Eina.Log.Debug("function efl_ui_timepicker_time_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Timepicker)wrapper).SetTime( hour,  min);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_timepicker_time_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hour,  min);
      }
   }
   private efl_ui_timepicker_time_set_delegate efl_ui_timepicker_time_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_timepicker_ampm_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_timepicker_ampm_get(System.IntPtr obj);
    private static bool ampm_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_timepicker_ampm_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
         return efl_ui_timepicker_ampm_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_timepicker_ampm_get_delegate efl_ui_timepicker_ampm_get_static_delegate;


    private delegate  void efl_ui_timepicker_ampm_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_24hour);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_timepicker_ampm_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_24hour);
    private static  void ampm_set(System.IntPtr obj, System.IntPtr pd,  bool is_24hour)
   {
      Eina.Log.Debug("function efl_ui_timepicker_ampm_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Timepicker)wrapper).SetAmpm( is_24hour);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_timepicker_ampm_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_24hour);
      }
   }
   private efl_ui_timepicker_ampm_set_delegate efl_ui_timepicker_ampm_set_static_delegate;
}
} } 
