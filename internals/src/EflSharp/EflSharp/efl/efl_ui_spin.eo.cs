#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>A Spin.
/// This is a widget which allows the user to increase or decrease a numeric value using arrow buttons. It&apos;s a basic type of widget for choosing and displaying values.</summary>
[Efl.Ui.Spin.NativeMethods]
[Efl.Eo.BindingEntity]
public class Spin : Efl.Ui.LayoutBase, Efl.Access.IValue, Efl.Ui.IFormat, Efl.Ui.IRangeDisplay, Efl.Ui.IRangeInteractive
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Spin))
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
        efl_ui_spin_class_get();
    /// <summary>Initializes a new instance of the <see cref="Spin"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Spin(Efl.Object parent
            , System.String style = null) : base(efl_ui_spin_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Spin(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Spin"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Spin(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Spin"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Spin(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when spin changed</summary>
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

                string key = "_EFL_UI_SPIN_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPIN_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SPIN_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when spin value reached min</summary>
    public event EventHandler MinReachedEvt
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

                string key = "_EFL_UI_SPIN_EVENT_MIN_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPIN_EVENT_MIN_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event MinReachedEvt.</summary>
    public void OnMinReachedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SPIN_EVENT_MIN_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when spin value reached max</summary>
    public event EventHandler MaxReachedEvt
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

                string key = "_EFL_UI_SPIN_EVENT_MAX_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPIN_EVENT_MAX_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event MaxReachedEvt.</summary>
    public void OnMaxReachedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SPIN_EVENT_MAX_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Gets value displayed by a accessible widget.</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    virtual public void GetValueAndText(out double value, out System.String text) {
                                                         Efl.Access.IValueConcrete.NativeMethods.efl_access_value_and_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out value, out text);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Value and text property</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    /// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
    virtual public bool SetValueAndText(double value, System.String text) {
                                                         var _ret_var = Efl.Access.IValueConcrete.NativeMethods.efl_access_value_and_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value, text);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets a range of all possible values and its description</summary>
    /// <param name="lower_limit">Lower limit of the range</param>
    /// <param name="upper_limit">Upper limit of the range</param>
    /// <param name="description">Description of the range</param>
    virtual public void GetRange(out double lower_limit, out double upper_limit, out System.String description) {
                                                                                 Efl.Access.IValueConcrete.NativeMethods.efl_access_value_range_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out lower_limit, out upper_limit, out description);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Gets an minimal incrementation value</summary>
    /// <returns>Minimal incrementation value</returns>
    virtual public double GetIncrement() {
         var _ret_var = Efl.Access.IValueConcrete.NativeMethods.efl_access_value_increment_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <returns>The range value (must be between $0.0 and 1.0)</returns>
    virtual public double GetRangeValue() {
         var _ret_var = Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <param name="val">The range value (must be between $0.0 and 1.0)</param>
    virtual public void SetRangeValue(double val) {
                                 Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the minimum and maximum values of the given range widget.
    /// Note: If only one value is needed, the other pointer can be passed as <c>null</c>.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    virtual public void GetRangeLimits(out double min, out double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_limits_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out min, out max);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the minimum and maximum values for given range widget.
    /// Define the allowed range of values to be selected by the user.
    /// 
    /// If actual value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The actual value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>
    /// 
    /// The minimum and maximum values may be different for each class.
    /// 
    /// Warning: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    virtual public void SetRangeLimits(double min, double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_limits_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),min, max);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <returns>The step value.</returns>
    virtual public double GetRangeStep() {
         var _ret_var = Efl.Ui.IRangeInteractiveConcrete.NativeMethods.efl_ui_range_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <param name="step">The step value.</param>
    virtual public void SetRangeStep(double step) {
                                 Efl.Ui.IRangeInteractiveConcrete.NativeMethods.efl_ui_range_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an minimal incrementation value</summary>
    /// <value>Minimal incrementation value</value>
    public double Increment {
        get { return GetIncrement(); }
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
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <value>The range value (must be between $0.0 and 1.0)</value>
    public double RangeValue {
        get { return GetRangeValue(); }
        set { SetRangeValue(value); }
    }
    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <value>The step value.</value>
    public double RangeStep {
        get { return GetRangeStep(); }
        set { SetRangeStep(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Spin.efl_ui_spin_class_get();
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

            if (efl_access_value_and_text_get_static_delegate == null)
            {
                efl_access_value_and_text_get_static_delegate = new efl_access_value_and_text_get_delegate(value_and_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValueAndText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_value_and_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_get_static_delegate) });
            }

            if (efl_access_value_and_text_set_static_delegate == null)
            {
                efl_access_value_and_text_set_static_delegate = new efl_access_value_and_text_set_delegate(value_and_text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValueAndText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_value_and_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_and_text_set_static_delegate) });
            }

            if (efl_access_value_range_get_static_delegate == null)
            {
                efl_access_value_range_get_static_delegate = new efl_access_value_range_get_delegate(range_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_value_range_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_range_get_static_delegate) });
            }

            if (efl_access_value_increment_get_static_delegate == null)
            {
                efl_access_value_increment_get_static_delegate = new efl_access_value_increment_get_delegate(increment_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIncrement") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_value_increment_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_value_increment_get_static_delegate) });
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

            if (efl_ui_range_value_get_static_delegate == null)
            {
                efl_ui_range_value_get_static_delegate = new efl_ui_range_value_get_delegate(range_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_get_static_delegate) });
            }

            if (efl_ui_range_value_set_static_delegate == null)
            {
                efl_ui_range_value_set_static_delegate = new efl_ui_range_value_set_delegate(range_value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_set_static_delegate) });
            }

            if (efl_ui_range_limits_get_static_delegate == null)
            {
                efl_ui_range_limits_get_static_delegate = new efl_ui_range_limits_get_delegate(range_limits_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeLimits") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_limits_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_limits_get_static_delegate) });
            }

            if (efl_ui_range_limits_set_static_delegate == null)
            {
                efl_ui_range_limits_set_static_delegate = new efl_ui_range_limits_set_delegate(range_limits_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeLimits") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_limits_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_limits_set_static_delegate) });
            }

            if (efl_ui_range_step_get_static_delegate == null)
            {
                efl_ui_range_step_get_static_delegate = new efl_ui_range_step_get_delegate(range_step_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_get_static_delegate) });
            }

            if (efl_ui_range_step_set_static_delegate == null)
            {
                efl_ui_range_step_set_static_delegate = new efl_ui_range_step_set_delegate(range_step_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Spin.efl_ui_spin_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_access_value_and_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String text);

        
        public delegate void efl_access_value_and_text_get_api_delegate(System.IntPtr obj,  out double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String text);

        public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate> efl_access_value_and_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate>(Module, "efl_access_value_and_text_get");

        private static void value_and_text_get(System.IntPtr obj, System.IntPtr pd, out double value, out System.String text)
        {
            Eina.Log.Debug("function efl_access_value_and_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        value = default(double);        System.String _out_text = default(System.String);
                            
                try
                {
                    ((Spin)ws.Target).GetValueAndText(out value, out _out_text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                text = _out_text;
                        
            }
            else
            {
                efl_access_value_and_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out value, out text);
            }
        }

        private static efl_access_value_and_text_get_delegate efl_access_value_and_text_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_value_and_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_value_and_text_set_api_delegate(System.IntPtr obj,  double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate> efl_access_value_and_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_set_api_delegate>(Module, "efl_access_value_and_text_set");

        private static bool value_and_text_set(System.IntPtr obj, System.IntPtr pd, double value, System.String text)
        {
            Eina.Log.Debug("function efl_access_value_and_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Spin)ws.Target).SetValueAndText(value, text);
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
                return efl_access_value_and_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value, text);
            }
        }

        private static efl_access_value_and_text_set_delegate efl_access_value_and_text_set_static_delegate;

        
        private delegate void efl_access_value_range_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double lower_limit,  out double upper_limit, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String description);

        
        public delegate void efl_access_value_range_get_api_delegate(System.IntPtr obj,  out double lower_limit,  out double upper_limit, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String description);

        public static Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate> efl_access_value_range_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_range_get_api_delegate>(Module, "efl_access_value_range_get");

        private static void range_get(System.IntPtr obj, System.IntPtr pd, out double lower_limit, out double upper_limit, out System.String description)
        {
            Eina.Log.Debug("function efl_access_value_range_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                lower_limit = default(double);        upper_limit = default(double);        System.String _out_description = default(System.String);
                                    
                try
                {
                    ((Spin)ws.Target).GetRange(out lower_limit, out upper_limit, out _out_description);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        description = _out_description;
                                
            }
            else
            {
                efl_access_value_range_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out lower_limit, out upper_limit, out description);
            }
        }

        private static efl_access_value_range_get_delegate efl_access_value_range_get_static_delegate;

        
        private delegate double efl_access_value_increment_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_access_value_increment_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate> efl_access_value_increment_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_increment_get_api_delegate>(Module, "efl_access_value_increment_get");

        private static double increment_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_value_increment_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Spin)ws.Target).GetIncrement();
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
                return efl_access_value_increment_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_value_increment_get_delegate efl_access_value_increment_get_static_delegate;

        
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
                    _ret_var = ((Spin)ws.Target).GetFormatFunc();
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
                    ((Spin)ws.Target).SetFormatFunc(func_wrapper.ManagedCb);
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
                    _ret_var = ((Spin)ws.Target).GetFormatValues();
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
                    ((Spin)ws.Target).SetFormatValues(_in_values);
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
                    ((Spin)ws.Target).GetFormatString(out _out_kw_string, out type);
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
                    ((Spin)ws.Target).SetFormatString(kw_string, type);
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
                    ((Spin)ws.Target).GetFormattedValue(str, value);
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
                    _ret_var = ((Spin)ws.Target).GetDecimalPlaces();
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
                    ((Spin)ws.Target).ApplyFormattedValue();
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

        
        private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_range_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate> efl_ui_range_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate>(Module, "efl_ui_range_value_get");

        private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_range_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Spin)ws.Target).GetRangeValue();
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
                return efl_ui_range_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_range_value_get_delegate efl_ui_range_value_get_static_delegate;

        
        private delegate void efl_ui_range_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  double val);

        
        public delegate void efl_ui_range_value_set_api_delegate(System.IntPtr obj,  double val);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate> efl_ui_range_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate>(Module, "efl_ui_range_value_set");

        private static void range_value_set(System.IntPtr obj, System.IntPtr pd, double val)
        {
            Eina.Log.Debug("function efl_ui_range_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Spin)ws.Target).SetRangeValue(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_range_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_ui_range_value_set_delegate efl_ui_range_value_set_static_delegate;

        
        private delegate void efl_ui_range_limits_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double min,  out double max);

        
        public delegate void efl_ui_range_limits_get_api_delegate(System.IntPtr obj,  out double min,  out double max);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_limits_get_api_delegate> efl_ui_range_limits_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_limits_get_api_delegate>(Module, "efl_ui_range_limits_get");

        private static void range_limits_get(System.IntPtr obj, System.IntPtr pd, out double min, out double max)
        {
            Eina.Log.Debug("function efl_ui_range_limits_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        min = default(double);        max = default(double);                            
                try
                {
                    ((Spin)ws.Target).GetRangeLimits(out min, out max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_range_limits_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out min, out max);
            }
        }

        private static efl_ui_range_limits_get_delegate efl_ui_range_limits_get_static_delegate;

        
        private delegate void efl_ui_range_limits_set_delegate(System.IntPtr obj, System.IntPtr pd,  double min,  double max);

        
        public delegate void efl_ui_range_limits_set_api_delegate(System.IntPtr obj,  double min,  double max);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_limits_set_api_delegate> efl_ui_range_limits_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_limits_set_api_delegate>(Module, "efl_ui_range_limits_set");

        private static void range_limits_set(System.IntPtr obj, System.IntPtr pd, double min, double max)
        {
            Eina.Log.Debug("function efl_ui_range_limits_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Spin)ws.Target).SetRangeLimits(min, max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_range_limits_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min, max);
            }
        }

        private static efl_ui_range_limits_set_delegate efl_ui_range_limits_set_static_delegate;

        
        private delegate double efl_ui_range_step_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_range_step_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate> efl_ui_range_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate>(Module, "efl_ui_range_step_get");

        private static double range_step_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_range_step_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Spin)ws.Target).GetRangeStep();
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
                return efl_ui_range_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_range_step_get_delegate efl_ui_range_step_get_static_delegate;

        
        private delegate void efl_ui_range_step_set_delegate(System.IntPtr obj, System.IntPtr pd,  double step);

        
        public delegate void efl_ui_range_step_set_api_delegate(System.IntPtr obj,  double step);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate> efl_ui_range_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate>(Module, "efl_ui_range_step_set");

        private static void range_step_set(System.IntPtr obj, System.IntPtr pd, double step)
        {
            Eina.Log.Debug("function efl_ui_range_step_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Spin)ws.Target).SetRangeStep(step);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_range_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), step);
            }
        }

        private static efl_ui_range_step_set_delegate efl_ui_range_step_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

