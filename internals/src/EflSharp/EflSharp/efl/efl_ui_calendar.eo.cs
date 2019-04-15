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
public class Calendar : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IFormat,Efl.Ui.Focus.IComposition
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Calendar))
                return Efl.Ui.CalendarNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_calendar_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Calendar(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_calendar_class_get(), typeof(Calendar), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Calendar(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Calendar(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
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
    /// <summary>The first day of week to use on calendar widgets.
    /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
    /// <returns>The first day of the week.</returns>
    virtual public Efl.Ui.CalendarWeekday GetFirstDayOfWeek() {
         var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_first_day_of_week_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The first day of week to use on calendar widgets.
    /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
    /// <param name="day">The first day of the week.</param>
    /// <returns></returns>
    virtual public void SetFirstDayOfWeek( Efl.Ui.CalendarWeekday day) {
                                 Efl.Ui.CalendarNativeInherit.efl_ui_calendar_first_day_of_week_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), day);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the minimum date.
    /// Default value is 1 JAN,1902.</summary>
    /// <returns>Time structure containing the minimum date.</returns>
    virtual public Efl.Time GetDateMin() {
         var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the minimum date on calendar.
    /// Set the minimum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is smaller than minimum date. If the minimum date is greater than current maximum date, the minimum date would be changed to the maximum date with returning <c>false</c>.</summary>
    /// <param name="min">Time structure containing the minimum date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDateMin( Efl.Time min) {
         Efl.Time.NativeStruct _in_min = min;
                        var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_min_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_min);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the maximum date.
    /// Default maximum year is -1. Default maximum day and month are 31 and DEC.
    /// 
    /// If the maximum year is a negative value, it will be limited depending on the platform architecture (year 2037 for 32 bits);</summary>
    /// <returns>Time structure containing the maximum date.</returns>
    virtual public Efl.Time GetDateMax() {
         var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the maximum date on calendar.
    /// Set the maximum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is bigger than maximum date. If the maximum date is less than current minimum date, the maximum date would be changed to the minimum date with returning <c>false</c>.</summary>
    /// <param name="max">Time structure containing the maximum date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDateMax( Efl.Time max) {
         Efl.Time.NativeStruct _in_max = max;
                        var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_max_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_max);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The selected date on calendar.</summary>
    /// <returns>Time structure containing the selected date.</returns>
    virtual public Efl.Time GetDate() {
         var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the selected date. If the date is greater than the maximum date, the date would be changed to the maximum date with returning <c>false</c>. In the opposite case with the minimum date, this would give the same result.</summary>
    /// <param name="date">Time structure containing the selected date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDate( Efl.Time date) {
         Efl.Time.NativeStruct _in_date = date;
                        var _ret_var = Efl.Ui.CalendarNativeInherit.efl_ui_calendar_date_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_date);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set the format function pointer to format the string.</summary>
    /// <param name="func">The format function callback</param>
    /// <returns></returns>
    virtual public void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatNativeInherit.efl_ui_format_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
    virtual public System.String GetFormatString() {
         var _ret_var = Efl.Ui.IFormatNativeInherit.efl_ui_format_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
    /// <returns></returns>
    virtual public void SetFormatString( System.String units) {
                                 Efl.Ui.IFormatNativeInherit.efl_ui_format_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), units);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <returns>The order to use</returns>
    virtual public Eina.List<Efl.Gfx.IEntity> GetCompositionElements() {
         var _ret_var = Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
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
    virtual public void SetCompositionElements( Eina.List<Efl.Gfx.IEntity> logical_order) {
         var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                        Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    virtual public bool GetLogicalMode() {
         var _ret_var = Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    /// <returns></returns>
    virtual public void SetLogicalMode( bool logical_mode) {
                                 Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), logical_mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    /// <returns></returns>
    virtual public void Dirty() {
         Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_dirty_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    /// <returns></returns>
    virtual public void Prepare() {
         Efl.Ui.Focus.ICompositionNativeInherit.efl_ui_focus_composition_prepare_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The first day of week to use on calendar widgets.
/// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
/// <value>The first day of the week.</value>
    public Efl.Ui.CalendarWeekday FirstDayOfWeek {
        get { return GetFirstDayOfWeek(); }
        set { SetFirstDayOfWeek( value); }
    }
    /// <summary>Minimum date on calendar.</summary>
/// <value>Time structure containing the minimum date.</value>
    public Efl.Time DateMin {
        get { return GetDateMin(); }
        set { SetDateMin( value); }
    }
    /// <summary>Maximum date on calendar.</summary>
/// <value>Time structure containing the maximum date.</value>
    public Efl.Time DateMax {
        get { return GetDateMax(); }
        set { SetDateMax( value); }
    }
    /// <summary>The selected date on calendar.</summary>
/// <value>Time structure containing the selected date.</value>
    public Efl.Time Date {
        get { return GetDate(); }
        set { SetDate( value); }
    }
    /// <summary>Set the format function pointer to format the string.</summary>
/// <value>The format function callback</value>
    public Efl.Ui.FormatFuncCb FormatCb {
        set { SetFormatCb( value); }
    }
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <value>The format string for <c>obj</c>&apos;s units label.</value>
    public System.String FormatString {
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
/// <value>The order to use</value>
    public Eina.List<Efl.Gfx.IEntity> CompositionElements {
        get { return GetCompositionElements(); }
        set { SetCompositionElements( value); }
    }
    /// <summary>Set to true if all children should be registered as logicals</summary>
/// <value><c>true</c> or <c>false</c></value>
    public bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Calendar.efl_ui_calendar_class_get();
    }
}
public class CalendarNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_calendar_first_day_of_week_get_static_delegate == null)
            efl_ui_calendar_first_day_of_week_get_static_delegate = new efl_ui_calendar_first_day_of_week_get_delegate(first_day_of_week_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFirstDayOfWeek") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_first_day_of_week_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_get_static_delegate)});
        if (efl_ui_calendar_first_day_of_week_set_static_delegate == null)
            efl_ui_calendar_first_day_of_week_set_static_delegate = new efl_ui_calendar_first_day_of_week_set_delegate(first_day_of_week_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFirstDayOfWeek") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_first_day_of_week_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_set_static_delegate)});
        if (efl_ui_calendar_date_min_get_static_delegate == null)
            efl_ui_calendar_date_min_get_static_delegate = new efl_ui_calendar_date_min_get_delegate(date_min_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDateMin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_get_static_delegate)});
        if (efl_ui_calendar_date_min_set_static_delegate == null)
            efl_ui_calendar_date_min_set_static_delegate = new efl_ui_calendar_date_min_set_delegate(date_min_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDateMin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_set_static_delegate)});
        if (efl_ui_calendar_date_max_get_static_delegate == null)
            efl_ui_calendar_date_max_get_static_delegate = new efl_ui_calendar_date_max_get_delegate(date_max_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDateMax") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_get_static_delegate)});
        if (efl_ui_calendar_date_max_set_static_delegate == null)
            efl_ui_calendar_date_max_set_static_delegate = new efl_ui_calendar_date_max_set_delegate(date_max_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDateMax") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_set_static_delegate)});
        if (efl_ui_calendar_date_get_static_delegate == null)
            efl_ui_calendar_date_get_static_delegate = new efl_ui_calendar_date_get_delegate(date_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_get_static_delegate)});
        if (efl_ui_calendar_date_set_static_delegate == null)
            efl_ui_calendar_date_set_static_delegate = new efl_ui_calendar_date_set_delegate(date_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_calendar_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_set_static_delegate)});
        if (efl_ui_format_cb_set_static_delegate == null)
            efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatCb") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
        if (efl_ui_format_string_get_static_delegate == null)
            efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
        if (efl_ui_format_string_set_static_delegate == null)
            efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
        if (efl_ui_focus_composition_elements_get_static_delegate == null)
            efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCompositionElements") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate)});
        if (efl_ui_focus_composition_elements_set_static_delegate == null)
            efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCompositionElements") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate)});
        if (efl_ui_focus_composition_logical_mode_get_static_delegate == null)
            efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLogicalMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate)});
        if (efl_ui_focus_composition_logical_mode_set_static_delegate == null)
            efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLogicalMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate)});
        if (efl_ui_focus_composition_dirty_static_delegate == null)
            efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
        if (methods.FirstOrDefault(m => m.Name == "Dirty") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate)});
        if (efl_ui_focus_composition_prepare_static_delegate == null)
            efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
        if (methods.FirstOrDefault(m => m.Name == "Prepare") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate)});
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


     public delegate Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_get_api_delegate> efl_ui_calendar_first_day_of_week_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_get_api_delegate>(_Module, "efl_ui_calendar_first_day_of_week_get");
     private static Efl.Ui.CalendarWeekday first_day_of_week_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
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
            return efl_ui_calendar_first_day_of_week_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_calendar_first_day_of_week_get_delegate efl_ui_calendar_first_day_of_week_get_static_delegate;


     private delegate void efl_ui_calendar_first_day_of_week_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.CalendarWeekday day);


     public delegate void efl_ui_calendar_first_day_of_week_set_api_delegate(System.IntPtr obj,   Efl.Ui.CalendarWeekday day);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_set_api_delegate> efl_ui_calendar_first_day_of_week_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_set_api_delegate>(_Module, "efl_ui_calendar_first_day_of_week_set");
     private static void first_day_of_week_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.CalendarWeekday day)
    {
        Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Calendar)wrapper).SetFirstDayOfWeek( day);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_calendar_first_day_of_week_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  day);
        }
    }
    private static efl_ui_calendar_first_day_of_week_set_delegate efl_ui_calendar_first_day_of_week_set_static_delegate;


     private delegate Efl.Time.NativeStruct efl_ui_calendar_date_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Time.NativeStruct efl_ui_calendar_date_min_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_get_api_delegate> efl_ui_calendar_date_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_get_api_delegate>(_Module, "efl_ui_calendar_date_min_get");
     private static Efl.Time.NativeStruct date_min_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_min_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Time _ret_var = default(Efl.Time);
            try {
                _ret_var = ((Calendar)wrapper).GetDateMin();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_calendar_date_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_calendar_date_min_get_delegate efl_ui_calendar_date_min_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time.NativeStruct min);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_calendar_date_min_set_api_delegate(System.IntPtr obj,   Efl.Time.NativeStruct min);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_set_api_delegate> efl_ui_calendar_date_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_set_api_delegate>(_Module, "efl_ui_calendar_date_min_set");
     private static bool date_min_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct min)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_min_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Time _in_min = min;
                            bool _ret_var = default(bool);
            try {
                _ret_var = ((Calendar)wrapper).SetDateMin( _in_min);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_calendar_date_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min);
        }
    }
    private static efl_ui_calendar_date_min_set_delegate efl_ui_calendar_date_min_set_static_delegate;


     private delegate Efl.Time.NativeStruct efl_ui_calendar_date_max_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Time.NativeStruct efl_ui_calendar_date_max_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_get_api_delegate> efl_ui_calendar_date_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_get_api_delegate>(_Module, "efl_ui_calendar_date_max_get");
     private static Efl.Time.NativeStruct date_max_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_max_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Time _ret_var = default(Efl.Time);
            try {
                _ret_var = ((Calendar)wrapper).GetDateMax();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_calendar_date_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_calendar_date_max_get_delegate efl_ui_calendar_date_max_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time.NativeStruct max);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_calendar_date_max_set_api_delegate(System.IntPtr obj,   Efl.Time.NativeStruct max);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_set_api_delegate> efl_ui_calendar_date_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_set_api_delegate>(_Module, "efl_ui_calendar_date_max_set");
     private static bool date_max_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct max)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_max_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Time _in_max = max;
                            bool _ret_var = default(bool);
            try {
                _ret_var = ((Calendar)wrapper).SetDateMax( _in_max);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_calendar_date_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  max);
        }
    }
    private static efl_ui_calendar_date_max_set_delegate efl_ui_calendar_date_max_set_static_delegate;


     private delegate Efl.Time.NativeStruct efl_ui_calendar_date_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Time.NativeStruct efl_ui_calendar_date_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_get_api_delegate> efl_ui_calendar_date_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_get_api_delegate>(_Module, "efl_ui_calendar_date_get");
     private static Efl.Time.NativeStruct date_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Time _ret_var = default(Efl.Time);
            try {
                _ret_var = ((Calendar)wrapper).GetDate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_calendar_date_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_calendar_date_get_delegate efl_ui_calendar_date_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_calendar_date_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Time.NativeStruct date);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_calendar_date_set_api_delegate(System.IntPtr obj,   Efl.Time.NativeStruct date);
     public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_set_api_delegate> efl_ui_calendar_date_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_set_api_delegate>(_Module, "efl_ui_calendar_date_set");
     private static bool date_set(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct date)
    {
        Eina.Log.Debug("function efl_ui_calendar_date_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Time _in_date = date;
                            bool _ret_var = default(bool);
            try {
                _ret_var = ((Calendar)wrapper).SetDate( _in_date);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_calendar_date_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  date);
        }
    }
    private static efl_ui_calendar_date_set_delegate efl_ui_calendar_date_set_static_delegate;


     private delegate void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);


     public delegate void efl_ui_format_cb_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate> efl_ui_format_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate>(_Module, "efl_ui_format_cb_set");
     private static void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
    {
        Eina.Log.Debug("function efl_ui_format_cb_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                        Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
            
            try {
                ((Calendar)wrapper).SetFormatCb( func_wrapper.ManagedCb);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
        }
    }
    private static efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_format_string_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(_Module, "efl_ui_format_string_get");
     private static System.String format_string_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_format_string_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Calendar)wrapper).GetFormatString();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


     private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);


     public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(_Module, "efl_ui_format_string_set");
     private static void format_string_set(System.IntPtr obj, System.IntPtr pd,  System.String units)
    {
        Eina.Log.Debug("function efl_ui_format_string_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Calendar)wrapper).SetFormatString( units);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
        }
    }
    private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;


     private delegate System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(_Module, "efl_ui_focus_composition_elements_get");
     private static System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.List<Efl.Gfx.IEntity> _ret_var = default(Eina.List<Efl.Gfx.IEntity>);
            try {
                _ret_var = ((Calendar)wrapper).GetCompositionElements();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_ui_focus_composition_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;


     private delegate void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr logical_order);


     public delegate void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,   System.IntPtr logical_order);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(_Module, "efl_ui_focus_composition_elements_set");
     private static void composition_elements_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr logical_order)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    var _in_logical_order = new Eina.List<Efl.Gfx.IEntity>(logical_order, true, false);
                            
            try {
                ((Calendar)wrapper).SetCompositionElements( _in_logical_order);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_focus_composition_elements_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_order);
        }
    }
    private static efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(_Module, "efl_ui_focus_composition_logical_mode_get");
     private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
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
            return efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;


     private delegate void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);


     public delegate void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(_Module, "efl_ui_focus_composition_logical_mode_set");
     private static void logical_mode_set(System.IntPtr obj, System.IntPtr pd,  bool logical_mode)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Calendar)wrapper).SetLogicalMode( logical_mode);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_mode);
        }
    }
    private static efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;


     private delegate void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(_Module, "efl_ui_focus_composition_dirty");
     private static void dirty(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Calendar)wrapper).Dirty();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_focus_composition_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;


     private delegate void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(_Module, "efl_ui_focus_composition_prepare");
     private static void prepare(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Calendar)wrapper).Prepare();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_focus_composition_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;
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
