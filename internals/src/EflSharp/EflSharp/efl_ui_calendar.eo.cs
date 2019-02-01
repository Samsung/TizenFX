#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Calendar widget
/// It helps applications to flexibly display a calendar with day of the week, date, year and month. Applications are able to set specific dates to be reported back, when selected, in the smart callbacks of the calendar widget.</summary>
[CalendarNativeInherit]
public class Calendar : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Ui.Format,Efl.Ui.Focus.Composition
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.CalendarNativeInherit nativeInherit = new Efl.Ui.CalendarNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Calendar))
            return Efl.Ui.CalendarNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Calendar obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_calendar_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Calendar(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Calendar", efl_ui_calendar_class_get(), typeof(Calendar), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Calendar(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Calendar(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Calendar static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Calendar(obj.NativeHandle);
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
   /// <summary>Emitted when the selected date in the calendar is changed</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
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
    protected static extern Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get(System.IntPtr obj);
   /// <summary>The first day of week to use on calendar widgets.
   /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
   /// <returns>The first day of the week.</returns>
   virtual public Efl.Ui.CalendarWeekday GetFirstDayOfWeek() {
       var _ret_var = efl_ui_calendar_first_day_of_week_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_calendar_first_day_of_week_set(System.IntPtr obj,   Efl.Ui.CalendarWeekday day);
   /// <summary>The first day of week to use on calendar widgets.
   /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
   /// <param name="day">The first day of the week.</param>
   /// <returns></returns>
   virtual public  void SetFirstDayOfWeek( Efl.Ui.CalendarWeekday day) {
                         efl_ui_calendar_first_day_of_week_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  day);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_calendar_date_min_get(System.IntPtr obj);
   /// <summary>Get the minimum date.
   /// Default value is 1 JAN,1902.</summary>
   /// <returns>Time structure containing the minimum date.</returns>
   virtual public Efl.Time GetDateMin() {
       var _ret_var = efl_ui_calendar_date_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_calendar_date_min_set(System.IntPtr obj,   Efl.Time_StructInternal min);
   /// <summary>Set the minimum date on calendar.
   /// Set the minimum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is smaller than minimum date. If the minimum date is greater than current maximum date, the minimum date would be changed to the maximum date with returning <c>false</c>.</summary>
   /// <param name="min">Time structure containing the minimum date.</param>
   /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
   virtual public bool SetDateMin( Efl.Time min) {
       var _in_min = Efl.Time_StructConversion.ToInternal(min);
                  var _ret_var = efl_ui_calendar_date_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_min);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_calendar_date_max_get(System.IntPtr obj);
   /// <summary>Get the maximum date.
   /// Default maximum year is -1. Default maximum day and month are 31 and DEC.
   /// 
   /// If the maximum year is a negative value, it will be limited depending on the platform architecture (year 2037 for 32 bits);</summary>
   /// <returns>Time structure containing the maximum date.</returns>
   virtual public Efl.Time GetDateMax() {
       var _ret_var = efl_ui_calendar_date_max_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_calendar_date_max_set(System.IntPtr obj,   Efl.Time_StructInternal max);
   /// <summary>Set the maximum date on calendar.
   /// Set the maximum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is bigger than maximum date. If the maximum date is less than current minimum date, the maximum date would be changed to the minimum date with returning <c>false</c>.</summary>
   /// <param name="max">Time structure containing the maximum date.</param>
   /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
   virtual public bool SetDateMax( Efl.Time max) {
       var _in_max = Efl.Time_StructConversion.ToInternal(max);
                  var _ret_var = efl_ui_calendar_date_max_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_max);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Time_StructInternal efl_ui_calendar_date_get(System.IntPtr obj);
   /// <summary>The selected date on calendar.</summary>
   /// <returns>Time structure containing the selected date.</returns>
   virtual public Efl.Time GetDate() {
       var _ret_var = efl_ui_calendar_date_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Time_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_calendar_date_set(System.IntPtr obj,   Efl.Time_StructInternal date);
   /// <summary>Set the selected date. If the date is greater than the maximum date, the date would be changed to the maximum date with returning <c>false</c>. In the opposite case with the minimum date, this would give the same result.</summary>
   /// <param name="date">Time structure containing the selected date.</param>
   /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
   virtual public bool SetDate( Efl.Time date) {
       var _in_date = Efl.Time_StructConversion.ToInternal(date);
                  var _ret_var = efl_ui_calendar_date_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_date);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_format_cb_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
   /// <summary>Set the format function pointer to format the string.</summary>
   /// <param name="func">The format function callback</param>
   /// <returns></returns>
   virtual public  void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      efl_ui_format_cb_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_format_string_get(System.IntPtr obj);
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
   virtual public  System.String GetFormatString() {
       var _ret_var = efl_ui_format_string_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_format_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
   /// <returns></returns>
   virtual public  void SetFormatString(  System.String units) {
                         efl_ui_format_string_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  units);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <returns>The order to use</returns>
   virtual public Eina.List<Efl.Gfx.Entity> GetCompositionElements() {
       var _ret_var = efl_ui_focus_composition_elements_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <param name="logical_order">The order to use</param>
   /// <returns></returns>
   virtual public  void SetCompositionElements( Eina.List<Efl.Gfx.Entity> logical_order) {
       var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                  efl_ui_focus_composition_elements_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_logical_order);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <returns>EFL focus manager</returns>
   virtual public Efl.Ui.Focus.Manager GetCustomManager() {
       var _ret_var = efl_ui_focus_composition_custom_manager_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <param name="custom_manager">EFL focus manager</param>
   /// <returns></returns>
   virtual public  void SetCustomManager( Efl.Ui.Focus.Manager custom_manager) {
                         efl_ui_focus_composition_custom_manager_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  custom_manager);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <returns><c>true</c> or <c>false</c></returns>
   virtual public bool GetLogicalMode() {
       var _ret_var = efl_ui_focus_composition_logical_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
   /// <returns></returns>
   virtual public  void SetLogicalMode( bool logical_mode) {
                         efl_ui_focus_composition_logical_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  logical_mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
   /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
   /// <returns></returns>
   virtual public  void Dirty() {
       efl_ui_focus_composition_dirty((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
   /// <summary>A call to prepare the children of this element, called if marked as dirty
   /// You can use this function to call composition_elements.</summary>
   /// <returns></returns>
   virtual public  void Prepare() {
       efl_ui_focus_composition_prepare((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>The first day of week to use on calendar widgets.
/// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
   public Efl.Ui.CalendarWeekday FirstDayOfWeek {
      get { return GetFirstDayOfWeek(); }
      set { SetFirstDayOfWeek( value); }
   }
   /// <summary>Minimum date on calendar.</summary>
   public Efl.Time DateMin {
      get { return GetDateMin(); }
      set { SetDateMin( value); }
   }
   /// <summary>Maximum date on calendar.</summary>
   public Efl.Time DateMax {
      get { return GetDateMax(); }
      set { SetDateMax( value); }
   }
   /// <summary>The selected date on calendar.</summary>
   public Efl.Time Date {
      get { return GetDate(); }
      set { SetDate( value); }
   }
   /// <summary>Set the format function pointer to format the string.</summary>
   public Efl.Ui.FormatFuncCb FormatCb {
      set { SetFormatCb( value); }
   }
   /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   public  System.String FormatString {
      get { return GetFormatString(); }
      set { SetFormatString( value); }
   }
   /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   public Eina.List<Efl.Gfx.Entity> CompositionElements {
      get { return GetCompositionElements(); }
      set { SetCompositionElements( value); }
   }
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   public Efl.Ui.Focus.Manager CustomManager {
      get { return GetCustomManager(); }
      set { SetCustomManager( value); }
   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   public bool LogicalMode {
      get { return GetLogicalMode(); }
      set { SetLogicalMode( value); }
   }
}
public class CalendarNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_calendar_first_day_of_week_get_static_delegate = new efl_ui_calendar_first_day_of_week_get_delegate(first_day_of_week_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_first_day_of_week_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_get_static_delegate)});
      efl_ui_calendar_first_day_of_week_set_static_delegate = new efl_ui_calendar_first_day_of_week_set_delegate(first_day_of_week_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_first_day_of_week_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_set_static_delegate)});
      efl_ui_calendar_date_min_get_static_delegate = new efl_ui_calendar_date_min_get_delegate(date_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_get_static_delegate)});
      efl_ui_calendar_date_min_set_static_delegate = new efl_ui_calendar_date_min_set_delegate(date_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_set_static_delegate)});
      efl_ui_calendar_date_max_get_static_delegate = new efl_ui_calendar_date_max_get_delegate(date_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_get_static_delegate)});
      efl_ui_calendar_date_max_set_static_delegate = new efl_ui_calendar_date_max_set_delegate(date_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_set_static_delegate)});
      efl_ui_calendar_date_get_static_delegate = new efl_ui_calendar_date_get_delegate(date_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_get_static_delegate)});
      efl_ui_calendar_date_set_static_delegate = new efl_ui_calendar_date_set_delegate(date_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_calendar_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_set_static_delegate)});
      efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
      efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
      efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
      efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate)});
      efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate)});
      efl_ui_focus_composition_custom_manager_get_static_delegate = new efl_ui_focus_composition_custom_manager_get_delegate(custom_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_get_static_delegate)});
      efl_ui_focus_composition_custom_manager_set_static_delegate = new efl_ui_focus_composition_custom_manager_set_delegate(custom_manager_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_set_static_delegate)});
      efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate)});
      efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate)});
      efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate)});
      efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Calendar.efl_ui_calendar_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Calendar.efl_ui_calendar_class_get();
   }


    private delegate Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get(System.IntPtr obj);
    private static Efl.Ui.CalendarWeekday first_day_of_week_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.CalendarWeekday _ret_var = default(Efl.Ui.CalendarWeekday);
         try {
            _ret_var = ((Calendar)wrapper).GetFirstDayOfWeek();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_calendar_first_day_of_week_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_calendar_first_day_of_week_get_delegate efl_ui_calendar_first_day_of_week_get_static_delegate;


    private delegate  void efl_ui_calendar_first_day_of_week_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.CalendarWeekday day);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_calendar_first_day_of_week_set(System.IntPtr obj,   Efl.Ui.CalendarWeekday day);
    private static  void first_day_of_week_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.CalendarWeekday day)
   {
      Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Calendar)wrapper).SetFirstDayOfWeek( day);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_calendar_first_day_of_week_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  day);
      }
   }
   private efl_ui_calendar_first_day_of_week_set_delegate efl_ui_calendar_first_day_of_week_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_calendar_date_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_calendar_date_min_get(System.IntPtr obj);
    private static Efl.Time_StructInternal date_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Calendar)wrapper).GetDateMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_calendar_date_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_calendar_date_min_get_delegate efl_ui_calendar_date_min_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal min);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_calendar_date_min_set(System.IntPtr obj,   Efl.Time_StructInternal min);
    private static bool date_min_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal min)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_min = Efl.Time_StructConversion.ToManaged(min);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Calendar)wrapper).SetDateMin( _in_min);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_calendar_date_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min);
      }
   }
   private efl_ui_calendar_date_min_set_delegate efl_ui_calendar_date_min_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_calendar_date_max_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_calendar_date_max_get(System.IntPtr obj);
    private static Efl.Time_StructInternal date_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Calendar)wrapper).GetDateMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_calendar_date_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_calendar_date_max_get_delegate efl_ui_calendar_date_max_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal max);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_calendar_date_max_set(System.IntPtr obj,   Efl.Time_StructInternal max);
    private static bool date_max_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal max)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_max = Efl.Time_StructConversion.ToManaged(max);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Calendar)wrapper).SetDateMax( _in_max);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_calendar_date_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  max);
      }
   }
   private efl_ui_calendar_date_max_set_delegate efl_ui_calendar_date_max_set_static_delegate;


    private delegate Efl.Time_StructInternal efl_ui_calendar_date_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Time_StructInternal efl_ui_calendar_date_get(System.IntPtr obj);
    private static Efl.Time_StructInternal date_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Time _ret_var = default(Efl.Time);
         try {
            _ret_var = ((Calendar)wrapper).GetDate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Time_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_calendar_date_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_calendar_date_get_delegate efl_ui_calendar_date_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time_StructInternal date);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_calendar_date_set(System.IntPtr obj,   Efl.Time_StructInternal date);
    private static bool date_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time_StructInternal date)
   {
      Eina.Log.Debug("function efl_ui_calendar_date_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_date = Efl.Time_StructConversion.ToManaged(date);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Calendar)wrapper).SetDate( _in_date);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_calendar_date_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  date);
      }
   }
   private efl_ui_calendar_date_set_delegate efl_ui_calendar_date_set_static_delegate;


    private delegate  void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_format_cb_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
    private static  void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_ui_format_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
         
         try {
            ((Calendar)wrapper).SetFormatCb( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_cb_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


    private delegate  System.IntPtr efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_ui_format_string_get(System.IntPtr obj);
    private static  System.IntPtr format_string_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_format_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Calendar)wrapper).GetFormatString();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Calendar)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_format_string_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


    private delegate  void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_format_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
    private static  void format_string_set(System.IntPtr obj, System.IntPtr pd,   System.String units)
   {
      Eina.Log.Debug("function efl_ui_format_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Calendar)wrapper).SetFormatString( units);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_string_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
      }
   }
   private efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
    private static  System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Gfx.Entity> _ret_var = default(Eina.List<Efl.Gfx.Entity>);
         try {
            _ret_var = ((Calendar)wrapper).GetCompositionElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_ui_focus_composition_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;


    private delegate  void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr logical_order);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
    private static  void composition_elements_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr logical_order)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_logical_order = new Eina.List<Efl.Gfx.Entity>(logical_order, true, false);
                     
         try {
            ((Calendar)wrapper).SetCompositionElements( _in_logical_order);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_elements_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_order);
      }
   }
   private efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager custom_manager_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((Calendar)wrapper).GetCustomManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_custom_manager_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_custom_manager_get_delegate efl_ui_focus_composition_custom_manager_get_static_delegate;


    private delegate  void efl_ui_focus_composition_custom_manager_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
    private static  void custom_manager_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager custom_manager)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Calendar)wrapper).SetCustomManager( custom_manager);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_custom_manager_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  custom_manager);
      }
   }
   private efl_ui_focus_composition_custom_manager_set_delegate efl_ui_focus_composition_custom_manager_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
    private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Calendar)wrapper).GetLogicalMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_logical_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;


    private delegate  void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
    private static  void logical_mode_set(System.IntPtr obj, System.IntPtr pd,  bool logical_mode)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Calendar)wrapper).SetLogicalMode( logical_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_logical_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_mode);
      }
   }
   private efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;


    private delegate  void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
    private static  void dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Calendar)wrapper).Dirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_dirty(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;


    private delegate  void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
    private static  void prepare(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Calendar)wrapper).Prepare();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_prepare(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>A weekday
/// See also <see cref="Efl.Ui.Calendar.SetFirstDayOfWeek"/>.</summary>
public enum CalendarWeekday
{
/// <summary>Sunday weekday</summary>
Sunday = 0,
/// <summary>Monday weekday</summary>
Monday = 1,
/// <summary>Tuesday weekday</summary>
Tuesday = 2,
/// <summary>Wednesday weekday</summary>
Wednesday = 3,
/// <summary>Thursday weekday</summary>
Thursday = 4,
/// <summary>Friday weekday</summary>
Friday = 5,
/// <summary>Saturday weekday</summary>
Saturday = 6,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 7,
}
} } 
