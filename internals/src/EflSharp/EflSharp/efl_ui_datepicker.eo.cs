#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Datepicker widget
/// This is a widget which allows the user to pick a date using internal spinner. User can use the internal spinner to select year, month, day or user can input value using internal entry.</summary>
[DatepickerNativeInherit]
public class Datepicker : Efl.Ui.Layout, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.DatepickerNativeInherit nativeInherit = new Efl.Ui.DatepickerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Datepicker))
            return Efl.Ui.DatepickerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Datepicker obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_datepicker_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Datepicker(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Datepicker", efl_ui_datepicker_class_get(), typeof(Datepicker), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Datepicker(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Datepicker(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Datepicker static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Datepicker(obj.NativeHandle);
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
   /// <summary>Called when date value is changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DATEPICKER_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DATEPICKER_EVENT_CHANGED";
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
    protected static extern  void efl_ui_datepicker_min_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
   /// <summary>The lower boundary of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 1 to 12.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void GetMin( out  int year,  out  int month,  out  int day) {
                                                             efl_ui_datepicker_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out year,  out month,  out day);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_datepicker_min_set(System.IntPtr obj,    int year,    int month,    int day);
   /// <summary>The lower boundary of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 1 to 12.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void SetMin(  int year,   int month,   int day) {
                                                             efl_ui_datepicker_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  year,  month,  day);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_datepicker_max_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
   /// <summary>The upper boundary of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 1 to 12.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void GetMax( out  int year,  out  int month,  out  int day) {
                                                             efl_ui_datepicker_max_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out year,  out month,  out day);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_datepicker_max_set(System.IntPtr obj,    int year,    int month,    int day);
   /// <summary>The upper boundary of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 1 to 12.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void SetMax(  int year,   int month,   int day) {
                                                             efl_ui_datepicker_max_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  year,  month,  day);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_datepicker_date_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
   /// <summary>The current value of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 0 to 11.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void GetDate( out  int year,  out  int month,  out  int day) {
                                                             efl_ui_datepicker_date_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out year,  out month,  out day);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_datepicker_date_set(System.IntPtr obj,    int year,    int month,    int day);
   /// <summary>The current value of date.
   /// <c>year</c>: Year. The year range is from 1900 to 2137.
   /// 
   /// <c>month</c>: Month. The month range is from 0 to 11.
   /// 
   /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
   /// <param name="year">The year value.</param>
   /// <param name="month">The month value from 1 to 12.</param>
   /// <param name="day">The day value from 1 to 31.</param>
   /// <returns></returns>
   virtual public  void SetDate(  int year,   int month,   int day) {
                                                             efl_ui_datepicker_date_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  year,  month,  day);
      Eina.Error.RaiseIfUnhandledException();
                                           }
}
public class DatepickerNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_datepicker_min_get_static_delegate = new efl_ui_datepicker_min_get_delegate(min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_min_get_static_delegate)});
      efl_ui_datepicker_min_set_static_delegate = new efl_ui_datepicker_min_set_delegate(min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_min_set_static_delegate)});
      efl_ui_datepicker_max_get_static_delegate = new efl_ui_datepicker_max_get_delegate(max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_max_get_static_delegate)});
      efl_ui_datepicker_max_set_static_delegate = new efl_ui_datepicker_max_set_delegate(max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_max_set_static_delegate)});
      efl_ui_datepicker_date_get_static_delegate = new efl_ui_datepicker_date_get_delegate(date_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_get_static_delegate)});
      efl_ui_datepicker_date_set_static_delegate = new efl_ui_datepicker_date_set_delegate(date_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_datepicker_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
   }


    private delegate  void efl_ui_datepicker_min_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int year,   out  int month,   out  int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_min_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
    private static  void min_get(System.IntPtr obj, System.IntPtr pd,  out  int year,  out  int month,  out  int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 year = default( int);      month = default( int);      day = default( int);                           
         try {
            ((Datepicker)wrapper).GetMin( out year,  out month,  out day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out year,  out month,  out day);
      }
   }
   private efl_ui_datepicker_min_get_delegate efl_ui_datepicker_min_get_static_delegate;


    private delegate  void efl_ui_datepicker_min_set_delegate(System.IntPtr obj, System.IntPtr pd,    int year,    int month,    int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_min_set(System.IntPtr obj,    int year,    int month,    int day);
    private static  void min_set(System.IntPtr obj, System.IntPtr pd,   int year,   int month,   int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Datepicker)wrapper).SetMin( year,  month,  day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  year,  month,  day);
      }
   }
   private efl_ui_datepicker_min_set_delegate efl_ui_datepicker_min_set_static_delegate;


    private delegate  void efl_ui_datepicker_max_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int year,   out  int month,   out  int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_max_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
    private static  void max_get(System.IntPtr obj, System.IntPtr pd,  out  int year,  out  int month,  out  int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 year = default( int);      month = default( int);      day = default( int);                           
         try {
            ((Datepicker)wrapper).GetMax( out year,  out month,  out day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out year,  out month,  out day);
      }
   }
   private efl_ui_datepicker_max_get_delegate efl_ui_datepicker_max_get_static_delegate;


    private delegate  void efl_ui_datepicker_max_set_delegate(System.IntPtr obj, System.IntPtr pd,    int year,    int month,    int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_max_set(System.IntPtr obj,    int year,    int month,    int day);
    private static  void max_set(System.IntPtr obj, System.IntPtr pd,   int year,   int month,   int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Datepicker)wrapper).SetMax( year,  month,  day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  year,  month,  day);
      }
   }
   private efl_ui_datepicker_max_set_delegate efl_ui_datepicker_max_set_static_delegate;


    private delegate  void efl_ui_datepicker_date_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int year,   out  int month,   out  int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_date_get(System.IntPtr obj,   out  int year,   out  int month,   out  int day);
    private static  void date_get(System.IntPtr obj, System.IntPtr pd,  out  int year,  out  int month,  out  int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_date_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 year = default( int);      month = default( int);      day = default( int);                           
         try {
            ((Datepicker)wrapper).GetDate( out year,  out month,  out day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_date_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out year,  out month,  out day);
      }
   }
   private efl_ui_datepicker_date_get_delegate efl_ui_datepicker_date_get_static_delegate;


    private delegate  void efl_ui_datepicker_date_set_delegate(System.IntPtr obj, System.IntPtr pd,    int year,    int month,    int day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_datepicker_date_set(System.IntPtr obj,    int year,    int month,    int day);
    private static  void date_set(System.IntPtr obj, System.IntPtr pd,   int year,   int month,   int day)
   {
      Eina.Log.Debug("function efl_ui_datepicker_date_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Datepicker)wrapper).SetDate( year,  month,  day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_datepicker_date_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  year,  month,  day);
      }
   }
   private efl_ui_datepicker_date_set_delegate efl_ui_datepicker_date_set_static_delegate;
}
} } 
