#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Calendar widget
/// It helps applications to flexibly display a calendar with day of the week, date, year and month. Applications are able to set specific dates to be reported back, when selected, in the smart callbacks of the calendar widget.</summary>
[Efl.Ui.Calendar.NativeMethods]
[Efl.Eo.BindingEntity]
public class Calendar : Efl.Ui.LayoutBase, Efl.Ui.IFormat, Efl.Ui.Focus.IComposition
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Calendar))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_calendar_class_get();
    /// <summary>Initializes a new instance of the <see cref="Calendar"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Calendar(Efl.Object parent
            , System.String style = null) : base(efl_ui_calendar_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Calendar(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Calendar"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Calendar(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Calendar"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Calendar(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Emitted when the selected date in the calendar is changed</summary>
    public event EventHandler ChangedEvt
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

                string key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_CALENDAR_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The first day of week to use on calendar widgets.
    /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
    /// <returns>The first day of the week.</returns>
    virtual public Efl.Ui.CalendarWeekday GetFirstDayOfWeek() {
         var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_first_day_of_week_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The first day of week to use on calendar widgets.
    /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
    /// <param name="day">The first day of the week.</param>
    virtual public void SetFirstDayOfWeek(Efl.Ui.CalendarWeekday day) {
                                 Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_first_day_of_week_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),day);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the minimum date.
    /// Default value is 1 JAN,1902.</summary>
    /// <returns>Time structure containing the minimum date.</returns>
    virtual public Efl.Time GetDateMin() {
         var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the minimum date on calendar.
    /// Set the minimum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is smaller than minimum date. If the minimum date is greater than current maximum date, the minimum date would be changed to the maximum date with returning <c>false</c>.</summary>
    /// <param name="min">Time structure containing the minimum date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDateMin(Efl.Time min) {
         Efl.Time.NativeStruct _in_min = min;
                        var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_min);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the maximum date.
    /// Default maximum year is -1. Default maximum day and month are 31 and DEC.
    /// 
    /// If the maximum year is a negative value, it will be limited depending on the platform architecture (year 2037 for 32 bits);</summary>
    /// <returns>Time structure containing the maximum date.</returns>
    virtual public Efl.Time GetDateMax() {
         var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the maximum date on calendar.
    /// Set the maximum date, changing the displayed month or year if needed. Displayed day also to be disabled if it is bigger than maximum date. If the maximum date is less than current minimum date, the maximum date would be changed to the minimum date with returning <c>false</c>.</summary>
    /// <param name="max">Time structure containing the maximum date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDateMax(Efl.Time max) {
         Efl.Time.NativeStruct _in_max = max;
                        var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_max);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The selected date on calendar.</summary>
    /// <returns>Time structure containing the selected date.</returns>
    virtual public Efl.Time GetDate() {
         var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the selected date. If the date is greater than the maximum date, the date would be changed to the maximum date with returning <c>false</c>. In the opposite case with the minimum date, this would give the same result.</summary>
    /// <param name="date">Time structure containing the selected date.</param>
    /// <returns><c>true</c>, on success, <c>false</c> otherwise</returns>
    virtual public bool SetDate(Efl.Time date) {
         Efl.Time.NativeStruct _in_date = date;
                        var _ret_var = Efl.Ui.Calendar.NativeMethods.efl_ui_calendar_date_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_date);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <returns>User-provided formatting function.</returns>
    virtual public Efl.Ui.FormatFunc GetFormatFunc() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <param name="func">User-provided formatting function.</param>
    virtual public void SetFormatFunc(Efl.Ui.FormatFunc func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</returns>
    virtual public Eina.Accessor<Efl.Ui.FormatValue> GetFormatValues() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Efl.Ui.FormatValue>(_ret_var, false);
 }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</param>
    virtual public void SetFormatValues(Eina.Accessor<Efl.Ui.FormatValue> values) {
         var _in_values = values.Handle;
                        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_values);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    virtual public void GetFormatString(out System.String kw_string, out Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out kw_string, out type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    virtual public void SetFormatString(System.String kw_string, Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string, type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
    /// <see cref="Efl.Ui.IFormat.GetFormattedValue"/> uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
    /// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
    /// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
    virtual public void GetFormattedValue(Eina.Strbuf str, Eina.Value value) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_formatted_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),str, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="Efl.Ui.IFormat.GetFormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
    /// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
    /// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
    virtual public int GetDecimalPlaces() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_decimal_places_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Internal method to be implemented by widgets including this mixin.
    /// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call <see cref="Efl.Ui.IFormat.GetFormattedValue"/> and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
    virtual public void ApplyFormattedValue() {
         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_apply_formatted_value_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public void SetCompositionElements(Eina.List<Efl.Gfx.IEntity> logical_order) {
         var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                        Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    virtual public bool GetLogicalMode() {
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    virtual public void SetLogicalMode(bool logical_mode) {
                                 Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),logical_mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    virtual public void Dirty() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_dirty_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    virtual public void Prepare() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_prepare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The first day of week to use on calendar widgets.
    /// This is the day that will appear in the left-most column (eg. Monday in France or Sunday in the US).</summary>
    /// <value>The first day of the week.</value>
    public Efl.Ui.CalendarWeekday FirstDayOfWeek {
        get { return GetFirstDayOfWeek(); }
        set { SetFirstDayOfWeek(value); }
    }
    /// <summary>Minimum date on calendar.</summary>
    /// <value>Time structure containing the minimum date.</value>
    public Efl.Time DateMin {
        get { return GetDateMin(); }
        set { SetDateMin(value); }
    }
    /// <summary>Maximum date on calendar.</summary>
    /// <value>Time structure containing the maximum date.</value>
    public Efl.Time DateMax {
        get { return GetDateMax(); }
        set { SetDateMax(value); }
    }
    /// <summary>The selected date on calendar.</summary>
    /// <value>Time structure containing the selected date.</value>
    public Efl.Time Date {
        get { return GetDate(); }
        set { SetDate(value); }
    }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <value>User-provided formatting function.</value>
    public Efl.Ui.FormatFunc FormatFunc {
        get { return GetFormatFunc(); }
        set { SetFormatFunc(value); }
    }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</value>
    public Eina.Accessor<Efl.Ui.FormatValue> FormatValues {
        get { return GetFormatValues(); }
        set { SetFormatValues(value); }
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
        set { SetCompositionElements(value); }
    }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <value><c>true</c> or <c>false</c></value>
    public bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Calendar.efl_ui_calendar_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_calendar_first_day_of_week_get_static_delegate == null)
            {
                efl_ui_calendar_first_day_of_week_get_static_delegate = new efl_ui_calendar_first_day_of_week_get_delegate(first_day_of_week_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFirstDayOfWeek") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_first_day_of_week_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_get_static_delegate) });
            }

            if (efl_ui_calendar_first_day_of_week_set_static_delegate == null)
            {
                efl_ui_calendar_first_day_of_week_set_static_delegate = new efl_ui_calendar_first_day_of_week_set_delegate(first_day_of_week_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFirstDayOfWeek") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_first_day_of_week_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_first_day_of_week_set_static_delegate) });
            }

            if (efl_ui_calendar_date_min_get_static_delegate == null)
            {
                efl_ui_calendar_date_min_get_static_delegate = new efl_ui_calendar_date_min_get_delegate(date_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDateMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_get_static_delegate) });
            }

            if (efl_ui_calendar_date_min_set_static_delegate == null)
            {
                efl_ui_calendar_date_min_set_static_delegate = new efl_ui_calendar_date_min_set_delegate(date_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDateMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_min_set_static_delegate) });
            }

            if (efl_ui_calendar_date_max_get_static_delegate == null)
            {
                efl_ui_calendar_date_max_get_static_delegate = new efl_ui_calendar_date_max_get_delegate(date_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDateMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_get_static_delegate) });
            }

            if (efl_ui_calendar_date_max_set_static_delegate == null)
            {
                efl_ui_calendar_date_max_set_static_delegate = new efl_ui_calendar_date_max_set_delegate(date_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDateMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_max_set_static_delegate) });
            }

            if (efl_ui_calendar_date_get_static_delegate == null)
            {
                efl_ui_calendar_date_get_static_delegate = new efl_ui_calendar_date_get_delegate(date_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_get_static_delegate) });
            }

            if (efl_ui_calendar_date_set_static_delegate == null)
            {
                efl_ui_calendar_date_set_static_delegate = new efl_ui_calendar_date_set_delegate(date_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_date_set_static_delegate) });
            }

            if (efl_ui_format_func_get_static_delegate == null)
            {
                efl_ui_format_func_get_static_delegate = new efl_ui_format_func_get_delegate(format_func_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_get_static_delegate) });
            }

            if (efl_ui_format_func_set_static_delegate == null)
            {
                efl_ui_format_func_set_static_delegate = new efl_ui_format_func_set_delegate(format_func_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_set_static_delegate) });
            }

            if (efl_ui_format_values_get_static_delegate == null)
            {
                efl_ui_format_values_get_static_delegate = new efl_ui_format_values_get_delegate(format_values_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_get_static_delegate) });
            }

            if (efl_ui_format_values_set_static_delegate == null)
            {
                efl_ui_format_values_set_static_delegate = new efl_ui_format_values_set_delegate(format_values_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_set_static_delegate) });
            }

            if (efl_ui_format_string_get_static_delegate == null)
            {
                efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate) });
            }

            if (efl_ui_format_string_set_static_delegate == null)
            {
                efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate) });
            }

            if (efl_ui_format_formatted_value_get_static_delegate == null)
            {
                efl_ui_format_formatted_value_get_static_delegate = new efl_ui_format_formatted_value_get_delegate(formatted_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_formatted_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_formatted_value_get_static_delegate) });
            }

            if (efl_ui_format_decimal_places_get_static_delegate == null)
            {
                efl_ui_format_decimal_places_get_static_delegate = new efl_ui_format_decimal_places_get_delegate(decimal_places_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDecimalPlaces") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_decimal_places_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_decimal_places_get_static_delegate) });
            }

            if (efl_ui_format_apply_formatted_value_static_delegate == null)
            {
                efl_ui_format_apply_formatted_value_static_delegate = new efl_ui_format_apply_formatted_value_delegate(apply_formatted_value);
            }

            if (methods.FirstOrDefault(m => m.Name == "ApplyFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_apply_formatted_value"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_apply_formatted_value_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_get_static_delegate == null)
            {
                efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_set_static_delegate == null)
            {
                efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_get_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_set_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate) });
            }

            if (efl_ui_focus_composition_dirty_static_delegate == null)
            {
                efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "Dirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate) });
            }

            if (efl_ui_focus_composition_prepare_static_delegate == null)
            {
                efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "Prepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Calendar.efl_ui_calendar_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.CalendarWeekday efl_ui_calendar_first_day_of_week_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_get_api_delegate> efl_ui_calendar_first_day_of_week_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_get_api_delegate>(Module, "efl_ui_calendar_first_day_of_week_get");

        private static Efl.Ui.CalendarWeekday first_day_of_week_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.CalendarWeekday _ret_var = default(Efl.Ui.CalendarWeekday);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetFirstDayOfWeek();
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
                return efl_ui_calendar_first_day_of_week_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_calendar_first_day_of_week_get_delegate efl_ui_calendar_first_day_of_week_get_static_delegate;

        
        private delegate void efl_ui_calendar_first_day_of_week_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.CalendarWeekday day);

        
        public delegate void efl_ui_calendar_first_day_of_week_set_api_delegate(System.IntPtr obj,  Efl.Ui.CalendarWeekday day);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_set_api_delegate> efl_ui_calendar_first_day_of_week_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_first_day_of_week_set_api_delegate>(Module, "efl_ui_calendar_first_day_of_week_set");

        private static void first_day_of_week_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.CalendarWeekday day)
        {
            Eina.Log.Debug("function efl_ui_calendar_first_day_of_week_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Calendar)ws.Target).SetFirstDayOfWeek(day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_calendar_first_day_of_week_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), day);
            }
        }

        private static efl_ui_calendar_first_day_of_week_set_delegate efl_ui_calendar_first_day_of_week_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_calendar_date_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_calendar_date_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_get_api_delegate> efl_ui_calendar_date_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_get_api_delegate>(Module, "efl_ui_calendar_date_min_get");

        private static Efl.Time.NativeStruct date_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetDateMin();
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
                return efl_ui_calendar_date_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_calendar_date_min_get_delegate efl_ui_calendar_date_min_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_calendar_date_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct min);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_calendar_date_min_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct min);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_set_api_delegate> efl_ui_calendar_date_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_min_set_api_delegate>(Module, "efl_ui_calendar_date_min_set");

        private static bool date_min_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct min)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_min = min;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Calendar)ws.Target).SetDateMin(_in_min);
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
                return efl_ui_calendar_date_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min);
            }
        }

        private static efl_ui_calendar_date_min_set_delegate efl_ui_calendar_date_min_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_calendar_date_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_calendar_date_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_get_api_delegate> efl_ui_calendar_date_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_get_api_delegate>(Module, "efl_ui_calendar_date_max_get");

        private static Efl.Time.NativeStruct date_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetDateMax();
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
                return efl_ui_calendar_date_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_calendar_date_max_get_delegate efl_ui_calendar_date_max_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_calendar_date_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct max);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_calendar_date_max_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct max);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_set_api_delegate> efl_ui_calendar_date_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_max_set_api_delegate>(Module, "efl_ui_calendar_date_max_set");

        private static bool date_max_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct max)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_max = max;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Calendar)ws.Target).SetDateMax(_in_max);
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
                return efl_ui_calendar_date_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), max);
            }
        }

        private static efl_ui_calendar_date_max_set_delegate efl_ui_calendar_date_max_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_calendar_date_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_calendar_date_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_get_api_delegate> efl_ui_calendar_date_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_get_api_delegate>(Module, "efl_ui_calendar_date_get");

        private static Efl.Time.NativeStruct date_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetDate();
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
                return efl_ui_calendar_date_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_calendar_date_get_delegate efl_ui_calendar_date_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_calendar_date_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct date);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_calendar_date_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct date);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_date_set_api_delegate> efl_ui_calendar_date_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_date_set_api_delegate>(Module, "efl_ui_calendar_date_set");

        private static bool date_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct date)
        {
            Eina.Log.Debug("function efl_ui_calendar_date_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_date = date;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Calendar)ws.Target).SetDate(_in_date);
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
                return efl_ui_calendar_date_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), date);
            }
        }

        private static efl_ui_calendar_date_set_delegate efl_ui_calendar_date_set_static_delegate;

        
        private delegate Efl.Ui.FormatFunc efl_ui_format_func_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.FormatFunc efl_ui_format_func_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate> efl_ui_format_func_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate>(Module, "efl_ui_format_func_get");

        private static Efl.Ui.FormatFunc format_func_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_func_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.FormatFunc _ret_var = default(Efl.Ui.FormatFunc);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetFormatFunc();
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
                return efl_ui_format_func_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_func_get_delegate efl_ui_format_func_get_static_delegate;

        
        private delegate void efl_ui_format_func_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_ui_format_func_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate> efl_ui_format_func_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate>(Module, "efl_ui_format_func_set");

        private static void format_func_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_ui_format_func_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            Efl.Ui.FormatFuncWrapper func_wrapper = new Efl.Ui.FormatFuncWrapper(func, func_data, func_free_cb);
            
                try
                {
                    ((Calendar)ws.Target).SetFormatFunc(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_func_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_ui_format_func_set_delegate efl_ui_format_func_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_format_values_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_format_values_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate> efl_ui_format_values_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate>(Module, "efl_ui_format_values_get");

        private static System.IntPtr format_values_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_values_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Accessor<Efl.Ui.FormatValue> _ret_var = default(Eina.Accessor<Efl.Ui.FormatValue>);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetFormatValues();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_ui_format_values_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_values_get_delegate efl_ui_format_values_get_static_delegate;

        
        private delegate void efl_ui_format_values_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr values);

        
        public delegate void efl_ui_format_values_set_api_delegate(System.IntPtr obj,  System.IntPtr values);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate> efl_ui_format_values_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate>(Module, "efl_ui_format_values_set");

        private static void format_values_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr values)
        {
            Eina.Log.Debug("function efl_ui_format_values_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_values = new Eina.Accessor<Efl.Ui.FormatValue>(values, false);
                            
                try
                {
                    ((Calendar)ws.Target).SetFormatValues(_in_values);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_values_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), values);
            }
        }

        private static efl_ui_format_values_set_delegate efl_ui_format_values_set_static_delegate;

        
        private delegate void efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(Module, "efl_ui_format_string_get");

        private static void format_string_get(System.IntPtr obj, System.IntPtr pd, out System.String kw_string, out Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_kw_string = default(System.String);
        type = default(Efl.Ui.FormatStringType);                            
                try
                {
                    ((Calendar)ws.Target).GetFormatString(out _out_kw_string, out type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        kw_string = _out_kw_string;
                                
            }
            else
            {
                efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out kw_string, out type);
            }
        }

        private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;

        
        private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(Module, "efl_ui_format_string_set");

        private static void format_string_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string, Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Calendar)ws.Target).SetFormatString(kw_string, type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string, type);
            }
        }

        private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;

        
        private delegate void efl_ui_format_formatted_value_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        
        public delegate void efl_ui_format_formatted_value_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate> efl_ui_format_formatted_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate>(Module, "efl_ui_format_formatted_value_get");

        private static void formatted_value_get(System.IntPtr obj, System.IntPtr pd, Eina.Strbuf str, Eina.ValueNative value)
        {
            Eina.Log.Debug("function efl_ui_format_formatted_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Calendar)ws.Target).GetFormattedValue(str, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_formatted_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), str, value);
            }
        }

        private static efl_ui_format_formatted_value_get_delegate efl_ui_format_formatted_value_get_static_delegate;

        
        private delegate int efl_ui_format_decimal_places_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_format_decimal_places_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate> efl_ui_format_decimal_places_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate>(Module, "efl_ui_format_decimal_places_get");

        private static int decimal_places_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_decimal_places_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetDecimalPlaces();
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
                return efl_ui_format_decimal_places_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_decimal_places_get_delegate efl_ui_format_decimal_places_get_static_delegate;

        
        private delegate void efl_ui_format_apply_formatted_value_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_format_apply_formatted_value_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate> efl_ui_format_apply_formatted_value_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate>(Module, "efl_ui_format_apply_formatted_value");

        private static void apply_formatted_value(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_apply_formatted_value was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Calendar)ws.Target).ApplyFormattedValue();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_format_apply_formatted_value_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_apply_formatted_value_delegate efl_ui_format_apply_formatted_value_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(Module, "efl_ui_focus_composition_elements_get");

        private static System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Gfx.IEntity> _ret_var = default(Eina.List<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetCompositionElements();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_ui_focus_composition_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr logical_order);

        
        public delegate void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,  System.IntPtr logical_order);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(Module, "efl_ui_focus_composition_elements_set");

        private static void composition_elements_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr logical_order)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_logical_order = new Eina.List<Efl.Gfx.IEntity>(logical_order, true, false);
                            
                try
                {
                    ((Calendar)ws.Target).SetCompositionElements(_in_logical_order);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_elements_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_order);
            }
        }

        private static efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_get");

        private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Calendar)ws.Target).GetLogicalMode();
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
                return efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        
        public delegate void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_set");

        private static void logical_mode_set(System.IntPtr obj, System.IntPtr pd, bool logical_mode)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Calendar)ws.Target).SetLogicalMode(logical_mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_mode);
            }
        }

        private static efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;

        
        private delegate void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(Module, "efl_ui_focus_composition_dirty");

        private static void dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Calendar)ws.Target).Dirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;

        
        private delegate void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(Module, "efl_ui_focus_composition_prepare");

        private static void prepare(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Calendar)ws.Target).Prepare();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>A weekday
/// See also <see cref="Efl.Ui.Calendar.SetFirstDayOfWeek"/>.</summary>
[Efl.Eo.BindingEntity]
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

}

}

