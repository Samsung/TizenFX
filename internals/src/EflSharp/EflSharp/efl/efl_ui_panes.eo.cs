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

/// <summary>Elementary panes class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Panes.NativeMethods]
[Efl.Eo.BindingEntity]
public class Panes : Efl.Ui.LayoutBase, Efl.Input.IClickable, Efl.Ui.ILayoutOrientable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Panes))
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
        efl_ui_panes_class_get();
    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Panes(Efl.Object parent
            , System.String style = null) : base(efl_ui_panes_class_get(), parent)
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
    protected Panes(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Panes(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Panes"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Panes(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when panes got pressed</summary>
    public event EventHandler PressEvent
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

                string key = "_ELM_PANES_EVENT_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_ELM_PANES_EVENT_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressEvent(EventArgs e)
    {
        var key = "_ELM_PANES_EVENT_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when panes are no longer pressed</summary>
    public event EventHandler UnpressEvent
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

                string key = "_ELM_PANES_EVENT_UNPRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_ELM_PANES_EVENT_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressEvent(EventArgs e)
    {
        var key = "_ELM_PANES_EVENT_UNPRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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
    /// <summary>The second half of the panes widget (right or bottom)</summary>
    public Efl.Ui.PanesPart SecondPart
    {
        get
        {
            return GetPart("second") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>The first half of the panes widget (left or top)</summary>
    public Efl.Ui.PanesPart FirstPart
    {
        get
        {
            return GetPart("first") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <returns>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</returns>
    public virtual double GetSplitRatio() {
         var _ret_var = Efl.Ui.Panes.NativeMethods.efl_ui_panes_split_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <param name="ratio">Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</param>
    public virtual void SetSplitRatio(double ratio) {
                                 Efl.Ui.Panes.NativeMethods.efl_ui_panes_split_ratio_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ratio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <returns>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</returns>
    public virtual bool GetFixed() {
         var _ret_var = Efl.Ui.Panes.NativeMethods.efl_ui_panes_fixed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <param name="kw_fixed">Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</param>
    public virtual void SetFixed(bool kw_fixed) {
                                 Efl.Ui.Panes.NativeMethods.efl_ui_panes_fixed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_fixed);
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
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <value>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</value>
    public double SplitRatio {
        get { return GetSplitRatio(); }
        set { SetSplitRatio(value); }
    }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <value>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</value>
    public bool Fixed {
        get { return GetFixed(); }
        set { SetFixed(value); }
    }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Panes.efl_ui_panes_class_get();
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

            if (efl_ui_panes_split_ratio_get_static_delegate == null)
            {
                efl_ui_panes_split_ratio_get_static_delegate = new efl_ui_panes_split_ratio_get_delegate(split_ratio_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSplitRatio") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_split_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_get_static_delegate) });
            }

            if (efl_ui_panes_split_ratio_set_static_delegate == null)
            {
                efl_ui_panes_split_ratio_set_static_delegate = new efl_ui_panes_split_ratio_set_delegate(split_ratio_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSplitRatio") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_split_ratio_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_set_static_delegate) });
            }

            if (efl_ui_panes_fixed_get_static_delegate == null)
            {
                efl_ui_panes_fixed_get_static_delegate = new efl_ui_panes_fixed_get_delegate(fixed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFixed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_fixed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_get_static_delegate) });
            }

            if (efl_ui_panes_fixed_set_static_delegate == null)
            {
                efl_ui_panes_fixed_set_static_delegate = new efl_ui_panes_fixed_set_delegate(fixed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFixed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panes_fixed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_set_static_delegate) });
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
            return Efl.Ui.Panes.efl_ui_panes_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_panes_split_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_panes_split_ratio_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate> efl_ui_panes_split_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate>(Module, "efl_ui_panes_split_ratio_get");

        private static double split_ratio_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panes_split_ratio_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Panes)ws.Target).GetSplitRatio();
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
                return efl_ui_panes_split_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panes_split_ratio_get_delegate efl_ui_panes_split_ratio_get_static_delegate;

        
        private delegate void efl_ui_panes_split_ratio_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ratio);

        
        public delegate void efl_ui_panes_split_ratio_set_api_delegate(System.IntPtr obj,  double ratio);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate> efl_ui_panes_split_ratio_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate>(Module, "efl_ui_panes_split_ratio_set");

        private static void split_ratio_set(System.IntPtr obj, System.IntPtr pd, double ratio)
        {
            Eina.Log.Debug("function efl_ui_panes_split_ratio_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panes)ws.Target).SetSplitRatio(ratio);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panes_split_ratio_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ratio);
            }
        }

        private static efl_ui_panes_split_ratio_set_delegate efl_ui_panes_split_ratio_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_panes_fixed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_panes_fixed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate> efl_ui_panes_fixed_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate>(Module, "efl_ui_panes_fixed_get");

        private static bool fixed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panes_fixed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Panes)ws.Target).GetFixed();
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
                return efl_ui_panes_fixed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panes_fixed_get_delegate efl_ui_panes_fixed_get_static_delegate;

        
        private delegate void efl_ui_panes_fixed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool kw_fixed);

        
        public delegate void efl_ui_panes_fixed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool kw_fixed);

        public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate> efl_ui_panes_fixed_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate>(Module, "efl_ui_panes_fixed_set");

        private static void fixed_set(System.IntPtr obj, System.IntPtr pd, bool kw_fixed)
        {
            Eina.Log.Debug("function efl_ui_panes_fixed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panes)ws.Target).SetFixed(kw_fixed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panes_fixed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_fixed);
            }
        }

        private static efl_ui_panes_fixed_set_delegate efl_ui_panes_fixed_set_static_delegate;

        
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
                    ((Panes)ws.Target).Press(button);
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
                    ((Panes)ws.Target).Unpress(button);
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
                    ((Panes)ws.Target).ResetButtonState(button);
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
                    ((Panes)ws.Target).LongpressAbort(button);
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
public static class Efl_UiPanes_ExtensionMethods {
    public static Efl.BindableProperty<double> SplitRatio<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panes, T>magic = null) where T : Efl.Ui.Panes {
        return new Efl.BindableProperty<double>("split_ratio", fac);
    }

    public static Efl.BindableProperty<bool> Fixed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panes, T>magic = null) where T : Efl.Ui.Panes {
        return new Efl.BindableProperty<bool>("fixed", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panes, T>magic = null) where T : Efl.Ui.Panes {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

        public static Efl.BindableFactoryPart<Efl.Ui.PanesPart> SecondPart<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panes, T> x=null) where T : Efl.Ui.Panes
    {
        return new Efl.BindableFactoryPart<Efl.Ui.PanesPart>("second" ,fac);
    }

        public static Efl.BindableFactoryPart<Efl.Ui.PanesPart> FirstPart<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panes, T> x=null) where T : Efl.Ui.Panes
    {
        return new Efl.BindableFactoryPart<Efl.Ui.PanesPart>("first" ,fac);
    }

}
#pragma warning restore CS1591
#endif
