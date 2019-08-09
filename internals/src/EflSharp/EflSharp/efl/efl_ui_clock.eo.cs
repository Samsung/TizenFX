#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI clock class</summary>
[Efl.Ui.Clock.NativeMethods]
[Efl.Eo.BindingEntity]
public class Clock : Efl.Ui.LayoutBase
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Clock))
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
        efl_ui_clock_class_get();
    /// <summary>Initializes a new instance of the <see cref="Clock"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Clock(Efl.Object parent
            , System.String style = null) : base(efl_ui_clock_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Clock(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Clock"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Clock(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Clock"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Clock(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when clock changed</summary>
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

                string key = "_EFL_UI_CLOCK_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_CLOCK_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_CLOCK_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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
    /// <returns>The clock format.</returns>
    virtual public System.String GetFormat() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_format_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
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
    /// <param name="fmt">The clock format.</param>
    virtual public void SetFormat(System.String fmt) {
                                 Efl.Ui.Clock.NativeMethods.efl_ui_clock_format_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fmt);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the given clock widget should be paused or not.
    /// This function pauses or starts the clock widget.</summary>
    /// <returns><c>true</c> to pause clock, <c>false</c> otherwise</returns>
    virtual public bool GetPause() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_pause_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the given clock widget should be paused or not.
    /// This function pauses or starts the clock widget.</summary>
    /// <param name="paused"><c>true</c> to pause clock, <c>false</c> otherwise</param>
    virtual public void SetPause(bool paused) {
                                 Efl.Ui.Clock.NativeMethods.efl_ui_clock_pause_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),paused);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
    /// <returns><c>true</c> to set edit mode, <c>false</c> otherwise</returns>
    virtual public bool GetEditMode() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_edit_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
    /// <param name="value"><c>true</c> to set edit mode, <c>false</c> otherwise</param>
    virtual public void SetEditMode(bool value) {
                                 Efl.Ui.Clock.NativeMethods.efl_ui_clock_edit_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
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
    /// <returns>Time structure containing the minimum time value.</returns>
    virtual public Efl.Time GetTimeMin() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
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
    /// <param name="mintime">Time structure containing the minimum time value.</param>
    virtual public void SetTimeMin(Efl.Time mintime) {
         Efl.Time.NativeStruct _in_mintime = mintime;
                        Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_mintime);
        Eina.Error.RaiseIfUnhandledException();
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
    /// <returns>Time structure containing the maximum time value.</returns>
    virtual public Efl.Time GetTimeMax() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
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
    /// <param name="maxtime">Time structure containing the maximum time value.</param>
    virtual public void SetTimeMax(Efl.Time maxtime) {
         Efl.Time.NativeStruct _in_maxtime = maxtime;
                        Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_maxtime);
        Eina.Error.RaiseIfUnhandledException();
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
    /// <returns>Time structure containing the time value.</returns>
    virtual public Efl.Time GetTime() {
         var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
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
    /// <param name="curtime">Time structure containing the time value.</param>
    virtual public void SetTime(Efl.Time curtime) {
         Efl.Time.NativeStruct _in_curtime = curtime;
                        Efl.Ui.Clock.NativeMethods.efl_ui_clock_time_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_curtime);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The field to be visible/not.</summary>
    /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
    /// <returns><c>true</c> field can be visible, <c>false</c> otherwise.</returns>
    virtual public bool GetFieldVisible(Efl.Ui.ClockType fieldtype) {
                                 var _ret_var = Efl.Ui.Clock.NativeMethods.efl_ui_clock_field_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fieldtype);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The field to be visible/not.</summary>
    /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
    /// <param name="visible"><c>true</c> field can be visible, <c>false</c> otherwise.</param>
    virtual public void SetFieldVisible(Efl.Ui.ClockType fieldtype, bool visible) {
                                                         Efl.Ui.Clock.NativeMethods.efl_ui_clock_field_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fieldtype, visible);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the field limits of a field.
    /// Limits can be set to individual fields, independently, except for the AM/PM field. Any field can display the values only in between these minimum and maximum limits unless the corresponding time value is restricted from MinTime to MaxTime. That is, min/max field limits always work under the limitations of mintime/maxtime.
    /// 
    /// There is no provision to set the limits of AM/PM field.</summary>
    /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
    /// <param name="min">Reference to field&apos;s minimum value.</param>
    /// <param name="max">Reference to field&apos;s maximum value.</param>
    virtual public void GetFieldLimit(Efl.Ui.ClockType fieldtype, out int min, out int max) {
                                                                                 Efl.Ui.Clock.NativeMethods.efl_ui_clock_field_limit_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fieldtype, out min, out max);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Set a field to be visible or not.
    /// Setting this API to <c>true</c> in itself doen&apos;t ensure that the field is visible. The field&apos;s format also must be present in the overall clock format.  If a field&apos;s visibility is set to <c>false</c> then it won&apos;t appear even though its format is present. In summary, if this API is set to true and the corresponding field&apos;s format is present in clock format, the field is visible.
    /// 
    /// By default the field visibility is set to <c>true</c>.</summary>
    /// <param name="fieldtype">Type of the field. #EFL_UI_CLOCK_TYPE_YEAR etc.</param>
    /// <param name="min">Reference to field&apos;s minimum value.</param>
    /// <param name="max">Reference to field&apos;s maximum value.</param>
    virtual public void SetFieldLimit(Efl.Ui.ClockType fieldtype, int min, int max) {
                                                                                 Efl.Ui.Clock.NativeMethods.efl_ui_clock_field_limit_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fieldtype, min, max);
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
    /// <value>The clock format.</value>
    public System.String Format {
        get { return GetFormat(); }
        set { SetFormat(value); }
    }
    /// <summary>Whether the given clock widget should be paused or not.
    /// This function pauses or starts the clock widget.</summary>
    /// <value><c>true</c> to pause clock, <c>false</c> otherwise</value>
    public bool Pause {
        get { return GetPause(); }
        set { SetPause(value); }
    }
    /// <summary>Digits of the given clock widget should be editable when in editing mode.</summary>
    /// <value><c>true</c> to set edit mode, <c>false</c> otherwise</value>
    public bool EditMode {
        get { return GetEditMode(); }
        set { SetEditMode(value); }
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
    /// <value>Time structure containing the minimum time value.</value>
    public Efl.Time TimeMin {
        get { return GetTimeMin(); }
        set { SetTimeMin(value); }
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
    /// <value>Time structure containing the maximum time value.</value>
    public Efl.Time TimeMax {
        get { return GetTimeMax(); }
        set { SetTimeMax(value); }
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
    /// <value>Time structure containing the time value.</value>
    public Efl.Time Time {
        get { return GetTime(); }
        set { SetTime(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Clock.efl_ui_clock_class_get();
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

            if (efl_ui_clock_format_get_static_delegate == null)
            {
                efl_ui_clock_format_get_static_delegate = new efl_ui_clock_format_get_delegate(format_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_format_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_format_get_static_delegate) });
            }

            if (efl_ui_clock_format_set_static_delegate == null)
            {
                efl_ui_clock_format_set_static_delegate = new efl_ui_clock_format_set_delegate(format_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_format_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_format_set_static_delegate) });
            }

            if (efl_ui_clock_pause_get_static_delegate == null)
            {
                efl_ui_clock_pause_get_static_delegate = new efl_ui_clock_pause_get_delegate(pause_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPause") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_pause_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_pause_get_static_delegate) });
            }

            if (efl_ui_clock_pause_set_static_delegate == null)
            {
                efl_ui_clock_pause_set_static_delegate = new efl_ui_clock_pause_set_delegate(pause_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPause") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_pause_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_pause_set_static_delegate) });
            }

            if (efl_ui_clock_edit_mode_get_static_delegate == null)
            {
                efl_ui_clock_edit_mode_get_static_delegate = new efl_ui_clock_edit_mode_get_delegate(edit_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEditMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_edit_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_edit_mode_get_static_delegate) });
            }

            if (efl_ui_clock_edit_mode_set_static_delegate == null)
            {
                efl_ui_clock_edit_mode_set_static_delegate = new efl_ui_clock_edit_mode_set_delegate(edit_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEditMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_edit_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_edit_mode_set_static_delegate) });
            }

            if (efl_ui_clock_time_min_get_static_delegate == null)
            {
                efl_ui_clock_time_min_get_static_delegate = new efl_ui_clock_time_min_get_delegate(time_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_min_get_static_delegate) });
            }

            if (efl_ui_clock_time_min_set_static_delegate == null)
            {
                efl_ui_clock_time_min_set_static_delegate = new efl_ui_clock_time_min_set_delegate(time_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_min_set_static_delegate) });
            }

            if (efl_ui_clock_time_max_get_static_delegate == null)
            {
                efl_ui_clock_time_max_get_static_delegate = new efl_ui_clock_time_max_get_delegate(time_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_max_get_static_delegate) });
            }

            if (efl_ui_clock_time_max_set_static_delegate == null)
            {
                efl_ui_clock_time_max_set_static_delegate = new efl_ui_clock_time_max_set_delegate(time_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_max_set_static_delegate) });
            }

            if (efl_ui_clock_time_get_static_delegate == null)
            {
                efl_ui_clock_time_get_static_delegate = new efl_ui_clock_time_get_delegate(time_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_get_static_delegate) });
            }

            if (efl_ui_clock_time_set_static_delegate == null)
            {
                efl_ui_clock_time_set_static_delegate = new efl_ui_clock_time_set_delegate(time_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_time_set_static_delegate) });
            }

            if (efl_ui_clock_field_visible_get_static_delegate == null)
            {
                efl_ui_clock_field_visible_get_static_delegate = new efl_ui_clock_field_visible_get_delegate(field_visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFieldVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_field_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_visible_get_static_delegate) });
            }

            if (efl_ui_clock_field_visible_set_static_delegate == null)
            {
                efl_ui_clock_field_visible_set_static_delegate = new efl_ui_clock_field_visible_set_delegate(field_visible_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFieldVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_field_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_visible_set_static_delegate) });
            }

            if (efl_ui_clock_field_limit_get_static_delegate == null)
            {
                efl_ui_clock_field_limit_get_static_delegate = new efl_ui_clock_field_limit_get_delegate(field_limit_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFieldLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_field_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_limit_get_static_delegate) });
            }

            if (efl_ui_clock_field_limit_set_static_delegate == null)
            {
                efl_ui_clock_field_limit_set_static_delegate = new efl_ui_clock_field_limit_set_delegate(field_limit_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFieldLimit") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clock_field_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clock_field_limit_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Clock.efl_ui_clock_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_clock_format_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_clock_format_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_format_get_api_delegate> efl_ui_clock_format_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_format_get_api_delegate>(Module, "efl_ui_clock_format_get");

        private static System.String format_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_format_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetFormat();
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
                return efl_ui_clock_format_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_format_get_delegate efl_ui_clock_format_get_static_delegate;

        
        private delegate void efl_ui_clock_format_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String fmt);

        
        public delegate void efl_ui_clock_format_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String fmt);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_format_set_api_delegate> efl_ui_clock_format_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_format_set_api_delegate>(Module, "efl_ui_clock_format_set");

        private static void format_set(System.IntPtr obj, System.IntPtr pd, System.String fmt)
        {
            Eina.Log.Debug("function efl_ui_clock_format_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Clock)ws.Target).SetFormat(fmt);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_format_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fmt);
            }
        }

        private static efl_ui_clock_format_set_delegate efl_ui_clock_format_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_clock_pause_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_clock_pause_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_pause_get_api_delegate> efl_ui_clock_pause_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_pause_get_api_delegate>(Module, "efl_ui_clock_pause_get");

        private static bool pause_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_pause_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetPause();
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
                return efl_ui_clock_pause_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_pause_get_delegate efl_ui_clock_pause_get_static_delegate;

        
        private delegate void efl_ui_clock_pause_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool paused);

        
        public delegate void efl_ui_clock_pause_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool paused);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_pause_set_api_delegate> efl_ui_clock_pause_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_pause_set_api_delegate>(Module, "efl_ui_clock_pause_set");

        private static void pause_set(System.IntPtr obj, System.IntPtr pd, bool paused)
        {
            Eina.Log.Debug("function efl_ui_clock_pause_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Clock)ws.Target).SetPause(paused);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_pause_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), paused);
            }
        }

        private static efl_ui_clock_pause_set_delegate efl_ui_clock_pause_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_clock_edit_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_clock_edit_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_edit_mode_get_api_delegate> efl_ui_clock_edit_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_edit_mode_get_api_delegate>(Module, "efl_ui_clock_edit_mode_get");

        private static bool edit_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_edit_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetEditMode();
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
                return efl_ui_clock_edit_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_edit_mode_get_delegate efl_ui_clock_edit_mode_get_static_delegate;

        
        private delegate void efl_ui_clock_edit_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool value);

        
        public delegate void efl_ui_clock_edit_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool value);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_edit_mode_set_api_delegate> efl_ui_clock_edit_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_edit_mode_set_api_delegate>(Module, "efl_ui_clock_edit_mode_set");

        private static void edit_mode_set(System.IntPtr obj, System.IntPtr pd, bool value)
        {
            Eina.Log.Debug("function efl_ui_clock_edit_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Clock)ws.Target).SetEditMode(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_edit_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_ui_clock_edit_mode_set_delegate efl_ui_clock_edit_mode_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_clock_time_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_clock_time_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_min_get_api_delegate> efl_ui_clock_time_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_min_get_api_delegate>(Module, "efl_ui_clock_time_min_get");

        private static Efl.Time.NativeStruct time_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_time_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetTimeMin();
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
                return efl_ui_clock_time_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_time_min_get_delegate efl_ui_clock_time_min_get_static_delegate;

        
        private delegate void efl_ui_clock_time_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct mintime);

        
        public delegate void efl_ui_clock_time_min_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct mintime);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_min_set_api_delegate> efl_ui_clock_time_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_min_set_api_delegate>(Module, "efl_ui_clock_time_min_set");

        private static void time_min_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct mintime)
        {
            Eina.Log.Debug("function efl_ui_clock_time_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_mintime = mintime;
                            
                try
                {
                    ((Clock)ws.Target).SetTimeMin(_in_mintime);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_time_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mintime);
            }
        }

        private static efl_ui_clock_time_min_set_delegate efl_ui_clock_time_min_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_clock_time_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_clock_time_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_max_get_api_delegate> efl_ui_clock_time_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_max_get_api_delegate>(Module, "efl_ui_clock_time_max_get");

        private static Efl.Time.NativeStruct time_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_time_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetTimeMax();
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
                return efl_ui_clock_time_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_time_max_get_delegate efl_ui_clock_time_max_get_static_delegate;

        
        private delegate void efl_ui_clock_time_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct maxtime);

        
        public delegate void efl_ui_clock_time_max_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct maxtime);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_max_set_api_delegate> efl_ui_clock_time_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_max_set_api_delegate>(Module, "efl_ui_clock_time_max_set");

        private static void time_max_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct maxtime)
        {
            Eina.Log.Debug("function efl_ui_clock_time_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_maxtime = maxtime;
                            
                try
                {
                    ((Clock)ws.Target).SetTimeMax(_in_maxtime);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_time_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), maxtime);
            }
        }

        private static efl_ui_clock_time_max_set_delegate efl_ui_clock_time_max_set_static_delegate;

        
        private delegate Efl.Time.NativeStruct efl_ui_clock_time_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Time.NativeStruct efl_ui_clock_time_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_get_api_delegate> efl_ui_clock_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_get_api_delegate>(Module, "efl_ui_clock_time_get");

        private static Efl.Time.NativeStruct time_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_clock_time_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Time _ret_var = default(Efl.Time);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetTime();
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
                return efl_ui_clock_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_clock_time_get_delegate efl_ui_clock_time_get_static_delegate;

        
        private delegate void efl_ui_clock_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Time.NativeStruct curtime);

        
        public delegate void efl_ui_clock_time_set_api_delegate(System.IntPtr obj,  Efl.Time.NativeStruct curtime);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_time_set_api_delegate> efl_ui_clock_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_time_set_api_delegate>(Module, "efl_ui_clock_time_set");

        private static void time_set(System.IntPtr obj, System.IntPtr pd, Efl.Time.NativeStruct curtime)
        {
            Eina.Log.Debug("function efl_ui_clock_time_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Time _in_curtime = curtime;
                            
                try
                {
                    ((Clock)ws.Target).SetTime(_in_curtime);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clock_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), curtime);
            }
        }

        private static efl_ui_clock_time_set_delegate efl_ui_clock_time_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_clock_field_visible_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_clock_field_visible_get_api_delegate(System.IntPtr obj,  Efl.Ui.ClockType fieldtype);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_field_visible_get_api_delegate> efl_ui_clock_field_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_field_visible_get_api_delegate>(Module, "efl_ui_clock_field_visible_get");

        private static bool field_visible_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ClockType fieldtype)
        {
            Eina.Log.Debug("function efl_ui_clock_field_visible_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Clock)ws.Target).GetFieldVisible(fieldtype);
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
                return efl_ui_clock_field_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fieldtype);
            }
        }

        private static efl_ui_clock_field_visible_get_delegate efl_ui_clock_field_visible_get_static_delegate;

        
        private delegate void efl_ui_clock_field_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype, [MarshalAs(UnmanagedType.U1)] bool visible);

        
        public delegate void efl_ui_clock_field_visible_set_api_delegate(System.IntPtr obj,  Efl.Ui.ClockType fieldtype, [MarshalAs(UnmanagedType.U1)] bool visible);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_field_visible_set_api_delegate> efl_ui_clock_field_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_field_visible_set_api_delegate>(Module, "efl_ui_clock_field_visible_set");

        private static void field_visible_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ClockType fieldtype, bool visible)
        {
            Eina.Log.Debug("function efl_ui_clock_field_visible_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Clock)ws.Target).SetFieldVisible(fieldtype, visible);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_clock_field_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fieldtype, visible);
            }
        }

        private static efl_ui_clock_field_visible_set_delegate efl_ui_clock_field_visible_set_static_delegate;

        
        private delegate void efl_ui_clock_field_limit_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype,  out int min,  out int max);

        
        public delegate void efl_ui_clock_field_limit_get_api_delegate(System.IntPtr obj,  Efl.Ui.ClockType fieldtype,  out int min,  out int max);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_field_limit_get_api_delegate> efl_ui_clock_field_limit_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_field_limit_get_api_delegate>(Module, "efl_ui_clock_field_limit_get");

        private static void field_limit_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ClockType fieldtype, out int min, out int max)
        {
            Eina.Log.Debug("function efl_ui_clock_field_limit_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        min = default(int);        max = default(int);                                    
                try
                {
                    ((Clock)ws.Target).GetFieldLimit(fieldtype, out min, out max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_clock_field_limit_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fieldtype, out min, out max);
            }
        }

        private static efl_ui_clock_field_limit_get_delegate efl_ui_clock_field_limit_get_static_delegate;

        
        private delegate void efl_ui_clock_field_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ClockType fieldtype,  int min,  int max);

        
        public delegate void efl_ui_clock_field_limit_set_api_delegate(System.IntPtr obj,  Efl.Ui.ClockType fieldtype,  int min,  int max);

        public static Efl.Eo.FunctionWrapper<efl_ui_clock_field_limit_set_api_delegate> efl_ui_clock_field_limit_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clock_field_limit_set_api_delegate>(Module, "efl_ui_clock_field_limit_set");

        private static void field_limit_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ClockType fieldtype, int min, int max)
        {
            Eina.Log.Debug("function efl_ui_clock_field_limit_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Clock)ws.Target).SetFieldLimit(fieldtype, min, max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_clock_field_limit_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fieldtype, min, max);
            }
        }

        private static efl_ui_clock_field_limit_set_delegate efl_ui_clock_field_limit_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Identifies a clock field, The widget supports 6 fields : Year, month, Date, Hour, Minute, AM/PM</summary>
[Efl.Eo.BindingEntity]
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

}

}

