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

/// <summary>Frame widget
/// The Frame widget allows for collapsing and expanding the content widget by clicking on the frame label. the label and content can be set using text_set and content_set api.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Frame.NativeMethods]
[Efl.Eo.BindingEntity]
public class Frame : Efl.Ui.LayoutBase, Efl.IContent, Efl.IText, Efl.ITextMarkup, Efl.Input.IClickable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Frame))
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
        efl_ui_frame_class_get();
    /// <summary>Initializes a new instance of the <see cref="Frame"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Frame(Efl.Object parent
            , System.String style = null) : base(efl_ui_frame_class_get(), parent)
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
    protected Frame(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Frame"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Frame(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Frame"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Frame(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
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
    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent
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
                        Efl.Input.ClickableClickedEventArgs args = new Efl.Input.ClickableClickedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedEvent(Efl.Input.ClickableClickedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED";
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
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
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
                        Efl.Input.ClickableClickedAnyEventArgs args = new Efl.Input.ClickableClickedAnyEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedAnyEvent(Efl.Input.ClickableClickedAnyEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED_ANY";
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
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent
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
                        Efl.Input.ClickablePressedEventArgs args = new Efl.Input.ClickablePressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressedEvent(Efl.Input.ClickablePressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_PRESSED";
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
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent
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
                        Efl.Input.ClickableUnpressedEventArgs args = new Efl.Input.ClickableUnpressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressedEvent(Efl.Input.ClickableUnpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_UNPRESSED";
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
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent
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
                        Efl.Input.ClickableLongpressedEventArgs args = new Efl.Input.ClickableLongpressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLongpressedEvent(Efl.Input.ClickableLongpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_LONGPRESSED";
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
    /// <summary>Manually collapse a frame without animations. Use this to toggle the collapsed state of a frame, bypassing animations.</summary>
    /// <returns><c>true</c> to collapse, <c>false</c> to expand.</returns>
    public virtual bool GetCollapse() {
         var _ret_var = Efl.Ui.Frame.NativeMethods.efl_ui_frame_collapse_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Manually collapse a frame without animations. Use this to toggle the collapsed state of a frame, bypassing animations.</summary>
    /// <param name="collapse"><c>true</c> to collapse, <c>false</c> to expand.</param>
    public virtual void SetCollapse(bool collapse) {
                                 Efl.Ui.Frame.NativeMethods.efl_ui_frame_collapse_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),collapse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Toggle autocollapsing of a frame. When <c>enable</c> is <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
    /// <returns>Whether to enable autocollapse.</returns>
    public virtual bool GetAutocollapse() {
         var _ret_var = Efl.Ui.Frame.NativeMethods.efl_ui_frame_autocollapse_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Toggle autocollapsing of a frame. When <c>enable</c> is <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
    /// <param name="autocollapse">Whether to enable autocollapse.</param>
    public virtual void SetAutocollapse(bool autocollapse) {
                                 Efl.Ui.Frame.NativeMethods.efl_ui_frame_autocollapse_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),autocollapse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Manually collapse a frame with animations Use this to toggle the collapsed state of a frame, triggering animations.</summary>
    /// <param name="collapse"><c>true</c> to collapse, <c>false</c> to expand.</param>
    public virtual void CollapseGo(bool collapse) {
                                 Efl.Ui.Frame.NativeMethods.efl_ui_frame_collapse_go_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),collapse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <returns>The sub-object.</returns>
    public virtual Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    public virtual bool SetContent(Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    public virtual Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
         var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
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
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public virtual bool GetInteraction() {
         var _ret_var = Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Press(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Unpress(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    protected virtual void ResetButtonState(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    protected virtual void LongpressAbort(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Manually collapse a frame without animations. Use this to toggle the collapsed state of a frame, bypassing animations.</summary>
    /// <value><c>true</c> to collapse, <c>false</c> to expand.</value>
    public bool Collapse {
        get { return GetCollapse(); }
        set { SetCollapse(value); }
    }
    /// <summary>Toggle autocollapsing of a frame. When <c>enable</c> is <c>true</c>, clicking a frame&apos;s label will collapse the frame vertically, shrinking it to the height of the label. By default, this is DISABLED.</summary>
    /// <value>Whether to enable autocollapse.</value>
    public bool Autocollapse {
        get { return GetAutocollapse(); }
        set { SetAutocollapse(value); }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
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
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Frame.efl_ui_frame_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_frame_collapse_get_static_delegate == null)
            {
                efl_ui_frame_collapse_get_static_delegate = new efl_ui_frame_collapse_get_delegate(collapse_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCollapse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_frame_collapse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_get_static_delegate) });
            }

            if (efl_ui_frame_collapse_set_static_delegate == null)
            {
                efl_ui_frame_collapse_set_static_delegate = new efl_ui_frame_collapse_set_delegate(collapse_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCollapse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_frame_collapse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_set_static_delegate) });
            }

            if (efl_ui_frame_autocollapse_get_static_delegate == null)
            {
                efl_ui_frame_autocollapse_get_static_delegate = new efl_ui_frame_autocollapse_get_delegate(autocollapse_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutocollapse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_frame_autocollapse_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_autocollapse_get_static_delegate) });
            }

            if (efl_ui_frame_autocollapse_set_static_delegate == null)
            {
                efl_ui_frame_autocollapse_set_static_delegate = new efl_ui_frame_autocollapse_set_delegate(autocollapse_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutocollapse") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_frame_autocollapse_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_autocollapse_set_static_delegate) });
            }

            if (efl_ui_frame_collapse_go_static_delegate == null)
            {
                efl_ui_frame_collapse_go_static_delegate = new efl_ui_frame_collapse_go_delegate(collapse_go);
            }

            if (methods.FirstOrDefault(m => m.Name == "CollapseGo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_frame_collapse_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_frame_collapse_go_static_delegate) });
            }

            if (efl_input_clickable_press_static_delegate == null)
            {
                efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
            }

            if (efl_input_clickable_unpress_static_delegate == null)
            {
                efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
            }

            if (efl_input_clickable_button_state_reset_static_delegate == null)
            {
                efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
            }

            if (efl_input_clickable_longpress_abort_static_delegate == null)
            {
                efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
            }

            if (methods.FirstOrDefault(m => m.Name == "LongpressAbort") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
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
            return Efl.Ui.Frame.efl_ui_frame_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_frame_collapse_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_frame_collapse_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_get_api_delegate> efl_ui_frame_collapse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_get_api_delegate>(Module, "efl_ui_frame_collapse_get");

        private static bool collapse_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_frame_collapse_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Frame)ws.Target).GetCollapse();
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
                return efl_ui_frame_collapse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_frame_collapse_get_delegate efl_ui_frame_collapse_get_static_delegate;

        
        private delegate void efl_ui_frame_collapse_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool collapse);

        
        public delegate void efl_ui_frame_collapse_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool collapse);

        public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_set_api_delegate> efl_ui_frame_collapse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_set_api_delegate>(Module, "efl_ui_frame_collapse_set");

        private static void collapse_set(System.IntPtr obj, System.IntPtr pd, bool collapse)
        {
            Eina.Log.Debug("function efl_ui_frame_collapse_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).SetCollapse(collapse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_frame_collapse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), collapse);
            }
        }

        private static efl_ui_frame_collapse_set_delegate efl_ui_frame_collapse_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_frame_autocollapse_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_frame_autocollapse_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_get_api_delegate> efl_ui_frame_autocollapse_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_get_api_delegate>(Module, "efl_ui_frame_autocollapse_get");

        private static bool autocollapse_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_frame_autocollapse_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Frame)ws.Target).GetAutocollapse();
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
                return efl_ui_frame_autocollapse_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_frame_autocollapse_get_delegate efl_ui_frame_autocollapse_get_static_delegate;

        
        private delegate void efl_ui_frame_autocollapse_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool autocollapse);

        
        public delegate void efl_ui_frame_autocollapse_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool autocollapse);

        public static Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_set_api_delegate> efl_ui_frame_autocollapse_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_autocollapse_set_api_delegate>(Module, "efl_ui_frame_autocollapse_set");

        private static void autocollapse_set(System.IntPtr obj, System.IntPtr pd, bool autocollapse)
        {
            Eina.Log.Debug("function efl_ui_frame_autocollapse_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).SetAutocollapse(autocollapse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_frame_autocollapse_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), autocollapse);
            }
        }

        private static efl_ui_frame_autocollapse_set_delegate efl_ui_frame_autocollapse_set_static_delegate;

        
        private delegate void efl_ui_frame_collapse_go_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool collapse);

        
        public delegate void efl_ui_frame_collapse_go_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool collapse);

        public static Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_go_api_delegate> efl_ui_frame_collapse_go_ptr = new Efl.Eo.FunctionWrapper<efl_ui_frame_collapse_go_api_delegate>(Module, "efl_ui_frame_collapse_go");

        private static void collapse_go(System.IntPtr obj, System.IntPtr pd, bool collapse)
        {
            Eina.Log.Debug("function efl_ui_frame_collapse_go was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).CollapseGo(collapse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_frame_collapse_go_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), collapse);
            }
        }

        private static efl_ui_frame_collapse_go_delegate efl_ui_frame_collapse_go_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_longpress_abort was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Frame)ws.Target).LongpressAbort(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_longpress_abort_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiFrame_ExtensionMethods {
    public static Efl.BindableProperty<bool> Collapse<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Frame, T>magic = null) where T : Efl.Ui.Frame {
        return new Efl.BindableProperty<bool>("collapse", fac);
    }

    public static Efl.BindableProperty<bool> Autocollapse<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Frame, T>magic = null) where T : Efl.Ui.Frame {
        return new Efl.BindableProperty<bool>("autocollapse", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Frame, T>magic = null) where T : Efl.Ui.Frame {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

    
    public static Efl.BindableProperty<System.String> Markup<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Frame, T>magic = null) where T : Efl.Ui.Frame {
        return new Efl.BindableProperty<System.String>("markup", fac);
    }

    
}
#pragma warning restore CS1591
#endif
