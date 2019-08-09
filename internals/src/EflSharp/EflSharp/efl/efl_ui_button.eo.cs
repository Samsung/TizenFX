#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Push-button widget
/// Press it and run some function. It can contain a simple label and icon object and it also has an autorepeat feature.</summary>
[Efl.Ui.Button.NativeMethods]
[Efl.Eo.BindingEntity]
public class Button : Efl.Ui.LayoutBase, Efl.IContent, Efl.IText, Efl.Ui.IAutorepeat, Efl.Ui.IClickable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Button))
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
        efl_ui_button_class_get();
    /// <summary>Initializes a new instance of the <see cref="Button"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Button(Efl.Object parent
            , System.String style = null) : base(efl_ui_button_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Button(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Button"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Button(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Button"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Button(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContentContentChangedEvt_Args> ContentChangedEvt
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
                        Efl.IContentContentChangedEvt_Args args = new Efl.IContentContentChangedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
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
    ///<summary>Method to raise event ContentChangedEvt.</summary>
    public void OnContentChangedEvt(Efl.IContentContentChangedEvt_Args e)
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
    /// <summary>Called when a repeated event is emitted</summary>
    public event EventHandler RepeatedEvt
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

                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event RepeatedEvt.</summary>
    public void OnRepeatedEvt(EventArgs e)
    {
        var key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object is in sequence pressed and unpressed, by the primary button</summary>
    public event EventHandler<Efl.Ui.IClickableClickedEvt_Args> ClickedEvt
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
                        Efl.Ui.IClickableClickedEvt_Args args = new Efl.Ui.IClickableClickedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(Efl.Ui.IClickableClickedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    public event EventHandler<Efl.Ui.IClickableClickedAnyEvt_Args> ClickedAnyEvt
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
                        Efl.Ui.IClickableClickedAnyEvt_Args args = new Efl.Ui.IClickableClickedAnyEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedAnyEvt.</summary>
    public void OnClickedAnyEvt(Efl.Ui.IClickableClickedAnyEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_ANY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
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
                        Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_UI_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
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
                        Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_UI_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
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
                        Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_UI_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <returns>The sub-object.</returns>
    virtual public Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    virtual public bool SetContent(Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    virtual public Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.IContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    virtual public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <returns>Timeout in seconds.</returns>
    virtual public double GetAutorepeatInitialTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <param name="t">Timeout in seconds.</param>
    virtual public void SetAutorepeatInitialTimeout(double t) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <returns>Time interval in seconds.</returns>
    virtual public double GetAutorepeatGapTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <param name="t">Time interval in seconds.</param>
    virtual public void SetAutorepeatGapTimeout(double t) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <returns>A bool to turn on/off the repeat event generation.</returns>
    virtual public bool GetAutorepeatEnabled() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <param name="on">A bool to turn on/off the repeat event generation.</param>
    virtual public void SetAutorepeatEnabled(bool on) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),on);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Press(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Unpress(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress. And set the state of the clickable mixin back into the unpressed state.</summary>
    virtual public void ResetButtonState(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <value>Timeout in seconds.</value>
    public double AutorepeatInitialTimeout {
        get { return GetAutorepeatInitialTimeout(); }
        set { SetAutorepeatInitialTimeout(value); }
    }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <value>Time interval in seconds.</value>
    public double AutorepeatGapTimeout {
        get { return GetAutorepeatGapTimeout(); }
        set { SetAutorepeatGapTimeout(value); }
    }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <value>A bool to turn on/off the repeat event generation.</value>
    public bool AutorepeatEnabled {
        get { return GetAutorepeatEnabled(); }
        set { SetAutorepeatEnabled(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Button.efl_ui_button_class_get();
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

            if (efl_content_get_static_delegate == null)
            {
                efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate) });
            }

            if (efl_content_set_static_delegate == null)
            {
                efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate) });
            }

            if (efl_content_unset_static_delegate == null)
            {
                efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnsetContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate) });
            }

            if (efl_text_get_static_delegate == null)
            {
                efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate) });
            }

            if (efl_text_set_static_delegate == null)
            {
                efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate) });
            }

            if (efl_ui_autorepeat_initial_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_get_static_delegate = new efl_ui_autorepeat_initial_timeout_get_delegate(autorepeat_initial_timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatInitialTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_initial_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_set_static_delegate = new efl_ui_autorepeat_initial_timeout_set_delegate(autorepeat_initial_timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatInitialTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_get_static_delegate = new efl_ui_autorepeat_gap_timeout_get_delegate(autorepeat_gap_timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatGapTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_set_static_delegate = new efl_ui_autorepeat_gap_timeout_set_delegate(autorepeat_gap_timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatGapTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_get_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_get_static_delegate = new efl_ui_autorepeat_enabled_get_delegate(autorepeat_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_get_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_set_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_set_static_delegate = new efl_ui_autorepeat_enabled_set_delegate(autorepeat_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_set_static_delegate) });
            }

            if (efl_ui_clickable_press_static_delegate == null)
            {
                efl_ui_clickable_press_static_delegate = new efl_ui_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_press_static_delegate) });
            }

            if (efl_ui_clickable_unpress_static_delegate == null)
            {
                efl_ui_clickable_unpress_static_delegate = new efl_ui_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_unpress_static_delegate) });
            }

            if (efl_ui_clickable_button_state_reset_static_delegate == null)
            {
                efl_ui_clickable_button_state_reset_static_delegate = new efl_ui_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_button_state_reset_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Button.efl_ui_button_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_content_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(Module, "efl_content_get");

        private static Efl.Gfx.IEntity content_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Button)ws.Target).GetContent();
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
                return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_get_delegate efl_content_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity content);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity content);

        public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(Module, "efl_content_set");

        private static bool content_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity content)
        {
            Eina.Log.Debug("function efl_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Button)ws.Target).SetContent(content);
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
                return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), content);
            }
        }

        private static efl_content_set_delegate efl_content_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_content_unset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(Module, "efl_content_unset");

        private static Efl.Gfx.IEntity content_unset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_unset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((Button)ws.Target).UnsetContent();
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
                return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_unset_delegate efl_content_unset_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(Module, "efl_text_get");

        private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Button)ws.Target).GetText();
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
                return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_get_delegate efl_text_get_static_delegate;

        
        private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate void efl_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(Module, "efl_text_set");

        private static void text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).SetText(text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text);
            }
        }

        private static efl_text_set_delegate efl_text_set_static_delegate;

        
        private delegate double efl_ui_autorepeat_initial_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_autorepeat_initial_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate> efl_ui_autorepeat_initial_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_get");

        private static double autorepeat_initial_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Button)ws.Target).GetAutorepeatInitialTimeout();
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
                return efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_initial_timeout_get_delegate efl_ui_autorepeat_initial_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_initial_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        public delegate void efl_ui_autorepeat_initial_timeout_set_api_delegate(System.IntPtr obj,  double t);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate> efl_ui_autorepeat_initial_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_set");

        private static void autorepeat_initial_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).SetAutorepeatInitialTimeout(t);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), t);
            }
        }

        private static efl_ui_autorepeat_initial_timeout_set_delegate efl_ui_autorepeat_initial_timeout_set_static_delegate;

        
        private delegate double efl_ui_autorepeat_gap_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_autorepeat_gap_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate> efl_ui_autorepeat_gap_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_get");

        private static double autorepeat_gap_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Button)ws.Target).GetAutorepeatGapTimeout();
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
                return efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_gap_timeout_get_delegate efl_ui_autorepeat_gap_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_gap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        public delegate void efl_ui_autorepeat_gap_timeout_set_api_delegate(System.IntPtr obj,  double t);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate> efl_ui_autorepeat_gap_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_set");

        private static void autorepeat_gap_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).SetAutorepeatGapTimeout(t);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), t);
            }
        }

        private static efl_ui_autorepeat_gap_timeout_set_delegate efl_ui_autorepeat_gap_timeout_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_autorepeat_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_autorepeat_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate> efl_ui_autorepeat_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate>(Module, "efl_ui_autorepeat_enabled_get");

        private static bool autorepeat_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Button)ws.Target).GetAutorepeatEnabled();
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
                return efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_enabled_get_delegate efl_ui_autorepeat_enabled_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool on);

        
        public delegate void efl_ui_autorepeat_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool on);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate> efl_ui_autorepeat_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate>(Module, "efl_ui_autorepeat_enabled_set");

        private static void autorepeat_enabled_set(System.IntPtr obj, System.IntPtr pd, bool on)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).SetAutorepeatEnabled(on);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), on);
            }
        }

        private static efl_ui_autorepeat_enabled_set_delegate efl_ui_autorepeat_enabled_set_static_delegate;

        
        private delegate void efl_ui_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate> efl_ui_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate>(Module, "efl_ui_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_press_delegate efl_ui_clickable_press_static_delegate;

        
        private delegate void efl_ui_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate> efl_ui_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate>(Module, "efl_ui_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_unpress_delegate efl_ui_clickable_unpress_static_delegate;

        
        private delegate void efl_ui_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate> efl_ui_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate>(Module, "efl_ui_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Button)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_button_state_reset_delegate efl_ui_clickable_button_state_reset_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

