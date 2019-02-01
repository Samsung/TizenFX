#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI clock class</summary>
[ClockNativeInherit]
public class Clock : Efl.Ui.Layout, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ClockNativeInherit nativeInherit = new Efl.Ui.ClockNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Clock))
            return Efl.Ui.ClockNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Clock obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_clock_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Clock(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Clock", efl_ui_clock_class_get(), typeof(Clock), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Clock(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Clock(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Clock static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Clock(obj.NativeHandle);
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
   /// <summary>Called when clock changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_CLOCK_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_CLOCK_EVENT_CHANGED";
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
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_clock_format_get(System.IntPtr obj);
   /// <summary>The current clock format. Format is a combination of allowed Libc date format specifiers like: &quot;%b %d, %Y %I : %M %p&quot;.
   /// Maximum allowed format length is 64 chars.
   /// 
   /// Format can include separators for each individual clock field except for AM/PM field.
   /// 
   /// Each separator can be a maximum of 6 UTF-8 bytes. Space is also taken as a separator.
   /// 
   /// These specifiers can be arranged in any order and the widget will display the fields accordingly.
   /// 
   /// Default format is taken as per the system locale settings.</summary>
   /// <returns>The clock format.</returns>
   virtual public  System.String GetFormat() {
       var _ret_var = efl_ui_clock_format_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_format_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String fmt);
   /// <summary>The current clock format. Format is a combination of allowed Libc date format specifiers like: &quot;%b %d, %Y %I : %M %p&quot;.
   /// Maximum allowed format length is 64 chars.
   /// 
   /// Format can include separators for each individual clock field except for AM/PM field.
   /// 
   /// Each separator can be a maximum of 6 UTF-8 bytes. Space is also taken as a separator.
   /// 
   /// These specifiers can be arranged in any order and the widget will display the fields accordingly.
   /// 
   /// Default format is taken as per the system locale settings.</summary>
   /// <param name="fmt">The clock format.</param>
   /// <returns></returns>
   virtual public  void SetFormat(  System.String fmt) {
                         efl_ui_clock_format_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fmt);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_clock_pause_get(System.IntPtr obj);
   /// <summary>Whether the given clock widget should be paused or not.
   /// This function pauses or starts the clock widget.</summary>
   /// <returns><c>true</c> to pause clock, <c>false</c> otherwise</returns>
   virtual public bool GetPause() {
       var _ret_var = efl_ui_clock_pause_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_pause_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
   /// <summary>Whether the given clock widget should be paused or not.
   /// This function pauses or starts the clock widget.</summary>
   /// <param name="paused"><c>true</c> to pause clock, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetPause( bool paused) {
                         efl_ui_clock_pause_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  paused);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_clock_edit_mode_get(System.IntPtr obj);
   /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
   /// <returns><c>true</c> to set edit mode, <c>false</c> otherwise</returns>
   virtual public bool GetEditMode() {
       var _ret_var = efl_ui_clock_edit_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_edit_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
   /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
   /// <param name="value"><c>true</c> to set edit mode, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetEditMode( bool value) {
                         efl_ui_clock_edit_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_clock_time_min_get(System.IntPtr obj);
   /// <summary>The lower boundary of a field.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <returns>Time structure containing the minimum time value.</returns>
   virtual public Efl.Time GetTimeMin() {
       var _ret_var = efl_ui_clock_time_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_time_min_set(System.IntPtr obj,   Efl.Time_StructInternal mintime);
   /// <summary>The lower boundary of a field.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <param name="mintime">Time structure containing the minimum time value.</param>
   /// <returns></returns>
   virtual public  void SetTimeMin( Efl.Time mintime) {
       var _in_mintime = Efl.Time_StructConversion.ToInternal(mintime);
                  efl_ui_clock_time_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_mintime);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_clock_time_max_get(System.IntPtr obj);
   /// <summary>The upper boundary of a field.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <returns>Time structure containing the maximum time value.</returns>
   virtual public Efl.Time GetTimeMax() {
       var _ret_var = efl_ui_clock_time_max_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_time_max_set(System.IntPtr obj,   Efl.Time_StructInternal maxtime);
   /// <summary>The upper boundary of a field.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <param name="maxtime">Time structure containing the maximum time value.</param>
   /// <returns></returns>
   virtual public  void SetTimeMax( Efl.Time maxtime) {
       var _in_maxtime = Efl.Time_StructConversion.ToInternal(maxtime);
                  efl_ui_clock_time_max_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_maxtime);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_clock_time_get(System.IntPtr obj);
   /// <summary>The current value of a clock object.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <returns>Time structure containing the time value.</returns>
   virtual public Efl.Time GetTime() {
       var _ret_var = efl_ui_clock_time_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_time_set(System.IntPtr obj,   Efl.Time_StructInternal curtime);
   /// <summary>The current value of a clock object.
   /// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
   /// 
   /// Month: default value range is from 0 to 11.
   /// 
   /// Date: default value range is from 1 to 31 according to the month value.
   /// 
   /// Hour: default value will be in terms of 24 hr format (0~23)
   /// 
   /// Minute: default value range is from 0 to 59.</summary>
   /// <param name="curtime">Time structure containing the time value.</param>
   /// <returns></returns>
   virtual public  void SetTime( Efl.Time curtime) {
       var _in_curtime = Efl.Time_StructConversion.ToInternal(curtime);
                  efl_ui_clock_time_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_curtime);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_clock_field_visible_get(System.IntPtr obj,   Efl.Ui.ClockType fieldtype);
   /// <summary>The field to be visible/not.</summary>
   /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
   /// <returns><c>true</c> field can be visible, <c>false</c> otherwise.</returns>
   virtual public bool GetFieldVisible( Efl.Ui.ClockType fieldtype) {
                         var _ret_var = efl_ui_clock_field_visible_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fieldtype);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_field_visible_set(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,  [MarshalAs(UnmanagedType.U1)]  bool visible);
   /// <summary>The field to be visible/not.</summary>
   /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
   /// <param name="visible"><c>true</c> field can be visible, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetFieldVisible( Efl.Ui.ClockType fieldtype,  bool visible) {
                                           efl_ui_clock_field_visible_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fieldtype,  visible);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_field_limit_get(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,   out  int min,   out  int max);
   /// <summary>Get the field limits of a field.
   /// Limits can be set to individual fields, independently, except for the AM/PM field. Any field can display the values only in between these minimum and maximum limits unless the corresponding time value is restricted from MinTime to MaxTime. That is, min/max field limits always work under the limitations of mintime/maxtime.
   /// 
   /// There is no provision to set the limits of AM/PM field.</summary>
   /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
   /// <param name="min">Reference to field&apos;s minimum value.</param>
   /// <param name="max">Reference to field&apos;s maximum value.</param>
   /// <returns></returns>
   virtual public  void GetFieldLimit( Efl.Ui.ClockType fieldtype,  out  int min,  out  int max) {
                                                             efl_ui_clock_field_limit_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fieldtype,  out min,  out max);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_clock_field_limit_set(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,    int min,    int max);
   /// <summary>Set a field to be visible or not.
   /// Setting this API to <c>true</c> in itself doen&apos;t ensure that the field is visible. The field&apos;s format also must be present in the overall clock format.  If a field&apos;s visibility is set to <c>false</c> then it won&apos;t appear even though its format is present. In summary, if this API is set to true and the corresponding field&apos;s format is present in clock format, the field is visible.
   /// 
   /// By default the field visibility is set to <c>true</c>.</summary>
   /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
   /// <param name="min">Reference to field&apos;s minimum value.</param>
   /// <param name="max">Reference to field&apos;s maximum value.</param>
   /// <returns></returns>
   virtual public  void SetFieldLimit( Efl.Ui.ClockType fieldtype,   int min,   int max) {
                                                             efl_ui_clock_field_limit_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  fieldtype,  min,  max);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>The current clock format. Format is a combination of allowed Libc date format specifiers like: &quot;%b %d, %Y %I : %M %p&quot;.
/// Maximum allowed format length is 64 chars.
/// 
/// Format can include separators for each individual clock field except for AM/PM field.
/// 
/// Each separator can be a maximum of 6 UTF-8 bytes. Space is also taken as a separator.
/// 
/// These specifiers can be arranged in any order and the widget will display the fields accordingly.
/// 
/// Default format is taken as per the system locale settings.</summary>
   public  System.String Format {
      get { return GetFormat(); }
      set { SetFormat( value); }
   }
   /// <summary>Whether the given clock widget should be paused or not.
/// This function pauses or starts the clock widget.</summary>
   public bool Pause {
      get { return GetPause(); }
      set { SetPause( value); }
   }
   /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
   public bool EditMode {
      get { return GetEditMode(); }
      set { SetEditMode( value); }
   }
   /// <summary>The lower boundary of a field.
/// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
/// 
/// Month: default value range is from 0 to 11.
/// 
/// Date: default value range is from 1 to 31 according to the month value.
/// 
/// Hour: default value will be in terms of 24 hr format (0~23)
/// 
/// Minute: default value range is from 0 to 59.</summary>
   public Efl.Time TimeMin {
      get { return GetTimeMin(); }
      set { SetTimeMin( value); }
   }
   /// <summary>The upper boundary of a field.
/// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
/// 
/// Month: default value range is from 0 to 11.
/// 
/// Date: default value range is from 1 to 31 according to the month value.
/// 
/// Hour: default value will be in terms of 24 hr format (0~23)
/// 
/// Minute: default value range is from 0 to 59.</summary>
   public Efl.Time TimeMax {
      get { return GetTimeMax(); }
      set { SetTimeMax( value); }
   }
   /// <summary>The current value of a clock object.
/// Year: years since 1900. Negative value represents year below 1900 (year value -30 represents 1870). Year default range is from 70 to 137.
/// 
/// Month: default value range is from 0 to 11.
/// 
/// Date: default value range is from 1 to 31 according to the month value.
/// 
/// Hour: default value will be in terms of 24 hr format (0~23)
/// 
/// Minute: default value range is from 0 to 59.</summary>
   public Efl.Time Time {
      get { return GetTime(); }
      set { SetTime( value); }
   }
}
public class ClockNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_clock_format_get_static_delegate = new efl_ui_clock_format_get_delegate(format_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_format_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_format_get_static_delegate)});
      efl_ui_clock_format_set_static_delegate = new efl_ui_clock_format_set_delegate(format_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_format_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_format_set_static_delegate)});
      efl_ui_clock_pause_get_static_delegate = new efl_ui_clock_pause_get_delegate(pause_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_pause_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_pause_get_static_delegate)});
      efl_ui_clock_pause_set_static_delegate = new efl_ui_clock_pause_set_delegate(pause_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_pause_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_pause_set_static_delegate)});
      efl_ui_clock_edit_mode_get_static_delegate = new efl_ui_clock_edit_mode_get_delegate(edit_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_edit_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_edit_mode_get_static_delegate)});
      efl_ui_clock_edit_mode_set_static_delegate = new efl_ui_clock_edit_mode_set_delegate(edit_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_edit_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_edit_mode_set_static_delegate)});
      efl_ui_clock_time_min_get_static_delegate = new efl_ui_clock_time_min_get_delegate(time_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_min_get_static_delegate)});
      efl_ui_clock_time_min_set_static_delegate = new efl_ui_clock_time_min_set_delegate(time_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_min_set_static_delegate)});
      efl_ui_clock_time_max_get_static_delegate = new efl_ui_clock_time_max_get_delegate(time_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_max_get_static_delegate)});
      efl_ui_clock_time_max_set_static_delegate = new efl_ui_clock_time_max_set_delegate(time_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_max_set_static_delegate)});
      efl_ui_clock_time_get_static_delegate = new efl_ui_clock_time_get_delegate(time_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_get_static_delegate)});
      efl_ui_clock_time_set_static_delegate = new efl_ui_clock_time_set_delegate(time_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_set_static_delegate)});
      efl_ui_clock_field_visible_get_static_delegate = new efl_ui_clock_field_visible_get_delegate(field_visible_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_field_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_visible_get_static_delegate)});
      efl_ui_clock_field_visible_set_static_delegate = new efl_ui_clock_field_visible_set_delegate(field_visible_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_field_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_visible_set_static_delegate)});
      efl_ui_clock_field_limit_get_static_delegate = new efl_ui_clock_field_limit_get_delegate(field_limit_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_field_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_limit_get_static_delegate)});
      efl_ui_clock_field_limit_set_static_delegate = new efl_ui_clock_field_limit_set_delegate(field_limit_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_clock_field_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_limit_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Clock.efl_ui_clock_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Clock.efl_ui_clock_class_get();
   }


    private delegate  System.IntPtr efl_ui_clock_format_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_clock_format_get(System.IntPtr obj);
    private static  System.IntPtr format_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_format_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Clock)wrapper).GetFormat();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Clock)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_clock_format_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_format_get_delegate efl_ui_clock_format_get_static_delegate;


    private delegate  void efl_ui_clock_format_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String fmt);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_format_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String fmt);
    private static  void format_set(System.IntPtr obj, System.IntPtr pd,   System.String fmt)
   {
      Eina.Log.Debug("function efl_ui_clock_format_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Clock)wrapper).SetFormat( fmt);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_format_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fmt);
      }
   }
   private efl_ui_clock_format_set_delegate efl_ui_clock_format_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_clock_pause_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_clock_pause_get(System.IntPtr obj);
    private static bool pause_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_pause_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Clock)wrapper).GetPause();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_clock_pause_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_pause_get_delegate efl_ui_clock_pause_get_static_delegate;


    private delegate  void efl_ui_clock_pause_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool paused);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_pause_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
    private static  void pause_set(System.IntPtr obj, System.IntPtr pd,  bool paused)
   {
      Eina.Log.Debug("function efl_ui_clock_pause_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Clock)wrapper).SetPause( paused);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_pause_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  paused);
      }
   }
   private efl_ui_clock_pause_set_delegate efl_ui_clock_pause_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_clock_edit_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_clock_edit_mode_get(System.IntPtr obj);
    private static bool edit_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_edit_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Clock)wrapper).GetEditMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_clock_edit_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_edit_mode_get_delegate efl_ui_clock_edit_mode_get_static_delegate;


    private delegate  void efl_ui_clock_edit_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_edit_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool value);
    private static  void edit_mode_set(System.IntPtr obj, System.IntPtr pd,  bool value)
   {
      Eina.Log.Debug("function efl_ui_clock_edit_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Clock)wrapper).SetEditMode( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_edit_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_ui_clock_edit_mode_set_delegate efl_ui_clock_edit_mode_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_clock_time_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_clock_time_min_get(System.IntPtr obj);
    private static Efl.Time_StructInternal time_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_time_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Clock)wrapper).GetTimeMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_clock_time_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_time_min_get_delegate efl_ui_clock_time_min_get_static_delegate;


    private delegate  void efl_ui_clock_time_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal mintime);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_time_min_set(System.IntPtr obj,   Efl.Time_StructInternal mintime);
    private static  void time_min_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal mintime)
   {
      Eina.Log.Debug("function efl_ui_clock_time_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_mintime = Efl.Time_StructConversion.ToManaged(mintime);
                     
         try {
            ((Clock)wrapper).SetTimeMin( _in_mintime);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_time_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mintime);
      }
   }
   private efl_ui_clock_time_min_set_delegate efl_ui_clock_time_min_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_clock_time_max_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_clock_time_max_get(System.IntPtr obj);
    private static Efl.Time_StructInternal time_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_time_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Clock)wrapper).GetTimeMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_clock_time_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_time_max_get_delegate efl_ui_clock_time_max_get_static_delegate;


    private delegate  void efl_ui_clock_time_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal maxtime);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_time_max_set(System.IntPtr obj,   Efl.Time_StructInternal maxtime);
    private static  void time_max_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal maxtime)
   {
      Eina.Log.Debug("function efl_ui_clock_time_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_maxtime = Efl.Time_StructConversion.ToManaged(maxtime);
                     
         try {
            ((Clock)wrapper).SetTimeMax( _in_maxtime);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_time_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  maxtime);
      }
   }
   private efl_ui_clock_time_max_set_delegate efl_ui_clock_time_max_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_clock_time_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_clock_time_get(System.IntPtr obj);
    private static Efl.Time_StructInternal time_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_clock_time_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Clock)wrapper).GetTime();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_clock_time_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_clock_time_get_delegate efl_ui_clock_time_get_static_delegate;


    private delegate  void efl_ui_clock_time_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal curtime);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_time_set(System.IntPtr obj,   Efl.Time_StructInternal curtime);
    private static  void time_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal curtime)
   {
      Eina.Log.Debug("function efl_ui_clock_time_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_curtime = Efl.Time_StructConversion.ToManaged(curtime);
                     
         try {
            ((Clock)wrapper).SetTime( _in_curtime);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_clock_time_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  curtime);
      }
   }
   private efl_ui_clock_time_set_delegate efl_ui_clock_time_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_clock_field_visible_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ClockType fieldtype);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_clock_field_visible_get(System.IntPtr obj,   Efl.Ui.ClockType fieldtype);
    private static bool field_visible_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype)
   {
      Eina.Log.Debug("function efl_ui_clock_field_visible_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Clock)wrapper).GetFieldVisible( fieldtype);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_clock_field_visible_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fieldtype);
      }
   }
   private efl_ui_clock_field_visible_get_delegate efl_ui_clock_field_visible_get_static_delegate;


    private delegate  void efl_ui_clock_field_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ClockType fieldtype,  [MarshalAs(UnmanagedType.U1)]  bool visible);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_field_visible_set(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,  [MarshalAs(UnmanagedType.U1)]  bool visible);
    private static  void field_visible_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype,  bool visible)
   {
      Eina.Log.Debug("function efl_ui_clock_field_visible_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Clock)wrapper).SetFieldVisible( fieldtype,  visible);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_clock_field_visible_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fieldtype,  visible);
      }
   }
   private efl_ui_clock_field_visible_set_delegate efl_ui_clock_field_visible_set_static_delegate;


    private delegate  void efl_ui_clock_field_limit_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ClockType fieldtype,   out  int min,   out  int max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_field_limit_get(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,   out  int min,   out  int max);
    private static  void field_limit_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype,  out  int min,  out  int max)
   {
      Eina.Log.Debug("function efl_ui_clock_field_limit_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       min = default( int);      max = default( int);                           
         try {
            ((Clock)wrapper).GetFieldLimit( fieldtype,  out min,  out max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_clock_field_limit_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fieldtype,  out min,  out max);
      }
   }
   private efl_ui_clock_field_limit_get_delegate efl_ui_clock_field_limit_get_static_delegate;


    private delegate  void efl_ui_clock_field_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ClockType fieldtype,    int min,    int max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_clock_field_limit_set(System.IntPtr obj,   Efl.Ui.ClockType fieldtype,    int min,    int max);
    private static  void field_limit_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype,   int min,   int max)
   {
      Eina.Log.Debug("function efl_ui_clock_field_limit_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Clock)wrapper).SetFieldLimit( fieldtype,  min,  max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_clock_field_limit_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fieldtype,  min,  max);
      }
   }
   private efl_ui_clock_field_limit_set_delegate efl_ui_clock_field_limit_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Identifies a clock field, The widget supports 6 fields : Year, month, Date, Hour, Minute, AM/PM</summary>
public enum ClockType
{
/// <summary>Indicates Year field.</summary>
Year = 0,
/// <summary>Indicates Month field.</summary>
Month = 1,
/// <summary>Indicates Date field.</summary>
Date = 2,
/// <summary>Indicates Hour field.</summary>
Hour = 3,
/// <summary>Indicates Minute field.</summary>
Minute = 4,
/// <summary>Indicates Second field.</summary>
Second = 5,
/// <summary>Indicated Day field.</summary>
Day = 6,
/// <summary>Indicates AM/PM field .</summary>
Ampm = 7,
}
} } 
