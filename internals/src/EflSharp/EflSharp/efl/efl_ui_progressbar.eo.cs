#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary progressbar class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Progressbar.NativeMethods]
[Efl.Eo.BindingEntity]
public class Progressbar : Efl.Ui.LayoutBase, Efl.IContent, Efl.IText, Efl.ITextMarkup, Efl.Access.IValue, Efl.Ui.IFormat, Efl.Ui.ILayoutOrientable, Efl.Ui.IRangeDisplay
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Progressbar))
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
        efl_ui_progressbar_class_get();

    /// <summary>Initializes a new instance of the <see cref="Progressbar"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Progressbar(Efl.Object parent
            , System.String style = null) : base(efl_ui_progressbar_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Progressbar(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Progressbar"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Progressbar(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Progressbar"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Progressbar(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Sent after the content is set or unset using the current content object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.ContentContentChangedEventArgs"/></value>
    public event EventHandler<Efl.ContentContentChangedEventArgs> ContentChangedEvent
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
                        Efl.ContentContentChangedEventArgs args = new Efl.ContentContentChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ContentChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentChangedEvent(Efl.ContentContentChangedEventArgs e)
    {
        var key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when the <see cref="Efl.Ui.IRangeDisplay.RangeValue"/> is getting changed.</summary>
    public event EventHandler ChangedEvent
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

                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Emitted when the <see cref="Efl.Ui.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>.</summary>
    public event EventHandler MinReachedEvent
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

                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event MinReachedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMinReachedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Emitted when the <c>range_value</c> has reached the maximum of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>.</summary>
    public event EventHandler MaxReachedEvent
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

                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event MaxReachedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMaxReachedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
    /// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call <see cref="Efl.Ui.Progressbar.SetPulse"/>.</summary>
    /// <returns><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</returns>
    public virtual bool GetPulseMode() {
        var _ret_var = Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_pulse_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
    /// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call <see cref="Efl.Ui.Progressbar.SetPulse"/>.</summary>
    /// <param name="pulse"><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</param>
    public virtual void SetPulseMode(bool pulse) {
        Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_pulse_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pulse);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Start/stop a given progress bar &quot;pulsing&quot; animation, if its under that mode.
    /// Note: This call won&apos;t do anything if <c>obj</c> is not under &quot;pulsing mode&quot;. See <see cref="Efl.Ui.Progressbar.PulseMode"/>.</summary>
    /// <returns><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</returns>
    public virtual bool GetPulse() {
        var _ret_var = Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_pulse_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Start/stop a given progress bar &quot;pulsing&quot; animation, if its under that mode.
    /// Note: This call won&apos;t do anything if <c>obj</c> is not under &quot;pulsing mode&quot;. See <see cref="Efl.Ui.Progressbar.PulseMode"/>.</summary>
    /// <param name="state"><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</param>
    public virtual void SetPulse(bool state) {
        Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_pulse_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),state);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether a textual progress label is shown alongside the progressbar to give an exact numerical indication of the current progress.
    /// Not to be confused with the widget label set through <see cref="Efl.IText.GetText"/>.</summary>
    /// <returns><c>true</c> to show the progress label.</returns>
    public virtual bool GetShowProgressLabel() {
        var _ret_var = Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_show_progress_label_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether a textual progress label is shown alongside the progressbar to give an exact numerical indication of the current progress.
    /// Not to be confused with the widget label set through <see cref="Efl.IText.GetText"/>.</summary>
    /// <param name="show"><c>true</c> to show the progress label.</param>
    public virtual void SetShowProgressLabel(bool show) {
        Efl.Ui.Progressbar.NativeMethods.efl_ui_progressbar_show_progress_label_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),show);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The sub-object.</returns>
    public virtual Efl.Gfx.IEntity GetContent() {
        var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    public virtual bool SetContent(Efl.Gfx.IEntity content) {
        var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Unswallowed object</returns>
    public virtual Efl.Gfx.IEntity UnsetContent() {
        var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
        var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetText(System.String text) {
        Efl.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Markup property</summary>
    /// <returns>The markup-text representation set to this text.</returns>
    public virtual System.String GetMarkup() {
        var _ret_var = Efl.TextMarkupConcrete.NativeMethods.efl_text_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Markup property</summary>
    /// <param name="markup">The markup-text representation set to this text.</param>
    public virtual void SetMarkup(System.String markup) {
        Efl.TextMarkupConcrete.NativeMethods.efl_text_markup_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),markup);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets value displayed by a accessible widget.</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    protected virtual void GetValueAndText(out double value, out System.String text) {
        Efl.Access.ValueConcrete.NativeMethods.efl_access_value_and_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out value, out text);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Value and text property</summary>
    /// <param name="value">Value of widget casted to floating point number.</param>
    /// <param name="text">string describing value in given context eg. small, enough</param>
    /// <returns><c>true</c> if setting widgets value has succeeded, otherwise <c>false</c> .</returns>
    protected virtual bool SetValueAndText(double value, System.String text) {
        var _ret_var = Efl.Access.ValueConcrete.NativeMethods.efl_access_value_and_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value, text);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The range of all possible values and its description</summary>
    /// <param name="lower_limit">Lower limit of the range</param>
    /// <param name="upper_limit">Upper limit of the range</param>
    /// <param name="description">Description of the range</param>
    protected virtual void GetRange(out double lower_limit, out double upper_limit, out System.String description) {
        Efl.Access.ValueConcrete.NativeMethods.efl_access_value_range_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out lower_limit, out upper_limit, out description);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an minimal incrementation value</summary>
    /// <returns>Minimal incrementation value</returns>
    protected virtual double GetIncrement() {
        var _ret_var = Efl.Access.ValueConcrete.NativeMethods.efl_access_value_increment_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <returns>User-provided formatting function.</returns>
    public virtual Efl.Ui.FormatFunc GetFormatFunc() {
        var _ret_var = Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_func_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <param name="func">User-provided formatting function.</param>
    public virtual void SetFormatFunc(Efl.Ui.FormatFunc func) {
        GCHandle func_handle = GCHandle.Alloc(func);
Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_func_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</returns>
    public virtual Eina.Accessor<Efl.Ui.FormatValue> GetFormatValues() {
        var _ret_var = Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_values_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Efl.Ui.FormatValue>(_ret_var, false);

    }

    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</param>
    public virtual void SetFormatValues(Eina.Accessor<Efl.Ui.FormatValue> values) {
        var _in_values = values.Handle;
Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_values_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_values);
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
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="Efl.Ui.FormatStringType.Simple"/>.</param>
    public virtual void GetFormatString(out System.String kw_string, out Efl.Ui.FormatStringType type) {
        Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out kw_string, out type);
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
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="Efl.Ui.FormatStringType.Simple"/>.</param>
    public virtual void SetFormatString(System.String kw_string, Efl.Ui.FormatStringType type) {
        Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string, type);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
    /// Efl.Ui.Format.formatted_value_get uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
    /// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
    /// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
    protected virtual void GetFormattedValue(Eina.Strbuf str, Eina.Value value) {
        Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_formatted_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),str, value);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="Efl.Ui.IFormat.GetFormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
    /// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
    /// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
    protected virtual int GetDecimalPlaces() {
        var _ret_var = Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_decimal_places_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Internal method to be implemented by widgets including this mixin.
    /// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call Efl.Ui.Format.formatted_value_get and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
    protected virtual void ApplyFormattedValue() {
        Efl.Ui.FormatConcrete.NativeMethods.efl_ui_format_apply_formatted_value_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    public virtual Efl.Ui.LayoutOrientation GetOrientation() {
        var _ret_var = Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    public virtual void SetOrientation(Efl.Ui.LayoutOrientation dir) {
        Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <returns>The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</returns>
    public virtual double GetRangeValue() {
        var _ret_var = Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <param name="val">The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</param>
    public virtual void SetRangeValue(double val) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public virtual void GetRangeLimits(out double min, out double max) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out min, out max);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public virtual void SetRangeLimits(double min, double max) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),min, max);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control whether a given progress bar widget is at &quot;pulsing mode&quot; or not.
    /// By default progress bars display values from low to high boundaries. There are situations however in which the progress of a given task is unknown. In these cases, you can set a progress bar widget to a &quot;pulsing state&quot; to give the user an idea that some computation is being done without showing the precise progress rate. In the default theme, it will animate the bar with content, switching constantly between filling it and back to non-filled in a loop. To start and stop this pulsing animation you need to explicitly call <see cref="Efl.Ui.Progressbar.SetPulse"/>.</summary>
    /// <value><c>true</c> to put <c>obj</c> in pulsing mode, <c>false</c> to put it back to its default one</value>
    public bool PulseMode {
        get { return GetPulseMode(); }
        set { SetPulseMode(value); }
    }

    /// <summary>Start/stop a given progress bar &quot;pulsing&quot; animation, if its under that mode.
    /// Note: This call won&apos;t do anything if <c>obj</c> is not under &quot;pulsing mode&quot;. See <see cref="Efl.Ui.Progressbar.PulseMode"/>.</summary>
    /// <value><c>true</c>, to start the pulsing animation, <c>false</c> to stop it</value>
    public bool Pulse {
        get { return GetPulse(); }
        set { SetPulse(value); }
    }

    /// <summary>Whether a textual progress label is shown alongside the progressbar to give an exact numerical indication of the current progress.
    /// Not to be confused with the widget label set through <see cref="Efl.IText.GetText"/>.</summary>
    /// <value><c>true</c> to show the progress label.</value>
    public bool ShowProgressLabel {
        get { return GetShowProgressLabel(); }
        set { SetShowProgressLabel(value); }
    }

    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }

    /// <summary>Markup property</summary>
    /// <value>The markup-text representation set to this text.</value>
    public System.String Markup {
        get { return GetMarkup(); }
        set { SetMarkup(value); }
    }

    /// <summary>Value and text property</summary>
    /// <value>Value of widget casted to floating point number.</value>
    protected (double, System.String) ValueAndText {
        get {
            double _out_value = default(double);
            System.String _out_text = default(System.String);
            GetValueAndText(out _out_value,out _out_text);
            return (_out_value,_out_text);
        }
        set { SetValueAndText( value.Item1,  value.Item2); }
    }

    /// <summary>The range of all possible values and its description</summary>
    protected (double, double, System.String) Range {
        get {
            double _out_lower_limit = default(double);
            double _out_upper_limit = default(double);
            System.String _out_description = default(System.String);
            GetRange(out _out_lower_limit,out _out_upper_limit,out _out_description);
            return (_out_lower_limit,_out_upper_limit,_out_description);
        }
    }

    /// <summary>Gets an minimal incrementation value</summary>
    /// <value>Minimal incrementation value</value>
    protected double Increment {
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

    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <value>Formatting string containing regular characters and format specifiers.</value>
    public (System.String, Efl.Ui.FormatStringType) FormatString {
        get {
            System.String _out_kw_string = default(System.String);
            Efl.Ui.FormatStringType _out_type = default(Efl.Ui.FormatStringType);
            GetFormatString(out _out_kw_string,out _out_type);
            return (_out_kw_string,_out_type);
        }
        set { SetFormatString( value.Item1,  value.Item2); }
    }

    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <value>Direction of the widget.</value>
    public Efl.Ui.LayoutOrientation Orientation {
        get { return GetOrientation(); }
        set { SetOrientation(value); }
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <value>The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</value>
    public double RangeValue {
        get { return GetRangeValue(); }
        set { SetRangeValue(value); }
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <value>The minimum value.</value>
    public (double, double) RangeLimits {
        get {
            double _out_min = default(double);
            double _out_max = default(double);
            GetRangeLimits(out _out_min,out _out_max);
            return (_out_min,_out_max);
        }
        set { SetRangeLimits( value.Item1,  value.Item2); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Progressbar.efl_ui_progressbar_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_progressbar_pulse_mode_get_static_delegate == null)
            {
                efl_ui_progressbar_pulse_mode_get_static_delegate = new efl_ui_progressbar_pulse_mode_get_delegate(pulse_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPulseMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_pulse_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_mode_get_static_delegate) });
            }

            if (efl_ui_progressbar_pulse_mode_set_static_delegate == null)
            {
                efl_ui_progressbar_pulse_mode_set_static_delegate = new efl_ui_progressbar_pulse_mode_set_delegate(pulse_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPulseMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_pulse_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_mode_set_static_delegate) });
            }

            if (efl_ui_progressbar_pulse_get_static_delegate == null)
            {
                efl_ui_progressbar_pulse_get_static_delegate = new efl_ui_progressbar_pulse_get_delegate(pulse_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPulse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_pulse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_get_static_delegate) });
            }

            if (efl_ui_progressbar_pulse_set_static_delegate == null)
            {
                efl_ui_progressbar_pulse_set_static_delegate = new efl_ui_progressbar_pulse_set_delegate(pulse_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPulse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_pulse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_pulse_set_static_delegate) });
            }

            if (efl_ui_progressbar_show_progress_label_get_static_delegate == null)
            {
                efl_ui_progressbar_show_progress_label_get_static_delegate = new efl_ui_progressbar_show_progress_label_get_delegate(show_progress_label_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetShowProgressLabel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_show_progress_label_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_show_progress_label_get_static_delegate) });
            }

            if (efl_ui_progressbar_show_progress_label_set_static_delegate == null)
            {
                efl_ui_progressbar_show_progress_label_set_static_delegate = new efl_ui_progressbar_show_progress_label_set_delegate(show_progress_label_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetShowProgressLabel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_progressbar_show_progress_label_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_progressbar_show_progress_label_set_static_delegate) });
            }

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
            return Efl.Ui.Progressbar.efl_ui_progressbar_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_progressbar_pulse_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_progressbar_pulse_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_get_api_delegate> efl_ui_progressbar_pulse_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_get_api_delegate>(Module, "efl_ui_progressbar_pulse_mode_get");

        private static bool pulse_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_progressbar_pulse_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Progressbar)ws.Target).GetPulseMode();
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
                return efl_ui_progressbar_pulse_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_progressbar_pulse_mode_get_delegate efl_ui_progressbar_pulse_mode_get_static_delegate;

        
        private delegate void efl_ui_progressbar_pulse_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool pulse);

        
        public delegate void efl_ui_progressbar_pulse_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool pulse);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_set_api_delegate> efl_ui_progressbar_pulse_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_mode_set_api_delegate>(Module, "efl_ui_progressbar_pulse_mode_set");

        private static void pulse_mode_set(System.IntPtr obj, System.IntPtr pd, bool pulse)
        {
            Eina.Log.Debug("function efl_ui_progressbar_pulse_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Progressbar)ws.Target).SetPulseMode(pulse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_progressbar_pulse_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pulse);
            }
        }

        private static efl_ui_progressbar_pulse_mode_set_delegate efl_ui_progressbar_pulse_mode_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_progressbar_pulse_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_progressbar_pulse_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_get_api_delegate> efl_ui_progressbar_pulse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_get_api_delegate>(Module, "efl_ui_progressbar_pulse_get");

        private static bool pulse_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_progressbar_pulse_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Progressbar)ws.Target).GetPulse();
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
                return efl_ui_progressbar_pulse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_progressbar_pulse_get_delegate efl_ui_progressbar_pulse_get_static_delegate;

        
        private delegate void efl_ui_progressbar_pulse_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool state);

        
        public delegate void efl_ui_progressbar_pulse_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool state);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_set_api_delegate> efl_ui_progressbar_pulse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_pulse_set_api_delegate>(Module, "efl_ui_progressbar_pulse_set");

        private static void pulse_set(System.IntPtr obj, System.IntPtr pd, bool state)
        {
            Eina.Log.Debug("function efl_ui_progressbar_pulse_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Progressbar)ws.Target).SetPulse(state);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_progressbar_pulse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state);
            }
        }

        private static efl_ui_progressbar_pulse_set_delegate efl_ui_progressbar_pulse_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_progressbar_show_progress_label_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_progressbar_show_progress_label_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_show_progress_label_get_api_delegate> efl_ui_progressbar_show_progress_label_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_show_progress_label_get_api_delegate>(Module, "efl_ui_progressbar_show_progress_label_get");

        private static bool show_progress_label_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_progressbar_show_progress_label_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Progressbar)ws.Target).GetShowProgressLabel();
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
                return efl_ui_progressbar_show_progress_label_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_progressbar_show_progress_label_get_delegate efl_ui_progressbar_show_progress_label_get_static_delegate;

        
        private delegate void efl_ui_progressbar_show_progress_label_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool show);

        
        public delegate void efl_ui_progressbar_show_progress_label_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool show);

        public static Efl.Eo.FunctionWrapper<efl_ui_progressbar_show_progress_label_set_api_delegate> efl_ui_progressbar_show_progress_label_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_progressbar_show_progress_label_set_api_delegate>(Module, "efl_ui_progressbar_show_progress_label_set");

        private static void show_progress_label_set(System.IntPtr obj, System.IntPtr pd, bool show)
        {
            Eina.Log.Debug("function efl_ui_progressbar_show_progress_label_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Progressbar)ws.Target).SetShowProgressLabel(show);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_progressbar_show_progress_label_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), show);
            }
        }

        private static efl_ui_progressbar_show_progress_label_set_delegate efl_ui_progressbar_show_progress_label_set_static_delegate;

        
        private delegate void efl_access_value_and_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String text);

        
        public delegate void efl_access_value_and_text_get_api_delegate(System.IntPtr obj,  out double value, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String text);

        public static Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate> efl_access_value_and_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_value_and_text_get_api_delegate>(Module, "efl_access_value_and_text_get");

        private static void value_and_text_get(System.IntPtr obj, System.IntPtr pd, out double value, out System.String text)
        {
            Eina.Log.Debug("function efl_access_value_and_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                value = default(double);System.String _out_text = default(System.String);

                try
                {
                    ((Progressbar)ws.Target).GetValueAndText(out value, out _out_text);
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
                    _ret_var = ((Progressbar)ws.Target).SetValueAndText(value, text);
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
                lower_limit = default(double);upper_limit = default(double);System.String _out_description = default(System.String);

                try
                {
                    ((Progressbar)ws.Target).GetRange(out lower_limit, out upper_limit, out _out_description);
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
                    _ret_var = ((Progressbar)ws.Target).GetIncrement();
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
                    ((Progressbar)ws.Target).GetFormattedValue(str, value);
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
                    _ret_var = ((Progressbar)ws.Target).GetDecimalPlaces();
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
                    ((Progressbar)ws.Target).ApplyFormattedValue();
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiProgressbar_ExtensionMethods {
    public static Efl.BindableProperty<bool> PulseMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<bool>("pulse_mode", fac);
    }

    public static Efl.BindableProperty<bool> Pulse<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<bool>("pulse", fac);
    }

    public static Efl.BindableProperty<bool> ShowProgressLabel<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<bool>("show_progress_label", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

    public static Efl.BindableProperty<System.String> Markup<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<System.String>("markup", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.FormatFunc> FormatFunc<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<Efl.Ui.FormatFunc>("format_func", fac);
    }

    public static Efl.BindableProperty<Eina.Accessor<Efl.Ui.FormatValue>> FormatValues<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<Eina.Accessor<Efl.Ui.FormatValue>>("format_values", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

    public static Efl.BindableProperty<double> RangeValue<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Progressbar, T>magic = null) where T : Efl.Ui.Progressbar {
        return new Efl.BindableProperty<double>("range_value", fac);
    }

}
#pragma warning restore CS1591
#endif
